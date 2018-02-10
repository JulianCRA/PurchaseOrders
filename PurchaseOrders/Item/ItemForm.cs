using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PurchaseOrders
{
    public partial class ItemForm : Form, IView
    {
        public ItemForm()
        {
            InitializeComponent();
        }

        private void ItemForm_Load(object sender, EventArgs e)
        {
            OnSearch();
            this.dgv.SelectionChanged += new EventHandler(this.dgv_SelectionChanged);
            this.textBoxSearch.TextChanged += new EventHandler(this.textBoxSearch_TextChanged);
            this.buttonClear.Click += new EventHandler(this.buttonClear_Click);
        }

        public String Token
        {
            get { return this.textBoxSearch.Text; }
            set { this.textBoxSearch.Text = value; }
        }

        public string SelectedIndex
        {
            get
            {
                if (dgv.SelectedRows.Count > 0)
                    return this.dgv.CurrentRow.Cells["ColumnID"].Value.ToString();
                return String.Empty;
            }
        }

        #region Event Dispatching

        private Boolean ignoreSelectedRowChanged = true;

        public event EventHandler<UserInteractedEventArgs> userInteracted;

        protected virtual void OnDelete()
        {
            userInteracted?.Invoke(this, new UserInteractedEventArgs() { action = "del", currentlySelected = Int32.Parse(this.SelectedIndex) });
        }

        protected virtual void OnSelect()
        {
            userInteracted?.Invoke(this, new UserInteractedEventArgs() { action = "sel", currentlySelected = Int32.Parse(this.SelectedIndex) });
        }

        protected virtual void OnEdit()
        {
            userInteracted?.Invoke(this, new UserInteractedEventArgs() { action = "edt", currentlySelected = Int32.Parse(this.SelectedIndex) });
        }

        protected virtual void OnAdd()
        {
            userInteracted?.Invoke(this, new UserInteractedEventArgs() { action = "add", currentlySelected = 0 });
        }

        protected virtual void OnSearch()
        {
            userInteracted?.Invoke(this, new UserInteractedEventArgs() { action = "syn", currentlySelected = 0 });
        }

        protected virtual void OnReset()
        {
            userInteracted?.Invoke(this, new UserInteractedEventArgs() { action = "clr", currentlySelected = 0 });
        }

        #endregion Event Dispatching

        public void popSuppliers(DataTable data)
        {
            this.comboBoxSupplier.DataSource = data;
            this.comboBoxSupplier.ValueMember = "ID";
            this.comboBoxSupplier.DisplayMember = "Name";
        }

        public void popCurrencies(List<String> l)
        {
            this.dgvPrices.populateCurrencies(l);
        }

        public void Populate(DataTable dt)
        {
            ignoreSelectedRowChanged = true;
            this.dgv.DataSource = dt;
            this.dgv.ClearSelection();
            ignoreSelectedRowChanged = false;
        }

        #region Form Behaviour

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            OnSearch();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            this.textBoxSearch.Text = String.Empty;
        }

        private void dgv_SelectionChanged(object source, EventArgs e)
        {
            if (ignoreSelectedRowChanged) return;

            if (dgv.Focused)
            {
                if (this.SelectedIndex != String.Empty)
                {
                    OnSelect();
                }
                else
                {
                    OnReset();
                }
                return;
            }
            this.ignoreSelectedRowChanged = true;
            this.dgv.ClearSelection();
            this.ignoreSelectedRowChanged = false;
        }

        private void radioButtonNew_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButtonNew.Checked)
            {
                OnReset();
            }
        }

        private void checkBoxAM_CheckedChanged(object sender, EventArgs e)
        {

            this.formFieldID.assignManually = this.checkBoxAM.Checked;
            if (!this.checkBoxAM.Checked)
            {
                //Supplier s = (Supplier)getForm();
                OnReset();
                //formFieldName.text = s.name;
                //formFieldEmail.text = s.email;
            }

        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            /*if (this.IsValid)
            {
                if (radioButtonNew.Checked)
                {
                    this.OnAdd();
                }
                else
                {
                    this.OnEdit();
                }
            }
            else
            {
                this.DisplayMsg(0, "Please make certain that all the input data is written correctly");
            }*/
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            DeleteSelected();
        }

        #endregion

        public IDatabaseEntity GetFormInfo()
        {
            throw new NotImplementedException();
        }

        public void DeleteSelected()
        {
            throw new NotImplementedException();
        }

        public void db(string s)
        {
            throw new NotImplementedException();
        }

        public void EnterCreationMode(string newid = "")
        {
            this.formFieldID.text = newid;
            this.formFieldName.text = String.Empty;
            this.formFieldDescription.text = String.Empty;
            this.comboBoxSupplier.SelectedIndex = -1;

            DataTable ptable = new DataTable();
            ptable.Columns.Add(new DataColumn("priceid"));
            ptable.Columns.Add(new DataColumn("ppu"));
            ptable.Columns.Add(new DataColumn("currency"));
            ptable.Columns.Add(new DataColumn("unit"));
            this.dgvPrices.populatePrices(ptable);

            this.checkBoxAM.Checked = false;
            this.radioButtonNew.Checked = true;
            this.buttonDelete.Enabled = false;
            this.checkBoxAM.Enabled = true;
            this.buttonSave.Text = "Add new";

            this.radioButtonEdit.Enabled = true;
            if (this.SelectedIndex == String.Empty)
                this.radioButtonEdit.Enabled = false;
        }

        public void EnterEditionMode(IDatabaseEntity obj)
        {
            Item i = (Item)obj;
            this.formFieldID.text = i.ID;
            this.formFieldName.text = i.Name;
            this.formFieldDescription.text = i.Description;
            this.comboBoxSupplier.SelectedValue = comboBoxSupplier.FindStringExact(i.Supplier) + 1;

            DataTable ptable = new DataTable();
            ptable.Columns.Add(new DataColumn("priceid"));
            ptable.Columns.Add(new DataColumn("ppu"));
            ptable.Columns.Add(new DataColumn("currency"));
            ptable.Columns.Add(new DataColumn("unit"));
            foreach (Price p in i.Prices)
            {
                ptable.Rows.Add(p.ID, p.PricePerUnit, p.Currency, p.Unit);
            }
            this.dgvPrices.populatePrices(ptable);

           
            this.radioButtonEdit.Enabled = true;
            this.radioButtonEdit.Checked = true;
            this.buttonDelete.Enabled = true;
            this.checkBoxAM.Checked = false;
            this.checkBoxAM.Enabled = false;
            this.buttonSave.Text = "Save changes";
        }

        public void DisplayMsg(int type, string msg)
        {
            throw new NotImplementedException();
        }

        

        

        

        
    }
}
