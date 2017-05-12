using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace ManagementPanel
{
    public partial class frmStreamShedule : Form
    {
        gblClass objMainClass = new gblClass();
        Int32 ModifyId = 0;
        public frmStreamShedule()
        {
            InitializeComponent();
            FillComobo();
            dtpStartDate.Value = DateTime.Now.Date;
            dtpEndDate.Value = DateTime.Now.Date;
            dtpFromDate.Value = DateTime.Now.Date;
            string Advttype = "select dfclientid, dealercode from ( select dfclientid, dealercode from tbdealerlogin  union all select dfclientid, dealercode from dfclients where dealercode='Claudio000' union all  select distinct '10001' as dfclientid, 'MyClaud000' as dealercode from dfclients  ) as a order by dfclientid";
            objMainClass.fnFillComboBox(Advttype, cmbSearchDealercode, "dfclientid", "dealercode", "");
        }
        private void FillComobo()
        {
            string str = "select * from tblTitleCategory order by TitleCategoryName";
            objMainClass.fnFillComboBox(str, cmbTitleCategory, "TitleCategoryid", "TitleCategoryName");

            string strCountry = "";
            strCountry = "select * from CountryCodes order by countryCode";
            objMainClass.fnFillComboBox(strCountry, cmbCountryName, "countrycode", "countryName", "");

            string Advttype = "select dfclientid, dealercode from ( select dfclientid, dealercode from tbdealerlogin  union all select dfclientid, dealercode from dfclients where dealercode='Claudio000' union all  select distinct '10001' as dfclientid, 'MyClaud000' as dealercode from dfclients ) as a order by dfclientid";
            objMainClass.fnFillComboBox(Advttype, cmbDealerCode, "dfclientid", "dealercode", "");
        }

        private void cmbTitleCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cmbTitleCategory.SelectedValue) == 0)
            {
                cmbStreamName.DataSource = null;
                cmbStreamName.Refresh();
                return;
            }
            string str = "";
            str = "Select * from  tblOnlineStreaming where titlecategoryId = " + Convert.ToInt32(cmbTitleCategory.SelectedValue) + " and Dealercode='" + cmbAdminCode.Text + "' order by StreamName";
            objMainClass.fnFillComboBox(str, cmbStreamName, "StreamId", "StreamName");
        }

        private void cmbAdminCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            string str = "";
            str = "Select * from  tblOnlineStreaming where titlecategoryId = " + Convert.ToInt32(cmbTitleCategory.SelectedValue) + " and Dealercode='" + cmbAdminCode.Text + "' order by StreamName";
            objMainClass.fnFillComboBox(str, cmbStreamName, "StreamId", "StreamName");
        }

        private void cmbCountryName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cmbCountryName.SelectedValue) == 0)
            {
                cmbStateName.DataSource = null;
                cmbStateName.Refresh();
                return;
            }
            string strState = "";
            strState = "select * from tbState where countryId= " + Convert.ToInt32(cmbCountryName.SelectedValue);
            objMainClass.fnFillComboBox(strState, cmbStateName, "stateid", "StateName", "");
        }

        private void cmbStateName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cmbStateName.SelectedValue) == 0)
            {
                cmbCityName.DataSource = null;
                cmbCityName.Refresh();
                return;
            }
            string strCity = "";
            strCity = "select * from tbCity where countryId= " + Convert.ToInt32(cmbCountryName.SelectedValue) + " and stateid =" + Convert.ToInt32(cmbStateName.SelectedValue);
            objMainClass.fnFillComboBox(strCity, cmbCityName, "Cityid", "CityName", "");
        }

        private void btnStateNew_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cmbCountryName.SelectedValue) == 0)
            {
                MessageBox.Show("Select a Country from the list name", "Management Panel");
                cmbCountryName.Focus();
                return;
            }
            txtName.Text = "";
            txtName.Focus();
            panMainNew.Width = this.Width;
            panMainNew.Height = this.Height;
            panMainNew.Location = new Point(0, 0);
            panMainNew.BringToFront();
            panMainNew.Visible = true;
            lblCaption.Text = "State Name";
            txtName.Focus();
        }

        private void btnCityNew_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cmbCountryName.SelectedValue) == 0)
            {
                MessageBox.Show("Select a Country from the list name", "Management Panel");
                cmbCountryName.Focus();
                return;
            }
            if (Convert.ToInt32(cmbStateName.SelectedValue) == 0)
            {
                MessageBox.Show("Select a state name", "Management Panel");
                cmbStateName.Focus();
                return;
            }
            txtName.Text = "";
            txtName.Focus();
            panMainNew.Width = this.Width;
            panMainNew.Height = this.Height;
            panMainNew.BringToFront();
            panMainNew.Location = new Point(0, 0);
            panMainNew.Visible = true;
            lblCaption.Text = "City Name";
            txtName.Focus();
        }

        private void btnSaveNew_Click(object sender, EventArgs e)
        {
            string returnValue = "";
            string strState = "";
            if (lblCaption.Text == "State Name")
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("SaveState", StaticClass.constr);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@CountryId", SqlDbType.BigInt));
                    cmd.Parameters["@CountryId"].Value = Convert.ToInt32(cmbCountryName.SelectedValue);

                    cmd.Parameters.Add(new SqlParameter("@StateName", SqlDbType.VarChar));
                    cmd.Parameters["@StateName"].Value = txtName.Text;
                    if (StaticClass.constr.State == ConnectionState.Open) StaticClass.constr.Close();
                    StaticClass.constr.Open();
                    returnValue = cmd.ExecuteScalar().ToString();
                    if (returnValue != "-2")
                    {
                        strState = "select * from tbState where countryId= " + Convert.ToInt32(cmbCountryName.SelectedValue);
                        objMainClass.fnFillComboBox(strState, cmbStateName, "stateid", "StateName", "");
                        cmbStateName.SelectedValue = Convert.ToInt32(returnValue);
                        panMainNew.Visible = false;
                        lblCaption.Text = "";
                    }
                    if (returnValue == "-2")
                    {
                        MessageBox.Show("State Name already exixts", "Management Panel");
                        panMainNew.Visible = false;
                        lblCaption.Text = "";
                        return;
                    }
                }
                catch (Exception ex) { }
            }
            else if (lblCaption.Text == "City Name")
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("SaveCity", StaticClass.constr);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@CountryId", SqlDbType.BigInt));
                    cmd.Parameters["@CountryId"].Value = Convert.ToInt32(cmbCountryName.SelectedValue);

                    cmd.Parameters.Add(new SqlParameter("@StateId", SqlDbType.BigInt));
                    cmd.Parameters["@StateId"].Value = Convert.ToInt32(cmbStateName.SelectedValue);

                    cmd.Parameters.Add(new SqlParameter("@CityName", SqlDbType.VarChar));
                    cmd.Parameters["@CityName"].Value = txtName.Text;

                    if (StaticClass.constr.State == ConnectionState.Open) StaticClass.constr.Close();
                    StaticClass.constr.Open();
                    returnValue = cmd.ExecuteScalar().ToString();
                    if (returnValue != "-2")
                    {

                        string strCity = "";
                        strCity = "select * from tbCity where countryId= " + Convert.ToInt32(cmbCountryName.SelectedValue) + " and stateid =" + Convert.ToInt32(cmbStateName.SelectedValue);
                        objMainClass.fnFillComboBox(strCity, cmbCityName, "Cityid", "CityName", "");
                        cmbCityName.SelectedValue = Convert.ToInt32(returnValue);
                        panMainNew.Visible = false;
                        lblCaption.Text = "";
                    }
                    if (returnValue == "-2")
                    {
                        MessageBox.Show("City Name already exixts", "Management Panel");
                        panMainNew.Visible = false;
                        lblCaption.Text = "";
                        return;
                    }
                }
                catch (Exception ex) { }
            }
        }

        private void btnNewCancel_Click(object sender, EventArgs e)
        {
            panMainNew.Visible = false;
            txtName.Text = "";
        }

        private void btnRefersh_Click(object sender, EventArgs e)
        {
            Clear();
        }
        private void Clear()
        {
            ModifyId = 0;
            btnSave.Text = "Save";
            cmbHour.Text = "";
            cmbMin.Text = "";
            cmbAMPM.Text = "";
            cmbAdminCode.Text = "";
            dtpStartDate.Value = DateTime.Now.Date;
            dtpEndDate.Value = DateTime.Now.Date;
            dtpFromDate.Value = DateTime.Now.Date;
            FillComobo();
            FillDealerAdvtDetail("GetStreamSheduling '" + string.Format("{0:dd/MMM/yyyy}", dtpFromDate.Value) + "',''");
        }
        private Boolean SubmitValidationAdvt()
        {

            if (Convert.ToInt32(cmbTitleCategory.SelectedValue) == 0)
            {
                MessageBox.Show("Category name cannot be blank", "Management Panel");
                cmbTitleCategory.Focus();
                return false;
            }
            if (cmbAdminCode.Text == "")
            {
                MessageBox.Show("Admin code cannot be blank", "Management Panel");
                cmbAdminCode.Focus();
                return false;
            }
            if (dtpEndDate.Value < dtpStartDate.Value)
            {
                MessageBox.Show("Please select proper date's", "Management Panel");
                dtpEndDate.Focus();
                return false;
            }
            if (Convert.ToInt32(cmbStreamName.SelectedValue) == 0)
            {
                MessageBox.Show("Stream name cannot be balnk", "Management Panel");
                cmbStreamName.Focus();
                return false;
            }
            if (cmbHour.Text == "")
            {
                MessageBox.Show("Please select the hour", "Management Panel");
                cmbHour.Focus();
                return false;
            }
            if (cmbMin.Text == "")
            {
                MessageBox.Show("Please select minute", "Management Panel");
                cmbMin.Focus();
                return false;
            }
            if (cmbAMPM.Text == "")
            {
                MessageBox.Show("Please select time type", "Management Panel");
                cmbAMPM.Focus();
                return false;
            }

            if (Convert.ToInt32(cmbDealerCode.SelectedValue) == 0)
            {
                MessageBox.Show("Please select a dealer code", "Management Panel");
                cmbDealerCode.Focus();
                return false;
            }
            if (Convert.ToInt32(cmbCountryName.SelectedValue) == 0)
            {
                MessageBox.Show("Select a Country from the list", "Management Panel");
                cmbCountryName.Focus();
                return false;
            }
            else if (Convert.ToInt32(cmbStateName.SelectedValue) == 0)
            {
                MessageBox.Show("Select a state", "Management Panel");
                cmbStateName.Focus();
                return false;
            }
            else if (Convert.ToInt32(cmbCityName.SelectedValue) == 0)
            {
                MessageBox.Show("Select a city", "Management Panel");
                cmbCityName.Focus();
                return false;
            }

            string GetComboTimeString = "";
            GetComboTimeString = cmbHour.Text + ":" + cmbMin.Text + " " + cmbAMPM.Text;
            DateTime GetComboTime = DateTime.ParseExact(GetComboTimeString, "hh:mm tt", System.Globalization.CultureInfo.InvariantCulture);
            string strDealerTimeValid = "";
            if (btnSave.Text == "Save")
            {
                strDealerTimeValid = "select * from tbStreamScheduling where tokenid=0 and titlecategoryId=" + Convert.ToInt32(cmbTitleCategory.SelectedValue) + " and cityid=" + Convert.ToInt32(cmbCityName.SelectedValue) + " and dealercode='" + cmbDealerCode.Text + "' and ";
                strDealerTimeValid = strDealerTimeValid + " StartTime='" + GetComboTime.ToString("hh:mm tt") + "' ";
                strDealerTimeValid = strDealerTimeValid + " and ('" + dtpStartDate.Value.ToString("dd/MMM/yyyy") + "' between StartDate and  EndDate";
                strDealerTimeValid = strDealerTimeValid + " or '" + dtpEndDate.Value.ToString("dd/MMM/yyyy") + "' between StartDate and  EndDate )";
            }
            else
            {
                strDealerTimeValid = "select * from tbStreamScheduling where tokenid=0 and titlecategoryId=" + Convert.ToInt32(cmbTitleCategory.SelectedValue) + " and cityid=" + Convert.ToInt32(cmbCityName.SelectedValue) + " and dealercode='" + cmbDealerCode.Text + "' and ";
                strDealerTimeValid = strDealerTimeValid + " StartTime='" + GetComboTime.ToString("hh:mm tt") + "' ";
                strDealerTimeValid = strDealerTimeValid + " and ('" + dtpStartDate.Value.ToString("dd/MMM/yyyy") + "' between StartDate and  EndDate";
                strDealerTimeValid = strDealerTimeValid + " or '" + dtpEndDate.Value.ToString("dd/MMM/yyyy") + "' between StartDate and  EndDate )";
                strDealerTimeValid = strDealerTimeValid + " and SheduleId   <> " + ModifyId;
            }
            DataTable dtDealerTimeValid = new DataTable();
            dtDealerTimeValid = objMainClass.fnFillDataTable(strDealerTimeValid);
            if (dtDealerTimeValid.Rows.Count > 0)
            {
                MessageBox.Show("This time is already used", "Management Panel");
                cmbMin.Focus();
                return false;
            }

            //strDealerTimeValid = "";
            //if (btnSave.Text == "Save")
            //{
            //    strDealerTimeValid = "select * from tbStreamScheduling where tokenid=0 and  cityid=" + Convert.ToInt32(cmbCityName.SelectedValue) + "' and dealercode='" + cmbDealerCode.Text + "' and ";
            //    strDealerTimeValid = strDealerTimeValid + " StreamId=" + Convert.ToInt32(cmbStreamName.SelectedValue) + " ";
            //    strDealerTimeValid = strDealerTimeValid + " and ('" + dtpStartDate.Value.ToString("dd/MMM/yyyy") + "' between StartDate and  EndDate";
            //    strDealerTimeValid = strDealerTimeValid + " or '" + dtpEndDate.Value.ToString("dd/MMM/yyyy") + "' between StartDate and  EndDate )";
            //}
            //else
            //{
            //    strDealerTimeValid = "select * from tbStreamScheduling where tokenid=0 and  cityid=" + Convert.ToInt32(cmbCityName.SelectedValue) + "' and dealercode='" + cmbDealerCode.Text + "' and ";
            //    strDealerTimeValid = strDealerTimeValid + " StreamId=" + Convert.ToInt32(cmbStreamName.SelectedValue) + " ";
            //    strDealerTimeValid = strDealerTimeValid + " and ('" + dtpStartDate.Value.ToString("dd/MMM/yyyy") + "' between StartDate and  EndDate";
            //    strDealerTimeValid = strDealerTimeValid + " or '" + dtpEndDate.Value.ToString("dd/MMM/yyyy") + "' between StartDate and  EndDate )";
            //    strDealerTimeValid = strDealerTimeValid + " and SheduleId   <> " + ModifyId;
            //}
            //dtDealerTimeValid = new DataTable();
            //dtDealerTimeValid = objMainClass.fnFillDataTable(strDealerTimeValid);
            //if (dtDealerTimeValid.Rows.Count > 0)
            //{
            //    MessageBox.Show("This stream is already used in between date's", "Management Panel");
            //    dtpStartDate.Focus();
            //    return false;
            //}

            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SubmitValidationAdvt() == false) return;
            SaveRecord();
        }
        private void SaveRecord()
        {
            string GetComboTimeString = "";
            GetComboTimeString = cmbHour.Text + ":" + cmbMin.Text + " " + cmbAMPM.Text;
            DateTime GetComboTime = DateTime.ParseExact(GetComboTimeString, "hh:mm tt", System.Globalization.CultureInfo.InvariantCulture);
            if (StaticClass.constr.State == ConnectionState.Open) StaticClass.constr.Close();
            StaticClass.constr.Open();
            SqlCommand cmd = new SqlCommand("spStreamScheduling", StaticClass.constr);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@SheduleId", SqlDbType.BigInt));
            cmd.Parameters["@SheduleId"].Value = Convert.ToInt32(ModifyId);

            cmd.Parameters.Add(new SqlParameter("@TitleCategoryId", SqlDbType.BigInt));
            cmd.Parameters["@TitleCategoryId"].Value = Convert.ToInt32(cmbTitleCategory.SelectedValue);

            cmd.Parameters.Add(new SqlParameter("@AdminCode", SqlDbType.VarChar));
            cmd.Parameters["@AdminCode"].Value = cmbAdminCode.Text.Trim();

            cmd.Parameters.Add(new SqlParameter("@StreamId", SqlDbType.BigInt));
            cmd.Parameters["@StreamId"].Value = Convert.ToInt32(cmbStreamName.SelectedValue);

            cmd.Parameters.Add(new SqlParameter("@StartDate", SqlDbType.DateTime));
            cmd.Parameters["@StartDate"].Value = dtpStartDate.Value.ToString("dd/MMM/yyyy");

            cmd.Parameters.Add(new SqlParameter("@EndDate", SqlDbType.DateTime));
            cmd.Parameters["@EndDate"].Value = dtpEndDate.Value.ToString("dd/MMM/yyyy");

            cmd.Parameters.Add(new SqlParameter("@StartTime", SqlDbType.DateTime));
            cmd.Parameters["@StartTime"].Value = GetComboTime.ToString("hh:mm tt");

            cmd.Parameters.Add(new SqlParameter("@Dealercode", SqlDbType.VarChar));
            cmd.Parameters["@Dealercode"].Value = cmbDealerCode.Text;

            cmd.Parameters.Add(new SqlParameter("@CountryId", SqlDbType.BigInt));
            cmd.Parameters["@CountryId"].Value = Convert.ToInt32(cmbCountryName.SelectedValue);

            cmd.Parameters.Add(new SqlParameter("@StateId", SqlDbType.BigInt));
            cmd.Parameters["@StateId"].Value = Convert.ToInt32(cmbStateName.SelectedValue);

            cmd.Parameters.Add(new SqlParameter("@CityId", SqlDbType.BigInt));
            cmd.Parameters["@CityId"].Value = Convert.ToInt32(cmbCityName.SelectedValue);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record is save", "Manageyourclaudio");
                Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Record not save", "!! Problem !!");
                Clear();
                return;
            }
            finally
            {
                StaticClass.constr.Close();
            }
        }

        private void InitilizeGrid()
        {
            if (dgStream.Rows.Count > 0)
            {
                dgStream.Rows.Clear();
            }
            if (dgStream.Columns.Count > 0)
            {
                dgStream.Columns.Clear();
            }

            dgStream.Columns.Add("ScheduleId", "Schedule Id");
            dgStream.Columns["ScheduleId"].Width = 0;
            dgStream.Columns["ScheduleId"].Visible = false;
            dgStream.Columns["ScheduleId"].ReadOnly = true;

            dgStream.Columns.Add("cName", "Category Name");
            dgStream.Columns["cName"].Width = 140;
            dgStream.Columns["cName"].Visible = true;
            dgStream.Columns["cName"].ReadOnly = true;
            dgStream.Columns["cName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            dgStream.Columns.Add("sName", "Stream Name");
            dgStream.Columns["sName"].Width = 370;
            dgStream.Columns["sName"].Visible = true;
            dgStream.Columns["sName"].ReadOnly = true;
            dgStream.Columns["sName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgStream.Columns.Add("aCode", "Admin Code");
            dgStream.Columns["aCode"].Width = 110;
            dgStream.Columns["aCode"].Visible = true;
            dgStream.Columns["aCode"].ReadOnly = true;
            dgStream.Columns["aCode"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            dgStream.Columns.Add("StartDate", "Start Date");
            dgStream.Columns["StartDate"].Width = 120;
            dgStream.Columns["StartDate"].Visible = true;
            dgStream.Columns["StartDate"].ReadOnly = true;
            dgStream.Columns["StartDate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            dgStream.Columns.Add("EndDate", "End Date");
            dgStream.Columns["EndDate"].Width = 120;
            dgStream.Columns["EndDate"].Visible = true;
            dgStream.Columns["EndDate"].ReadOnly = true;
            dgStream.Columns["EndDate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            dgStream.Columns.Add("Time", "Time");
            dgStream.Columns["Time"].Width = 100;
            dgStream.Columns["Time"].Visible = true;
            dgStream.Columns["Time"].ReadOnly = true;
            dgStream.Columns["Time"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;


            dgStream.Columns.Add("CiName", "City Name");
            dgStream.Columns["CiName"].Width = 140;
            dgStream.Columns["CiName"].Visible = true;
            dgStream.Columns["CiName"].ReadOnly = true;
            dgStream.Columns["CiName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            DataGridViewLinkColumn EditAdvt = new DataGridViewLinkColumn();
            EditAdvt.HeaderText = "Edit";
            EditAdvt.Text = "Edit";
            EditAdvt.DataPropertyName = "Edit";
            dgStream.Columns.Add(EditAdvt);
            EditAdvt.UseColumnTextForLinkValue = true;
            EditAdvt.Width = 70;
            EditAdvt.Visible = true;
            dgStream.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            DataGridViewLinkColumn DeleteAdvt = new DataGridViewLinkColumn();
            DeleteAdvt.HeaderText = "Delete";
            DeleteAdvt.Text = "Delete";
            DeleteAdvt.DataPropertyName = "Delete";
            dgStream.Columns.Add(DeleteAdvt);
            DeleteAdvt.UseColumnTextForLinkValue = true;
            DeleteAdvt.Width = 70;
            DeleteAdvt.Visible = true;
            dgStream.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            //dgGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;

        }
        private void FillDealerAdvtDetail(string Query)
        {
            int iCtr;
            DataTable dtDetail;
            dtDetail = objMainClass.fnFillDataTable(Query);
            InitilizeGrid();
            if ((dtDetail.Rows.Count > 0))
            {
                for (iCtr = 0; (iCtr <= (dtDetail.Rows.Count - 1)); iCtr++)
                {
                    dgStream.Rows.Add();
                    dgStream.Rows[dgStream.Rows.Count - 1].Cells["ScheduleId"].Value = dtDetail.Rows[iCtr]["SheduleId"];
                    dgStream.Rows[dgStream.Rows.Count - 1].Cells["cName"].Value = dtDetail.Rows[iCtr]["titlecategoryname"];
                    dgStream.Rows[dgStream.Rows.Count - 1].Cells["sName"].Value = dtDetail.Rows[iCtr]["StreamName"];
                    dgStream.Rows[dgStream.Rows.Count - 1].Cells["aCode"].Value = dtDetail.Rows[iCtr]["AdminCode"];
                    dgStream.Rows[dgStream.Rows.Count - 1].Cells["StartDate"].Value = string.Format("{0:dd/MMM/yyyy}", dtDetail.Rows[iCtr]["StartDate"]);
                    dgStream.Rows[dgStream.Rows.Count - 1].Cells["EndDate"].Value = string.Format("{0:dd/MMM/yyyy}", dtDetail.Rows[iCtr]["EndDate"]);
                    dgStream.Rows[dgStream.Rows.Count - 1].Cells["Time"].Value = string.Format("{0:hh:mm tt}", dtDetail.Rows[iCtr]["StartTime"]);
                    dgStream.Rows[dgStream.Rows.Count - 1].Cells["CiName"].Value = dtDetail.Rows[iCtr]["CityName"];
                }
                 
            }
        }

        private void dtpFromDate_ValueChanged(object sender, EventArgs e)
        {
            string Localstr = "";
            Localstr = "GetStreamSheduling '" + string.Format("{0:dd/MMM/yyyy}", dtpFromDate.Value) + "','" + cmbSearchDealercode.Text + "'";
            FillDealerAdvtDetail(Localstr);
        }

        private void cmbSearchDealercode_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (Convert.ToInt32(cmbSearchDealercode.SelectedValue) == 0) return;
            string Localstr = "";
            Localstr = "GetStreamSheduling '" + string.Format("{0:dd/MMM/yyyy}", dtpFromDate.Value) + "','" + cmbSearchDealercode.Text + "'";
            FillDealerAdvtDetail(Localstr);
        }

        private void dgStream_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (e.ColumnIndex == 8)
            {
                string Localstr = "";
                Localstr = " select * from tbStreamScheduling ";
                Localstr = Localstr + "	where SheduleId = " + Convert.ToInt32(dgStream.Rows[dgStream.CurrentCell.RowIndex].Cells[0].Value);
                DataTable dtDetail;
                dtDetail = objMainClass.fnFillDataTable(Localstr);
                if ((dtDetail.Rows.Count > 0))
                {
                    btnSave.Text = "Update";
                    ModifyId = Convert.ToInt32(dtDetail.Rows[0]["SheduleId"]);

                    cmbCountryName.SelectedValue = Convert.ToInt32(dtDetail.Rows[0]["Countryid"]);
                    cmbTitleCategory.SelectedValue = Convert.ToInt32(dtDetail.Rows[0]["TitleCategoryId"]);
                    cmbAdminCode.Text = dtDetail.Rows[0]["AdminCode"].ToString();
                    cmbStreamName.SelectedValue = Convert.ToInt32(dtDetail.Rows[0]["StreamId"]);
                    dtpStartDate.Value = Convert.ToDateTime(string.Format("{0:dd/MMM/yyyy}", dtDetail.Rows[0]["StartDate"]));
                    dtpEndDate.Value = Convert.ToDateTime(string.Format("{0:dd/MMM/yyyy}", dtDetail.Rows[0]["EndDate"]));
                    cmbStateName.SelectedValue = Convert.ToInt32(dtDetail.Rows[0]["StateId"]);
                    cmbDealerCode.Text = dtDetail.Rows[0]["Dealercode"].ToString();
                    cmbHour.Text = string.Format("{0:hh}", dtDetail.Rows[0]["StartTime"]);
                    cmbMin.Text = string.Format("{0:mm}", dtDetail.Rows[0]["StartTime"]);
                    cmbAMPM.Text = string.Format("{0:tt}", dtDetail.Rows[0]["StartTime"]);
                    cmbCityName.SelectedValue = Convert.ToInt32(dtDetail.Rows[0]["CityId"]);
                }

            }
            if (e.ColumnIndex == 9)
            {
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;
                if (dgStream.Rows.Count <= 0) return;
                if (Convert.ToInt32(dgStream.Rows[dgStream.CurrentCell.RowIndex].Cells[0].Value) != 0)
                {
                    result = MessageBox.Show("Are you sure delete selected shedule?", "Management Panel", buttons);
                    if (result == System.Windows.Forms.DialogResult.Yes)
                    {
                        if (StaticClass.constr.State == ConnectionState.Open) StaticClass.constr.Close();
                        StaticClass.constr.Open();
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = StaticClass.constr;
                        cmd.CommandText = "delete from tbStreamScheduling where SheduleId=" + Convert.ToInt32(dgStream.Rows[dgStream.CurrentCell.RowIndex].Cells[0].Value);
                        cmd.ExecuteNonQuery();
                        StaticClass.constr.Close();
                        FillDealerAdvtDetail("GetStreamSheduling '01-01-1900',''");
                    }
                }
            }
        }
    }
}
