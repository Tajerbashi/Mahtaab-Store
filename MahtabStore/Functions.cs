using System;
using System.Windows.Forms;
using System.Globalization;

namespace MahtabStore
{
    public class Functions
    {
        public string GetPersianDate(DateTime date)
        {
            System.Globalization.PersianCalendar jc = new System.Globalization.PersianCalendar();
            int hr = int.Parse(jc.GetHour(date).ToString()) > 12 ? int.Parse(jc.GetHour(date).ToString()) - 12 : int.Parse(jc.GetHour(date).ToString());
            return string.Format("{0:0000}/{1:00}/{2:00}  {3:00}:{4:00}:{5:00}  ", jc.GetYear(date), jc.GetMonth(date), jc.GetDayOfMonth(date), hr, jc.GetMinute(date), jc.GetSecond(date));
        }
        public String CLOCK()
        {
            string ToDayShamsiDate = GetPersianDate(DateTime.Now);

            return ToDayShamsiDate;
        }
        public void ClearTextBoxes(Control.ControlCollection ctrlCollection)
        {
            foreach (Control ctrl in ctrlCollection)
            {
                if (ctrl is TextBoxBase)
                {
                    ctrl.Text = String.Empty;
                }
                else
                {
                    ClearTextBoxes(ctrl.Controls);
                }
            }
        }
        public void digitonly(KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar) || char.IsPunctuation(e.KeyChar)))
            {
                e.Handled = true;
                MessageBox.Show("کیبورد را عوض کنید", "Alert!");
            }
        }
        public String ChangeToEnglishNumber(String input)
        {
            String EnglishNumbers = "";
            for (int i = 0; i < input.Length; i++)
            {
                if (Char.IsDigit(input[i]))
                {
                    EnglishNumbers += char.GetNumericValue(input, i);
                }
                else
                {
                    EnglishNumbers += input[i].ToString();
                }
            }
            return EnglishNumbers;
        }
        public String ChangeToPersionNumber(String englishNumber)
        {
            String Result = "";
            foreach (char ch in englishNumber)
            {
                Result += (char)(1776 + char.GetNumericValue(ch));
            }
            return Result;
        }
        public String toArabicNumber(String input)
        {
            var arabic = new String[10] { "۰", "۱", "۲", "۳", "۴", "۵", "۶", "۷", "۸", "۹" };
            for (int j = 0; j < arabic.Length; j++)
            {
                input = input.Replace(j.ToString(), arabic[j]);
            }
            return input;
        }
        public String GetMonthFarsi(int Number)
        {
            switch (Number)
            {
                case 1:
                    {
                        return "فروردین";
                    }
                case 2:
                    {
                        return "اردیبهشت";
                    }
                case 3:
                    {
                        return "خرداد";
                    }
                case 4:
                    {
                        return "تیر";
                    }
                case 5:
                    {
                        return "مرداد";
                    }
                case 6:
                    {
                        return "شهریور";
                    }

                case 7:
                    {
                        return "مهر";
                    }
                case 8:
                    {
                        return "ابان";
                    }
                case 9:
                    {
                        return "اذر";
                    }
                case 10:
                    {
                        return "دی";
                    }
                case 11:
                    {
                        return "بهمن";
                    }
                case 12:
                    {
                        return "اسفند";
                    }
            }
            return "خالی";
        }
        public String GetWeekName(int Number)
        {
            if (Number > 0 && Number <= 7)
            {
                return "هفته اول";
            }
            else if (Number > 7 && Number <= 14)
            {
                return "هفته دوم";
            }
            else if (Number > 14 && Number <= 21)
            {
                return "هفته سوم";
            }
            else if (Number > 21 && Number <= 31)
            {
                return "هفته چهارم";
            }
            return "خالی";
        }
        public String GetDayWeekName(DateTime Date)
        {
            string Res;
            PersianCalendar DateFme = new PersianCalendar();
            Res = DateFme.GetDayOfWeek(ConvertToMiladi(Date.ToString("yyyy/MM/dd"))).ToString();
            switch (Res)
            {
                case "Saturday":
                    {
                        return "شنبه";
                    }
                case "Sunday":
                    {
                        return "یکشبه";
                    }
                case "Monday":
                    {
                        return "دو شنبه";
                    }
                case "Tuesday":
                    {
                        return "سه شبه";
                    }
                case "Wednesday":
                    {
                        return "چهار شنبه";
                    }
                case "Thursday":
                    {
                        return "پنج شنبه";
                    }
                case "Friday":
                    {
                        return "جمعه";
                    }
            }
            return "خالی";
        }
        public string ConvertToPersian(DateTime date)
        {
            PersianCalendar g = new PersianCalendar();
            return string.Format("{0}/{1}/{2}", g.GetYear(date), g.GetMonth(date), g.GetDayOfMonth(date));
        }

        public DateTime ConvertToMiladi(string date)
        {
            string[] d = new string[3];
            d = date.Split('/');
            PersianCalendar g = new PersianCalendar();
            return g.ToDateTime(int.Parse(d[0]), int.Parse(d[1]), int.Parse(d[2]), 8, 0, 0, 0);//1392/05/10
        }

        public PersianCalendar converttopersian(DateTime date)
        {
            PersianCalendar g = new PersianCalendar();
            return g;
        }

    }
}
