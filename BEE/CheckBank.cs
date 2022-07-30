using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEE
{
    public class CheckBank
    {
        public int id { get; set; }
        public String Admin { get; set; }
        public String Agent { get; set; }
        public String BankName { get; set; }
        public String CheckNumber { get; set; }
        public double Price { get; set; }
        public String DayDate { get; set; } 
        public String PassDate { get; set; }        
        public String Details { get; set; }
        public bool DeleteStatus { get; set; }
        public bool Status { get; set; } = false;       //ایا چک پاس شده یا خیر    پاس شده درست نشده نادرست
    }
}
