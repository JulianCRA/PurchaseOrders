using System;
using System.Collections.Generic;
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
            _form.popCurrencies(new List<String> { "USD", "VND", "EUR" });
        }
    }
}
