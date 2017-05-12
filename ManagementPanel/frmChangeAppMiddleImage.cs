using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace ManagementPanel
{
    public partial class frmChangeAppMiddleImage : Form
    {
        gblClass objMainClass = new gblClass();
        public frmChangeAppMiddleImage()
        {
            InitializeComponent();
            DataTable dtDetail = new DataTable();
            string str = "Select * from  tblMiddleImage_App";
            dtDetail = objMainClass.fnFillDataTable(str);
            picImage.ImageLocation = dtDetail.Rows[0]["imgPath"].ToString();
        }

        private void btnImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenDialog = new OpenFileDialog();
            OpenDialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg;  *.png";
            DialogResult res = OpenDialog.ShowDialog();
            if (res == DialogResult.OK)
            {
                picImage.Image = Image.FromFile(OpenDialog.FileName);
                lblPath.Text = OpenDialog.FileName;
            }
        }

        private void btnUploadImage_Click(object sender, EventArgs e)
        {
            if (lblPath.Text == "")
            {
                MessageBox.Show("Please browse your image", "Management Panel");
                btnImage.Focus();
                return;
            }
            btnUploadImage.Enabled = false;
            bgMiddleImage.RunWorkerAsync();
        }

        private void bgMiddleImage_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                string filename = lblPath.Text;
                FileInfo objFile = new FileInfo(filename);
                string ftpServerIP = "ftp://85.195.82.94:21/AMMusicFiles/ripper/AppMiddlePic/1" + objFile.Extension;
                string ftpUserName = "harish";
                string ftpPassword = "Mohali123";
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(new Uri(ftpServerIP));
                request.Method = WebRequestMethods.Ftp.UploadFile;
                request.Credentials = new NetworkCredential(ftpUserName, ftpPassword);
                request.UseBinary = true;
                request.UsePassive = false;
                byte[] fileStream = System.IO.File.ReadAllBytes(filename);
                System.IO.Stream requestStream = request.GetRequestStream();
                for (int offset = 0; offset <= fileStream.Length; offset += 1024)
                {
                    bgMiddleImage.ReportProgress(Convert.ToInt32(offset * pBarImage.Maximum / fileStream.Length));
                    int chSize = fileStream.Length - offset;
                    if (chSize > 1024)
                        chSize = 1024;
                    requestStream.Write(fileStream, offset, chSize);
                }
                requestStream.Close();
                requestStream.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

                return;
            }
        }

        private void bgMiddleImage_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pBarImage.Value = e.ProgressPercentage;
            lblPer.Text = e.ProgressPercentage + "%";
        }

        private void bgMiddleImage_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            GC.Collect();
            FileInfo objFile = new FileInfo(lblPath.Text);

            if (StaticClass.constr.State == ConnectionState.Open) StaticClass.constr.Close();
            StaticClass.constr.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = StaticClass.constr;
            cmd.CommandText = "delete from  tblMiddleImage_App";
            cmd.ExecuteNonQuery();
            StaticClass.constr.Close();

            if (StaticClass.constr.State == ConnectionState.Open) StaticClass.constr.Close();
            StaticClass.constr.Open();
            cmd = new SqlCommand();
            cmd.Connection = StaticClass.constr;
            cmd.CommandText = "insert into tblMiddleImage_App(imgPath) values('http://85.195.82.94/AppMiddlePic/1" + objFile.Extension + "' )";
            cmd.ExecuteNonQuery();
            StaticClass.constr.Close();

            lblPer.Text = "";
            pBarImage.Value = 0;
            lblPath.Text = "";
            btnUploadImage.Enabled = true;
        }

        private void frmChangeAppMiddleImage_Load(object sender, EventArgs e)
        {

        }
    }
}
