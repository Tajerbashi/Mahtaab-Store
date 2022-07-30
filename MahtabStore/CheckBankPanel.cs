using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using BEE;

namespace MahtabStore
{
    public partial class CheckBankPanel : UserControl
    {
        public CheckBankPanel()
        {
            InitializeComponent();
        }
        BLLClass blc = new BLLClass();
        Functions Fun = new Functions();
        int Tap = 0, IDM = 0;
        bool Sw = true;
        String StartYear = "0000";
        String EndYear = "0000";
        public void GetAdminsName()
        {
            AdminCom.Items.Clear();
            var DB = blc.GetAllAdmins();
            foreach (var item in DB)
            {
                AdminCom.Items.Add(item.FullName);
            }
        }
        public void GetBanksName()
        {
            BankCom.Items.Clear();
            var DB = blc.GetBankNames();
            foreach (var item in DB)
            {
                BankCom.Items.Add(item);
            }
        }
        public void GetAgentName()
        {
            AgentCom.Items.Clear();
            var DB = blc.GetAgentsName(AdminCom.Text);
            foreach (var item in DB)
            {
                AgentCom.Items.Add(item);
            }
        }
        
        public void ShowAllCheckBanks(String Admin)
        {
            DGV.Rows.Clear();
            var DB = blc.GetAllChecks(Admin,StartYear,EndYear);
            foreach (var item in DB)
            {
                String Status = (item.Status) ? "پاس شده" : "پاس نشده";
                DGV.Rows.Add(item.id,item.CheckNumber,item.BankName,item.Agent,item.Price.ToString("#,0"),item.PassDate,Status,item.Details);
            }
        }
        public void ShowCheckBanksPass(String Admin)
        {
            DGV.Rows.Clear();
            var DB = blc.GetAllChecksPassed(Admin, StartYear, EndYear);
            foreach (var item in DB)
            {
                String Status = (item.Status) ? "پاس شده" : "پاس نشده";
                DGV.Rows.Add(item.id, item.CheckNumber, item.BankName, item.Agent, item.Price.ToString("#,0"), item.PassDate, Status, item.Details);
            }
        }
        public void ShowCheckBanksNotPass(String Admin)
        {
            DGV.Rows.Clear();
            var DB = blc.GetAllChecksNotPassed(Admin, StartYear, EndYear);
            foreach (var item in DB)
            {
                String Status = (item.Status) ? "پاس شده" : "پاس نشده";
                DGV.Rows.Add(item.id, item.CheckNumber, item.BankName, item.Agent, item.Price.ToString("#,0"), item.PassDate, Status, item.Details);
            }
        }
        public void ShowTodayCheckBanks(String Admin, String Date)
        {
            DGV.Rows.Clear();
            var DB = blc.GetAllTodayChecks(Admin, Date);
            foreach (var item in DB)
            {
                String Status = (item.Status) ? "پاس شده" : "پاس نشده";
                DGV.Rows.Add(item.id, item.CheckNumber, item.BankName, item.Agent, item.Price.ToString("#,0"), item.PassDate, Status, item.Details);
            }
        }
        public void ShowSearchResult(String Admin, String Word)
        {
            DGV.Rows.Clear();
            var DB = blc.ShowSearchResult(Admin, Word, StartYear, EndYear);
            foreach (var item in DB)
            {
                String Status = (item.Status) ? "پاس شده" : "پاس نشده";
                DGV.Rows.Add(item.id, item.CheckNumber, item.BankName, item.Agent, item.Price.ToString("#,0"), item.PassDate, Status, item.Details);
            }
        }
        public void ShowSearchResultNotPass(String Admin, String Word)
        {
            DGV.Rows.Clear();
            var DB = blc.ShowSearchResultNotPass(Admin, Word, StartYear, EndYear);
            foreach (var item in DB)
            {
                String Status = (item.Status) ? "پاس شده" : "پاس نشده";
                DGV.Rows.Add(item.id, item.CheckNumber, item.BankName, item.Agent, item.Price.ToString("#,0"), item.PassDate, Status, item.Details);
            }
        }
        public void ShowTodayCheckBanksPass(String Admin, String Date)
        {
            DGV.Rows.Clear();
            var DB = blc.GetAllTodayChecksPassed(Admin, Date);
            foreach (var item in DB)
            {
                String Status = (item.Status) ? "پاس شده" : "پاس نشده";
                DGV.Rows.Add(item.id, item.CheckNumber, item.BankName, item.Agent, item.Price.ToString("#,0"), item.PassDate, Status, item.Details);
            }
        }
        public void ShowTodayCheckBanksNotPass(String Admin, String Date)
        {
            DGV.Rows.Clear();
            var DB = blc.GetAllTodayChecksNotPassed(Admin, Date);
            foreach (var item in DB)
            {
                String Status = (item.Status) ? "پاس شده" : "پاس نشده";
                DGV.Rows.Add(item.id, item.CheckNumber, item.BankName, item.Agent, item.Price.ToString("#,0"), item.PassDate, Status, item.Details);
            }
        }


