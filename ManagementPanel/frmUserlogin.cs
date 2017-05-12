using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using System.Net.Mail;
using System.Data.SqlClient;
using System.IO;

namespace ManagementPanel
{
    public partial class frmUserlogin : Form
    {
        gblClass ObjMainClass = new gblClass();
        
        Int32 User_id = 0;
        Int32 OnlineUserId = 0;
        Int32 MainClientId = 0;
        Int32 OldMainClientId = 0;
        string SubmitValidate="";
        string Matter = "";
        public frmUserlogin()
        {
            InitializeComponent();
            CheckIfRememberedUser();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmUserlogin_FormClosing(object sender, FormClosingEventArgs e)
        {
          
           Application.Exit();
        }
        private void CheckIfRememberedUser()
        {
            if (Properties.Settings.Default.RememberMeUsername != null && Properties.Settings.Default.RememberMeUsername != "")
            {
                txtloginUserName.Text = Properties.Settings.Default.RememberMeUsername;
                txtLoginPassword.Text = Properties.Settings.Default.RememberMePassword;
                chkRemember.Checked = true;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //if (ObjMainClass.CheckForInternetConnection() == false)
            //{
            //    MessageBox.Show("Please check your Internet connection.", "Management Panel");
            //    return;
            //}
            SubmitValidation();
            if (SubmitValidate == "True")
            {
                GetDataFromWebsite();
            }
        }
        private void GetDataFromWebsite()
        {
            
                if (chkRemember.Checked == true)
                {
                    Properties.Settings.Default.RememberMeUsername = txtloginUserName.Text;
                    Properties.Settings.Default.RememberMePassword = txtLoginPassword.Text;
                    Properties.Settings.Default.Save();
                }
                else
                {
                    Properties.Settings.Default.RememberMeUsername = "";
                    Properties.Settings.Default.RememberMePassword = "";
                    Properties.Settings.Default.Save();
                }
                //MusicPlayerTokenAdministrator objMainWindow = new MusicPlayerTokenAdministrator();
                //objMainWindow.Show();
                //panOnline.Visible = false;
                frmMain objMainWindow = new frmMain();
                objMainWindow.Show();
                this.Hide(); 
            
            
           

        }




        public void SubmitValidation()
        {
            try
            {
                string str = "";
                str = "select * from tbdealerlogin where loginname='" + txtloginUserName.Text + "' and Loginpassword='" + txtLoginPassword.Text + "'";
                DataSet ds = new DataSet();
                ds = ObjMainClass.fnFillDataSet(str);
                if (txtloginUserName.Text == "")
                {
                    MessageBox.Show("The login user name cannot be empty", "Manageyourclaudio");
                    SubmitValidate = "False";
                }
                else if (txtLoginPassword.Text == "")
                {
                    MessageBox.Show("Login password cannot be blank", "Manageyourclaudio");
                    SubmitValidate = "False";
                }
                else if (ds.Tables[0].Rows.Count <= 0)
                {
                    MessageBox.Show("Login user/password is wrong", "Manageyourclaudio");
                    SubmitValidate = "False";
                }
                else if (ds.Tables[0].Rows.Count > 0)
                {
                    SubmitValidate = "True";
                }
            }
            catch (Exception ex) { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int[] a = new int[] { 10, 20, 100, 100, 100, 10, 30, 20, 40, 50, 12, 14 };
            var query = from d in a
                        group d by d into da
                        select da;
            foreach (var i in query.Select((ab, bc) => ab).Where((ab, bc) => ab.Count() != 1))
                txtloginUserName.Text = txtloginUserName.Text + ',' + i.Key;
            //MessageBox.Show(Enum.GetName(typeof(DayOfWeek), Convert.ToInt32(txtloginUserName.Text)).Substring(0,3).ToString());

            //try
            //{
            //    var fromAddress = "support@freejobsnews.com";
            //    var toAddress = "talwinder.parastechnologies@gmail.com";
            //    const string fromPassword = "Siyainfotech@123";
            //    string subject = "Welcome";
            //    string body = "Hello \n";
            //    body += "You are regsiter with manageyourclaudio \n";
            //    body += "\n";
            //    body += "Team\n";
            //    body += "Manageyourclaudio";
            //    var smtp = new System.Net.Mail.SmtpClient();
            //    {
            //        smtp.Host = "40.78.157.193";
            //        smtp.Port = 26;
            //        smtp.EnableSsl = false;
            //        smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            //        smtp.Credentials = new NetworkCredential(fromAddress, fromPassword);
            //        smtp.Timeout = 999999999;
            //    }
            //    smtp.Send(fromAddress, toAddress, subject, body);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }



        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            Stream streamRemote = null;
            Stream streamLocal = null;

            String RemoteFtpPath = "http://146.0.229.66/oggfiles/1.ogg";
            String LocalDestinationPath = Application.StartupPath + "\\1.ogg";
            try
            {

                string sUrlToReadFileFrom = RemoteFtpPath;
                string sFilePathToWriteFileTo = LocalDestinationPath;
                Uri url = new Uri(sUrlToReadFileFrom);
                request = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(url);
                response = (System.Net.HttpWebResponse)request.GetResponse();
                response.Close();
                Int64 iSize = response.ContentLength;
                Int64 iRunningByteTotal = 0;
                using (System.Net.WebClient client = new System.Net.WebClient())
                {
                    using (streamRemote = client.OpenRead(new Uri(sUrlToReadFileFrom)))
                    {
                        using (streamLocal = new FileStream(sFilePathToWriteFileTo, FileMode.Create, FileAccess.Write, FileShare.None))
                        {
                            int iByteSize = 0;
                            byte[] byteBuffer = new byte[iSize];
                            while ((iByteSize = streamRemote.Read(byteBuffer, 0, byteBuffer.Length)) > 0)
                            {
                                streamLocal.Write(byteBuffer, 0, iByteSize);
                                iRunningByteTotal += iByteSize;
                                double dIndex = (double)(iRunningByteTotal);
                                double dTotal = (double)byteBuffer.Length;
                                double dProgressPercentage = (dIndex / dTotal);
                                int iProgressPercentage = (int)(dProgressPercentage * 100);
                                backgroundWorker1.ReportProgress(iProgressPercentage);
                            }
                            streamLocal.Close();
                        }
                        streamRemote.Close();
                    }
                }

            }
            catch (Exception  ex)
            {
                



                if (backgroundWorker1.IsBusy == true)
                {
                    streamLocal = null;
                    streamRemote = null;
                    request = null;
                    response = null;

                    backgroundWorker1.CancelAsync();
                    if (backgroundWorker1.CancellationPending == true)
                    {
                        e.Cancel = true;
                    }
                }
                return;
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
             //pBarOnline.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            GC.Collect();
        }

        private void frmUserlogin_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.Eufory;
        }

        
    

        
       
 
    }
}
