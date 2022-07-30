using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using System.Drawing.Printing;

using BLL;
using BEE;

namespace MahtabStore
{
    public partial class MainForm : Form
    {
        #region CodeRound
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // width of ellipse
            int nHeightEllipse // height of ellipse
        );
        public MainForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }
        #endregion
        BLLClass blc = new BLLClass();
        private void buttonX8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        public void RegisterLoginUser()
        {
            Admin admin = new Admin();
            admin.FullName = "ADMIN";
            admin.UserName = "ADMIN";
            admin.Password = "ADMIN";
            admin.Phone = "ADMIN";
            admin.Activation = true;
            blc.CheckUser(admin);
        }

        private void LoginPanel_Click(object sender, EventArgs e)
        {

        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            DayReports panel = new DayReports();
            if (MainPanel.Controls.Count>0)
            {
                MainPanel.Controls[0].Dispose();
            }
            MainPanel.Controls.Add(panel);
        }

        private void buttonX5_Click(object sender, EventArgs e)
        {
            AdminRegister panel = new AdminRegister();
            if (MainPanel.Controls.Count > 0)
            {
                MainPanel.Controls[0].Dispose();
            }
            MainPanel.Controls.Add(panel);
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            CheckBankPanel panel = new CheckBankPanel();
            if (MainPanel.Controls.Count > 0)
            {
                MainPanel.Controls[0].Dispose();
            }
            MainPanel.Controls.Add(panel);
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            Reportation panel = new Reportation();
            if (MainPanel.Controls.Count > 0)
            {
                MainPanel.Controls[0].Dispose();
            }
            MainPanel.Controls.Add(panel);
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            BackUpPanel panel = new BackUpPanel();
            if (MainPanel.Controls.Count > 0)
            {
                MainPanel.Controls[0].Dispose();
            }
            MainPanel.Controls.Add(panel);
        }

        private void buttonX6_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            if (blc.AccessAdmin(username.Text,Passcode.Text))
            {
                username.Text = " ";
                Passcode.Text = " ";
                LOGINPANEL.Visible = false;
            }
            else
            {
                ResultTxt.Text = "دسترسی ندارید";
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Admin admin = new Admin();
            admin.FullName = "ADMIN";
            admin.UserName = "ADMIN";
            admin.Phone = "ADMIN";
            admin.Password = "ADMIN";
            admin.Activation = true;
            blc.CreateAdmin(admin);
            DayReports panel = new DayReports();
            if (MainPanel.Controls.Count > 0)
            {
                MainPanel.Controls[0].Dispose();
            }
            MainPanel.Controls.Add(panel);
        }

        private void buttonX7_Click(object sender, EventArgs e)
        {
            LOGINPANEL.Visible = true;
            
            DayReports panel = new DayReports();
            if (MainPanel.Controls.Count > 0)
            {
                MainPanel.Controls[0].Dispose();
            }
            MainPanel.Controls.Add(panel);

        }

        private void buttonX9_Click(object sender, EventArgs e)
        {
            About panel = new About();
            if (MainPanel.Controls.Count > 0)
            {
                MainPanel.Controls[0].Dispose();
            }
            MainPanel.Controls.Add(panel);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Recovery.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Functions Fun = new Functions();
            try
            {
                if (blc.GetPass(Use.Text,FullName.Text, Fun.ChangeToEnglishNumber(Phone.Text)) != "0")
                {
                    PAS.Text = blc.GetPass(Use.Text,FullName.Text, Fun.ChangeToEnglishNumber(Phone.Text));
                }
                else
                {
                    PAS.Text = "اطلاعات اشتباه است";
                }
            }
            catch
            {
                    PAS.Text = "مقادیر درست وارد کنید";
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Recovery.Visible = false;
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonX10_Click(object sender, EventArgs e)
        {
            //  خرید نقدی
            MoneyPanel panel = new MoneyPanel();
            if (MainPanel.Controls.Count > 0)
            {
                MainPanel.Controls[0].Dispose();
            }
            MainPanel.Controls.Add(panel);
        }
    }
}