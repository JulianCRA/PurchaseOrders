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
        public List<Supplier> lalista;

        public Dashboard()
        {
            InitializeComponent();
        }

        private void suppliersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SupplierGateway repository = new SupplierGateway();
            SupplierForm view = new SupplierForm();

            SupplierPresenter presenter = new SupplierPresenter(view, repository);
            view.MdiParent = this;
            view.Show();
        }

        private void itemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ItemGateway repository = new ItemGateway();
            ItemForm view = new ItemForm();

            var presenter = new Item.ItemPresenter(view, repository);
            //presenter.customizeView();
            view.MdiParent = this;
            view.Show();*/
        }
    }
}
