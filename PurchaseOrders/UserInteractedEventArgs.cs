using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseOrders
{
    public class UserInteractedEventArgs : EventArgs
    {
        public String action;

        public Int32 currentlySelected;
    }
}
