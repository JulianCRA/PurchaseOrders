using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseOrders
{
    class OrderDetail : IDatabaseEntity
    {
        public Boolean ffd { get; set; }

        public String ID { get; set; }

        public String PurchaseOrder { get; set; }

        public Price Price { get; set; }

        public Int32 Quantity { get; set; }

        public String Total { get; set; }

        public OrderDetail(String i, String po, Int32 q, Price p)
        {
            this.ID = i;
            this.PurchaseOrder = po;
            this.Price = p;
            this.Quantity = q;
            this.Total = (Int32.Parse(this.Price.PricePerUnit) * q).ToString();
        }

        public bool IsValid()
        {
            throw new NotImplementedException();
        }
    }
}
