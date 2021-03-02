using System;
using System.Drawing;
using System.Windows.Forms;
using ChassisTek;
using System.IO;

namespace Chassis_Editor
{
    public partial class MainWindow : Form
    {
        public enum ProcessMode { SINGLE, BATCH };
        ProcessMode currentMode = ProcessMode.SINGLE;
        public enum UIGrouping { DESCRIPTION, GENERAL, MOVEMENT, COMBAT, LOCATION };
        UIGrouping currentGroup = UIGrouping.DESCRIPTION;

        Model model;

        // The power of polymorphism compells me
        SingleController singleController;
        BatchController batchController;
        Controller currentController;

        BatchChangeGroupBox batchChangeGroupBox = null;


        // Size of mainWindow changes with the process mode. We need more space for batch changes
        Size singleSize = new Size(1100, 600);
        Size batchSize = new Size(1100, 600);

        string initDirectory = "C:\\";
        bool LoadButtonExtended = true;
        bool changingGroup = false;
        int loadSingleWidth = 0;
        int loadBatchWidth = 0;
        int loadSingleHeight = 0;
        int loadBatchHeight = 0;
        public int largeTextWidth = 300;
        public int mediumTextWidth = 200;
        public int smallTextWidth = 100;
        public int tinyTextWidth = 50;

        bool[] hardpointChanges = { false, false, false, false, false, false, false, false };

        // These are each UI Group's fields that a user can update using the groupComboBox and groupTextBox elements. 
        string[] descriptionItems = {"Cost","Details","Manufacturer","Model","Name","Purchasable",
            "Rarity","StockRole","VariantName","YangsThoughts"};
        string[] generalItems = {"Tonnage","InitialTonnage","weightClass","Heatsinks","MaxJumpjets",
            "Stability","SpotterDistanceMultiplier","VisibilityMultiplier","SensorRangeMultiplier",
            "Signature","Radius","HardpointDataDefID","PrefabIdentifier","PrefabBase","BattleValue"};
        string[] combatItems = {"MeleeDamage","MeleeInstability","MeleeToHitModifier","DFADamage",
            "DFAToHitModifier","DFASelfDamage","DFAInstability","PunchesWithLeftArm" };
        string[] movementItems = { "TopSpeed", "TurnRadius", "MovementCapDefID",
            "PathingCapDefID" };

        // Locations have their own fields to be modified, so they will use the locationComboBox and groupTextBox elements for updates.
        // The groupComboBox will be used to select which location to modify
        string[] locationsItems = {"Head","CenterTorso","LeftTorso","RightTorso","LeftArm",
            "RightArm","LeftLeg","RightLeg"};
        string[] locationFields = {"Tonnage","InventorySlots","MaxArmor","MaxRearArmor",
            "InternalStructure", "Hardpoints"};
        // This is a mapping of UI Groups and their data items within the ChassisTek classes
        /*
        UI Grouping: Description 
        public Description description
            public float Cost
            public float Rarity
            public bool Purchasable
            public string Manufacturer
            public string Model
            public string Name
            public string Details
        public string VariantName
        public string StockRole
        public string YangsThoughts

        UI Grouping: General
        public float Tonnage
        public float InitialTonnage
        public string weightClass
        public float Heatsinks
        public float MaxJumpjets
        public float Stability
        public float SpotterDistanceMultiplier
        public float VisibilityMultiplier
        public float SensorRangeMultiplier
        public float Signature
        public float Radius
        public string HardpointDataDefID
        public string PrefabIdentifier
        public string PrefabBase
        public float BattleValue

        UI Grouping: Movement
        public float TopSpeed
        public float TurnRadius
        public float MovementCapDefID
        public float PathingCapDefID

        UI Grouping: Combat
        public float MeleeDamage
        public float MeleeInstability
        public float MeleeToHitModifier
        public float DFADamage
        public float DFAToHitModifier
        public float DFASelfDamage
        public float DFAInstability

        UI Grouping: Locations
        public Locations Location
            public float Tonnage
            public float InventorySlots
            public float MaxArmor
            public float MaxRearArmor
            public float InternalStructure
            public Hardpoint[] Hardpoints
        */

        public MainWindow(Model modelIn)
        {
            InitializeComponent();
            model = modelIn;

            singleController = new SingleController(modelIn, this);
            batchController = new BatchController(modelIn, this);
            currentController = singleController;

            Size = singleSize;

            // store the width/height of the load button with each of the images. 
            // This will be used to place UI elements in the same spot even if the load button is retracted
            loadButton.Image = Properties.Resources.LoadChassisButton;
            loadBatchWidth = loadButton.Size.Width;
            loadBatchHeight = loadButton.Size.Height;
            loadSingleWidth = loadButton.Size.Width;
            loadSingleHeight = loadButton.Size.Height;
            Log.updateLog(Log.LogType.INITIALIZE, "MainWindow initialized");
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            switch (currentMode)
            {
                case ProcessMode.SINGLE:
                    loadChassisFile();
                    break;
                case ProcessMode.BATCH:
                    loadDirectory();
                    break;
                default:
                    break;
            }
        }

