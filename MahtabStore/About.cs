using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;
namespace MahtabStore
{
    public partial class About : UserControl
    {
        public About()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Panel.Text = "Kamran_Tajerbashi";
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Panel.Text = "KamranTajerbashi@gmail.com";
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Panel.Text = "دنیا مال شماست اگر به اندازه دنیا بزرگ بی اندیشید";
        }

        private void Send_Click(object sender, EventArgs e)
        {
            try
            {
                SmtpClient client = new SmtpClient("smtp.gmail.com", 465);
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential(From.Text, PassCode.Text);

                MailAddress from = new MailAddress(From.Text);
                MailAddress to = new MailAddress(To.Text);
                MailMessage message = new MailMessage(from, to);
                message.Body = Subject.Text;
                message.BodyEncoding = Encoding.UTF8;
                message.Subject = Title.Text;
                message.SubjectEncoding = Encoding.UTF8;
                client.Send(message);
                message.Dispose();
                MessageBox.Show("Message Sent!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //try
            //{
            //    MailMessage mail = new MailMessage();
            //    SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

            //    //نام فرستنده
            //    mail.From = new MailAddress(From.Text);
            //    //آدرس گیرنده یا گیرندگان
            //    mail.To.Add(To.Text);
            //    //عنوان ایمیل
            //    mail.Subject = Title.Text;
            //    //بدنه ایمیل
            //    mail.Body = Subject.Text;
            //    //مشخص کرن پورت 
            //    SmtpServer.Port = 587;
            //    //username : به جای این کلمه نام کاربری ایمیل خود را قرار دهید
            //    //password : به جای این کلمه رمز عبور ایمیل خود را قرار دهید
            //    SmtpServer.Credentials = new System.Net.NetworkCredential("username", "password");
            //    SmtpServer.EnableSsl = true;

            //    SmtpServer.Send(mail);
            //    MessageBox.Show("mail Send");
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.ToString());
            //}
        }
    }
}
