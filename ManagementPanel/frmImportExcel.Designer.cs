namespace ManagementPanel
{
    partial class frmImportExcel
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmImportExcel));
            this.btnStart = new System.Windows.Forms.Button();
            this.panControls = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.picBrowseSave = new System.Windows.Forms.PictureBox();
            this.picBrowseMp3 = new System.Windows.Forms.PictureBox();
            this.txtSavePath = new System.Windows.Forms.TextBox();
            this.txtMp3Path = new System.Windows.Forms.TextBox();
            this.picBrowse = new System.Windows.Forms.PictureBox();
            this.txtExcelFilePath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pBar = new System.Windows.Forms.ProgressBar();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgExcel = new System.Windows.Forms.DataGridView();
            this.ofdExcel = new System.Windows.Forms.OpenFileDialog();
            this.bgWorker = new System.ComponentModel.BackgroundWorker();
            this.bgWorkerStep2 = new System.ComponentModel.BackgroundWorker();
            this.panPopUp = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblPercentage = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.rdoVideo = new System.Windows.Forms.RadioButton();
            this.rdoAudio = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.panControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBrowseSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBrowseMp3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBrowse)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgExcel)).BeginInit();
            this.panPopUp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.Transparent;
            this.btnStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStart.FlatAppearance.MouseDownBackColor = System.Drawing.Color.PowderBlue;
            this.btnStart.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.ForeColor = System.Drawing.Color.White;
            this.btnStart.Location = new System.Drawing.Point(881, 38);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(69, 32);
            this.btnStart.TabIndex = 10;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // panControls
            // 
            this.panControls.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panControls.Controls.Add(this.label3);
            this.panControls.Controls.Add(this.rdoVideo);
            this.panControls.Controls.Add(this.rdoAudio);
            this.panControls.Controls.Add(this.btnExit);
            this.panControls.Controls.Add(this.btnCancel);
            this.panControls.Controls.Add(this.picBrowseSave);
            this.panControls.Controls.Add(this.picBrowseMp3);
            this.panControls.Controls.Add(this.txtSavePath);
            this.panControls.Controls.Add(this.txtMp3Path);
            this.panControls.Controls.Add(this.picBrowse);
            this.panControls.Controls.Add(this.btnStart);
            this.panControls.Controls.Add(this.txtExcelFilePath);
            this.panControls.Controls.Add(this.label2);
            this.panControls.Controls.Add(this.label1);
            this.panControls.Controls.Add(this.label5);
            this.panControls.Dock = System.Windows.Forms.DockStyle.Top;
            this.panControls.Location = new System.Drawing.Point(0, 0);
            this.panControls.Name = "panControls";
            this.panControls.Size = new System.Drawing.Size(1184, 83);
            this.panControls.TabIndex = 11;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.PowderBlue;
            this.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(1031, 38);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(69, 32);
            this.btnExit.TabIndex = 37;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Visible = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.PowderBlue;
            this.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(956, 38);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(69, 32);
            this.btnCancel.TabIndex = 37;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // picBrowseSave
            // 
            this.picBrowseSave.BackgroundImage = global::ManagementPanel.Properties.Resources.grid_enable;
            this.picBrowseSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picBrowseSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picBrowseSave.Location = new System.Drawing.Point(1076, 9);
            this.picBrowseSave.Name = "picBrowseSave";
            this.picBrowseSave.Size = new System.Drawing.Size(24, 22);
            this.picBrowseSave.TabIndex = 36;
            this.picBrowseSave.TabStop = false;
            this.picBrowseSave.Click += new System.EventHandler(this.picBrowseSave_Click);
            // 
            // picBrowseMp3
            // 
            this.picBrowseMp3.BackgroundImage = global::ManagementPanel.Properties.Resources.grid_enable;
            this.picBrowseMp3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picBrowseMp3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picBrowseMp3.Location = new System.Drawing.Point(711, 9);
            this.picBrowseMp3.Name = "picBrowseMp3";
            this.picBrowseMp3.Size = new System.Drawing.Size(24, 22);
            this.picBrowseMp3.TabIndex = 36;
            this.picBrowseMp3.TabStop = false;
            this.picBrowseMp3.Click += new System.EventHandler(this.picBrowseMp3_Click);
            // 
            // txtSavePath
            // 
            this.txtSavePath.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSavePath.Location = new System.Drawing.Point(852, 9);
            this.txtSavePath.Name = "txtSavePath";
            this.txtSavePath.ReadOnly = true;
            this.txtSavePath.Size = new System.Drawing.Size(220, 23);
            this.txtSavePath.TabIndex = 35;
            // 
            // txtMp3Path
            // 
            this.txtMp3Path.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMp3Path.Location = new System.Drawing.Point(452, 9);
            this.txtMp3Path.Name = "txtMp3Path";
            this.txtMp3Path.ReadOnly = true;
            this.txtMp3Path.Size = new System.Drawing.Size(256, 23);
            this.txtMp3Path.TabIndex = 34;
            // 
            // picBrowse
            // 
            this.picBrowse.BackgroundImage = global::ManagementPanel.Properties.Resources.grid_enable;
            this.picBrowse.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picBrowse.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picBrowse.Location = new System.Drawing.Point(340, 10);
            this.picBrowse.Name = "picBrowse";
            this.picBrowse.Size = new System.Drawing.Size(24, 22);
            this.picBrowse.TabIndex = 32;
            this.picBrowse.TabStop = false;
            this.picBrowse.Click += new System.EventHandler(this.picBrowse_Click);
            // 
            // txtExcelFilePath
            // 
            this.txtExcelFilePath.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtExcelFilePath.Location = new System.Drawing.Point(117, 9);
            this.txtExcelFilePath.Name = "txtExcelFilePath";
            this.txtExcelFilePath.ReadOnly = true;
            this.txtExcelFilePath.Size = new System.Drawing.Size(220, 23);
            this.txtExcelFilePath.TabIndex = 30;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(744, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 19);
            this.label2.TabIndex = 15;
            this.label2.Text = "Song Save Path";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(374, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 19);
            this.label1.TabIndex = 15;
            this.label1.Text = "Song Path";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(3, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 19);
            this.label5.TabIndex = 15;
            this.label5.Text = "Excel Sheet Path";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pBar
            // 
            this.pBar.ForeColor = System.Drawing.Color.LightCyan;
            this.pBar.Location = new System.Drawing.Point(-2, 144);
            this.pBar.Name = "pBar";
            this.pBar.Size = new System.Drawing.Size(516, 23);
            this.pBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pBar.TabIndex = 33;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgExcel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 83);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1184, 379);
            this.panel2.TabIndex = 12;
            // 
            // dgExcel
            // 
            this.dgExcel.AllowUserToAddRows = false;
            this.dgExcel.AllowUserToDeleteRows = false;
            this.dgExcel.AllowUserToResizeColumns = false;
            this.dgExcel.AllowUserToResizeRows = false;
            this.dgExcel.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(51)))), ((int)(((byte)(45)))));
            this.dgExcel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgExcel.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgExcel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(162)))), ((int)(((byte)(175)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgExcel.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgExcel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgExcel.Location = new System.Drawing.Point(0, 0);
            this.dgExcel.MultiSelect = false;
            this.dgExcel.Name = "dgExcel";
            this.dgExcel.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(162)))), ((int)(((byte)(175)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgExcel.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgExcel.RowHeadersVisible = false;
            this.dgExcel.RowTemplate.Height = 30;
            this.dgExcel.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgExcel.Size = new System.Drawing.Size(1184, 379);
            this.dgExcel.TabIndex = 3;
            // 
            // bgWorker
            // 
            this.bgWorker.WorkerReportsProgress = true;
            this.bgWorker.WorkerSupportsCancellation = true;
            this.bgWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorker_DoWork);
            this.bgWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgWorker_ProgressChanged);
            this.bgWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorker_RunWorkerCompleted);
            // 
            // bgWorkerStep2
            // 
            this.bgWorkerStep2.WorkerReportsProgress = true;
            this.bgWorkerStep2.WorkerSupportsCancellation = true;
            this.bgWorkerStep2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorkerStep2_DoWork);
            this.bgWorkerStep2.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgWorkerStep2_ProgressChanged);
            this.bgWorkerStep2.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorkerStep2_RunWorkerCompleted);
            // 
            // panPopUp
            // 
            this.panPopUp.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panPopUp.Controls.Add(this.pictureBox1);
            this.panPopUp.Controls.Add(this.lblPercentage);
            this.panPopUp.Controls.Add(this.lblName);
            this.panPopUp.Controls.Add(this.pBar);
            this.panPopUp.Location = new System.Drawing.Point(308, 131);
            this.panPopUp.Name = "panPopUp";
            this.panPopUp.Size = new System.Drawing.Size(517, 278);
            this.panPopUp.TabIndex = 13;
            this.panPopUp.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(206, 17);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 96);
            this.pictureBox1.TabIndex = 34;
            this.pictureBox1.TabStop = false;
            // 
            // lblPercentage
            // 
            this.lblPercentage.BackColor = System.Drawing.Color.Transparent;
            this.lblPercentage.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblPercentage.ForeColor = System.Drawing.Color.White;
            this.lblPercentage.Location = new System.Drawing.Point(384, 123);
            this.lblPercentage.Name = "lblPercentage";
            this.lblPercentage.Size = new System.Drawing.Size(126, 19);
            this.lblPercentage.TabIndex = 16;
            this.lblPercentage.Text = "Data Importing";
            this.lblPercentage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.BackColor = System.Drawing.Color.Transparent;
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblName.ForeColor = System.Drawing.Color.White;
            this.lblName.Location = new System.Drawing.Point(3, 122);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(103, 19);
            this.lblName.TabIndex = 16;
            this.lblName.Text = "Data Importing";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rdoVideo
            // 
            this.rdoVideo.AutoSize = true;
            this.rdoVideo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.rdoVideo.ForeColor = System.Drawing.Color.Yellow;
            this.rdoVideo.Location = new System.Drawing.Point(195, 38);
            this.rdoVideo.Name = "rdoVideo";
            this.rdoVideo.Size = new System.Drawing.Size(62, 23);
            this.rdoVideo.TabIndex = 39;
            this.rdoVideo.Text = "Video";
            this.rdoVideo.UseVisualStyleBackColor = true;
            // 
            // rdoAudio
            // 
            this.rdoAudio.AutoSize = true;
            this.rdoAudio.Checked = true;
            this.rdoAudio.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.rdoAudio.ForeColor = System.Drawing.Color.Yellow;
            this.rdoAudio.Location = new System.Drawing.Point(117, 38);
            this.rdoAudio.Name = "rdoAudio";
            this.rdoAudio.Size = new System.Drawing.Size(63, 23);
            this.rdoAudio.TabIndex = 38;
            this.rdoAudio.Text = "Audio";
            this.rdoAudio.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(3, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 19);
            this.label3.TabIndex = 40;
            this.label3.Text = "Media Type";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmImportExcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(51)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(1184, 462);
            this.Controls.Add(this.panPopUp);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panControls);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmImportExcel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Direct Upload";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmImportExcel_Load);
            this.SizeChanged += new System.EventHandler(this.frmImportExcel_SizeChanged);
            this.panControls.ResumeLayout(false);
            this.panControls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBrowseSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBrowseMp3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBrowse)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgExcel)).EndInit();
            this.panPopUp.ResumeLayout(false);
            this.panPopUp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Panel panControls;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtExcelFilePath;
        private System.Windows.Forms.PictureBox picBrowse;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.OpenFileDialog ofdExcel;
        private System.Windows.Forms.DataGridView dgExcel;
        private System.ComponentModel.BackgroundWorker bgWorker;
        private System.Windows.Forms.ProgressBar pBar;
        private System.Windows.Forms.TextBox txtSavePath;
        private System.Windows.Forms.TextBox txtMp3Path;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox picBrowseSave;
        private System.Windows.Forms.PictureBox picBrowseMp3;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnExit;
        private System.ComponentModel.BackgroundWorker bgWorkerStep2;
        private System.Windows.Forms.Panel panPopUp;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblPercentage;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rdoVideo;
        private System.Windows.Forms.RadioButton rdoAudio;
    }
}