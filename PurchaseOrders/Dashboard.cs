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
            var repository = new SupplierGateway();
            ConvertListToDataTable(repository.SearchByName("") as List<Supplier>);
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
            /*var repository = new Item.ItemList();
            var view = new Item.ItemForm();

            var presenter = new Item.ItemPresenter(view, repository);
            //presenter.customizeView();
            view.MdiParent = this;
            view.Show();*/
        }

        public DataTable ConvertListToDataTable(List<Supplier> list)
        {
            int index = dgv.Columns.Add("id", "ID");
            dgv.Columns[index].DataPropertyName = "c3";
            dgv.Columns[index].Visible = false;
            DataTable dt = new DataTable();
            
            dt.Columns.Add(new DataColumn("c1"));
            dt.Columns.Add(new DataColumn("c2"));
            dt.Columns.Add(new DataColumn("c3"));
            dgv.AutoGenerateColumns = false;
            
            foreach (Supplier s in list)
            {
                dt.Rows.Add(s.id, s.name, s.email);
            }

            dgv.DataSource = dt;
            dgv.CellClick += ss;

            return dt;
        }

        public void ss(object source, DataGridViewCellEventArgs e)
        {
            db.Text += dgv.Rows[e.RowIndex].Cells["id"].Value.ToString() + " - ";
        }
    }
}
