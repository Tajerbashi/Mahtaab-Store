using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BEE;

namespace BLL
{
    public class BLLClass
    {
        DALClass dlc = new DALClass();
        public void DisActive(int ID)
        {
            dlc.DisActive(ID);
        }
        public void ChangeStatusAdmin(int ID)
        {
            dlc.ChangeStatusAdmin(ID);
        }
        public void Backup(String Path)
        {
            dlc.Backup(Path);
        }
        public void Restor(String Path)
        {
            dlc.Restor(Path);
        }
        public String GetPass(String User, String Name, String Phone)
        {
            return dlc.GetPass(User, Name, Phone);
        }
        public bool AccessAdmin(String User, String Pass)
        {
            return dlc.AccessAdmin(User, Pass);
        }
        public void CheckUser(Admin admin)
        {
            dlc.CheckUser(admin);
        }
        public bool CreateAdmin(Admin admin)
        {
            if (dlc.ExistAdmin(admin))
            {
                return false;
            }
            else
            {
                dlc.CreateAdmin(admin);
                return true;
            }
        }
        //  Admin
        public List<Admin> GetAllAdmins()
        {
            return (dlc.GetAllAdmins()).ToList();
        }
        public void DeleteAdmin(int ID)
        {
            dlc.DeleteAdmin(ID);
        }
        public bool EditAdmin(Admin admin, int ID)
        {
            return dlc.EditAdmin(admin, ID);
        }
        //  Create CRUD
        public bool CreateDayReport(DaysClass days)
        {
            if (!dlc.ExisDay(days))
            {
                dlc.CreateDayReport(days);
                return true;
            }
            return false;
        }
        public bool CreateWeekReport(WeekClass week)
        {
            if (!dlc.ExisWeek(week))
            {
                dlc.CreateWeekReport(week);
                return true;
            }
            return false;

        }
        public bool CreateMonthReport(MonthsClass month)
        {
            if (!dlc.ExisMonth(month))
            {
                dlc.CreateMonthReport(month);
                return true;
            }
            return false;
        }
        public bool CreateYearReport(YearsClass year)
        {
            if (!dlc.ExisYear(year))
            {
                dlc.CreateYearReport(year);
                return true;
            }
            return false;
        }
        //  Get All
        public List<DaysClass> GetAllDays(String Admin,String Start,String End)
        {
            return (dlc.GetAllDays(Admin,Start,End)).ToList();
        }
        public List<WeekClass> GetAllWeeks(String Admin, String Start, String End)
        {
            return (dlc.GetAllWeeks(Admin,Start,End)).ToList();
        }
        public List<MonthsClass> GetAllMonths(String Admin, String Start, String End)
        {
            return (dlc.GetAllMonths(Admin,Start,End)).ToList();
        }
        public List<YearsClass> GetAllYears(String Admin, String Start, String End)
        {
            return (dlc.GetAllYears(Admin,Start,End).ToList());
        }
        public List<CheckBank> GetAllChecks(String Admin,String Start,String End)
        {
            return (dlc.GetAllChecks(Admin, Start, End)).ToList();
        }

        //  Show Sort Type
        public List<DaysClass> GetAllDaysSortByDate(String Admin, String Start, String End)
        {
            return (dlc.GetAllDaysSortByDate(Admin,Start,End)).ToList();
        }
        public List<WeekClass> GetAllWeeksSortByDate(String Admin, String Start, String End)
        {
            return (dlc.GetAllWeeksSortByDate(Admin, Start, End)).ToList();
        }
        public List<MonthsClass> GetAllMonthsSortByDate(String Admin, String Start, String End)
        {
            return (dlc.GetAllMonthsSortByDate(Admin, Start, End)).ToList();
        }
        public List<YearsClass> GetAllYearsSortByDate(String Admin, String Start, String End)
        {
            return (dlc.GetAllYearsSortByDate(Admin, Start, End)).ToList();
        }
        public List<CheckBank> GetAllChecksSortByDate(String Admin, String Start, String End)
        {
            return (dlc.GetAllChecksSortByDate(Admin, Start, End)).ToList();
        }

