using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseOrders
{
    public class Price
    {
        public String ID { get; set; }

        public String PricePerUnit { get; set; }

        public String Currency { get; set; }

        public String Unit { get; set; }

        public Price(String i, String p, String c, String u)
        {
            this.ID = i;
            this.PricePerUnit = p;
            this.Currency = c;
            this.Unit = u;
        }

        public bool validate()
        {
            if (String.IsNullOrWhiteSpace(this.ID)) return false;
            if (String.IsNullOrWhiteSpace(this.PricePerUnit)) return false;
            if (String.IsNullOrWhiteSpace(this.Currency)) return false;
            if (String.IsNullOrWhiteSpace(this.Unit)) return false;

            // Implement REGEX validation

            return true;
        }
    }
}
