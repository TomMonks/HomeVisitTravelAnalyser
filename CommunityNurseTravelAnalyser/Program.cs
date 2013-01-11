using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using Microsoft.VisualBasic.ApplicationServices;

namespace HomeVisitTravelAnalyser
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new MainForm());

            new MyApp().Run(args);
            
        }
    }

    public class MyApp : WindowsFormsApplicationBase 
    {

        protected override void OnCreateSplashScreen() {
          this.SplashScreen = new Splash();
        }

        protected override void OnCreateMainForm() 
        {
          // any initialization here
          //...
          System.Threading.Thread.Sleep(4000);  // Test
          // Then create the main form, the splash screen will automatically close
          this.MainForm = new MainForm();
        }
  }


}
