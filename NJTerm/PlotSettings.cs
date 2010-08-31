using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Collections;
using System.Reflection;

namespace NanoTerm
{

    public partial class PlotSettings : Form
    {
        public Hashtable DataSeries;
        public MarkerStyle defaultMarkerStyle;
        public int defaultMarkerSize;
        public DataTable dt;
        public Hashtable Dic;
        private string oldSeries = "";

        public PlotSettings(string[] PortNames)
        {
            InitializeComponent();

            #region{Key-Valueペアの準備}
            this.Dic = new Hashtable();
            Dic["●"] = MarkerStyle.Circle;
            Dic["×"] = MarkerStyle.Cross;
            Dic["▲"] = MarkerStyle.Triangle;
            Dic["■"] = MarkerStyle.Square;
            Dic["なし"] = MarkerStyle.None;
            Dic["主軸"] = AxisType.Primary;
            Dic["第2軸"] = AxisType.Secondary;
            Dic["折れ線（マーカーなし）"] = SeriesChartType.FastLine;
            Dic["散布図"] = SeriesChartType.FastPoint;
            Dic["折れ線（マーカー有り）"] = SeriesChartType.Line;
            Dic["ステップ"] = SeriesChartType.StepLine;
            Dic["棒"] = SeriesChartType.Column;
            Dic["線（スムージング）"] = SeriesChartType.Spline;

            Hashtable h2 = new Hashtable();
            foreach (object o in Dic.Keys)
            {
                h2[Dic[o]] = o;
            }
            foreach (object o in h2.Keys)
            {
                Dic[o] = h2[o];
            }
           
            #endregion

            DataGridViewComboBoxColumn dataGridPortColumn = (DataGridViewComboBoxColumn)this.dataGridView1.Columns["COM"];           
            foreach (string port in PortNames)
            {
                this.comboBox_Port.Items.Add(port);
                dataGridPortColumn.Items.Add(port);
            }

            this.comboBox_ChartType.DrawMode = DrawMode.OwnerDrawFixed;
            DataTable table = new DataTable();
            //テーブルにValueMemberとDisplayMemberの列とイメージの列を追加
            table.Columns.Add("ValueMember", typeof(SeriesChartType));//ValueMember（項目の値）
            table.Columns.Add("DisplayMember", typeof(string)); //DisplayMember（項目の表示名）
            table.Columns.Add("Image", typeof(Image));  //項目のイメージ
            table.Columns.Add("HasPoint", typeof(bool));  //点を描画するか

            Assembly asm = Assembly.GetExecutingAssembly();

            table.Rows.Add(SeriesChartType.FastPoint, "散布図", new Bitmap(asm.GetManifestResourceStream("NanoTerm.Images.point.BMP")),true);
            table.Rows.Add(SeriesChartType.FastLine, "折れ線（マーカーなし）", new Bitmap(asm.GetManifestResourceStream("NanoTerm.Images.fastline.BMP")),false);
            table.Rows.Add(SeriesChartType.Line, "折れ線（マーカー有り）", new Bitmap(asm.GetManifestResourceStream("NanoTerm.Images.line.BMP")),true);
            table.Rows.Add(SeriesChartType.Spline, "線（スムージング）", new Bitmap(asm.GetManifestResourceStream("NanoTerm.Images.spline.BMP")),true);
            table.Rows.Add(SeriesChartType.StepLine, "ステップ", new Bitmap(asm.GetManifestResourceStream("NanoTerm.Images.stepline.BMP")),true);
            table.Rows.Add(SeriesChartType.Column, "棒", new Bitmap(asm.GetManifestResourceStream("NanoTerm.Images.column.BMP")),false);

            this.comboBox_ChartType.ValueMember = "ValueMember";
            this.comboBox_ChartType.DisplayMember = "DisplayMember";
            this.comboBox_ChartType.DataSource = table;

        }

        public void SetInitiallizedValues()
        {
            foreach (Plot p in this.DataSeries.Values)
            {
                this.comboBox_Series.Items.Add(p.Series);
            }
            if (this.comboBox_Series.Items.Count != 0)
            {
                this.comboBox_Series.SelectedIndex = 0;
                refreshSimple();
            }
            this.oldSeries = this.comboBox_Series.Text;
            datagridSetting();
            this.comboBox_Series.SelectedIndexChanged += new System.EventHandler(this.comboBox_Series_SelectedIndexChanged);
        }

        private void datagridSetting()
        {
            foreach (Plot p in this.DataSeries.Values)
            {
                addDataGrid(p);
            }
        }

        private void refreshGrids()
        {
            this.dataGridView1.Rows.Clear();
            foreach (Plot p in this.DataSeries.Values)
            {
                addDataGrid(p);
            }
        }

