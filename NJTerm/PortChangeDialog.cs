using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NanoTerm
{
    public partial class PortChangeDialog : Form
    {
        public PortChangeDialog(string[] ports)
        {
            InitializeComponent();
            foreach (string port in ports)
            {
                this.comboBox_COM.Items.Add(port);
            }
            if (this.comboBox_COM.Items.Count > 0)
            {
                this.comboBox_COM.SelectedIndex = 0;
            }
            else
            {
                this.radioButton_Change.Checked = false;
                this.radioButton_Ignore.Checked = true;
                this.comboBox_COM.Enabled = false;
            }
        }

        private void radioButton_Ignore_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButton_Ignore.Checked)
            {
                this.comboBox_COM.Enabled = false;
            }
        }

        private void radioButton_Change_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButton_Change.Checked)
            {
                this.comboBox_COM.Enabled = true;
            }
        }

        private void button_AllOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Yes;
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.No;
        }
    }
}
