using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseOrders
{
    public class Price : IDatabaseEntity
    {
        public String ID { get; set; }

        public String Item { get; set; }

        public String PricePerUnit { get; set; }

        public String Currency { get; set; }

        public String Unit { get; set; }

        public Boolean ffd { get; set; }

        public Price(String id, String i, String p, String c, String u, Boolean d = false)
        {
            this.ID = id;
            this.Item = i;
            this.PricePerUnit = p;
            this.Currency = c;
            this.Unit = u;
            this.ffd = d;
        }

        public bool IsValid()
        {
            if (String.IsNullOrWhiteSpace(this.ID)) return false;
            if (String.IsNullOrWhiteSpace(this.Item)) return false;
            if (String.IsNullOrWhiteSpace(this.PricePerUnit)) return false;
            if (String.IsNullOrWhiteSpace(this.Currency)) return false;
            if (String.IsNullOrWhiteSpace(this.Unit)) return false;

            // Implement REGEX validation

            return true;
        }

        public override string ToString()
        {
            return "[Price ID: " + this.ID +
                   " - Price Item: " + this.Item +
                   " - Price PPU: " + this.PricePerUnit +
                   " - Price Curr: " + this.Currency +
                   " - Price Unit: " + this.Unit + "]";
        }
    }
}
