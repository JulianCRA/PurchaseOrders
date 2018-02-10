using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseOrders
{
    public class ItemPresenter : Presenter
    {
        private new ItemForm _form
        {
            get { return (ItemForm)base._form; }
            set { base._form = value; }
        }

        private new ItemGateway _list
        {
            get { return (ItemGateway)base._list; }
            set { base._list = value; }
        }

        public ItemPresenter(ItemForm form, ItemGateway list) : base(form, list)
        {
            customizeView();
        }

        override public void SynchronizeView()
        {
            List<Item> l = _list.SearchByName(_form.Token) as List<Item>;

            DataTable dt = new DataTable();

            dt.Columns.Add(new DataColumn("id"));
            dt.Columns.Add(new DataColumn("name"));
            dt.Columns.Add(new DataColumn("supplier"));

            foreach (Item i in l)
            {
                dt.Rows.Add(i.ID, i.Name, i.Supplier);
            }

            _form.Populate(dt);
            _form.EnterCreationMode(_list.GetNextID());
        }

        public void customizeView()
        {
            popSuppliers();
            popCurrency();
        }

        private void popSuppliers()
        {
            _form.popSuppliers(_list.GetSuppliers());
        }

        private void popCurrency()
        {
            _form.popCurrencies(new List<String> { "USD", "VND", "EUR" }); // Can be replaced with values from a table
        }
    }
}