        private void CheckPrice_TextChanged(object sender, EventArgs e)
        {
            //ToString("#,0")
            try
            {
                NumberFormatInfo nfi = new NumberFormatInfo();
                nfi.NumberDecimalDigits = 0;
                CheckPrice.Text = Int64.Parse(CheckPrice.Text, NumberStyles.AllowThousands).ToString("N", nfi);
                CheckPrice.Select(CheckPrice.Text.Length, 0);
            }
            catch
            {
            }
        }

        private void CheckBank_Load(object sender, EventArgs e)
        {
            GetAdminsName();
            DayDate.Text = Fun.CLOCK();
            DateTime YEARNOw = Convert.ToDateTime(Fun.CLOCK());
            YearFilter.Text = YEARNOw.ToString("yyyy");
            StartYear = Fun.ChangeToEnglishNumber(YearFilter.Text) + "/00/00";
            EndYear = Fun.ChangeToEnglishNumber(YearFilter.Text) + "/12/31";
        }

        private void AdminName_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowAllCheckBanks(AdminCom.Text);
            //ShowTodayCheckBanks(AdminCom.Text,Fun.ChangeToEnglishNumber(DayDate.Text));
            GetAgentName();
            GetBanksName();
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {

                if (Sw)
                {
                    CheckBank check = new CheckBank();
                    check.Admin = AdminCom.Text;
                    check.Agent = AgentCom.Text;
                    check.BankName = BankCom.Text;
                    check.CheckNumber = CheckNumbertxt.Text;
                    check.Price = Convert.ToDouble(Fun.ChangeToEnglishNumber(CheckPrice.Text));
                    check.DayDate = Fun.ChangeToEnglishNumber(DayDate.Text);
                    check.PassDate = Fun.ChangeToEnglishNumber(CheckDate.Text);
                    check.Details = Details.Text;
                    blc.CreateCheckBank(check);
                    ShowAllCheckBanks(AdminCom.Text);
                }
                else
                {
                    CheckBank check = new CheckBank();
                    check.Admin = AdminCom.Text;
                    check.Agent = AgentCom.Text;
                    check.BankName = BankCom.Text;
                    check.CheckNumber = CheckNumbertxt.Text;
                    check.Price = Convert.ToDouble(Fun.ChangeToEnglishNumber(CheckPrice.Text));
                    check.DayDate = Fun.ChangeToEnglishNumber(DayDate.Text);
                    check.PassDate = Fun.ChangeToEnglishNumber(CheckDate.Text);
                    check.Details = Details.Text;
                    blc.EditCheckBank(check, IDM);
                    ShowAllCheckBanks(AdminCom.Text);
                    Sw = true;
                    SaveBtn.Text = "ذخیره";
                }

            }
            catch
            {
                MessageBox.Show("مقادیر را درست وارد کنید","خطا",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            Fun.ClearTextBoxes(this.Controls);
        }

        private void Tools_Click(object sender, EventArgs e)
        {
            if (Tap%2==0)
            {
                ToolsPanel.Visible = true;
                TotalPriceList.Visible = true;
            }
            else
            {
                ToolsPanel.Visible = false;
                TotalPriceList.Visible = false;
            }
            Tap++;
        }
        
        private void حذفچکToolStripMenuItem_Click(object sender, EventArgs e)
        {
            blc.DeleteCheckBank(IDM);
            ShowAllCheckBanks(AdminCom.Text);
        }

        private void AdminCom_TabIndexChanged(object sender, EventArgs e)
        {
            GetAgentName();
            GetBanksName();
        }

        private void ShowAllChecks_Click(object sender, EventArgs e)
        {
            //  همه چک ها
            ShowAllCheckBanks(AdminCom.Text);
        }

        private void TodayChecks_Click(object sender, EventArgs e)
        {
            DayDate.Text = Fun.CLOCK();
            ShowTodayCheckBanks(AdminCom.Text,Fun.ChangeToEnglishNumber(DayDate.Text));
        }

        private void PassedChecks_Click(object sender, EventArgs e)
        {
            ShowTodayCheckBanksPass(AdminCom.Text, Fun.ChangeToEnglishNumber(DayDate.Text));
        }

        private void NotPassCheck_Click(object sender, EventArgs e)
        {
            ShowTodayCheckBanksNotPass(AdminCom.Text, Fun.ChangeToEnglishNumber(DayDate.Text));
        }

        private void buttonX5_Click(object sender, EventArgs e)
        {
            //  تمام چک های پاس شده
            ShowCheckBanksPass(AdminCom.Text);
        }

        private void buttonX6_Click(object sender, EventArgs e)
        {
            //  تمام چک های پاس نشده
            ShowCheckBanksNotPass(AdminCom.Text);

        }

        private void PassChecks_Click(object sender, EventArgs e)
        {
            //  پاس کردن تمام چک های لیست
            for (int i=0;i<DGV.RowCount;i++)
            {
                IDM = int.Parse(DGV.Rows[i].Cells[0].Value.ToString());
                blc.PassCheck(IDM);
            }
            ShowTodayCheckBanks(AdminCom.Text, Fun.ChangeToEnglishNumber(DayDate.Text));
        }

        private void ClaculateList_Click(object sender, EventArgs e)
        {
            //  جمع کل لیست
            double Total = 0;
            for (int i=0;i<DGV.RowCount;i++)
            {
                Total += Convert.ToDouble( DGV.Rows[i].Cells[4].Value.ToString());
            }
            TotalPriceList.Text = Total.ToString("#,0");
        }

        private void تغییرحالتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IDM = int.Parse(DGV.CurrentRow.Cells[0].Value.ToString());
            blc.ChangeStatus(IDM);
            ShowAllCheckBanks(AdminCom.Text);
        }

