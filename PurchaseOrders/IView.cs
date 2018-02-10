using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseOrders
{
    public interface IView
    {
        event EventHandler<UserInteractedEventArgs> userInteracted;

        String Token { set; get; }

        String SelectedIndex { get; }

        void Populate(DataTable dt);

        IDatabaseEntity GetFormInfo();

        void DeleteSelected();

        void db(Object s);

        void EnterCreationMode(String newid = "");

        void EnterEditionMode(IDatabaseEntity obj);

        void DisplayMsg(Int32 type, String msg);
    }
}
