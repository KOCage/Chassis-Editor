using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using ChassisTek;
using System.Windows.Forms;

namespace Chassis_Editor
{
    public abstract class Controller
    {
        protected Model model;
        protected MainWindow mainWindow;
        protected MainWindow.ProcessMode mode;

        public Controller(Model modelIn, MainWindow mainWindowIn)
        {
            model = modelIn;
            mainWindow = mainWindowIn;
            Program.updateLog(Log.LogType.INITIALIZE, "Controller initialized");
        }

        public abstract void ComboBoxChanged(object sender, MainWindow.UIGrouping currentGroup);

        public abstract void TextBoxChanged(MainWindow.UIGrouping currentGroup);

        public abstract Hardpoint AddHardpoint();

        public abstract Hardpoint RemoveHardpoint(Object sender);

        public abstract void ApplyChanges();
    }
}
