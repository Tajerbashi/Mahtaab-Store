using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using BLL;
using BEE;
namespace MahtabStore
{
    public partial class Reportation : UserControl
    {
        public Reportation()
        {
            InitializeComponent();
        }
        Functions Fun = new Functions();
        BLLClass blc = new BLLClass();

        #region GetNameofInCombo
        //public void GetWeeks()
        //{
        //    WeekCom.Items.Clear();
        //    List<String> Weeks = new List<string>() { "هفته اول", "هفته دوم", "هفته سوم", "هفته چهارم" };
        //    foreach (var item in Weeks)
        //    {
        //        WeekCom.Items.Add(item);
        //    }
            
        //}
        //public void GetMonths()
        //{
        //    MonthCom.Items.Clear();
        //    List<String> Months = new List<string>() { "فروردین", "اردیبهشت", "خرداد", "تیر", "مرداد", "شهریور", "مهر", "آبان", "آذر", "دی", "بهمن", "اسفند" };
        //    foreach (var item in Months)
        //    {
        //        MonthCom.Items.Add(item);
        //    }
        //}
        //public void GetYears()
        //{
        //    YearCom.Items.Clear();
        //    for (int i = 1395; i < 1420; i++)
        //    {
        //        YearCom.Items.Add(i);
        //    }
        //}
        
        public void GetAdminsName()
        {
            AdminCom.Items.Clear();
            var DB = blc.GetAllAdmins();
            foreach (var item in DB)
            {
                AdminCom.Items.Add(item.FullName);
            }
        }
        #endregion
        private void Reportation_Load(object sender, EventArgs e)
        {
            AdminCom.BackColor = System.Drawing.Color.Orange;
            GetAdminsName();
        }