        //  Show Sort Type Bank
        public List<DaysClass> GetAllDaysSortByBank(String Admin, String Start, String End)
        {
            return (dlc.GetAllDaysSortByBank(Admin, Start, End)).ToList();
        }
        public List<WeekClass> GetAllWeeksSortByBank(String Admin, String Start, String End)
        {
            return (dlc.GetAllWeeksSortByBank(Admin, Start, End)).ToList();
        }
        public List<MonthsClass> GetAllMonthsSortByBank(String Admin, String Start, String End)
        {
            return (dlc.GetAllMonthsSortByBank(Admin, Start, End)).ToList();

        }
        public List<YearsClass> GetAllYearsSortByBank(String Admin, String Start, String End)
        {
            return (dlc.GetAllYearsSortByBank(Admin, Start, End)).ToList();
        }

        //  Show Sort Type Money
        public List<DaysClass> GetAllDaysSortByMoney(String Admin, String Start, String End)
        {
            return (dlc.GetAllDaysSortByMoney(Admin, Start, End)).ToList();
        }
        public List<WeekClass> GetAllWeeksSortByMoney(String Admin, String Start, String End)
        {
            return (dlc.GetAllWeeksSortByMoney(Admin, Start, End)).ToList();
        }
        public List<MonthsClass> GetAllMonthsSortByMoney(String Admin, String Start, String End)
        {
            return (dlc.GetAllMonthsSortByMoney(Admin, Start, End)).ToList();

        }
        public List<YearsClass> GetAllYearsSortByMoney(String Admin, String Start, String End)
        {
            return (dlc.GetAllYearsSortByMoney(Admin, Start, End)).ToList();
        }

        //  Delete
        public void DeleteDay(int ID)
        {
            dlc.DeleteDay(ID);
        }
        public void DeleteWeek(int ID)
        {
            dlc.DeleteWeek(ID);
        }
        public void DeleteMonth(int ID)
        {
            dlc.DeleteMonth(ID);
        }
        public void DeleteYear(int ID)
        {
            dlc.DeleteYear(ID);
        }

        //  Edit
        public void EditDay(DaysClass NDay, int ID)
        {
            dlc.EditDay(NDay, ID);
        }
        public void EditWeek(WeekClass week, int ID)
        {
            dlc.EditWeek(week, ID);
        }
        public void EditMonth(MonthsClass month, int ID)
        {
            dlc.EditMonth(month, ID);
        }
        public void EditYear(YearsClass year, int ID)
        {
            dlc.EditYear(year, ID);
        }

        //  Search Day
        public List<DaysClass> SearchDay(String Word, String Admin, String Start, String End)
        {
            return (dlc.SearchDay(Word, Admin, Start, End)).ToList();
        }
        public List<DaysClass> SearchWeek(int Year, String Month, String Week, String Admin)
        {
            return (dlc.SearchWeek(Year, Month, Week, Admin)).ToList();
        }
        public List<DaysClass> SearchMonth(int Year, String Month, String Admin)
        {
            return (dlc.SearchMonth(Year, Month, Admin)).ToList();
        }
        public List<DaysClass> SearchYear(int Year, String Admin)
        {
            return (dlc.SearchYear(Year, Admin)).ToList();
        }

        //  Search Week
        public List<WeekClass> SearchWWeek(int Year, String Month, String Week, String Admin)
        {
            return (dlc.SearchWWeek(Year, Month, Week, Admin)).ToList();
        }
        public List<WeekClass> SearchWMonth(int Year, String Month, String Admin)
        {
            return (dlc.SearchWMonth(Year, Month, Admin)).ToList();
        }
        public List<WeekClass> SearchWYear(int Year, String Admin)
        {
            return (dlc.SearchWYear(Year, Admin)).ToList();
        }

        //  Search Month
        public List<MonthsClass> SearchMMonth(int Year, String Month, String Admin )
        {
            return (dlc.SearchMMonth(Year, Month, Admin)).ToList();
        }
        public List<MonthsClass> SearchMYear(int Year, String Admin )
        {
            return (dlc.SearchMYear(Year, Admin)).ToList();
        }

        //  Search Month
        public List<YearsClass> SearchYYear(int Year, String Admin )
        {
            return (dlc.SearchYYear(Year, Admin)).ToList();
        }

        //  CheckBank
        public void CreateCheckBank(CheckBank check)
        {
            dlc.CreateCheckBank(check);
        }
        public void EditCheckBank(CheckBank Ncheck, int ID)
        {
            dlc.EditCheckBank(Ncheck, ID);
        }
        public void DeleteCheckBank(int ID)
        {
            dlc.DeleteCheckBank(ID);
        }