        private void addDataGrid(Plot p)
        {
            int i = this.dataGridView1.Rows.Count;
            this.dataGridView1.Rows.Add();
            this.dataGridView1["Marker", i].Value = Dic[p.MarkerStyle];
            this.dataGridView1["ChartType", i].Value = Dic[p.ChartType];
            this.dataGridView1["YAxisType", i].Value = Dic[p.YAxisType];
            this.dataGridView1["Series", i].Value = p.Series;
            this.dataGridView1["COM", i].Value = p.COM;
            this.dataGridView1["Splitter", i].Value = p.Splitter;
            this.dataGridView1["a", i].Value = p.a.ToString();
            this.dataGridView1["b", i].Value = p.b.ToString();
            this.dataGridView1["Label", i].Value = p.Label;
            this.dataGridView1["MarkerSize", i].Value = p.MarkerSize.ToString();
        }

        private void refreshSimple()
        {
            string Series = this.comboBox_Series.Text;
            if (Series.Length == 0)
            {
                return;
            }
            this.comboBox_Port.Text = ((Plot)(DataSeries[Series])).COM;
            SeriesChartType s = ((Plot)(DataSeries[Series])).ChartType;
            switch (s)
            {
                case SeriesChartType.FastPoint:
                    this.comboBox_ChartType.SelectedIndex = 0;
                    break;
                case SeriesChartType.FastLine:
                    this.comboBox_ChartType.SelectedIndex = 1;
                    break;
                case SeriesChartType.Line:
                    this.comboBox_ChartType.SelectedIndex = 2;
                    break;
                case SeriesChartType.Spline:
                    this.comboBox_ChartType.SelectedIndex = 3;
                    break;
                case SeriesChartType.StepLine:
                    this.comboBox_ChartType.SelectedIndex = 4;
                    break;
                case SeriesChartType.Column:
                    this.comboBox_ChartType.SelectedIndex = 5;
                    break;
                default:
                    this.comboBox_ChartType.SelectedIndex = 0;
                    break;
            }
            if (((Plot)(DataSeries[Series])).YAxisType == AxisType.Primary)
            {
                this.radioButton_MainAxis.Checked = true;
            }
            else
            {
                this.radioButton_SubAxis.Checked = true;
            }

            if (s == SeriesChartType.Line)
            {
                if (((Plot)(DataSeries[Series])).MarkerStyle == this.defaultMarkerStyle &&
                    ((Plot)(DataSeries[Series])).MarkerSize == this.defaultMarkerSize)
                {
                    this.radioButton_default.Checked = true;
                    this.numericUpDown_markerSize.Enabled = false;
                    this.comboBox_markerStyle.Enabled = false;
                }
                else if (((Plot)(DataSeries[Series])).MarkerStyle == MarkerStyle.None)
                {
                    this.radioButton_none.Checked = true;
                    this.numericUpDown_markerSize.Enabled = false;
                    this.comboBox_markerStyle.Enabled = false;
                }
                else
                {
                    this.radioButton_custom.Checked = true;
                    this.numericUpDown_markerSize.Value = ((Plot)(DataSeries[Series])).MarkerSize;
                    MarkerStyle m = ((Plot)(DataSeries[Series])).MarkerStyle;
                    switch (m)
                    {
                        case MarkerStyle.Square:
                            this.comboBox_markerStyle.SelectedIndex = 0;
                            break;
                        case MarkerStyle.Circle:
                            this.comboBox_markerStyle.SelectedIndex = 1;
                            break;
                        case MarkerStyle.Cross:
                            this.comboBox_markerStyle.SelectedIndex = 2;
                            break;
                        case MarkerStyle.Triangle:
                            this.comboBox_markerStyle.SelectedIndex = 3;
                            break;
                        default:
                            this.comboBox_markerStyle.SelectedIndex = 0;
                            break;
                    }
                }
            }
            else
            {
                this.groupBox_MarkerSettings.Enabled = false;
            }


        }