        private void Okay_Click(object sender, EventArgs e)
        {
            try
            {
                if (AdminCom.Text.Trim().Length==0)
                {
                    ResultError.Text = "نام ادمین را انتخاب کنید";
                }
                else if (ReportType.Text.Trim().Length == 0)
                {
                    ResultError.Text = "نوع گزارش گیری را انتخاب کنید";
                }
                else if (ReportType.SelectedIndex == 0)
                {
                    //  سالانه
                    //MessageBox.Show(ReportType.Text + "0");
                    if (YearCom.Text.Trim().Length==0)
                    {
                        ResultError.Text = "سال را برای گزارش انتخاب کنید";
                    }
                    else
                    {
                        #region Code
                        String Admin = AdminCom.Text;
                        int Year = int.Parse(YearCom.Text);
                        YearsClass YEAR = blc.GetYear(Admin, Year);
                        if (YEAR != null)
                        {
                            ResultError.Text = " گزارش سال " + YEAR.Year;
                            MoneyL.Text = YEAR.Money.ToString("#,0");
                            BankL.Text = YEAR.Banki.ToString("#,0");
                            TotalL.Text = YEAR.Total.ToString("#,0");
                            if (Percent.Text.Trim().Length == 0)
                            {
                                MoneyLL.Text = "درصد مفاد ذکر نشده";
                                BankiLL.Text = "درصد مفاد ذکر نشده";
                                TotalLL.Text = "درصد مفاد ذکر نشده";
                            }
                            else
                            {
                                int P = int.Parse(Fun.ChangeToEnglishNumber(Percent.Text));
                                MoneyLL.Text = ((Convert.ToDouble(YEAR.Money) * Convert.ToDouble(P)) / 100).ToString("#,0");
                                BankiLL.Text = ((Convert.ToDouble(YEAR.Banki) * Convert.ToDouble(P)) / 100).ToString("#,0");
                                TotalLL.Text = ((Convert.ToDouble(YEAR.Total) * Convert.ToDouble(P)) / 100).ToString("#,0");
                            }
                        }
                        else
                        {
                            ResultError.Text = "گزارشی موجود نیست";
                        }

                        #endregion
                    }
                
                }
                else if (ReportType.SelectedIndex == 1)
                {
                    //  ماهانه
                    //MessageBox.Show(ReportType.Text + "1");
                    if (YearCom.Text.Trim().Length==0)
                    {
                        ResultError.Text = "نوع گزارش گیری را انتخاب کنید";

                    }
                    else if (MonthCom.Text.Trim().Length==0)
                    {
                        ResultError.Text = "ماه را انتخاب کنید";
                    }
                    else
                    {
                        #region Code
                        String Admin = AdminCom.Text;
                        int Y = int.Parse(YearCom.Text);
                        String M = MonthCom.Text;

                        MonthsClass Month = blc.GetMonth(Admin, Y, M);
                        if (Month != null)
                        {
                            ResultError.Text = "گزارش سال " + Month.Year + " ماه " + Month.Month;
                            MoneyL.Text = Month.Money.ToString("#,0");
                            BankL.Text = Month.Banki.ToString("#,0");
                            TotalL.Text = Month.Total.ToString("#,0");

                            if (Percent.Text.Trim().Length == 0)
                            {
                                MoneyLL.Text = "درصد مفاد ذکر نشده";
                                BankiLL.Text = "درصد مفاد ذکر نشده";
                                TotalLL.Text = "درصد مفاد ذکر نشده";
                            }
                            else
                            {
                                int P = int.Parse(Fun.ChangeToEnglishNumber(Percent.Text));

                                MoneyLL.Text = ((Convert.ToDouble(Month.Money) * Convert.ToDouble(P)) / 100).ToString("#,0");
                                BankiLL.Text = ((Convert.ToDouble(Month.Banki) * Convert.ToDouble(P)) / 100).ToString("#,0");
                                TotalLL.Text = ((Convert.ToDouble(Month.Total) * Convert.ToDouble(P)) / 100).ToString("#,0");
                            }
                        }
                        else
                        {
                            ResultError.Text = "گزارشی موجود نیست";
                        }

                        #endregion
                    }
                }
                else if (ReportType.SelectedIndex == 2)
                {
                    //  هفته وار
                    //MessageBox.Show(ReportType.Text + "2");
                    if (YearCom.Text.Trim().Length==0)
                    {
                        ResultError.Text = "سال را برای گزارش انتخاب کنید";
                    }
                    else if (MonthCom.Text.Trim().Length==0)
                    {
                        ResultError.Text = "ماه را انتخاب کنید";
                    }
                    else if (WeekCom.Text.Trim().Length==0)
                    {
                        ResultError.Text = "هفته را انتخاب کنید";
                    }
                    else
                    {
                        #region Code
                        String Admin = AdminCom.Text;
                        int Y = int.Parse(YearCom.Text);
                        String M = MonthCom.Text;
                        String W = WeekCom.Text;

                        WeekClass Week = blc.GetWeek(Admin, Y, M, W);
                        if (Week != null)
                        {
                            ResultError.Text = "گزارش سال " + Week.Year + " ماه " + Week.Month + " " + Week.Week;
                            MoneyL.Text = Week.Money.ToString("#,0");
                            BankL.Text = Week.Banki.ToString("#,0");
                            TotalL.Text = Week.Total.ToString("#,0");

                            if (Percent.Text.Trim().Length == 0)
                            {
                                MoneyLL.Text = "درصد مفاد ذکر نشده";
                                BankiLL.Text = "درصد مفاد ذکر نشده";
                                TotalLL.Text = "درصد مفاد ذکر نشده";
                            }
                            else
                            {
                                int P = int.Parse(Fun.ChangeToEnglishNumber(Percent.Text));

                                MoneyLL.Text = ((Convert.ToDouble(Week.Money) * Convert.ToDouble(P)) / 100).ToString("#,0");
                                BankiLL.Text = ((Convert.ToDouble(Week.Banki) * Convert.ToDouble(P)) / 100).ToString("#,0");
                                TotalLL.Text = ((Convert.ToDouble(Week.Total) * Convert.ToDouble(P)) / 100).ToString("#,0");
                            }
                        }
                        else
                        {
                            ResultError.Text = "گزارشی موجود نیست";
                        }
                        
                        #endregion
                    }
                }
                
                #region ChartColumn
                foreach (var series in ColumnChart.Series)
                {
                    series.Points.Clear();
                    series.ChartType = SeriesChartType.Column;
                }
                try
                {
                    //ColumnChart.Palette = ChartColorPalette.SeaGreen;
                    ColumnChart.Series["ستون"].Points.AddXY("نقدی", MoneyL.Text);
                    ColumnChart.Series["ستون"].Points.AddXY("بانکی", BankL.Text);
                    ColumnChart.Series["ستون"].Points.AddXY("جمع کل", TotalL.Text);
                }
                catch
                {
                    MessageBox.Show("مقادیر نادرست است", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                #endregion
                #region CircleChart
                foreach (var series in CircleChart.Series)
                {
                    series.Points.Clear();
                    //series.ChartType = SeriesChartType.Column;
                }
                try
                {
                    //ColumnChart.Palette = ChartColorPalette.SeaGreen;
                    CircleChart.Series["قسمت"].Points.AddXY("نقدی", MoneyL.Text);
                    CircleChart.Series["قسمت"].Points.AddXY("بانکی", BankL.Text);
                    //CircleChart.Series["قسمت"].Points.AddXY("جمع کل", TotalL.Text);
                }
                catch
                {
                    MessageBox.Show("مقادیر نادرست است", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                #endregion
            }
            catch
            {
                MessageBox.Show("مقادیر نادرست است", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
    }
}
