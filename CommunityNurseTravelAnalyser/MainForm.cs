using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using EasyDatabase.MSAccess;
using EasyDatabase.SQL;

using EasyExcel;
using DistanceFunctions;
using Statistics.Descriptive;
using LocalSearch;
using System.Diagnostics;

using HomeVisitTravelAnalyser.Results;
using HomeVisitTravelAnalyser.Query;
using HomeVisitTravelAnalyser.UI;
using HomeVisitTravelAnalyser.Analysis;
using HomeVisitTravelAnalyser.Serialization;

namespace HomeVisitTravelAnalyser
{
    public partial class MainForm : Form
    {
        protected List<ILocalityQuerySetup> setups;
        
        protected List<LocalityResult> homeResults;
        protected List<LocalityResult> gpResults;
        protected TabPage tspResultsTab;
        protected TabPage centroidResultsTab;
        protected int resultsPagesOpen;

        #region Constants

        protected const string RUNNING_CENTROID_MSG = "Please wait. Analysing by change in spread of postcodes";
        protected const string RUNNING_TSP_MSG = "Please wait. Analysing by change in nurse travel distance";

        protected const string USER_SETTINGS_PATH = "usersettings.txt";

        #endregion

        protected WaitForm waitForm = new WaitForm();

        public BackgroundEventHandler OnBackgroundEvent;

        public MainForm()
        {
            InitializeComponent();
            resultsPagesOpen = 0;


            if (System.IO.File.Exists(USER_SETTINGS_PATH))
            {

                DeserializeSettings();             
            }

        }

        private void DeserializeSettings()
        {

            Serializer serializer = new Serializer();

            try
            {
                ObjectToSerialize objectToSerialize = serializer.DeSerializeObject(USER_SETTINGS_PATH);

                this.localityQuerySetupPanel1.Settings = (UserQuerySettings)objectToSerialize.Queries[0];
                this.localityQuerySetupPanel2.Settings = (UserQuerySettings)objectToSerialize.Queries[1];
            }
            catch(System.Runtime.Serialization.SerializationException)
            {

                Console.WriteLine("There was an error reading the user settings file. \nDefault settings have been used instead.");

            }
        }
               

        private void MainForm_Shown(object sender, EventArgs e)
        {
            var mappings = this.localityQuerySetupPanel2.FieldMappings;
            mappings["Locality"] = "GP_Locality";
            this.localityQuerySetupPanel2.FieldMappings = mappings;

            this.setups = new List<ILocalityQuerySetup>();
            
            
            this.setups.Add(this.localityQuerySetupPanel1);
            this.setups.Add(this.localityQuerySetupPanel2);

            SetToolstripImages();
        }

        private void SetToolstripImages()
        {
            this.analysisOptionsToolStripMenuItem.Image = Properties.Resources.sprocket_dark;
            this.homePostcodeConfigToolStripMenuItem.Image = Properties.Resources.pin;
            this.gPAllocationConfigToolStripMenuItem.Image = Properties.Resources.pin;
            this.runAnalysisToolStripMenuItem.Image = Properties.Resources.play_green;
        }

        #region Tabpage manipulation


