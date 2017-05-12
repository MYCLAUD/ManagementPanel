using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ManagementPanel
{
    public partial class frmSpecialPlaylistFormat : Form
    {
        gblClass ObjMainClass = new gblClass();
        string SearchText = "";
        Int32 ModifyPlaylistId = 0;
        string pAction = "New";
        public frmSpecialPlaylistFormat()
        {
            InitializeComponent();
            FillLocalPlaylist();
            string mType = "";
            if (rdoAudio.Checked == true)
            {
                mType = "Audio";
            }
            if (rdoVideo.Checked == true)
            {
                mType = "Video";
            }
            string str = "SELECT TOP (500) Titles.TitleID, Titles.Title, Titles.Time, Artists.Name as ArtistName, Albums.Name AS AlbumName, isnull(Titles.AlenkaTempo,'') as Tempo,isnull(tbAlenkaGenre.genre,'') as genre, Titles.titleyear FROM Titles INNER JOIN Albums ON Titles.AlbumID = Albums.AlbumID INNER JOIN Artists ON Titles.ArtistID = Artists.ArtistID LEFT OUTER JOIN tbAlenkaGenre ON Titles.AlenkaGenreId = tbAlenkaGenre.AlenkaGenreId    where titlecategoryid=4  and mediatype='" + mType+"' order by TitleID desc";
            FillGrid(str);
            tbcMain.Dock = DockStyle.Fill;
            FillFormat();

        }
        private void InitilizeLocalGrid()
        {
            if (dgLocalPlaylist.Rows.Count > 0)
            {
                dgLocalPlaylist.Rows.Clear();
            }
            if (dgLocalPlaylist.Columns.Count > 0)
            {
                dgLocalPlaylist.Columns.Clear();
            }

            dgLocalPlaylist.Columns.Add("playlistId", "playlist Id");
            dgLocalPlaylist.Columns["playlistId"].Width = 0;
            dgLocalPlaylist.Columns["playlistId"].Visible = false;
            dgLocalPlaylist.Columns["playlistId"].ReadOnly = true;
            dgLocalPlaylist.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            dgLocalPlaylist.Columns.Add("playlistname", "Playlist Name");
            dgLocalPlaylist.Columns["playlistname"].Width = 250;
            dgLocalPlaylist.Columns["playlistname"].Visible = true;
            dgLocalPlaylist.Columns["playlistname"].ReadOnly = true;
            dgLocalPlaylist.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgLocalPlaylist.Columns["playlistname"].CellTemplate.Style.Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Regular);

            DataGridViewLinkColumn EditPlaylist = new DataGridViewLinkColumn();
            EditPlaylist.HeaderText = "Edit";
            EditPlaylist.Text = "Edit";
            EditPlaylist.DataPropertyName = "Edit";
            EditPlaylist.LinkBehavior = LinkBehavior.SystemDefault;
            dgLocalPlaylist.Columns.Add(EditPlaylist);
            EditPlaylist.UseColumnTextForLinkValue = true;
            EditPlaylist.Width = 50;
            EditPlaylist.Visible = true;
            dgLocalPlaylist.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            EditPlaylist.CellTemplate.Style.Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Regular);

            DataGridViewLinkColumn DeleteSong = new DataGridViewLinkColumn();
            DeleteSong.HeaderText = "Delete";
            DeleteSong.Text = "Delete";
            DeleteSong.DataPropertyName = "Delete";
            DeleteSong.LinkColor = Color.FromArgb(64, 64, 64);
            DeleteSong.CellTemplate.Style.Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Regular);
            DeleteSong.LinkBehavior = LinkBehavior.SystemDefault;
            dgLocalPlaylist.Columns.Add(DeleteSong);
            DeleteSong.UseColumnTextForLinkValue = true;
            DeleteSong.Width = 55;
            dgLocalPlaylist.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

        }

        private void FillLocalPlaylist()
        {

            string str = "";
            string strGetCount = "";
            int iCtr;
            DataTable dtDetail;
            DataTable dtGetCount;
            str = "select * from tbSpecialPlaylists where formatid = " + Convert.ToInt32(cmbFormat.SelectedValue) + " order by splPlaylistName";
            dtDetail = ObjMainClass.fnFillDataTable(str);

            InitilizeLocalGrid();
            if ((dtDetail.Rows.Count > 0))
            {
                if (dtDetail.Rows[0]["mediatype"].ToString() == "Audio")
                {
                    rdoSaveAudio.Checked = true;
                }
                if (dtDetail.Rows[0]["mediatype"].ToString() == "Video")
                {
                    rdoSaveVideo.Checked = true;
                }
                for (iCtr = 0; (iCtr <= (dtDetail.Rows.Count - 1)); iCtr++)
                {
                    dgLocalPlaylist.Rows.Add();
                    dgLocalPlaylist.Rows[dgLocalPlaylist.Rows.Count - 1].Cells[0].Value = dtDetail.Rows[iCtr]["splPlaylistId"];

                    strGetCount = "select Count(*) as Total from  tbSpecialPlaylists_Titles where splPlaylistId =" + dtDetail.Rows[iCtr]["splPlaylistId"] + " ";
                    dtGetCount = ObjMainClass.fnFillDataTable(strGetCount);

                    dgLocalPlaylist.Rows[dgLocalPlaylist.Rows.Count - 1].Cells[1].Value = dtDetail.Rows[iCtr]["splPlaylistName"] + "  (" + dtGetCount.Rows[0]["Total"] + ")";
                    dgLocalPlaylist.Rows[dgLocalPlaylist.Rows.Count - 1].Cells[2].Value = "";


                }
                foreach (DataGridViewRow row in dgLocalPlaylist.Rows)
                {
                    row.Height = 35;
                }
                dgLocalPlaylist.CurrentCell = dgLocalPlaylist.Rows[0].Cells[1];
                dgLocalPlaylist.Rows[0].Selected = true;
                PopulateInputFileTypeDetail(dgPlaylist, Convert.ToInt32(dgLocalPlaylist.Rows[0].Cells[0].Value), false);
            }
            else
            {
                InitilizeGrid(dgPlaylist);
            }


        }

        private void InitilizeGrid(DataGridView dgGrid)
        {
            if (dgGrid.Rows.Count > 0)
            {
                dgGrid.Rows.Clear();
            }
            if (dgGrid.Columns.Count > 0)
            {
                dgGrid.Columns.Clear();
            }

            dgGrid.Columns.Add("songid", "song Id");
            dgGrid.Columns["songid"].Width = 0;
            dgGrid.Columns["songid"].Visible = false;
            dgGrid.Columns["songid"].ReadOnly = true;


            dgGrid.Columns.Add("songname", "Title");
            dgGrid.Columns["songname"].Width = 420;
            dgGrid.Columns["songname"].Visible = true;
            dgGrid.Columns["songname"].ReadOnly = true;
            dgGrid.Columns["songname"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgGrid.Columns.Add("Length", "Length");
            dgGrid.Columns["Length"].Width = 70;
            dgGrid.Columns["Length"].Visible = true;
            dgGrid.Columns["Length"].ReadOnly = true;
            dgGrid.Columns["Length"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            dgGrid.Columns.Add("Artist", "Artist");
            dgGrid.Columns["Artist"].Width = 190;
            dgGrid.Columns["Artist"].Visible = true;
            dgGrid.Columns["Artist"].ReadOnly = true;
            dgGrid.Columns["Artist"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            dgGrid.Columns.Add("Album", "Album");
            dgGrid.Columns["Album"].Width = 190;
            
                dgGrid.Columns["Album"].Visible = true;
             
            dgGrid.Columns["Album"].ReadOnly = true;
            dgGrid.Columns["Album"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;


            dgGrid.Columns.Add("Genre", "Genre");
            dgGrid.Columns["Genre"].Width = 150;
             
                dgGrid.Columns["Genre"].Visible = true;
            
            dgGrid.Columns["Genre"].ReadOnly = true;
            dgGrid.Columns["Genre"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            dgGrid.Columns.Add("Tempo", "Tempo");
            dgGrid.Columns["Tempo"].Width = 60;
            dgGrid.Columns["Tempo"].Visible = true;
            dgGrid.Columns["Tempo"].ReadOnly = true;
            dgGrid.Columns["Tempo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            dgGrid.Columns.Add("year", "year");
            dgGrid.Columns["year"].Width = 60;
            dgGrid.Columns["year"].Visible = true;
            dgGrid.Columns["year"].ReadOnly = true;
            dgGrid.Columns["year"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;


            dgGrid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, System.Drawing.FontStyle.Regular);
            dgGrid.ColumnHeadersDefaultCellStyle.BackColor = Color.DimGray;
            dgGrid.EnableHeadersVisualStyles = false;
            dgGrid.ColumnHeadersHeight = 30;
            dgGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

        }

        private void PopulateInputFileTypeDetail(DataGridView dgGrid, Int32 currentPlayRow, Boolean IsBestOf)
        {
            string mlsSql = "";
            string TitleTime = "";
            var Special_Name = "";
            string Special_Change = "";
            Int32 iCtr = 0;
            DataTable dtDetail = new DataTable();
            if (IsBestOf == false)
            {
                mlsSql = "SELECT  Titles.TitleID, rtrim(ltrim(Titles.Title)) as Title, Titles.Time,rtrim(ltrim(Albums.Name)) AS AlbumName ,";
                mlsSql = mlsSql + " Titles.TitleYear ,  rtrim(ltrim(Artists.Name)) as ArtistName , isnull(tbAlenkaGenre.genre,'') as genre, isnull(Titles.AlenkaTempo,'') as Tempo  FROM   tbSpecialPlaylists_Titles  ";
                mlsSql = mlsSql + " INNER JOIN Titles ON tbSpecialPlaylists_Titles.TitleID = Titles.TitleID   ";
                mlsSql = mlsSql + " INNER JOIN Albums ON Titles.AlbumID = Albums.AlbumID  ";
                mlsSql = mlsSql + " INNER JOIN Artists ON Titles.ArtistID = Artists.ArtistID  ";
                mlsSql = mlsSql + " LEFT OUTER JOIN tbAlenkaGenre ON Titles.AlenkaGenreId = tbAlenkaGenre.AlenkaGenreId  "; 
                mlsSql = mlsSql + " where tbSpecialPlaylists_Titles.splPlaylistId= " + Convert.ToInt32(currentPlayRow) + " order by Titles.Title ";
            }
            else
            {
                mlsSql = "SELECT  Titles.TitleID, ltrim(Titles.Title) as Title, Titles.Time,ltrim(Albums.Name) AS AlbumName ,";
                mlsSql = mlsSql + " Titles.TitleYear ,  ltrim(Artists.Name) as ArtistName, isnull(tbAlenkaGenre.genre,'') as genre, isnull(Titles.AlenkaTempo,'') as Tempo  FROM  TitlesInPlaylists  ";
                mlsSql = mlsSql + " INNER JOIN Titles ON TitlesInPlaylists.TitleID = Titles.TitleID    ";
                mlsSql = mlsSql + " INNER JOIN Albums ON Titles.AlbumID = Albums.AlbumID  ";
                mlsSql = mlsSql + " INNER JOIN Artists ON Titles.ArtistID = Artists.ArtistID   ";
                mlsSql = mlsSql + " LEFT OUTER JOIN tbAlenkaGenre ON Titles.AlenkaGenreId = tbAlenkaGenre.AlenkaGenreId  ";
                mlsSql = mlsSql + " where TitlesInPlaylists.PlaylistID=" + Convert.ToInt32(currentPlayRow) + " order by Titles.Title ";
            }




            dtDetail = ObjMainClass.fnFillDataTable(mlsSql);
            InitilizeGrid(dgGrid);
            if ((dtDetail.Rows.Count > 0))
            {
                for (iCtr = 0; (iCtr <= (dtDetail.Rows.Count - 1)); iCtr++)
                {
                    dgGrid.Rows.Add();
                    dgGrid.Rows[dgGrid.Rows.Count - 1].Cells["songid"].Value = dtDetail.Rows[iCtr]["TitleID"];

                    Special_Name = "";
                    Special_Change = "";
                    Special_Name = dtDetail.Rows[iCtr]["Title"].ToString();
                    Special_Change = Special_Name.Replace("??$$$??", "'");
                    dgGrid.Rows[dgGrid.Rows.Count - 1].Cells["songname"].Value = Special_Change;

                    string str = dtDetail.Rows[iCtr]["Time"].ToString();
                    string[] arr = str.Split(':');
                    TitleTime = arr[1] + ":" + arr[2];

                    dgGrid.Rows[dgGrid.Rows.Count - 1].Cells["Length"].Value = TitleTime;

                    Special_Name = "";
                    Special_Change = "";

                    Special_Name = dtDetail.Rows[iCtr]["AlbumName"].ToString();
                    Special_Change = Special_Name.Replace("??$$$??", "'");
                    dgGrid.Rows[dgGrid.Rows.Count - 1].Cells["Album"].Value = Special_Change;

                    Special_Name = "";
                    Special_Change = "";

                    Special_Name = dtDetail.Rows[iCtr]["ArtistName"].ToString();
                    Special_Change = Special_Name.Replace("??$$$??", "'");
                    dgGrid.Rows[dgGrid.Rows.Count - 1].Cells["Artist"].Value = Special_Change;

                    dgGrid.Rows[dgGrid.Rows.Count - 1].Cells["genre"].Value = dtDetail.Rows[iCtr]["genre"];

                    dgGrid.Rows[dgGrid.Rows.Count - 1].Cells["Tempo"].Value = dtDetail.Rows[iCtr]["Tempo"];
                    dgGrid.Rows[dgGrid.Rows.Count - 1].Cells["year"].Value = dtDetail.Rows[iCtr]["TitleYear"];

                    dgGrid.Rows[dgGrid.Rows.Count - 1].Cells["songname"].Style.Font = new Font("Segoe UI", 10, System.Drawing.FontStyle.Regular);
                    dgGrid.Rows[dgGrid.Rows.Count - 1].Cells["Length"].Style.Font = new Font("Segoe UI", 9, System.Drawing.FontStyle.Regular);
                    dgGrid.Rows[dgGrid.Rows.Count - 1].Cells["Album"].Style.Font = new Font("Segoe UI", 9, System.Drawing.FontStyle.Regular);
                    dgGrid.Rows[dgGrid.Rows.Count - 1].Cells["Artist"].Style.Font = new Font("Segoe UI", 9, System.Drawing.FontStyle.Regular);
                    dgGrid.Rows[dgGrid.Rows.Count - 1].Cells["Genre"].Style.Font = new Font("Segoe UI", 9, System.Drawing.FontStyle.Regular);
                    dgGrid.Rows[dgGrid.Rows.Count - 1].Cells["Tempo"].Style.Font = new Font("Segoe UI", 9, System.Drawing.FontStyle.Regular);
                    
                    //dgGrid.Rows[dgGrid.Rows.Count - 1].Cells["songname"].Style.Font = new Font("Segoe UI", 11, System.Drawing.FontStyle.Regular);
                    //dgGrid.Rows[dgGrid.Rows.Count - 1].Cells["Length"].Style.Font = new Font("Segoe UI", 11, System.Drawing.FontStyle.Regular);
                    //dgGrid.Rows[dgGrid.Rows.Count - 1].Cells["genre"].Style.Font = new Font("Segoe UI", 9, System.Drawing.FontStyle.Regular);
                   //dgGrid.Rows[dgGrid.Rows.Count - 1].Cells["Artist"].Style.Font = new Font("Segoe UI", 11, System.Drawing.FontStyle.Regular);
                }
            }
            foreach (DataGridViewRow row in dgGrid.Rows)
            {
                row.Height = 30;
            }
        }

        private void dgLocalPlaylist_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            if (e.ColumnIndex == 1)
            {
                if (e.RowIndex >= 0)
                {
                    PopulateInputFileTypeDetail(dgPlaylist, Convert.ToInt32(dgLocalPlaylist.Rows[e.RowIndex].Cells[0].Value), false);
                }
            }
            if (e.ColumnIndex == 2)
            {
                if (e.RowIndex >= 0)
                {
                    string str45 = dgLocalPlaylist.Rows[e.RowIndex].Cells[1].Value.ToString();
                    string[] arr = str45.Split('(');
                    txtPlaylistName.Text = arr[0].Trim();
                    ModifyPlaylistId = Convert.ToInt32(dgLocalPlaylist.Rows[e.RowIndex].Cells[0].Value);
                    pAction = "Modify";
                    txtPlaylistName.Focus();
                }
            }
            if (e.ColumnIndex == 3)
            {
                if (e.RowIndex >= 0)
                {
                    DialogResult result;
                    result = MessageBox.Show("Are you sure to delete ?", "Management Panel", MessageBoxButtons.YesNo);
                    if (result == System.Windows.Forms.DialogResult.Yes)
                    {
                        string strDel = "";
                        DataTable dtDetail = new DataTable();
                        strDel = "select tbSpecialPlaylistSchedule_Token.* from tbSpecialPlaylistSchedule";
                        strDel = strDel + " inner join tbSpecialPlaylistSchedule_Token on tbSpecialPlaylistSchedule_Token.pschid= tbSpecialPlaylistSchedule.pschid";
                        strDel = strDel + " where tbSpecialPlaylistSchedule.splplaylistid = " + Convert.ToInt32(dgLocalPlaylist.Rows[e.RowIndex].Cells[0].Value);


                        dtDetail = ObjMainClass.fnFillDataTable(strDel);
                        if ((dtDetail.Rows.Count > 0))
                        {
                            MessageBox.Show("This playlist cannot be deleted, as it is assigned to tokens", "Management Panel");
                            return;
                        }


                        strDel = "";
                        strDel = "delete from tbSpecialPlaylists_Titles where splPlaylistId= " + Convert.ToInt32(dgLocalPlaylist.Rows[e.RowIndex].Cells[0].Value);
                        if (StaticClass.constr.State == ConnectionState.Open) StaticClass.constr.Close();
                        StaticClass.constr.Open();
                        SqlCommand cmd = new SqlCommand(strDel, StaticClass.constr);
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                        StaticClass.constr.Close();

                        strDel = "";
                        strDel = "delete from tbSpecialPlaylists where splPlaylistId= " + Convert.ToInt32(dgLocalPlaylist.Rows[e.RowIndex].Cells[0].Value);
                        if (StaticClass.constr.State == ConnectionState.Open) StaticClass.constr.Close();
                        StaticClass.constr.Open();
                        cmd = new SqlCommand(strDel, StaticClass.constr);
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                        StaticClass.constr.Close();

                        dgLocalPlaylist.Rows.RemoveAt(e.RowIndex);

                        if (dgLocalPlaylist.Rows.Count > 0)
                        {
                            PopulateInputFileTypeDetail(dgPlaylist, Convert.ToInt32(dgLocalPlaylist.Rows[0].Cells[0].Value), false);
                        }
                        else
                        {
                            InitilizeGrid(dgPlaylist);
                        }

                    }
                }
            }
        }

        private void txtPlaylistName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 39 || Convert.ToInt32(e.KeyChar) == 37)
            {
                e.Handled = true;
                return;
            }
        }
        private void FillGrid(string str)
        {
            int iCtr;

            string TitleTime = "";
            try
            {
                InitilizeGrid(dgCommanGrid);
                DataTable dtDetail;
                dtDetail = ObjMainClass.fnFillDataTable(str);
                if ((dtDetail.Rows.Count > 0))
                {

                    for (iCtr = 0; (iCtr <= (dtDetail.Rows.Count - 1)); iCtr++)
                    {

                        dgCommanGrid.Rows.Add();
                        dgCommanGrid.Rows[dgCommanGrid.Rows.Count - 1].Cells["songid"].Value = dtDetail.Rows[iCtr]["TitleID"];
                        dgCommanGrid.Rows[dgCommanGrid.Rows.Count - 1].Cells["songname"].Value = dtDetail.Rows[iCtr]["Title"];

                        string strTime = dtDetail.Rows[iCtr]["Time"].ToString();
                        string[] arr = strTime.Split(':');
                        TitleTime = arr[1] + ":" + arr[2];

                        dgCommanGrid.Rows[dgCommanGrid.Rows.Count - 1].Cells["Length"].Value = TitleTime;
                        dgCommanGrid.Rows[dgCommanGrid.Rows.Count - 1].Cells["Artist"].Value = dtDetail.Rows[iCtr]["ArtistName"];
                        dgCommanGrid.Rows[dgCommanGrid.Rows.Count - 1].Cells["Album"].Value = dtDetail.Rows[iCtr]["AlbumName"];

                        
                            dgCommanGrid.Rows[dgCommanGrid.Rows.Count - 1].Cells["Genre"].Value = dtDetail.Rows[iCtr]["genre"];
                            dgCommanGrid.Rows[dgCommanGrid.Rows.Count - 1].Cells["Tempo"].Value = dtDetail.Rows[iCtr]["Tempo"];
                        dgCommanGrid.Rows[dgCommanGrid.Rows.Count - 1].Cells["year"].Value = dtDetail.Rows[iCtr]["TitleYear"];

                        dgCommanGrid.Rows[dgCommanGrid.Rows.Count - 1].Cells["Artist"].Style.Font = new Font("Segoe UI", 9, System.Drawing.FontStyle.Regular);
                        dgCommanGrid.Rows[dgCommanGrid.Rows.Count - 1].Cells["Album"].Style.Font = new Font("Segoe UI", 9, System.Drawing.FontStyle.Regular);
                        dgCommanGrid.Rows[dgCommanGrid.Rows.Count - 1].Cells["Genre"].Style.Font = new Font("Segoe UI", 9, System.Drawing.FontStyle.Regular);

                    }
                    foreach (DataGridViewRow row in dgCommanGrid.Rows)
                    {
                        row.Height = 30;
                    }
                    //dgCommanGrid.Sort(dgCommanGrid.Columns[1], ListSortDirection.Ascending);
                }

            }

            catch
            {

                return;
            }
        }

        private void picSavePlaylist_Click(object sender, EventArgs e)
        {
            Save(txtPlaylistName.Text.Trim());
             
        }

        private void picSearch_Click(object sender, EventArgs e)
        {
            string mType = "";
            if (rdoAudio.Checked == true)
            {
                mType = "Audio";
            }
            if (rdoVideo.Checked == true)
            {
                mType = "Video"; 
            }
            if (txtSearch.Visible == true)
            {
                if (txtSearch.Text == "")
                {
                        string str = "SELECT TOP (500) Titles.TitleID, Titles.Title, Titles.Time, Artists.Name as ArtistName, Albums.Name AS AlbumName, isnull(Titles.AlenkaTempo,'') as Tempo,isnull(tbAlenkaGenre.genre,'') as genre , Titles.titleyear FROM Titles INNER JOIN Albums ON Titles.AlbumID = Albums.AlbumID INNER JOIN Artists ON Titles.ArtistID = Artists.ArtistID LEFT OUTER JOIN tbAlenkaGenre ON Titles.AlenkaGenreId = tbAlenkaGenre.AlenkaGenreId    where titlecategoryid=4 and mediaType='" + mType + "' order by TitleID desc";
                        FillGrid(str);
                        return;
                }
                if (txtSearch.Text.Length < 2)
                {
                    MessageBox.Show("Enter minimum 2 characters for a search function.", "Token Admin");
                    return;
                }

                SearchText = txtSearch.Text.Trim();
                CommanSearch();
                txtSearch.TextAlign = HorizontalAlignment.Left;
                txtSearch.ForeColor = Color.White;
                txtSearch.Text = "";
            }
        }

        private void CommanSearch()
        {
            string stSearch = "";
            string strAlbum = "";
                if (rdoTitle.Checked == true)
                {
                    stSearch = "spSearch_Title_Comman '" + SearchText + "'";
                    FillGrid(stSearch);
                }
                else if (rdoArtist.Checked == true)
                {
                    stSearch = "spSearch_Artist_Comman '" + SearchText + "'";
                    FillGrid(stSearch);
                }
                else if (rdoAlbum.Checked == true)
                {
                    strAlbum = "spSearch_Album_Copyright '" + SearchText + "'";
                    ObjMainClass.fnFillComboBoxSpl(strAlbum, cmbAlbum, "AlbumID", "Name", "");
                    cmbAlbum.Visible = true;
                    txtSearch.Visible = false;
                }
        }

        private void rdoTitle_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoTitle.Checked == true)
            {
                cmbAlbum.Visible = false;
                txtSearch.Visible = true;
            }
        }

        private void rdoArtist_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoArtist.Checked == true)
            {
                cmbAlbum.Visible = false;
                txtSearch.Visible = true;
            }
        }

        private void rdoAlbum_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoAlbum.Checked == true)
            {
                cmbAlbum.Visible = false;
                txtSearch.Visible = true;
            }
        }

        private void cmbAlbum_SelectedIndexChanged(object sender, EventArgs e)
        {
            string mType = "";
            if (rdoAudio.Checked == true)
            {
                mType = "Audio";
            }
            if (rdoVideo.Checked == true)
            {
                mType = "Video";
            }
            string stSearch = "";
            if (rdoAlbum.Checked == true)
            {
                stSearch = "spSearch_Album_spl " + cmbAlbum.SelectedValue;
            }
            else if (rdoGenre.Checked==true)
            {
                stSearch = " select distinct TitleID, ltrim(Title) as Title,Time, ltrim(ArtistName) as ArtistName, ltrim(AlbumName) as AlbumName , isnull(genre,'') as genre, Tempo ,titleyear from( ";
                stSearch = stSearch + " SELECT  Titles.TitleID, Titles.Title,Titles.Time, Artists.Name as ArtistName, Albums.Name AS AlbumName, tbAlenkaGenre.genre, isnull(Titles.AlenkaTempo,'') as Tempo,Titles.titleyear FROM Titles ";
                stSearch = stSearch + " INNER JOIN Albums ON Titles.AlbumID = Albums.AlbumID  ";
                stSearch = stSearch + " INNER JOIN Artists ON Titles.ArtistID = Artists.ArtistID  ";
                stSearch = stSearch + " LEFT OUTER JOIN tbAlenkaGenre ON Titles.AlenkaGenreId = tbAlenkaGenre.AlenkaGenreId  ";
                stSearch = stSearch + " where Titles.AlenkaGenreId= " + Convert.ToInt32(cmbAlbum.SelectedValue) + " and Titles.mediatype='" + mType + "'";
                    
                stSearch = stSearch + " ) as d  order by TitleID desc    ";
            }
            else if (rdoTempo.Checked == true)
            {
                stSearch = " select distinct TitleID, ltrim(Title) as Title,Time, ltrim(ArtistName) as ArtistName, ltrim(AlbumName) as AlbumName , isnull(genre,'') as genre, Tempo, titleyear from( ";
                stSearch = stSearch + " SELECT  Titles.TitleID, Titles.Title,Titles.Time, Artists.Name as ArtistName, Albums.Name AS AlbumName, tbAlenkaGenre.genre, isnull(Titles.AlenkaTempo,'') as Tempo , Titles.titleyear FROM Titles ";
                stSearch = stSearch + " INNER JOIN Albums ON Titles.AlbumID = Albums.AlbumID  ";
                stSearch = stSearch + " INNER JOIN Artists ON Titles.ArtistID = Artists.ArtistID  ";
                stSearch = stSearch + " LEFT OUTER JOIN tbAlenkaGenre ON Titles.AlenkaGenreId = tbAlenkaGenre.AlenkaGenreId  ";
                stSearch = stSearch + " where Titles.alenkatempo= '" + cmbAlbum.Text + "'  and Titles.mediatype='" + mType + "'";

                stSearch = stSearch + " ) as d  order by TitleID desc    ";
            }
            else if (rdoCategory.Checked == true)
            {
                stSearch = " select distinct TitleID, ltrim(Title) as Title,Time, ltrim(ArtistName) as ArtistName, ltrim(AlbumName) as AlbumName , isnull(genre,'') as genre, Tempo , titleyear from( ";
                stSearch = stSearch + " SELECT  Titles.TitleID, Titles.Title,Titles.Time, Artists.Name as ArtistName, Albums.Name AS AlbumName, tbAlenkaGenre.genre, isnull(Titles.AlenkaTempo,'') as Tempo , Titles.titleyear FROM Titles ";
                stSearch = stSearch + " INNER JOIN Albums ON Titles.AlbumID = Albums.AlbumID  ";
                stSearch = stSearch + " INNER JOIN Artists ON Titles.ArtistID = Artists.ArtistID  ";
                stSearch = stSearch + " LEFT OUTER JOIN tbAlenkaGenre ON Titles.AlenkaGenreId = tbAlenkaGenre.AlenkaGenreId  ";
                stSearch = stSearch + " where Titles.alenkacategory= '" + cmbAlbum.Text + "'  and Titles.mediatype='" + mType + "'";

                stSearch = stSearch + " ) as d  order by TitleID desc    ";
            }
            FillGrid(stSearch);
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Search")
            {
                txtSearch.Text = "";
            }
            txtSearch.TextAlign = HorizontalAlignment.Left;
            txtSearch.ForeColor = Color.White;
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                txtSearch.Text = "Search";
                txtSearch.TextAlign = HorizontalAlignment.Center;
                txtSearch.ForeColor = Color.White;
            }
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 39 || Convert.ToInt32(e.KeyChar) == 37)
            {
                e.Handled = true;
                return;
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            string mType = "";
            if (rdoAudio.Checked == true)
            {
                mType = "Audio";
            }
            if (rdoVideo.Checked == true)
            {
                mType = "Video";
            }

            if (e.KeyCode == Keys.Return)
            {
                if (txtSearch.Text == "")
                {
                        string str = "SELECT TOP (500) Titles.TitleID, Titles.Title, Titles.Time, Artists.Name as ArtistName, Albums.Name AS AlbumName, isnull(Titles.AlenkaTempo,'') as Tempo,isnull(tbAlenkaGenre.genre,'') as genre , Titles.titleyear FROM Titles INNER JOIN Albums ON Titles.AlbumID = Albums.AlbumID INNER JOIN Artists ON Titles.ArtistID = Artists.ArtistID LEFT OUTER JOIN tbAlenkaGenre ON Titles.AlenkaGenreId = tbAlenkaGenre.AlenkaGenreId    where titlecategoryid=4  and mediatype='" + mType + "' order by TitleID desc";
                        FillGrid(str);
                        return;
                }
                if (txtSearch.Text.Length < 2)
                {
                    MessageBox.Show("Enter minimum 2 characters for a search function.", "Token Admin");
                    return;
                }

                SearchText = txtSearch.Text.Trim();
                CommanSearch();
                txtSearch.TextAlign = HorizontalAlignment.Left;
                txtSearch.ForeColor = Color.White;
                txtSearch.Text = "";
            }
        }
        private void PlaylistSaveUpdate(string playlistName)
        {
            string mediatype = "";
            if (rdoSaveAudio.Checked == true)
            {
                mediatype = "Audio";
            }
            if (rdoSaveVideo.Checked == true)
            {
                mediatype = "Video";
            }
            Int32 lPlaylistId = 0;
            if (StaticClass.constr.State == ConnectionState.Open) StaticClass.constr.Close();
            StaticClass.constr.Open();
            SqlCommand cmd = new SqlCommand("spSpecialPlaylists_Save_Update", StaticClass.constr);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@pAction", SqlDbType.VarChar));
            cmd.Parameters["@pAction"].Value = pAction;
            cmd.Parameters.Add(new SqlParameter("@splPlaylistId", SqlDbType.BigInt));
            cmd.Parameters["@splPlaylistId"].Value = ModifyPlaylistId;
            cmd.Parameters.Add(new SqlParameter("@splPlaylistName", SqlDbType.VarChar));
            cmd.Parameters["@splPlaylistName"].Value = playlistName;
            cmd.Parameters.Add(new SqlParameter("@pVersion", SqlDbType.VarChar));
            cmd.Parameters["@pVersion"].Value = "c";
            cmd.Parameters.Add(new SqlParameter("@Formatid", SqlDbType.BigInt));
            cmd.Parameters["@Formatid"].Value = Convert.ToInt32(cmbFormat.SelectedValue);
            cmd.Parameters.Add(new SqlParameter("@mType", SqlDbType.VarChar));
            cmd.Parameters["@mType"].Value = mediatype;

            try
            {
                lPlaylistId = Convert.ToInt32(cmd.ExecuteScalar());
                if (tbcMain.SelectedIndex == 1)
                {
                    if (StaticClass.constr.State == ConnectionState.Open) StaticClass.constr.Close();
                    StaticClass.constr.Open();
                    cmd = new SqlCommand();
                    cmd.Connection = StaticClass.constr;
                    cmd.CommandText = "insert into tbSpecialPlaylists_Titles select " + lPlaylistId + ",titleid from titlesinplaylists where playlistid=" + Convert.ToInt32(dgBestofPlaylist.Rows[dgBestofPlaylist.CurrentCell.RowIndex].Cells[0].Value);
                    cmd.ExecuteNonQuery();
                    StaticClass.constr.Close();
                }
                if (tbcMain.SelectedIndex == 2)
                {
                    if (StaticClass.constr.State == ConnectionState.Open) StaticClass.constr.Close();
                    StaticClass.constr.Open();
                    cmd = new SqlCommand();
                    cmd.Connection = StaticClass.constr;
                    cmd.CommandText = "insert into tbSpecialPlaylists_Titles select " + lPlaylistId + ",titleid from tbSpecialPlaylists_Titles where splPlaylistid=" + Convert.ToInt32(dgLibrary.Rows[dgLibrary.CurrentCell.RowIndex].Cells[0].Value);
                    cmd.ExecuteNonQuery();
                    StaticClass.constr.Close();
                }
            }
            catch (Exception ex)
            {
                // throw new ApplicationException ("Data error.");
                // MessageBox.Show(ex.Message);
            }
            finally
            {
                StaticClass.constr.Close();
            }
        }



        private void picAddtoPlaylist_Click(object sender, EventArgs e)
        {
            string lStr;
            try
            {
                if (tbcMain.SelectedIndex == 1)
                {
                    MessageBox.Show("It is not allowed to modify Best of Playlists", "Management Panel");
                    return;
                }
                for (int i = 0; i < dgCommanGrid.Rows.Count; i++)
                {
                    if (dgCommanGrid.Rows[i].Selected == true)
                    {
                        //If already song add in playlist then this step:-
                        lStr = "select * from tbSpecialPlaylists_Titles where splPlaylistId=" + Convert.ToInt32(dgLocalPlaylist.Rows[dgLocalPlaylist.CurrentCell.RowIndex].Cells[0].Value) + " and TitleID=" + dgCommanGrid.Rows[i].Cells[0].Value;
                        DataSet ds = new DataSet();
                        ds = ObjMainClass.fnFillDataSet(lStr);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                        }
                        else
                        {
                            string TitleTime = "";
                            string Title_id = "";
                            string Title = "";
                            string AlbumName = "";
                            string ArtistName = "";
                            Title_id = dgCommanGrid.Rows[i].Cells["songid"].Value.ToString();
                            Title = dgCommanGrid.Rows[i].Cells["songname"].Value.ToString();
                            TitleTime = dgCommanGrid.Rows[i].Cells["Length"].Value.ToString();
                            AlbumName = dgCommanGrid.Rows[i].Cells["album"].Value.ToString();
                            ArtistName = dgCommanGrid.Rows[i].Cells["Artist"].Value.ToString();
                            dgPlaylist.Rows.Insert(dgPlaylist.Rows.Count, Title_id, Title, TitleTime, ArtistName, AlbumName, dgCommanGrid.Rows[i].Cells["Genre"].Value.ToString(), dgCommanGrid.Rows[i].Cells["Tempo"].Value.ToString());
                            dgPlaylist.Rows[dgPlaylist.Rows.Count - 1].Cells["songname"].Style.Font = new Font("Segoe UI", 10, System.Drawing.FontStyle.Regular);
                            dgPlaylist.Rows[dgPlaylist.Rows.Count - 1].Cells["Length"].Style.Font = new Font("Segoe UI", 9, System.Drawing.FontStyle.Regular);
                            dgPlaylist.Rows[dgPlaylist.Rows.Count - 1].Cells["Album"].Style.Font = new Font("Segoe UI", 9, System.Drawing.FontStyle.Regular);
                            dgPlaylist.Rows[dgPlaylist.Rows.Count - 1].Cells["Artist"].Style.Font = new Font("Segoe UI", 9, System.Drawing.FontStyle.Regular);
                            dgPlaylist.Rows[dgPlaylist.Rows.Count - 1].Cells["Genre"].Style.Font = new Font("Segoe UI", 9, System.Drawing.FontStyle.Regular);
                            dgPlaylist.Rows[dgPlaylist.Rows.Count - 1].Cells["Tempo"].Style.Font = new Font("Segoe UI", 9, System.Drawing.FontStyle.Regular);
                            insert_Playlist_song(dgCommanGrid.Rows[i].Cells[0].Value.ToString(), "No", false);
                            GetSongCounter();
                        }
                    }
                }
                foreach (DataGridViewRow row in dgPlaylist.Rows)
                {
                    row.Height = 30;
                }

            }
            catch
            {


            }
        }

        void insert_Playlist_song(string songid, string GridReset, Boolean IsComeDropSong)
        {
            try
            {
                if (StaticClass.constr.State == ConnectionState.Open) StaticClass.constr.Close();
                StaticClass.constr.Open();
                SqlCommand cmd = new SqlCommand("InsertTitlesInSplPlayLists", StaticClass.constr);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@splPlaylistId", SqlDbType.BigInt));
                cmd.Parameters["@splPlaylistId"].Value = Convert.ToInt32(dgLocalPlaylist.Rows[dgLocalPlaylist.CurrentCell.RowIndex].Cells[0].Value);
                cmd.Parameters.Add(new SqlParameter("@TitleID", SqlDbType.BigInt));
                cmd.Parameters["@TitleID"].Value = songid;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                // throw new ApplicationException("Data error.");
            }
            finally
            {
                // StaticClass.constr.Close();
            }

        }

        private void GetSongCounter()
        {
            string strNew = "";
            DataTable dtDetailNew = new DataTable();
            strNew = "select tbSpecialPlaylists_Titles.splPlaylistId, Count(*) as Total  from tbSpecialPlaylists_Titles ";
            strNew = strNew + " where tbSpecialPlaylists_Titles.splPlaylistId = " + Convert.ToInt32(dgLocalPlaylist.Rows[dgLocalPlaylist.CurrentCell.RowIndex].Cells[0].Value) + " ";
            strNew = strNew + " group by tbSpecialPlaylists_Titles.splPlaylistId ";
            dtDetailNew = ObjMainClass.fnFillDataTable(strNew);
            if ((dtDetailNew.Rows.Count > 0))
            {
                for (int iCtr = 0; (iCtr <= (dgLocalPlaylist.Rows.Count - 1)); iCtr++)
                {
                    if (Convert.ToInt32(dgLocalPlaylist.Rows[iCtr].Cells[0].Value) == Convert.ToInt32(dtDetailNew.Rows[0]["splPlaylistId"]))
                    {
                        string strGetName = dgLocalPlaylist.Rows[iCtr].Cells[1].Value.ToString();
                        string[] arr = strGetName.Split('(');
                        dgLocalPlaylist.Rows[iCtr].Cells[1].Value = arr[0].Trim() + "  (" + dtDetailNew.Rows[0]["Total"] + ")";
                    }
                    // dtDetail.Rows[iCtr]["playlistId"];
                    //  
                }
            }
        }

        private void GetSongCounterLibrary(Int32 splPlaylistId)
        {
            string strNew = "";
            DataTable dtDetailNew = new DataTable();
            strNew = "select tbSpecialPlaylists_Titles.splPlaylistId, Count(*) as Total  from tbSpecialPlaylists_Titles ";
            strNew = strNew + " where tbSpecialPlaylists_Titles.splPlaylistId = " + splPlaylistId + " ";
            strNew = strNew + " group by tbSpecialPlaylists_Titles.splPlaylistId ";
            dtDetailNew = ObjMainClass.fnFillDataTable(strNew);
            if ((dtDetailNew.Rows.Count > 0))
            {
                for (int iCtr = 0; (iCtr <= (dgLibrary.Rows.Count - 1)); iCtr++)
                {
                    if (Convert.ToInt32(dgLibrary.Rows[iCtr].Cells[0].Value) == Convert.ToInt32(dtDetailNew.Rows[0]["splPlaylistId"]))
                    {
                        string strGetName = dgLibrary.Rows[iCtr].Cells[1].Value.ToString();
                        string[] arr = strGetName.Split('(');
                        dgLibrary.Rows[iCtr].Cells[1].Value = arr[0].Trim() + "  (" + dtDetailNew.Rows[0]["Total"] + ")";
                    }
                    // dtDetail.Rows[iCtr]["playlistId"];
                    //  
                }
            }
        }


        private void dgPlaylist_CellClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void dgPlaylist_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {

            }
        }

         

        private void btnNew_Click(object sender, EventArgs e)
        {
           
            txtName.Focus();
            if (Convert.ToInt32(cmbFormat.SelectedValue) == 0)
            {
                txtName.Text = "";
                btnSaveNew.Text = "Save";
            }
            else
            {
                txtName.Text = cmbFormat.Text;
                btnSaveNew.Text = "Update";
            }
            string Localstr = "";
            Localstr = "select isnull(r,224) as R, isnull(g,224) as G , isnull(b,244) as B , stime, eTime,TotalHour,Is24Hour from tbSpecialFormat where formatid= " + Convert.ToInt32(cmbFormat.SelectedValue);
            DataTable dtCommon = new DataTable();
            dtCommon = ObjMainClass.fnFillDataTable(Localstr);

            if ((dtCommon.Rows.Count > 0))
            {
                lblR.Text = dtCommon.Rows[0]["R"].ToString();
                lblG.Text = dtCommon.Rows[0]["G"].ToString();
                lblB.Text = dtCommon.Rows[0]["B"].ToString();
                lblFormatColor.BackColor = Color.FromArgb(Convert.ToInt32(lblR.Text), Convert.ToInt32(lblG.Text), Convert.ToInt32(lblB.Text));
                chk24Hour.Checked = Convert.ToBoolean(dtCommon.Rows[0]["Is24Hour"]);
                dtpsTime.Value = Convert.ToDateTime(string.Format("{0:hh:mm tt}", dtCommon.Rows[0]["sTime"]));
                dtpeTime.Value = Convert.ToDateTime(string.Format("{0:hh:mm tt}", dtCommon.Rows[0]["eTime"]));

            }
            else
            {
                lblR.Text = "224";
                lblG.Text = "224";
                lblB.Text = "224";
                lblFormatColor.BackColor = Color.FromArgb(Convert.ToInt32(lblR.Text), Convert.ToInt32(lblG.Text), Convert.ToInt32(lblB.Text));
                chk24Hour.Checked = false;
                dtpsTime.Value = Convert.ToDateTime(string.Format("{0:hh:mm tt}", DateTime.Now));
                dtpeTime.Value = Convert.ToDateTime(string.Format("{0:hh:mm tt}", DateTime.Now));

            }

            panMainNew.Width = this.Width;
            panMainNew.Height = this.Height;
            panMainNew.BringToFront();
            panMainNew.Location = new Point(0, 0);
            panMainNew.Visible = true;
            txtName.Focus();
        }

        private void cmbFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tbcMain.SelectedIndex == 0)
            {
                FillLocalPlaylist();
            }
        }

        private void lblFormatColor_Click(object sender, EventArgs e)
        {
            ColorDialog cld = new ColorDialog();
            if (cld.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                lblFormatColor.BackColor = cld.Color;
                lblR.Text = cld.Color.R.ToString();
                lblG.Text = cld.Color.G.ToString();
                lblB.Text = cld.Color.B.ToString();
            }
        }

        private void btnNewCancel_Click(object sender, EventArgs e)
        {
            panMainNew.Visible = false;
            txtName.Text = "";
        }

        private void btnSaveNew_Click(object sender, EventArgs e)
        {
            string returnValue = "";
            string strState = "";

            try
            {
                SqlCommand cmd = new SqlCommand("spSaveSpecialFormat", StaticClass.constr);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@FormatId", SqlDbType.BigInt));
                if (btnSaveNew.Text == "Update")
                {
                    cmd.Parameters["@FormatId"].Value = Convert.ToInt32(cmbFormat.SelectedValue);
                }
                else
                {
                    cmd.Parameters["@FormatId"].Value = "0";
                }


                cmd.Parameters.Add(new SqlParameter("@FormatName", SqlDbType.VarChar));
                cmd.Parameters["@FormatName"].Value = txtName.Text;

                cmd.Parameters.Add(new SqlParameter("@R", SqlDbType.Int));
                cmd.Parameters["@R"].Value = lblR.Text;

                cmd.Parameters.Add(new SqlParameter("@G", SqlDbType.Int));
                cmd.Parameters["@G"].Value = lblG.Text;

                cmd.Parameters.Add(new SqlParameter("@B", SqlDbType.Int));
                cmd.Parameters["@B"].Value = lblB.Text;

                cmd.Parameters.Add(new SqlParameter("@DfClientId", SqlDbType.BigInt));
                cmd.Parameters["@DfClientId"].Value = Convert.ToInt32(0);

                cmd.Parameters.Add(new SqlParameter("@pVersion", SqlDbType.VarChar));
                cmd.Parameters["@pVersion"].Value = "c";

                cmd.Parameters.Add(new SqlParameter("@sTime", SqlDbType.DateTime));
                cmd.Parameters["@sTime"].Value = string.Format("{0:hh:mm tt}", dtpsTime.Value);

                cmd.Parameters.Add(new SqlParameter("@eTime", SqlDbType.DateTime));
                cmd.Parameters["@eTime"].Value = string.Format("{0:hh:mm tt}", dtpeTime.Value);

                string startTime = string.Format("{0:hh:mm tt}", dtpsTime.Value);
                string endTime = string.Format("{0:hh:mm tt}", dtpeTime.Value);
                TimeSpan duration = DateTime.Parse(endTime).Subtract(DateTime.Parse(startTime));

                if (chk24Hour.Checked == false)
                {
                    cmd.Parameters.Add(new SqlParameter("@TotalHour", SqlDbType.Int));
                    cmd.Parameters["@TotalHour"].Value = duration.TotalHours;
                }
                else
                {
                    cmd.Parameters.Add(new SqlParameter("@TotalHour", SqlDbType.Int));
                    cmd.Parameters["@TotalHour"].Value = "24";
                }

                cmd.Parameters.Add(new SqlParameter("@Is24Hour", SqlDbType.Bit));
                cmd.Parameters["@Is24Hour"].Value = Convert.ToByte(chk24Hour.Checked);



                if (StaticClass.constr.State == ConnectionState.Open) StaticClass.constr.Close();
                StaticClass.constr.Open();
                returnValue = cmd.ExecuteScalar().ToString();
                if (returnValue != "-2")
                {
                    FillFormat();
                    cmbFormat.SelectedValue = Convert.ToInt32(returnValue);
                    panMainNew.Visible = false;

                }
                if (returnValue == "-2")
                {
                    MessageBox.Show("This format name already exists", "Management Panel");
                    
                    // panMainNew.Visible = false;
                    //  lblCaption.Text = "";
                    txtName.Text = "";
                    return;
                }
            }
            catch (Exception ex) { }
        }

        private void cmbDealer_SelectedIndexChanged(object sender, EventArgs e)
        {
            

             

        }

        private void lblFormatDelete_Click(object sender, EventArgs e)
        {

            DialogResult result;
            if (Convert.ToInt32(cmbFormat.SelectedValue) == 0)
            {
                MessageBox.Show("Please select a format", "Management Panel");
                cmbFormat.Focus();
                return;
            }
            result = MessageBox.Show("Are you sure to delete this format schedule?", "Management Panel", MessageBoxButtons.YesNo);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                string strDel = "";
                DataTable dtDetail = new DataTable();
                strDel = "select * from tbSpecialPlaylistSchedule_Token where pschid in (select pschid from  tbSpecialPlaylistSchedule where formatid= " + Convert.ToInt32(cmbFormat.SelectedValue) + " )";
                dtDetail = ObjMainClass.fnFillDataTable(strDel);
                if ((dtDetail.Rows.Count > 0))
                {
                    MessageBox.Show("This format cannot be deleted, as it is assigned to tokens", "Management Panel");
                    return;
                }
                strDel = "delete from tbSpecialPlaylistSchedule_Weekday where pSchid in (select pSchid from  tbSpecialPlaylistSchedule where formatid= " + Convert.ToInt32(cmbFormat.SelectedValue) + " )";
                if (StaticClass.constr.State == ConnectionState.Open) StaticClass.constr.Close();
                StaticClass.constr.Open();
                SqlCommand cmd = new SqlCommand(strDel, StaticClass.constr);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                StaticClass.constr.Close();

                strDel = "";
                strDel = "delete from tbSpecialPlaylistSchedule_Token where pSchid in (select pSchid from  tbSpecialPlaylistSchedule where formatid= " + Convert.ToInt32(cmbFormat.SelectedValue) + " )";
                if (StaticClass.constr.State == ConnectionState.Open) StaticClass.constr.Close();
                StaticClass.constr.Open();
                cmd = new SqlCommand(strDel, StaticClass.constr);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                StaticClass.constr.Close();

                strDel = "";
                strDel = "delete from tbSpecialPlaylistSchedule where pSchid in (select pSchid from  tbSpecialPlaylistSchedule where formatid= " + Convert.ToInt32(cmbFormat.SelectedValue) + " )";
                if (StaticClass.constr.State == ConnectionState.Open) StaticClass.constr.Close();
                StaticClass.constr.Open();
                cmd = new SqlCommand(strDel, StaticClass.constr);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                StaticClass.constr.Close();


                strDel = "";
                strDel = "delete from tbSpecialPlaylists_Titles where splPlaylistId in (select splplaylistid from tbSpecialPlaylists where formatid=" + Convert.ToInt32(cmbFormat.SelectedValue) + ")";
                if (StaticClass.constr.State == ConnectionState.Open) StaticClass.constr.Close();
                StaticClass.constr.Open();
                cmd = new SqlCommand(strDel, StaticClass.constr);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                StaticClass.constr.Close();

                strDel = "";
                strDel = "delete from tbSpecialPlaylists where formatid= " + Convert.ToInt32(cmbFormat.SelectedValue);
                if (StaticClass.constr.State == ConnectionState.Open) StaticClass.constr.Close();
                StaticClass.constr.Open();
                cmd = new SqlCommand(strDel, StaticClass.constr);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                StaticClass.constr.Close();

                strDel = "";
                strDel = "delete from tbSpecialFormat where formatid= " + Convert.ToInt32(cmbFormat.SelectedValue);
                if (StaticClass.constr.State == ConnectionState.Open) StaticClass.constr.Close();
                StaticClass.constr.Open();
                cmd = new SqlCommand(strDel, StaticClass.constr);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                StaticClass.constr.Close();


                FillFormat();

                InitilizeLocalGrid();
                if (tbcMain.SelectedIndex == 0)
                {
                    InitilizeGrid(dgPlaylist);
                }
                //  FillSaveData();

            }
        }
        private void FillFormat()
        {
            string strState = "";
            strState = "select max(Formatid) as Formatid, formatname from tbSpecialFormat group by formatname";
            ObjMainClass.fnFillComboBox(strState, cmbFormat, "FormatId", "FormatName", "");
        }
        private void txtPlaylistName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Save(txtPlaylistName.Text.Trim());
            }
        }
        private void Save(string playlistName)
        {
            try
            {
                if (playlistName == "")
                {
                    MessageBox.Show("The playlist cannot be empty or without a name.", "Management Panel");
                    txtPlaylistName.Focus();
                    return;
                }
                 
                if (Convert.ToInt32(cmbFormat.SelectedValue) == 0)
                {
                    MessageBox.Show("Please select a format name", "Management Panel");
                    cmbFormat.Focus();
                    return;
                }
                PlaylistSaveUpdate(playlistName);
                txtPlaylistName.Text = "";
                playlistName = "";
                pAction = "New";
                if (tbcMain.SelectedIndex != 1)
                {
                    FillLocalPlaylist();
                }
                else
                {
                    //  MessageBox.Show("Best of playlist is copied", "Management Panel");
                }
                ModifyPlaylistId = 0;
            }
            catch
            {

                return;
            }
        }


        private void InitilizeCommanOptionGrid(DataGridView Grid_Name)
        {
            if (Grid_Name.Rows.Count > 0)
            {
                Grid_Name.Rows.Clear();
            }
            if (Grid_Name.Columns.Count > 0)
            {
                Grid_Name.Columns.Clear();
            }

            Grid_Name.Columns.Add("playlistId", "playlist Id");
            Grid_Name.Columns["playlistId"].Width = 0;
            Grid_Name.Columns["playlistId"].Visible = false;
            Grid_Name.Columns["playlistId"].ReadOnly = true;

            Grid_Name.Columns.Add("CommanName", "Comman Name");
            Grid_Name.Columns["CommanName"].Visible = true;
            Grid_Name.Columns["CommanName"].ReadOnly = true;
            Grid_Name.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            Grid_Name.Columns["CommanName"].CellTemplate.Style.Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Regular);

            DataGridViewLinkColumn Addinformat = new DataGridViewLinkColumn();
            Addinformat.HeaderText = "Addinformat";
            Addinformat.Text = "Add in format";
            Addinformat.DataPropertyName = "Addinformat";
            Grid_Name.Columns.Add(Addinformat);
            Addinformat.UseColumnTextForLinkValue = true;
            Addinformat.Width = 85;
            Addinformat.Visible = true;
            Addinformat.CellTemplate.Style.Font = new System.Drawing.Font("Segoe UI", 9, System.Drawing.FontStyle.Regular);
            Grid_Name.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;


        }
        private void FillCommanGrid(DataGridView Grid_Name, string Query)
        {
            int iCtr;
            string str = Query;
            Boolean isTrue = false;
            try
            {
                InitilizeCommanOptionGrid(Grid_Name);
                DataTable dtDetail;
                DataTable dtGetCount = new DataTable();
                dtDetail = ObjMainClass.fnFillDataTable(str);
                if ((dtDetail.Rows.Count > 0))
                {
                    for (iCtr = 0; (iCtr <= (dtDetail.Rows.Count - 1)); iCtr++)
                    {

                        Grid_Name.Rows.Add();
                        Grid_Name.Rows[Grid_Name.Rows.Count - 1].Cells[0].Value = dtDetail.Rows[iCtr]["IdName"];
                        if (Grid_Name.Name == "dgBestofPlaylist")
                        {
                            str = "select Count(*) as Total from  TitlesInPlaylists where PlaylistID =" + dtDetail.Rows[iCtr]["IdName"] + " ";
                        }
                        else
                        {
                            str = "select Count(*) as Total from  tbSpecialPlaylists_Titles where splPlaylistid =" + dtDetail.Rows[iCtr]["IdName"] + " ";
                        }
                        dtGetCount = ObjMainClass.fnFillDataTable(str);
                        Grid_Name.Rows[Grid_Name.Rows.Count - 1].Cells[1].Value = dtDetail.Rows[iCtr]["textname"] + "  (" + dtGetCount.Rows[0]["Total"] + ")";
                    }

                    foreach (DataGridViewRow row in Grid_Name.Rows)
                    {
                        row.Height = 30;
                    }
                    

                    //PopulateInputFileTypeDetail(dgPlaylist, Convert.ToInt32(Grid_Name.Rows[Grid_Name.CurrentCell.RowIndex].Cells[0].Value), isTrue);
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }

        private void tbcMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tbcMain.SelectedIndex == 0)
            {
                picDeleteSongs.Visible = true;
                InitilizeGrid(dgPlaylist);
                panel2.Dock = DockStyle.Top;
                panel3.Visible = true;
                FillLocalPlaylist();
            }
            if (tbcMain.SelectedIndex == 1)
            {
                InitilizeGrid(dgPlaylist);
                picDeleteSongs.Visible = false;
                panel3.Visible = false;
                panel2.Dock = DockStyle.Fill;

                if (bgLibrary.IsBusy)
                {
                    bgLibrary.CancelAsync();
                }
               // FillCommanGrid(dgBestofPlaylist, "select PlaylistId as IdName, ltrim(Name) as textName from Playlists where isPredefined=1 order by Name");
               // PopulateInputFileTypeDetail(dgPlaylist, Convert.ToInt32(dgBestofPlaylist.Rows[dgBestofPlaylist.CurrentCell.RowIndex].Cells[0].Value), true);

                if (!bgSplPlaylist.IsBusy)
                {
                    RetriveSplPlaylist TObj = new RetriveSplPlaylist();
                    InitilizeCommanOptionGrid(dgBestofPlaylist);
                    bgSplPlaylist.RunWorkerAsync(TObj);

                }
            }
            if (tbcMain.SelectedIndex == 2)
            {
                
                picDeleteSongs.Visible = true;
                panel3.Visible = false;
                panel2.Dock = DockStyle.Fill;
                //FillCommanGrid(dgLibrary, "GetPlaylistLibrary");
               // PopulateInputFileTypeDetail(dgPlaylist, Convert.ToInt32(dgLibrary.Rows[dgLibrary.CurrentCell.RowIndex].Cells[0].Value), false);
                if (bgSplPlaylist.IsBusy)
                {
                    bgSplPlaylist.CancelAsync();
                }
                if (!bgLibrary.IsBusy)
                {
                    RetrivePlaylistLibrary TObj = new RetrivePlaylistLibrary();
                    InitilizeCommanOptionGrid(dgLibrary);
                    bgLibrary.RunWorkerAsync(TObj);
                    
                }
            }

        }

        private void dgBestof_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            if (e.ColumnIndex == 1)
            {
                if (e.RowIndex >= 0)
                {
                    PopulateInputFileTypeDetail(dgPlaylist, Convert.ToInt32(dgBestofPlaylist.Rows[e.RowIndex].Cells[0].Value), true);
                }
            }
            if (e.ColumnIndex == 2)
            {
                 
                if (Convert.ToInt32(cmbFormat.SelectedValue) == 0)
                {
                    MessageBox.Show("Please select a format name", "Management Panel");
                    cmbFormat.Focus();
                    return;
                }

                DialogResult result;

                result = MessageBox.Show("Do you confirm that this selection is copied to the selected format?", "Management Panel", MessageBoxButtons.YesNo);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    string str45 = dgBestofPlaylist.Rows[e.RowIndex].Cells[1].Value.ToString();
                    string[] arr = str45.Split('(');
                    Save(arr[0].Trim());
                }

            }
        }

        private void picDeleteSongs_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgPlaylist.CurrentCell.RowIndex == -1) return;
                if (tbcMain.SelectedIndex == 2)
                {
                    DialogResult rlt;
                    rlt = MessageBox.Show("Are you sure to delete this song?", "Management Panel", MessageBoxButtons.YesNo);
                    if (rlt == DialogResult.Yes)
                    {
                        for (int i = 0; i < dgPlaylist.Rows.Count; i++)
                        {
                            if (dgPlaylist.Rows[i].Selected == true)
                            {
                                if (StaticClass.constr.State == ConnectionState.Open) StaticClass.constr.Close();
                                StaticClass.constr.Open();
                                SqlCommand cmd = new SqlCommand();
                                cmd.Connection = StaticClass.constr;
                                cmd.CommandText = "delete from tbSpecialPlaylists_Titles where TitleID =" + dgPlaylist.Rows[i].Cells[0].Value;
                                cmd.ExecuteNonQuery();
                                StaticClass.constr.Close();


                                if (StaticClass.constr.State == ConnectionState.Open) StaticClass.constr.Close();
                                StaticClass.constr.Open();
                                cmd = new SqlCommand();
                                cmd.Connection = StaticClass.constr;
                                cmd.CommandText = "delete from Titles where TitleID =" + dgPlaylist.Rows[i].Cells[0].Value;
                                cmd.ExecuteNonQuery();
                                StaticClass.constr.Close();

                                // dgPlaylist.Rows.RemoveAt(i);
                            }
                        }
                      PopulateInputFileTypeDetail(dgPlaylist, Convert.ToInt32(dgLibrary.Rows[dgLibrary.CurrentCell.RowIndex].Cells[0].Value), false);
                        GetSongCounterLibrary(Convert.ToInt32(dgLibrary.Rows[dgLibrary.CurrentCell.RowIndex].Cells[0].Value));
                    }
                }
                if (tbcMain.SelectedIndex == 0)
                {
                    DialogResult rlt;
                    rlt = MessageBox.Show("Are you sure to delete this song?", "Management Panel", MessageBoxButtons.YesNo);
                    if (rlt == DialogResult.Yes)
                    {
                        for (int i = 0; i < dgPlaylist.Rows.Count; i++)
                        {
                            if (dgPlaylist.Rows[i].Selected == true)
                            {
                                if (StaticClass.constr.State == ConnectionState.Open) StaticClass.constr.Close();
                                StaticClass.constr.Open();
                                SqlCommand cmd = new SqlCommand();
                                cmd.Connection = StaticClass.constr;
                                cmd.CommandText = "delete from tbSpecialPlaylists_Titles where TitleID =" + dgPlaylist.Rows[i].Cells[0].Value + " and splPlaylistId= " + dgLocalPlaylist.Rows[dgLocalPlaylist.CurrentCell.RowIndex].Cells[0].Value;
                                cmd.ExecuteNonQuery();
                                StaticClass.constr.Close();
                                // dgPlaylist.Rows.RemoveAt(i);
                            }
                        }
                        PopulateInputFileTypeDetail(dgPlaylist, Convert.ToInt32(dgLocalPlaylist.Rows[dgLocalPlaylist.CurrentCell.RowIndex].Cells[0].Value), false);
                        GetSongCounter();
                    }
                }

            }
            catch (Exception ex) { }
        }

        private void chk24Hour_CheckedChanged(object sender, EventArgs e)
        {
            if (chk24Hour.Checked == true)
            {
                dtpeTime.Enabled = false;
                dtpsTime.Enabled = false;
                dtpeTime.Value = Convert.ToDateTime("00:00");
                dtpsTime.Value = Convert.ToDateTime("00:00");

            }
            else
            {
                dtpeTime.Enabled = true;
                dtpsTime.Enabled = true;
                dtpeTime.Value = DateTime.Now;
                dtpsTime.Value = DateTime.Now;
           }
        }

        private void panMainNew_VisibleChanged(object sender, EventArgs e)
        {
            if (panMainNew.Visible == true)
            {
                panNew.Location = new Point(
         this.panMainNew.Width / 2 - panNew.Size.Width / 2,
         this.panMainNew.Height / 2 - panNew.Size.Height / 2);
            }
        }

        private void rdoGenre_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoGenre.Checked == true)
            {
                string str = "select *  from tbAlenkaGenre order by genre";
                ObjMainClass.fnFillComboBoxSpl(str, cmbAlbum, "AlenkaGenreId", "genre", "");
                cmbAlbum.Visible = true;
                txtSearch.Visible = false;
            }
        }

         

        private void rdoTempo_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoTempo.Checked == true)
            {
                string str = "select  alenkatempo  as Tempo, 1 as alenkatempo from titles where alenkatempo is not null group by alenkatempo order by alenkatempo";
                ObjMainClass.fnFillComboBoxSpl(str, cmbAlbum, "alenkatempo", "Tempo", "");
                cmbAlbum.Visible = true;
                txtSearch.Visible = false;
            }
        }

        private void dgLibrary_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            if (e.ColumnIndex == 1)
            {
                if (e.RowIndex >= 0)
                {
                    PopulateInputFileTypeDetail(dgPlaylist, Convert.ToInt32(dgLibrary.Rows[e.RowIndex].Cells[0].Value), false);
                }
            }
            if (e.ColumnIndex == 2)
            {
                
                if (Convert.ToInt32(cmbFormat.SelectedValue) == 0)
                {
                    MessageBox.Show("Please select a format name", "Management Panel");
                    cmbFormat.Focus();
                    return;
                }

                DialogResult result;

                result = MessageBox.Show("Do you confirm that this selection is copied to the selected format?", "Management Panel", MessageBoxButtons.YesNo);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    string str45 = dgLibrary.Rows[e.RowIndex].Cells[1].Value.ToString();
                    string[] arr = str45.Split('(');
                    Save(arr[0].Trim());
                }

            }
        }



        #region Fill Playlist Library with thread
        SqlCommand Sqlcmd;
        SqlDataReader reader = null;
        private void bgLibrary_DoWork(object sender, DoWorkEventArgs e)
        {
            RetrivePlaylistLibrary Obj = (RetrivePlaylistLibrary)e.Argument;
            string SqlcmdString = "GetPlaylistLibrary";
            
             
            int i = 1;
            try
            {
                    Sqlcmd = new SqlCommand(SqlcmdString, StaticClass.constr);
                    if (StaticClass.constr.State == ConnectionState.Closed)
                    {
                        StaticClass.constr.Open();
                    }
                   //
                    try
                    {
                        reader = Sqlcmd.ExecuteReader();
                    }
                    catch (Exception ex)
                    {
                        readerSpl.Close();
                        
                        reader = Sqlcmd.ExecuteReader();
                    }
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Obj.pId = reader["IdName"].ToString();
                            Obj.pName = reader["textname"].ToString();
                            
                            bgLibrary.ReportProgress(i, Obj);
                            Thread.Sleep(100);
                            if (bgLibrary.CancellationPending)
                            {
                                reader.Close();
                                e.Cancel = true;
                                
                                bgLibrary.ReportProgress(0);
                                return;
                            }
                            i++;
                        }
                       
                    }
                 
            }
            catch (Exception ex)
            {
               

                MessageBox.Show(ex.Message);
            }


        }

        private void bgLibrary_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            try
            {
                if (!bgLibrary.CancellationPending)
                {
                    RetrivePlaylistLibrary Obj = (RetrivePlaylistLibrary)e.UserState;
                    dgLibrary.Rows.Add(Obj.pId.ToString(), Obj.pName.ToString());
                }
            }
            catch (Exception ex) { }
        }

        private void bgLibrary_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            reader.Close();
            if (e.Cancelled == false)
            {
                PopulateInputFileTypeDetail(dgPlaylist, Convert.ToInt32(dgLibrary.Rows[dgLibrary.CurrentCell.RowIndex].Cells[0].Value), false);
            }
        }
        public class RetrivePlaylistLibrary
        {
            public string pId;
            public string pName;
        } 
        #endregion



        #region Fill Speical Playlist with thread
        SqlCommand SqlcmdSpl;
        SqlDataReader readerSpl = null;
        private void bgSplPlaylist_DoWork(object sender, DoWorkEventArgs e)
        {
            RetriveSplPlaylist Obj = (RetriveSplPlaylist)e.Argument;
            string SqlcmdStringSpl = "GetBestPlaylist";
           
             
            int i = 1;
            try
            {
                SqlcmdSpl = new SqlCommand(SqlcmdStringSpl, StaticClass.constr);
                if (StaticClass.constr.State == ConnectionState.Closed)
                {
                    StaticClass.constr.Open();
                }
                
                try
                {
                    readerSpl = SqlcmdSpl.ExecuteReader();
                }
                catch (Exception ex)
                {
                    reader.Close();
                    readerSpl = SqlcmdSpl.ExecuteReader();
                }

                if (readerSpl.HasRows)
                {
                    while (readerSpl.Read())
                    {
                        Obj.SplId = readerSpl["IdName"].ToString();
                        Obj.SplName = readerSpl["textname"].ToString();
                        Thread.Sleep(100);
                        bgSplPlaylist.ReportProgress(i, Obj);
                        if (bgSplPlaylist.CancellationPending)
                        {
                            readerSpl.Close();
                            e.Cancel = true;
                            
                            bgSplPlaylist.ReportProgress(0);
                            return;
                        }
                        i++;
                    }
                }

            }
            catch (Exception ex)
            {
              
                MessageBox.Show(ex.Message);
            }
        }

        private void bgSplPlaylist_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            try
            {
                if (!bgSplPlaylist.CancellationPending)
                {
                    RetriveSplPlaylist Obj = (RetriveSplPlaylist)e.UserState;
                    dgBestofPlaylist.Rows.Add(Obj.SplId.ToString(), Obj.SplName.ToString());
                }
            }
            catch (Exception ex) { }
        }

        private void bgSplPlaylist_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            readerSpl.Close();
            if (e.Cancelled == false)
            {
                if (dgBestofPlaylist.Rows.Count > 0)
                {
                    PopulateInputFileTypeDetail(dgPlaylist, Convert.ToInt32(dgBestofPlaylist.Rows[dgBestofPlaylist.CurrentCell.RowIndex].Cells[0].Value), true);
                }
            }
        }
        public class RetriveSplPlaylist
        {
            public string SplId;
            public string SplName;
        }
        #endregion

        private void rdoVideo_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoVideo.Checked == true)
            {
                string mType = "";
                if (rdoAudio.Checked == true)
                {
                    mType = "Audio";
                }
                if (rdoVideo.Checked == true)
                {
                    mType = "Video";
                }
                if (txtSearch.Visible == true)
                {
                    if (txtSearch.Text == "")
                    {
                        string str = "SELECT TOP (500) Titles.TitleID, Titles.Title, Titles.Time, Artists.Name as ArtistName, Albums.Name AS AlbumName, isnull(Titles.AlenkaTempo,'') as Tempo,isnull(tbAlenkaGenre.genre,'') as genre, Titles.titleyear FROM Titles INNER JOIN Albums ON Titles.AlbumID = Albums.AlbumID INNER JOIN Artists ON Titles.ArtistID = Artists.ArtistID LEFT OUTER JOIN tbAlenkaGenre ON Titles.AlenkaGenreId = tbAlenkaGenre.AlenkaGenreId    where titlecategoryid=4 and mediaType='" + mType + "' order by TitleID desc";
                        FillGrid(str);
                        return;
                    }
                    if (txtSearch.Text.Length < 2)
                    {
                        MessageBox.Show("Enter minimum 2 characters for a search function.", "Token Admin");
                        return;
                    }

                    SearchText = txtSearch.Text.Trim();
                    CommanSearch();
                    txtSearch.TextAlign = HorizontalAlignment.Left;
                    txtSearch.ForeColor = Color.White;
                    txtSearch.Text = "";
                }
                else
                {
                    string stSearch = "";
                    if (rdoAlbum.Checked == true)
                    {
                        stSearch = "spSearch_Album_spl " + cmbAlbum.SelectedValue;
                    }
                    else if (rdoGenre.Checked == true)
                    {
                        stSearch = " select distinct TitleID, ltrim(Title) as Title,Time, ltrim(ArtistName) as ArtistName, ltrim(AlbumName) as AlbumName , isnull(genre,'') as genre, Tempo from( ";
                        stSearch = stSearch + " SELECT  Titles.TitleID, Titles.Title,Titles.Time, Artists.Name as ArtistName, Albums.Name AS AlbumName, tbAlenkaGenre.genre, isnull(Titles.AlenkaTempo,'') as Tempo FROM Titles ";
                        stSearch = stSearch + " INNER JOIN Albums ON Titles.AlbumID = Albums.AlbumID  ";
                        stSearch = stSearch + " INNER JOIN Artists ON Titles.ArtistID = Artists.ArtistID  ";
                        stSearch = stSearch + " LEFT OUTER JOIN tbAlenkaGenre ON Titles.AlenkaGenreId = tbAlenkaGenre.AlenkaGenreId  ";
                        stSearch = stSearch + " where Titles.AlenkaGenreId= " + Convert.ToInt32(cmbAlbum.SelectedValue) + " and Titles.mediatype='" + mType + "'";

                        stSearch = stSearch + " ) as d  order by TitleID desc    ";
                    }
                    else if (rdoTempo.Checked == true)
                    {
                        stSearch = " select distinct TitleID, ltrim(Title) as Title,Time, ltrim(ArtistName) as ArtistName, ltrim(AlbumName) as AlbumName , isnull(genre,'') as genre, Tempo from( ";
                        stSearch = stSearch + " SELECT  Titles.TitleID, Titles.Title,Titles.Time, Artists.Name as ArtistName, Albums.Name AS AlbumName, tbAlenkaGenre.genre, isnull(Titles.AlenkaTempo,'') as Tempo FROM Titles ";
                        stSearch = stSearch + " INNER JOIN Albums ON Titles.AlbumID = Albums.AlbumID  ";
                        stSearch = stSearch + " INNER JOIN Artists ON Titles.ArtistID = Artists.ArtistID  ";
                        stSearch = stSearch + " LEFT OUTER JOIN tbAlenkaGenre ON Titles.AlenkaGenreId = tbAlenkaGenre.AlenkaGenreId  ";
                        stSearch = stSearch + " where Titles.alenkatempo= '" + cmbAlbum.Text + "'  and Titles.mediatype='" + mType + "'";

                        stSearch = stSearch + " ) as d  order by TitleID desc    ";
                    }
                    FillGrid(stSearch);
                }
            }
        }

        private void rdoAudio_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoAudio.Checked == true)
            {
                string mType = "";
                if (rdoAudio.Checked == true)
                {
                    mType = "Audio";
                }
                if (rdoVideo.Checked == true)
                {
                    mType = "Video";
                }
                if (txtSearch.Visible == true)
                {
                    if (txtSearch.Text == "")
                    {
                        string str = "SELECT TOP (500) Titles.TitleID, Titles.Title, Titles.Time, Artists.Name as ArtistName, Albums.Name AS AlbumName, isnull(Titles.AlenkaTempo,'') as Tempo,isnull(tbAlenkaGenre.genre,'') as genre, Titles.titleyear FROM Titles INNER JOIN Albums ON Titles.AlbumID = Albums.AlbumID INNER JOIN Artists ON Titles.ArtistID = Artists.ArtistID LEFT OUTER JOIN tbAlenkaGenre ON Titles.AlenkaGenreId = tbAlenkaGenre.AlenkaGenreId    where titlecategoryid=4 and mediaType='" + mType + "' order by TitleID desc";
                        FillGrid(str);
                        return;
                    }
                    if (txtSearch.Text.Length < 2)
                    {
                        MessageBox.Show("Enter minimum 2 characters for a search function.", "Token Admin");
                        return;
                    }

                    SearchText = txtSearch.Text.Trim();
                    CommanSearch();
                    txtSearch.TextAlign = HorizontalAlignment.Left;
                    txtSearch.ForeColor = Color.White;
                    txtSearch.Text = "";
                }
                else
                {
                    string stSearch = "";
                    if (rdoAlbum.Checked == true)
                    {
                        stSearch = "spSearch_Album_spl " + cmbAlbum.SelectedValue;
                    }
                    else if (rdoGenre.Checked == true)
                    {
                        stSearch = " select distinct TitleID, ltrim(Title) as Title,Time, ltrim(ArtistName) as ArtistName, ltrim(AlbumName) as AlbumName , isnull(genre,'') as genre, Tempo from( ";
                        stSearch = stSearch + " SELECT  Titles.TitleID, Titles.Title,Titles.Time, Artists.Name as ArtistName, Albums.Name AS AlbumName, tbAlenkaGenre.genre, isnull(Titles.AlenkaTempo,'') as Tempo FROM Titles ";
                        stSearch = stSearch + " INNER JOIN Albums ON Titles.AlbumID = Albums.AlbumID  ";
                        stSearch = stSearch + " INNER JOIN Artists ON Titles.ArtistID = Artists.ArtistID  ";
                        stSearch = stSearch + " LEFT OUTER JOIN tbAlenkaGenre ON Titles.AlenkaGenreId = tbAlenkaGenre.AlenkaGenreId  ";
                        stSearch = stSearch + " where Titles.AlenkaGenreId= " + Convert.ToInt32(cmbAlbum.SelectedValue) + " and Titles.mediatype='" + mType + "'";

                        stSearch = stSearch + " ) as d  order by TitleID desc    ";
                    }
                    else if (rdoTempo.Checked == true)
                    {
                        stSearch = " select distinct TitleID, ltrim(Title) as Title,Time, ltrim(ArtistName) as ArtistName, ltrim(AlbumName) as AlbumName , isnull(genre,'') as genre, Tempo from( ";
                        stSearch = stSearch + " SELECT  Titles.TitleID, Titles.Title,Titles.Time, Artists.Name as ArtistName, Albums.Name AS AlbumName, tbAlenkaGenre.genre, isnull(Titles.AlenkaTempo,'') as Tempo FROM Titles ";
                        stSearch = stSearch + " INNER JOIN Albums ON Titles.AlbumID = Albums.AlbumID  ";
                        stSearch = stSearch + " INNER JOIN Artists ON Titles.ArtistID = Artists.ArtistID  ";
                        stSearch = stSearch + " LEFT OUTER JOIN tbAlenkaGenre ON Titles.AlenkaGenreId = tbAlenkaGenre.AlenkaGenreId  ";
                        stSearch = stSearch + " where Titles.alenkatempo= '" + cmbAlbum.Text + "'  and Titles.mediatype='" + mType + "'";

                        stSearch = stSearch + " ) as d  order by TitleID desc    ";
                    }
                    FillGrid(stSearch);
                }
            }
        }

        private void rdoCategory_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoCategory.Checked == true)
            {
                string str = "select  alenkacategory as Acat, 1 as alenkacategory from titles where alenkacategory is not null group by alenkacategory order by alenkacategory";
                ObjMainClass.fnFillComboBoxSpl(str, cmbAlbum, "alenkacategory", "Acat", "");
                cmbAlbum.Visible = true;
                txtSearch.Visible = false;
            }
        }
    }
}
