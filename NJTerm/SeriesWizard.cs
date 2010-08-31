using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Windows.Forms.DataVisualization.Charting;
using System.Collections;
using System.Globalization;
using System.Text.RegularExpressions;

namespace NanoTerm
{
    public partial class SeriesWizard : Form
    {
        Plot p;
        public List<Plot> plots;
        int page = 1;
        string graphDescriptionDefault;

        string[] FormTitle = { "データ系列の追加ウィザード - 1/4 - COMポートの選択", 
                             "データ系列の追加ウィザード - 2/4 - データ抽出方法の選択",
                             "データ系列の追加ウィザード - 3/4 - ラベルと変換式", 
                             "データ系列の追加ウィザード - 3/4 - ラベルと変換式", 
                             "データ系列の追加ウィザード - 4/4 - グラフの種類" };

        Hashtable GraphToolTip = new Hashtable();

        public SeriesWizard()
        {
            InitializeComponent();
            foreach (string port in SerialPort.GetPortNames())
            {
                this.comboBox_1_COM.Items.Add(port);
            }
            this.comboBox_1_COM.SelectedIndex = 0;

            this.Text = this.FormTitle[0];
            this.p = new Plot();
            this.plots = new List<Plot>();
            this.dataGridView_3B.Rows.Add();
            this.dataGridView_3B[0, 0].Value = "0";
            this.graphDescriptionDefault = this.textBox_4_Explain.Text;
            GraphToolTip[SeriesChartType.Column] = "集合縦棒 - 項目ごとに値を比較します．";
            GraphToolTip[SeriesChartType.Line] = "折れ線グラフ - データにマーカーが付けられた折れ線グラフです．長時間描画する場合，速度が低下することがあります．";
            GraphToolTip[SeriesChartType.FastLine] = "折れ線グラフ - データにマーカーが付けられていない折れ線グラフです．大量のデータを高速に描画可能です．";
            GraphToolTip[SeriesChartType.FastPoint] = "散布図 - 値の組を比較します．大量のデータを高速に描画可能です．";
            GraphToolTip[SeriesChartType.StepLine] = "ステップグラフ - 階段状にデータを表示します．";
            GraphToolTip[SeriesChartType.Spline] = "スプライン - データポイントを平滑線で繋いだグラフです．";       
        }

        void nextPage()
        {
            panel_1_COMSelect.Visible = false;
            panel_2_LabelType.Visible = false;
            panel_3A_Label.Visible = false;
            panel_3B_Label.Visible = false;
            panel_4_ChartType.Visible = false;

            switch (page)
            {
                case 1:
                    panel_2_LabelType.Visible = true;
                    panel_2_LabelType.BringToFront();
                    this.button_Previous.Enabled = true;
                    this.Text = this.FormTitle[1];
                    break;
                case 2:
                    if (radioButton_2_Array.Checked)
                    {
                        panel_3B_Label.Visible = true;
                        panel_3B_Label.BringToFront();
                        this.Text = this.FormTitle[3];
                    }
                    else
                    {
                        panel_3A_Label.Visible = true;
                        panel_3A_Label.BringToFront();
                        this.Text = this.FormTitle[2];
                    }
                    break;
                case 3:
                    panel_4_ChartType.Visible = true;
                    panel_4_ChartType.BringToFront();
                    this.Text = this.FormTitle[4];
                    this.button_Next.Enabled = false;
                    this.button_OK.Enabled = true;
                    break;
            }
            page++;
        }

        void previousPage()
        {
            panel_1_COMSelect.Visible = false;
            panel_2_LabelType.Visible = false;
            panel_3A_Label.Visible = false;
            panel_3B_Label.Visible = false;
            panel_4_ChartType.Visible = false;

            switch (page)
            {
                case 2:
                    panel_1_COMSelect.Visible = true;
                    panel_1_COMSelect.BringToFront();
                    this.Text = this.FormTitle[0];
                    this.button_Previous.Enabled = false;
                    break;
                case 3:
                    panel_2_LabelType.Visible = true;
                    panel_2_LabelType.BringToFront();
                    this.Text = this.FormTitle[1];
                    break;
                case 4:
                    if (radioButton_2_Array.Checked)
                    {
                        panel_3B_Label.Visible = true;
                        panel_3B_Label.BringToFront();
                        this.Text = this.FormTitle[3];
                    }
                    else
                    {
                        panel_3A_Label.Visible = true;
                        panel_3A_Label.BringToFront();
                        this.Text = this.FormTitle[2];
                    }
                    button_Next.Enabled = true;
                    button_OK.Enabled = false;
                    break;
            }
            page--;
        }

        private void button_Next_Click(object sender, EventArgs e)
        {
            nextPage();
        }

