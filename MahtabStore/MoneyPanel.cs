using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using BEE;
using System.Globalization;

namespace MahtabStore
{
    public partial class MoneyPanel : UserControl
    {
        public MoneyPanel()
        {
            InitializeComponent();
        }

        BLLClass blc = new BLLClass();
        Functions Fun = new Functions();
        int Tap = 0, ID = 0;
        bool SW = true;
        String StartYear = "0000";
        String EndYear = "0000";
        public void SearchResultInDGV(String Word)
        {
            DGV.Rows.Clear();
            var item = blc.SearchResultInDGV(AdminCom.Text,Word);
            foreach (var I in item)
            {
                DGV.Rows.Add(I.ID, I.Code, I.Name, I.Date, I.Agent, I.Price.ToString("#,0"), I.Details);
            }
        }
        public void GetAdminsInCom()
        {
            AdminCom.Items.Clear();
            var DB = blc.GetAllAdmins();
            foreach (var item in DB)
            {
                AdminCom.Items.Add(item.FullName);
            }
        }
        public void GetAgentInCom(String Admin)
        {
            AgentCom.Items.Clear();
            var DB = blc.GetAgentsName(Admin);
            foreach (var item in DB)
            {
                AgentCom.Items.Add(item);
            }
        }

        public void ShowMoneyInDGV(String Admin)
        {
            DGV.Rows.Clear();
            var item = blc.GetAllMoneyBuys(Admin,StartYear,EndYear);
            foreach (var I in item)
            {
                DGV.Rows.Add(I.ID,I.Code,I.Name,I.Date,I.Agent,I.Price.ToString("#,0"),I.Details);
            }
        }
        
        private void MoneyPanel_Load(object sender, EventArgs e)
        {
            CodeBuy.Text = blc.GetLastCode().ToString();
            GetAdminsInCom();
            DateTxt.Text = Fun.CLOCK();
            DateTime YEARNOw = Convert.ToDateTime(Fun.CLOCK());
            YearFilter.Text = YEARNOw.ToString("yyyy");
            StartYear = Fun.ChangeToEnglishNumber(YearFilter.Text) + "/00/00";
            EndYear = Fun.ChangeToEnglishNumber(YearFilter.Text) + "/12/31";
        }

        private void DGV_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right)
                {
                    ID = int.Parse(DGV.SelectedCells[0].Value.ToString());
                }
                if (e.Button == MouseButtons.Right)
                {
                    contextMenuStrip1.Show(Cursor.Position.X, Cursor.Position.Y);
                }
            }
            catch
            {
            }
        }

        private void حذفToolStripMenuItem_Click(object sender, EventArgs e)
        {
            blc.DeleteMoneyBuy(ID);
            ShowMoneyInDGV(AdminCom.Text);
        }

        private void تغییرحالتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            blc.ChangeStatusMoneyBuy(ID);
            ShowMoneyInDGV(AdminCom.Text);
        }

        private void AdminCom_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetAgentInCom(AdminCom.Text);
            ShowMoneyInDGV(AdminCom.Text);
        }

        private void PriceTxt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                NumberFormatInfo nfi = new NumberFormatInfo();
                nfi.NumberDecimalDigits = 0;
                PriceTxt.Text = Int64.Parse(PriceTxt.Text, NumberStyles.AllowThousands).ToString("N", nfi);
                PriceTxt.Select(PriceTxt.Text.Length, 0);
            }
            catch
            {

            }
        }

        private void ویرایشToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SW = false;
            SaveBtn.Text = "بروزرسانی";
            CodeBuy.Text = DGV.CurrentRow.Cells[1].Value.ToString();
            NameBuy.Text = DGV.CurrentRow.Cells[2].Value.ToString();
            DateTxt.Text = DGV.CurrentRow.Cells[3].Value.ToString();
            AgentCom.Text = DGV.CurrentRow.Cells[4].Value.ToString();
            PriceTxt.Text = DGV.CurrentRow.Cells[5].Value.ToString();
            Details.Text = DGV.CurrentRow.Cells[6].Value.ToString();
        }

        private void OkayYear_Click(object sender, EventArgs e)
        {
            StartYear = Fun.ChangeToEnglishNumber(YearFilter.Text) + "/00/00";
            EndYear = Fun.ChangeToEnglishNumber(YearFilter.Text) + "/12/31";
            ShowMoneyInDGV(AdminCom.Text);
        }

        private void PanelYearFilter_Click(object sender, EventArgs e)
        {
            if (Tap%2==0)
            {
                YearSearch.Visible = true;
            }
            else
            {
                YearSearch.Visible = false;
            }
            Tap++;
        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            SearchResultInDGV(Fun.ChangeToEnglishNumber(SearchTxt.Text));
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (SW)
            {
                MoneyBuy Money = new MoneyBuy();
                Money.Admin = AdminCom.Text;
                Money.Agent = AgentCom.Text;
                Money.Date = Fun.ChangeToEnglishNumber(DateTxt.Text);
                Money.Code = int.Parse(Fun.ChangeToEnglishNumber(CodeBuy.Text));
                Money.Name = NameBuy.Text;
                Money.Price = Convert.ToDouble(Fun.ChangeToEnglishNumber(PriceTxt.Text));
                Money.Details = Details.Text;
                if (blc.CreateMoneyBuy(Money))
                {
                    Result.Text = "خرید نقدی ذخیره شد";
                }
                else
                {
                    Result.Text = "خرید نقدی موجود بود ویرایش شد";
                }
            }
            else
            {
                MoneyBuy Money = new MoneyBuy();
                Money.Admin = AdminCom.Text;
                Money.Agent = AgentCom.Text;
                Money.Date = Fun.ChangeToEnglishNumber(DateTxt.Text);
                Money.Code = int.Parse(Fun.ChangeToEnglishNumber(CodeBuy.Text));
                Money.Name = NameBuy.Text;
                Money.Price = Convert.ToDouble(Fun.ChangeToEnglishNumber(PriceTxt.Text));
                Money.Details = Details.Text;
                if (blc.CreateMoneyBuy(Money))
                {
                    Result.Text = "اطلاعات جدید بود و اضافه شد";
                }
                else
                {
                    Result.Text = "خرید نقدی موجود ویرایش شد";
                }
                SW = true;
                SaveBtn.Text = "ذخیره";
            }

            ShowMoneyInDGV(AdminCom.Text);
            Fun.ClearTextBoxes(this.Controls);
            CodeBuy.Text = blc.GetLastCode().ToString();
            DateTxt.Text = Fun.CLOCK();
        }
    }
}
