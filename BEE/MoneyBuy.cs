using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEE
{
    public class MoneyBuy
    {
        public int ID { get; set; }
        public String Name { get; set; }
        public int Code { get; set; }
        public String Admin { get; set; }
        public String Agent { get; set; }
        public String Date { get; set; }
        public Double Price { get; set; }
        public String Details { get; set; }
        public bool Status { get; set; } = true;
    }
}