        // an open file dialog window is shown. The user selects a chassis file
        // and the path is passed to the model to load
        // After a file is loaded in to the model, the loadButton is Retracted. 
        private void loadChassisFile()
        {
            Log.updateLog(Log.LogType.FILELOAD, "Entering loadChassisFileButton_Click");
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.InitialDirectory = initDirectory;
            fileDialog.Filter = "Chassis Files (Chassis*.json)|Chassis*.json";
            fileDialog.FilterIndex = 1;
            fileDialog.RestoreDirectory = true;
            Log.updateLog(Log.LogType.FILELOAD, "Displaying fileDialog to user");
            if (fileDialog.ShowDialog() == DialogResult.Cancel)
                return;

            try
            {
                // logged by the Model.LoadChassisFile function
                model.LoadChassisFile(fileDialog.FileName);

                Log.updateLog(Log.LogType.FILELOAD, "Completed file loading");
                // If a chassis file is loaded, retract the LoadChassisFileButton and show the applyChangesButton
                if (model.FileLoaded())
                {
                    // If a file is loaded, then return to the description UI group and update the display
                    currentGroup = UIGrouping.DESCRIPTION;
                    UpdateDisplay();

                    // store the file directory of the current file so that we can load files from there again, but also so we can save the file 
                    initDirectory = model.chassisFileDirectory;
                    Log.updateLog(Log.LogType.SHOW, "Attempting to load the fileTextBox.Text with " + model.chassisFileName);
                    fileTextBox.Text = model.chassisFileName;
                    directoryLabel.Text = model.chassisFileDirectory;
                    RetractLoadButton();
                }
            }
            catch (Exception ex)
            {
                Log.updateLog(Log.LogType.EXCEPTION, "Displayed error to user: " + ex.Message);
                MessageBox.Show(ex.Message, "File Load Error: ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // a folder browser dialog window is shown. The user selected a directory and the path is passed to the model to load
        // After a directory is loaded, the loadButton is Retracted
        private void loadDirectory()
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            // I suppose you might go to select a folder and then realize you didn't make one... you can always add files between now and clicking apply
            folderBrowserDialog.ShowNewFolderButton = true;
            if (folderBrowserDialog.ShowDialog() == DialogResult.Cancel)
                return;

            string path = folderBrowserDialog.SelectedPath;
            // Not sure if you can somehow return an invalid path from FolderBrowserDialog, but just in case, I'll check it
            if (Directory.Exists(path))
            {
                model.batchDirectory = path;
                directoryLabel.Text = path;
                RetractLoadButton();
                UpdateDisplay();
            }
            else
                throw new Exception("Selected path '" + path + "' does not exist.");

        }

        // Ensure that the correct elements are displayed in the correct locations
        public void UpdateDisplay()
        {
            switch (currentMode)
            {
                case ProcessMode.SINGLE:
                    UpdateSingleDisplay();
                    break;
                case ProcessMode.BATCH:
                    UpdateBatchDisplay();
                    break;
                default:
                    break;
            }
        }

        // Display UI for the user to perform single file modifictions
        private void UpdateSingleDisplay()
        {
            Log.updateLog(Log.LogType.SHOW, "Updating the display for single file edit");
            changingGroup = true;

            int verticalMargin = 20;
            int x = loadButton.Location.X;
            int y = loadButton.Location.Y + loadSingleHeight + verticalMargin;

            // If a file has been loaded and the UI Grouping Buttons are hidden, then show them
            if (model.FileLoaded() && !descriptionGroupButton.Visible)
            {
                Log.updateLog(Log.LogType.INITIALIZE, "Displaying UI Grouping Buttons for first time");
                descriptionGroupButton.Location = new Point(x, y);
                y += descriptionGroupButton.Size.Height + verticalMargin;
                generalGroupButton.Location = new Point(x, y);
                y += generalGroupButton.Size.Height + verticalMargin;
                movementGroupButton.Location = new Point(x, y);
                y += movementGroupButton.Size.Height + verticalMargin;
                combatGroupButton.Location = new Point(x, y);
                y += combatGroupButton.Size.Height + verticalMargin;
                locationsGroupButton.Location = new Point(x, y);

                descriptionGroupButton.Show();
                generalGroupButton.Show();
                movementGroupButton.Show();
                combatGroupButton.Show();
                locationsGroupButton.Show();

                // Prepare the fileTextBox to appear 20 pixels to the right of the loadButton and the applyChangesButton to appear 20 pixels beyond that
                Log.updateLog(Log.LogType.INITIALIZE, "Displaying the file text box and apply changes button");
                x = loadButton.Location.X;
                y = loadButton.Location.Y + 20;
                int textBoxX = loadSingleWidth + x + 20;
                int applyX = fileTextBox.Size.Width + textBoxX + 20;
                int labelRowY = y - 20;
                if (labelRowY < 0)
                    labelRowY = 0;

                fileTextBox.Location = new Point(textBoxX, y);
                fileTextBox.Show();
                directoryLabel.Location = new Point(textBoxX, labelRowY);
                directoryLabel.Show();
                applyChangesButton.Location = new Point(applyX, y);
                applyChangesButton.Show();
            }

            // logged in the functions
            // Ensure correct UI Grouping is visible
            DisplayUIGroup(currentGroup);
            changingGroup = false;
            Log.updateLog(Log.LogType.SHOW, "Completed updating the display");
        }

        // Display UI for the user to perform batch modifications
        private void UpdateBatchDisplay()
        {
            Log.updateLog(Log.LogType.SHOW, "Updating the display for batch edit");
            changingGroup = true;

            int verticalMargin = 20;
            int x = loadButton.Location.X;
            int y = loadButton.Location.Y + loadBatchHeight + verticalMargin;

            // If a file has been loaded then perform UI updates
            if (model.DirectoryLoaded())
            {
                Log.updateLog(Log.LogType.INITIALIZE, "Displaying UI Grouping Buttons for first time");
                descriptionGroupButton.Location = new Point(x, y);
                y += descriptionGroupButton.Size.Height + verticalMargin;
                generalGroupButton.Location = new Point(x, y);
                y += generalGroupButton.Size.Height + verticalMargin;
                movementGroupButton.Location = new Point(x, y);
                y += movementGroupButton.Size.Height + verticalMargin;
                combatGroupButton.Location = new Point(x, y);
                y += combatGroupButton.Size.Height + verticalMargin;
                locationsGroupButton.Location = new Point(x, y);

                descriptionGroupButton.Show();
                generalGroupButton.Show();
                movementGroupButton.Show();
                combatGroupButton.Show();
                locationsGroupButton.Show();

                // Prepare the fileTextBox to appear 20 pixels to the right of the loadButton and the applyChangesButton to appear 20 pixels beyond that
                Log.updateLog(Log.LogType.INITIALIZE, "Displaying the file text box and apply changes button");
                x = loadButton.Location.X;
                y = loadButton.Location.Y + 20;
                int directoryX = x + loadBatchWidth + 20;
                int applyX = directoryX + directoryLabel.Size.Width + 20;
                int clearX = applyX + applyChangesButton.Size.Width + 20;

                directoryLabel.Location = new Point(directoryX, y);
                directoryLabel.Show();
                applyChangesButton.Location = new Point(applyX, y);
                applyChangesButton.Show();
                clearChangesButton.Location = new Point(clearX, y);
                clearChangesButton.Show();
                if (batchChangeGroupBox == null)
                {
                    batchChangeGroupBox = new BatchChangeGroupBox(
                        clearChangesButton.Location.X + clearChangesButton.Size.Width + 100,
                        clearChangesButton.Location.Y, 
                        this);
                }
                batchChangeGroupBox.Show();
            }

            // logged in the functions
            // Ensure correct UI Grouping is visible
            DisplayUIGroup(currentGroup);
            changingGroup = false;
            Log.updateLog(Log.LogType.SHOW, "Completed updating the display");
        }

        // Ensure the selected UI Group elements are visible and contain correct data from the model
        private void DisplayUIGroup(UIGrouping g)
        {
            // if there is not a file/directory loaded for the current mode, then we should return
            if ((currentMode == ProcessMode.SINGLE && !model.FileLoaded()) ||
                (currentMode == ProcessMode.BATCH && !model.DirectoryLoaded()))
                return;
            // UI Groups share the groupComboBox and groupTextBox. So as each is shown, the boxes must be updated and moved. 
            // The location group, however, also uses the locationComboBox. 
            int groupButtonX = 0;
            int groupButtonWidth = 0;
            int rowY = 0;
            int comboBoxX = 0;
            int comboBoxWidth = groupComboBox.Size.Width;
            int textBoxX = 0;
            int textBoxWidth = groupTextBox.Size.Width;
            int operationComboBoxX = 0;
            int operationComboBoxWidth = operationComboBox.Size.Width;
            int locationComboBoxX = 0;
            int locationComboBoxWidth = locationComboBox.Size.Width;
            int horizontalSpacing = 20;
            string[] newItems = { };
            string selectedItem = "";


            // To display the a group, we must move the groupComboBox to 20 pixels right of the group button
            // The groupTextBox is moved 20 pixels to the right of the groupComboBox
            // The groupComboBox is then updated to contain the items of the group
            // Lastly, the groupComboBox is set to the prefered item and updated
            if (g == UIGrouping.DESCRIPTION)
            {
                Log.updateLog(Log.LogType.SHOW, "Aligning groupComboBox and groupTextBox to the description group");
                groupButtonX = descriptionGroupButton.Location.X;
                rowY = descriptionGroupButton.Location.Y;
                groupButtonWidth = descriptionGroupButton.Size.Width;

                comboBoxX = groupButtonX + groupButtonWidth + horizontalSpacing;
                if (currentMode == ProcessMode.BATCH)
                {
                    operationComboBoxX = comboBoxX + comboBoxWidth + horizontalSpacing;
                    textBoxX = operationComboBoxX + operationComboBoxWidth + horizontalSpacing;
                }
                else
                {
                    textBoxX = comboBoxX + comboBoxWidth + horizontalSpacing;
                }
                selectedItem = "Name";
                newItems = descriptionItems;
            }

            if (g == UIGrouping.GENERAL)
            {
                Log.updateLog(Log.LogType.SHOW, "Aligning groupComboBox and groupTextBox to the general group");
                groupButtonX = generalGroupButton.Location.X;
                rowY = generalGroupButton.Location.Y;
                groupButtonWidth = generalGroupButton.Size.Width;

                comboBoxX = groupButtonX + groupButtonWidth + horizontalSpacing;

                if (currentMode == ProcessMode.BATCH)
                {
                    operationComboBoxX = comboBoxX + comboBoxWidth + horizontalSpacing;
                    textBoxX = operationComboBoxX + operationComboBoxWidth + horizontalSpacing;
                }
                else
                {
                    textBoxX = comboBoxX + comboBoxWidth + horizontalSpacing;
                }

                newItems = generalItems;
                selectedItem = "Tonnage";
            }

            if (g == UIGrouping.MOVEMENT)
            {
                Log.updateLog(Log.LogType.SHOW, "Aligning groupComboBox and groupTextBox to the movement group");
                groupButtonX = movementGroupButton.Location.X;
                rowY = movementGroupButton.Location.Y;
                groupButtonWidth = movementGroupButton.Size.Width;

                comboBoxX = groupButtonX + groupButtonWidth + horizontalSpacing;

                if (currentMode == ProcessMode.BATCH)
                {
                    operationComboBoxX = comboBoxX + comboBoxWidth + horizontalSpacing;
                    textBoxX = operationComboBoxX + operationComboBoxWidth + horizontalSpacing;
                }
                else
                {
                    textBoxX = comboBoxX + comboBoxWidth + horizontalSpacing;
                }

                newItems = movementItems;
                selectedItem = "TopSpeed";
            }

            if (g == UIGrouping.COMBAT)
            {
                Log.updateLog(Log.LogType.SHOW, "Aligning groupComboBox and groupTextBox to the combat group");
                groupButtonX = combatGroupButton.Location.X;
                rowY = combatGroupButton.Location.Y;
                groupButtonWidth = combatGroupButton.Size.Width;

                comboBoxX = groupButtonX + groupButtonWidth + horizontalSpacing;
                if (currentMode == ProcessMode.BATCH)
                {
                    operationComboBoxX = comboBoxX + comboBoxWidth + horizontalSpacing;
                    textBoxX = operationComboBoxX + operationComboBoxWidth + horizontalSpacing;
                }
                else
                {
                    textBoxX = comboBoxX + comboBoxWidth + horizontalSpacing;
                }

                newItems = combatItems;
                selectedItem = "MeleeDamage";
            }

            if (g == UIGrouping.LOCATION)
            {
                Log.updateLog(Log.LogType.SHOW, "Aligning groupComboBox and groupTextBox to the locations group");
                groupButtonX = locationsGroupButton.Location.X;
                rowY = locationsGroupButton.Location.Y;
                groupButtonWidth = locationsGroupButton.Size.Width;

                comboBoxX = groupButtonX + groupButtonWidth + horizontalSpacing;
                locationComboBoxX = comboBoxX + comboBoxWidth + horizontalSpacing;

                if (currentMode == ProcessMode.BATCH)
                {
                    operationComboBoxX = locationComboBoxX + locationComboBoxWidth + horizontalSpacing;
                    textBoxX = operationComboBoxX + operationComboBoxWidth + horizontalSpacing;
                }
                else
                {
                    textBoxX = locationComboBoxX + locationComboBoxWidth + horizontalSpacing;
                }

                newItems = locationsItems;
                selectedItem = "Head";
                UpdateComboBox(locationComboBox, locationFields);
            }
            else
            {
                locationComboBox.Hide();
                HideAllHardpointElements();
            }

            // with all variables updated for the specific UI Group, perform the moves and updates
            groupComboBox.Location = new Point(comboBoxX, rowY);
            UpdateComboBox(groupComboBox, newItems);

            Log.updateLog(Log.LogType.SHOW, "Attempting to select item: " + selectedItem);
            groupComboBox.SelectedItem = selectedItem; // THIS LINE ALSO CALLS THE GroupComboBox_SelectedValueChange function
            Log.updateLog(Log.LogType.SHOW, "Selected");
            groupComboBox.Show();

            // For the Location group, we also need to update the locationComboBox
            if (g == UIGrouping.LOCATION)
            {
                locationComboBox.Location = new Point(locationComboBoxX, rowY);
                locationComboBox.Show();
                locationComboBox.SelectedItem = "Tonnage"; // THIS LIKE ALSO CALLS THE groupComboBox_SelectedValueChange function
            }

            groupTextBox.Location = new Point(textBoxX, rowY);
            groupTextBox.Show();
           
            if (currentMode == ProcessMode.BATCH)
            {
                operationComboBox.Location = new Point(operationComboBoxX, rowY);
                operationComboBox.Show();
                MoveSaveChangeButton();
                saveChangeButton.Show();
            }
            Log.updateLog(Log.LogType.SHOW, "Completed DisplayUIGroup call");
        }

        // Hide all the UI elements, except the mode and load buttons
        private void HideUI()
        {
            descriptionGroupButton.Hide();
            generalGroupButton.Hide();
            movementGroupButton.Hide();
            combatGroupButton.Hide();
            locationsGroupButton.Hide();
            groupComboBox.Hide();
            locationComboBox.Hide();
            groupTextBox.Hide();
            directoryLabel.Hide();
            fileTextBox.Hide();
            applyChangesButton.Hide();
            clearChangesButton.Hide();
            saveChangeButton.Hide();
            if (batchChangeGroupBox != null)
                batchChangeGroupBox.Hide();
            operationComboBox.Hide();
            HideAllHardpointElements();
        }

        // Click functions for each UI Group 
        // If the user clicks the descriptionGroupButton, then we should update the current UI Group
        private void descriptionGroupButton_Click(object sender, EventArgs e)
        {
            if (currentGroup != UIGrouping.DESCRIPTION)
            {
                Log.updateLog(Log.LogType.CLICK, "Changing to the description UI Group");
                currentGroup = UIGrouping.DESCRIPTION;
                UpdateDisplay();
            }
        }
        // If the user clicks the generalGroupButton, then we should update the current UI Group
        private void generalGroupButton_Click(object sender, EventArgs e)
        {
            if (currentGroup != UIGrouping.GENERAL)
            {
                Log.updateLog(Log.LogType.CLICK, "Changing to the general UI Group");
                currentGroup = UIGrouping.GENERAL;
                UpdateDisplay();
            }
        }
        // If the user clicks the movementGroupButton, then we should update the current UI Group
        private void movementGroupButton_Click(object sender, EventArgs e)
        {
            Log.updateLog(Log.LogType.CLICK, "Changing to the movement UI Group");
            if (currentGroup != UIGrouping.MOVEMENT)
            {
                currentGroup = UIGrouping.MOVEMENT;
                UpdateDisplay();
            }
        }
        // If the user clicks the combatGroupButton, then we should update the current UI Group
        private void combatGroupButton_Click(object sender, EventArgs e)
        {
            Log.updateLog(Log.LogType.CLICK, "Changing to the combat UI Group");
            if (currentGroup != UIGrouping.COMBAT)
            {
                currentGroup = UIGrouping.COMBAT;
                UpdateDisplay();
            }
        }
        // If the user clicks the locationGroupButton, then we should update the current UI Group
        private void locationGroupButton_Click(object sender, EventArgs e)
        {
            Log.updateLog(Log.LogType.CLICK, "Changing to the location UI Group");
            if (currentGroup != UIGrouping.LOCATION)
            {
                currentGroup = UIGrouping.LOCATION;
                UpdateDisplay();
            }
        }
        // MouseEnter and MouseLeave functions for LoadChassisFileButton
        // If the button is retracted when the mouse enters, extend it
        private void LoadButton_MouseEnter(object sender, EventArgs e)
        {
            // logged in function
            ExtendLoadButton();
        }
        // If the button is extended when the mouse leaves, retract it
        private void LoadButton_MouseLeave(object sender, EventArgs e)
        {
            if ((currentMode == ProcessMode.SINGLE &&
                 model.FileLoaded()) ||
                (currentMode == ProcessMode.BATCH &&
                 model.DirectoryLoaded()))
            {
                // logged in function
                RetractLoadButton();
            }
        }
        // Extend and Retract functions for the LoadChassisFileButton
        // If the LoadChassisFileButton is extended, then switch to the retracted image and update the flag
        private void RetractLoadButton()
        {

            if (LoadButtonExtended)
            {
                Log.updateLog(Log.LogType.SHOW, "Retracting the load button");
                switch (currentMode)
                {
                    case ProcessMode.SINGLE:
                        loadButton.Image = Properties.Resources.LoadChassisButtonRetracted;
                        break;
                    case ProcessMode.BATCH:
                        loadButton.Image = Properties.Resources.LoadChassisButtonRetracted;
                        break;
                    default:
                        break;
                }
                LoadButtonExtended = false;
            }
        }
        // If the LoadChassiFileButton is retracted, then switch to the extended image and update the flag
        private void ExtendLoadButton()
        {

            if (!LoadButtonExtended)
            {
                Log.updateLog(Log.LogType.HIDE, "Extending the load button");
                switch (currentMode)
                {
                    case ProcessMode.SINGLE:
                        loadButton.Image = Properties.Resources.LoadChassisButton;
                        break;
                    case ProcessMode.BATCH:
                        loadButton.Image = Properties.Resources.LoadDirectoryButton;
                        break;
                    default:
                        break;
                }
                LoadButtonExtended = true;
            }
        }

        // Update the descriptionTextBox to the correct size and with the correct value from the model
        private void GroupComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            currentController.ComboBoxChanged(sender, currentGroup);
            if (currentMode == ProcessMode.BATCH)
            {
                ResetHardpointChanges();
                ResetHardpointOperationComboBoxes();
                model.ClearBatchChanges();
            }
        }

        // Update the model with the text in the descriptionTextBox
        private void GroupTextBox_TextChanged(object sender, EventArgs e)
        {
            if (changingGroup)
                return;
            currentController.TextBoxChanged(currentGroup);
        }

        // Tell the controller to write back to the file
        private void applyChangesButton_Click(object sender, EventArgs e)
        {
            Log.updateLog(Log.LogType.CLICK, "User clicked the apply changes button");
            currentController.ApplyChanges();
            clearChangesButton_Click(this, new EventArgs());
        }

        private void FileTextBox_TextChanged(object sender, EventArgs e)
        {
            model.UpdateChassisFile(fileTextBox.Text);
        }

        // clears the designated combobox of items, then adds items created from a string array
        private void UpdateComboBox(ComboBox comboBox, string[] newItems)
        {
            int index = 0;
            Log.updateLog(Log.LogType.SHOW, "Clearing the " + comboBox.Name + " items");
            comboBox.Items.Clear();

            foreach (string item in newItems)
            {
                Log.updateLog(Log.LogType.SHOW, "Attempting to add item: " + item + " to " + comboBox.Name);
                index = comboBox.Items.Add(item);
                Log.updateLog(Log.LogType.SHOW, index + ":" + item);
            }
            Log.updateLog(Log.LogType.SHOW, "Completed updating the " + comboBox.Name);
        }

        public void HideAllHardpointElements()
        {
            // Add elements
            weaponComboBox.Hide();
            omniCheckBox.Hide();
            addHardpointButton.Hide();

            // Energy elements
            energyOmniTrueLabel.Hide();
            energyOmniTrueCountLabel.Hide();
            energyOmniFalseLabel.Hide();
            energyOmniFalseCountLabel.Hide();
            removeEnergyOmniTrueButton.Hide();
            removeEnergyOmniFalseButton.Hide();
            energyOmniTrueOperationComboBox.Hide();
            energyOmniFalseOperationComboBox.Hide();


            // Ballistic elements
            ballisticOmniTrueLabel.Hide();
            ballisticOmniTrueCountLabel.Hide();
            ballisticOmniFalseLabel.Hide();
            ballisticOmniFalseCountLabel.Hide();
            removeBallisticOmniTrueButton.Hide();
            removeBallisticOmniFalseButton.Hide();
            ballisticOmniTrueOperationComboBox.Hide();
            ballisticOmniFalseOperationComboBox.Hide();

            // AntiPersonnel elements
            antiPersonnelOmniTrueLabel.Hide();
            antiPersonnelOmniTrueCountLabel.Hide();
            antiPersonnelOmniFalseLabel.Hide();
            antiPersonnelOmniFalseCountLabel.Hide();
            removeAntiPersonnelOmniTrueButton.Hide();
            removeAntiPersonnelOmniFalseButton.Hide();
            antiPersonnelOmniTrueOperationComboBox.Hide();
            antiPersonnelOmniFalseOperationComboBox.Hide();

            // Missile elements
            missileOmniTrueLabel.Hide();
            missileOmniTrueCountLabel.Hide();
            missileOmniFalseLabel.Hide();
            missileOmniFalseCountLabel.Hide();
            removeMissileOmniTrueButton.Hide();
            removeMissileOmniFalseButton.Hide();
            missileOmniTrueOperationComboBox.Hide();
            missileOmniFalseOperationComboBox.Hide();
        }

        public void ShowAllHardpointElements()
        {
            // Add elements
            weaponComboBox.Show();
            omniCheckBox.Show();
            addHardpointButton.Show();

            // Energy elements
            energyOmniTrueLabel.Show();
            energyOmniTrueCountLabel.Show();
            energyOmniFalseLabel.Show();
            energyOmniFalseCountLabel.Show();
            removeEnergyOmniTrueButton.Show();
            removeEnergyOmniFalseButton.Show();
            if(currentMode == ProcessMode.BATCH)
            {
                energyOmniTrueOperationComboBox.Show();
                energyOmniFalseOperationComboBox.Show();
            }

            // Ballistic elements
            ballisticOmniTrueLabel.Show();
            ballisticOmniTrueCountLabel.Show();
            ballisticOmniFalseLabel.Show();
            ballisticOmniFalseCountLabel.Show();
            removeBallisticOmniTrueButton.Show();
            removeBallisticOmniFalseButton.Show();
            if (currentMode == ProcessMode.BATCH)
            {
                ballisticOmniTrueOperationComboBox.Show();
                ballisticOmniFalseOperationComboBox.Show();
            }


            // AntiPersonnel elements
            antiPersonnelOmniTrueLabel.Show();
            antiPersonnelOmniTrueCountLabel.Show();
            antiPersonnelOmniFalseLabel.Show();
            antiPersonnelOmniFalseCountLabel.Show();
            removeAntiPersonnelOmniTrueButton.Show();
            removeAntiPersonnelOmniFalseButton.Show();
            if (currentMode == ProcessMode.BATCH)
            {
                antiPersonnelOmniTrueOperationComboBox.Show();
                antiPersonnelOmniFalseOperationComboBox.Show();
            }

            // Missile elements
            missileOmniTrueLabel.Show();
            missileOmniTrueCountLabel.Show();
            missileOmniFalseLabel.Show();
            missileOmniFalseCountLabel.Show();
            removeMissileOmniTrueButton.Show();
            removeMissileOmniFalseButton.Show();
            if (currentMode == ProcessMode.BATCH)
            {
                missileOmniTrueOperationComboBox.Show();
                missileOmniFalseOperationComboBox.Show();
            }
            ResetHardpointOperationComboBoxes();
        }

        public void PlaceAllHardpointElements(int x, int y)
        {
            // distance between Add Elements and the group elements
            int betweenAddAndGroups = 52;
            int betweenOmni = 25;
            int betweenWeapons = 30;
            int betweenLabelAndCount = 189;
            int betweenCountAndButton = 29;
            int buttonAdjust = 5;
            // Store starting x for aligning lower elements
            int startX = x;
            int betweenButtonAndComboBox = 70;

            // Place the Add Elements starting from x, y in a row
            weaponComboBox.Location = new Point(x, y);
            x = x + weaponComboBox.Size.Width + 8;
            omniCheckBox.Location = new Point(x, y + 1);
            x = x + omniCheckBox.Size.Width + 3;
            addHardpointButton.Location = new Point(x, y - 3);

            // Return to start of row, but jump down to where the weapons groups begin
            x = startX;
            y += betweenAddAndGroups;

            // Energy Elements
            energyOmniTrueLabel.Location = new Point(x, y);
            x += betweenLabelAndCount;
            energyOmniTrueCountLabel.Location = new Point(x, y);
            x += betweenCountAndButton;
            removeEnergyOmniTrueButton.Location = new Point(x, y - buttonAdjust);
            x += betweenButtonAndComboBox;
            energyOmniTrueOperationComboBox.Location = new Point(x, y - buttonAdjust);
            

            x = startX;
            y += betweenOmni;
            energyOmniFalseLabel.Location = new Point(x, y);
            x += betweenLabelAndCount;
            energyOmniFalseCountLabel.Location = new Point(x, y);
            x += betweenCountAndButton;
            removeEnergyOmniFalseButton.Location = new Point(x, y - buttonAdjust);
            x += betweenButtonAndComboBox;
            energyOmniFalseOperationComboBox.Location = new Point(x, y - buttonAdjust);

            x = startX;
            y += betweenWeapons;
            // Ballistic Elements
            ballisticOmniTrueLabel.Location = new Point(x, y);
            x += betweenLabelAndCount;
            ballisticOmniTrueCountLabel.Location = new Point(x, y);
            x += betweenCountAndButton;
            removeBallisticOmniTrueButton.Location = new Point(x, y - buttonAdjust);
            x += betweenButtonAndComboBox;
            ballisticOmniTrueOperationComboBox.Location = new Point(x, y - buttonAdjust);

            x = startX;
            y += betweenOmni;
            ballisticOmniFalseLabel.Location = new Point(x, y);
            x += betweenLabelAndCount;
            ballisticOmniFalseCountLabel.Location = new Point(x, y);
            x += betweenCountAndButton;
            removeBallisticOmniFalseButton.Location = new Point(x, y - buttonAdjust);
            x += betweenButtonAndComboBox;
            ballisticOmniFalseOperationComboBox.Location = new Point(x, y - buttonAdjust);

            x = startX;
            y += betweenWeapons;
            // AntiPersonnel Elements
            antiPersonnelOmniTrueLabel.Location = new Point(x, y);
            x += betweenLabelAndCount;
            antiPersonnelOmniTrueCountLabel.Location = new Point(x, y);
            x += betweenCountAndButton;
            removeAntiPersonnelOmniTrueButton.Location = new Point(x, y - buttonAdjust);
            x += betweenButtonAndComboBox;
            antiPersonnelOmniTrueOperationComboBox.Location = new Point(x, y - buttonAdjust);

            x = startX;
            y += betweenOmni;
            antiPersonnelOmniFalseLabel.Location = new Point(x, y);
            x += betweenLabelAndCount;
            antiPersonnelOmniFalseCountLabel.Location = new Point(x, y);
            x += betweenCountAndButton;
            removeAntiPersonnelOmniFalseButton.Location = new Point(x, y - buttonAdjust);
            x += betweenButtonAndComboBox;
            antiPersonnelOmniFalseOperationComboBox.Location = new Point(x, y - buttonAdjust);

            x = startX;
            y += betweenWeapons;
            // Missile Elements
            missileOmniTrueLabel.Location = new Point(x, y);
            x += betweenLabelAndCount;
            missileOmniTrueCountLabel.Location = new Point(x, y);
            x += betweenCountAndButton;
            removeMissileOmniTrueButton.Location = new Point(x, y - buttonAdjust);
            x += betweenButtonAndComboBox;
            missileOmniTrueOperationComboBox.Location = new Point(x, y - buttonAdjust);

            x = startX;
            y += betweenOmni;
            missileOmniFalseLabel.Location = new Point(x, y);
            x += betweenLabelAndCount;
            missileOmniFalseCountLabel.Location = new Point(x, y);
            x += betweenCountAndButton;
            removeMissileOmniFalseButton.Location = new Point(x, y - buttonAdjust);
            x += betweenButtonAndComboBox;
            missileOmniFalseOperationComboBox.Location = new Point(x, y - buttonAdjust);
        }

        public void SetAllHardpointValues(Locations loc)
        {
            Log.updateLog(Log.LogType.HARDPOINT, "updating all the hardpoints labels for " + loc.Location);
            int enOmTr = 0;
            int enOmFa = 0;
            int baOmTr = 0;
            int baOmFa = 0;
            int anOmTr = 0;
            int anOmFa = 0;
            int miOmTr = 0;
            int miOmFa = 0;

            if (loc.Hardpoints == null)
            {
                Log.updateLog(Log.LogType.HARDPOINT, "location does not have a hardpoints array");
                throw new Exception("location " + loc.Location + " does not have a hardpoints array");
            }

            Log.updateLog(Log.LogType.HARDPOINT, "number of hardpoints: " + loc.Hardpoints.Length);

            foreach (Hardpoint h in loc.Hardpoints)
            {
                // If energy weapon, update energy count
                if (h.WeaponMount.Equals("Energy"))
                {
                    if (h.Omni)
                    {
                        enOmTr++;
                    }
                    else
                        enOmFa++;
                }

                // If ballistic weapon, update energy count
                if (h.WeaponMount.Equals("Ballistic"))
                {
                    if (h.Omni)
                    {
                        baOmTr++;
                    }
                    else
                        baOmFa++;
                }

                // If antipersonnel weapon, update energy count
                if (h.WeaponMount.Equals("AntiPersonnel"))
                {
                    if (h.Omni)
                    {
                        anOmTr++;
                    }
                    else
                        anOmFa++;
                }

                // If missile weapon, update energy count
                if (h.WeaponMount.Equals("Missile"))
                {
                    if (h.Omni)
                    {
                        miOmTr++;
                    }
                    else
                        miOmFa++;
                }
            }

            Log.updateLog(Log.LogType.HARDPOINT, "Hardpoints counted");
            energyOmniTrueCountLabel.Text = enOmTr.ToString();
            energyOmniFalseCountLabel.Text = enOmFa.ToString();

            ballisticOmniTrueCountLabel.Text = baOmTr.ToString();
            ballisticOmniFalseCountLabel.Text = baOmFa.ToString();

            antiPersonnelOmniTrueCountLabel.Text = anOmTr.ToString();
            antiPersonnelOmniFalseCountLabel.Text = anOmFa.ToString();

            missileOmniTrueCountLabel.Text = miOmTr.ToString();
            missileOmniFalseCountLabel.Text = miOmFa.ToString();
        }

        public int GetHardpointValue(Hardpoint h)
        {
            switch (h.WeaponMount + "Omni" + h.Omni.ToString())
            {
                case "EnergyOmniTrue":
                    return Convert.ToInt32(energyOmniTrueCountLabel.Text);
                case "EnergyOmniFalse":
                    return Convert.ToInt32(energyOmniFalseCountLabel.Text);
                case "BallisticOmniTrue":
                    return Convert.ToInt32(ballisticOmniTrueCountLabel.Text);
                case "BallisticOmniFalse":
                    return Convert.ToInt32(ballisticOmniFalseCountLabel.Text);
                case "AntiPersonnelOmniTrue":
                    return Convert.ToInt32(antiPersonnelOmniTrueCountLabel.Text);
                case "AntiPersonnelOmniFalse":
                    return Convert.ToInt32(antiPersonnelOmniFalseCountLabel.Text);
                case "MissileOmniTrue":
                    return Convert.ToInt32(missileOmniTrueCountLabel.Text);
                case "MissileOmniFalse":
                    return Convert.ToInt32(missileOmniFalseCountLabel.Text);
                default:
                    return 0;
            }
        }

        private void AddHardpointButton_Click(object sender, EventArgs e)
        {
            Hardpoint h = currentController.AddHardpoint();
            SetAllHardpointValues(model.GetLocation(groupComboBox.SelectedItem.ToString(), currentMode));
            if (currentMode == ProcessMode.BATCH)
            {
                UpdateHardpointChange(h, true);
            }
        }

        private void RemoveHardpoint_Click(object sender, EventArgs e)
        {
            Hardpoint h = currentController.RemoveHardpoint(sender);
            SetAllHardpointValues(model.GetLocation(groupComboBox.SelectedItem.ToString(), currentMode));
            if (currentMode == ProcessMode.BATCH)
            {
                if (GetHardpointValue(h) == 0)
                    UpdateHardpointChange(h, false);
            }
        }

        private void UpdateHardpointChange(Hardpoint h, bool updateBool)
        {
            if (h == null)
                return;
            switch (h.WeaponMount + "Omni" + h.Omni.ToString())
            {
                case "EnergyOmniTrue":
                    hardpointChanges[0] = updateBool;
                    break;
                case "EnergyOmniFalse":
                    hardpointChanges[1] = updateBool;
                    break;
                case "BallisticOmniTrue":
                    hardpointChanges[2] = updateBool;
                    break;
                case "BallisticOmniFalse":
                    hardpointChanges[3] = updateBool;
                    break;
                case "AntiPersonnelOmniTrue":
                    hardpointChanges[4] = updateBool;
                    break;
                case "AntiPersonnelOmniFalse":
                    hardpointChanges[5] = updateBool;
                    break;
                case "MissileOmniTrue":
                    hardpointChanges[6] = updateBool;
                    break;
                case "MissileOmniFalse":
                    hardpointChanges[7] = updateBool;
                    break;
            }
        }

        private void toggleMode(object sender, EventArgs e)
        {
            Log.updateLog(Log.LogType.SHOW, "Toggling between modes");
            Button button = (Button)sender;
            ProcessMode oldMode = currentMode;
            // if user clicks editSingleButton and we are not in ProcessMode.SINGLE
            if (button.Name.Equals("editSingleButton") &&
                currentMode != ProcessMode.SINGLE)
            {
                HideUI();
                Log.updateLog(Log.LogType.SHOW, "Switching to Edit Single mode");
                currentMode = ProcessMode.SINGLE;
                Size = singleSize;
                editBatchButton.Image = Properties.Resources.EditBatchButtonUnselected;
                editSingleButton.Image = Properties.Resources.EditSingleButton;
                loadButton.Image = Properties.Resources.LoadChassisButton;
                currentController = singleController;
                currentGroup = UIGrouping.DESCRIPTION;

                if (model.FileLoaded())
                {
                    LoadButtonExtended = true;
                    RetractLoadButton();
                }
                else
                {
                    LoadButtonExtended = false;
                    ExtendLoadButton();
                }
            }
           else if (button.Name.Equals("editBatchButton") &&
                 currentMode != ProcessMode.BATCH)
            {
                HideUI();
                Log.updateLog(Log.LogType.SHOW, "Switching to Edit Batch mode");
                currentMode = ProcessMode.BATCH;
                Size = batchSize;
                editSingleButton.Image = Properties.Resources.EditSingleButtonUnselected;
                editBatchButton.Image = Properties.Resources.EditBatchButton;
                loadButton.Image = Properties.Resources.LoadDirectoryButton;
                currentController = batchController;
                currentGroup = UIGrouping.DESCRIPTION;
                operationComboBox.SelectedItem = "=";

                Log.updateLog(Log.LogType.SHOW, "Buttons and controllers set up");

                if (model.DirectoryLoaded())
                {
                    Log.updateLog(Log.LogType.SHOW, "Retracting the load button");
                    LoadButtonExtended = true;
                    RetractLoadButton();
                }
                else
                {
                    LoadButtonExtended = false;
                    ExtendLoadButton();
                }
            }
            if (oldMode != currentMode)
                UpdateDisplay();
        }

        // The caller knows what element it is requesting, so it can handle any conversion
        public Object GetElement(string elementName)
        {
            switch (elementName)
            {
                case "groupComboBox":
                    return groupComboBox;
                case "locationComboBox":
                    return locationComboBox;
                case "groupTextBox":
                    return groupTextBox;
                case "weaponComboBox":
                    return weaponComboBox;
                case "omniCheckBox":
                    return omniCheckBox;
                case "saveChangeButton":
                    return saveChangeButton;
                case "operationComboBox":
                    return operationComboBox;
                case "batchChangeGroupBox":
                    return batchChangeGroupBox;
                default:
                    return null;
            }
        }

        public void clearChangesButton_Click(object sender, EventArgs e)
        {
            ResetHardpointChanges();
            if (batchChangeGroupBox != null)
                batchChangeGroupBox.ClearBatchChanges();
            model.ClearBatchChanges();
            currentGroup = UIGrouping.DESCRIPTION;
            UpdateDisplay();
        }

        private void SaveChangeButton_Click(object sender, EventArgs e)
        {
            Log.updateLog(Log.LogType.CLICK, "User has clicked the save change button");
            // The user has clicked the save button
            // We must convert the displayed change in to a BatchChange object
            BatchChange change = new BatchChange();
            // Then we need to add that change to the BatchChangeGroupBox

            // Description, General, Movement, and Combat are all the same
            // The source of the change is the groupComboBox.SelectedItem
            // The operation is the operationComboBox.SelectedItem
            // And the value is the groupTextBox.Text (converted appropriately)
            if (currentGroup == UIGrouping.DESCRIPTION ||
                currentGroup == UIGrouping.GENERAL ||
                currentGroup == UIGrouping.MOVEMENT ||
                currentGroup == UIGrouping.COMBAT)
            {
                Log.updateLog(Log.LogType.CLICK, "Simple non-location change is being made");
                string group = "";
                switch(currentGroup)
                {
                    case UIGrouping.DESCRIPTION:
                        group = "Description";
                            break;
                    case UIGrouping.GENERAL:
                        group = "General";
                            break;
                    case UIGrouping.MOVEMENT:
                        group = "Movement";
                            break;
                    case UIGrouping.COMBAT:
                        group = "Combat";
                            break;
                }
                change.source = group + "." + groupComboBox.SelectedItem.ToString();
                switch (operationComboBox.SelectedItem.ToString())
                {
                    case "=":
                        change.operation = BatchChange.Operator.EQUALS;
                        break;
                    case "-":
                        change.operation = BatchChange.Operator.MINUS;
                        break;
                    case "+":
                        change.operation = BatchChange.Operator.PLUS;
                        break;
                }
                float floatValue = 0;
                bool isFloat = false;
                bool boolValue = false;
                bool isBool = false;
                string textValue = groupTextBox.Text;

                // Attempt to conver to a float, if successful, then it is a float value
                try
                {
                    floatValue = float.Parse(textValue);
                    isFloat = true;
#pragma warning disable CS0168 // Variable is declared but never used
                } catch (Exception ex)
#pragma warning restore CS0168 // Variable is declared but never used
                {
                    // Don't need to do anything. If it fails, then it isn't a float and won't be used as one
                }

                // Check to see if it is a bool
                if (textValue.Trim().ToUpper().Equals("TRUE"))
                {
                    boolValue = true;
                    isBool = true;
                } 
                else if (textValue.Trim().ToUpper().Equals("FALSE"))
                {
                    boolValue = false;
                    isBool = false;
                }

                if (isFloat)
                    change.SetValue(floatValue);
                else if (isBool)
                    change.SetValue(boolValue);
                else
                    change.SetValue(textValue);
                Log.updateLog(Log.LogType.CLICK, "Simple non-location change has been built");
                batchChangeGroupBox.AppendChange(change);
                return;
            }

            // For Locations with simple changes (as in not hardpoints)
            // the source is the groupComboBox.SelectedItem + "." + locationComboBox.SelectedItem
            // the operation is the operationComboBox.SelectedItem
            // the source is the groupTextBox.Text (converted appropriately)
            if (currentGroup == UIGrouping.LOCATION &&
                !locationComboBox.SelectedItem.ToString().Equals("Hardpoints"))
            {
                string group = groupComboBox.SelectedItem.ToString();
                Log.updateLog(Log.LogType.CLICK, "Simple location change is being made");
                change.source = group + "." + locationComboBox.SelectedItem.ToString();
                switch (operationComboBox.SelectedItem.ToString())
                {
                    case "=":
                        change.operation = BatchChange.Operator.EQUALS;
                        break;
                    case "-":
                        change.operation = BatchChange.Operator.MINUS;
                        break;
                    case "+":
                        change.operation = BatchChange.Operator.PLUS;
                        break;
                }
                float floatValue = 0;
                bool isFloat = false;
                bool boolValue = false;
                bool isBool = false;
                string textValue = groupTextBox.Text;

                // Attempt to conver to a float, if successful, then it is a float value
                try
                {
                    floatValue = float.Parse(textValue);
                    isFloat = true;
#pragma warning disable CS0168 // Variable is declared but never used
                } catch (Exception ex)
#pragma warning restore CS0168 // Variable is declared but never used
                { 
                // Don't need to do anything. If it fails, then it isn't a float and won't be used as one
                }

                // Check to see if it is a bool
                if (textValue.Trim().ToUpper().Equals("TRUE"))
                {
                    boolValue = true;
                    isBool = true;
                }
                else if (textValue.Trim().ToUpper().Equals("FALSE"))
                {
                    boolValue = false;
                    isBool = false;
                }

                if (isFloat)
                    change.SetValue(floatValue);
                else if (isBool)
                    change.SetValue(boolValue);
                else
                    change.SetValue(textValue);
                Log.updateLog(Log.LogType.CLICK, "Simple location change has been built");
                batchChangeGroupBox.AppendChange(change);
                return;
            }

            // For Locations with complex changes (as in hardpoints)
            // we actually need to make multiple changes, one for each WeaponType/Omni
            // each change will have a source of groupComboBox.SelectedItem + "." + WeaponType/Omni
            // each change will have an operation based on the operationComboBox associated with that WeaponType/Omni
            // each change will have a value of the weaponType/Omni
           else if (currentGroup == UIGrouping.LOCATION &&
                locationComboBox.SelectedItem.ToString().Equals("Hardpoints"))
            {

                Log.updateLog(Log.LogType.CLICK, "Complex location change is being made");
                string[] hardpoints = {"EnergyOmniTrue", "EnergyOmniFalse",
                                        "BallisticOmniTrue", "BallisticOmniFalse",
                                        "AntiPersonnelOmniTrue", "AntiPersonnelOmniFalse",
                                        "MissileOmniTrue", "MissileOmniFalse"};
                string group = groupComboBox.SelectedItem.ToString() + ".";
                Log.updateLog(Log.LogType.CLICK, "group: " + group);
                string operation = "";
                float value = 0;

                for (int i = 0; i < hardpoints.Length; i++)
                {
                    if (!hardpointChanges[i])
                        continue;

                    change = new BatchChange();

                    change.source = group + hardpoints[i];
                    Log.updateLog(Log.LogType.CLICK, "new change source: " + change.source);

                    switch (hardpoints[i])
                    {
                        case "EnergyOmniTrue":
                            operation = energyOmniTrueOperationComboBox.SelectedItem.ToString();
                            value = float.Parse(energyOmniTrueCountLabel.Text);
                            break;
                        case "EnergyOmniFalse":
                            operation = energyOmniFalseOperationComboBox.SelectedItem.ToString();
                            value = float.Parse(energyOmniFalseCountLabel.Text);
                            break;
                        case "BallisticOmniTrue":
                            operation = ballisticOmniTrueOperationComboBox.SelectedItem.ToString();
                            value = float.Parse(ballisticOmniTrueCountLabel.Text);
                            break;
                        case "BallisticOmniFalse":
                            operation = ballisticOmniFalseOperationComboBox.SelectedItem.ToString();
                            value = float.Parse(ballisticOmniFalseCountLabel.Text);
                            break;
                        case "AntiPersonnelOmniTrue":
                            operation = antiPersonnelOmniTrueOperationComboBox.SelectedItem.ToString();
                            value = float.Parse(antiPersonnelOmniTrueCountLabel.Text);
                            break;
                        case "AntiPersonnelOmniFalse":
                            operation = antiPersonnelOmniFalseOperationComboBox.SelectedItem.ToString();
                            value = float.Parse(antiPersonnelOmniFalseCountLabel.Text);
                            break;
                        case "MissileOmniTrue":
                            operation = missileOmniTrueOperationComboBox.SelectedItem.ToString();
                            value = float.Parse(missileOmniTrueCountLabel.Text);
                            break;
                        case "MissileOmniFalse":
                            operation = missileOmniFalseOperationComboBox.SelectedItem.ToString();
                            value = float.Parse(missileOmniFalseCountLabel.Text);
                            break;
                    }

                    Log.updateLog(Log.LogType.CLICK, "new change with operation: " + operation + " and value: " + value);

                    switch (operation)
                    {
                        case "=":
                            change.operation = BatchChange.Operator.EQUALS;
                            break;
                        case "-":
                            change.operation = BatchChange.Operator.MINUS;
                            break;
                        case "+":
                            change.operation = BatchChange.Operator.PLUS;
                            break;
                    }

                    change.SetValue(value);
                    Log.updateLog(Log.LogType.CLICK, "Complex location change has been built");
                    batchChangeGroupBox.AppendChange(change);
                }
                // reset the hardpointChanges tracker
                ResetHardpointChanges();
            }
        }

        public void MoveSaveChangeButton()
        {
            int x = 0;
            int y = 0;
            int horizontalSpacing = 20;
            switch (currentGroup)
            {
                case UIGrouping.DESCRIPTION:
                    x = groupTextBox.Location.X + groupTextBox.Size.Width + horizontalSpacing;
                    y = groupTextBox.Location.Y;
                    break;
                case UIGrouping.GENERAL:
                    x = groupTextBox.Location.X + groupTextBox.Size.Width + horizontalSpacing;
                    y = groupTextBox.Location.Y;
                    break;
                case UIGrouping.MOVEMENT:
                    x = groupTextBox.Location.X + groupTextBox.Size.Width + horizontalSpacing;
                    y = groupTextBox.Location.Y;
                    break;
                case UIGrouping.COMBAT:
                    x = groupTextBox.Location.X + groupTextBox.Size.Width + horizontalSpacing;
                    y = groupTextBox.Location.Y;
                    break;
                case UIGrouping.LOCATION:
                    if (locationComboBox.SelectedItem.ToString().Equals("Hardpoints"))
                    {
                        x = addHardpointButton.Location.X + addHardpointButton.Size.Width + horizontalSpacing;
                        y = addHardpointButton.Location.Y;
                    }
                    else
                    {
                        x = groupTextBox.Location.X + groupTextBox.Size.Width + horizontalSpacing;
                        y = groupTextBox.Location.Y;
                    }
                    break;
                default:
                    break;
            }
            saveChangeButton.Location = new Point(x, y);
        }

        private void HardpointOperationComboBox_Click(object sender, EventArgs e)
        {
            ComboBox operationComboBox = (ComboBox)sender;
            Hardpoint h = new Hardpoint();
            switch (operationComboBox.Name)
            {
                case "energyOmniTrueOperationComboBox":
                    h.WeaponMount = "Energy";
                    h.Omni = true;
                    break;
                case "energyOmniFalseOperationComboBox":
                    h.WeaponMount = "Energy";
                    h.Omni = false;
                    break;
                case "ballisticOmniTrueOperationComboBox":
                    h.WeaponMount = "Ballistic";
                    h.Omni = true;
                    break;
                case "ballisticOmniFalseOperationComboBox":
                    h.WeaponMount = "Ballistic";
                    h.Omni = false;
                    break;
                case "antiPersonnelOmniTrueOperationComboBox":
                    h.WeaponMount = "AntiPersonnel";
                    h.Omni = true;
                    break;
                case "antiPersonnelOmniFalseOperationComboBox":
                    h.WeaponMount = "AntiPersonnel";
                    h.Omni = false;
                    break;
                case "missileOmniTrueOperationComboBox":
                    h.WeaponMount = "Missile";
                    h.Omni = true;
                    break;
                case "missileOmniFalseOperationComboBox":
                    h.WeaponMount = "Missile";
                    h.Omni = false;
                    break;
            }
            UpdateHardpointChange(h, true);
        }

        private void ResetHardpointChanges()
        {
            for (int i = 0; i < hardpointChanges.Length; i++)
            {
                hardpointChanges[i] = false;
            }
        }

        private void ResetHardpointOperationComboBoxes()
        {
            energyOmniTrueOperationComboBox.SelectedItem = "=";
            energyOmniFalseOperationComboBox.SelectedItem = "=";
            ballisticOmniTrueOperationComboBox.SelectedItem = "=";
            ballisticOmniFalseOperationComboBox.SelectedItem = "=";
            antiPersonnelOmniTrueOperationComboBox.SelectedItem = "=";
            antiPersonnelOmniFalseOperationComboBox.SelectedItem = "=";
            missileOmniTrueOperationComboBox.SelectedItem = "=";
            missileOmniFalseOperationComboBox.SelectedItem = "=";
        }

    }
}
