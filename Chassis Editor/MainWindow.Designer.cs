namespace Chassis_Editor
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.descriptionGroupButton = new System.Windows.Forms.Button();
            this.generalGroupButton = new System.Windows.Forms.Button();
            this.movementGroupButton = new System.Windows.Forms.Button();
            this.combatGroupButton = new System.Windows.Forms.Button();
            this.locationsGroupButton = new System.Windows.Forms.Button();
            this.groupComboBox = new System.Windows.Forms.ComboBox();
            this.groupTextBox = new System.Windows.Forms.TextBox();
            this.applyChangesButton = new System.Windows.Forms.Button();
            this.loadButton = new System.Windows.Forms.Button();
            this.fileTextBox = new System.Windows.Forms.TextBox();
            this.directoryLabel = new System.Windows.Forms.Label();
            this.locationComboBox = new System.Windows.Forms.ComboBox();
            this.weaponComboBox = new System.Windows.Forms.ComboBox();
            this.omniCheckBox = new System.Windows.Forms.CheckBox();
            this.addHardpointButton = new System.Windows.Forms.Button();
            this.energyOmniTrueLabel = new System.Windows.Forms.Label();
            this.energyOmniFalseLabel = new System.Windows.Forms.Label();
            this.ballisticOmniFalseLabel = new System.Windows.Forms.Label();
            this.ballisticOmniTrueLabel = new System.Windows.Forms.Label();
            this.missileOmniFalseLabel = new System.Windows.Forms.Label();
            this.missileOmniTrueLabel = new System.Windows.Forms.Label();
            this.antiPersonnelOmniFalseLabel = new System.Windows.Forms.Label();
            this.antiPersonnelOmniTrueLabel = new System.Windows.Forms.Label();
            this.energyOmniTrueCountLabel = new System.Windows.Forms.Label();
            this.energyOmniFalseCountLabel = new System.Windows.Forms.Label();
            this.ballisticOmniTrueCountLabel = new System.Windows.Forms.Label();
            this.ballisticOmniFalseCountLabel = new System.Windows.Forms.Label();
            this.missileOmniFalseCountLabel = new System.Windows.Forms.Label();
            this.missileOmniTrueCountLabel = new System.Windows.Forms.Label();
            this.antiPersonnelOmniFalseCountLabel = new System.Windows.Forms.Label();
            this.antiPersonnelOmniTrueCountLabel = new System.Windows.Forms.Label();
            this.removeEnergyOmniTrueButton = new System.Windows.Forms.Button();
            this.removeEnergyOmniFalseButton = new System.Windows.Forms.Button();
            this.removeBallisticOmniTrueButton = new System.Windows.Forms.Button();
            this.removeBallisticOmniFalseButton = new System.Windows.Forms.Button();
            this.removeMissileOmniFalseButton = new System.Windows.Forms.Button();
            this.removeMissileOmniTrueButton = new System.Windows.Forms.Button();
            this.removeAntiPersonnelOmniFalseButton = new System.Windows.Forms.Button();
            this.removeAntiPersonnelOmniTrueButton = new System.Windows.Forms.Button();
            this.editSingleButton = new System.Windows.Forms.Button();
            this.editBatchButton = new System.Windows.Forms.Button();
            this.clearChangesButton = new System.Windows.Forms.Button();
            this.saveChangeButton = new System.Windows.Forms.Button();
            this.operationComboBox = new System.Windows.Forms.ComboBox();
            this.energyOmniTrueOperationComboBox = new System.Windows.Forms.ComboBox();
            this.energyOmniFalseOperationComboBox = new System.Windows.Forms.ComboBox();
            this.ballisticOmniTrueOperationComboBox = new System.Windows.Forms.ComboBox();
            this.ballisticOmniFalseOperationComboBox = new System.Windows.Forms.ComboBox();
            this.antiPersonnelOmniTrueOperationComboBox = new System.Windows.Forms.ComboBox();
            this.antiPersonnelOmniFalseOperationComboBox = new System.Windows.Forms.ComboBox();
            this.missileOmniTrueOperationComboBox = new System.Windows.Forms.ComboBox();
            this.missileOmniFalseOperationComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // descriptionGroupButton
            // 
            this.descriptionGroupButton.AutoSize = true;
            this.descriptionGroupButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.descriptionGroupButton.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.descriptionGroupButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.descriptionGroupButton.Location = new System.Drawing.Point(11, 124);
            this.descriptionGroupButton.Margin = new System.Windows.Forms.Padding(0);
            this.descriptionGroupButton.Name = "descriptionGroupButton";
            this.descriptionGroupButton.Size = new System.Drawing.Size(89, 27);
            this.descriptionGroupButton.TabIndex = 3;
            this.descriptionGroupButton.Text = "Description";
            this.descriptionGroupButton.UseVisualStyleBackColor = false;
            this.descriptionGroupButton.Visible = false;
            this.descriptionGroupButton.Click += new System.EventHandler(this.descriptionGroupButton_Click);
            // 
            // generalGroupButton
            // 
            this.generalGroupButton.AutoSize = true;
            this.generalGroupButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.generalGroupButton.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.generalGroupButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.generalGroupButton.Location = new System.Drawing.Point(11, 175);
            this.generalGroupButton.Margin = new System.Windows.Forms.Padding(0);
            this.generalGroupButton.Name = "generalGroupButton";
            this.generalGroupButton.Size = new System.Drawing.Size(69, 27);
            this.generalGroupButton.TabIndex = 4;
            this.generalGroupButton.Text = "General";
            this.generalGroupButton.UseVisualStyleBackColor = false;
            this.generalGroupButton.Visible = false;
            this.generalGroupButton.Click += new System.EventHandler(this.generalGroupButton_Click);
            // 
            // movementGroupButton
            // 
            this.movementGroupButton.AutoSize = true;
            this.movementGroupButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.movementGroupButton.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.movementGroupButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.movementGroupButton.Location = new System.Drawing.Point(11, 224);
            this.movementGroupButton.Margin = new System.Windows.Forms.Padding(0);
            this.movementGroupButton.Name = "movementGroupButton";
            this.movementGroupButton.Size = new System.Drawing.Size(83, 27);
            this.movementGroupButton.TabIndex = 5;
            this.movementGroupButton.Text = "Movement";
            this.movementGroupButton.UseVisualStyleBackColor = false;
            this.movementGroupButton.Visible = false;
            this.movementGroupButton.Click += new System.EventHandler(this.movementGroupButton_Click);
            // 
            // combatGroupButton
            // 
            this.combatGroupButton.AutoSize = true;
            this.combatGroupButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.combatGroupButton.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.combatGroupButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.combatGroupButton.Location = new System.Drawing.Point(11, 274);
            this.combatGroupButton.Margin = new System.Windows.Forms.Padding(0);
            this.combatGroupButton.Name = "combatGroupButton";
            this.combatGroupButton.Size = new System.Drawing.Size(66, 27);
            this.combatGroupButton.TabIndex = 6;
            this.combatGroupButton.Text = "Combat";
            this.combatGroupButton.UseVisualStyleBackColor = false;
            this.combatGroupButton.Visible = false;
            this.combatGroupButton.Click += new System.EventHandler(this.combatGroupButton_Click);
            // 
            // locationsGroupButton
            // 
            this.locationsGroupButton.AutoSize = true;
            this.locationsGroupButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.locationsGroupButton.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.locationsGroupButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.locationsGroupButton.Location = new System.Drawing.Point(11, 325);
            this.locationsGroupButton.Margin = new System.Windows.Forms.Padding(0);
            this.locationsGroupButton.Name = "locationsGroupButton";
            this.locationsGroupButton.Size = new System.Drawing.Size(79, 27);
            this.locationsGroupButton.TabIndex = 7;
            this.locationsGroupButton.Text = "Locations";
            this.locationsGroupButton.UseVisualStyleBackColor = false;
            this.locationsGroupButton.Visible = false;
            this.locationsGroupButton.Click += new System.EventHandler(this.locationGroupButton_Click);
            // 
            // groupComboBox
            // 
            this.groupComboBox.FormattingEnabled = true;
            this.groupComboBox.Items.AddRange(new object[] {
            "Cost",
            "Details",
            "Manufacturer",
            "Model",
            "Name",
            "Purchasable",
            "Rarity",
            "StockRole",
            "VariantName",
            "YangsThoughts"});
            this.groupComboBox.Location = new System.Drawing.Point(115, 127);
            this.groupComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupComboBox.Name = "groupComboBox";
            this.groupComboBox.Size = new System.Drawing.Size(171, 24);
            this.groupComboBox.TabIndex = 8;
            this.groupComboBox.Text = "Name";
            this.groupComboBox.Visible = false;
            this.groupComboBox.SelectedValueChanged += new System.EventHandler(this.GroupComboBox_SelectedValueChanged);
            // 
            // groupTextBox
            // 
            this.groupTextBox.Location = new System.Drawing.Point(308, 127);
            this.groupTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupTextBox.Multiline = true;
            this.groupTextBox.Name = "groupTextBox";
            this.groupTextBox.Size = new System.Drawing.Size(520, 110);
            this.groupTextBox.TabIndex = 9;
            this.groupTextBox.Visible = false;
            this.groupTextBox.TextChanged += new System.EventHandler(this.GroupTextBox_TextChanged);
            // 
            // applyChangesButton
            // 
            this.applyChangesButton.AutoSize = true;
            this.applyChangesButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.applyChangesButton.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.applyChangesButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.applyChangesButton.Location = new System.Drawing.Point(699, 49);
            this.applyChangesButton.Margin = new System.Windows.Forms.Padding(0);
            this.applyChangesButton.Name = "applyChangesButton";
            this.applyChangesButton.Size = new System.Drawing.Size(111, 27);
            this.applyChangesButton.TabIndex = 10;
            this.applyChangesButton.Text = "Apply changes";
            this.applyChangesButton.UseVisualStyleBackColor = false;
            this.applyChangesButton.Visible = false;
            this.applyChangesButton.Click += new System.EventHandler(this.applyChangesButton_Click);
            // 
            // loadButton
            // 
            this.loadButton.AutoSize = true;
            this.loadButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.loadButton.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.loadButton.Image = ((System.Drawing.Image)(resources.GetObject("loadButton.Image")));
            this.loadButton.Location = new System.Drawing.Point(11, 71);
            this.loadButton.Margin = new System.Windows.Forms.Padding(0);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(174, 39);
            this.loadButton.TabIndex = 2;
            this.loadButton.UseVisualStyleBackColor = false;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            this.loadButton.MouseEnter += new System.EventHandler(this.LoadButton_MouseEnter);
            this.loadButton.MouseLeave += new System.EventHandler(this.LoadButton_MouseLeave);
            // 
            // fileTextBox
            // 
            this.fileTextBox.Location = new System.Drawing.Point(251, 54);
            this.fileTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.fileTextBox.Name = "fileTextBox";
            this.fileTextBox.Size = new System.Drawing.Size(423, 22);
            this.fileTextBox.TabIndex = 11;
            this.fileTextBox.Visible = false;
            this.fileTextBox.TextChanged += new System.EventHandler(this.FileTextBox_TextChanged);
            // 
            // directoryLabel
            // 
            this.directoryLabel.AutoSize = true;
            this.directoryLabel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.directoryLabel.Location = new System.Drawing.Point(247, 22);
            this.directoryLabel.Name = "directoryLabel";
            this.directoryLabel.Size = new System.Drawing.Size(0, 17);
            this.directoryLabel.TabIndex = 12;
            this.directoryLabel.Visible = false;
            // 
            // locationComboBox
            // 
            this.locationComboBox.FormattingEnabled = true;
            this.locationComboBox.Items.AddRange(new object[] {
            "Tonnage"});
            this.locationComboBox.Location = new System.Drawing.Point(308, 303);
            this.locationComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.locationComboBox.Name = "locationComboBox";
            this.locationComboBox.Size = new System.Drawing.Size(171, 24);
            this.locationComboBox.TabIndex = 13;
            this.locationComboBox.Text = "Tonnage";
            this.locationComboBox.Visible = false;
            this.locationComboBox.SelectedValueChanged += new System.EventHandler(this.GroupComboBox_SelectedValueChanged);
            // 
            // weaponComboBox
            // 
            this.weaponComboBox.FormattingEnabled = true;
            this.weaponComboBox.Items.AddRange(new object[] {
            "Energy",
            "Ballistic",
            "AntiPersonnel",
            "Missile"});
            this.weaponComboBox.Location = new System.Drawing.Point(560, 303);
            this.weaponComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.weaponComboBox.Name = "weaponComboBox";
            this.weaponComboBox.Size = new System.Drawing.Size(171, 24);
            this.weaponComboBox.TabIndex = 14;
            this.weaponComboBox.Text = "Energy";
            this.weaponComboBox.Visible = false;
            // 
            // omniCheckBox
            // 
            this.omniCheckBox.AutoSize = true;
            this.omniCheckBox.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.omniCheckBox.Location = new System.Drawing.Point(739, 304);
            this.omniCheckBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.omniCheckBox.Name = "omniCheckBox";
            this.omniCheckBox.Size = new System.Drawing.Size(63, 21);
            this.omniCheckBox.TabIndex = 15;
            this.omniCheckBox.Text = "Omni";
            this.omniCheckBox.UseVisualStyleBackColor = true;
            this.omniCheckBox.Visible = false;
            // 
            // addHardpointButton
            // 
            this.addHardpointButton.AutoSize = true;
            this.addHardpointButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.addHardpointButton.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.addHardpointButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.addHardpointButton.Location = new System.Drawing.Point(805, 300);
            this.addHardpointButton.Margin = new System.Windows.Forms.Padding(0);
            this.addHardpointButton.Name = "addHardpointButton";
            this.addHardpointButton.Size = new System.Drawing.Size(43, 27);
            this.addHardpointButton.TabIndex = 16;
            this.addHardpointButton.Text = "Add";
            this.addHardpointButton.UseVisualStyleBackColor = false;
            this.addHardpointButton.Visible = false;
            this.addHardpointButton.Click += new System.EventHandler(this.AddHardpointButton_Click);
            // 
            // energyOmniTrueLabel
            // 
            this.energyOmniTrueLabel.AutoSize = true;
            this.energyOmniTrueLabel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.energyOmniTrueLabel.Location = new System.Drawing.Point(560, 354);
            this.energyOmniTrueLabel.Name = "energyOmniTrueLabel";
            this.energyOmniTrueLabel.Size = new System.Drawing.Size(133, 17);
            this.energyOmniTrueLabel.TabIndex = 17;
            this.energyOmniTrueLabel.Text = "Energy - Omni True";
            this.energyOmniTrueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.energyOmniTrueLabel.Visible = false;
            // 
            // energyOmniFalseLabel
            // 
            this.energyOmniFalseLabel.AutoSize = true;
            this.energyOmniFalseLabel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.energyOmniFalseLabel.Location = new System.Drawing.Point(560, 385);
            this.energyOmniFalseLabel.Name = "energyOmniFalseLabel";
            this.energyOmniFalseLabel.Size = new System.Drawing.Size(137, 17);
            this.energyOmniFalseLabel.TabIndex = 18;
            this.energyOmniFalseLabel.Text = "Energy - Omni False";
            this.energyOmniFalseLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.energyOmniFalseLabel.Visible = false;
            // 
            // ballisticOmniFalseLabel
            // 
            this.ballisticOmniFalseLabel.AutoSize = true;
            this.ballisticOmniFalseLabel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.ballisticOmniFalseLabel.Location = new System.Drawing.Point(557, 455);
            this.ballisticOmniFalseLabel.Name = "ballisticOmniFalseLabel";
            this.ballisticOmniFalseLabel.Size = new System.Drawing.Size(139, 17);
            this.ballisticOmniFalseLabel.TabIndex = 20;
            this.ballisticOmniFalseLabel.Text = "Ballistic - Omni False";
            this.ballisticOmniFalseLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ballisticOmniFalseLabel.Visible = false;
            // 
            // ballisticOmniTrueLabel
            // 
            this.ballisticOmniTrueLabel.AutoSize = true;
            this.ballisticOmniTrueLabel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.ballisticOmniTrueLabel.Location = new System.Drawing.Point(557, 425);
            this.ballisticOmniTrueLabel.Name = "ballisticOmniTrueLabel";
            this.ballisticOmniTrueLabel.Size = new System.Drawing.Size(135, 17);
            this.ballisticOmniTrueLabel.TabIndex = 19;
            this.ballisticOmniTrueLabel.Text = "Ballistic - Omni True";
            this.ballisticOmniTrueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ballisticOmniTrueLabel.Visible = false;
            // 
            // missileOmniFalseLabel
            // 
            this.missileOmniFalseLabel.AutoSize = true;
            this.missileOmniFalseLabel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.missileOmniFalseLabel.Location = new System.Drawing.Point(557, 594);
            this.missileOmniFalseLabel.Name = "missileOmniFalseLabel";
            this.missileOmniFalseLabel.Size = new System.Drawing.Size(134, 17);
            this.missileOmniFalseLabel.TabIndex = 24;
            this.missileOmniFalseLabel.Text = "Missile - Omni False";
            this.missileOmniFalseLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.missileOmniFalseLabel.Visible = false;
            // 
            // missileOmniTrueLabel
            // 
            this.missileOmniTrueLabel.AutoSize = true;
            this.missileOmniTrueLabel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.missileOmniTrueLabel.Location = new System.Drawing.Point(557, 565);
            this.missileOmniTrueLabel.Name = "missileOmniTrueLabel";
            this.missileOmniTrueLabel.Size = new System.Drawing.Size(130, 17);
            this.missileOmniTrueLabel.TabIndex = 23;
            this.missileOmniTrueLabel.Text = "Missile - Omni True";
            this.missileOmniTrueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.missileOmniTrueLabel.Visible = false;
            // 
            // antiPersonnelOmniFalseLabel
            // 
            this.antiPersonnelOmniFalseLabel.AutoSize = true;
            this.antiPersonnelOmniFalseLabel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.antiPersonnelOmniFalseLabel.Location = new System.Drawing.Point(557, 526);
            this.antiPersonnelOmniFalseLabel.Name = "antiPersonnelOmniFalseLabel";
            this.antiPersonnelOmniFalseLabel.Size = new System.Drawing.Size(180, 17);
            this.antiPersonnelOmniFalseLabel.TabIndex = 22;
            this.antiPersonnelOmniFalseLabel.Text = "AntiPersonnel - Omni False";
            this.antiPersonnelOmniFalseLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.antiPersonnelOmniFalseLabel.Visible = false;
            // 
            // antiPersonnelOmniTrueLabel
            // 
            this.antiPersonnelOmniTrueLabel.AutoSize = true;
            this.antiPersonnelOmniTrueLabel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.antiPersonnelOmniTrueLabel.Location = new System.Drawing.Point(557, 495);
            this.antiPersonnelOmniTrueLabel.Name = "antiPersonnelOmniTrueLabel";
            this.antiPersonnelOmniTrueLabel.Size = new System.Drawing.Size(176, 17);
            this.antiPersonnelOmniTrueLabel.TabIndex = 21;
            this.antiPersonnelOmniTrueLabel.Text = "AntiPersonnel - Omni True";
            this.antiPersonnelOmniTrueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.antiPersonnelOmniTrueLabel.Visible = false;
            // 
            // energyOmniTrueCountLabel
            // 
            this.energyOmniTrueCountLabel.AutoSize = true;
            this.energyOmniTrueCountLabel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.energyOmniTrueCountLabel.Location = new System.Drawing.Point(749, 354);
            this.energyOmniTrueCountLabel.Name = "energyOmniTrueCountLabel";
            this.energyOmniTrueCountLabel.Size = new System.Drawing.Size(16, 17);
            this.energyOmniTrueCountLabel.TabIndex = 25;
            this.energyOmniTrueCountLabel.Text = "0";
            this.energyOmniTrueCountLabel.Visible = false;
            // 
            // energyOmniFalseCountLabel
            // 
            this.energyOmniFalseCountLabel.AutoSize = true;
            this.energyOmniFalseCountLabel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.energyOmniFalseCountLabel.Location = new System.Drawing.Point(749, 385);
            this.energyOmniFalseCountLabel.Name = "energyOmniFalseCountLabel";
            this.energyOmniFalseCountLabel.Size = new System.Drawing.Size(16, 17);
            this.energyOmniFalseCountLabel.TabIndex = 26;
            this.energyOmniFalseCountLabel.Text = "0";
            this.energyOmniFalseCountLabel.Visible = false;
            // 
            // ballisticOmniTrueCountLabel
            // 
            this.ballisticOmniTrueCountLabel.AutoSize = true;
            this.ballisticOmniTrueCountLabel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.ballisticOmniTrueCountLabel.Location = new System.Drawing.Point(749, 425);
            this.ballisticOmniTrueCountLabel.Name = "ballisticOmniTrueCountLabel";
            this.ballisticOmniTrueCountLabel.Size = new System.Drawing.Size(16, 17);
            this.ballisticOmniTrueCountLabel.TabIndex = 27;
            this.ballisticOmniTrueCountLabel.Text = "0";
            this.ballisticOmniTrueCountLabel.Visible = false;
            // 
            // ballisticOmniFalseCountLabel
            // 
            this.ballisticOmniFalseCountLabel.AutoSize = true;
            this.ballisticOmniFalseCountLabel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.ballisticOmniFalseCountLabel.Location = new System.Drawing.Point(749, 455);
            this.ballisticOmniFalseCountLabel.Name = "ballisticOmniFalseCountLabel";
            this.ballisticOmniFalseCountLabel.Size = new System.Drawing.Size(16, 17);
            this.ballisticOmniFalseCountLabel.TabIndex = 28;
            this.ballisticOmniFalseCountLabel.Text = "0";
            this.ballisticOmniFalseCountLabel.Visible = false;
            // 
            // missileOmniFalseCountLabel
            // 
            this.missileOmniFalseCountLabel.AutoSize = true;
            this.missileOmniFalseCountLabel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.missileOmniFalseCountLabel.Location = new System.Drawing.Point(749, 594);
            this.missileOmniFalseCountLabel.Name = "missileOmniFalseCountLabel";
            this.missileOmniFalseCountLabel.Size = new System.Drawing.Size(16, 17);
            this.missileOmniFalseCountLabel.TabIndex = 32;
            this.missileOmniFalseCountLabel.Text = "0";
            this.missileOmniFalseCountLabel.Visible = false;
            // 
            // missileOmniTrueCountLabel
            // 
            this.missileOmniTrueCountLabel.AutoSize = true;
            this.missileOmniTrueCountLabel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.missileOmniTrueCountLabel.Location = new System.Drawing.Point(749, 565);
            this.missileOmniTrueCountLabel.Name = "missileOmniTrueCountLabel";
            this.missileOmniTrueCountLabel.Size = new System.Drawing.Size(16, 17);
            this.missileOmniTrueCountLabel.TabIndex = 31;
            this.missileOmniTrueCountLabel.Text = "0";
            this.missileOmniTrueCountLabel.Visible = false;
            // 
            // antiPersonnelOmniFalseCountLabel
            // 
            this.antiPersonnelOmniFalseCountLabel.AutoSize = true;
            this.antiPersonnelOmniFalseCountLabel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.antiPersonnelOmniFalseCountLabel.Location = new System.Drawing.Point(749, 526);
            this.antiPersonnelOmniFalseCountLabel.Name = "antiPersonnelOmniFalseCountLabel";
            this.antiPersonnelOmniFalseCountLabel.Size = new System.Drawing.Size(16, 17);
            this.antiPersonnelOmniFalseCountLabel.TabIndex = 30;
            this.antiPersonnelOmniFalseCountLabel.Text = "0";
            this.antiPersonnelOmniFalseCountLabel.Visible = false;
            // 
            // antiPersonnelOmniTrueCountLabel
            // 
            this.antiPersonnelOmniTrueCountLabel.AutoSize = true;
            this.antiPersonnelOmniTrueCountLabel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.antiPersonnelOmniTrueCountLabel.Location = new System.Drawing.Point(749, 495);
            this.antiPersonnelOmniTrueCountLabel.Name = "antiPersonnelOmniTrueCountLabel";
            this.antiPersonnelOmniTrueCountLabel.Size = new System.Drawing.Size(16, 17);
            this.antiPersonnelOmniTrueCountLabel.TabIndex = 29;
            this.antiPersonnelOmniTrueCountLabel.Text = "0";
            this.antiPersonnelOmniTrueCountLabel.Visible = false;
            // 
            // removeEnergyOmniTrueButton
            // 
            this.removeEnergyOmniTrueButton.AutoSize = true;
            this.removeEnergyOmniTrueButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.removeEnergyOmniTrueButton.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.removeEnergyOmniTrueButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.removeEnergyOmniTrueButton.Location = new System.Drawing.Point(779, 350);
            this.removeEnergyOmniTrueButton.Margin = new System.Windows.Forms.Padding(0);
            this.removeEnergyOmniTrueButton.Name = "removeEnergyOmniTrueButton";
            this.removeEnergyOmniTrueButton.Size = new System.Drawing.Size(70, 27);
            this.removeEnergyOmniTrueButton.TabIndex = 33;
            this.removeEnergyOmniTrueButton.Text = "Remove";
            this.removeEnergyOmniTrueButton.UseVisualStyleBackColor = false;
            this.removeEnergyOmniTrueButton.Visible = false;
            this.removeEnergyOmniTrueButton.Click += new System.EventHandler(this.RemoveHardpoint_Click);
            // 
            // removeEnergyOmniFalseButton
            // 
            this.removeEnergyOmniFalseButton.AutoSize = true;
            this.removeEnergyOmniFalseButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.removeEnergyOmniFalseButton.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.removeEnergyOmniFalseButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.removeEnergyOmniFalseButton.Location = new System.Drawing.Point(779, 380);
            this.removeEnergyOmniFalseButton.Margin = new System.Windows.Forms.Padding(0);
            this.removeEnergyOmniFalseButton.Name = "removeEnergyOmniFalseButton";
            this.removeEnergyOmniFalseButton.Size = new System.Drawing.Size(70, 27);
            this.removeEnergyOmniFalseButton.TabIndex = 34;
            this.removeEnergyOmniFalseButton.Text = "Remove";
            this.removeEnergyOmniFalseButton.UseVisualStyleBackColor = false;
            this.removeEnergyOmniFalseButton.Visible = false;
            this.removeEnergyOmniFalseButton.Click += new System.EventHandler(this.RemoveHardpoint_Click);
            // 
            // removeBallisticOmniTrueButton
            // 
            this.removeBallisticOmniTrueButton.AutoSize = true;
            this.removeBallisticOmniTrueButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.removeBallisticOmniTrueButton.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.removeBallisticOmniTrueButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.removeBallisticOmniTrueButton.Location = new System.Drawing.Point(779, 420);
            this.removeBallisticOmniTrueButton.Margin = new System.Windows.Forms.Padding(0);
            this.removeBallisticOmniTrueButton.Name = "removeBallisticOmniTrueButton";
            this.removeBallisticOmniTrueButton.Size = new System.Drawing.Size(70, 27);
            this.removeBallisticOmniTrueButton.TabIndex = 35;
            this.removeBallisticOmniTrueButton.Text = "Remove";
            this.removeBallisticOmniTrueButton.UseVisualStyleBackColor = false;
            this.removeBallisticOmniTrueButton.Visible = false;
            this.removeBallisticOmniTrueButton.Click += new System.EventHandler(this.RemoveHardpoint_Click);
            // 
            // removeBallisticOmniFalseButton
            // 
            this.removeBallisticOmniFalseButton.AutoSize = true;
            this.removeBallisticOmniFalseButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.removeBallisticOmniFalseButton.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.removeBallisticOmniFalseButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.removeBallisticOmniFalseButton.Location = new System.Drawing.Point(779, 450);
            this.removeBallisticOmniFalseButton.Margin = new System.Windows.Forms.Padding(0);
            this.removeBallisticOmniFalseButton.Name = "removeBallisticOmniFalseButton";
            this.removeBallisticOmniFalseButton.Size = new System.Drawing.Size(70, 27);
            this.removeBallisticOmniFalseButton.TabIndex = 36;
            this.removeBallisticOmniFalseButton.Text = "Remove";
            this.removeBallisticOmniFalseButton.UseVisualStyleBackColor = false;
            this.removeBallisticOmniFalseButton.Visible = false;
            this.removeBallisticOmniFalseButton.Click += new System.EventHandler(this.RemoveHardpoint_Click);
            // 
            // removeMissileOmniFalseButton
            // 
            this.removeMissileOmniFalseButton.AutoSize = true;
            this.removeMissileOmniFalseButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.removeMissileOmniFalseButton.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.removeMissileOmniFalseButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.removeMissileOmniFalseButton.Location = new System.Drawing.Point(779, 590);
            this.removeMissileOmniFalseButton.Margin = new System.Windows.Forms.Padding(0);
            this.removeMissileOmniFalseButton.Name = "removeMissileOmniFalseButton";
            this.removeMissileOmniFalseButton.Size = new System.Drawing.Size(70, 27);
            this.removeMissileOmniFalseButton.TabIndex = 40;
            this.removeMissileOmniFalseButton.Text = "Remove";
            this.removeMissileOmniFalseButton.UseVisualStyleBackColor = false;
            this.removeMissileOmniFalseButton.Visible = false;
            this.removeMissileOmniFalseButton.Click += new System.EventHandler(this.RemoveHardpoint_Click);
            // 
            // removeMissileOmniTrueButton
            // 
            this.removeMissileOmniTrueButton.AutoSize = true;
            this.removeMissileOmniTrueButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.removeMissileOmniTrueButton.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.removeMissileOmniTrueButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.removeMissileOmniTrueButton.Location = new System.Drawing.Point(779, 560);
            this.removeMissileOmniTrueButton.Margin = new System.Windows.Forms.Padding(0);
            this.removeMissileOmniTrueButton.Name = "removeMissileOmniTrueButton";
            this.removeMissileOmniTrueButton.Size = new System.Drawing.Size(70, 27);
            this.removeMissileOmniTrueButton.TabIndex = 39;
            this.removeMissileOmniTrueButton.Text = "Remove";
            this.removeMissileOmniTrueButton.UseVisualStyleBackColor = false;
            this.removeMissileOmniTrueButton.Visible = false;
            this.removeMissileOmniTrueButton.Click += new System.EventHandler(this.RemoveHardpoint_Click);
            // 
            // removeAntiPersonnelOmniFalseButton
            // 
            this.removeAntiPersonnelOmniFalseButton.AutoSize = true;
            this.removeAntiPersonnelOmniFalseButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.removeAntiPersonnelOmniFalseButton.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.removeAntiPersonnelOmniFalseButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.removeAntiPersonnelOmniFalseButton.Location = new System.Drawing.Point(779, 519);
            this.removeAntiPersonnelOmniFalseButton.Margin = new System.Windows.Forms.Padding(0);
            this.removeAntiPersonnelOmniFalseButton.Name = "removeAntiPersonnelOmniFalseButton";
            this.removeAntiPersonnelOmniFalseButton.Size = new System.Drawing.Size(70, 27);
            this.removeAntiPersonnelOmniFalseButton.TabIndex = 38;
            this.removeAntiPersonnelOmniFalseButton.Text = "Remove";
            this.removeAntiPersonnelOmniFalseButton.UseVisualStyleBackColor = false;
            this.removeAntiPersonnelOmniFalseButton.Visible = false;
            this.removeAntiPersonnelOmniFalseButton.Click += new System.EventHandler(this.RemoveHardpoint_Click);
            // 
            // removeAntiPersonnelOmniTrueButton
            // 
            this.removeAntiPersonnelOmniTrueButton.AutoSize = true;
            this.removeAntiPersonnelOmniTrueButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.removeAntiPersonnelOmniTrueButton.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.removeAntiPersonnelOmniTrueButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.removeAntiPersonnelOmniTrueButton.Location = new System.Drawing.Point(779, 490);
            this.removeAntiPersonnelOmniTrueButton.Margin = new System.Windows.Forms.Padding(0);
            this.removeAntiPersonnelOmniTrueButton.Name = "removeAntiPersonnelOmniTrueButton";
            this.removeAntiPersonnelOmniTrueButton.Size = new System.Drawing.Size(70, 27);
            this.removeAntiPersonnelOmniTrueButton.TabIndex = 37;
            this.removeAntiPersonnelOmniTrueButton.Text = "Remove";
            this.removeAntiPersonnelOmniTrueButton.UseVisualStyleBackColor = false;
            this.removeAntiPersonnelOmniTrueButton.Visible = false;
            this.removeAntiPersonnelOmniTrueButton.Click += new System.EventHandler(this.RemoveHardpoint_Click);
            // 
            // editSingleButton
            // 
            this.editSingleButton.AutoSize = true;
            this.editSingleButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.editSingleButton.Image = ((System.Drawing.Image)(resources.GetObject("editSingleButton.Image")));
            this.editSingleButton.Location = new System.Drawing.Point(12, 0);
            this.editSingleButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.editSingleButton.Name = "editSingleButton";
            this.editSingleButton.Size = new System.Drawing.Size(174, 39);
            this.editSingleButton.TabIndex = 41;
            this.editSingleButton.UseVisualStyleBackColor = true;
            this.editSingleButton.Click += new System.EventHandler(this.toggleMode);
            // 
            // editBatchButton
            // 
            this.editBatchButton.AutoSize = true;
            this.editBatchButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.editBatchButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.editBatchButton.Image = global::Chassis_Editor.Properties.Resources.EditBatchButtonUnselected;
            this.editBatchButton.Location = new System.Drawing.Point(253, 0);
            this.editBatchButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.editBatchButton.Name = "editBatchButton";
            this.editBatchButton.Size = new System.Drawing.Size(174, 39);
            this.editBatchButton.TabIndex = 42;
            this.editBatchButton.UseVisualStyleBackColor = true;
            this.editBatchButton.Click += new System.EventHandler(this.toggleMode);
            // 
            // clearChangesButton
            // 
            this.clearChangesButton.AutoSize = true;
            this.clearChangesButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.clearChangesButton.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.clearChangesButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.clearChangesButton.Location = new System.Drawing.Point(827, 49);
            this.clearChangesButton.Margin = new System.Windows.Forms.Padding(0);
            this.clearChangesButton.Name = "clearChangesButton";
            this.clearChangesButton.Size = new System.Drawing.Size(109, 27);
            this.clearChangesButton.TabIndex = 43;
            this.clearChangesButton.Text = "Clear changes";
            this.clearChangesButton.UseVisualStyleBackColor = false;
            this.clearChangesButton.Visible = false;
            this.clearChangesButton.Click += new System.EventHandler(this.clearChangesButton_Click);
            // 
            // saveChangeButton
            // 
            this.saveChangeButton.AutoSize = true;
            this.saveChangeButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.saveChangeButton.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.saveChangeButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.saveChangeButton.Location = new System.Drawing.Point(875, 300);
            this.saveChangeButton.Margin = new System.Windows.Forms.Padding(0);
            this.saveChangeButton.Name = "saveChangeButton";
            this.saveChangeButton.Size = new System.Drawing.Size(101, 27);
            this.saveChangeButton.TabIndex = 44;
            this.saveChangeButton.Text = "Save change";
            this.saveChangeButton.UseVisualStyleBackColor = false;
            this.saveChangeButton.Visible = false;
            this.saveChangeButton.Click += new System.EventHandler(this.SaveChangeButton_Click);
            // 
            // operationComboBox
            // 
            this.operationComboBox.FormattingEnabled = true;
            this.operationComboBox.Items.AddRange(new object[] {
            "=",
            "-",
            "+"});
            this.operationComboBox.Location = new System.Drawing.Point(500, 304);
            this.operationComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.operationComboBox.Name = "operationComboBox";
            this.operationComboBox.Size = new System.Drawing.Size(37, 24);
            this.operationComboBox.TabIndex = 45;
            this.operationComboBox.Text = "=";
            this.operationComboBox.Visible = false;
            // 
            // energyOmniTrueOperationComboBox
            // 
            this.energyOmniTrueOperationComboBox.FormattingEnabled = true;
            this.energyOmniTrueOperationComboBox.Items.AddRange(new object[] {
            "=",
            "-",
            "+"});
            this.energyOmniTrueOperationComboBox.Location = new System.Drawing.Point(875, 351);
            this.energyOmniTrueOperationComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.energyOmniTrueOperationComboBox.Name = "energyOmniTrueOperationComboBox";
            this.energyOmniTrueOperationComboBox.Size = new System.Drawing.Size(37, 24);
            this.energyOmniTrueOperationComboBox.TabIndex = 46;
            this.energyOmniTrueOperationComboBox.Text = "=";
            this.energyOmniTrueOperationComboBox.Visible = false;
            this.energyOmniTrueOperationComboBox.Click += new System.EventHandler(this.HardpointOperationComboBox_Click);
            // 
            // energyOmniFalseOperationComboBox
            // 
            this.energyOmniFalseOperationComboBox.FormattingEnabled = true;
            this.energyOmniFalseOperationComboBox.Items.AddRange(new object[] {
            "=",
            "-",
            "+"});
            this.energyOmniFalseOperationComboBox.Location = new System.Drawing.Point(875, 385);
            this.energyOmniFalseOperationComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.energyOmniFalseOperationComboBox.Name = "energyOmniFalseOperationComboBox";
            this.energyOmniFalseOperationComboBox.Size = new System.Drawing.Size(37, 24);
            this.energyOmniFalseOperationComboBox.TabIndex = 47;
            this.energyOmniFalseOperationComboBox.Text = "=";
            this.energyOmniFalseOperationComboBox.Visible = false;
            this.energyOmniFalseOperationComboBox.Click += new System.EventHandler(this.HardpointOperationComboBox_Click);
            // 
            // ballisticOmniTrueOperationComboBox
            // 
            this.ballisticOmniTrueOperationComboBox.FormattingEnabled = true;
            this.ballisticOmniTrueOperationComboBox.Items.AddRange(new object[] {
            "=",
            "-",
            "+"});
            this.ballisticOmniTrueOperationComboBox.Location = new System.Drawing.Point(875, 418);
            this.ballisticOmniTrueOperationComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ballisticOmniTrueOperationComboBox.Name = "ballisticOmniTrueOperationComboBox";
            this.ballisticOmniTrueOperationComboBox.Size = new System.Drawing.Size(37, 24);
            this.ballisticOmniTrueOperationComboBox.TabIndex = 48;
            this.ballisticOmniTrueOperationComboBox.Text = "=";
            this.ballisticOmniTrueOperationComboBox.Visible = false;
            this.ballisticOmniTrueOperationComboBox.Click += new System.EventHandler(this.HardpointOperationComboBox_Click);
            // 
            // ballisticOmniFalseOperationComboBox
            // 
            this.ballisticOmniFalseOperationComboBox.FormattingEnabled = true;
            this.ballisticOmniFalseOperationComboBox.Items.AddRange(new object[] {
            "=",
            "-",
            "+"});
            this.ballisticOmniFalseOperationComboBox.Location = new System.Drawing.Point(875, 452);
            this.ballisticOmniFalseOperationComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ballisticOmniFalseOperationComboBox.Name = "ballisticOmniFalseOperationComboBox";
            this.ballisticOmniFalseOperationComboBox.Size = new System.Drawing.Size(37, 24);
            this.ballisticOmniFalseOperationComboBox.TabIndex = 49;
            this.ballisticOmniFalseOperationComboBox.Text = "=";
            this.ballisticOmniFalseOperationComboBox.Visible = false;
            this.ballisticOmniFalseOperationComboBox.Click += new System.EventHandler(this.HardpointOperationComboBox_Click);
            // 
            // antiPersonnelOmniTrueOperationComboBox
            // 
            this.antiPersonnelOmniTrueOperationComboBox.FormattingEnabled = true;
            this.antiPersonnelOmniTrueOperationComboBox.Items.AddRange(new object[] {
            "=",
            "-",
            "+"});
            this.antiPersonnelOmniTrueOperationComboBox.Location = new System.Drawing.Point(875, 495);
            this.antiPersonnelOmniTrueOperationComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.antiPersonnelOmniTrueOperationComboBox.Name = "antiPersonnelOmniTrueOperationComboBox";
            this.antiPersonnelOmniTrueOperationComboBox.Size = new System.Drawing.Size(37, 24);
            this.antiPersonnelOmniTrueOperationComboBox.TabIndex = 50;
            this.antiPersonnelOmniTrueOperationComboBox.Text = "=";
            this.antiPersonnelOmniTrueOperationComboBox.Visible = false;
            this.antiPersonnelOmniTrueOperationComboBox.Click += new System.EventHandler(this.HardpointOperationComboBox_Click);
            // 
            // antiPersonnelOmniFalseOperationComboBox
            // 
            this.antiPersonnelOmniFalseOperationComboBox.FormattingEnabled = true;
            this.antiPersonnelOmniFalseOperationComboBox.Items.AddRange(new object[] {
            "=",
            "-",
            "+"});
            this.antiPersonnelOmniFalseOperationComboBox.Location = new System.Drawing.Point(875, 526);
            this.antiPersonnelOmniFalseOperationComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.antiPersonnelOmniFalseOperationComboBox.Name = "antiPersonnelOmniFalseOperationComboBox";
            this.antiPersonnelOmniFalseOperationComboBox.Size = new System.Drawing.Size(37, 24);
            this.antiPersonnelOmniFalseOperationComboBox.TabIndex = 51;
            this.antiPersonnelOmniFalseOperationComboBox.Text = "=";
            this.antiPersonnelOmniFalseOperationComboBox.Visible = false;
            this.antiPersonnelOmniFalseOperationComboBox.Click += new System.EventHandler(this.HardpointOperationComboBox_Click);
            // 
            // missileOmniTrueOperationComboBox
            // 
            this.missileOmniTrueOperationComboBox.FormattingEnabled = true;
            this.missileOmniTrueOperationComboBox.Items.AddRange(new object[] {
            "=",
            "-",
            "+"});
            this.missileOmniTrueOperationComboBox.Location = new System.Drawing.Point(875, 565);
            this.missileOmniTrueOperationComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.missileOmniTrueOperationComboBox.Name = "missileOmniTrueOperationComboBox";
            this.missileOmniTrueOperationComboBox.Size = new System.Drawing.Size(37, 24);
            this.missileOmniTrueOperationComboBox.TabIndex = 52;
            this.missileOmniTrueOperationComboBox.Text = "=";
            this.missileOmniTrueOperationComboBox.Visible = false;
            this.missileOmniTrueOperationComboBox.Click += new System.EventHandler(this.HardpointOperationComboBox_Click);
            // 
            // missileOmniFalseOperationComboBox
            // 
            this.missileOmniFalseOperationComboBox.FormattingEnabled = true;
            this.missileOmniFalseOperationComboBox.Items.AddRange(new object[] {
            "=",
            "-",
            "+"});
            this.missileOmniFalseOperationComboBox.Location = new System.Drawing.Point(875, 594);
            this.missileOmniFalseOperationComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.missileOmniFalseOperationComboBox.Name = "missileOmniFalseOperationComboBox";
            this.missileOmniFalseOperationComboBox.Size = new System.Drawing.Size(37, 24);
            this.missileOmniFalseOperationComboBox.TabIndex = 53;
            this.missileOmniFalseOperationComboBox.Text = "=";
            this.missileOmniFalseOperationComboBox.Visible = false;
            this.missileOmniFalseOperationComboBox.Click += new System.EventHandler(this.HardpointOperationComboBox_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1699, 718);
            this.Controls.Add(this.missileOmniFalseOperationComboBox);
            this.Controls.Add(this.missileOmniTrueOperationComboBox);
            this.Controls.Add(this.antiPersonnelOmniFalseOperationComboBox);
            this.Controls.Add(this.antiPersonnelOmniTrueOperationComboBox);
            this.Controls.Add(this.ballisticOmniFalseOperationComboBox);
            this.Controls.Add(this.ballisticOmniTrueOperationComboBox);
            this.Controls.Add(this.energyOmniFalseOperationComboBox);
            this.Controls.Add(this.energyOmniTrueOperationComboBox);
            this.Controls.Add(this.operationComboBox);
            this.Controls.Add(this.saveChangeButton);
            this.Controls.Add(this.clearChangesButton);
            this.Controls.Add(this.editBatchButton);
            this.Controls.Add(this.editSingleButton);
            this.Controls.Add(this.removeMissileOmniFalseButton);
            this.Controls.Add(this.removeMissileOmniTrueButton);
            this.Controls.Add(this.removeAntiPersonnelOmniFalseButton);
            this.Controls.Add(this.removeAntiPersonnelOmniTrueButton);
            this.Controls.Add(this.removeBallisticOmniFalseButton);
            this.Controls.Add(this.removeBallisticOmniTrueButton);
            this.Controls.Add(this.removeEnergyOmniFalseButton);
            this.Controls.Add(this.removeEnergyOmniTrueButton);
            this.Controls.Add(this.missileOmniFalseCountLabel);
            this.Controls.Add(this.missileOmniTrueCountLabel);
            this.Controls.Add(this.antiPersonnelOmniFalseCountLabel);
            this.Controls.Add(this.antiPersonnelOmniTrueCountLabel);
            this.Controls.Add(this.ballisticOmniFalseCountLabel);
            this.Controls.Add(this.ballisticOmniTrueCountLabel);
            this.Controls.Add(this.energyOmniFalseCountLabel);
            this.Controls.Add(this.energyOmniTrueCountLabel);
            this.Controls.Add(this.missileOmniFalseLabel);
            this.Controls.Add(this.missileOmniTrueLabel);
            this.Controls.Add(this.antiPersonnelOmniFalseLabel);
            this.Controls.Add(this.antiPersonnelOmniTrueLabel);
            this.Controls.Add(this.ballisticOmniFalseLabel);
            this.Controls.Add(this.ballisticOmniTrueLabel);
            this.Controls.Add(this.energyOmniFalseLabel);
            this.Controls.Add(this.energyOmniTrueLabel);
            this.Controls.Add(this.addHardpointButton);
            this.Controls.Add(this.omniCheckBox);
            this.Controls.Add(this.weaponComboBox);
            this.Controls.Add(this.locationComboBox);
            this.Controls.Add(this.directoryLabel);
            this.Controls.Add(this.fileTextBox);
            this.Controls.Add(this.applyChangesButton);
            this.Controls.Add(this.groupTextBox);
            this.Controls.Add(this.groupComboBox);
            this.Controls.Add(this.locationsGroupButton);
            this.Controls.Add(this.combatGroupButton);
            this.Controls.Add(this.movementGroupButton);
            this.Controls.Add(this.generalGroupButton);
            this.Controls.Add(this.descriptionGroupButton);
            this.Controls.Add(this.loadButton);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainWindow";
            this.Text = "Chassis Editor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.Button descriptionGroupButton;
        private System.Windows.Forms.Button generalGroupButton;
        private System.Windows.Forms.Button movementGroupButton;
        private System.Windows.Forms.Button combatGroupButton;
        private System.Windows.Forms.Button locationsGroupButton;
        private System.Windows.Forms.ComboBox groupComboBox;
        private System.Windows.Forms.TextBox groupTextBox;
        private System.Windows.Forms.Button applyChangesButton;
        private System.Windows.Forms.TextBox fileTextBox;
        private System.Windows.Forms.Label directoryLabel;
        private System.Windows.Forms.ComboBox locationComboBox;
        private System.Windows.Forms.ComboBox weaponComboBox;
        private System.Windows.Forms.CheckBox omniCheckBox;
        private System.Windows.Forms.Button addHardpointButton;
        private System.Windows.Forms.Label energyOmniTrueLabel;
        private System.Windows.Forms.Label energyOmniFalseLabel;
        private System.Windows.Forms.Label ballisticOmniFalseLabel;
        private System.Windows.Forms.Label ballisticOmniTrueLabel;
        private System.Windows.Forms.Label missileOmniFalseLabel;
        private System.Windows.Forms.Label missileOmniTrueLabel;
        private System.Windows.Forms.Label antiPersonnelOmniFalseLabel;
        private System.Windows.Forms.Label antiPersonnelOmniTrueLabel;
        private System.Windows.Forms.Label energyOmniTrueCountLabel;
        private System.Windows.Forms.Label energyOmniFalseCountLabel;
        private System.Windows.Forms.Label ballisticOmniTrueCountLabel;
        private System.Windows.Forms.Label ballisticOmniFalseCountLabel;
        private System.Windows.Forms.Label missileOmniFalseCountLabel;
        private System.Windows.Forms.Label missileOmniTrueCountLabel;
        private System.Windows.Forms.Label antiPersonnelOmniFalseCountLabel;
        private System.Windows.Forms.Label antiPersonnelOmniTrueCountLabel;
        private System.Windows.Forms.Button removeEnergyOmniTrueButton;
        private System.Windows.Forms.Button removeEnergyOmniFalseButton;
        private System.Windows.Forms.Button removeBallisticOmniTrueButton;
        private System.Windows.Forms.Button removeBallisticOmniFalseButton;
        private System.Windows.Forms.Button removeMissileOmniFalseButton;
        private System.Windows.Forms.Button removeMissileOmniTrueButton;
        private System.Windows.Forms.Button removeAntiPersonnelOmniFalseButton;
        private System.Windows.Forms.Button removeAntiPersonnelOmniTrueButton;
        private System.Windows.Forms.Button editSingleButton;
        private System.Windows.Forms.Button editBatchButton;
        private System.Windows.Forms.Button clearChangesButton;
        private System.Windows.Forms.Button saveChangeButton;
        private System.Windows.Forms.ComboBox operationComboBox;
        private System.Windows.Forms.ComboBox energyOmniTrueOperationComboBox;
        private System.Windows.Forms.ComboBox energyOmniFalseOperationComboBox;
        private System.Windows.Forms.ComboBox ballisticOmniTrueOperationComboBox;
        private System.Windows.Forms.ComboBox ballisticOmniFalseOperationComboBox;
        private System.Windows.Forms.ComboBox antiPersonnelOmniTrueOperationComboBox;
        private System.Windows.Forms.ComboBox antiPersonnelOmniFalseOperationComboBox;
        private System.Windows.Forms.ComboBox missileOmniTrueOperationComboBox;
        private System.Windows.Forms.ComboBox missileOmniFalseOperationComboBox;
    }
}

