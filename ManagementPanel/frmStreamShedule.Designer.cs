namespace ManagementPanel
{
    partial class frmStreamShedule
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStreamShedule));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbAdminCode = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbTitleCategory = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnCityNew = new System.Windows.Forms.Button();
            this.btnStateNew = new System.Windows.Forms.Button();
            this.cmbCityName = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbStateName = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbCountryName = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbDealerCode = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbAMPM = new System.Windows.Forms.ComboBox();
            this.cmbMin = new System.Windows.Forms.ComboBox();
            this.cmbHour = new System.Windows.Forms.ComboBox();
            this.cmbStreamName = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnRefersh = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgStream = new System.Windows.Forms.DataGridView();
            this.panel11 = new System.Windows.Forms.Panel();
            this.cmbSearchDealercode = new System.Windows.Forms.ComboBox();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.label21 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.panMainNew = new System.Windows.Forms.Panel();
            this.panNew = new System.Windows.Forms.Panel();
            this.btnNewCancel = new System.Windows.Forms.Button();
            this.btnSaveNew = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblCaption = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgStream)).BeginInit();
            this.panel11.SuspendLayout();
            this.panMainNew.SuspendLayout();
            this.panNew.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.cmbAdminCode);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cmbTitleCategory);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.btnCityNew);
            this.panel1.Controls.Add(this.btnStateNew);
            this.panel1.Controls.Add(this.cmbCityName);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.cmbStateName);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.cmbCountryName);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.cmbDealerCode);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cmbAMPM);
            this.panel1.Controls.Add(this.cmbMin);
            this.panel1.Controls.Add(this.cmbHour);
            this.panel1.Controls.Add(this.cmbStreamName);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.label17);
            this.panel1.Controls.Add(this.label22);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.dtpEndDate);
            this.panel1.Controls.Add(this.dtpStartDate);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1264, 147);
            this.panel1.TabIndex = 0;
            // 
            // cmbAdminCode
            // 
            this.cmbAdminCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAdminCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbAdminCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbAdminCode.FormattingEnabled = true;
            this.cmbAdminCode.Items.AddRange(new object[] {
            "",
            "MyClaud000",
            "TotalFina"});
            this.cmbAdminCode.Location = new System.Drawing.Point(394, 39);
            this.cmbAdminCode.Name = "cmbAdminCode";
            this.cmbAdminCode.Size = new System.Drawing.Size(225, 25);
            this.cmbAdminCode.TabIndex = 1;
            this.cmbAdminCode.SelectedIndexChanged += new System.EventHandler(this.cmbAdminCode_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(309, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 16);
            this.label1.TabIndex = 198;
            this.label1.Text = "Admin Code";
            // 
            // cmbTitleCategory
            // 
            this.cmbTitleCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTitleCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbTitleCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTitleCategory.FormattingEnabled = true;
            this.cmbTitleCategory.Location = new System.Drawing.Point(110, 39);
            this.cmbTitleCategory.Name = "cmbTitleCategory";
            this.cmbTitleCategory.Size = new System.Drawing.Size(193, 25);
            this.cmbTitleCategory.TabIndex = 0;
            this.cmbTitleCategory.SelectedIndexChanged += new System.EventHandler(this.cmbTitleCategory_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Arial", 9.75F);
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(6, 41);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 16);
            this.label7.TabIndex = 196;
            this.label7.Text = "Category Name";
            // 
            // btnCityNew
            // 
            this.btnCityNew.BackColor = System.Drawing.Color.Transparent;
            this.btnCityNew.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCityNew.BackgroundImage")));
            this.btnCityNew.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCityNew.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCityNew.FlatAppearance.MouseDownBackColor = System.Drawing.Color.PowderBlue;
            this.btnCityNew.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
            this.btnCityNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCityNew.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCityNew.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(117)))), ((int)(((byte)(188)))));
            this.btnCityNew.Location = new System.Drawing.Point(887, 108);
            this.btnCityNew.Name = "btnCityNew";
            this.btnCityNew.Size = new System.Drawing.Size(29, 25);
            this.btnCityNew.TabIndex = 194;
            this.btnCityNew.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCityNew.UseVisualStyleBackColor = false;
            this.btnCityNew.Click += new System.EventHandler(this.btnCityNew_Click);
            // 
            // btnStateNew
            // 
            this.btnStateNew.BackColor = System.Drawing.Color.Transparent;
            this.btnStateNew.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnStateNew.BackgroundImage")));
            this.btnStateNew.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnStateNew.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStateNew.FlatAppearance.MouseDownBackColor = System.Drawing.Color.PowderBlue;
            this.btnStateNew.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
            this.btnStateNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStateNew.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStateNew.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(117)))), ((int)(((byte)(188)))));
            this.btnStateNew.Location = new System.Drawing.Point(590, 106);
            this.btnStateNew.Name = "btnStateNew";
            this.btnStateNew.Size = new System.Drawing.Size(29, 25);
            this.btnStateNew.TabIndex = 193;
            this.btnStateNew.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnStateNew.UseVisualStyleBackColor = false;
            this.btnStateNew.Click += new System.EventHandler(this.btnStateNew_Click);
            // 
            // cmbCityName
            // 
            this.cmbCityName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbCityName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCityName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbCityName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCityName.FormattingEnabled = true;
            this.cmbCityName.Location = new System.Drawing.Point(719, 107);
            this.cmbCityName.Name = "cmbCityName";
            this.cmbCityName.Size = new System.Drawing.Size(162, 25);
            this.cmbCityName.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Arial", 9.75F);
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(625, 111);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 16);
            this.label8.TabIndex = 191;
            this.label8.Text = "City Name";
            // 
            // cmbStateName
            // 
            this.cmbStateName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbStateName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbStateName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbStateName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbStateName.FormattingEnabled = true;
            this.cmbStateName.Location = new System.Drawing.Point(394, 106);
            this.cmbStateName.Name = "cmbStateName";
            this.cmbStateName.Size = new System.Drawing.Size(190, 25);
            this.cmbStateName.TabIndex = 10;
            this.cmbStateName.SelectedIndexChanged += new System.EventHandler(this.cmbStateName_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Arial", 9.75F);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(309, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 16);
            this.label5.TabIndex = 189;
            this.label5.Text = "State Name";
            // 
            // cmbCountryName
            // 
            this.cmbCountryName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbCountryName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCountryName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbCountryName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCountryName.FormattingEnabled = true;
            this.cmbCountryName.Location = new System.Drawing.Point(110, 106);
            this.cmbCountryName.Name = "cmbCountryName";
            this.cmbCountryName.Size = new System.Drawing.Size(195, 25);
            this.cmbCountryName.TabIndex = 9;
            this.cmbCountryName.SelectedIndexChanged += new System.EventHandler(this.cmbCountryName_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Arial", 9.75F);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(8, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 16);
            this.label4.TabIndex = 187;
            this.label4.Text = "Country Name";
            // 
            // cmbDealerCode
            // 
            this.cmbDealerCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDealerCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbDealerCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.cmbDealerCode.FormattingEnabled = true;
            this.cmbDealerCode.Location = new System.Drawing.Point(1004, 76);
            this.cmbDealerCode.Name = "cmbDealerCode";
            this.cmbDealerCode.Size = new System.Drawing.Size(220, 25);
            this.cmbDealerCode.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(919, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 16);
            this.label3.TabIndex = 184;
            this.label3.Text = "Dealer Code";
            // 
            // cmbAMPM
            // 
            this.cmbAMPM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAMPM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbAMPM.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.cmbAMPM.FormattingEnabled = true;
            this.cmbAMPM.Items.AddRange(new object[] {
            "",
            "am",
            "pm"});
            this.cmbAMPM.Location = new System.Drawing.Point(850, 73);
            this.cmbAMPM.Name = "cmbAMPM";
            this.cmbAMPM.Size = new System.Drawing.Size(63, 25);
            this.cmbAMPM.TabIndex = 7;
            // 
            // cmbMin
            // 
            this.cmbMin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbMin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.cmbMin.FormattingEnabled = true;
            this.cmbMin.Items.AddRange(new object[] {
            "",
            "00",
            "30"});
            this.cmbMin.Location = new System.Drawing.Point(778, 73);
            this.cmbMin.Name = "cmbMin";
            this.cmbMin.Size = new System.Drawing.Size(72, 25);
            this.cmbMin.TabIndex = 6;
            // 
            // cmbHour
            // 
            this.cmbHour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHour.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbHour.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.cmbHour.FormattingEnabled = true;
            this.cmbHour.Items.AddRange(new object[] {
            "",
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12"});
            this.cmbHour.Location = new System.Drawing.Point(719, 73);
            this.cmbHour.Name = "cmbHour";
            this.cmbHour.Size = new System.Drawing.Size(59, 25);
            this.cmbHour.TabIndex = 5;
            // 
            // cmbStreamName
            // 
            this.cmbStreamName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStreamName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbStreamName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.cmbStreamName.FormattingEnabled = true;
            this.cmbStreamName.Location = new System.Drawing.Point(719, 37);
            this.cmbStreamName.Name = "cmbStreamName";
            this.cmbStreamName.Size = new System.Drawing.Size(505, 25);
            this.cmbStreamName.TabIndex = 2;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("Arial", 9.75F);
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(625, 41);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(88, 16);
            this.label15.TabIndex = 167;
            this.label15.Text = "Stream Name";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Font = new System.Drawing.Font("Arial", 9.75F);
            this.label17.ForeColor = System.Drawing.Color.White;
            this.label17.Location = new System.Drawing.Point(309, 74);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(62, 16);
            this.label17.TabIndex = 173;
            this.label17.Text = "End Date";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.BackColor = System.Drawing.Color.Transparent;
            this.label22.Font = new System.Drawing.Font("Arial", 9.75F);
            this.label22.ForeColor = System.Drawing.Color.White;
            this.label22.Location = new System.Drawing.Point(625, 75);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(36, 16);
            this.label22.TabIndex = 171;
            this.label22.Text = "Time";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Arial", 9.75F);
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(8, 77);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(67, 16);
            this.label13.TabIndex = 172;
            this.label13.Text = "Start Date";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.CustomFormat = "dd/MMM/yyyy";
            this.dtpEndDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndDate.Location = new System.Drawing.Point(394, 74);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(225, 23);
            this.dtpEndDate.TabIndex = 4;
            this.dtpEndDate.Value = new System.DateTime(2015, 1, 20, 0, 0, 0, 0);
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.CustomFormat = "dd/MMM/yyyy";
            this.dtpStartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartDate.Location = new System.Drawing.Point(110, 74);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(193, 23);
            this.dtpStartDate.TabIndex = 3;
            this.dtpStartDate.Value = new System.DateTime(2015, 1, 20, 0, 0, 0, 0);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label11.ForeColor = System.Drawing.Color.Yellow;
            this.label11.Location = new System.Drawing.Point(4, 5);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(141, 21);
            this.label11.TabIndex = 136;
            this.label11.Text = "Stream Scheduling";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.btnRefersh);
            this.panel3.Controls.Add(this.btnSave);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 147);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1264, 51);
            this.panel3.TabIndex = 1;
            // 
            // btnRefersh
            // 
            this.btnRefersh.BackColor = System.Drawing.Color.Transparent;
            this.btnRefersh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefersh.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnRefersh.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.btnRefersh.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.btnRefersh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefersh.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefersh.ForeColor = System.Drawing.Color.Yellow;
            this.btnRefersh.Location = new System.Drawing.Point(1129, 5);
            this.btnRefersh.Name = "btnRefersh";
            this.btnRefersh.Size = new System.Drawing.Size(95, 38);
            this.btnRefersh.TabIndex = 1;
            this.btnRefersh.Text = "Refersh";
            this.btnRefersh.UseVisualStyleBackColor = false;
            this.btnRefersh.Click += new System.EventHandler(this.btnRefersh_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.Yellow;
            this.btnSave.Location = new System.Drawing.Point(1028, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(95, 38);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.dgStream);
            this.panel2.Controls.Add(this.panel11);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 198);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1264, 426);
            this.panel2.TabIndex = 21;
            // 
            // dgStream
            // 
            this.dgStream.AllowUserToAddRows = false;
            this.dgStream.AllowUserToDeleteRows = false;
            this.dgStream.AllowUserToResizeColumns = false;
            this.dgStream.AllowUserToResizeRows = false;
            this.dgStream.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(51)))), ((int)(((byte)(45)))));
            this.dgStream.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgStream.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgStream.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgStream.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(162)))), ((int)(((byte)(175)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgStream.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgStream.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgStream.Location = new System.Drawing.Point(0, 40);
            this.dgStream.MultiSelect = false;
            this.dgStream.Name = "dgStream";
            this.dgStream.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(162)))), ((int)(((byte)(175)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgStream.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgStream.RowHeadersVisible = false;
            this.dgStream.RowTemplate.Height = 30;
            this.dgStream.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgStream.Size = new System.Drawing.Size(1262, 384);
            this.dgStream.TabIndex = 154;
            this.dgStream.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgStream_CellClick);
            // 
            // panel11
            // 
            this.panel11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel11.Controls.Add(this.cmbSearchDealercode);
            this.panel11.Controls.Add(this.dtpFromDate);
            this.panel11.Controls.Add(this.label21);
            this.panel11.Controls.Add(this.label2);
            this.panel11.Controls.Add(this.label12);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel11.Location = new System.Drawing.Point(0, 0);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(1262, 40);
            this.panel11.TabIndex = 153;
            // 
            // cmbSearchDealercode
            // 
            this.cmbSearchDealercode.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbSearchDealercode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.cmbSearchDealercode.FormattingEnabled = true;
            this.cmbSearchDealercode.Location = new System.Drawing.Point(420, 6);
            this.cmbSearchDealercode.Name = "cmbSearchDealercode";
            this.cmbSearchDealercode.Size = new System.Drawing.Size(219, 25);
            this.cmbSearchDealercode.TabIndex = 156;
            this.cmbSearchDealercode.SelectedIndexChanged += new System.EventHandler(this.cmbSearchDealercode_SelectedIndexChanged);
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.CustomFormat = "dd/MMM/yyyy";
            this.dtpFromDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromDate.Location = new System.Drawing.Point(120, 6);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(173, 23);
            this.dtpFromDate.TabIndex = 151;
            this.dtpFromDate.Value = new System.DateTime(2015, 1, 20, 0, 0, 0, 0);
            this.dtpFromDate.ValueChanged += new System.EventHandler(this.dtpFromDate_ValueChanged);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.BackColor = System.Drawing.Color.Transparent;
            this.label21.Font = new System.Drawing.Font("Arial", 9.75F);
            this.label21.ForeColor = System.Drawing.Color.White;
            this.label21.Location = new System.Drawing.Point(314, 8);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(79, 16);
            this.label21.TabIndex = 148;
            this.label21.Text = "Dealer Code";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 15);
            this.label2.TabIndex = 148;
            this.label2.Text = "Search";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Arial", 9.75F);
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(71, 8);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(35, 16);
            this.label12.TabIndex = 148;
            this.label12.Text = "Date";
            // 
            // panMainNew
            // 
            this.panMainNew.Controls.Add(this.panNew);
            this.panMainNew.Location = new System.Drawing.Point(396, 153);
            this.panMainNew.Name = "panMainNew";
            this.panMainNew.Size = new System.Drawing.Size(522, 40);
            this.panMainNew.TabIndex = 22;
            this.panMainNew.Visible = false;
            // 
            // panNew
            // 
            this.panNew.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panNew.Controls.Add(this.btnNewCancel);
            this.panNew.Controls.Add(this.btnSaveNew);
            this.panNew.Controls.Add(this.label6);
            this.panNew.Controls.Add(this.txtName);
            this.panNew.Controls.Add(this.lblCaption);
            this.panNew.Location = new System.Drawing.Point(426, 174);
            this.panNew.Name = "panNew";
            this.panNew.Size = new System.Drawing.Size(416, 228);
            this.panNew.TabIndex = 14;
            // 
            // btnNewCancel
            // 
            this.btnNewCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnNewCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNewCancel.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnNewCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.btnNewCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.btnNewCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewCancel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewCancel.ForeColor = System.Drawing.Color.Yellow;
            this.btnNewCancel.Location = new System.Drawing.Point(260, 111);
            this.btnNewCancel.Name = "btnNewCancel";
            this.btnNewCancel.Size = new System.Drawing.Size(95, 38);
            this.btnNewCancel.TabIndex = 106;
            this.btnNewCancel.Text = "Cancel";
            this.btnNewCancel.UseVisualStyleBackColor = false;
            this.btnNewCancel.Click += new System.EventHandler(this.btnNewCancel_Click);
            // 
            // btnSaveNew
            // 
            this.btnSaveNew.BackColor = System.Drawing.Color.Transparent;
            this.btnSaveNew.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSaveNew.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnSaveNew.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.btnSaveNew.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.btnSaveNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveNew.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveNew.ForeColor = System.Drawing.Color.Yellow;
            this.btnSaveNew.Location = new System.Drawing.Point(150, 111);
            this.btnSaveNew.Name = "btnSaveNew";
            this.btnSaveNew.Size = new System.Drawing.Size(95, 38);
            this.btnSaveNew.TabIndex = 105;
            this.btnSaveNew.Text = "Save";
            this.btnSaveNew.UseVisualStyleBackColor = false;
            this.btnSaveNew.Click += new System.EventHandler(this.btnSaveNew_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Arial", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(83, 76);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 19);
            this.label6.TabIndex = 104;
            this.label6.Text = "Name :";
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(148, 74);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(207, 23);
            this.txtName.TabIndex = 103;
            // 
            // lblCaption
            // 
            this.lblCaption.AutoSize = true;
            this.lblCaption.BackColor = System.Drawing.Color.Transparent;
            this.lblCaption.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaption.ForeColor = System.Drawing.Color.Yellow;
            this.lblCaption.Location = new System.Drawing.Point(3, 8);
            this.lblCaption.Name = "lblCaption";
            this.lblCaption.Size = new System.Drawing.Size(164, 21);
            this.lblCaption.TabIndex = 102;
            this.lblCaption.Text = "Dealer Registration";
            // 
            // frmStreamShedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(51)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(1264, 624);
            this.Controls.Add(this.panMainNew);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmStreamShedule";
            this.Text = "Stream Scheduling";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgStream)).EndInit();
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            this.panMainNew.ResumeLayout(false);
            this.panNew.ResumeLayout(false);
            this.panNew.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnStateNew;
        private System.Windows.Forms.ComboBox cmbCityName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbStateName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbCountryName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbDealerCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbStreamName;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnRefersh;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgStream;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.ComboBox cmbSearchDealercode;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel panMainNew;
        private System.Windows.Forms.Panel panNew;
        private System.Windows.Forms.Button btnNewCancel;
        private System.Windows.Forms.Button btnSaveNew;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblCaption;
        private System.Windows.Forms.Button btnCityNew;
        private System.Windows.Forms.ComboBox cmbAMPM;
        private System.Windows.Forms.ComboBox cmbMin;
        private System.Windows.Forms.ComboBox cmbHour;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.ComboBox cmbAdminCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbTitleCategory;
        private System.Windows.Forms.Label label7;
    }
}