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
    public partial class FormField : UserControl
    {
        private Regex rgx = new Regex(@".");

        public Boolean isValid { get; set; }

        public Boolean numericOnly { get; set; }

        public String regEx
        {
            get { return rgx.ToString(); }
            set { rgx = new Regex(value); }
        }

        public String text
        {
            get { return this.textBoxField.Text; }
            set { this.textBoxField.Text = value; this.validateInput(); }
        }

        public String title
        {
            get { return this.labelTitle.Text; }
            set { this.labelTitle.Text = value; }
        }

        // Property created so the max lenght can be manipulated to better control the user input

        public Int32 textMaxLenght
        {
            get { return this.textBoxField.MaxLength; }
            set { this.textBoxField.MaxLength = value; }
        }

        // Basically a binary switch that determines if the user should be able to manipukate the contents of the field

        public Boolean assignManually
        {
            get { return this.textBoxField.Enabled; }
            set
            {
                this.textBoxField.Enabled = value;
                if (value) this.textBoxField.Focus();
            }
        }

        public FormField()
        {
            InitializeComponent();
            validateInput();
            assignManually = true;
        }

        private void validateInput()
        {
            this.isValid = this.rgx.IsMatch(textBoxField.Text);
            if (this.textBoxField.TextLength > 0)
            {
                if (this.isValid)
                {
                    this.reset();
                }
                else
                {
                    this.displayFeedback();
                }
            }
            else
            {
                this.reset();
            }
        }

        private void textBoxField_GotFocus(object sender, EventArgs e)
        {
            if(this.numericOnly)
                this.textBoxField.KeyPress += new KeyPressEventHandler(this.textBoxField_KeyPress);
            if (this.textBoxField.Text != String.Empty)
            {
                this.textBoxField.TextChanged += new System.EventHandler(this.textBoxField_TextChanged);
            }
        }

        private void textBoxField_LostFocus(object sender, EventArgs e)
        {
            this.validateInput();
            if (!this.isValid && this.textBoxField.Text != String.Empty)
            {
                this.displayFeedback();
            }
        }

        private void textBoxField_TextChanged(object sender, EventArgs e)
        {
            this.validateInput();
        }

        private void displayFeedback()
        {
            this.labelError.Visible = true;
            this.labelError.Text = "Erroneous input";
        }

        private void reset()
        {
            this.labelError.Visible = false;
        }

        // Method created as a way to let the user infer that the field should be filled with numbers only
        // The criteria can be easily modified so it'll accept only certan set of characters

        private void textBoxField_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }
    }
}