        private void button_Previous_Click(object sender, EventArgs e)
        {
            previousPage();
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            #region{ラベル型の場合}
            if (radioButton_2_Label.Checked)
            {
                Plot plot = new Plot();
                if (this.comboBox_1_COM.Text.Length == 0)
                {
                    MessageBox.Show("COMポートを指定してください");
                    return;
                }
                plot.comNumber = MainForm.portNumber(this.comboBox_1_COM.Text);
                plot.COM = this.comboBox_1_COM.Text;
                if (!double.TryParse(this.textBox_3A_a.Text, out plot.a))
                {
                    plot.a = 1.0;
                }
                if (!double.TryParse(this.textBox_3A_b.Text, out plot.b))
                {
                    plot.b = 0.0;
                }
                plot.ChartType = getChartType();
                if (textBox_3A_Label.Text.Length == 0)
                {
                    MessageBox.Show("ラベルを入力してください");
                    return;
                }
                plot.Label = textBox_3A_Label.Text;

                if (textBox_3A_Series.Text.Length == 0)
                {
                    MessageBox.Show("系列名を入力してください");
                    return;
                }
                plot.Series = textBox_3A_Series.Text;

                if (checkBox_3A_SecondaryAxis.Checked)
                {
                    plot.YAxisType = AxisType.Secondary;
                }
                this.plots.Add(plot);
            }
            #endregion

            #region{配列型の場合}
            else
            {
                if (textBox_3B_Splitter.Text.Length == 0)
                {
                    MessageBox.Show("スプリッタを入力してください");
                    return;
                }
                if (this.comboBox_1_COM.Text.Length == 0)
                {
                    MessageBox.Show("COMポートを指定してください");
                    return;
                }

                foreach (DataGridViewRow row in this.dataGridView_3B.Rows)
                {
                    if (row.Cells[1].Value != null && row.Cells[0].Value != null)
                    {
                        Plot p = new Plot();
                        if (!double.TryParse((string)row.Cells[2].Value, out p.a))
                        {
                            p.a = 1.0;
                        }
                        if (!double.TryParse((string)row.Cells[3].Value, out p.b))
                        {
                            p.b = 0.0;
                        }
                        if (this.textBox_3B_Label.Text.Length != 0)
                        {
                            p.Label = this.textBox_3B_Label.Text;
                        }
                        else
                        {
                            p.Label = "";
                        }
                        p.ChartType = getChartType();

                        p.IsSeriesPlot = true;
                        p.Series = row.Cells[1].Value.ToString();
                        p.Splitter = textBox_3B_Splitter.Text;
                        p.COM = this.comboBox_1_COM.Text;
                        p.SeriesIndex = int.Parse(row.Cells[0].Value.ToString());
                        p.comNumber = MainForm.portNumber(this.comboBox_1_COM.Text);

                        this.plots.Add(p);
                    }
                }

            }
            #endregion

            this.DialogResult = DialogResult.OK;
        }

        private SeriesChartType getChartType()
        {
            if (this.radioButton_4_Column.Checked)
            {
                return SeriesChartType.Column;
            }
            else if (this.radioButton_4_FastLine.Checked)
            {
                return SeriesChartType.FastLine;
            }
            else if (this.radioButton_4_Line.Checked)
            {
                return SeriesChartType.Line;
            }
            else if (this.radioButton_4_Point.Checked)
            {
                return SeriesChartType.Point;
            }
            else if (this.radioButton_4_Spline.Checked)
            {
                return SeriesChartType.Spline;
            }
            else
            {
                return SeriesChartType.FastLine;
            }
        }

        private void numericUpDown_3B_ValueChanged(object sender, EventArgs e)
        {
            if (this.dataGridView_3B.Rows.Count < (this.numericUpDown_3B.Value))
            {
                while (this.dataGridView_3B.Rows.Count != (this.numericUpDown_3B.Value))
                {
                    DataGridViewDataErrorContexts c = new DataGridViewDataErrorContexts();
                    this.dataGridView_3B.Rows.Add();
                    this.dataGridView_3B[0, this.dataGridView_3B.Rows.Count - 1].Value = this.dataGridView_3B.Rows.Count - 1;
                    this.dataGridView_3B.CommitEdit(c);
                }
            }
            else if (this.dataGridView_3B.Rows.Count > (this.numericUpDown_3B.Value))
            {
                while (this.dataGridView_3B.Rows.Count != (this.numericUpDown_3B.Value))
                {
                    DataGridViewRow dr = this.dataGridView_3B.Rows[dataGridView_3B.Rows.Count - 1];
                    this.dataGridView_3B.Rows.RemoveAt(dataGridView_3B.Rows.Count - 1);
                    //this.dataGridView_3B.Rows.Remove(this.dataGridView_3B.Rows[this.dataGridView_3B.Rows.Count - 1]);
                }
            }
        }

