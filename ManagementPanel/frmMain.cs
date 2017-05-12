using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.IO;
namespace ManagementPanel
{
    public partial class frmMain : Form
    {
        Type FormType;
        Form ObjFormName;
        gblClass objMainClass = new gblClass();
        string CopyleftFileLocation = "";
        string CopyrightFileLocation = "";
        public frmMain()
        {
            InitializeComponent();
        }
        private void btnShow_Click(object sender, EventArgs e)
        {
            if (cmbMusicType.Text == "")
            {
                MessageBox.Show("Please select a subscription Type", "Tokan Administrator");
                cmbMusicType.Focus();
                return;
            }
            if (cmbPlayerType.Text == "")
            {
                MessageBox.Show("Please select a player type", "Tokan Administrator");
                cmbPlayerType.Focus();
                return;
            }

            if (cmbPlayerType.Text == "Desktop")
            {
                #region "Desktop Forms"
                if (cmbMusicType.Text == "Copyright")
                {
                    if (lblOpenType.Text == "Token")
                    {
                        sprOpenForm(Application.ProductName + ".frmTokenGeneration");
                    }
                    else if (lblOpenType.Text == "Settings")
                    {
                        sprOpenForm(Application.ProductName + ".frmCopyrightTokenSettings");
                    }
                    else if (lblOpenType.Text == "Advt")
                    {
                        gblClass.MusicType = cmbMusicType.Text;
                        //sprOpenForm(Application.ProductName + ".frmAdvertisementDetail");
                        frmAdvertisementDetail frm = new frmAdvertisementDetail();
                        frm.MdiParent = this;
                        frm.Show();
                        frm.Dock = DockStyle.Fill;
                    }
                    else if (lblOpenType.Text == "TokenDetail")
                    {
                        gblClass.MusicType = cmbMusicType.Text;
                        sprOpenForm(Application.ProductName + ".frmTokenDetail");

                    }
                    else if (lblOpenType.Text == "TokenExpiry")
                    {
                        gblClass.MusicType = cmbMusicType.Text;
                        //sprOpenForm(Application.ProductName + ".frmTokenExpiryReport");
                        frmTokenExpiryReport frm = new frmTokenExpiryReport();
                        frm.MdiParent = this;
                        frm.Show();
                        frm.Dock = DockStyle.Fill;
                    }

                }



                else if (cmbMusicType.Text == "Sanjivani")
                {
                    if (lblOpenType.Text == "Token")
                    {
                        sprOpenForm(Application.ProductName + ".frmSanjivaniTokenGeneration");
                    }
                    else if (lblOpenType.Text == "Settings")
                    {
                       // sprOpenForm(Application.ProductName + ".frmCopyleftTokenSettingsAsian");
                    }
                    else if (lblOpenType.Text == "Advt")
                    {
                        gblClass.MusicType = cmbMusicType.Text;
                         
                        frmAdvertisementDetail frm = new frmAdvertisementDetail();
                        frm.MdiParent = this;
                        frm.Show();
                        frm.Dock = DockStyle.Fill;
                    }
                    else if (lblOpenType.Text == "TokenDetail")
                    {
                    //    gblClass.MusicType = cmbMusicType.Text;
                      //  sprOpenForm(Application.ProductName + ".frmTokenDetail");
                    }
                    else if (lblOpenType.Text == "TokenExpiry")
                    {
                       // gblClass.MusicType = cmbMusicType.Text;
                        
                     //   frmTokenExpiryReport frm = new frmTokenExpiryReport();
                    //   frm.MdiParent = this;
                    //    frm.Show();
                   //     frm.Dock = DockStyle.Fill;
                    }
                }
                else if (cmbMusicType.Text == "Copyleft")
                {
                    if (lblOpenType.Text == "Token")
                    {
                        sprOpenForm(Application.ProductName + ".frmCopyleftTokenGeneration");
                    }
                    else if (lblOpenType.Text == "Settings")
                    {
                        sprOpenForm(Application.ProductName + ".frmCopyleftTokenSettings");
                    }
                    else if (lblOpenType.Text == "Advt")
                    {
                        gblClass.MusicType = "Dam";
                        //sprOpenForm(Application.ProductName + ".frmAdvertisementDetail"); 
                        frmAdvertisementDetail frm = new frmAdvertisementDetail();
                        frm.MdiParent = this;
                        frm.Show();
                        frm.Dock = DockStyle.Fill;
                    }
                    else if (lblOpenType.Text == "TokenDetail")
                    {
                        gblClass.MusicType = "Dam";
                        sprOpenForm(Application.ProductName + ".frmTokenDetail");
                    }
                    else if (lblOpenType.Text == "TokenExpiry")
                    {
                        gblClass.MusicType = "Dam";
                        //sprOpenForm(Application.ProductName + ".frmTokenExpiryReport"); 
                        frmTokenExpiryReport frm = new frmTokenExpiryReport();
                        frm.MdiParent = this;
                        frm.Show();
                        frm.Dock = DockStyle.Fill;
                    }
                }
                else if (cmbMusicType.Text == "Asian")
                {
                    if (lblOpenType.Text == "Token")
                    {
                        sprOpenForm(Application.ProductName + ".frmAsianTokenGeneration");
                    }
                    else if (lblOpenType.Text == "Settings")
                    {
                        sprOpenForm(Application.ProductName + ".frmAsianTokenSettings");
                    }
                    else if (lblOpenType.Text == "Advt")
                    {
                        gblClass.MusicType = cmbMusicType.Text;
                        //sprOpenForm(Application.ProductName + ".frmAdvertisementDetail");
                        frmAdvertisementDetail frm = new frmAdvertisementDetail();
                        frm.MdiParent = this;
                        frm.Show();
                        frm.Dock = DockStyle.Fill;
                    }
                    else if (lblOpenType.Text == "TokenDetail")
                    {
                        gblClass.MusicType = cmbMusicType.Text;
                        sprOpenForm(Application.ProductName + ".frmTokenDetail");

                    }
                    else if (lblOpenType.Text == "TokenExpiry")
                    {
                        gblClass.MusicType = cmbMusicType.Text;
                        //sprOpenForm(Application.ProductName + ".frmTokenExpiryReport");
                        frmTokenExpiryReport frm = new frmTokenExpiryReport();
                        frm.MdiParent = this;
                        frm.Show();
                        frm.Dock = DockStyle.Fill;
                    }

                }
                #endregion
            }
            if (cmbPlayerType.Text == "Android")
            {
                if (cmbMusicType.Text != "Copyleft")
                {
                    MessageBox.Show("Music is not available for " + cmbMusicType.Text + "", "Tokan Administrator");
                    cmbMusicType.Focus();
                    return;
                }
                #region "Android Forms"
                if (cmbMusicType.Text == "Copyleft")
                {
                    if (lblOpenType.Text == "Token")
                    {
                        sprOpenForm(Application.ProductName + ".frmCopyleftTokenGeneration_Android");
                    }
                    else if (lblOpenType.Text == "Settings")
                    {
                        sprOpenForm(Application.ProductName + ".frmCopyleftTokenSettings_Android");
                    }
                    else if (lblOpenType.Text == "Advt")
                    {
                        return;
                    }
                    else if (lblOpenType.Text == "TokenDetail")
                    {
                        return;
                    }
                    else if (lblOpenType.Text == "TokenExpiry")
                    {
                        return;
                    }
                }
                #endregion
            }
            if (cmbPlayerType.Text == "iPhone")
            {
                if (cmbMusicType.Text != "Copyleft")
                {
                    MessageBox.Show("Music is not available for " + cmbMusicType.Text + "", "Tokan Administrator");
                    cmbMusicType.Focus();
                    return;
                }
                #region "iPhone Forms"
                if (cmbMusicType.Text == "Copyleft")
                {
                    if (lblOpenType.Text == "Token")
                    {
                        sprOpenForm(Application.ProductName + ".frmCopyleftTokenGeneration_iPhone");
                    }
                    else if (lblOpenType.Text == "Settings")
                    {
                        sprOpenForm(Application.ProductName + ".frmCopyleftTokenSettings_iPhone");
                    }
                    else if (lblOpenType.Text == "Advt")
                    {
                        return;
                    }
                    else if (lblOpenType.Text == "TokenDetail")
                    {
                        return;
                    }
                    else if (lblOpenType.Text == "TokenExpiry")
                    {
                        return;
                    }
                }
                #endregion
            }
            panTokenOption.Visible = false;
        }
        private void btnRegistration_Click(object sender, EventArgs e)
        {
            SetButtonColor(btnRegistration);
            sprOpenForm(Application.ProductName + ".frmRegistration");
            //frmRegistration frm = new frmRegistration();
            //frm.MdiParent = this;
            //frm.Show();
            //frm.Dock = DockStyle.Fill;
            panTokenOption.Visible = false;
            panLinks.Visible = false;
        }