        private void ویرایشچکToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //  ویرایش چک
            IDM = int.Parse(DGV.CurrentRow.Cells[0].Value.ToString());
            BankCom.Text = DGV.CurrentRow.Cells[2].Value.ToString();
            AgentCom.Text= DGV.CurrentRow.Cells[3].Value.ToString();
            CheckNumbertxt.Text= DGV.CurrentRow.Cells[1].Value.ToString();
            CheckPrice.Text= DGV.CurrentRow.Cells[4].Value.ToString();
            CheckDate.Text= DGV.CurrentRow.Cells[5].Value.ToString();
            Sw = false;
            SaveBtn.Text = "بروزرسانی";
        }

        private void labelX5_Click(object sender, EventArgs e)
        {
            DayDate.Text = Fun.CLOCK();
        }

        private void Searchbtn_Click_1(object sender, EventArgs e)
        {
            if (SearchTxt.Text.Trim().Length==0)
            {
                MessageBox.Show("تاریخ درج نشده است");
            }
            else
            {
                ShowSearchResult(AdminCom.Text, Fun.ChangeToEnglishNumber(SearchTxt.Text));
            }
        }

        private void SearchNotPass_Click(object sender, EventArgs e)
        {
            if (SearchTxt.Text.Trim().Length == 0)
            {
                MessageBox.Show("تاریخ درج نشده است");
            }
            else
            {
                ShowSearchResultNotPass(AdminCom.Text, Fun.ChangeToEnglishNumber(SearchTxt.Text));
            }
        }

        private void DGV_KeyDown(object sender, KeyEventArgs e)
        {
            IDM = int.Parse(DGV.CurrentRow.Cells[0].Value.ToString());

        }

        private void DGV_KeyUp(object sender, KeyEventArgs e)
        {
            IDM = int.Parse(DGV.CurrentRow.Cells[0].Value.ToString());

        }

        private void PanelYearFilter_Click(object sender, EventArgs e)
        {
            if (Tap % 2 == 0)
            {
                YearSearch.Visible = true;
            }
            else
            {
                YearSearch.Visible = false;
            }
            Tap++;
        }

        private void OkayYear_Click(object sender, EventArgs e)
        {
            StartYear = Fun.ChangeToEnglishNumber(YearFilter.Text) + "/00/00";
            EndYear = Fun.ChangeToEnglishNumber(YearFilter.Text) + "/12/31";
            ShowAllCheckBanks(AdminCom.Text);
        }

        private void DGV_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button==MouseButtons.Left || e.Button==MouseButtons.Right)
            {
                IDM = int.Parse(DGV.SelectedCells[0].Value.ToString());
            }
            if (e.Button==MouseButtons.Right)
            {
                contextMenuStrip1.Show(Cursor.Position.X, Cursor.Position.Y);
            }
        }

    }
}
