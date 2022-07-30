using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using BEE;
namespace DAL
{
    internal class DBClass : DbContext
    {
        public DBClass() : base("DBC")
        {
        }
        public DbSet<Admin> admins { set; get; }
        public DbSet<DaysClass> days { set; get; }
        public DbSet<WeekClass> weeks { set; get; }
        public DbSet<MonthsClass> months { set; get; }
        public DbSet<YearsClass> years { set; get; }
        public DbSet<CheckBank> checkBanks { set; get; }
        public DbSet<MoneyBuy> moneyBuys { set; get; }
    }
}