        private void btnDealerRegistration_Click(object sender, EventArgs e)
        {
            SetButtonColor(btnDealerRegistration);
            sprOpenForm(Application.ProductName + ".frmDealerRegistration");
            panTokenOption.Visible = false;
            panLinks.Visible = false;
        }
        private void SetButtonColor(Button btnName)
        {
            Color light = Color.FromName("ControlLightLight");
            Color bLight = Color.FromName("Control");
            btnRegistration.BackColor = Color.FromArgb(bLight.A, bLight.R, bLight.G, bLight.B);
            btnTokenGeneration.BackColor = Color.FromArgb(bLight.A, bLight.R, bLight.G, bLight.B);
            btnTokenSettings.BackColor = Color.FromArgb(bLight.A, bLight.R, bLight.G, bLight.B);
            btnTokenExpiryDate.BackColor = Color.FromArgb(bLight.A, bLight.R, bLight.G, bLight.B);
            btnDealerRegistration.BackColor = Color.FromArgb(bLight.A, bLight.R, bLight.G, bLight.B);
            btnDealerDetail.BackColor = Color.FromArgb(bLight.A, bLight.R, bLight.G, bLight.B);
            btnAdvertisementControl.BackColor = Color.FromArgb(bLight.A, bLight.R, bLight.G, bLight.B);
            btnSpecialEvents.BackColor = Color.FromArgb(bLight.A, bLight.R, bLight.G, bLight.B);
            btnBestoff.BackColor = Color.FromArgb(bLight.A, bLight.R, bLight.G, bLight.B);
            btnStreamShedule.BackColor = Color.FromArgb(bLight.A, bLight.R, bLight.G, bLight.B);
            btnAdvt.BackColor = Color.FromArgb(bLight.A, bLight.R, bLight.G, bLight.B);
            btnPrayer.BackColor = Color.FromArgb(bLight.A, bLight.R, bLight.G, bLight.B);
            btnDotNetStream.BackColor = Color.FromArgb(bLight.A, bLight.R, bLight.G, bLight.B);
            btnMobileAppStream.BackColor = Color.FromArgb(bLight.A, bLight.R, bLight.G, bLight.B);
            btnChangeMiddleImg.BackColor = Color.FromArgb(bLight.A, bLight.R, bLight.G, bLight.B);
             
            //btnName.BackColor = Color.FromArgb(light.A,light.R,light.G,light.B);
            btnName.BackColor = Color.White;
        }
        private void SetButtonColorSpl(Button btnName)
        {
            btnTokenDetail.BackColor = Color.FromArgb(55, 51, 45);
           
            btnManagementDealers.BackColor = Color.FromArgb(55, 51, 45);
            btnOnlineStream.BackColor = Color.FromArgb(55, 51, 45);
            btnManagementPlaylists.BackColor = Color.FromArgb(55, 51, 45);
            btnStore.BackColor = Color.FromArgb(55, 51, 45);
            btnPlayerAdvertisement.BackColor = Color.FromArgb(55, 51, 45);
            btnDirectUpload.BackColor = Color.FromArgb(55, 51, 45);
            btnLinks.BackColor = Color.FromArgb(55, 51, 45);
            btnName.BackColor = Color.DimGray;
        }
        private void btnDealerDetail_Click(object sender, EventArgs e)
        {
            SetButtonColor(btnDealerDetail);
            //sprOpenForm(Application.ProductName + ".frmDealerLedger");
            sprOpenForm(Application.ProductName + ".frmTokenDetail");
            panTokenOption.Visible = false;
            panLinks.Visible = false;
        }

