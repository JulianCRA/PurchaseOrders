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
    public partial class SupplierForm : Form, IView
    {
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
        #endregion

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

        private Boolean IsValid
        {
            get
            {
                if (!this.formFieldID.isValid) return false;
                if (!this.formFieldName.isValid) return false;
                if (!this.formFieldEmail.isValid) return false;
                return true;
            }
        }

        public SupplierForm()
        {
            InitializeComponent();
        }

        private void SupplierForm_Load(object sender, EventArgs e)
        {
            OnSearch();
            this.dgv.SelectionChanged += new EventHandler(this.dgv_SelectionChanged);
            this.textBoxSearch.TextChanged += new EventHandler(this.textBoxSearch_TextChanged);
            this.buttonClear.Click += new EventHandler(this.buttonClear_Click);
        }

        public void Populate(DataTable table)
        {
            ignoreSelectedRowChanged = true;
            this.dgv.DataSource = table;
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
            if (this.IsValid)
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
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            DeleteSelected();
        }

        #endregion

        public IDatabaseEntity GetFormInfo()
        {
            return new Supplier(formFieldID.text, formFieldName.text, formFieldEmail.text);
        }

        public void DeleteSelected()
        {
            if (this.SelectedIndex != String.Empty)
            {
                DialogResult dr = MessageBox.Show("You are about to delete this record from the system. Do you want to delete it?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                {
                    OnDelete();
                }
            }
        }

        public void db(string s)
        {
            debugBox.Text += s + " :: ";
        }

        public void EnterCreationMode(String nextID = "")
        {
            this.formFieldID.text = nextID;
            this.formFieldName.text = String.Empty;
            this.formFieldEmail.text = String.Empty;

            this.checkBoxAM.Checked = false;
            this.radioButtonNew.Checked = true;
            this.buttonDelete.Enabled = false;
            this.checkBoxAM.Enabled = true;
            this.buttonSave.Text = "Add new";

            this.radioButtonEdit.Enabled = true;
            if (SelectedIndex == String.Empty)
                this.radioButtonEdit.Enabled = false;
        }

        public void EnterEditionMode(IDatabaseEntity obj)
        {
            Supplier s = (Supplier)obj;
            this.formFieldID.text = s.id;
            this.formFieldName.text = s.name;
            this.formFieldEmail.text = s.email;

            this.radioButtonEdit.Enabled = true;
            this.radioButtonEdit.Checked = true;
            this.buttonDelete.Enabled = true;
            this.checkBoxAM.Checked = false;
            this.checkBoxAM.Enabled = false;
            this.buttonSave.Text = "Save changes";
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
