using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BEE;
using BLL;


namespace MahtabStore
{
    public partial class BackUpPanel : UserControl
    {
        public BackUpPanel()
        {
            InitializeComponent();
        }
        BLLClass blc = new BLLClass();
        private void button1_Click(object sender, EventArgs e)
        {
            //  پشتیان گیری
            Result.Text = "منتظر اتمام عملیات بمانید";
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowDialog();
            blc.Backup(fbd.SelectedPath);
            Result.Text = "پشتیبان گیری با موفقیت انجام شد";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //  بازگردانی
            MessagePanel.Visible = true;
            button1.Enabled = false;
            button2.Enabled = false;
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            if (blc.AccessAdmin(Username.Text,Password.Text))
            {
                Result.Text = "پایگاه داده اطلاعات خود را در دریوار سی نمیتوانید پشتیبان گیری کنید";
                PanelAccess.Visible = false;
                button1.Visible = true;
                button2.Visible = true;
            }
            else
            {
                Result.Text = "نام کاربری  یا رمز کاربری درستی وارد نکردید و دسترسی داده نشد";
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            MessagePanel.Visible = false;
            Result.Text = "منتظر اتمام عملیات بمانید";
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();
            if (ofd.FileName.Trim().Length != 0)
            {
                blc.Restor(ofd.FileName);
                Result.Text = "بازگردانی اطلاعات با موفقیت انجام شد";
            }
            button1.Enabled = true;
            button2.Enabled = true;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            MessagePanel.Visible = false;
            button1.Enabled = true;
            button2.Enabled = true;
        }
    }
}