        private void AddResultsPanel(string pageName, string pageText, ResultsPanel resultsPanel)
        {
            resultsPagesOpen++;
            var newPage = new TabPage("Results " + resultsPagesOpen + " - " + pageText);
                       
            newPage.Location = new System.Drawing.Point(4, 22);
            newPage.Size = new System.Drawing.Size(1185, 569);
            newPage.TabIndex = 3;
            newPage.Name = "resultsTab" + resultsPagesOpen;
            newPage.UseVisualStyleBackColor = true;
            newPage.ImageIndex = 3;
           
            resultsPanel.Location = new System.Drawing.Point(3, 3);
            resultsPanel.Name = "resultsPanel_" + resultsPagesOpen;
            resultsPanel.ResultsDescription = "Results " + resultsPagesOpen + " - " + pageText;
            resultsPanel.Size = new System.Drawing.Size(1153, 525);
            resultsPanel.Anchor =  ((System.Windows.Forms.AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right)))));

            resultsPanel.TabIndex = 0;

            AddContextMenuToTab(newPage);

            newPage.Controls.Add(resultsPanel);
            
            this.tabControl1.TabPages.Add(newPage);
            this.tabControl1.SelectedTab = newPage;

            

        }


        private void AddContextMenuToTab(TabPage tab)
        {
            var menu = new ContextMenuStrip();
            menu.Items.Add("Close", null, CloseTabPage);
            tab.ContextMenuStrip = menu;
           
        }

        private void CloseTabPage(object sender, EventArgs e)
        {
           //var menuitem = (MenuItem)sender;
            
            //page.Parent.Controls.Remove(page);
            this.tabControl1.TabPages.Remove(this.tabControl1.SelectedTab);
        }


        protected void ShowTabPage(TabPage toShow)
        {
            if (!this.tabControl1.TabPages.Contains(toShow))
            {
                this.tabControl1.TabPages.Add(toShow);
            }

            this.tabControl1.SelectedTab = toShow;
        }


        #endregion

        #region Menu item action



        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void runAnalysisToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
            this.backgroundWorker1.RunWorkerAsync();
            this.OnBackgroundEvent += waitForm.UpdateMessage;
            waitForm.ShowDialog(this);
        }


        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.backgroundWorker1.RunWorkerAsync();
            this.OnBackgroundEvent += waitForm.UpdateMessage;
            waitForm.ShowDialog();
        }


        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var about = new AboutBox1();
            about.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void homePostcodeConfigToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowTabPage(this.tp_HomeConfig);
        }

        private void gPAllocationConfigToolStripMenuItem_Click(object sender, EventArgs e)
        {

            ShowTabPage(this.tp_GPConfig);
        }

        private void analysisOptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            ShowTabPage(this.tp_AnalysisOptions);
        }


        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        #endregion
                
        #region Old single thread code for analysis


        public void RunAnalysis()
        {
            if (this.analysisOptionPanel1.CentroidAnalysis)
            {
                if (this.analysisOptionPanel1.DailyCentroidMethod)
                {
                    DailyCentroidAnalysis();
                }
                else
                {
                    CentroidAnalysis();
                }
                Console.WriteLine("Centroid analysis complete");
            }

            if (this.analysisOptionPanel1.DistanceAnalysis)
            {
                DistanceAnalysis();
                Console.WriteLine("TSP analysis complete");
            }

            Console.WriteLine("All analysis is complete");
            this.runAnalysisToolStripMenuItem.Enabled = true;

        }


        private void DistanceAnalysis()
        {
            int pass = 0;

            foreach (var setup in this.setups)
            {
                pass++;
                var patientResults = new List<LocalityResult>();

                var salesman = new TravelingSalesmanAnalyser(setup, this.analysisOptionPanel1);

                salesman.Execute();

                if (pass == 1)
                {

                    this.homeResults = new List<LocalityResult>();
                    salesman.Result.ForEach(x => homeResults.Add(x));

                }
                else
                {

                    this.gpResults = new List<LocalityResult>();
                    salesman.Result.ForEach(x => gpResults.Add(x));
                    var resultsPanel = new ResultsPanel();
                    resultsPanel.SetResults(homeResults, gpResults, setup.SelectedLocalities);
                    AddResultsPanel("TSPResults", "TSP Results", resultsPanel);
                }
            }


        }


        private void DailyCentroidAnalysis()
        {
            int pass = 0;

            foreach (var setup in this.setups)
            {
                pass++;
                var patientResults = new List<LocalityResult>();

                var analyser = new CentroidDailyAnalysisMethod(setup);

                analyser.Execute();

                if (pass == 1)
                {

                    this.homeResults = new List<LocalityResult>();
                    analyser.Result.ForEach(x => homeResults.Add(x));

                }
                else
                {

                    this.gpResults = new List<LocalityResult>();
                    analyser.Result.ForEach(x => gpResults.Add(x));
                    var resultsPanel = new ResultsPanel();
                    resultsPanel.SetResults(homeResults, gpResults, setup.SelectedLocalities);
                    AddResultsPanel("DailyCentroidAnalysis", "Centroid Analysis - Daily", resultsPanel);
                }
            }



        }

        private void CentroidAnalysis()
        {
            int pass = 0;

            foreach (var setup in this.setups)
            {
                pass++;
                var patientResults = new List<LocalityResult>();

                var analyser = new CentroidAnalysisMethod(setup);

                analyser.Execute();

                if (pass == 1)
                {

                    this.homeResults = new List<LocalityResult>();
                    analyser.Result.ForEach(x => homeResults.Add(x));

                }
                else
                {

                    this.gpResults = new List<LocalityResult>();
                    analyser.Result.ForEach(x => gpResults.Add(x));

                    var resultsPanel = new ResultsPanel();
                    resultsPanel.SetResults(homeResults, gpResults, setup.SelectedLocalities);
                    AddResultsPanel("CentroidAnalysis", "Centroid Analysis - All", resultsPanel);

                }
            }



        }



        #endregion

        #region Code that runs analysis

        private ResultsContainer CentroidAnalysis2()
        {
            int pass = 0;

            var results = new ResultsContainer() { Name = "Centroid Analysis - All" , PageName = "CentroidAnalysis"};
            Console.WriteLine("## Running group centroid analysis ## ");
            
            foreach (var setup in this.setups)
            {
                pass++;
                var patientResults = new List<LocalityResult>();

                var analyser = new CentroidAnalysisMethod(setup);

                OutputAllocationStrategyName(pass);

                analyser.Execute();

                if (pass == 1)
                {

                    analyser.Result.ForEach(x => results.Home.Add(x));

                }
                else
                {

                    analyser.Result.ForEach(x => results.GP.Add(x));
                }
            }

            return results;

        }

        private ResultsContainer DailyCentroidAnalysis2()
        {
            int pass = 0;

            var results = new ResultsContainer() { Name = "Centroid Analysis - Daily", PageName = "DailyCentroidAnalysis" };

            foreach (var setup in this.setups)
            {
                pass++;
                var patientResults = new List<LocalityResult>();

                var analyser = new CentroidDailyAnalysisMethod(setup);

                OutputAllocationStrategyName(pass);

                analyser.Execute();

                if (pass == 1)
                {

                    analyser.Result.ForEach(x => results.Home.Add(x));

                }
                else
                {

                    analyser.Result.ForEach(x => results.GP.Add(x));

                }
            }


            return results;
        }


        private ResultsContainer DistanceAnalysis2()
        {
            int pass = 0;

            var results = new ResultsContainer() { Name = "TSP Results", PageName = "TSPResults" };

            Console.WriteLine("## Running travelling salesman analysis ## ");

            foreach (var setup in this.setups)
            {
                pass++;
                var patientResults = new List<LocalityResult>();

                var salesman = new TravelingSalesmanAnalyser(setup, this.analysisOptionPanel1);


                OutputAllocationStrategyName(pass);

                salesman.Execute();

                if (pass == 1)
                {

                    salesman.Result.ForEach(x => results.Home.Add(x));

                }
                else
                {

                    salesman.Result.ForEach(x => results.GP.Add(x));

                }
            }

            return results;


        }

        private static void OutputAllocationStrategyName(int pass)
        {
            if (pass == 1)
            {

                Console.WriteLine("## Patients allocated by home postcode ## ");
            }
            else
            {
                Console.WriteLine("## Patients allocated by GP surgery postcode ## ");
            }
        }

