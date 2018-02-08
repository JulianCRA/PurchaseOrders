using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PurchaseOrders
{
    class Supplier : IDatabaseEntity
    {
        public String id { get; set; }

        public String name { get; set; }

        public String email { get; set; }

        public Supplier(String i, String n, string e)
        {
            this.id = i;
            this.name = n;
            this.email = e;
        }

        public Boolean IsValid()
        {
            if (String.IsNullOrWhiteSpace(this.id)) return false;
            if (String.IsNullOrWhiteSpace(this.name)) return false;
            if (String.IsNullOrWhiteSpace(this.email)) return false;

            Regex rgx = new Regex(@"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");
            if (!rgx.IsMatch(this.email)) return false;

            rgx = new Regex(@"^[\d]{0,6}[\d]$");
            if (!rgx.IsMatch(this.id)) return false;

            rgx = new Regex(@"^(?=\S)( |.){0,29}\S$");
            if (!rgx.IsMatch(this.name)) return false;

            return true;
        }
    }
}
