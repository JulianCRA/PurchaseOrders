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
    public partial class OrderForm : Form, IView
    {
        public string Token { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public string SelectedIndex => throw new NotImplementedException();

        public OrderForm()
        {
            InitializeComponent();
            this.dateTimePickerExpected.MinDate = DateTime.Now;
            this.dateTimePickerExpected.Value = DateTime.Now;
            this.dateTimePickerExpected.CustomFormat = "dddd, MMM. dd, yyyy";
            this.dateTimePickerExpected.Format = DateTimePickerFormat.Custom;
            db(DateTime.Now.ToString("dddd, MMM. dd, yyyy"));
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

        public void db(Object o)
        {
            this.textBoxDebug.Text += o.ToString() + " :: ";
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            //db(this.dateTimePickerExpected.Value.Date.ToString("yyyy-MM-dd"));if (radioButtonNew.Checked)
            if (radioButtonNew.Checked)
            {
                this.OnAdd();
            }
            else
            {
                this.OnEdit();
            }
        }

        public void Populate(DataTable dt)
        {
            throw new NotImplementedException();
        }

        public IDatabaseEntity GetFormInfo()
        {
            return new PurchaseOrder("0", this.comboBoxSupplier.SelectedValue.ToString(), this.dateTimePickerExpected.Value.Date);
        }

        public void DeleteSelected()
        {
            throw new NotImplementedException();
        }

        public void EnterCreationMode(string newid = "")
        {
            throw new NotImplementedException();
        }

        public void EnterEditionMode(IDatabaseEntity obj)
        {
            throw new NotImplementedException();
        }

        public void DisplayMsg(int type, string msg)
        {
            switch (type)
            {
                case 1:
                    MessageBox.Show(msg, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case 0:
                    MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }
    }
}
