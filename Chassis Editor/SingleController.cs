using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChassisTek;

namespace Chassis_Editor
{
    class SingleController : Controller
    {
        int largeTextWidth = 400;
        int mediumTextWidth = 200;
        int smallTextWidth = 100;
        int tinyTextWidth = 50;

        public SingleController(Model modelIn, MainWindow mainWindowIn) :
            base(modelIn, mainWindowIn)
        {
            mode = MainWindow.ProcessMode.SINGLE;
            largeTextWidth = mainWindow.largeTextWidth;
            mediumTextWidth = mainWindow.mediumTextWidth;
            smallTextWidth = mainWindow.smallTextWidth;
            tinyTextWidth = mainWindow.tinyTextWidth;
        }

        public override void ComboBoxChanged(object sender, MainWindow.UIGrouping currentGroup)
        {
            Log.updateLog(Log.LogType.SHOW, "Combo Box has changed and file loaded: " + model.FileLoaded());
            if (!model.FileLoaded())
                return;
            // Getting exceptions while attempting the variable initialization. I suspect the issue is that we are trying to store the SelectedItems before they
            // are established. I think what we need is to split this function by UI Group. Most groups will share one set of code, and the locations
            // group will have its own code
            string comboBoxName = ((ComboBox)sender).Name;
            ComboBox groupComboBox = (ComboBox)mainWindow.GetElement("groupComboBox");
            ComboBox locationComboBox = (ComboBox)mainWindow.GetElement("locationComboBox");
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
                        groupTextBox.Text = model.chassis.description.Cost.ToString();
                        groupTextBox.Width = mediumTextWidth;
                        groupTextBox.Height = 22;
                        break;
                    case "Details":
                        groupTextBox.Multiline = true;
                        groupTextBox.Text = model.chassis.description.Details;
                        groupTextBox.Width = largeTextWidth;
                        groupTextBox.Height = 110;
                        break;
                    case "Manufacturer":
                        groupTextBox.Multiline = false;
                        groupTextBox.Text = model.chassis.description.Manufacturer;
                        groupTextBox.Width = mediumTextWidth;
                        groupTextBox.Height = 22;
                        break;
                    case "Model":
                        groupTextBox.Multiline = false;
                        groupTextBox.Text = model.chassis.description.Model;
                        groupTextBox.Width = mediumTextWidth;
                        groupTextBox.Height = 22;
                        break;
                    case "Name":
                        groupTextBox.Multiline = false;
                        groupTextBox.Text = model.chassis.description.Name;
                        groupTextBox.Width = mediumTextWidth;
                        groupTextBox.Height = 22;
                        break;
                    case "Purchasable":
                        groupTextBox.Multiline = false;
                        groupTextBox.Text = model.chassis.description.Purchasable.ToString();
                        groupTextBox.Width = tinyTextWidth;
                        groupTextBox.Height = 22;
                        break;
                    case "Rarity":
                        groupTextBox.Multiline = false;
                        groupTextBox.Text = model.chassis.description.Rarity.ToString();
                        groupTextBox.Width = tinyTextWidth;
                        groupTextBox.Height = 22;
                        break;
                    case "StockRole":
                        groupTextBox.Multiline = false;
                        groupTextBox.Text = model.chassis.StockRole;
                        groupTextBox.Width = mediumTextWidth;
                        groupTextBox.Height = 22;
                        break;
                    case "VariantName":
                        groupTextBox.Multiline = false;
                        groupTextBox.Text = model.chassis.VariantName;
                        groupTextBox.Width = mediumTextWidth;
                        groupTextBox.Height = 22;
                        break;
                    case "YangsThoughts":
                        groupTextBox.Multiline = true;
                        groupTextBox.Text = model.chassis.YangsThoughts;
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
                        groupTextBox.Text = model.chassis.Tonnage.ToString();
                        groupTextBox.Width = smallTextWidth;
                        groupTextBox.Height = 22;
                        break;
                    case "InitialTonnage":
                        groupTextBox.Multiline = false;
                        groupTextBox.Text = model.chassis.InitialTonnage.ToString();
                        groupTextBox.Width = smallTextWidth;
                        groupTextBox.Height = 22;
                        break;
                    case "weightClass":
                        groupTextBox.Multiline = false;
                        groupTextBox.Text = model.chassis.weightClass;
                        groupTextBox.Width = mediumTextWidth;
                        groupTextBox.Height = 22;
                        break;
                    case "Heatsinks":
                        groupTextBox.Multiline = false;
                        groupTextBox.Text = model.chassis.Heatsinks.ToString();
                        groupTextBox.Width = smallTextWidth;
                        groupTextBox.Height = 22;
                        break;
                    case "MaxJumpjets":
                        groupTextBox.Multiline = false;
                        groupTextBox.Text = model.chassis.MaxJumpjets.ToString();
                        groupTextBox.Width = smallTextWidth;
                        groupTextBox.Height = 22;
                        break;
                    case "Stability":
                        groupTextBox.Multiline = false;
                        groupTextBox.Text = model.chassis.Stability.ToString();
                        groupTextBox.Width = smallTextWidth;
                        groupTextBox.Height = 22;
                        break;
                    case "SpotterDistanceMultiplier":
                        groupTextBox.Multiline = false;
                        groupTextBox.Text = model.chassis.SpotterDistanceMultiplier.ToString();
                        groupTextBox.Width = tinyTextWidth;
                        groupTextBox.Height = 22;
                        break;
                    case "VisibilityMultiplier":
                        groupTextBox.Multiline = false;
                        groupTextBox.Text = model.chassis.VisibilityMultiplier.ToString();
                        groupTextBox.Width = tinyTextWidth;
                        groupTextBox.Height = 22;
                        break;
                    case "SensorRangeMultiplier":
                        groupTextBox.Multiline = false;
                        groupTextBox.Text = model.chassis.SensorRangeMultiplier.ToString();
                        groupTextBox.Width = tinyTextWidth;
                        groupTextBox.Height = 22;
                        break;
                    case "Signature":
                        groupTextBox.Multiline = false;
                        groupTextBox.Text = model.chassis.Signature.ToString();
                        groupTextBox.Width = tinyTextWidth;
                        groupTextBox.Height = 22;
                        break;
                    case "Radius":
                        groupTextBox.Multiline = false;
                        groupTextBox.Text = model.chassis.Radius.ToString();
                        groupTextBox.Width = smallTextWidth;
                        groupTextBox.Height = 22;
                        break;
                    case "HardpointDataDefID":
                        groupTextBox.Multiline = false;
                        groupTextBox.Text = model.chassis.HardpointDataDefID;
                        groupTextBox.Width = 200;
                        groupTextBox.Height = 22;
                        break;
                    case "PrefabIdentifier":
                        groupTextBox.Multiline = false;
                        groupTextBox.Text = model.chassis.PrefabIdentifier;
                        groupTextBox.Width = mediumTextWidth;
                        groupTextBox.Height = 22;
                        break;
                    case "PrefabBase":
                        groupTextBox.Multiline = false;
                        groupTextBox.Text = model.chassis.PrefabBase;
                        groupTextBox.Width = mediumTextWidth;
                        groupTextBox.Height = 22;
                        break;
                    case "BattleValue":
                        groupTextBox.Multiline = false;
                        groupTextBox.Text = model.chassis.BattleValue.ToString();
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
                        groupTextBox.Text = model.chassis.TopSpeed.ToString();
                        groupTextBox.Width = smallTextWidth;
                        groupTextBox.Height = 22;
                        break;
                    case "TurnRadius":
                        groupTextBox.Multiline = false;
                        groupTextBox.Text = model.chassis.TurnRadius.ToString();
                        groupTextBox.Width = smallTextWidth;
                        groupTextBox.Height = 22;
                        break;
                    case "MovementCapDefID":
                        groupTextBox.Multiline = false;
                        groupTextBox.Text = model.chassis.MovementCapDefID.ToString();
                        groupTextBox.Width = mediumTextWidth;
                        groupTextBox.Height = 22;
                        break;
                    case "PathingCapDefID":
                        groupTextBox.Multiline = false;
                        groupTextBox.Text = model.chassis.PathingCapDefID.ToString();
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
                        groupTextBox.Text = model.chassis.MeleeDamage.ToString();
                        groupTextBox.Width = smallTextWidth;
                        groupTextBox.Height = 22;
                        break;
                    case "MeleeInstability":
                        groupTextBox.Multiline = false;
                        groupTextBox.Text = model.chassis.MeleeInstability.ToString();
                        groupTextBox.Width = smallTextWidth;
                        groupTextBox.Height = 22;
                        break;
                    case "MeleeToHitModifier":
                        groupTextBox.Multiline = false;
                        groupTextBox.Text = model.chassis.MeleeToHitModifier.ToString();
                        groupTextBox.Width = tinyTextWidth;
                        groupTextBox.Height = 22;
                        break;
                    case "DFADamage":
                        groupTextBox.Multiline = false;
                        groupTextBox.Text = model.chassis.DFADamage.ToString();
                        groupTextBox.Width = smallTextWidth;
                        groupTextBox.Height = 22;
                        break;
                    case "DFAToHitModifier":
                        groupTextBox.Multiline = false;
                        groupTextBox.Text = model.chassis.DFAToHitModifier.ToString();
                        groupTextBox.Width = tinyTextWidth;
                        groupTextBox.Height = 22;
                        break;
                    case "DFASelfDamage":
                        groupTextBox.Multiline = false;
                        groupTextBox.Text = model.chassis.DFASelfDamage.ToString();
                        groupTextBox.Width = smallTextWidth;
                        groupTextBox.Height = 22;
                        break;
                    case "DFAInstability":
                        groupTextBox.Multiline = false;
                        groupTextBox.Text = model.chassis.DFAInstability.ToString();
                        groupTextBox.Width = smallTextWidth;
                        groupTextBox.Height = 22;
                        break;
                    case "PunchesWithLeftArm":
                        groupTextBox.Multiline = false;
                        groupTextBox.Text = model.chassis.PunchesWithLeftArm.ToString();
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
                    loc = model.GetLocation(location, MainWindow.ProcessMode.SINGLE);
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
                    mainWindow.PlaceAllHardpointElements(groupTextBox.Location.X, groupTextBox.Location.Y);
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
        }

