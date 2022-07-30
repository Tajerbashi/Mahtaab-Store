using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using BEE;
using System.Data.SqlClient;
namespace DAL
{
    public class DALClass
    {
        DBClass DB = new DBClass();
        public void DisActive(int ID)
        {
            Admin admin = DB.admins.Where(c => c.ID == ID).FirstOrDefault();
            admin.Activation = false;
            DB.SaveChanges();
        }
        public void ChangeStatusAdmin(int ID)
        {
            Admin admin = DB.admins.Where(c => c.ID == ID).FirstOrDefault();
            admin.Activation = (admin.Activation) ? false : true;
            DB.SaveChanges();
        }
        public String GetPass(String User,String Name,String Phone)
        {
            foreach (var item in DB.admins)
            {
                if ( item.UserName==User && item.FullName==Name && item.Phone==Phone)
                {
                    return item.Password;
                }
            }
            return "0";
        }

        public void Backup(String Path)
        {
            String cnstr = "Data Source=.;Initial Catalog=MahtabStoreDB;Integrated Security=true";
            SqlConnection connection = new SqlConnection(cnstr);
            connection.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = @"BACKUP DATABASE MahtabStoreDB TO DISK = '" + Path + @"\BACKUPDB.BAK'";
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void Restor(String Path)
        {
            if (Path.Length != 0)
            {
                String cnstr = "Data Source=.;Initial Catalog=master;Integrated Security=true";
                SqlConnection connection = new SqlConnection(cnstr);
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "alter database MahtabStoreDB set offline with rollback immediate";
                command.ExecuteNonQuery();
                command.CommandText = @" RESTORE DATABASE MahtabStoreDB FROM DISK = '" + Path + "' WITH REPLACE";
                command.ExecuteNonQuery();
                command.CommandText = "alter database MahtabStoreDB set online";
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
        public bool AccessAdmin(String User,String Pass)
        {
            foreach (var item in DB.admins)
            {
                if (item.UserName==User && item.Password==Pass && item.Activation)
                {
                    return true;
                }
            }
            return false;
        }
        public bool CheckUser(Admin admin)
        {
            foreach (var item in DB.admins)
            {
                if (item.FullName==admin.FullName && item.UserName==admin.UserName && item.Password==admin.Password && item.Activation)
                {
                    return false;
                }
            }
            DB.admins.Add(admin);
            return true;
        }
        public void CreateAdmin(Admin admin)
        {
            DB.admins.Add(admin);
            DB.SaveChanges();
        }
        public List<Admin> GetAllAdmins()
        {
            return (DB.admins.Where(c => c.Activation).ToList());
        }
        public bool ExistAdmin(Admin admin)
        {
            foreach (var item in DB.admins)
            {
                if (item.FullName==admin.FullName && item.Phone==admin.Phone && item.UserName==admin.UserName)
                {
                    return true;
                }
            }
            return false;
        }
        public void DeleteAdmin(int ID)
        {
            Admin admin = DB.admins.Where(c => c.ID == ID).FirstOrDefault();
            DB.admins.Remove(admin);
            DB.SaveChanges();
        }
        public bool EditAdmin(Admin admin,int ID)
        {
            Admin nadmin = DB.admins.Where(c => c.ID == ID).FirstOrDefault();
            nadmin.FullName = admin.FullName;
            nadmin.Phone = admin.Phone;
            nadmin.UserName = admin.UserName;
            nadmin.Password = admin.Password;
            DB.SaveChanges();
            return true;
        }

        //  Crud Create Exist
        public void CreateDayReport(DaysClass Day)
        {
            DB.days.Add(Day);
            DB.SaveChanges();
        }
        public bool ExisDay(DaysClass Day)
        {
            foreach (var item in DB.days)
            {
                if (item.Admin==Day.Admin && item.DayDate==Day.DayDate)
                {
                    return true;
                }
            }
            return false;
        }
        
        public void CreateWeekReport(WeekClass Week)
        {
            DB.weeks.Add(Week);
            DB.SaveChanges();
        }
        public bool ExisWeek(WeekClass Week)
        {
            foreach (var item in DB.weeks)
            {
                if (item.Admin == Week.Admin && item.DayDate == Week.DayDate)
                {
                    return true;
                }
            }
            return false;
        }
        
        public void CreateMonthReport(MonthsClass month)
        {
            DB.months.Add(month);
            DB.SaveChanges();
        }
        public bool ExisMonth(MonthsClass month)
        {
            foreach (var item in DB.months)
            {
                if (item.Admin == month.Admin && item.DayDate == month.DayDate)
                {
                    return true;
                }
            }
            return false;
        }
        
        public void CreateYearReport(YearsClass year)
        {
            DB.years.Add(year);
            DB.SaveChanges();
        }
        public bool ExisYear(YearsClass year)
        {
            foreach (var item in DB.years)
            {
                if (item.Admin == year.Admin && item.DayDate == year.DayDate)
                {
                    return true;
                }
            }
            return false;
        }
        
        //  Get All
        public List<DaysClass> GetAllDays(String Admin, String Start, String End)
        {
            return DB.days.Where(c => c.Admin==Admin && ((String.Compare(c.DayDate, Start) >= 0) && (String.Compare(c.DayDate, End) <= 0))).ToList();
        }
        public List<WeekClass> GetAllWeeks(String Admin, String Start, String End)
        {
            return DB.weeks.Where(c => c.Admin == Admin && ((String.Compare(c.DayDate, Start) >= 0) && (String.Compare(c.DayDate, End) <= 0))).ToList();
        }
        public List<MonthsClass> GetAllMonths(String Admin, String Start, String End)
        {
            return DB.months.Where(c => c.Admin == Admin && ((String.Compare(c.DayDate, Start) >= 0) && (String.Compare(c.DayDate, End) <= 0))).ToList();
        }
        public List<YearsClass> GetAllYears(String Admin, String Start, String End)
        {
            return DB.years.Where(c => c.Admin == Admin && ((String.Compare(c.DayDate, Start) >= 0) && (String.Compare(c.DayDate, End) <= 0))).ToList();
        }
        public List<CheckBank> GetAllChecks(String Admin, String Start, String End)
        {
            return DB.checkBanks.Where(c => c.Admin == Admin && ((String.Compare(c.DayDate, Start) >= 0) && (String.Compare(c.DayDate, End) <= 0))).ToList();
        }
        
        //  Show Sort Type
        public List<DaysClass> GetAllDaysSortByDate(String Admin, String Start, String End)
        {
            return DB.days.Where(c => c.Admin == Admin && ((String.Compare(c.DayDate, Start) >= 0) && (String.Compare(c.DayDate, End) <= 0))).OrderBy(c => c.DayDate).ToList();
        }
        public List<WeekClass> GetAllWeeksSortByDate(String Admin, String Start, String End)
        {
            return DB.weeks.Where(c => c.Admin == Admin && ((String.Compare(c.DayDate, Start) >= 0) && (String.Compare(c.DayDate, End) <= 0))).OrderBy(c => c.DayDate).ToList();
        }
        public List<MonthsClass> GetAllMonthsSortByDate(String Admin, String Start, String End)
        {
            return DB.months.Where(c => c.Admin == Admin && ((String.Compare(c.DayDate, Start) >= 0) && (String.Compare(c.DayDate, End) <= 0))).OrderBy(c => c.DayDate).ToList();
        }
        public List<YearsClass> GetAllYearsSortByDate(String Admin, String Start, String End)
        {
            return DB.years.Where(c => c.Admin == Admin && ((String.Compare(c.DayDate, Start) >= 0) && (String.Compare(c.DayDate, End) <= 0))).OrderBy(c => c.DayDate).ToList();
        }
        public List<CheckBank> GetAllChecksSortByDate(String Admin, String Start, String End)
        {
            return DB.checkBanks.Where(c => c.Admin == Admin && ((String.Compare(c.DayDate, Start) >= 0) && (String.Compare(c.DayDate, End) <= 0))).OrderBy(c => c.DayDate).ToList();
        }
        
        //  Show Sort Type Bank
        public List<DaysClass> GetAllDaysSortByBank(String Admin, String Start, String End)
        {
            return DB.days.Where(c => c.Admin == Admin && ((String.Compare(c.DayDate, Start) >= 0) && (String.Compare(c.DayDate, End) <= 0))).OrderByDescending(c => c.Banki).ToList();
        }
        public List<WeekClass> GetAllWeeksSortByBank(String Admin, String Start, String End)
        {
            return DB.weeks.Where(c => c.Admin == Admin && ((String.Compare(c.DayDate, Start) >= 0) && (String.Compare(c.DayDate, End) <= 0))).OrderByDescending(c => c.Banki).ToList();
        }
        public List<MonthsClass> GetAllMonthsSortByBank(String Admin, String Start, String End)
        {
            return DB.months.Where(c => c.Admin == Admin && ((String.Compare(c.DayDate, Start) >= 0) && (String.Compare(c.DayDate, End) <= 0))).OrderByDescending(c => c.Banki).ToList();
        }
        public List<YearsClass> GetAllYearsSortByBank(String Admin, String Start, String End)
        {
            return DB.years.Where(c => c.Admin == Admin && ((String.Compare(c.DayDate, Start) >= 0) && (String.Compare(c.DayDate, End) <= 0))).OrderByDescending(c => c.Banki).ToList();
        }
        
        //  Show Sort Type Money
        public List<DaysClass> GetAllDaysSortByMoney(String Admin, String Start, String End)
        {
            return DB.days.Where(c => c.Admin == Admin && ((String.Compare(c.DayDate, Start) >= 0) && (String.Compare(c.DayDate, End) <= 0))).OrderByDescending(c => c.Money).ToList();
        }
        public List<WeekClass> GetAllWeeksSortByMoney(String Admin, String Start, String End)
        {
            return DB.weeks.Where(c => c.Admin == Admin && ((String.Compare(c.DayDate, Start) >= 0) && (String.Compare(c.DayDate, End) <= 0))).OrderByDescending(c => c.Money).ToList();
        }
        public List<MonthsClass> GetAllMonthsSortByMoney(String Admin, String Start, String End)
        {
            return DB.months.Where(c => c.Admin == Admin && ((String.Compare(c.DayDate, Start) >= 0) && (String.Compare(c.DayDate, End) <= 0))).OrderByDescending(c => c.Money).ToList();
        }
        public List<YearsClass> GetAllYearsSortByMoney(String Admin, String Start, String End)
        {
            return DB.years.Where(c => c.Admin == Admin && ((String.Compare(c.DayDate, Start) >= 0) && (String.Compare(c.DayDate, End) <= 0))).OrderByDescending(c => c.Money).ToList();
        }

        //  Delete
        public void DeleteDay(int ID)
        {
            DaysClass Day = DB.days.Where(c => c.ID == ID).FirstOrDefault();
            DB.days.Remove(Day);
            DB.SaveChanges();
        }
        public void DeleteWeek(int ID)
        {
            WeekClass Week = DB.weeks.Where(c => c.ID == ID).FirstOrDefault();
            DB.weeks.Remove(Week);
            DB.SaveChanges();
        }
        public void DeleteMonth(int ID)
        {
            MonthsClass month = DB.months.Where(c => c.ID == ID).FirstOrDefault();
            DB.months.Remove(month);
            DB.SaveChanges();
        }
        public void DeleteYear(int ID)
        {
            YearsClass Year = DB.years.Where(c => c.ID == ID).FirstOrDefault();
            DB.years.Remove(Year);
            DB.SaveChanges();
        }

        //  Edit
        public void EditDay(DaysClass NDay,int ID)
        {
            DaysClass Day = DB.days.Where(c => c.ID == ID).FirstOrDefault();
            Day.Admin = NDay.Admin;
            Day.Year = NDay.Year;
            Day.Month = NDay.Month;
            Day.Week = NDay.Week;
            Day.Day = NDay.Day;
            Day.DayDate = NDay.DayDate;
            Day.Banki = NDay.Banki;
            Day.Money = NDay.Money;
            Day.Total = NDay.Total;
            DB.SaveChanges();
        }
        public void EditWeek(WeekClass week,int ID)
        {
            WeekClass Week = DB.weeks.Where(c => c.ID == ID).FirstOrDefault();
            Week.Admin = week.Admin;
            Week.Year = week.Year;
            Week.Month = week.Month;
            Week.Week = week.Week;
            Week.Day = week.Day;
            Week.DayDate = week.DayDate;
            Week.Banki = week.Banki;
            Week.Money = week.Money;
            Week.Total = week.Total;
            DB.SaveChanges();
        }
        public void EditMonth(MonthsClass month, int ID)
        {
            MonthsClass Month = DB.months.Where(c => c.ID == ID).FirstOrDefault();
            Month.Admin = month.Admin;
            Month.Year = month.Year;
            Month.Month = month.Month;
            Month.Week = month.Week;
            Month.Day = month.Day;
            Month.DayDate = month.DayDate;
            Month.Banki = month.Banki;
            Month.Money = month.Money;
            Month.Total = month.Total;
            DB.SaveChanges();
        }
        public void EditYear(YearsClass year, int ID)
        {
            YearsClass Year = DB.years.Where(c => c.ID == ID).FirstOrDefault();
            Year.Admin = year.Admin;
            Year.Year = year.Year;
            Year.Month = year.Month;
            Year.Week = year.Week;
            Year.Day = year.Day;
            Year.DayDate = year.DayDate;
            Year.Banki = year.Banki;
            Year.Money = year.Money;
            Year.Total = year.Total;
            DB.SaveChanges();
        }

        //  Search Day
        public List<DaysClass> SearchDay(String Word, String Admin, String Start, String End)
        {
            return DB.days.Where(c => c.DayDate == Word && c.Admin==Admin && ((String.Compare(c.DayDate, Start) >= 0) && (String.Compare(c.DayDate, End) <= 0))).ToList();
        }
        public List<DaysClass> SearchWeek(int Year, String Month, String Week, String Admin)
        {
            return DB.days.Where(c => c.Year == Year && c.Month==Month && c.Week==Week && c.Admin==Admin ).ToList();
        }
        public List<DaysClass> SearchMonth(int Year, String Month, String Admin)
        {
            return DB.days.Where(c => c.Year == Year && c.Month==Month && c.Admin==Admin).ToList();
        }
        public List<DaysClass> SearchYear(int Year, String Admin)
        {
            return DB.days.Where(c => c.Year == Year && c.Admin==Admin ).ToList();
        }

        //  Search Week
        public List<WeekClass> SearchWWeek(int Year, String Month, String Week, String Admin)
        {
            return DB.weeks.Where(c => c.Year == Year && c.Month == Month && c.Week == Week && c.Admin == Admin).ToList();
        }
        public List<WeekClass> SearchWMonth(int Year, String Month, String Admin)
        {
            return DB.weeks.Where(c => c.Year == Year && c.Month == Month && c.Admin == Admin).ToList();
        }
        public List<WeekClass> SearchWYear(int Year, String Admin)
        {
            return DB.weeks.Where(c => c.Year == Year && c.Admin == Admin).ToList();
        }
        //  Search Month
        public List<MonthsClass> SearchMMonth(int Year, String Month, String Admin)
        {
            return DB.months.Where(c => c.Year == Year && c.Month == Month && c.Admin == Admin).ToList();
        }
        public List<MonthsClass> SearchMYear(int Year, String Admin)
        {
            return DB.months.Where(c => c.Year == Year && c.Admin == Admin).ToList();
        }
        //  Search Month
        public List<YearsClass> SearchYYear(int Year, String Admin)
        {
            return DB.years.Where(c => c.Year == Year && c.Admin == Admin).ToList();
        }
        //  CheckBank
        public void CreateCheckBank(CheckBank check)
        {
            DB.checkBanks.Add(check);
            DB.SaveChanges();
        }
        public void EditCheckBank(CheckBank Ncheck,int ID)
        {
            CheckBank check = DB.checkBanks.Where(c => c.id == ID).FirstOrDefault();
            check.Admin = Ncheck.Admin;
            check.Agent = Ncheck.Agent;
            check.BankName = Ncheck.BankName;
            check.CheckNumber = Ncheck.CheckNumber;
            check.Price = Ncheck.Price;
            check.DayDate = Ncheck.DayDate;
            check.PassDate = Ncheck.PassDate;
            check.Details = Ncheck.Details;
            DB.SaveChanges();
        }
        public void DeleteCheckBank(int ID)
        {
            CheckBank check = DB.checkBanks.Where(c => c.id == ID).FirstOrDefault();
            DB.checkBanks.Remove(check);
            DB.SaveChanges();
        }

        public List<String> GetBankNames()
        {
            return (from i in DB.checkBanks select i.BankName).Distinct().ToList();
        }
        public List<String> GetAgentsName(String Admin)
        {
            List<String> Names = new List<string>();
            foreach (var item in DB.checkBanks)
            {
                if (item.Admin==Admin)
                {
                    Names.Add(item.Agent);
                }
            }
            foreach (var item in DB.moneyBuys)
            {
                if (item.Admin==Admin)
                {
                    Names.Add(item.Agent);
                }
            }
            return Names.Distinct().ToList();
        }
        public List<CheckBank> GetAllTodayChecks(String Admin,String Date)
        {
            return (DB.checkBanks.Where(c => c.Admin == Admin && c.PassDate==Date)).ToList();
        }
        public List<CheckBank> GetAllTodayChecksPassed(String Admin, String Date)
        {
            return (DB.checkBanks.Where(c => c.Admin == Admin && c.PassDate == Date && c.Status)).ToList();
        }
        public List<CheckBank> GetAllTodayChecksNotPassed(String Admin, String Date)
        {
            return (DB.checkBanks.Where(c => c.Admin == Admin && c.PassDate == Date && !c.Status)).ToList();
        }
        public void ChangeStatus(int ID)
        {
            CheckBank check = DB.checkBanks.Where(c => c.id == ID).FirstOrDefault();
            check.Status = (check.Status) ? false : true;
            DB.SaveChanges();
        }
        public List<CheckBank> GetAllChecksPassed(String Admin, String Start, String End)
        {
            return (DB.checkBanks.Where(c => c.Admin == Admin && c.Status)).ToList();
        }
        public List<CheckBank> GetAllChecksNotPassed(String Admin, String Start, String End)
        {
            return (DB.checkBanks.Where(c => c.Admin == Admin && !c.Status)).ToList();
        }
        public List<CheckBank> ShowSearchResultCheckBank(String Admin, String Word, String Start, String End)
        {
            //String.Compare(c.PassDate, Word) <= 0
            return (DB.checkBanks.Where(c => c.Admin == Admin &&((c.CheckNumber).Contains(Word) || (c.Agent).Contains(Word) || (c.PassDate).Contains(Word))).OrderByDescending(c => c.PassDate).ToList());
        }
        public List<CheckBank> ShowSearchResultNotPass(String Admin, String Word, String Start, String End)
        {
            DateTime onmonth = Convert.ToDateTime(Word);
            onmonth = onmonth.AddMonths(-1);
            String older = onmonth.ToString("yyyy/MM/dd");
            return (DB.checkBanks.Where(c => c.Admin == Admin && !c.Status && ((String.Compare(c.PassDate, Word) <= 0) && (String.Compare(Word, older) >= 0))).OrderByDescending(c => c.PassDate).ToList());
        }
        public void PassCheck(int ID)
        {
            CheckBank check = DB.checkBanks.Where(c => c.id == ID).FirstOrDefault();
            check.Status = true;
            DB.SaveChanges();
        }
        public YearsClass GetYear(String Admin, int Year)
        {
            return (DB.years.Where(c => c.Admin == Admin && c.Year == Year)).FirstOrDefault();
        }
        public MonthsClass GetMonth(String Admin, int Year,String Month)
        {
            return (DB.months.Where(c => c.Admin == Admin && c.Year == Year && c.Month == Month)).FirstOrDefault();
        }
        public WeekClass GetWeek(String Admin, int Year,String Month,String Week)
        {
            return (DB.weeks.Where(c => c.Admin == Admin && c.Year == Year && c.Month == Month && c.Week == Week)).FirstOrDefault();
        }
        public DaysClass GetDay(String Admin, int Year, String Month, String Week,String Day)
        {
            return (DB.days.Where(c => c.Admin == Admin && c.Year == Year && c.Month == Month && c.Week == Week && c.Day==Day)).FirstOrDefault();
        }
    
        //  Auto Registeration
        //  Auto Week
        public void CreateAutoWeek(WeekClass Week)
        {
            DB.weeks.Add(Week);
            DB.SaveChanges();
        }
        public int ExistWeek(WeekClass Week)
        {
            foreach (var item in DB.weeks)
            {
                if (item.Admin==Week.Admin && item.Year==Week.Year && item.Month==Week.Month && item.Week==Week.Week)
                {
                    return item.ID;
                }
            }
            return 0;
        }
        public void EditAutoWeek(WeekClass Week,int ID)
        {
            WeekClass week = DB.weeks.Where(c => c.ID == ID).FirstOrDefault();
            week.DayDate = Week.DayDate;
            week.Year = Week.Year;
            week.Month = Week.Month;
            week.Week = Week.Week;
            week.Day = Week.Day;
            week.Admin = Week.Admin;
            week.Banki += Week.Banki;
            week.Money += Week.Money;
            week.Total += Week.Total;
            DB.SaveChanges();
        }

        //  Auto Month
        public void CreateAutoMonth(MonthsClass Month)
        {
            DB.months.Add(Month);
            DB.SaveChanges();
        }
        public int ExistMonth(MonthsClass Month)
        {
            foreach (var item in DB.months)
            {
                if (item.Admin == Month.Admin && item.Year == Month.Year && item.Month == Month.Month)
                {
                    return item.ID;
                }
            }
            return 0;
        }
        public void EditAutoMonth(MonthsClass Month, int ID)
        {
            MonthsClass month = DB.months.Where(c => c.ID == ID).FirstOrDefault();
            month.DayDate = Month.DayDate;
            month.Year = Month.Year;
            month.Month = Month.Month;
            month.Week = Month.Week;
            month.Day = Month.Day;
            month.Admin = Month.Admin;
            month.Banki += Month.Banki;
            month.Money += Month.Money;
            month.Total += Month.Total;
            DB.SaveChanges();
        }

        //  Auto Month
        public void CreateAutoYear(YearsClass Year)
        {
            DB.years.Add(Year);
            DB.SaveChanges();
        }
        public int ExistYear(YearsClass Year)
        {
            foreach (var item in DB.years)
            {
                if (item.Admin == Year.Admin && item.Year == Year.Year)
                {
                    return item.ID;
                }
            }
            return 0;
        }
        public void EditAutoYear(YearsClass Year, int ID)
        {
            YearsClass year = DB.years.Where(c => c.ID == ID).FirstOrDefault();
            year.DayDate = Year.DayDate;
            year.Year = Year.Year;
            year.Month = Year.Month;
            year.Week = Year.Week;
            year.Day = Year.Day;
            year.Admin = Year.Admin;
            year.Banki += Year.Banki;
            year.Money += Year.Money;
            year.Total += Year.Total;
            DB.SaveChanges();
        }

        //  Money Buy
        public List<MoneyBuy> GetAllMoneyBuys(String Admin,String Start,String End)
        {
            return (DB.moneyBuys.Where(c => c.Admin == Admin && ((String.Compare(c.Date, Start) >= 0) && (String.Compare(c.Date, End) <= 0)) && c.Status)).ToList();
        }
        public List<MoneyBuy> SearchResultInDGV(String Admin,String Word)
        {
            return (from i in DB.moneyBuys where i.Admin == Admin && i.Agent.Contains(Word) || i.Name.Contains(Word) || i.Code.ToString()==Word || i.Date==Word select i).ToList();
        }

        //  Crud MoneyBuy
        public void CreateMoneyBuy(MoneyBuy Money)
        {
            DB.moneyBuys.Add(Money);
            DB.SaveChanges();
        }
        public int ExistMoneyBuy(MoneyBuy Money)
        {
            foreach (var item in DB.moneyBuys)
            {
                if (item.Name == Money.Name && item.Date == Money.Date)
                {
                    if (item.Admin==Money.Admin && item.Agent==Money.Agent)
                    {
                        return item.ID;
                    }
                }
            }
            return 0;
        }
        public void EditMoneyBuy(MoneyBuy Money, int ID)
        {
            MoneyBuy money = DB.moneyBuys.Where(c => c.ID == ID).FirstOrDefault();
            money.Admin = Money.Admin;
            money.Agent = Money.Agent;
            money.Date = Money.Date;
            money.Price = Money.Price;
            money.Details = Money.Details;
            money.Name = Money.Name;
            money.Code = Money.Code;
            DB.SaveChanges();
        }
        public void DeleteMoneyBuy(int ID)
        {
            MoneyBuy money = DB.moneyBuys.Where(c => c.ID == ID).FirstOrDefault();
            DB.moneyBuys.Remove(money);
            DB.SaveChanges();
        }
        public void ChangeStatusMoneyBuy(int ID)
        {
            MoneyBuy money = DB.moneyBuys.Where(c => c.ID == ID).FirstOrDefault();
            money.Status = (money.Status) ? false : true;
            DB.SaveChanges();
        }
        public int GetLastCode()
        {
            try
            {
                return ((from i in DB.moneyBuys select i.Code).Max() + 1);
            }
            catch
            {
                return 1001;
            }
        }
        //((String.Compare(c.Date, Start) >= 0) && (String.Compare(c.Date, End) <= 0))
    }
}