        private void comboBox_Series_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBox_Port.Text.Length != 0)
            {
                saveSimpleSettings();
                refreshSimple();
            }
        }

        private void saveSimpleSettings()
        {
            if (this.oldSeries.Length == 0)
            {
                return;
            }
            string com = this.comboBox_Port.Text;
            string Series = this.oldSeries; 

            Plot newPlot = ((Plot)(DataSeries[Series]));

            newPlot.ChartType = (SeriesChartType)(((DataRowView)this.comboBox_ChartType.SelectedItem).Row["ValueMember"]);
            if (newPlot.ChartType == SeriesChartType.Point || newPlot.ChartType == SeriesChartType.Line)
            {
                if (this.radioButton_custom.Checked)
                {
                    switch (this.comboBox_markerStyle.SelectedIndex)
                    {
                        case 0:
                            newPlot.MarkerStyle = MarkerStyle.Square;
                            break;
                        case 1:
                            newPlot.MarkerStyle = MarkerStyle.Circle;
                            break;
                        case 2:
                            newPlot.MarkerStyle = MarkerStyle.Cross;
                            break;
                        case 3:
                            newPlot.MarkerStyle = MarkerStyle.Triangle;
                            break;
                        default:
                            newPlot.MarkerStyle = MarkerStyle.Square;
                            break;
                    }
                    newPlot.MarkerSize = (int)this.numericUpDown_markerSize.Value;
                }
                else if (this.radioButton_default.Checked)
                {
                    newPlot.MarkerStyle = this.defaultMarkerStyle;
                    newPlot.MarkerSize = this.defaultMarkerSize;
                }
                else
                {
                    newPlot.MarkerStyle = MarkerStyle.None;
                    newPlot.MarkerSize = 0;
                }
            }

            if (this.radioButton_MainAxis.Checked)
            {
                newPlot.YAxisType = AxisType.Primary;
            }
            else
            {
                newPlot.YAxisType = AxisType.Secondary;
            }

            newPlot.COM = com;

            this.DataSeries[Series] = newPlot;
            this.oldSeries = this.comboBox_Series.Text;
        }

        private void saveDetailSettings()
        {
            foreach (DataGridViewRow row in this.dataGridView1.Rows)
            {
                Plot p = new Plot();
                p.Series = row.Cells["Series"].Value.ToString();
                p.COM = row.Cells["COM"].Value.ToString();
                p.Label = row.Cells["Label"].Value.ToString();
                p.Splitter = row.Cells["Splitter"].Value.ToString();
                p.ChartType = (SeriesChartType)this.Dic[row.Cells["ChartType"].Value];
                try
                {
                    p.a = double.Parse(row.Cells["a"].Value.ToString());
                    p.b = double.Parse(row.Cells["b"].Value.ToString());
                }
                catch
                {
                    MessageBox.Show("a,bに正しい書式の数値を入力してください。","設定適用エラー");
                }
                p.YAxisType = (AxisType)this.Dic[row.Cells["YAXisType"].Value];
                p.MarkerStyle = (MarkerStyle)this.Dic[row.Cells["Marker"].Value];
                p.MarkerSize = int.Parse(row.Cells["MarkerSize"].Value.ToString());
                p.SeriesIndex = ((Plot)(this.DataSeries[p.Series])).SeriesIndex;
                p.DefaultColor = ((Plot)(this.DataSeries[p.Series])).DefaultColor;
                p.comNumber = ((Plot)(this.DataSeries[p.Series])).comNumber;
                p.IsSeriesPlot = ((Plot)(this.DataSeries[p.Series])).IsSeriesPlot;
                this.DataSeries[p.Series] = p;

            }
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            if (this.panel_Simple.Visible)
            {
                saveSimpleSettings();

            }
            else
            {
                saveDetailSettings();
            }
        }

        private void radioButton_custom_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButton_custom.Checked)
            {
                this.comboBox_markerStyle.Enabled = true;
                this.numericUpDown_markerSize.Enabled = true;
            }
            else
            {
                this.comboBox_markerStyle.Enabled = false;
                this.numericUpDown_markerSize.Enabled = false;
            }
        }

        private void comboBox_ChartType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((bool)(((DataRowView)this.comboBox_ChartType.SelectedItem).Row["HasPoint"])) // ChartType.Line
            {
                this.groupBox_MarkerSettings.Enabled = true;
            }
            else
            {
                this.groupBox_MarkerSettings.Enabled = false;
            }
        }

        private void comboBox_ChartType_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (-1 < e.Index)
            {//描画対象となる項目のインデックスが有効なとき

                //コンボボックスを取得
                ComboBox cmbBox = (ComboBox)sender;

                //描画対象となる項目を取得
                DataRowView dataRowView = (DataRowView)cmbBox.Items[e.Index];

                //項目のテキストを取得
                string text = (string)dataRowView.Row["DisplayMember"];

                //項目のイメージを取得
                Image image = dataRowView.Row["Image"] as Image;

                //イメージの描画領域
                //イメージをコンボボックスの高さに合わせる。幅は高さを同じ比率にする
                Rectangle imgRect = new Rectangle(
                    e.Bounds.Left + 1,//左上X
                    e.Bounds.Top + 1,//左上Y
                     (cmbBox.ItemHeight - 2) * image.Width / image.Height,//幅
                    cmbBox.ItemHeight - 2);//高さ

                //テキストの描画領域
                //テキストはイメージの右に3px隙間を空け、上下中央-左寄せで表示。
                Rectangle textRect = new Rectangle(
                    e.Bounds.Left + imgRect.Width + 3,//左上X
                    e.Bounds.Top + (cmbBox.ItemHeight - e.Font.Height) / 2,//左上Y
                    e.Bounds.Width - (imgRect.Width + 2),//幅
                    e.Font.Height);//高さ

                if (cmbBox.Enabled)
                {//コンボボックスが有効なとき

                    //背景を描画
                    e.DrawBackground();

                    //項目のイメージを描画
                    e.Graphics.DrawImage(image, imgRect);

                    //項目のテキストを前景色で描画
                    e.Graphics.DrawString(text, e.Font, new SolidBrush(e.ForeColor), textRect);

                    //フォーカスを示す四角形を描画
                    e.DrawFocusRectangle();
                }
                else
                {//コンボボックスが無効なとき

                    //項目の描画サイズのイメージを作成
                    Bitmap drawSizeImage = new Bitmap(image, imgRect.Width, imgRect.Height);

                    //項目の無効状態のイメージを描画
                    ControlPaint.DrawImageDisabled(e.Graphics, drawSizeImage, imgRect.Left, imgRect.Top, e.BackColor);

                    //項目のテキストを淡色で描画
                    e.Graphics.DrawString(text, e.Font, new SolidBrush(Color.FromKnownColor(KnownColor.GrayText)), textRect);
                }
            }
        }

        private void button_Detail_Click(object sender, EventArgs e)
        {
            saveSimpleSettings();
            this.panel_Simple.Visible = false;
            this.panel_Detail.Visible = true;
            refreshGrids();
            this.Width = 830;
        }

        private void button_Simple_Click(object sender, EventArgs e)
        {
            saveDetailSettings();
            this.panel_Detail.Visible = false;
            this.panel_Simple.Visible = true;
            refreshSimple();
            this.Width = 383;
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        //#region{datagridview}

        //private void setMarkerStyle()
        //{
        //    KeyValuePair<string, MarkerStyle>[] MarkerStyleComboBox = new KeyValuePair<string, MarkerStyle>[]{
        //        new KeyValuePair<string,MarkerStyle>("■",MarkerStyle.Square),
        //        new KeyValuePair<string,MarkerStyle>("●",MarkerStyle.Circle),
        //        new KeyValuePair<string,MarkerStyle>("×",MarkerStyle.Cross),
        //        new KeyValuePair<string,MarkerStyle>("▲",MarkerStyle.Diamond),
        //    };
        //    DataGridViewComboBoxColumn co = (DataGridViewComboBoxColumn)this.dataGridView1.Columns["Marker"];
        //    co.DataSource = MarkerStyleComboBox;
        //    co.ValueMember = "Value";
        //    co.DisplayMember = "Key";
        //}

        //private void setAxisType()
        //{
        //    KeyValuePair<string, AxisType>[] AxisTypeComboBox = new KeyValuePair<string, AxisType>[]{
        //        new KeyValuePair<string,AxisType>("主軸",AxisType.Primary),
        //        new KeyValuePair<string,AxisType>("第2軸",AxisType.Secondary)};
        //    DataGridViewComboBoxColumn co = (DataGridViewComboBoxColumn)this.dataGridView1.Columns["YAxisType"];
        //    co.DataSource = AxisTypeComboBox;
        //    co.ValueMember = "Value";
        //    co.DisplayMember = "Key";
        //}

        //private void setChartType()
        //{
        //    KeyValuePair<string, SeriesChartType>[] SeriesChartTypeComboBox = new KeyValuePair<string, SeriesChartType>[]{
        //        new KeyValuePair<string,SeriesChartType>("散布図",SeriesChartType.Point),
        //        new KeyValuePair<string,SeriesChartType>("折れ線（マーカーなし）",SeriesChartType.FastLine),
        //        new KeyValuePair<string,SeriesChartType>("折れ線（マーカー有り）",SeriesChartType.FastPoint),
        //        new KeyValuePair<string,SeriesChartType>("線（スムージング）",SeriesChartType.Spline),          
        //        new KeyValuePair<string,SeriesChartType>("ステップ",SeriesChartType.StepLine),
        //        new KeyValuePair<string,SeriesChartType>("棒",SeriesChartType.Column)          
        //    };

        //    ((DataGridViewComboBoxColumn)(this.dataGridView2.Columns["CType"])).DataSource = SeriesChartTypeComboBox;
        //    ((DataGridViewComboBoxColumn)(this.dataGridView2.Columns["CType"])).ValueMember = "Value";
        //    ((DataGridViewComboBoxColumn)(this.dataGridView2.Columns["CType"])).DisplayMember = "Key";
        //}


        //#endregion

    }
}
