using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace MahtabStore
{
    public partial class DateClass
    {
        /// <summary>
        /// برای کار کردن با تقویم  هجری شمسی
        /// </summary>
        public partial class MaftooxPersianCalendar
        {
            public struct PDate
            {
                public int year;
                public int month;
                public int day;
            }
            /// <summary>
            /// برای کار کردن با تاریخ فارسی
            /// </summary>
            public class DateWork
            {
                #region ..:: Variable Private

                private DateTime DateMe = new DateTime();



                #endregion

                #region ..:: Upate


                /// <summary>
                /// تنظیم نمودن اطلاعات
                /// </summary>
                /// <returns></returns>      

                public void Upate()
                {
                    DateMe = DateTime.Now;

                }
                /// <summary>
                /// تنظیم نمودن اطلاعات
                /// </summary>
                /// <param name="DateSet">DateTime.Now</param>
                public void Upate(DateTime DateSet)
                {
                    DateMe = DateSet;

                }

                #endregion

                #region ..::  Day Work
                /// <summary>
                /// بدست اوردن   روز شمسی
                /// </summary>
                /// <returns></returns>      

                public int GetNumberDayInMonth()
                {
                    int Res;
                    try
                    {
                        PersianCalendar DateFme = new PersianCalendar();
                        Res = DateFme.GetDayOfMonth(DateTime.Now);
                    }
                    catch
                    {
                        Res = 0;
                    }
                    return Res;
                }
                /// <summary>
                /// بدست اوردن نام روز شمسی
                /// </summary>
                /// <returns></returns>      
                public string GetNameDayInMonth()
                {

                    string Resme = "";
                    string Res;
                    PersianCalendar DateFme = new PersianCalendar();
                    Res = DateFme.GetDayOfWeek(DateTime.Now).ToString();
                    switch (Res)
                    {
                        case "Saturday":
                            {
                                Resme = "شنبه";
                                break;
                            }
                        case "Sunday":
                            {
                                Resme = "یکشبه";
                                break;
                            }
                        case "Monday":
                            {
                                Resme = "دو شنبه";
                                break;
                            }
                        case "Tuesday":
                            {
                                Resme = "سه شبه";
                                break;
                            }
                        case "Wednesday":
                            {
                                Resme = "چهار شنبه";
                                break;
                            }
                        case "Thursday":
                            {
                                Resme = "پنج شنبه";
                                break;
                            }
                        case "Friday":
                            {
                                Resme = "جمعه";
                                break;
                            }
                    }
                    return Resme;
                }

                #endregion

                #region ..::  Month Work

                /// <summary>
                /// بدست اوردن نام ماه شمسی
                /// </summary>
                /// <returns></returns>      
                public string GetNameMonth()
                {

                    string Resme = "";
                    string Res;
                    PersianCalendar DateFme = new PersianCalendar();
                    Res = DateFme.GetMonth(DateTime.Now).ToString();
                    switch (Res)
                    {
                        case "1":
                            {
                                Resme = "فروردین";
                                break;
                            }
                        case "2":
                            {
                                Resme = "اردیبهشت";
                                break;
                            }
                        case "3":
                            {
                                Resme = "خرداد";
                                break;
                            }
                        case "4":
                            {
                                Resme = "تیر";
                                break;
                            }
                        case "5":
                            {
                                Resme = "مرداد";
                                break;
                            }
                        case "6":
                            {
                                Resme = "شهریور";
                                break;
                            }

                        case "7":
                            {
                                Resme = "مهر";
                                break;
                            }
                        case "8":
                            {
                                Resme = "ابان";
                                break;
                            }
                        case "9":
                            {
                                Resme = "اذر";
                                break;
                            }


                        case "10":
                            {
                                Resme = "دی";
                                break;
                            }
                        case "11":
                            {
                                Resme = "بهمن";
                                break;
                            }
                        case "12":
                            {
                                Resme = "اسفند";
                                break;
                            }



                    }




                    return Resme;


                }
                /// <summary>
                /// بدست اوردن ماه شمسی
                /// </summary>
                /// <returns></returns>         
                public int GetNumberMonth()
                {
                    string Res;
                    PersianCalendar DateFme = new PersianCalendar();
                    Res = DateFme.GetMonth(DateMe).ToString();
                    return Convert.ToInt32(Res);
                }

                #endregion

                #region ..::  Years Work
                /// <summary>
                /// بدست اوردن سال شمسی
                /// </summary>
                /// <returns></returns>
                public int GetNumberYear()
                {
                    string Res;
                    PersianCalendar DateFme = new PersianCalendar();
                    Res = DateFme.GetYear(DateTime.Now).ToString();
                    return Convert.ToInt32(Res);
                }


                #endregion

                /// <summary>
                /// ایا این سال کبیسه است یا نه
                /// </summary>
                /// <returns>Boolean</returns>
                public Boolean Kabiseh()
                {
                    Boolean Flag;
                    int Year = Convert.ToInt32(GetNumberYear());


                    if (((Year - 3) % 4) == 0)
                    {
                        Flag = true;
                    }
                    else
                    {
                        Flag = false;
                    }


                    return Flag;
                }



                public DateTime Shamsi2Miladi(string date1)
                {
                    try
                    {
                        int year = int.Parse(date1.Substring(0, 4));
                        int month = int.Parse(date1.Substring(5, 2));
                        int day = int.Parse(date1.Substring(8, 2));
                        PersianCalendar p = new PersianCalendar();
                        return p.ToDateTime(year, month, day, 0, 0, 0, 0);
                    }
                    catch
                    {
                        return DateTime.Now;
                    }
                }



                public string Miladi2Shamsi(DateTime date1)
                {
                    PersianCalendar pc = new PersianCalendar();
                    StringBuilder sb = new StringBuilder();
                    sb.Append(pc.GetYear(date1).ToString("0000"));
                    sb.Append("/");
                    sb.Append(pc.GetMonth(date1).ToString("00"));
                    sb.Append("/");
                    sb.Append(pc.GetDayOfMonth(date1).ToString("00"));
                    return sb.ToString();
                }
                
                /*
                /// <summary>
                /// تبدیل تاریخ شمسی به میلادی 
                /// </summary>
                /// <param name="Input">  (02/01/1388 )تاریخ شمسی </param>                      
                public DateTime ShamsiTomiladi(string Input)
                {
                    PersianCalendar Pe = new PersianCalendar();
 
 
                    int year = Convert.ToInt32(Input.Substring(6, 4));
                    int Month = Convert.ToInt32(Input.Substring(3, 2));
                    int Day = Convert.ToInt32(Input.Substring(0, 2));
                    return Pe.ToDateTime(year, Month, Day, 10, 20, 21, 21);
 
                }
 
 
                /// <summary>
                /// تبدیل تاریخ میلادی به شمسی
                /// </summary>
                /// <param name="Input">تاریخ انگلیسی  (DateTime .Now ) </param>             
                public String MiliadiToshamsi(DateTime Input)
                {
                    PersianCalendar Pe = new PersianCalendar();
 
                    string s = Pe.GetDayOfMonth(Input).ToString() + "/" + Pe.GetMonth(Input).ToString() + "/" + Pe.GetYear(Input).ToString();
 
 
                    return s;
 
                }
 
                */

                /// <summary>
                /// کم کردن تاریخ ها از یکدیگر
                /// </summary>
                /// <param name="pdate1"> 1386/12/22</param>
                /// <param name="pdate2"> 1386/12/22</param>
                /// <returns></returns>
                public PDate SubDate(string pdate1, string pdate2)
                {
                    PersianCalendar pc = new PersianCalendar();
                    DateTime d1, d2;
                    TimeSpan ts = new TimeSpan();

                    PDate pd1;
                    PDate pd2;
                    PDate pdout;
                    pd1.year = int.Parse(pdate1.Substring(0, 4));//1386/12/22
                    pd1.month = int.Parse(pdate1.Substring(5, 2));
                    pd1.day = int.Parse(pdate1.Substring(8, 2));
                    pd2.year = int.Parse(pdate2.Substring(0, 4));
                    pd2.month = int.Parse(pdate2.Substring(5, 2));
                    pd2.day = int.Parse(pdate2.Substring(8, 2));
                    d1 = pc.ToDateTime(pd1.year, pd1.month, pd1.day, 0, 0, 0, 0, 0);
                    d2 = pc.ToDateTime(pd2.year, pd2.month, pd2.day, 0, 0, 0, 0, 0);

                    ts = d1 - d2;
                    pdout.year = d1.Year - d2.Year;
                    pdout.month = pdout.year * 12 + (d1.Month - d2.Month);
                    pdout.day = ts.Days;
                    return pdout;

                }
            }

            /// <summary>
            /// برای کار کردن با زمان فارسی
            /// </summary>
            public class TimeWork
            {
                #region ..:: Variable Private

                private DateTime DateMe = new DateTime();



                #endregion

                #region ..:: Upate

                public void Upate()
                {
                    DateMe = DateTime.Now;

                }

                public void Upate(DateTime DateSet)
                {
                    DateMe = DateSet;

                }

                #endregion


                #region ..:: events

                public int GetNumberHour()
                {
                    int Res;
                    try
                    {

                        PersianCalendar DateFme = new PersianCalendar();

                        Res = DateFme.GetHour(DateMe);


                    }
                    catch
                    {
                        Res = 0;
                    }


                    return Res;


                }

                public int GetNumberMinute()
                {
                    int Res;
                    try
                    {

                        PersianCalendar DateFme = new PersianCalendar();

                        Res = DateFme.GetMinute(DateMe);


                    }
                    catch
                    {
                        Res = 0;
                    }


                    return Res;


                }

                public int GetNumberSecond()
                {
                    int Res;
                    try
                    {

                        PersianCalendar DateFme = new PersianCalendar();

                        Res = DateFme.GetSecond(DateMe);


                    }
                    catch
                    {
                        Res = 0;
                    }


                    return Res;


                }

                public DateTime GetFullTime()
                {
                    DateTime Res = new DateTime();
                    try
                    {
                        Res = DateTime.Now;
                        Res = Convert.ToDateTime(Convert.ToString(GetNumberHour()) + ":" + Convert.ToString(GetNumberMinute()) + ":" + Convert.ToString(GetNumberSecond()));

                    }
                    catch
                    {

                    }
                    return Res;
                }

                public Boolean IsAm()
                {
                    Boolean Flag = false;
                    int f = -1;

                    string St = Convert.ToString(DateTime.Now);
                    try
                    {
                        f = St.IndexOf("am");
                        if (f != -1)
                        { Flag = true; }
                        else
                        { Flag = false; }
                    }
                    catch
                    {

                    }




                    return Flag;

                }
                public Boolean IsPm()
                {
                    Boolean Flag = false;
                    int f = -1;
                    string St = Convert.ToString(DateTime.Now);
                    try
                    {
                        f = St.IndexOf("pm");
                        if (f != -1)
                        { Flag = true; }
                        else
                        { Flag = false; }
                    }
                    catch
                    {

                    }
                    return Flag;
                }

                public Boolean IsFarsiAm()
                {
                    Boolean Flag = false;
                    int f = -1;
                    string St = Convert.ToString(DateTime.Now);
                    try
                    {
                        f = St.IndexOf("ق.ظ");
                        if (f != -1)
                        { Flag = true; }
                        else
                        { Flag = false; }
                    }
                    catch
                    {

                    }
                    return Flag;
                }


                public Boolean IsFarsiPm()
                {
                    Boolean Flag = false;
                    int f = -1;

                    string St = Convert.ToString(DateTime.Now);
                    try
                    {
                        f = St.IndexOf("ب.ظ");
                        if (f != -1)
                        { Flag = true; }
                        else
                        { Flag = false; }
                    }
                    catch
                    {

                    }




                    return Flag;

                }

                #endregion

            }

        }

        /// <summary>
        /// برای کار کردن با تقویم  هجری قمری
        /// </summary>
        public partial class MaftooxArabicCalendar
        {
            public struct PDate
            {
                public int year;
                public int month;
                public int day;
            }
            /// <summary>
            /// برای کار کردن با تاریخ  هجری قمری
            /// </summary>
            public class DateWork
            {
                #region ..:: Variable Private

                private DateTime DateMe = new DateTime();



                #endregion

                #region ..:: Upate


                /// <summary>
                /// تنظیم نمودن اطلاعات
                /// </summary>
                /// <returns></returns>      

                public void Upate()
                {
                    DateMe = DateTime.Now;

                }
                /// <summary>
                /// تنظیم نمودن اطلاعات
                /// </summary>
                /// <param name="DateSet">DateTime.Now</param>
                public void Upate(DateTime DateSet)
                {
                    DateMe = DateSet;

                }

                #endregion

                #region ..::  Day Work
                /// <summary>
                /// بدست اوردن   روز هجری
                /// </summary>
                /// <returns></returns>      

                public int GetNumberDayInMonth()
                {
                    int Res;
                    try
                    {
                        HijriCalendar DateFme = new HijriCalendar();
                        Res = DateFme.GetDayOfMonth(DateMe);
                    }
                    catch
                    {
                        Res = 0;
                    }
                    return Res;
                }
                /// <summary>
                /// بدست اوردن نام روز هجری
                /// </summary>
                /// <returns></returns>      
                public string GetNameDayInMonth()
                {

                    string Resme = "";
                    string Res;
                    HijriCalendar DateFme = new HijriCalendar();
                    Res = DateFme.GetDayOfWeek(DateMe).ToString();
                    switch (Res)
                    {
                        case "Saturday":
                            {
                                Resme = "اِسَّبِت";
                                break;
                            }
                        case "Sunday":
                            {
                                Resme = "اِلأَحَّد";
                                break;
                            }
                        case "Monday":
                            {
                                Resme = "اِلأِثنين";
                                break;
                            }
                        case "Tuesday":
                            {
                                Resme = "اِثَّلاثا";
                                break;
                            }
                        case "Wednesday":
                            {
                                Resme = "اِلأَربِعا";
                                break;
                            }
                        case "Thursday":
                            {
                                Resme = "اِلخَميس";
                                break;
                            }
                        case "Friday":
                            {
                                Resme = "اِجُّمعَة";
                                break;
                            }
                    }
                    return Resme;
                }

                #endregion

                #region ..::  Month Work

                /// <summary>
                /// بدست اوردن نام ماه هجری
                /// </summary>
                /// <returns></returns>      
                public string GetNameMonth()
                {

                    string Resme = "";
                    string Res;
                    HijriCalendar DateFme = new HijriCalendar();
                    Res = DateFme.GetMonth(DateMe).ToString();
                    switch (Res)
                    {
                        case "1":
                            {
                                Resme = "محرم";
                                break;
                            }
                        case "2":
                            {
                                Resme = "صفر";
                                break;
                            }
                        case "3":
                            {
                                Resme = "ربيع الاول";
                                break;
                            }
                        case "4":
                            {
                                Resme = "ربيع الثاني";
                                break;
                            }
                        case "5":
                            {
                                Resme = "جمادي الاولي";
                                break;
                            }
                        case "6":
                            {
                                Resme = "جمادي الثانيه";
                                break;
                            }

                        case "7":
                            {
                                Resme = "رجب";
                                break;
                            }
                        case "8":
                            {
                                Resme = "شعبان";
                                break;
                            }
                        case "9":
                            {
                                Resme = "رمضان";
                                break;
                            }


                        case "10":
                            {
                                Resme = "شوال";
                                break;
                            }
                        case "11":
                            {
                                Resme = "ذو القعده";
                                break;
                            }
                        case "12":
                            {
                                Resme = "ذو الحجه";
                                break;
                            }



                    }




                    return Resme;


                }
                /// <summary>
                /// بدست اوردن ماه هجری
                /// </summary>
                /// <returns></returns>         
                public int GetNumberMonth()
                {
                    string Res;
                    HijriCalendar DateFme = new HijriCalendar();
                    Res = DateFme.GetMonth(DateMe).ToString();
                    return Convert.ToInt32(Res);
                }

                #endregion

                #region ..::  Years Work
                /// <summary>
                /// بدست اوردن سال هجری
                /// </summary>
                /// <returns></returns>
                public int GetNumberYear()
                {
                    string Res;
                    HijriCalendar DateFme = new HijriCalendar();
                    Res = DateFme.GetYear(DateMe).ToString();
                    return Convert.ToInt32(Res);
                }


                #endregion

                /// <summary>
                /// تبدیل تاریخ هجری به میلادی 
                /// </summary>
                /// <param name="Input">  (02/01/1388 )تاریخ شمسی </param>                      
                public DateTime HijriTomiladi(string Input)
                {
                    HijriCalendar Pe = new HijriCalendar();


                    int year = Convert.ToInt32(Input.Substring(6, 4));
                    int Month = Convert.ToInt32(Input.Substring(3, 2));
                    int Day = Convert.ToInt32(Input.Substring(0, 2));
                    return Pe.ToDateTime(year, Month, Day, 10, 20, 21, 21);

                }


                /// <summary>
                /// تبدیل تاریخ میلادی به هجری
                /// </summary>
                /// <param name="Input">تاریخ انگلیسی  (DateTime .Now ) </param>             
                public String MiliadiToHijri(DateTime Input)
                {
                    HijriCalendar Pe = new HijriCalendar();
                    string s = Pe.GetDayOfMonth(Input).ToString() + "/" + Pe.GetMonth(Input).ToString() + "/" + Pe.GetYear(Input).ToString();

                    return s;

                }



                /// <summary>
                /// کم کردن تاریخ ها از یکدیگر
                /// </summary>
                /// <param name="pdate1"></param>
                /// <param name="pdate2"></param>
                /// <returns></returns>
                public PDate SubDate(string pdate1, string pdate2)
                {
                    HijriCalendar pc = new HijriCalendar();
                    DateTime d1, d2;
                    TimeSpan ts = new TimeSpan();

                    PDate pd1;
                    PDate pd2;
                    PDate pdout;
                    pd1.year = int.Parse(pdate1.Substring(0, 4));//1386/12/22
                    pd1.month = int.Parse(pdate1.Substring(5, 2));
                    pd1.day = int.Parse(pdate1.Substring(8, 2));
                    pd2.year = int.Parse(pdate2.Substring(0, 4));
                    pd2.month = int.Parse(pdate2.Substring(5, 2));
                    pd2.day = int.Parse(pdate2.Substring(8, 2));
                    d1 = pc.ToDateTime(pd1.year, pd1.month, pd1.day, 0, 0, 0, 0, 0);
                    d2 = pc.ToDateTime(pd2.year, pd2.month, pd2.day, 0, 0, 0, 0, 0);

                    ts = d1 - d2;
                    pdout.year = d1.Year - d2.Year;
                    pdout.month = pdout.year * 12 + (d1.Month - d2.Month);
                    pdout.day = ts.Days;
                    return pdout;

                }


            }

            /// <summary>
            /// برای کار کردن با زمان هجری
            /// </summary>
            public class TimeWork
            {
                #region ..:: Variable Private

                private DateTime DateMe = new DateTime();



                #endregion

                #region ..:: Upate

                public void Upate()
                {
                    DateMe = DateTime.Now;

                }

                public void Upate(DateTime DateSet)
                {
                    DateMe = DateSet;

                }

                #endregion



                public int GetNumberHour()
                {
                    int Res;
                    try
                    {

                        HijriCalendar DateFme = new HijriCalendar();

                        Res = DateFme.GetHour(DateMe);


                    }
                    catch
                    {
                        Res = 0;
                    }


                    return Res;


                }

                public int GetNumberMinute()
                {
                    int Res;
                    try
                    {

                        HijriCalendar DateFme = new HijriCalendar();

                        Res = DateFme.GetMinute(DateMe);


                    }
                    catch
                    {
                        Res = 0;
                    }


                    return Res;


                }

                public int GetNumberSecond()
                {
                    int Res;
                    try
                    {

                        HijriCalendar DateFme = new HijriCalendar();

                        Res = DateFme.GetSecond(DateMe);


                    }
                    catch
                    {
                        Res = 0;
                    }


                    return Res;


                }

                public DateTime GetFullTime()
                {






                    DateTime Res = new DateTime();

                    try
                    {
                        Res = DateTime.Now;
                        Res = Convert.ToDateTime(Convert.ToString(GetNumberHour()) + ":" + Convert.ToString(GetNumberMinute()) + ":" + Convert.ToString(GetNumberSecond()));

                    }
                    catch
                    {

                    }


                    return Res;


                }

                public Boolean IsAm()
                {
                    Boolean Flag = false;
                    int f = -1;

                    string St = Convert.ToString(DateTime.Now);
                    try
                    {
                        f = St.IndexOf("am");
                        if (f != -1)
                        { Flag = true; }
                        else
                        { Flag = false; }
                    }
                    catch
                    {

                    }




                    return Flag;

                }


                public Boolean IsPm()
                {
                    Boolean Flag = false;
                    int f = -1;

                    string St = Convert.ToString(DateTime.Now);
                    try
                    {
                        f = St.IndexOf("pm");
                        if (f != -1)
                        { Flag = true; }
                        else
                        { Flag = false; }
                    }
                    catch
                    {

                    }




                    return Flag;

                }



            }

        }

        /// <summary>
        /// تبدیل عدد به حروف فارسی
        /// </summary>
        public partial class MaftooxNumberToPersianText
        {
            //
            // Get Yekan
            //
            private string GetYekan(string S)
            {
                string Res = "";

                switch (Convert.ToInt32(S))
                {
                    case 1: Res = "يک"; break;
                    case 2: Res = "دو"; break;
                    case 3: Res = "سه"; break;
                    case 4: Res = "چهار"; break;
                    case 5: Res = "پنج"; break;
                    case 6: Res = "شش"; break;
                    case 7: Res = "هفت"; break;
                    case 8: Res = "هشت"; break;
                    case 9: Res = "نه"; break;
                    default: Res = ""; break;
                }

                // Return value
                return Res;
            }

            //
            // Get Dahgan
            //
            private string GetDahgan(string S)
            {
                string Res = "";

                switch (Convert.ToInt32(S))
                {
                    case 10:
                    case 1: Res = "ده"; break;
                    case 2: Res = "بيست"; break;
                    case 3: Res = "سي"; break;
                    case 4: Res = "چهل"; break;
                    case 5: Res = "پنجاه"; break;
                    case 6: Res = "شصت"; break;
                    case 7: Res = "هفتاد"; break;
                    case 8: Res = "هشتاد"; break;
                    case 9: Res = "نود"; break;
                    case 11: Res = "يازده"; break;
                    case 12: Res = "دوازده"; break;
                    case 13: Res = "سيزده"; break;
                    case 14: Res = "چهارده"; break;
                    case 15: Res = "پانزده"; break;
                    case 16: Res = "شانزده"; break;
                    case 17: Res = "هفده"; break;
                    case 18: Res = "هجده"; break;
                    case 19: Res = "نوزده"; break;
                    default: Res = ""; break;
                }

                // Return value
                return Res;
            }

            //
            // Get Sadgan
            //
            private string GetSadgan(string S)
            {
                string Res = "";

                switch (Convert.ToInt32(S))
                {
                    case 1: Res = "يکصد"; break;
                    case 2: Res = "دويست"; break;
                    case 3: Res = "سيصد"; break;
                    case 4: Res = "چهارصد"; break;
                    case 5: Res = "پانصد"; break;
                    case 6: Res = "ششصد"; break;
                    case 7: Res = "هفتصد"; break;
                    case 8: Res = "هشتصد"; break;
                    case 9: Res = "نهصد"; break;
                    default: Res = ""; break;
                }

                // Return value
                return Res;
            }

            private string ConvertToString(string num)
            {
                //Check for Number Range
                if ((num.Length > 18) || (num.Length < 1))
                    return "";
                else
                    try { num = Convert.ToInt64(num.Trim()).ToString(); }
                    catch { return ""; }

                string Res = "";
                string Num = Convert.ToInt64(num.Trim()).ToString();
                string[] Degress = new string[6];
                int Deg = 0;

                // Set Degress level
                Degress[0] = ""; Degress[1] = "هزار";
                Degress[2] = "ميليون"; Degress[3] = "ميليارد";
                Degress[4] = "تريليون"; Degress[5] = "تريليارد";
                Deg = 0;

                // Try to get string format
                while (num.Length > 0)
                {
                    // Get Master Number
                    Num = num;

                    // Our number is beetwen 0-9        --------------------
                    if (Num.Length == 1)
                    {
                        if (Num != "0")
                            Res = GetYekan(Num) + " " + Degress[Deg++] +
                                (Res != "" ? " و " : " ") + Res;
                        else
                            Deg++;
                        num = "";
                    }
                    // Our number is beetwen 0-99       --------------------
                    else if (Num.Length == 2)
                    {
                        // Get Master Number
                        Num = num;

                        if (Num != "00")
                        {
                            // Number is beetwen 10-19
                            if (Num[0] == '1') Res = GetDahgan(Num) + " " + Degress[Deg++] +
                                                   (Res != "" ? " و " : " ") + Res;
                            else Res = GetDahgan(Num[0].ToString()) +
                                     (Num[1] != '0' ? " و " : " ") +
                                     GetYekan(Num[1].ToString()) +
                                     " " + Degress[Deg++] +
                                     (Res != "" ? " و " : " ") + Res;
                        }
                        else
                            Deg++;
                        num = "";
                    }
                    // Our number is beetwen 0-999  --------------------
                    else if (Num.Length >= 3)
                    {
                        int Mx = num.Length - 1;
                        // Get Master Number
                        Num = num[Mx - 2].ToString() + num[Mx - 1].ToString() + num[Mx].ToString();

                        if (Num != "000")
                        {
                            // Number is beetwen 10-19
                            if (Num[1] == '1')
                                Res = GetSadgan(Num[0].ToString()) +
                                        (Num[0] != '0' ? " و " : " ") +
                                        GetDahgan(Num[1].ToString() + Num[2].ToString()) +
                                        " " + Degress[Deg++] +
                                        (Res != "" ? " و " : " ") + Res;
                            else
                                Res = GetSadgan(Num[0].ToString()) +
                                        (((Num[1] != '0') || (Num[2] != '0')) && (Num[0] != '0') ? " و " : "") +
                                        GetDahgan(Num[1].ToString()) +
                                        ((Num[2] != '0') && (Num[1] != '0') ? " و " : "") +
                                        GetYekan(Num[2].ToString()) +
                                        " " + Degress[Deg++] +
                                        (Res != "" ? " و " : " ") + Res;
                        }
                        else
                            Deg++;
                        Num = "";

                        // Decrease Master number
                        for (int i = 0; i < num.Length - 3; i++)
                            Num += num[i].ToString();
                        num = Num;
                    }
                }

                // Return value
                return Res.TrimEnd();
            }

            /// <summary>
            /// تبدیل عدد به حروف
            /// </summary>
            /// <param name="num">Example ( 123 )</param>
            /// <returns></returns>        
            public string ConvertNumToString(string num)
            {
                string ret = string.Empty;

                try { ret = ConvertToString(num); }
                catch { }


                return ret;

            }



        }

    }

}