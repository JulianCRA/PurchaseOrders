namespace PurchaseOrders
{
    partial class OrderForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.groupBoxOptions = new System.Windows.Forms.GroupBox();
            this.radioButtonEdit = new System.Windows.Forms.RadioButton();
            this.radioButtonNew = new System.Windows.Forms.RadioButton();
            this.buttonSave = new System.Windows.Forms.Button();
            this.comboBoxSupplier = new System.Windows.Forms.ComboBox();
            this.labelSupplier = new System.Windows.Forms.Label();
            this.textBoxDebug = new System.Windows.Forms.TextBox();
            this.dateTimePickerExpected = new System.Windows.Forms.DateTimePicker();
            this.groupBoxOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSearch.Location = new System.Drawing.Point(12, 22);
            this.textBoxSearch.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(355, 32);
            this.textBoxSearch.TabIndex = 1;
            // 
            // buttonClear
            // 
            this.buttonClear.FlatAppearance.BorderSize = 0;
            this.buttonClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonClear.Location = new System.Drawing.Point(382, 21);
            this.buttonClear.Margin = new System.Windows.Forms.Padding(0);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(53, 34);
            this.buttonClear.TabIndex = 3;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = true;
            // 
            // buttonDelete
            // 
            this.buttonDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDelete.Location = new System.Drawing.Point(608, 519);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(140, 36);
            this.buttonDelete.TabIndex = 10;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            // 
            // groupBoxOptions
            // 
            this.groupBoxOptions.Controls.Add(this.radioButtonEdit);
            this.groupBoxOptions.Controls.Add(this.radioButtonNew);
            this.groupBoxOptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxOptions.Location = new System.Drawing.Point(455, 15);
            this.groupBoxOptions.Name = "groupBoxOptions";
            this.groupBoxOptions.Padding = new System.Windows.Forms.Padding(0);
            this.groupBoxOptions.Size = new System.Drawing.Size(293, 52);
            this.groupBoxOptions.TabIndex = 4;
            this.groupBoxOptions.TabStop = false;
            this.groupBoxOptions.Text = "Purchase order";
            // 
            // radioButtonEdit
            // 
            this.radioButtonEdit.AutoSize = true;
            this.radioButtonEdit.Location = new System.Drawing.Point(188, 21);
            this.radioButtonEdit.Name = "radioButtonEdit";
            this.radioButtonEdit.Size = new System.Drawing.Size(50, 21);
            this.radioButtonEdit.TabIndex = 1;
            this.radioButtonEdit.Text = "Edit";
            this.radioButtonEdit.UseVisualStyleBackColor = true;
            // 
            // radioButtonNew
            // 
            this.radioButtonNew.AutoSize = true;
            this.radioButtonNew.Checked = true;
            this.radioButtonNew.Location = new System.Drawing.Point(55, 21);
            this.radioButtonNew.Name = "radioButtonNew";
            this.radioButtonNew.Size = new System.Drawing.Size(80, 21);
            this.radioButtonNew.TabIndex = 0;
            this.radioButtonNew.TabStop = true;
            this.radioButtonNew.Text = "Add new";
            this.radioButtonNew.UseVisualStyleBackColor = true;
            // 
            // buttonSave
            // 
            this.buttonSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSave.Location = new System.Drawing.Point(455, 519);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(140, 36);
            this.buttonSave.TabIndex = 9;
            this.buttonSave.Text = "Add";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // comboBoxSupplier
            // 
            this.comboBoxSupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSupplier.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxSupplier.FormattingEnabled = true;
            this.comboBoxSupplier.Location = new System.Drawing.Point(455, 198);
            this.comboBoxSupplier.Name = "comboBoxSupplier";
            this.comboBoxSupplier.Size = new System.Drawing.Size(293, 33);
            this.comboBoxSupplier.TabIndex = 20;
            // 
            // labelSupplier
            // 
            this.labelSupplier.AutoSize = true;
            this.labelSupplier.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSupplier.Location = new System.Drawing.Point(452, 175);
            this.labelSupplier.Name = "labelSupplier";
            this.labelSupplier.Size = new System.Drawing.Size(80, 20);
            this.labelSupplier.TabIndex = 21;
            this.labelSupplier.Text = "Supplier:";
            // 
            // textBoxDebug
            // 
            this.textBoxDebug.Location = new System.Drawing.Point(13, 402);
            this.textBoxDebug.Multiline = true;
            this.textBoxDebug.Name = "textBoxDebug";
            this.textBoxDebug.Size = new System.Drawing.Size(422, 159);
            this.textBoxDebug.TabIndex = 22;
            // 
            // dateTimePickerExpected
            // 
            this.dateTimePickerExpected.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerExpected.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerExpected.Location = new System.Drawing.Point(455, 263);
            this.dateTimePickerExpected.Margin = new System.Windows.Forms.Padding(0);
            this.dateTimePickerExpected.Name = "dateTimePickerExpected";
            this.dateTimePickerExpected.Size = new System.Drawing.Size(293, 30);
            this.dateTimePickerExpected.TabIndex = 23;
            // 
            // OrderForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(773, 573);
            this.Controls.Add(this.dateTimePickerExpected);
            this.Controls.Add(this.textBoxDebug);
            this.Controls.Add(this.labelSupplier);
            this.Controls.Add(this.comboBoxSupplier);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.groupBoxOptions);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.textBoxSearch);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(789, 612);
            this.MinimumSize = new System.Drawing.Size(789, 612);
            this.Name = "OrderForm";
            this.Text = "Purchase Orders";
            this.groupBoxOptions.ResumeLayout(false);
            this.groupBoxOptions.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.GroupBox groupBoxOptions;
        private System.Windows.Forms.RadioButton radioButtonEdit;
        private System.Windows.Forms.RadioButton radioButtonNew;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.ComboBox comboBoxSupplier;
        private System.Windows.Forms.Label labelSupplier;
        private System.Windows.Forms.TextBox textBoxDebug;
        private System.Windows.Forms.DateTimePicker dateTimePickerExpected;
    }
}