        private void radioButton_4_FastLine_MouseEnter(object sender, EventArgs e)
        {
            this.textBox_4_Explain.Text = (string)this.GraphToolTip[SeriesChartType.FastLine];
        }

        private void radioButton_4_Point_MouseEnter(object sender, EventArgs e)
        {
            this.textBox_4_Explain.Text = (string)this.GraphToolTip[SeriesChartType.FastPoint];
        }

        private void radioButton_4_Line_MouseEnter(object sender, EventArgs e)
        {
            this.textBox_4_Explain.Text = (string)this.GraphToolTip[SeriesChartType.Line];
        }



        private void radioButton_4_Line_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButton_4_Line.Checked)
            {
                this.graphDescriptionDefault = (string)this.GraphToolTip[SeriesChartType.Line];
            }
        }

        private void radioButton_4_FastLine_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButton_4_FastLine.Checked)
            {
                this.graphDescriptionDefault = (string)this.GraphToolTip[SeriesChartType.FastLine];
            }
        }

        private void radioButton_4_Point_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButton_4_Point.Checked)
            {
                this.graphDescriptionDefault = (string)this.GraphToolTip[SeriesChartType.FastPoint];
            }
        }

        private void radioButton_4_Column_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButton_4_Column.Checked)
            {
                this.graphDescriptionDefault = (string)this.GraphToolTip[SeriesChartType.Column];
            }
        }

        private void radioButton_4_Spline_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButton_4_Spline.Checked)
            {
                this.graphDescriptionDefault = (string)this.GraphToolTip[SeriesChartType.Spline];
            }
        }

        private void radioButton_4_Spline_MouseEnter(object sender, EventArgs e)
        {
            this.textBox_4_Explain.Text = (string)this.GraphToolTip[SeriesChartType.Spline];
        }

        private void radioButton_4_Column_MouseEnter(object sender, EventArgs e)
        {
            this.textBox_4_Explain.Text = (string)this.GraphToolTip[SeriesChartType.Column];
        }

        private void radioButton_4_Line_MouseLeave(object sender, EventArgs e)
        {
            this.textBox_4_Explain.Text = this.graphDescriptionDefault;
        }

        private void radioButton_4_FastLine_MouseLeave(object sender, EventArgs e)
        {
            this.textBox_4_Explain.Text = this.graphDescriptionDefault;
        }

        private void radioButton_4_Point_MouseLeave(object sender, EventArgs e)
        {
            this.textBox_4_Explain.Text = this.graphDescriptionDefault;
        }

        private void radioButton_4_Spline_MouseLeave(object sender, EventArgs e)
        {
            this.textBox_4_Explain.Text = this.graphDescriptionDefault;
        }

        private void radioButton_4_Column_MouseLeave(object sender, EventArgs e)
        {
            this.textBox_4_Explain.Text = this.graphDescriptionDefault;
        }

        private void button_3A_Regcheck_Click(object sender, EventArgs e)
        {
            string s = textBox_3A_Label.Text + "[: ]?" + "([-0-9.a-fA-Fx]+)";
            Regex r = new Regex(s);
            Match m = r.Match(textBox_3A_Reg.Text);
            while (m.Success)
            {
                if (m.Groups.Count > 1)
                {
                    string val = m.Groups[1].Value;
                    int i;
                    double j;
                    if (double.TryParse(m.Groups[1].Value, NumberStyles.Number, CultureInfo.InvariantCulture, out j))
                    {
                        double value = double.Parse(m.Groups[1].Value);
                        double a,b;
                        if (double.TryParse(textBox_3A_a.Text, out a) && double.TryParse(textBox_3A_b.Text, out b))
                        {
                            value = a * value + b;
                        }
                        MessageBox.Show(value.ToString());
                        return;

                    }
                    else if (Int32.TryParse(m.Groups[1].Value, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out i))
                    {
                        double value = (double)Int32.Parse(m.Groups[1].Value, NumberStyles.HexNumber);
                        double a, b;
                        if (double.TryParse(textBox_3A_a.Text, out a) && double.TryParse(textBox_3A_b.Text, out b))
                        {
                            value = a * value + b;
                        } 
                        MessageBox.Show(value.ToString());
                        return;
                    }
                }
                m = m.NextMatch();
            }
            MessageBox.Show("有効なデータを抽出できませんでした．");
        }

        private void textBox_3A_a_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != '\b' && e.KeyChar != '.')
            {
                e.Handled = true;
            }

        }

        private void textBox_3A_b_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != '\b' && e.KeyChar != '.')
            {
                e.Handled = true;
            }

        }

        //ショートカット処理
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Left)
            {
                if (page != 1)
                {
                    previousPage();
                }
                return true;
            }
            else if (keyData == Keys.Right)
            {
                if (page != 4)
                {
                    nextPage();
                }
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

    }
}
