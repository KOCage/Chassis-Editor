using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChassisTek;
using System.IO;

namespace Chassis_Editor
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]

        static void Main()
        {
            // Attempting to MVC
            Model model = new Model();
            // Controller controller = new Controller(model);
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainWindow(model));
            } catch (Exception ex)
            {
                Log.updateLog(Log.LogType.EXCEPTION, "FATAL EXCEPTION: " + ex.Message);
            }

            // Write log of MVC Attempt
            if (Log.LoggingEnabled())
            {
                string dtStamp = DateTime.Now.ToString("hh-mm-tt");
                string path = Directory.GetCurrentDirectory() + "\\log " + dtStamp + ".txt";
                Log.WriteLog(path);
            }

        }

        public static void updateLog(Log.LogType logType, string log)
        {
            Log.updateLog(logType, log);
        }
    }
}
