using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseOrders
{
    public class SupplierPresenter : Presenter
    {
        public SupplierPresenter(IView form, IGateway list) : base(form, list) { }

        override public void SynchronizeView()
        {
            List<Supplier> l = _list.SearchByName(_form.Token) as List<Supplier>;

            DataTable dt = new DataTable();

            dt.Columns.Add(new DataColumn("id"));
            dt.Columns.Add(new DataColumn("name"));
            dt.Columns.Add(new DataColumn("email"));

            foreach (Supplier s in l)
            {
                dt.Rows.Add(s.id, s.name, s.email);
            }

            _form.Populate(dt);
            _form.EnterCreationMode(_list.GetNextID());
        }
    }
}
