using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChassisTek;

namespace Chassis_Editor
{
    class BatchController : Controller
    {
        int largeTextWidth = 400;
        int mediumTextWidth = 200;
        int smallTextWidth = 100;
        int tinyTextWidth = 50;

        public BatchController(Model modelIn, MainWindow mainWindowIn) : 
            base(modelIn, mainWindowIn)
        {
            mode = MainWindow.ProcessMode.BATCH;
            largeTextWidth = mainWindow.largeTextWidth;
            mediumTextWidth = mainWindow.mediumTextWidth;
            smallTextWidth = mainWindow.smallTextWidth;
            tinyTextWidth = mainWindow.tinyTextWidth;
        }

        public override void ComboBoxChanged(object sender, MainWindow.UIGrouping currentGroup)
        {
            Log.updateLog(Log.LogType.SHOW, "Combo Box has changed and directory loaded: " + model.DirectoryLoaded());
            if (!model.DirectoryLoaded())
                return;
            // Getting exceptions while attempting the variable initialization. I suspect the issue is that we are trying to store the SelectedItems before they
            // are established. I think what we need is to split this function by UI Group. Most groups will share one set of code, and the locations
            // group will have its own code
            string comboBoxName = ((ComboBox)sender).Name;
            ComboBox groupComboBox = (ComboBox)mainWindow.GetElement("groupComboBox");
            ComboBox locationComboBox = (ComboBox)mainWindow.GetElement("locationComboBox");
            Button saveChangeButton = (Button)mainWindow.GetElement("saveChangeButton");
            ComboBox operationComboBox = (ComboBox)mainWindow.GetElement("operationComboBox");
            string newSelection;
            string location;
            Log.updateLog(Log.LogType.SHOW, "Reacting to change in " + comboBoxName + " selected value");
            try
            {
                newSelection = "";
                // if the groupComboBox is changing, then store "Tonnage" as that is the default for each location
                if (comboBoxName.Equals("groupComboBox"))
                    newSelection = groupComboBox.SelectedItem.ToString();
                // if the locationComboBox is changing, then store its SelectedItem in the newSelection
                else
                    newSelection = locationComboBox.SelectedItem.ToString();
                // we want to store the groupComboBox's selected item as the location, since that is where we read and write
                location = groupComboBox.SelectedItem.ToString();
                Log.updateLog(Log.LogType.SHOW, "Value selected: " + newSelection + " for location: " + location);

            }
            catch (Exception ex)
            {
                string exception = "Encountered exception initializing variables: " + ex.Message;
                Log.updateLog(Log.LogType.EXCEPTION, exception);
                throw new Exception(exception);
            }

            // I'm pretty sure this is unnecessary, but I don't think it can harm anything. 
            if (newSelection.Equals(""))
            {
                string exception = "Encountered exception in GroupComboBox_SelectedValueChanged: sender " + comboBoxName + " not recognized";
                Log.updateLog(Log.LogType.EXCEPTION, exception);
                MessageBox.Show(exception, "Error Detected", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (comboBoxName.Equals("locationComboBox"))
                Log.updateLog(Log.LogType.CLICK, comboBoxName + " has been changed to " + newSelection);
            else if (comboBoxName.Equals("groupComboBox"))
                Log.updateLog(Log.LogType.CLICK, comboBoxName + " has been changed to " + location);

            TextBox groupTextBox = (TextBox)mainWindow.GetElement("groupTextBox");

            // Each UI Group has its own set of items, but there may be overlaps of names
            if (currentGroup == MainWindow.UIGrouping.DESCRIPTION)
            {
                /* Current items
                    Cost
                    Details
                    Manufacturer
                    Model
                    Name
                    Purchasable
                    Rarity
                    StockRole
                    VariantName
                    YangsThoughts
                */

                switch (newSelection)
                {
                    case "Cost":
                        groupTextBox.Multiline = false;
                        groupTextBox.Text = model.batchChassis.description.Cost.ToString();
                        groupTextBox.Width = mediumTextWidth;
                        groupTextBox.Height = 22;
                        break;
                    case "Details":
                        groupTextBox.Multiline = true;
                        groupTextBox.Text = model.batchChassis.description.Details;
                        groupTextBox.Width = largeTextWidth;
                        groupTextBox.Height = 110;
                        break;
                    case "Manufacturer":
                        groupTextBox.Multiline = false;
                        groupTextBox.Text = model.batchChassis.description.Manufacturer;
                        groupTextBox.Width = mediumTextWidth;
                        groupTextBox.Height = 22;
                        break;
                    case "Model":
                        groupTextBox.Multiline = false;
                        groupTextBox.Text = model.batchChassis.description.Model;
                        groupTextBox.Width = mediumTextWidth;
                        groupTextBox.Height = 22;
                        break;
                    case "Name":
                        groupTextBox.Multiline = false;
                        groupTextBox.Text = model.batchChassis.description.Name;
                        groupTextBox.Width = mediumTextWidth;
                        groupTextBox.Height = 22;
                        break;
                    case "Purchasable":
                        groupTextBox.Multiline = false;
                        groupTextBox.Text = model.batchChassis.description.Purchasable.ToString();
                        groupTextBox.Width = tinyTextWidth;
                        groupTextBox.Height = 22;
                        break;
                    case "Rarity":
                        groupTextBox.Multiline = false;
                        groupTextBox.Text = model.batchChassis.description.Rarity.ToString();
                        groupTextBox.Width = tinyTextWidth;
                        groupTextBox.Height = 22;
                        break;
                    case "StockRole":
                        groupTextBox.Multiline = false;
                        groupTextBox.Text = model.batchChassis.StockRole;
                        groupTextBox.Width = mediumTextWidth;
                        groupTextBox.Height = 22;
                        break;
                    case "VariantName":
                        groupTextBox.Multiline = false;
                        groupTextBox.Text = model.batchChassis.VariantName;
                        groupTextBox.Width = mediumTextWidth;
                        groupTextBox.Height = 22;
                        break;
                    case "YangsThoughts":
                        groupTextBox.Multiline = true;
                        groupTextBox.Text = model.batchChassis.YangsThoughts;
                        groupTextBox.Width = largeTextWidth;
                        groupTextBox.Height = 110;
                        break;
                    default:
                        MessageBox.Show("No match for " + newSelection + " description items");
                        break;
                }

            }
            if (currentGroup == MainWindow.UIGrouping.GENERAL)
            {
                /* Current Items
                    Tonnage
                    InitialTonnage
                    weightClass
                    Heatsinks
                    MaxJumpjets
                    Stability
                    SpotterDistanceMultiplier
                    VisibilityMultiplier
                    SensorRangeMultiplier
                    Signature
                    Radius
                */

                switch (newSelection)
                {
                    case "Tonnage":
                        groupTextBox.Multiline = false;
                        groupTextBox.Text = model.batchChassis.Tonnage.ToString();
                        groupTextBox.Width = smallTextWidth;
                        groupTextBox.Height = 22;
                        break;
                    case "InitialTonnage":
                        groupTextBox.Multiline = false;
                        groupTextBox.Text = model.batchChassis.InitialTonnage.ToString();
                        groupTextBox.Width =  smallTextWidth;
                        groupTextBox.Height = 22;
                        break;
                    case "weightClass":
                        groupTextBox.Multiline = false;
                        groupTextBox.Text = model.batchChassis.weightClass;
                        groupTextBox.Width = mediumTextWidth;
                        groupTextBox.Height = 22;
                        break;
                    case "Heatsinks":
                        groupTextBox.Multiline = false;
                        groupTextBox.Text = model.batchChassis.Heatsinks.ToString();
                        groupTextBox.Width = smallTextWidth;
                        groupTextBox.Height = 22;
                        break;
                    case "MaxJumpjets":
                        groupTextBox.Multiline = false;
                        groupTextBox.Text = model.batchChassis.MaxJumpjets.ToString();
                        groupTextBox.Width = smallTextWidth;
                        groupTextBox.Height = 22;
                        break;
                    case "Stability":
                        groupTextBox.Multiline = false;
                        groupTextBox.Text = model.batchChassis.Stability.ToString();
                        groupTextBox.Width = smallTextWidth;
                        groupTextBox.Height = 22;
                        break;
                    case "SpotterDistanceMultiplier":
                        groupTextBox.Multiline = false;
                        groupTextBox.Text = model.batchChassis.SpotterDistanceMultiplier.ToString();
                        groupTextBox.Width = tinyTextWidth;
                        groupTextBox.Height = 22;
                        break;
                    case "VisibilityMultiplier":
                        groupTextBox.Multiline = false;
                        groupTextBox.Text = model.batchChassis.VisibilityMultiplier.ToString();
                        groupTextBox.Width = tinyTextWidth;
                        groupTextBox.Height = 22;
                        break;
                    case "SensorRangeMultiplier":
                        groupTextBox.Multiline = false;
                        groupTextBox.Text = model.batchChassis.SensorRangeMultiplier.ToString();
                        groupTextBox.Width = tinyTextWidth;
                        groupTextBox.Height = 22;
                        break;
                    case "Signature":
                        groupTextBox.Multiline = false;
                        groupTextBox.Text = model.batchChassis.Signature.ToString();
                        groupTextBox.Width = tinyTextWidth;
                        groupTextBox.Height = 22;
                        break;
                    case "Radius":
                        groupTextBox.Multiline = false;
                        groupTextBox.Text = model.batchChassis.Radius.ToString();
                        groupTextBox.Width = smallTextWidth;
                        groupTextBox.Height = 22;
                        break;
                    case "HardpointDataDefID":
                        groupTextBox.Multiline = false;
                        groupTextBox.Text = model.batchChassis.HardpointDataDefID;
                        groupTextBox.Width = mediumTextWidth;
                        groupTextBox.Height = 22;
                        break;
                    case "PrefabIdentifier":
                        groupTextBox.Multiline = false;
                        groupTextBox.Text = model.batchChassis.PrefabIdentifier;
                        groupTextBox.Width = mediumTextWidth;
                        groupTextBox.Height = 22;
                        break;
                    case "PrefabBase":
                        groupTextBox.Multiline = false;
                        groupTextBox.Text = model.batchChassis.PrefabBase;
                        groupTextBox.Width = mediumTextWidth;
                        groupTextBox.Height = 22;
                        break;
                    case "BattleValue":
                        groupTextBox.Multiline = false;
                        groupTextBox.Text = model.batchChassis.BattleValue.ToString();
                        groupTextBox.Width = mediumTextWidth;
                        groupTextBox.Height = 22;
                        break;
                    default:
                        break;
                }
            }
            if (currentGroup == MainWindow.UIGrouping.MOVEMENT)
            {
                /* Current Items
                    TopSpeed
                    TurnRadius
                    MovementCapDefID
                    PathingCapDefID
                */

                switch (newSelection)
                {
                    case "TopSpeed":
                        groupTextBox.Multiline = false;
                        groupTextBox.Text = model.batchChassis.TopSpeed.ToString();
                        groupTextBox.Width = smallTextWidth;
                        groupTextBox.Height = 22;
                        break;
                    case "TurnRadius":
                        groupTextBox.Multiline = false;
                        groupTextBox.Text = model.batchChassis.TurnRadius.ToString();
                        groupTextBox.Width = smallTextWidth;
                        groupTextBox.Height = 22;
                        break;
                    case "MovementCapDefID":
                        groupTextBox.Multiline = false;
                        groupTextBox.Text = model.batchChassis.MovementCapDefID.ToString();
                        groupTextBox.Width = mediumTextWidth;
                        groupTextBox.Height = 22;
                        break;
                    case "PathingCapDefID":
                        groupTextBox.Multiline = false;
                        groupTextBox.Text = model.batchChassis.PathingCapDefID.ToString();
                        groupTextBox.Width = mediumTextWidth;
                        groupTextBox.Height = 22;
                        break;
                    default:
                        break;
                }
            }
            if (currentGroup == MainWindow.UIGrouping.COMBAT)
            {
                /* Current Items
                    MeleeDamage
                    MeleeInstability
                    MeleeToHitModifier
                    DFADamage
                    DFAToHitModifier
                    DFASelfDamage
                    DFAInstability
                    PunchesWithLeftArm
                */

                switch (newSelection)
                {
                    case "MeleeDamage":
                        groupTextBox.Multiline = false;
                        groupTextBox.Text = model.batchChassis.MeleeDamage.ToString();
                        groupTextBox.Width = smallTextWidth;
                        groupTextBox.Height = 22;
                        break;
                    case "MeleeInstability":
                        groupTextBox.Multiline = false;
                        groupTextBox.Text = model.batchChassis.MeleeInstability.ToString();
                        groupTextBox.Width = smallTextWidth;
                        groupTextBox.Height = 22;
                        break;
                    case "MeleeToHitModifier":
                        groupTextBox.Multiline = false;
                        groupTextBox.Text = model.batchChassis.MeleeToHitModifier.ToString();
                        groupTextBox.Width = tinyTextWidth;
                        groupTextBox.Height = 22;
                        break;
                    case "DFADamage":
                        groupTextBox.Multiline = false;
                        groupTextBox.Text = model.batchChassis.DFADamage.ToString();
                        groupTextBox.Width = smallTextWidth;
                        groupTextBox.Height = 22;
                        break;
                    case "DFAToHitModifier":
                        groupTextBox.Multiline = false;
                        groupTextBox.Text = model.batchChassis.DFAToHitModifier.ToString();
                        groupTextBox.Width = tinyTextWidth;
                        groupTextBox.Height = 22;
                        break;
                    case "DFASelfDamage":
                        groupTextBox.Multiline = false;
                        groupTextBox.Text = model.batchChassis.DFASelfDamage.ToString();
                        groupTextBox.Width = smallTextWidth;
                        groupTextBox.Height = 22;
                        break;
                    case "DFAInstability":
                        groupTextBox.Multiline = false;
                        groupTextBox.Text = model.batchChassis.DFAInstability.ToString();
                        groupTextBox.Width = smallTextWidth;
                        groupTextBox.Height = 22;
                        break;
                    case "PunchesWithLeftArm":
                        groupTextBox.Multiline = false;
                        groupTextBox.Text = model.batchChassis.PunchesWithLeftArm.ToString();
                        groupTextBox.Width = smallTextWidth;
                        groupTextBox.Height = 22;
                        break;
                    default:
                        break;
                }
            }

            // Changes while in the Location UI Group are tricky. If the user is updating the groupComboBox, then they are selecting the location
            // If the user is upating the locationComboBox, however, then they are selecting a field in a location
            // a group change means reselecting the default location box 
            // a location change means updating the groupTextBox
            // since every group change also cause a location change, I think we should have the group switch ONLY if from the group
            // and each case will also change the new selection value to the default selection, I think Tonnage
            // but the location change should happen every time. 
            // BECAUSE CHANGING THE locationComboBox.SelectedItem calls this same function, any changes to the group selects the Tonnage for locationComboBox
            // and then returns. This prevents retrieving the data twice. 

            if (currentGroup == MainWindow.UIGrouping.LOCATION)
            {
                Log.updateLog(Log.LogType.CLICK, "Updating groupTextBox.Text based on Location.SelectedItem");
                Locations loc = new Locations("");

                // group update
                if (comboBoxName.Equals("groupComboBox"))
                {
                    Log.updateLog(Log.LogType.CLICK, "This is a group update: updating locationComboBox");
                    if (!locationComboBox.Visible)
                        locationComboBox.SelectedItem = "Tonnage"; // calls this same function for the location combo box, so no need to proceed
                    else
                        ComboBoxChanged(locationComboBox, currentGroup); // call this same function for the location combo box, so no need to proceed
                    return;
                }

                try
                {
                    loc = model.GetLocation(location, MainWindow.ProcessMode.BATCH);
                }
                catch (Exception ex)
                {
                    string exception = "Encountered exception attempting to match " + location + " against locations in the chassis: " + ex.Message;
                    Log.updateLog(Log.LogType.EXCEPTION, exception);
                    throw new Exception(exception);
                }

                Log.updateLog(Log.LogType.CLICK, "Found match for " + loc.Location);
                // location update
                /* Current Items
                    Tonnage;
                    InventorySlots;
                    MaxArmor;
                    MaxRearArmor; --Only for the torso set
                    InternalStructure;
                */
                ComboBox weaponComboBox = (ComboBox)mainWindow.GetElement("weaponComboBox");
                // If we aren't updating to Hardpoints, then ensure hardpoints are not visible
                if (!newSelection.Equals("Hardpoints"))
                {
                    if (weaponComboBox.Visible)
                        mainWindow.HideAllHardpointElements();
                    groupTextBox.Multiline = false;
                    groupTextBox.Width = smallTextWidth;
                    groupTextBox.Height = 22;
                }
                // if we are setting to hardpoints and either the groupTextBox is visible or the Hardpoints Elements are invisible
                else if (groupTextBox.Visible || !weaponComboBox.Visible)
                {
                    groupTextBox.Hide();
                    operationComboBox.Hide();
                    mainWindow.PlaceAllHardpointElements(operationComboBox.Location.X, operationComboBox.Location.Y);
                    mainWindow.ShowAllHardpointElements();
                }

                Log.updateLog(Log.LogType.CLICK, "Getting value of " + newSelection + " from " + loc.Location);

                switch (newSelection)
                {
                    case "Tonnage":
                        groupTextBox.Text = loc.Tonnage.ToString();
                        groupTextBox.Show();
                        break;
                    case "InventorySlots":
                        groupTextBox.Text = loc.InventorySlots.ToString();
                        groupTextBox.Show();
                        break;
                    case "MaxArmor":
                        groupTextBox.Text = loc.MaxArmor.ToString();
                        groupTextBox.Show();
                        break;
                    case "MaxRearArmor":
                        groupTextBox.Text = loc.MaxRearArmor.ToString();
                        groupTextBox.Show();
                        break;
                    case "InternalStructure":
                        groupTextBox.Text = loc.InternalStructure.ToString();
                        groupTextBox.Show();
                        break;
                    case "Hardpoints":
                        mainWindow.SetAllHardpointValues(loc);
                        break;
                    default:
                        break;
                }

                Log.updateLog(Log.LogType.CLICK, "Reaction Complete");
            }
            mainWindow.MoveSaveChangeButton();
        }

        public override void TextBoxChanged(MainWindow.UIGrouping currentGroup)
        {

        }

        public override Hardpoint AddHardpoint()
        {
            ComboBox groupComboBox = (ComboBox)mainWindow.GetElement("groupComboBox");
            ComboBox weaponComboBox = (ComboBox)mainWindow.GetElement("weaponComboBox");
            CheckBox omniCheckBox = (CheckBox)mainWindow.GetElement("omniCheckBox");
            Log.updateLog(Log.LogType.HARDPOINT, "User clicked the AddHardpoint button");
            string weaponType = "";
            string locationName = "";
            try
            {
                Log.updateLog(Log.LogType.HARDPOINT, "Attempting to store location from groupComboBox");
                locationName = groupComboBox.SelectedItem.ToString();
                Log.updateLog(Log.LogType.HARDPOINT, "location: " + locationName);
                Log.updateLog(Log.LogType.HARDPOINT, "Attempting to store weaponType from weaponComboBox");
                weaponType = weaponComboBox.SelectedItem.ToString();
                Log.updateLog(Log.LogType.HARDPOINT, "weaponType: " + weaponType);

            }
            catch (Exception ex)
            {
                string exception = "Encountered exception while attempting to add a hardpoint: " + ex.Message;
                Log.updateLog(Log.LogType.EXCEPTION, exception);
                MessageBox.Show(exception, "Add Hardpoint Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            Hardpoint h = new Hardpoint();
            h.WeaponMount = weaponType;
            h.Omni = omniCheckBox.Checked;
            model.AddHardpoint(locationName, h, MainWindow.ProcessMode.BATCH);
            return h;
        }

        public override Hardpoint RemoveHardpoint(object sender)
        {
            ComboBox groupComboBox = (ComboBox)mainWindow.GetElement("groupComboBox");
            Log.updateLog(Log.LogType.CLICK, "Clicked remove hardpoint");
            Button button = (Button)sender;
            string locationName = groupComboBox.SelectedItem.ToString();
            Log.updateLog(Log.LogType.HARDPOINT, "Location: " + locationName);

            Hardpoint h = new Hardpoint();

            switch (button.Name)
            {
                // Energy cases
                case "removeEnergyOmniTrueButton":
                    h.WeaponMount = "Energy";
                    h.Omni = true;
                    break;
                case "removeEnergyOmniFalseButton":
                    h.WeaponMount = "Energy";
                    h.Omni = false;
                    break;
                // Ballistic cases
                case "removeBallisticOmniTrueButton":
                    h.WeaponMount = "Ballistic";
                    h.Omni = true;
                    break;
                case "removeBallisticOmniFalseButton":
                    h.WeaponMount = "Ballistic";
                    h.Omni = false;
                    break;
                // AntiPersonnel cases
                case "removeAntiPersonnelOmniTrueButton":
                    h.WeaponMount = "AntiPersonnel";
                    h.Omni = true;
                    break;
                case "removeAntiPersonnelOmniFalseButton":
                    h.WeaponMount = "AntiPersonnel";
                    h.Omni = false;
                    break;
                // Missile cases
                case "removeMissileOmniTrueButton":
                    h.WeaponMount = "Missile";
                    h.Omni = true;
                    break;
                case "removeMissileOmniFalseButton":
                    h.WeaponMount = "Missile";
                    h.Omni = false;
                    break;
                default:
                    throw new Exception("Unable to recognize button with name " + button.Name + " when removing hardpoints");
            }
            try
            {
                Log.updateLog(Log.LogType.HARDPOINT, "WeaponMount: " + h.WeaponMount + " - Omni: " + h.Omni.ToString());
                model.RemoveHardpoint(locationName, h, mode);
            }
            catch (Exception ex)
            {
                string exception = "Encountered exception while trying to remove hardpoint: " + ex.Message;
                Log.updateLog(Log.LogType.EXCEPTION, exception);
                MessageBox.Show(exception, "Error While Removing", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return h;
        }

        public override void ApplyChanges()
        {
            bool writeLog = false;
            string logFileName = "Log " + DateTime.Now.ToString("hh-mm-ss tt") + ".txt";
            DialogResult result = MessageBox.Show("Write a log file of changes?", "Write Log?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                writeLog = true;
            }
            
            Log.updateLog(Log.LogType.CLICK, "Applying changes to a batch of files");
            try
            {
                BatchChangeGroupBox batchChangeGroupBox = (BatchChangeGroupBox)mainWindow.GetElement("batchChangeGroupBox");
                BatchChange[] changes = batchChangeGroupBox.GetChanges();
                model.PerformBatchChanges(changes, writeLog, logFileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Encountered the following exception while trying to apply batch changes: " + ex.Message, "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