        private void btnOnlineStream_Click(object sender, EventArgs e)
        {
            SetButtonColorSpl(btnOnlineStream);
            SetButtonColor(btnDotNetStream);
            sprOpenForm(Application.ProductName + ".frmOnlineStreaming");
            panSingleUsers.Visible = false;
            panManagementDealers.Visible = false;
            panStreaming.Visible = true;
            panManagementPlaylists.Visible = false;
            panAdvt.Visible = false;
            panTokenOption.Visible = false;
            panLinks.Visible = false;
        }

        private void btnPlayerAdvertisement_Click(object sender, EventArgs e)
        {
            SetButtonColorSpl(btnPlayerAdvertisement);
            SetButtonColor(btnAdvt);
            sprOpenForm(Application.ProductName + ".frmAdvtAdmin");
            panSingleUsers.Visible = false;
            panManagementDealers.Visible = false;
            panStreaming.Visible = false;
            panManagementPlaylists.Visible = false;
            panAdvt.Visible = true;

            panTokenOption.Visible = false;
            panLinks.Visible = false;

        }

        private void frmMain_Load(object sender, EventArgs e)
        {

            this.Icon = Properties.Resources.Eufory;


            SetButtonColorSpl(btnManagementDealers);
            SetButtonColor(btnDealerRegistration);
            sprOpenForm(Application.ProductName + ".frmDealerRegistration");
            panSingleUsers.Visible = false;
            panManagementDealers.Visible = true;
            panStreaming.Visible = false;
            panManagementPlaylists.Visible = false;
            panAdvt.Visible = false;
            panTokenOption.Visible = false;
            panLinks.Visible = false;







             
        }

