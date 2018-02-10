using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace UserControls
{
    public partial class DGVPrices: UserControl
    {
        private Boolean shouldIgnoreValidation = true;

        private Boolean isBlinking = false;
        
        public DGVPrices()
        {
            InitializeComponent();
            this.dgv.AutoGenerateColumns = false;
            this.dgv.CellBeginEdit += dgv_CellBeginEdit;
            this.dgv.RowValidating += dgv_RowValidating;
            this.dgv.CellClick += dgv_CellClick;
            this.dgv.UserDeletingRow += dgv_UserDeletingRow;
            this.dgv.UserDeletedRow += dgv_UserDeletedRow;

            ColumnCurrency.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
        }

        public void populatePrices(DataTable table)
        {
            this.dgv.DataSource = table;
            this.dgv.ClearSelection();
            this.dgv.CurrentCell = null;
        }

        public DataTable getPricesList()
        {
            return (DataTable)this.dgv.DataSource;
        }

        public void populateCurrencies(List<String> currencies)
        {
            foreach (String s in currencies)
                this.ColumnCurrency.Items.Add(s);
        }

        private void dgv_UserDeletedRow(object source, DataGridViewRowEventArgs e)
        {
            /*dgv.ClearSelection();
            shouldIgnoreValidation = true;*/
        }

        private void dgv_UserDeletingRow(object source, DataGridViewRowCancelEventArgs e)
        {
            e.Cancel = true;
            dgv["ColumnFFD", e.Row.Index].Value = true;
            dgv.CurrentCell = null;
            dgv.Rows[e.Row.Index].Visible = false;
            dgv.ClearSelection();
            shouldIgnoreValidation = true;
        }

        private void dgv_CellClick(object source, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0)
            {
                dgv.EndEdit();
                return;
            }
            if(dgv.Columns[e.ColumnIndex] == ColumnCurrency)
            {
                if(!dgv.IsCurrentCellInEditMode)
                    SendKeys.Send("{F4}");
            }
        }

        private void dgv_CellBeginEdit(object source, DataGridViewCellCancelEventArgs e)
        {
            shouldIgnoreValidation = false;
        }

        private void dgv_RowValidating(object source, DataGridViewCellCancelEventArgs e)
        {
            if (!shouldIgnoreValidation)
            {
                if (!validateRow(e.RowIndex))
                {
                    rowBlink(e.RowIndex, Color.DarkSalmon);
                    e.Cancel = true;
                }
                else
                {
                    this.dgv.ClearSelection();
                    shouldIgnoreValidation = true;
                }
            }
            this.getPricesList();
        }

        private Boolean validateRow(Int32 rowIndex)
        {
            String i = dgv["ColumnPriceID", rowIndex].Value?.ToString() ?? String.Empty;
            String p = dgv["ColumnPrice", rowIndex].Value?.ToString() ?? String.Empty;
            String c = dgv["ColumnCurrency", rowIndex].Value?.ToString() ?? String.Empty;
            String u = dgv["ColumnUnit", rowIndex].Value?.ToString() ?? String.Empty;

            Regex rgx1 = new Regex(@"^[0-9]{1,18}(?:(\.|,)[0-9]{1,2})?$");
            Regex rgx2 = new Regex(@"^[a-zA-Z]{1,10}$");

            if (String.IsNullOrWhiteSpace(p) && String.IsNullOrWhiteSpace(c) && String.IsNullOrWhiteSpace(u)) return false;
            if (!rgx1.IsMatch(p) || !ColumnCurrency.Items.Contains(c) || !rgx2.IsMatch(u)) return false;

            if (String.IsNullOrWhiteSpace(i)) dgv["ColumnPriceID", rowIndex].Value = "0";

            return true;
        }

        private void rowBlink(Int32 index, Color c)
        {
            if (index >= 0 && !isBlinking)
            {
                isBlinking = true;
                Int32 times = 0;
                Timer t = new Timer();
                t.Interval = 70;
                t.Tick += t_Tick;
                t.Start();

                dgv.ClearSelection();
                void t_Tick(object sender, EventArgs e)
                {
                    if (dgv.Rows[index].DefaultCellStyle.BackColor != Color.Empty)
                    {
                        dgv.Rows[index].DefaultCellStyle.SelectionBackColor = Color.Empty;
                        dgv.Rows[index].DefaultCellStyle.BackColor = Color.Empty;

                        if (dgv.IsCurrentCellInEditMode && dgv.CurrentCell.OwningColumn != ColumnCurrency)
                        {
                            DataGridViewTextBoxEditingControl ec = dgv.EditingControl as DataGridViewTextBoxEditingControl;
                            ec.BackColor = Color.Empty;
                            ec.Parent.BackColor = Color.Empty;
                        }

                    }
                    else
                    {
                        dgv.Rows[index].DefaultCellStyle.BackColor = c;
                        dgv.Rows[index].DefaultCellStyle.SelectionBackColor = c;

                        if (dgv.IsCurrentCellInEditMode && dgv.CurrentCell.OwningColumn != ColumnCurrency)
                        {
                            DataGridViewTextBoxEditingControl ec = dgv.EditingControl as DataGridViewTextBoxEditingControl;
                            ec.BackColor = c;
                            ec.Parent.BackColor = c;
                        }
                    }

                    if (times < 7) times++;         // How many times should it blink
                    else
                    {
                        t.Stop();
                        isBlinking = false;
                    }

                }
            }
        }
    }
}
