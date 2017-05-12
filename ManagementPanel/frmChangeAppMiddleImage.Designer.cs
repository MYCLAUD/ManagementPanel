﻿namespace ManagementPanel
{
    partial class frmChangeAppMiddleImage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChangeAppMiddleImage));
            this.lblPath = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.lblPer = new System.Windows.Forms.Label();
            this.pBarImage = new System.Windows.Forms.ProgressBar();
            this.btnImage = new System.Windows.Forms.Button();
            this.picImage = new System.Windows.Forms.PictureBox();
            this.btnUploadImage = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.bgMiddleImage = new System.ComponentModel.BackgroundWorker();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPath
            // 
            this.lblPath.AutoSize = true;
            this.lblPath.BackColor = System.Drawing.Color.Transparent;
            this.lblPath.Font = new System.Drawing.Font("Arial", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPath.ForeColor = System.Drawing.Color.White;
            this.lblPath.Location = new System.Drawing.Point(540, 228);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(0, 19);
            this.lblPath.TabIndex = 184;
            this.lblPath.Visible = false;
            // 
            // panel7
            // 
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Controls.Add(this.lblPer);
            this.panel7.Controls.Add(this.pBarImage);
            this.panel7.Controls.Add(this.btnImage);
            this.panel7.Controls.Add(this.picImage);
            this.panel7.Location = new System.Drawing.Point(12, 38);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(443, 242);
            this.panel7.TabIndex = 183;
            // 
            // lblPer
            // 
            this.lblPer.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblPer.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPer.ForeColor = System.Drawing.Color.White;
            this.lblPer.Location = new System.Drawing.Point(389, 220);
            this.lblPer.Name = "lblPer";
            this.lblPer.Size = new System.Drawing.Size(52, 20);
            this.lblPer.TabIndex = 180;
            this.lblPer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pBarImage
            // 
            this.pBarImage.Dock = System.Windows.Forms.DockStyle.Left;
            this.pBarImage.ForeColor = System.Drawing.Color.Yellow;
            this.pBarImage.Location = new System.Drawing.Point(0, 220);
            this.pBarImage.Name = "pBarImage";
            this.pBarImage.Size = new System.Drawing.Size(383, 20);
            this.pBarImage.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pBarImage.TabIndex = 179;
            // 
            // btnImage
            // 
            this.btnImage.BackColor = System.Drawing.Color.Transparent;
            this.btnImage.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImage.BackgroundImage")));
            this.btnImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImage.FlatAppearance.MouseDownBackColor = System.Drawing.Color.PowderBlue;
            this.btnImage.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
            this.btnImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImage.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(117)))), ((int)(((byte)(188)))));
            this.btnImage.Location = new System.Drawing.Point(406, 189);
            this.btnImage.Name = "btnImage";
            this.btnImage.Size = new System.Drawing.Size(29, 25);
            this.btnImage.TabIndex = 178;
            this.btnImage.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnImage.UseVisualStyleBackColor = false;
            this.btnImage.Click += new System.EventHandler(this.btnImage_Click);
            // 
            // picImage
            // 
            this.picImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picImage.Dock = System.Windows.Forms.DockStyle.Top;
            this.picImage.Location = new System.Drawing.Point(0, 0);
            this.picImage.Name = "picImage";
            this.picImage.Size = new System.Drawing.Size(441, 220);
            this.picImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picImage.TabIndex = 0;
            this.picImage.TabStop = false;
            // 
            // btnUploadImage
            // 
            this.btnUploadImage.BackColor = System.Drawing.Color.Transparent;
            this.btnUploadImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUploadImage.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnUploadImage.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.btnUploadImage.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.btnUploadImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUploadImage.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUploadImage.ForeColor = System.Drawing.Color.Yellow;
            this.btnUploadImage.Location = new System.Drawing.Point(360, 286);
            this.btnUploadImage.Name = "btnUploadImage";
            this.btnUploadImage.Size = new System.Drawing.Size(95, 38);
            this.btnUploadImage.TabIndex = 182;
            this.btnUploadImage.Text = "Upload";
            this.btnUploadImage.UseVisualStyleBackColor = false;
            this.btnUploadImage.Click += new System.EventHandler(this.btnUploadImage_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label11.ForeColor = System.Drawing.Color.Yellow;
            this.label11.Location = new System.Drawing.Point(9, 11);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(162, 21);
            this.label11.TabIndex = 181;
            this.label11.Text = "Change Middle Image";
            // 
            // bgMiddleImage
            // 
            this.bgMiddleImage.WorkerReportsProgress = true;
            this.bgMiddleImage.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgMiddleImage_DoWork);
            this.bgMiddleImage.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgMiddleImage_ProgressChanged);
            this.bgMiddleImage.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgMiddleImage_RunWorkerCompleted);
            // 
            // frmChangeAppMiddleImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(51)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(1264, 486);
            this.Controls.Add(this.lblPath);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.btnUploadImage);
            this.Controls.Add(this.label11);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmChangeAppMiddleImage";
            this.Text = "frmChangeAppMiddleImage";
            this.Load += new System.EventHandler(this.frmChangeAppMiddleImage_Load);
            this.panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPath;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label lblPer;
        private System.Windows.Forms.ProgressBar pBarImage;
        private System.Windows.Forms.Button btnImage;
        private System.Windows.Forms.PictureBox picImage;
        private System.Windows.Forms.Button btnUploadImage;
        private System.Windows.Forms.Label label11;
        private System.ComponentModel.BackgroundWorker bgMiddleImage;
    }
}