namespace PurchaseOrders
{
    partial class SupplierForm
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
            this.dgv = new System.Windows.Forms.DataGridView();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.buttonClear = new System.Windows.Forms.Button();
            this.groupBoxOptions = new System.Windows.Forms.GroupBox();
            this.radioButtonEdit = new System.Windows.Forms.RadioButton();
            this.radioButtonNew = new System.Windows.Forms.RadioButton();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.checkBoxAM = new System.Windows.Forms.CheckBox();
            this.debugBox = new System.Windows.Forms.TextBox();
            this.formFieldEmail = new UserControls.FormField();
            this.formFieldName = new UserControls.FormField();
            this.formFieldID = new UserControls.FormField();
            this.ColumnID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.groupBoxOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToResizeColumns = false;
            this.dgv.AllowUserToResizeRows = false;
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnID,
            this.ColumnName,
            this.ColumnEmail});
            this.dgv.Location = new System.Drawing.Point(12, 70);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgv.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(423, 487);
            this.dgv.TabIndex = 0;
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
            // groupBoxOptions
            // 
            this.groupBoxOptions.Controls.Add(this.radioButtonEdit);
            this.groupBoxOptions.Controls.Add(this.radioButtonNew);
            this.groupBoxOptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxOptions.Location = new System.Drawing.Point(455, 202);
            this.groupBoxOptions.Name = "groupBoxOptions";
            this.groupBoxOptions.Padding = new System.Windows.Forms.Padding(0);
            this.groupBoxOptions.Size = new System.Drawing.Size(293, 52);
            this.groupBoxOptions.TabIndex = 4;
            this.groupBoxOptions.TabStop = false;
            this.groupBoxOptions.Text = "Supplier";
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
            this.radioButtonNew.CheckedChanged += new System.EventHandler(this.radioButtonNew_CheckedChanged);
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
            // buttonDelete
            // 
            this.buttonDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDelete.Location = new System.Drawing.Point(608, 519);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(140, 36);
            this.buttonDelete.TabIndex = 10;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // checkBoxAM
            // 
            this.checkBoxAM.AutoSize = true;
            this.checkBoxAM.Location = new System.Drawing.Point(652, 299);
            this.checkBoxAM.Margin = new System.Windows.Forms.Padding(0);
            this.checkBoxAM.Name = "checkBoxAM";
            this.checkBoxAM.Size = new System.Drawing.Size(101, 17);
            this.checkBoxAM.TabIndex = 14;
            this.checkBoxAM.Text = "Assign manually";
            this.checkBoxAM.UseVisualStyleBackColor = true;
            this.checkBoxAM.CheckedChanged += new System.EventHandler(this.checkBoxAM_CheckedChanged);
            // 
            // debugBox
            // 
            this.debugBox.Location = new System.Drawing.Point(455, 21);
            this.debugBox.Multiline = true;
            this.debugBox.Name = "debugBox";
            this.debugBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.debugBox.Size = new System.Drawing.Size(293, 175);
            this.debugBox.TabIndex = 15;
            // 
            // formFieldEmail
            // 
            this.formFieldEmail.assignManually = true;
            this.formFieldEmail.isValid = false;
            this.formFieldEmail.Location = new System.Drawing.Point(441, 402);
            this.formFieldEmail.Margin = new System.Windows.Forms.Padding(0);
            this.formFieldEmail.MaximumSize = new System.Drawing.Size(320, 72);
            this.formFieldEmail.MinimumSize = new System.Drawing.Size(120, 72);
            this.formFieldEmail.Name = "formFieldEmail";
            this.formFieldEmail.numericOnly = false;
            this.formFieldEmail.regEx = "^[a-zA-Z][\\w\\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\\w\\.-]*[a-zA-Z0-9]\\.[a-zA-Z][a-zA-Z\\.]*[" +
    "a-zA-Z]$";
            this.formFieldEmail.Size = new System.Drawing.Size(320, 72);
            this.formFieldEmail.TabIndex = 13;
            this.formFieldEmail.text = "";
            this.formFieldEmail.textMaxLenght = 50;
            this.formFieldEmail.title = "E-mail:";
            // 
            // formFieldName
            // 
            this.formFieldName.assignManually = true;
            this.formFieldName.isValid = false;
            this.formFieldName.Location = new System.Drawing.Point(441, 336);
            this.formFieldName.Margin = new System.Windows.Forms.Padding(0);
            this.formFieldName.MaximumSize = new System.Drawing.Size(320, 72);
            this.formFieldName.MinimumSize = new System.Drawing.Size(120, 72);
            this.formFieldName.Name = "formFieldName";
            this.formFieldName.numericOnly = false;
            this.formFieldName.regEx = "^(?=\\S)( |.){0,29}\\S$";
            this.formFieldName.Size = new System.Drawing.Size(320, 72);
            this.formFieldName.TabIndex = 12;
            this.formFieldName.text = "";
            this.formFieldName.textMaxLenght = 30;
            this.formFieldName.title = "Name:";
            // 
            // formFieldID
            // 
            this.formFieldID.assignManually = false;
            this.formFieldID.isValid = false;
            this.formFieldID.Location = new System.Drawing.Point(441, 270);
            this.formFieldID.Margin = new System.Windows.Forms.Padding(0);
            this.formFieldID.MaximumSize = new System.Drawing.Size(320, 72);
            this.formFieldID.MinimumSize = new System.Drawing.Size(120, 72);
            this.formFieldID.Name = "formFieldID";
            this.formFieldID.numericOnly = true;
            this.formFieldID.regEx = "^[\\d]{0,6}[\\d]$";
            this.formFieldID.Size = new System.Drawing.Size(218, 72);
            this.formFieldID.TabIndex = 11;
            this.formFieldID.text = "";
            this.formFieldID.textMaxLenght = 7;
            this.formFieldID.title = "ID:";
            // 
            // ColumnID
            // 
            this.ColumnID.DataPropertyName = "id";
            this.ColumnID.HeaderText = "ID";
            this.ColumnID.MaxInputLength = 10;
            this.ColumnID.Name = "ColumnID";
            this.ColumnID.ReadOnly = true;
            this.ColumnID.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColumnID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnID.Visible = false;
            // 
            // ColumnName
            // 
            this.ColumnName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnName.DataPropertyName = "name";
            this.ColumnName.FillWeight = 35F;
            this.ColumnName.HeaderText = "Name";
            this.ColumnName.Name = "ColumnName";
            this.ColumnName.ReadOnly = true;
            this.ColumnName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColumnName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColumnEmail
            // 
            this.ColumnEmail.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnEmail.DataPropertyName = "email";
            this.ColumnEmail.FillWeight = 65F;
            this.ColumnEmail.HeaderText = "Contact email";
            this.ColumnEmail.Name = "ColumnEmail";
            this.ColumnEmail.ReadOnly = true;
            this.ColumnEmail.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColumnEmail.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // SupplierForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(773, 573);
            this.Controls.Add(this.debugBox);
            this.Controls.Add(this.checkBoxAM);
            this.Controls.Add(this.formFieldEmail);
            this.Controls.Add(this.formFieldName);
            this.Controls.Add(this.formFieldID);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.groupBoxOptions);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.textBoxSearch);
            this.Controls.Add(this.dgv);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SupplierForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Suppliers";
            this.Load += new System.EventHandler(this.SupplierForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.groupBoxOptions.ResumeLayout(false);
            this.groupBoxOptions.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.GroupBox groupBoxOptions;
        private System.Windows.Forms.RadioButton radioButtonEdit;
        private System.Windows.Forms.RadioButton radioButtonNew;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonDelete;
        private UserControls.FormField formFieldID;
        private UserControls.FormField formFieldName;
        private UserControls.FormField formFieldEmail;
        private System.Windows.Forms.CheckBox checkBoxAM;
        private System.Windows.Forms.TextBox debugBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnEmail;
    }
}