#endregion

        #region background worker 

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

            List<ResultsContainer> results = new List<ResultsContainer>();

            if (this.analysisOptionPanel1.CentroidAnalysis)
            {
                this.backgroundWorker1.ReportProgress(0, RUNNING_CENTROID_MSG);

                if (this.analysisOptionPanel1.DailyCentroidMethod)
                {
                    results.Add(DailyCentroidAnalysis2());
                }
                else
                {
                    results.Add(CentroidAnalysis2());
                }

                Console.WriteLine("Centroid analysis complete");
            }

            if (this.analysisOptionPanel1.DistanceAnalysis)
            {
                this.backgroundWorker1.ReportProgress(0, RUNNING_TSP_MSG);

                results.Add(DistanceAnalysis2());
                Console.WriteLine("TSP analysis complete");
            }

            Console.WriteLine("All analysis is complete");

            e.Result = results;

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            var results = (List<ResultsContainer>)e.Result;

            foreach (var result in results)
            {
                var resultsPanel = new ResultsPanel();
                resultsPanel.SetResults(result.Home, result.GP, setups[0].SelectedLocalities);
                AddResultsPanel(result.PageName, result.Name, resultsPanel);
            }

            waitForm.Close();
        }

        private void teToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new WaitForm();
            frm.ShowDialog();
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            string msg = (string)e.UserState;

            Console.WriteLine(msg);

            if (OnBackgroundEvent != null)
            {
                OnBackgroundEvent(this, new BackgroundEventArgs(){Message = msg});
            }
        }

        #endregion

        #region User settings

        /// <summary>
        /// When the main form closes the settings data is serialised.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ObjectToSerialize objectToSerialize = new ObjectToSerialize();
            objectToSerialize.Queries.Add(this.localityQuerySetupPanel1.Settings);
            objectToSerialize.Queries.Add(this.localityQuerySetupPanel2.Settings);

            Serializer serializer = new Serializer();
            serializer.SerializeObject(USER_SETTINGS_PATH, objectToSerialize);
        }

        #endregion
    }
}
