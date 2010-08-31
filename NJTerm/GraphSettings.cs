using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace NanoTerm
{
    public partial class GraphSettings : Form
    {
        public string AXisXTitle = "";
        public string AXisYTitle = "";
        public string GraphTitle = "";
        public string AXisY2Title = "";

        public GraphSettings(Chart chart)
        {
            InitializeComponent();
            this.textBox_Axis2ndYTitle.Text = chart.ChartAreas[0].AxisY2.Title;
            this.textBox_AxisXTitle.Text = chart.ChartAreas[0].AxisX.Title;
            this.textBox_AxisYTitle.Text = chart.ChartAreas[0].AxisY.Title;
            if (chart.Titles.Count > 0)
            {
                this.textBox_GraphTitle.Text = chart.Titles[0].Text;
            }
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            this.AXisXTitle = this.textBox_AxisXTitle.Text;
            this.AXisYTitle = this.textBox_AxisYTitle.Text;
            this.GraphTitle = this.textBox_GraphTitle.Text;
            this.AXisY2Title = this.textBox_Axis2ndYTitle.Text;
            this.DialogResult = DialogResult.OK;
        }
    }
}
