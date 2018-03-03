using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseOrders
{
    class PurchaseOrder : IDatabaseEntity
    {
        public String ID { get; set; }

        public String Supplier { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime ExpectedDate { get; set; }

        public String Total { get; set; }

        public List<OrderDetail> Details { get; set; }

        public PurchaseOrder(String i, String s, DateTime c, DateTime e, String t, List<OrderDetail> d)
        {
            this.ID = i;
            this.Supplier = s;
            this.CreationDate = c;
            this.ExpectedDate = e;
            this.Details = d;

            this.calculateTotal();
        }

        public PurchaseOrder(String i, String s, DateTime e)
        {
            this.ID = i;
            this.Supplier = s;
            this.ExpectedDate = e;
        }

        private void calculateTotal()
        {
            foreach(OrderDetail p in this.Details)
            {
                this.Total += p.Price;
            }
        }

        public bool IsValid()
        {
            return true;
        }
    }
}
