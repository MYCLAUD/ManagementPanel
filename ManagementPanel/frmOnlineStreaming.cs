﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Net;

namespace ManagementPanel
{
    public partial class frmOnlineStreaming : Form
    {
        gblClass objMainClass = new gblClass();
        string SaveType = "Save";
        Int32 ModifyStreamId = 0;
        string AppSaveType = "Save";
        Int32 ModifyStreamIdApp = 0;

        Int32 NewFileName = 0;
        public frmOnlineStreaming()
        {
            InitializeComponent();
            cmbAdminCode.Text = "MyClaud000";
            cmbSearchAdminCode.Text = "MyClaud000";

        }
        private void btnUnload_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        private void FillTitleCategory()
        {
            string str = "select * from tblTitleCategory order by TitleCategoryid";
            objMainClass.fnFillComboBox(str, cmbTitleCategory, "TitleCategoryid", "TitleCategoryName");
            objMainClass.fnFillComboBox(str, cmbSearchCategoryName, "TitleCategoryid", "TitleCategoryName");
        }
        private void FillStreamData(Int32 TitleCategoryId)
        {
            string str;
            int iCtr;
            DataTable dtDetail;
            if (TitleCategoryId == 0)
            {
                str = "Select * from  tblOnlineStreaming where dealercode!='CLAudio000' and  dealercode='" + cmbSearchAdminCode.Text + "' order by titlecategoryId, StreamName";
            }
            else
            {
                str = "Select * from  tblOnlineStreaming where dealercode!='CLAudio000' and titlecategoryId = " + TitleCategoryId + " and dealercode='" + cmbSearchAdminCode.Text + "' order by titlecategoryId, StreamName";
            }

            dtDetail = objMainClass.fnFillDataTable(str);

            InitilizeStreamGrid();

            if ((dtDetail.Rows.Count > 0))
            {
                for (iCtr = 0; (iCtr <= (dtDetail.Rows.Count - 1)); iCtr++)
                {
                    dgStream.Rows.Add();
                    dgStream.Rows[dgStream.Rows.Count - 1].Cells["StreamId"].Value = dtDetail.Rows[iCtr]["StreamId"];
                    dgStream.Rows[dgStream.Rows.Count - 1].Cells["StreamLink"].Value = dtDetail.Rows[iCtr]["StreamLink"];
                    dgStream.Rows[dgStream.Rows.Count - 1].Cells["StreamName"].Value = dtDetail.Rows[iCtr]["StreamName"];
                    dgStream.Rows[dgStream.Rows.Count - 1].Cells["TitleCatId"].Value = dtDetail.Rows[iCtr]["titlecategoryId"];
                    dgStream.Rows[dgStream.Rows.Count - 1].Cells["AdminCode"].Value = dtDetail.Rows[iCtr]["Dealercode"];
                }

                foreach (DataGridViewRow row in dgStream.Rows)
                {
                    row.Height = 35;
                }
            }
        }
        private void InitilizeStreamGrid()
        {
            if (dgStream.Rows.Count > 0)
            {
                dgStream.Rows.Clear();
            }
            if (dgStream.Columns.Count > 0)
            {
                dgStream.Columns.Clear();
            }

            dgStream.Columns.Add("Streamid", "Stream Id");
            dgStream.Columns["Streamid"].Width = 0;
            dgStream.Columns["Streamid"].Visible = false;
            dgStream.Columns["Streamid"].ReadOnly = true;

            dgStream.Columns.Add("StreamLink", "Stream Link");
            dgStream.Columns["StreamLink"].Width = 0;
            dgStream.Columns["StreamLink"].Visible = false;
            dgStream.Columns["StreamLink"].ReadOnly = true;

            dgStream.Columns.Add("StreamName", "Stream Name");
            dgStream.Columns["StreamName"].Width = 950;
            dgStream.Columns["StreamName"].Visible = true;
            dgStream.Columns["StreamName"].ReadOnly = true;
            dgStream.Columns["StreamName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgStream.Columns.Add("TitleCatId", "TitleCatId");
            dgStream.Columns["TitleCatId"].Width = 0;
            dgStream.Columns["TitleCatId"].Visible = false;
            dgStream.Columns["TitleCatId"].ReadOnly = true;

            dgStream.Columns.Add("AdminCode", "Admin Code");
            dgStream.Columns["AdminCode"].Width = 150;
            dgStream.Columns["AdminCode"].Visible = true;
            dgStream.Columns["AdminCode"].ReadOnly = true;
            dgStream.Columns["AdminCode"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            DataGridViewLinkColumn EditUser = new DataGridViewLinkColumn();
            EditUser.HeaderText = "Edit";
            EditUser.Text = "Edit";
            EditUser.DataPropertyName = "Edit";
            dgStream.Columns.Add(EditUser);
            EditUser.UseColumnTextForLinkValue = true;
            EditUser.Width = 50;
            EditUser.Visible = true;
            dgStream.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            DataGridViewLinkColumn Delete = new DataGridViewLinkColumn();
            Delete.HeaderText = "Delete";
            Delete.Text = "Delete";
            Delete.DataPropertyName = "Delete";
            dgStream.Columns.Add(Delete);
            Delete.UseColumnTextForLinkValue = true;
            Delete.Width = 90;
            Delete.Visible = true;
            dgStream.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
        }

        private void frmOnlineStreaming_Load(object sender, EventArgs e)
        {
            FillTitleCategory();
            FillStreamData(0);
           
        }

        private void cmbSearchCategoryName_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillStreamData(Convert.ToInt32(cmbSearchCategoryName.SelectedValue));
        }

        private void btnRefersh_Click(object sender, EventArgs e)
        {
            ClearFelids();
        }
        private void ClearFelids()
        {
            txtStreamName.Text = "";
            txtStreamLink.Text = "";
            FillTitleCategory();
            FillStreamData(0);
            SaveType = "Save";
            cmbAdminCode.Text = "MyClaud000";
            ModifyStreamId = 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SubmitValidation() == false) return;
            RecordSave();
            ClearFelids();
        }
        private void RecordSave()
        {

            if (StaticClass.constr.State == ConnectionState.Open) StaticClass.constr.Close();
            StaticClass.constr.Open();
            SqlCommand cmd = new SqlCommand("sp_OnlineStream", StaticClass.constr);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@SaveType", SqlDbType.VarChar));
            cmd.Parameters["@SaveType"].Value = SaveType;

            cmd.Parameters.Add(new SqlParameter("@StreamId", SqlDbType.BigInt));
            cmd.Parameters["@StreamId"].Value = ModifyStreamId;

            cmd.Parameters.Add(new SqlParameter("@StreamName", SqlDbType.VarChar));
            cmd.Parameters["@StreamName"].Value = txtStreamName.Text;

            cmd.Parameters.Add(new SqlParameter("@StreamLink", SqlDbType.VarChar));
            cmd.Parameters["@StreamLink"].Value = txtStreamLink.Text;

            cmd.Parameters.Add(new SqlParameter("@titlecategoryId", SqlDbType.BigInt));
            cmd.Parameters["@titlecategoryId"].Value = Convert.ToInt32(cmbTitleCategory.SelectedValue);

            cmd.Parameters.Add(new SqlParameter("@DealerCode", SqlDbType.VarChar));
            cmd.Parameters["@DealerCode"].Value = cmbAdminCode.Text;


            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                StaticClass.constr.Close();
            }
        }
        private Boolean SubmitValidation()
        {
            if (txtStreamName.Text == "")
            {
                MessageBox.Show("The stream name cannot be empty", "Management Panel");
                txtStreamName.Focus();
                return false;
            }
            else if (txtStreamLink.Text == "")
            {
                MessageBox.Show("The stream link cannot be empty", "Management Panel");
                txtStreamLink.Focus();
                return false;
            }

            else if (Convert.ToInt32(cmbTitleCategory.SelectedValue) == 0)
            {
                MessageBox.Show("Select a title category", "Management Panel");
                cmbTitleCategory.Focus();
                return false;
            }
            return true;
        }

