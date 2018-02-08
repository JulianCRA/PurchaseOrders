using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseOrders
{
    public interface IPresenter
    {
        void Form_OnUserInteracted(object source, UserInteractedEventArgs e);

        void Insert();

        void Update();

        void Delete();

        void SynchronizeView();

        void GetByID();
    }
}
