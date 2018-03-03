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
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(SupplierForm))
                {
                    form.WindowState = FormWindowState.Normal;
                    form.Activate();
                    return;
                }
            }

            SupplierGateway repository = new SupplierGateway();
            SupplierForm view = new SupplierForm();

            SupplierPresenter presenter = new SupplierPresenter(view, repository);
            view.MdiParent = this;
            view.Show();
        }

        private void itemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(ItemForm))
                {
                    form.WindowState = FormWindowState.Normal;
                    form.Activate();
                    return;
                }
            }

            ItemGateway repository = new ItemGateway();
            ItemForm view = new ItemForm();

            var presenter = new ItemPresenter(view, repository);
            view.MdiParent = this;
            view.Show();
        }

        private void purchaseOrdersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(OrderForm))
                {
                    form.WindowState = FormWindowState.Normal;
                    form.Activate();
                    return;
                }
            }

            OrderGateway repository = new OrderGateway();
            OrderForm view = new OrderForm();

            var presenter = new OrderPresenter(view, repository);

            view.MdiParent = this;
            view.Show();
        }
    }
}