        private void dgStream_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (e.ColumnIndex == 5)
            {
                SaveType = "Modify";
                ModifyStreamId = Convert.ToInt32(dgStream.Rows[e.RowIndex].Cells[0].Value);
                txtStreamLink.Text = dgStream.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtStreamName.Text = dgStream.Rows[e.RowIndex].Cells[2].Value.ToString();
                cmbAdminCode.Text = dgStream.Rows[e.RowIndex].Cells[4].Value.ToString();
                cmbTitleCategory.SelectedValue = dgStream.Rows[e.RowIndex].Cells[3].Value;
            }
            if (e.ColumnIndex == 6)
            {
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;
                result = MessageBox.Show("Are you sure to delete ?", "Management Panel", buttons);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    if (StaticClass.constr.State == ConnectionState.Open) StaticClass.constr.Close();
                    StaticClass.constr.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = StaticClass.constr;
                    cmd.CommandText = "delete from tblOnlineStreaming where streamid=" + Convert.ToInt32(dgStream.Rows[e.RowIndex].Cells[0].Value);
                    cmd.ExecuteNonQuery();
                    StaticClass.constr.Close();
                    ClearFelids();
                }
            }
        }

        private void cmbSearchAdminCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cmbSearchCategoryName.SelectedValue) == 0)
            {
                FillStreamData(0);
            }
            else
            {
                FillStreamData(Convert.ToInt32(cmbSearchCategoryName.SelectedValue));
            }
        }

       
 
   
        
        private void tbcMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