        private void btnTokenSettings_Click(object sender, EventArgs e)
        {
            SetButtonColor(btnTokenSettings);
            lblOpenType.Text = "Settings";
            panTokenOption.Dock = DockStyle.Fill;
            panTokenOption.Visible = true;
            panLinks.Visible = false;
            panLinks.Dock = DockStyle.None;

        }

        private void btnTokenGeneration_Click(object sender, EventArgs e)
        {
            SetButtonColor(btnTokenGeneration);
            lblOpenType.Text = "Token";
            panTokenOption.Dock = DockStyle.Fill;
            panTokenOption.Visible = true;
            panLinks.Visible = false;
            panLinks.Dock = DockStyle.None;



        }

        private void btnTokenDetail_Click(object sender, EventArgs e)
        {
            SetButtonColorSpl(btnTokenDetail);
            SetButtonColor(btnRegistration);
            sprOpenForm(Application.ProductName + ".frmRegistration");
            panSingleUsers.Visible = true;
            panManagementDealers.Visible = false;
            panStreaming.Visible = false;
            panManagementPlaylists.Visible = false;
            panAdvt.Visible = false;
            panTokenOption.Visible = false;
            panLinks.Visible = false;
        }

        private void btnTokenExpiryDate_Click(object sender, EventArgs e)
        {
            SetButtonColor(btnTokenExpiryDate);
            lblOpenType.Text = "TokenExpiry";
            panTokenOption.Dock = DockStyle.Fill;
            panTokenOption.Visible = true;
            panLinks.Visible = false;
            panLinks.Dock = DockStyle.None;

        }

