﻿namespace UserControls
{
    partial class DGVPrices
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgv = new System.Windows.Forms.DataGridView();
            this.ColumnPriceID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCurrency = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColumnUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.debug = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv
            // 
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnPriceID,
            this.ColumnPrice,
            this.ColumnCurrency,
            this.ColumnUnit});
            this.dgv.Location = new System.Drawing.Point(3, 3);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgv.Size = new System.Drawing.Size(282, 114);
            this.dgv.TabIndex = 0;
            // 
            // ColumnPriceID
            // 
            this.ColumnPriceID.DataPropertyName = "priceid";
            this.ColumnPriceID.HeaderText = "ID";
            this.ColumnPriceID.MaxInputLength = 10;
            this.ColumnPriceID.Name = "ColumnPriceID";
            this.ColumnPriceID.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColumnPriceID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnPriceID.Visible = false;
            // 
            // ColumnPrice
            // 
            this.ColumnPrice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnPrice.DataPropertyName = "ppu";
            this.ColumnPrice.FillWeight = 40F;
            this.ColumnPrice.HeaderText = "Price per unit";
            this.ColumnPrice.MaxInputLength = 22;
            this.ColumnPrice.Name = "ColumnPrice";
            this.ColumnPrice.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColumnPrice.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColumnCurrency
            // 
            this.ColumnCurrency.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnCurrency.DataPropertyName = "currency";
            this.ColumnCurrency.FillWeight = 25F;
            this.ColumnCurrency.HeaderText = "Currency";
            this.ColumnCurrency.Name = "ColumnCurrency";
            this.ColumnCurrency.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // ColumnUnit
            // 
            this.ColumnUnit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnUnit.DataPropertyName = "unit";
            this.ColumnUnit.FillWeight = 35F;
            this.ColumnUnit.HeaderText = "Unit";
            this.ColumnUnit.MaxInputLength = 10;
            this.ColumnUnit.Name = "ColumnUnit";
            this.ColumnUnit.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColumnUnit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // debug
            // 
            this.debug.Location = new System.Drawing.Point(4, 123);
            this.debug.Multiline = true;
            this.debug.Name = "debug";
            this.debug.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.debug.Size = new System.Drawing.Size(281, 89);
            this.debug.TabIndex = 1;
            // 
            // DGVPrices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.debug);
            this.Controls.Add(this.dgv);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.MinimumSize = new System.Drawing.Size(293, 112);
            this.Name = "DGVPrices";
            this.Size = new System.Drawing.Size(294, 215);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.TextBox debug;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPriceID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrice;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColumnCurrency;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnUnit;
    }
}
