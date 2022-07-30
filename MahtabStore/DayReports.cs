using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using BLL;
using BEE;

namespace MahtabStore
{
    public partial class DayReports : UserControl
    {
        public DayReports()
        {
            InitializeComponent();
        }
        Functions Fun = new Functions();
        BLLClass blc = new BLLClass();
        int Tap = 1,ID=0;
        bool SW = true;
        String StartYear = "0000";
        String EndYear = "0000";
        #region GetNameofInCombo
        public void GetDays()
        {
            DC.Items.Clear();
            List<String> DaysName = new List<string>() { "شنبه","یکشنبه","دوشنبه","سه شنبه","چهارشنبه","پنج شنبه","جمعه"};
            foreach (var item in DaysName)
            {
                DC.Items.Add(item);
            }
        }
        public void GetWeeks()
        {
            WeeksCom.Items.Clear();
            List<String> Weeks = new List<string>() { "هفته اول", "هفته دوم", "هفته سوم", "هفته چهارم" };
            foreach (var item in Weeks)
            {
                WeeksCom.Items.Add(item);
            }
        }
        public void GetMonths()
        {
            MonthsCom.Items.Clear();
            List<String> Months = new List<string>() { "فروردین", "اردیبهشت", "خرداد", "تیر", "مرداد", "شهریور", "مهر","آبان","آذر","دی","بهمن","اسفند" };
            foreach (var item in Months)
            {
                MonthsCom.Items.Add(item);
            }
        }
        public void GetYears()
        {
            YearsCom.Items.Clear();
            for (int i=1395;i<1420;i++)
            {
                YearsCom.Items.Add(i);
            }
        }
        public void GetAdminsName()
        {
            Admins.Items.Clear();
            var DB = blc.GetAllAdmins();
            foreach (var item in DB)
            {
                Admins.Items.Add(item.FullName);
            }
        }
        #endregion
        #region ShowDGV
        public void RefreshDGV()
        {
            if (dayR.Checked)
            {
                ShowDaysInDGV();
            }
            else if (WeekR.Checked)
            {
                ShowWeeksInDGV();
            }
            else if (MonthR.Checked)
            {
                ShowMonthsInDGV();
            }
            else if (YearR.Checked)
            {
                ShowYearsInDGV();
            }
        }
        public void ShowDaysInDGV()
        {
            DGV.Rows.Clear();
            var DB = blc.GetAllDays(Admins.Text,StartYear,EndYear);
            foreach (var item in DB)
            {
                DGV.Rows.Add(item.ID,item.DayDate,item.Day,item.Week,item.Month,item.Year,item.Banki.ToString("#,0"),item.Money.ToString("#,0"), item.Total.ToString("#,0"));
            }
        }
        public void ShowWeeksInDGV()
        {
            DGV.Rows.Clear();
            var DB = blc.GetAllWeeks(Admins.Text, StartYear, EndYear);
            foreach (var item in DB)
            {
                DGV.Rows.Add(item.ID, item.DayDate, item.Day, item.Week, item.Month, item.Year, item.Banki.ToString("#,0"), item.Money.ToString("#,0"), item.Total.ToString("#,0"));
            }
        }
        public void ShowMonthsInDGV()
        {
            DGV.Rows.Clear();
            var DB = blc.GetAllMonths(Admins.Text, StartYear, EndYear);
            foreach (var item in DB)
            {
                DGV.Rows.Add(item.ID, item.DayDate, item.Day, item.Week, item.Month, item.Year, item.Banki.ToString("#,0"), item.Money.ToString("#,0"), item.Total.ToString("#,0"));
            }
        }
        public void ShowYearsInDGV()
        {
            DGV.Rows.Clear();
            var DB = blc.GetAllYears(Admins.Text, StartYear, EndYear);
            foreach (var item in DB)
            {
                DGV.Rows.Add(item.ID, item.DayDate, item.Day, item.Week, item.Month, item.Year, item.Banki.ToString("#,0"), item.Money.ToString("#,0"), item.Total.ToString("#,0"));
            }
        }
        #endregion
        #region ShowSortDate
        public void RefreshSortByDateDGV()
        {
            if (dayR.Checked)
            {
                ShowDaysInDGVSortByDate();
            }
            else if (WeekR.Checked)
            {
                ShowWeeksInDGVSortByDate();
            }
            else if (MonthR.Checked)
            {
                ShowMonthsInDGVSortByDate();
            }
            else if (YearR.Checked)
            {
                ShowYearsInDGVSortByDate();
            }
        }
        public void ShowDaysInDGVSortByDate()
        {
            DGV.Rows.Clear();
            var DB = blc.GetAllDaysSortByDate(Admins.Text, StartYear, EndYear);
            foreach (var item in DB)
            {
                DGV.Rows.Add(item.ID, item.DayDate, item.Day, item.Week, item.Month, item.Year, item.Banki.ToString("#,0"), item.Money.ToString("#,0"), item.Total.ToString("#,0"));
            }
        }
        public void ShowWeeksInDGVSortByDate()
        {
            DGV.Rows.Clear();
            var DB = blc.GetAllWeeksSortByDate(Admins.Text, StartYear, EndYear);
            foreach (var item in DB)
            {
                DGV.Rows.Add(item.ID, item.DayDate, item.Day, item.Week, item.Month, item.Year, item.Banki.ToString("#,0"), item.Money.ToString("#,0"), item.Total.ToString("#,0"));
            }
        }
        public void ShowMonthsInDGVSortByDate()
        {
            DGV.Rows.Clear();
            var DB = blc.GetAllMonthsSortByDate(Admins.Text, StartYear, EndYear);
            foreach (var item in DB)
            {
                DGV.Rows.Add(item.ID, item.DayDate, item.Day, item.Week, item.Month, item.Year, item.Banki.ToString("#,0"), item.Money.ToString("#,0"), item.Total.ToString("#,0"));
            }
        }
        public void ShowYearsInDGVSortByDate()
        {
            DGV.Rows.Clear();
            var DB = blc.GetAllYearsSortByDate(Admins.Text, StartYear, EndYear);
            foreach (var item in DB)
            {
                DGV.Rows.Add(item.ID, item.DayDate, item.Day, item.Week, item.Month, item.Year, item.Banki.ToString("#,0"), item.Money.ToString("#,0"), item.Total.ToString("#,0"));
            }
        }
        #endregion
        #region ShowSortBanki
        public void RefreshSortByBankDGV()
        {
            if (dayR.Checked)
            {
                ShowDaysInDGVSortByBank();
            }
            else if (WeekR.Checked)
            {
                ShowWeeksInDGVSortByBank();
            }
            else if (MonthR.Checked)
            {
                ShowMonthsInDGVSortByBank();
            }
            else if (YearR.Checked)
            {
                ShowYearsInDGVSortByBank();
            }
        }
        public void ShowDaysInDGVSortByBank()
        {
            DGV.Rows.Clear();
            var DB = blc.GetAllDaysSortByBank(Admins.Text, StartYear, EndYear);
            foreach (var item in DB)
            {
                DGV.Rows.Add(item.ID, item.DayDate, item.Day, item.Week, item.Month, item.Year, item.Banki.ToString("#,0"), item.Money.ToString("#,0"), item.Total.ToString("#,0"));
            }
        }
        public void ShowWeeksInDGVSortByBank()
        {
            DGV.Rows.Clear();
            var DB = blc.GetAllWeeksSortByBank(Admins.Text, StartYear, EndYear);
            foreach (var item in DB)
            {
                DGV.Rows.Add(item.ID, item.DayDate, item.Day, item.Week, item.Month, item.Year, item.Banki.ToString("#,0"), item.Money.ToString("#,0"), item.Total.ToString("#,0"));
            }
        }
        public void ShowMonthsInDGVSortByBank()
        {
            DGV.Rows.Clear();
            var DB = blc.GetAllMonthsSortByBank(Admins.Text, StartYear, EndYear);
            foreach (var item in DB)
            {
                DGV.Rows.Add(item.ID, item.DayDate, item.Day, item.Week, item.Month, item.Year, item.Banki.ToString("#,0"), item.Money.ToString("#,0"), item.Total.ToString("#,0"));
            }
        }
        public void ShowYearsInDGVSortByBank()
        {
            DGV.Rows.Clear();
            var DB = blc.GetAllYearsSortByBank(Admins.Text, StartYear, EndYear);
            foreach (var item in DB)
            {
                DGV.Rows.Add(item.ID, item.DayDate, item.Day, item.Week, item.Month, item.Year, item.Banki.ToString("#,0"), item.Money.ToString("#,0"), item.Total.ToString("#,0"));
            }
        }
        #endregion
        #region ShowSortMoney
        public void RefreshSortByMoneyDGV()
        {
            if (dayR.Checked)
            {
                ShowDaysInDGVSortByMoney();
            }
            else if (WeekR.Checked)
            {
                ShowWeeksInDGVSortByMoney();
            }
            else if (MonthR.Checked)
            {
                ShowMonthsInDGVSortByMoney();
            }
            else if (YearR.Checked)
            {
                ShowYearsInDGVSortByMoney();
            }
        }
        public void ShowDaysInDGVSortByMoney()
        {
            DGV.Rows.Clear();
            var DB = blc.GetAllDaysSortByMoney(Admins.Text, StartYear, EndYear);
            foreach (var item in DB)
            {
                DGV.Rows.Add(item.ID, item.DayDate, item.Day, item.Week, item.Month, item.Year, item.Banki.ToString("#,0"), item.Money.ToString("#,0"), item.Total.ToString("#,0"));
            }
        }
        public void ShowWeeksInDGVSortByMoney()
        {
            DGV.Rows.Clear();
            var DB = blc.GetAllWeeksSortByMoney(Admins.Text, StartYear, EndYear);
            foreach (var item in DB)
            {
                DGV.Rows.Add(item.ID, item.DayDate, item.Day, item.Week, item.Month, item.Year, item.Banki.ToString("#,0"), item.Money.ToString("#,0"), item.Total.ToString("#,0"));
            }
        }
        public void ShowMonthsInDGVSortByMoney()
        {
            DGV.Rows.Clear();
            var DB = blc.GetAllMonthsSortByMoney(Admins.Text, StartYear, EndYear);
            foreach (var item in DB)
            {
                DGV.Rows.Add(item.ID, item.DayDate, item.Day, item.Week, item.Month, item.Year, item.Banki.ToString("#,0"), item.Money.ToString("#,0"), item.Total.ToString("#,0"));
            }
        }
        public void ShowYearsInDGVSortByMoney()
        {
            DGV.Rows.Clear();
            var DB = blc.GetAllYearsSortByMoney(Admins.Text, StartYear, EndYear);
            foreach (var item in DB)
            {
                DGV.Rows.Add(item.ID, item.DayDate, item.Day, item.Week, item.Month, item.Year, item.Banki.ToString("#,0"), item.Money.ToString("#,0"), item.Total.ToString("#,0"));
            }
        }
        #endregion
        #region SearchDay
        public void ShowDAYResultSearch(String Word,String Admin)
        {
            DGV.Rows.Clear();
            var DB = blc.SearchDay(Word,Admin, StartYear, EndYear);
            foreach (var item in DB)
            {
                DGV.Rows.Add(item.ID, item.DayDate, item.Day, item.Week, item.Month, item.Year, item.Banki.ToString("#,0"), item.Money.ToString("#,0"), item.Total.ToString("#,0"));
            }
        }
        public void ShowWEEKResultSearch(int Year, String Month, String Week, String Admin)
        {
            DGV.Rows.Clear();
            var DB = blc.SearchWeek(Year,Month,Week,Admin);
            foreach (var item in DB)
            {
                DGV.Rows.Add(item.ID, item.DayDate, item.Day, item.Week, item.Month, item.Year, item.Banki.ToString("#,0"), item.Money.ToString("#,0"), item.Total.ToString("#,0"));
            }
        }
        public void ShowMONTHResultSearch(int Year, String Month, String Admin)
        {
            DGV.Rows.Clear();
            var DB = blc.SearchMonth(Year,Month,Admin);
            foreach (var item in DB)
            {
                DGV.Rows.Add(item.ID, item.DayDate, item.Day, item.Week, item.Month, item.Year, item.Banki.ToString("#,0"), item.Money.ToString("#,0"), item.Total.ToString("#,0"));
            }
        }
        public void ShowYEARResultSearch(int Year,String Admin)
        {
            DGV.Rows.Clear();
            var DB = blc.SearchYear(Year,Admin);
            foreach (var item in DB)
            {
                DGV.Rows.Add(item.ID, item.DayDate, item.Day,item.Week,item.Month, item.Year, item.Banki.ToString("#,0"), item.Money.ToString("#,0"), item.Total.ToString("#,0"));
            }
        }
        #endregion
        #region SearchWeek
        public void ShowWEEKWResultSearch(int Year, String Month, String Week, String Admin)
        {
            DGV.Rows.Clear();
            var DB = blc.SearchWWeek(Year, Month, Week, Admin);
            foreach (var item in DB)
            {
                DGV.Rows.Add(item.ID, item.DayDate, item.Day, item.Week, item.Month, item.Year, item.Banki.ToString("#,0"), item.Money.ToString("#,0"), item.Total.ToString("#,0"));
            }
        }
        public void ShowMONTHWResultSearch(int Year, String Month, String Admin)
        {
            DGV.Rows.Clear();
            var DB = blc.SearchWMonth(Year, Month, Admin);
            foreach (var item in DB)
            {
                DGV.Rows.Add(item.ID, item.DayDate, item.Day, item.Week, item.Month, item.Year, item.Banki.ToString("#,0"), item.Money.ToString("#,0"), item.Total.ToString("#,0"));
            }
        }
        public void ShowYEARWResultSearch(int Year, String Admin)
        {
            DGV.Rows.Clear();
            var DB = blc.SearchWYear(Year, Admin);
            foreach (var item in DB)
            {
                DGV.Rows.Add(item.ID, item.DayDate, item.Day, item.Week, item.Month, item.Year, item.Banki.ToString("#,0"), item.Money.ToString("#,0"), item.Total.ToString("#,0"));
            }
        }
        #endregion
        #region SearchMonth
        public void ShowMONTHMResultSearch(int Year, String Month, String Admin)
        {
            DGV.Rows.Clear();
            var DB = blc.SearchMMonth(Year, Month, Admin);
            foreach (var item in DB)
            {
                DGV.Rows.Add(item.ID, item.DayDate, item.Day, item.Week, item.Month, item.Year, item.Banki.ToString("#,0"), item.Money.ToString("#,0"), item.Total.ToString("#,0"));
            }
        }
        public void ShowYEARMResultSearch(int Year, String Admin)
        {
            DGV.Rows.Clear();
            var DB = blc.SearchMYear(Year, Admin);
            foreach (var item in DB)
            {
                DGV.Rows.Add(item.ID, item.DayDate, item.Day, item.Week, item.Month, item.Year, item.Banki.ToString("#,0"), item.Money.ToString("#,0"), item.Total.ToString("#,0"));
            }
        }
        #endregion
        #region SearchYear
        public void ShowYEARYResultSearch(int Year, String Admin)
        {
            DGV.Rows.Clear();
            var DB = blc.SearchYYear(Year, Admin);
            foreach (var item in DB)
            {
                DGV.Rows.Add(item.ID, item.DayDate, item.Day, item.Week, item.Month, item.Year, item.Banki.ToString("#,0"), item.Money.ToString("#,0"), item.Total.ToString("#,0"));
            }
        }
        #endregion
        #region GetDate
        public void GetWeekName(int dayR)
        {
            if (dayR > 0 && dayR <= 7)
            {
                WeeksCom.Text = "هفته اول";
            }
            else if (dayR > 7 && dayR <= 14)
            {
                WeeksCom.Text = "هفته دوم";
            }
            else if (dayR > 14 && dayR <= 21)
            {
                WeeksCom.Text = "هفته سوم";
            }
            else if (dayR > 21 && dayR <= 31)
            {
                WeeksCom.Text = "هفته چهارم";
            }
        }
        public void DateCheck(String Date1)
        {
            try
            {
                String DNM = Fun.ChangeToEnglishNumber(Date1);
                DateTime Date = Convert.ToDateTime(DNM);
                //روز بر اساس ماه
                String D1 = Date.ToString("dd");
                int dayR = int.Parse(D1);
                GetWeekName(dayR);
                // ماه بر اساس سال
                String M1 = Date.ToString("MM");
                int MonthR = int.Parse(M1);
                MonthsCom.Text = Fun.GetMonthFarsi(MonthR); //نام ماه به فارسی
                // سال
                String Y1 = Date.ToString("yyyy");
                int YearR = int.Parse(Y1);
                YearsCom.Text = YearR.ToString();
                //  نام روز در هفته
                String WeekDayName = Fun.GetDayWeekName(Date);
                DC.Text = WeekDayName;
                //MessageBox.Show(Fun.GetDayWeekName(Date));
            }
            catch
            {
                MessageBox.Show("تاریخ درست وارد نشده است", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
        public void Delete(int ID)
        {
            if (dayR.Checked)
            {
                blc.DeleteDay(ID);
            }
            else if (WeekR.Checked)
            {
                blc.DeleteWeek(ID);
            }
            else if (MonthR.Checked)
            {
                blc.DeleteMonth(ID);
            }
            else if (YearR.Checked)
            {
                blc.DeleteYear(ID);
            }
        }
        
        private void DayReports_Load(object sender, EventArgs e)
        {
            DayDate.Text = Fun.ChangeToEnglishNumber(Fun.CLOCK());
            GetAdminsName();
            GetYears();
            GetMonths();
            GetWeeks();
            GetDays();
            dayR.Checked = true;
            DateTime YEARNOw = Convert.ToDateTime(Fun.CLOCK());
            YearFilter.Text = YEARNOw.ToString("yyyy");
            StartYear = Fun.ChangeToEnglishNumber(YearFilter.Text) + "/00/00";
            EndYear = Fun.ChangeToEnglishNumber(YearFilter.Text) + "/12/31";
        }
        private void dayR_CheckedChanged(object sender, EventArgs e)
        {
            ListB.Text = "فروش کل روز :";
            GetDays();
            ShowDaysInDGV();
        }
        private void WeekR_CheckedChanged(object sender, EventArgs e)
        {
            ListB.Text = "فروش کل هفته :";
            GetWeeks();
            ShowWeeksInDGV();
        }
        private void MonthR_CheckedChanged(object sender, EventArgs e)
        {
            ListB.Text = "فروش کل ماه :";
            GetMonths();
            ShowMonthsInDGV();
        }
        private void YearR_CheckedChanged(object sender, EventArgs e)
        {
            ListB.Text = "فروش کل سال :";
            GetYears();
            ShowYearsInDGV();
        }
        private void buttonX1_Click(object sender, EventArgs e)
        {
            if (Admins.Text.Trim().Length==0)
            {
                Result.Text = "نام ادمین را انتخاب کنید";
            }
            else if (YearsCom.Text.Trim().Length == 0)
            {
                Result.Text = "سال را انتخاب کنید";
            }
            else if (MonthsCom.Text.Trim().Length == 0)
            {
                Result.Text = "ماه را انتخاب کنید";
            }
            else if (WeeksCom.Text.Trim().Length == 0)
            {
                Result.Text = "هفته را انتخاب کنید";
            }
            else if (DC.Text.Trim().Length == 0)
            {
                Result.Text = "روز را انتخاب کنید";
            }
            else if (DayDate.Text.Trim().Length == 0)
            {
                Result.Text = "تاریخ را انتخاب کنید";
            }
            else if (Banking.Text.Trim().Length == 0)
            {
                Result.Text = "مبلغ بانکی را انتخاب کنید";
            }
            else if (Money.Text.Trim().Length == 0)
            {
                Result.Text = "مبلغ نقدی را انتخاب کنید";
            }
            else
            {
                try
                {
                    if (SW)
                    {
                        if (dayR.Checked)
                        {
                            DaysClass Day = new DaysClass();
                            Day.Admin = Admins.Text;
                            Day.Year = int.Parse(YearsCom.Text);
                            Day.Month = MonthsCom.Text;
                            Day.Week = WeeksCom.Text;
                            Day.Day = DC.Text;
                            Day.DayDate = Fun.ChangeToEnglishNumber(DayDate.Text);
                            Day.Banki = Convert.ToDouble(Fun.ChangeToEnglishNumber(Banking.Text));
                            Day.Money = Convert.ToDouble(Fun.ChangeToEnglishNumber(Money.Text));
                            Day.Total = Convert.ToDouble(Fun.ChangeToEnglishNumber(Total.Text));
                            if (blc.CreateDayReport(Day))
                            {
                                Result.Text = "گزارش روزانه ذخیره شد";
                            }
                            else
                            {
                                Result.Text = "گزارش روزانه موجود است برای تغییرات ویرایش کنید";
                            }
                        }
                        else if (WeekR.Checked)
                        {
                            WeekClass Week = new WeekClass();
                            Week.Admin = Admins.Text;
                            Week.Year = int.Parse(YearsCom.Text);
                            Week.Month = MonthsCom.Text;
                            Week.Week = WeeksCom.Text;
                            Week.Day = DC.Text;
                            Week.DayDate = Fun.ChangeToEnglishNumber(DayDate.Text);
                            Week.Banki = Convert.ToDouble(Fun.ChangeToEnglishNumber(Banking.Text));
                            Week.Money = Convert.ToDouble(Fun.ChangeToEnglishNumber(Money.Text));
                            Week.Total = Convert.ToDouble(Fun.ChangeToEnglishNumber(Total.Text));
                            if (blc.CreateWeekReport(Week))
                            {
                                Result.Text = "گزارش روزانه ذخیره شد";
                            }
                            else
                            {
                                Result.Text = "گزارش روزانه موجود است برای تغییرات ویرایش کنید";
                            }
                            
                        }
                        else if (MonthR.Checked)
                        {
                            MonthsClass month = new MonthsClass();
                            month.Admin = Admins.Text;
                            month.Year = int.Parse(YearsCom.Text);
                            month.Month = MonthsCom.Text;
                            month.Week = WeeksCom.Text;
                            month.Day = DC.Text;
                            month.DayDate = Fun.ChangeToEnglishNumber(DayDate.Text);
                            month.Banki = Convert.ToDouble(Fun.ChangeToEnglishNumber(Banking.Text));
                            month.Money = Convert.ToDouble(Fun.ChangeToEnglishNumber(Money.Text));
                            month.Total = Convert.ToDouble(Fun.ChangeToEnglishNumber(Total.Text));
                            blc.CreateMonthReport(month);
                        }
                        else if (YearR.Checked)
                        {
                            YearsClass year = new YearsClass();
                            year.Admin = Admins.Text;
                            year.Year = int.Parse(YearsCom.Text);
                            year.Month = MonthsCom.Text;
                            year.Week = WeeksCom.Text;
                            year.Day = DC.Text;
                            year.DayDate = Fun.ChangeToEnglishNumber(DayDate.Text);
                            year.Banki = Convert.ToDouble(Fun.ChangeToEnglishNumber(Banking.Text));
                            year.Money = Convert.ToDouble(Fun.ChangeToEnglishNumber(Money.Text));
                            year.Total = Convert.ToDouble(Fun.ChangeToEnglishNumber(Total.Text));
                            if (blc.CreateYearReport(year))
                            {
                                Result.Text = "گزارش روزانه ذخیره شد";
                            }
                            else
                            {
                                Result.Text = "گزارش روزانه موجود است برای تغییرات ویرایش کنید";
                            }
                            blc.CreateYearReport(year);
                        }
                        //  ثبت اتومات هفته ایی
                        WeekClass WeekAuto = new WeekClass();
                        WeekAuto.Admin = Admins.Text;
                        WeekAuto.Year = int.Parse(Fun.ChangeToEnglishNumber(YearsCom.Text));
                        WeekAuto.Month = MonthsCom.Text;
                        WeekAuto.Week = WeeksCom.Text;
                        WeekAuto.Day = DC.Text;
                        WeekAuto.DayDate = Fun.ChangeToEnglishNumber(DayDate.Text);
                        WeekAuto.Money = Convert.ToDouble(Fun.ChangeToEnglishNumber(Money.Text));
                        WeekAuto.Banki = Convert.ToDouble(Fun.ChangeToEnglishNumber(Banking.Text));
                        WeekAuto.Total= Convert.ToDouble(Fun.ChangeToEnglishNumber(Total.Text));
                        blc.CreateAutoWeek(WeekAuto);
                        //  ثبت اتومات ماهیانه
                        MonthsClass MonthAuto = new MonthsClass();
                        MonthAuto.Admin = Admins.Text;
                        MonthAuto.Year = int.Parse(Fun.ChangeToEnglishNumber(YearsCom.Text));
                        MonthAuto.Month = MonthsCom.Text;
                        MonthAuto.Week = WeeksCom.Text;
                        MonthAuto.Day = DC.Text;
                        MonthAuto.DayDate = Fun.ChangeToEnglishNumber(DayDate.Text);
                        MonthAuto.Money = Convert.ToDouble(Fun.ChangeToEnglishNumber(Money.Text));
                        MonthAuto.Banki = Convert.ToDouble(Fun.ChangeToEnglishNumber(Banking.Text));
                        MonthAuto.Total = Convert.ToDouble(Fun.ChangeToEnglishNumber(Total.Text));
                        blc.CreateAutoMonth(MonthAuto);
                        //  ثبت اتومات سالانه
                        YearsClass YearAuto = new YearsClass();
                        YearAuto.Admin = Admins.Text;
                        YearAuto.Year = int.Parse(Fun.ChangeToEnglishNumber(YearsCom.Text));
                        YearAuto.Month = MonthsCom.Text;
                        YearAuto.Week = WeeksCom.Text;
                        YearAuto.Day = DC.Text;
                        YearAuto.DayDate = Fun.ChangeToEnglishNumber(DayDate.Text);
                        YearAuto.Money = Convert.ToDouble(Fun.ChangeToEnglishNumber(Money.Text));
                        YearAuto.Banki = Convert.ToDouble(Fun.ChangeToEnglishNumber(Banking.Text));
                        YearAuto.Total = Convert.ToDouble(Fun.ChangeToEnglishNumber(Total.Text));
                        blc.CreateAutoYear(YearAuto);
                    }
                    else
                    {
                        if (dayR.Checked)
                        {
                            DaysClass Day = new DaysClass();
                            Day.Admin = Admins.Text;
                            Day.Year = int.Parse(YearsCom.Text);
                            Day.Month = MonthsCom.Text;
                            Day.Week = WeeksCom.Text;
                            Day.Day = DC.Text;
                            Day.DayDate = Fun.ChangeToEnglishNumber(DayDate.Text);
                            Day.Banki = Convert.ToDouble(Fun.ChangeToEnglishNumber(Banking.Text));
                            Day.Money = Convert.ToDouble(Fun.ChangeToEnglishNumber(Money.Text));
                            Day.Total = Convert.ToDouble(Fun.ChangeToEnglishNumber(Total.Text));
                            blc.EditDay(Day, ID);
                        }
                        else if (WeekR.Checked)
                        {
                            WeekClass Week = new WeekClass();
                            Week.Admin = Admins.Text;
                            Week.Year = int.Parse(YearsCom.Text);
                            Week.Month = MonthsCom.Text;
                            Week.Week = WeeksCom.Text;
                            Week.Day = DC.Text;
                            Week.DayDate = Fun.ChangeToEnglishNumber(DayDate.Text);
                            Week.Banki = Convert.ToDouble(Fun.ChangeToEnglishNumber(Banking.Text));
                            Week.Money = Convert.ToDouble(Fun.ChangeToEnglishNumber(Money.Text));
                            Week.Total = Convert.ToDouble(Fun.ChangeToEnglishNumber(Total.Text));
                            blc.EditWeek(Week, ID);
                        }
                        else if (MonthR.Checked)
                        {
                            MonthsClass month = new MonthsClass();
                            month.Admin = Admins.Text;
                            month.Year = int.Parse(YearsCom.Text);
                            month.Month = MonthsCom.Text;
                            month.Week = WeeksCom.Text;
                            month.Day = DC.Text;
                            month.DayDate = Fun.ChangeToEnglishNumber(DayDate.Text);
                            month.Banki = Convert.ToDouble(Fun.ChangeToEnglishNumber(Banking.Text));
                            month.Money = Convert.ToDouble(Fun.ChangeToEnglishNumber(Money.Text));
                            month.Total = Convert.ToDouble(Fun.ChangeToEnglishNumber(Total.Text));
                            blc.EditMonth(month, ID);
                        }
                        else if (YearR.Checked)
                        {
                            YearsClass year = new YearsClass();
                            year.Admin = Admins.Text;
                            year.Year = int.Parse(YearsCom.Text);
                            year.Month = MonthsCom.Text;
                            year.Week = WeeksCom.Text;
                            year.Day = DC.Text;
                            year.DayDate = Fun.ChangeToEnglishNumber(DayDate.Text);
                            year.Banki = Convert.ToDouble(Fun.ChangeToEnglishNumber(Banking.Text));
                            year.Money = Convert.ToDouble(Fun.ChangeToEnglishNumber(Money.Text));
                            year.Total = Convert.ToDouble(Fun.ChangeToEnglishNumber(Total.Text));
                            blc.EditYear(year, ID);
                        }

                        SW = true;
                        buttonX1.Text = "ذخیره";
                    }
                    Fun.ClearTextBoxes(this.Controls);
                    RefreshDGV();
                    DayDate.Text = Fun.CLOCK();
                }
                catch
                {
                    MessageBox.Show("مقادیر ورودی را درست وارد کنید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }

            }

        }
        private void Total_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        private void Banking_TextChanged(object sender, EventArgs e)
        {
            try
            {
                NumberFormatInfo nfi = new NumberFormatInfo();
                nfi.NumberDecimalDigits = 0;
                Banking.Text = Int64.Parse(Banking.Text, NumberStyles.AllowThousands).ToString("N", nfi);
                Banking.Select(Banking.Text.Length, 0);
            }
            catch 
            {
            }
            
        }
        private void Money_TextChanged(object sender, EventArgs e)
        {
            try
            {
                NumberFormatInfo nfi = new NumberFormatInfo();
                nfi.NumberDecimalDigits = 0;
                Money.Text = Int64.Parse(Money.Text, NumberStyles.AllowThousands).ToString("N", nfi);
                Money.Select(Money.Text.Length, 0);
            }
            catch
            {
            }
            
        }
        private void Total_TextChanged(object sender, EventArgs e)
        {
            try
            {
                NumberFormatInfo nfi = new NumberFormatInfo();
                nfi.NumberDecimalDigits = 0;
                Total.Text = Int64.Parse(Total.Text, NumberStyles.AllowThousands).ToString("N", nfi);
                Total.Select(Total.Text.Length, 0);
            }
            catch
            {
            }
            
        }
        private void Money_Leave(object sender, EventArgs e)
        {
            try
            {
                NumberFormatInfo nfi = new NumberFormatInfo();
                nfi.NumberDecimalDigits = 0;
                String Number = (Convert.ToDouble(Money.Text) + Convert.ToDouble(Banking.Text)).ToString();
                Total.Text = Int64.Parse(Number, NumberStyles.AllowThousands).ToString("N", nfi);
                Total.Select(Total.Text.Length, 0);
            }
            catch
            {
            }
            
        }
        private void Admins_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshDGV();
            ADMINNAME.Text = Admins.Text;
        }
        private void ToolsBtn_Click(object sender, EventArgs e)
        {
            if (Tap%2==1)
            {
                ToolsPanel.Visible = true;
            }
            else
            {
                ToolsPanel.Visible = false;
            }
            Tap++;
        }
        private void RefreshPage_Click(object sender, EventArgs e)
        {
            RefreshDGV();
        }
        private void Calculator_Click(object sender, EventArgs e)
        {
            double Banki = 0, Money = 0, Total = 0;
            for (int i=0;i<DGV.RowCount;i++)
            {
                Banki += Convert.ToDouble(DGV.Rows[i].Cells[6].Value.ToString());
                Money += Convert.ToDouble(DGV.Rows[i].Cells[7].Value.ToString());
                Total += Convert.ToDouble(DGV.Rows[i].Cells[8].Value.ToString());
            }
            TOTALBANKI.Text = Banki.ToString("#,0");
            TOTALMONEY.Text = Money.ToString("#,0");
            TOTALPRICE.Text = Total.ToString("#,0");
        }
        private void SortDate_Click(object sender, EventArgs e)
        {
            RefreshSortByDateDGV();
        }

        private void SortBanking_Click(object sender, EventArgs e)
        {
            RefreshSortByBankDGV();
        }

        private void SortByMoney_Click(object sender, EventArgs e)
        {
            RefreshSortByMoneyDGV();
        }

        private void ویرایشToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SW = false;
            DayDate.Text = DGV.Rows[DGV.CurrentRow.Index].Cells["Date1"].Value.ToString();
            DC.Text = DGV.Rows[DGV.CurrentRow.Index].Cells["Day2"].Value.ToString();
            WeeksCom.Text = DGV.Rows[DGV.CurrentRow.Index].Cells["Week3"].Value.ToString();
            MonthsCom.Text = DGV.Rows[DGV.CurrentRow.Index].Cells["Month4"].Value.ToString();
            YearsCom.Text = DGV.Rows[DGV.CurrentRow.Index].Cells["Year5"].Value.ToString();
            Banking.Text = DGV.Rows[DGV.CurrentRow.Index].Cells["Bank6"].Value.ToString();
            Money.Text = DGV.Rows[DGV.CurrentRow.Index].Cells["Money7"].Value.ToString();
            Total.Text = DGV.Rows[DGV.CurrentRow.Index].Cells["Total8"].Value.ToString();
            buttonX1.Text = "بروزرسانی";
        }

        private void حذفToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Delete(ID);
            RefreshDGV();
        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            if (dayR.Checked)
            {
                if (DayS.Checked)
                {
                    ShowDAYResultSearch(Fun.ChangeToEnglishNumber(SearchTxt.Text), Admins.Text);
                }
                else if (WeekS.Checked)
                {
                    String Week = WeeksCom.Text;
                    String Month = MonthsCom.Text;
                    int Year = int.Parse(YearsCom.Text);
                    ShowWEEKResultSearch(Year, Month, Week, Admins.Text);
                }
                else if (MonthS.Checked)
                {
                    String Month = MonthsCom.Text;
                    int Year = int.Parse(YearsCom.Text);
                    ShowMONTHResultSearch(Year, Month, Admins.Text);
                }
                else if (YearS.Checked)
                {
                    int Year = int.Parse(YearsCom.Text);

                    ShowYEARResultSearch(Year, Admins.Text);
                }
            }
            else if (WeekR.Checked)
            {
                if (WeekS.Checked)
                {
                    String Week = WeeksCom.Text;
                    String Month = MonthsCom.Text;
                    int Year = int.Parse(YearsCom.Text);
                    ShowWEEKWResultSearch(Year, Month, Week, Admins.Text);
                }
                else if (MonthS.Checked)
                {
                    String Month = MonthsCom.Text;
                    int Year = int.Parse(YearsCom.Text);
                    ShowMONTHWResultSearch(Year, Month, Admins.Text);
                }
                else if (YearS.Checked)
                {
                    int Year = int.Parse(YearsCom.Text);

                    ShowYEARWResultSearch(Year, Admins.Text);
                }
            }
            else if (MonthR.Checked)
            {
                if (MonthS.Checked)
                {
                    String Month = MonthsCom.Text;
                    int Year = int.Parse(YearsCom.Text);
                    ShowMONTHMResultSearch(Year, Month, Admins.Text);
                }
                else if (YearS.Checked)
                {
                    int Year = int.Parse(YearsCom.Text);

                    ShowYEARMResultSearch(Year, Admins.Text);
                }
            }
            else if (YearR.Checked)
            {
                if (YearS.Checked)
                {
                    int Year = int.Parse(YearsCom.Text);

                    ShowYEARYResultSearch(Year, Admins.Text);
                }
            }
            Fun.ClearTextBoxes(this.Controls);
        }

        private void Admins_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            DateCheck(DayDate.Text);
        }

        private void DayDate_Leave(object sender, EventArgs e)
        {
            DateCheck(DayDate.Text);
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
            RefreshDGV();
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
    }
}
