using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseOrders
{
    public class OrderPresenter : Presenter
    {
        private new OrderForm _form
        {
            get { return (OrderForm)base._form; }
            set { base._form = value; }
        }

        private new OrderGateway _list
        {
            get { return (OrderGateway)base._list; }
            set { base._list = value; }
        }

        public OrderPresenter(OrderForm form, OrderGateway list) : base(form, list)
        {
            customizeView();
        }

        override public void SynchronizeView()
        {
            /*List<Item> l = _list.SearchByName(_form.Token) as List<Item>;

            DataTable dt = new DataTable();

            dt.Columns.Add(new DataColumn("id"));
            dt.Columns.Add(new DataColumn("name"));
            dt.Columns.Add(new DataColumn("supplier"));

            foreach (Item i in l)
            {
                dt.Rows.Add(i.ID, i.Name, i.Supplier);
            }

            _form.Populate(dt);
            _form.EnterCreationMode(_list.GetNextID());*/
        }

        public void customizeView()
        {
            popSuppliers();
        }

        private void popSuppliers()
        {
            _form.popSuppliers(_list.GetSuppliers());
        }
    }
}
