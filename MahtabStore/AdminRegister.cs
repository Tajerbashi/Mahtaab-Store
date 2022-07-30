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
    public partial class AdminRegister : UserControl
    {
        public AdminRegister()
        {
            InitializeComponent();
        }
        Functions Fun = new Functions();
        BLLClass blc = new BLLClass();
        int ID = 0;
        bool SW = true;
        public void ShowAllAdmin()
        {
            DGV.Rows.Clear();
            var DB = blc.GetAllAdmins();
            foreach (var item in DB)
            {
                DGV.Rows.Add(item.ID,item.FullName,item.Phone,item.UserName,item.Password);
            }
        }
        private void textBoxX2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void Savebtn_Click(object sender, EventArgs e)
        {
            try
            {
                Admin admin = new Admin();
                admin.FullName = FullName.Text;
                admin.Phone = Fun.ChangeToEnglishNumber(Phone.Text);
                admin.UserName = UserName.Text;
                if (Password.Text == RPassword.Text)
                {
                    admin.Password = Password.Text;

                    if (blc.CreateAdmin(admin) && SW)
                    {
                        blc.DisActive(1);
                        Result.Text = "ادمین ذخیره شد";
                        ShowAllAdmin();
                        Fun.ClearTextBoxes(this.Controls);
                    }
                    else if (blc.EditAdmin(admin, ID) && !SW)
                    {
                        Result.Text = "ادمین ویرایش شد";
                        ShowAllAdmin();
                        Savebtn.Text = "ذخیره";
                        SW = true;
                        Fun.ClearTextBoxes(this.Controls);
                    }
                    else
                    {
                        Result.Text = "اطلاعات ادمین تکراری است";
                    }

                }
                else
                {
                    Result.Text = "رمز همخوانی ندارد";
                }
            }
            catch
            {
                MessageBox.Show("اطلاعات درست درج نشده است");
            }
            
        }

        private void AdminRegister_Load(object sender, EventArgs e)
        {
            ShowAllAdmin();
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
            blc.DeleteAdmin(ID);
            ShowAllAdmin();

        }

        private void ویرایشToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FullName.Text = DGV.CurrentRow.Cells[1].Value.ToString();
            Phone.Text = DGV.CurrentRow.Cells[2].Value.ToString();
            UserName.Text = DGV.CurrentRow.Cells[3].Value.ToString();
            Password.Text = DGV.CurrentRow.Cells[4].Value.ToString();
            SW = false;
            Savebtn.Text = "بروزرسانی";
        }

        private void تغییرحالتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ID = int.Parse(DGV.CurrentRow.Cells[0].Value.ToString());
            blc.ChangeStatusAdmin(ID);
            ShowAllAdmin();
        }
    }
}