        private void btnAdvertisementControl_Click(object sender, EventArgs e)
        {
            SetButtonColor(btnAdvertisementControl);
            //lblOpenType.Text = "Advt";
            //panTokenOption.Dock = DockStyle.Fill;
            //panTokenOption.Visible = true;
            //panLinks.Visible = false;
            //panLinks.Dock = DockStyle.None;
            sprOpenForm(Application.ProductName + ".frmSpecialPlaylistFormat");
            panTokenOption.Visible = false;
            panLinks.Visible = false;
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        { 
            Application.Exit();
            //if (e.CloseReason == CloseReason.UserClosing)
            //{
            //    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            //    DialogResult result;
            //    result = MessageBox.Show("Are you sure to exit ?", "Token Admin", buttons, MessageBoxIcon.Question);
            //    if (result == System.Windows.Forms.DialogResult.Yes)
            //    {
            //        e.Cancel = false;
                   
            //    }
            //    else
            //    {
            //        e.Cancel = true;
            //    }

            //}
        }

        private void sprOpenForm(string FormName)
        {
            string mlsFormName = FormName;
            try
            {

                FormType = Type.GetType(mlsFormName, true, true);
                ObjFormName = (Form)Activator.CreateInstance(FormType);
                ObjFormName.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                foreach (Form ChildForm in this.MdiChildren)
                {
                    if (ChildForm.Name == ObjFormName.Name)
                    {
                        ChildForm.Show();
                        ChildForm.Activate();
                        Application.DoEvents();
                        ChildForm.BringToFront();
                        ChildForm.WindowState = FormWindowState.Normal;
                        ChildForm.Dock = DockStyle.Fill;
                        return;
                    }
                }

                ObjFormName.MdiParent = this;
                ObjFormName.Show();
                Application.DoEvents();
                ObjFormName.BringToFront();
                ObjFormName.WindowState = FormWindowState.Normal;
                ObjFormName.Dock = DockStyle.Fill;

            }
            catch (Exception ex)
            {
                MessageBox.Show("This module is under process", "Under Construction");
            }

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            SetButtonColor(btnBestoff);
            sprOpenForm(Application.ProductName + ".frmBestofPlaylist");
            panTokenOption.Visible = false;
            panLinks.Visible = false;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://146.0.229.66/PlayerFiles/setups/normal/CL/publish.htm");
        }

        private void label6_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://146.0.229.66/PlayerFiles/setups/WinXp/normal/CL/publish.htm");
        }

        private void label3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://146.0.229.66/PlayerFiles/setups/normal/Asian/publish.htm");
        }

