using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PurchaseOrders
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void suppliersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*var repository = new Supplier.SuppliersList();
            var view = new Supplier.SupplierForm();

            var presenter = new Supplier.SupplierPresenter(view, repository);
            view.MdiParent = this;
            view.Show();*/
        }

        private void itemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*var repository = new Item.ItemList();
            var view = new Item.ItemForm();

            var presenter = new Item.ItemPresenter(view, repository);
            //presenter.customizeView();
            view.MdiParent = this;
            view.Show();*/
        }

        
    }
}