        public List<String> GetBankNames()
        {
            return (dlc.GetBankNames()).ToList();
        }
        public List<String> GetAgentsName(String Admin)
        {
            return (dlc.GetAgentsName(Admin)).ToList();
        }
        public List<CheckBank> GetAllTodayChecks(String Admin, String Date)
        {
            return (dlc.GetAllTodayChecks(Admin, Date)).ToList();
        }
        public List<CheckBank> GetAllTodayChecksPassed(String Admin, String Date)
        {
            return (dlc.GetAllTodayChecksPassed(Admin, Date)).ToList();
        }
        public List<CheckBank> GetAllTodayChecksNotPassed(String Admin, String Date)
        {
            return (dlc.GetAllTodayChecksNotPassed(Admin, Date)).ToList();
        }
        public void ChangeStatus(int ID)
        {
            dlc.ChangeStatus(ID);
        }
        public List<CheckBank> GetAllChecksPassed(String Admin, String Start, String End)
        {
            return dlc.GetAllChecksPassed(Admin, Start, End).ToList();
        }
        public List<CheckBank> GetAllChecksNotPassed(String Admin, String Start, String End)
        {
            return dlc.GetAllChecksNotPassed(Admin,Start, End).ToList();
        }
        public List<CheckBank> ShowSearchResult(String Admin, String Word, String Start, String End)
        {
            return (dlc.ShowSearchResultCheckBank(Admin, Word, Start, End)).ToList();
        }
        public List<CheckBank> ShowSearchResultNotPass(String Admin, String Word, String Start, String End)
        {
            return (dlc.ShowSearchResultNotPass(Admin, Word, Start, End)).ToList();
        }
        public void PassCheck(int ID)
        {
            dlc.PassCheck(ID);
        }
        public YearsClass GetYear(String Admin, int Year)
        {
            return (dlc.GetYear(Admin, Year));
        }
        public MonthsClass GetMonth(String Admin, int Year, String Month)
        {
            return (dlc.GetMonth(Admin, Year, Month));
        }
        public WeekClass GetWeek(String Admin, int Year, String Month, String Week)
        {
            return (dlc.GetWeek(Admin, Year, Month, Week));
        }
        public DaysClass GetDay(String Admin, int Year, String Month, String Week, String Day)
        {
            return (dlc.GetDay(Admin, Year, Month, Week, Day));
        }

        //  Auto Registeration

        public void CreateAutoWeek(WeekClass Week)
        {
            int ID = dlc.ExistWeek(Week);
            if (ID != 0)
            {
                dlc.EditAutoWeek(Week, ID);
            }
            else
            {
                dlc.CreateAutoWeek(Week);
            }
        }
        public void CreateAutoMonth(MonthsClass Month)
        {
            int ID = dlc.ExistMonth(Month);
            if (ID != 0)
            {
                dlc.EditAutoMonth(Month, ID);
            }
            else
            {
                dlc.CreateAutoMonth(Month);
            }
        }
        public void CreateAutoYear(YearsClass Year)
        {
            int ID = dlc.ExistYear(Year);
            if (ID != 0)
            {
                dlc.EditAutoYear(Year, ID);
            }
            else
            {
                dlc.CreateAutoYear(Year);

            }
        }

        //  Money Buy
        public List<MoneyBuy> GetAllMoneyBuys(String Admin, String Start, String End)
        {
            return (dlc.GetAllMoneyBuys(Admin, Start, End)).ToList();
        }
        public List<MoneyBuy> SearchResultInDGV(String Admin, String Word)
        {
            return (dlc.SearchResultInDGV(Admin, Word)).ToList();
        }
        public bool CreateMoneyBuy(MoneyBuy money)
        {
            int ID = dlc.ExistMoneyBuy(money);
            if (ID != 0)
            {
                dlc.EditMoneyBuy(money, ID);
                return false;
            }
            else
            {
                dlc.CreateMoneyBuy(money);
                return true;
            }
        }
        public void DeleteMoneyBuy(int ID)
        {
            dlc.DeleteMoneyBuy(ID);
        }
        public void ChangeStatusMoneyBuy(int ID)
        {
            dlc.ChangeStatusMoneyBuy(ID);
        }
        public int GetLastCode()
        {
            return dlc.GetLastCode();
        }
    }
}