        private void label7_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://146.0.229.66/PlayerFiles/setups/WinXp/normal/Asian/publish.htm");
        }

        private void label4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://146.0.229.66/PlayerFiles/setups/normal/CR/publish.htm");
        }

        private void label8_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://146.0.229.66/PlayerFiles/setups/WinXp/normal/CR/publish.htm");
        }

         

        private void btnLinks_Click(object sender, EventArgs e)
        {
            string str = "";
              
            SetButtonColorSpl(btnLinks);

            

            panLinks.Visible = true;
            panLinks.Dock = DockStyle.Fill;
            panTokenOption.Visible = false;
            panTokenOption.Dock = DockStyle.None;
            panSingleUsers.Visible = false;
            panManagementDealers.Visible = false;
            panStreaming.Visible = false;
            panManagementPlaylists.Visible = false;

            panAdvt.Visible = false;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SetButtonColor(btnSpecialEvents);
            sprOpenForm(Application.ProductName + ".frmSpecialEvent");
            panTokenOption.Visible = false;
            panLinks.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SetButtonColorSpl(btnManagementDealers);
            SetButtonColor(btnDealerRegistration);
            sprOpenForm(Application.ProductName + ".frmDealerRegistration");
            panSingleUsers.Visible = false;
            panManagementDealers.Visible = true;
            panStreaming.Visible = false;
            panManagementPlaylists.Visible = false;
            panAdvt.Visible = false;
            panTokenOption.Visible = false;
            panLinks.Visible = false;
        }

        private void label12_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://manageyourclaudio.eu/CopyleftTokenDetails.rar");
        }

        private void label14_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://146.0.229.66/PlayerFiles/setups/TokenLicenseHolder.msi");
        }
                                
        private void label17_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://146.0.229.66/PlayerFiles/setups/Total_Centomedia_MYM.msi");
        }

        private void label19_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://146.0.229.66/PlayerFiles/setups/remote.exe");
        }

        private void label21_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://146.0.229.66/PlayerFiles/setups/GetUnquieId.rar");
        }

        
        private void btnStreamShedule_Click(object sender, EventArgs e)
        {
            SetButtonColor(btnStreamShedule);
            sprOpenForm(Application.ProductName + ".frmStreamShedule");
            panTokenOption.Visible = false;
            panLinks.Visible = false;
        }
         
        
        
       
        private void label32_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://146.0.229.66/PlayerFiles/setups/NativeCL/publish.htm");
        }

        private void label34_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://146.0.229.66/PlayerFiles/setups/WinXp/NativeCL/publish.htm");
        }

        private void label33_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://146.0.229.66/PlayerFiles/setups/NativeCR/publish.htm");
        }

        private void label35_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://146.0.229.66/PlayerFiles/setups/WinXp/NativeCR/publish.htm");
        }

        
        private void frmMain_SizeChanged(object sender, EventArgs e)
        {
             
                
        }

        private void cmbDealer_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btnStore_Click(object sender, EventArgs e)
        {
            SetButtonColorSpl(btnStore);
            frmSpecialPlaylists frm = new frmSpecialPlaylists(this);
            frm.MdiParent = this;
            panSingleUsers.Visible = false;
            panManagementDealers.Visible = false;
            panStreaming.Visible = false;
            panManagementPlaylists.Visible = false;
            panAdvt.Visible = false;
            panTokenOption.Visible = false;
            panLinks.Visible = false;
            frm.BringToFront();
            frm.WindowState = FormWindowState.Normal;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void btnManagementPlaylists_Click(object sender, EventArgs e)
        {
            SetButtonColorSpl(btnManagementPlaylists);
            SetButtonColor(btnBestoff);
            sprOpenForm(Application.ProductName + ".frmBestofPlaylist");
            panSingleUsers.Visible = false;
            panManagementDealers.Visible = false;
            panStreaming.Visible = false;
            panManagementPlaylists.Visible = true;
            panAdvt.Visible = false;
            panTokenOption.Visible = false;
            panLinks.Visible = false;
        }

        private void btnDotNetStream_Click(object sender, EventArgs e)
        {
            SetButtonColor(btnDotNetStream);
            sprOpenForm(Application.ProductName + ".frmOnlineStreaming");
            panTokenOption.Visible = false;
            panLinks.Visible = false;
        }

        private void btnMobileAppStream_Click(object sender, EventArgs e)
        {
            SetButtonColor(btnMobileAppStream);
            sprOpenForm(Application.ProductName + ".frmMoblieAppStreams");
            panTokenOption.Visible = false;
            panLinks.Visible = false;
        }

        private void btnChangeMiddleImg_Click(object sender, EventArgs e)
        {
            SetButtonColor(btnChangeMiddleImg);
            sprOpenForm(Application.ProductName + ".frmChangeAppMiddleImage");
            panTokenOption.Visible = false;
            panLinks.Visible = false;
        }

        private void btnAdvt_Click(object sender, EventArgs e)
        {
            SetButtonColor(btnAdvt);
            sprOpenForm(Application.ProductName + ".frmAdvtAdmin");
            panTokenOption.Visible = false;
            panLinks.Visible = false;
        }

        private void btnPrayer_Click(object sender, EventArgs e)
        {
            SetButtonColor(btnPrayer);
            sprOpenForm(Application.ProductName + ".frmPrayer");
            panTokenOption.Visible = false;
            panLinks.Visible = false;
        }

        private void label26_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://146.0.229.66/PlayerFiles/setups/NativeAsian/publish.htm");
        }

        private void label27_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://146.0.229.66/PlayerFiles/setups/WinXp/NativeAsian/publish.htm");
        }

        private void btnVideoAdvt_Click(object sender, EventArgs e)
        {
             
        
        }
       
        public String nameOfControlVisible2
        {
            get { return this.lblButtonName.Text; }
            set
            {
                this.lblButtonName.Text = value;
                btnTokenDetail.BackColor = Color.FromArgb(55, 51, 45);
                btnManagementDealers.BackColor = Color.FromArgb(55, 51, 45);
                btnOnlineStream.BackColor = Color.FromArgb(55, 51, 45);
                btnManagementPlaylists.BackColor = Color.FromArgb(55, 51, 45);
                btnStore.BackColor = Color.FromArgb(55, 51, 45);
                btnPlayerAdvertisement.BackColor = Color.FromArgb(55, 51, 45);
                btnLinks.BackColor = Color.FromArgb(55, 51, 45);
                btnManagementPlaylists.BackColor = Color.DimGray;
                SetButtonColor(btnAdvertisementControl);
                panSingleUsers.Visible = false;
                panManagementDealers.Visible = false;
                panStreaming.Visible = false;
                panManagementPlaylists.Visible = true;
                panAdvt.Visible = false;
                panTokenOption.Visible = false;
                panLinks.Visible = false;
            }
        }

        private void btnDirectUpload_Click(object sender, EventArgs e)
        {
            SetButtonColorSpl(btnDirectUpload);

            sprOpenForm(Application.ProductName + ".frmImportExcel");
            panSingleUsers.Visible = false;
            panManagementDealers.Visible = false;
            panStreaming.Visible = false;
            panManagementPlaylists.Visible = false;
            panAdvt.Visible = false;
            panTokenOption.Visible = false;
            panLinks.Visible = false;
        }

        private void cmbDealer_Click(object sender, EventArgs e)
        {
           
        }

        private void cmbClientName_Click(object sender, EventArgs e)
        {
            string str = "";
            str = "select DFClientID,ClientName from DFClients where CountryCode is not null and DFClients.IsDealer=1 ";
            str = str + " order by DFClientID desc ";
            objMainClass.fnFillComboBox(str, cmbClientName, "DFClientID", "ClientName", "");
        }

        private void cmbClientName_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtLogin.Text = "";
            txtPassword.Text = "";
            if (Convert.ToInt32(cmbClientName.SelectedValue) == 0)
            {
                txtLogin.Text = "";
                txtPassword.Text = "";
            }
            DataTable dsTotalToken = new DataTable();
            string sQr = " ";
            sQr = "SELECT * from tbdealerlogin ";
            sQr = sQr + " where  dfclientid =" + Convert.ToInt32(cmbClientName.SelectedValue);
            dsTotalToken = objMainClass.fnFillDataTable(sQr);
            if (dsTotalToken.Rows.Count > 0)
            {
                txtLogin.Text = dsTotalToken.Rows[0]["LoginName"].ToString();
                txtPassword.Text = dsTotalToken.Rows[0]["LoginPassword"].ToString();
            }
            else
            {
                txtLogin.Text = "";
                txtPassword.Text = "";
            }
        }






    }
}