        public override void TextBoxChanged(MainWindow.UIGrouping currentGroup)
        {
            TextBox groupTextBox = (TextBox)mainWindow.GetElement("groupTextBox");
            ComboBox groupComboBox = (ComboBox)mainWindow.GetElement("groupComboBox");
            ComboBox locationComboBox = (ComboBox)mainWindow.GetElement("locationComboBox");
            string newText = groupTextBox.Text;
            string group = "";
            string selectedItem = groupComboBox.SelectedItem.ToString();
            switch (currentGroup)
            {
                case MainWindow.UIGrouping.DESCRIPTION:
                    group = "Description";
                    break;
                case MainWindow.UIGrouping.GENERAL:
                    group = "General";
                    break;
                case MainWindow.UIGrouping.MOVEMENT:
                    group = "Movement";
                    break;
                case MainWindow.UIGrouping.COMBAT:
                    group = "Combat";
                    break;
                case MainWindow.UIGrouping.LOCATION:
                    group = groupComboBox.SelectedItem.ToString();
                    selectedItem = locationComboBox.SelectedItem.ToString();
                    break;
                default:
                    break;
            }

            model.UpdateModel(group, selectedItem, newText);
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
            model.AddHardpoint(locationName, h, MainWindow.ProcessMode.SINGLE);
            return h;
        }

        public override Hardpoint RemoveHardpoint(Object sender)
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
            Log.updateLog(Log.LogType.CLICK, "Applying changes to single file");
            try
            {
                model.WriteChassisFile();
                MessageBox.Show("Successfully saved file: " + model.chassisFile, "Successful Write", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Encountered the following exception while trying to apply changes: " + ex.Message, "Failure to Write", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
