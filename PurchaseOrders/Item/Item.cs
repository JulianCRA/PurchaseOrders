using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PurchaseOrders
{
    public class Item : IDatabaseEntity
    {
        public String ID { get; set; }

        public String Supplier { get; set; }

        public String Name { get; set; }

        public String Description { get; set; }

        public List<Price> Prices { get; set; }
        
        public Item(String i, String s, String n, String d, List<Price> p)
        {
            this.ID = i;
            this.Supplier = s;
            this.Name = n;
            this.Description = d;
            this.Prices = p;
        }

        public Boolean IsValid()
        {
            if (this.Prices == null) return false;
            if (String.IsNullOrWhiteSpace(this.ID)) return false;
            if (String.IsNullOrWhiteSpace(this.Description)) return false;
            if (String.IsNullOrWhiteSpace(this.Supplier)) return false;
            if (String.IsNullOrWhiteSpace(this.Name)) return false;

            Regex rgx = new Regex(@"^[\d]{0,6}[\d]$");
            if (!rgx.IsMatch(this.ID)) return false;

            rgx = new Regex(@"^.{1,50}$");
            if (!rgx.IsMatch(this.Description)) return false;

            rgx = new Regex(@"^(?=\S)( |.){0,29}\S$");
            if (!rgx.IsMatch(this.Supplier)) return false;

            rgx = new Regex(@"^(?=\S)( |.){0,14}\S$");
            if (!rgx.IsMatch(this.Name)) return false;
            
            return true;
        }
    }
}

