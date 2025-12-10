using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace accounting_system
{
    public class Data
    {
        public string date { get; set; }
        public string income { get; set; }
        public string type { get; set; }
        public decimal amount { get; set; }
        public string remark { get; set; }

        public Data(string date, string income, string type, decimal amount, string remark = "")
        {
            this.date = date;
            this.income = income;
            this.type = type;
            this.amount = amount;
            this.remark = remark;
        }

        public override bool Equals(object obj)
        {
            if (obj is Data other)
            {
                return date == other.date && income == other.income && type == other.type && amount == other.amount && remark == other.remark;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(date, income, type, amount, remark);
        }
    }
}
