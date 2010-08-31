namespace NanoTerm
{
    partial class PlotSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlotSettings));
            this.comboBox_Series = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button_Detail = new System.Windows.Forms.Button();
            this.comboBox_ChartType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox_MarkerSettings = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDown_markerSize = new System.Windows.Forms.NumericUpDown();
            this.comboBox_markerStyle = new System.Windows.Forms.ComboBox();
            this.radioButton_custom = new System.Windows.Forms.RadioButton();
            this.radioButton_none = new System.Windows.Forms.RadioButton();
            this.radioButton_default = new System.Windows.Forms.RadioButton();
            this.groupBox_AxisSelect = new System.Windows.Forms.GroupBox();
            this.radioButton_SubAxis = new System.Windows.Forms.RadioButton();
            this.radioButton_MainAxis = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox_Port = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button_OK = new System.Windows.Forms.Button();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Series = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COM = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Label = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Splitter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChartType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.a = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.b = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.YAxisType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Marker = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.MarkerSize = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.button_Simple = new System.Windows.Forms.Button();
            this.panel_Simple = new System.Windows.Forms.Panel();
            this.panel_Detail = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.groupBox_MarkerSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_markerSize)).BeginInit();
            this.groupBox_AxisSelect.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel_Simple.SuspendLayout();
            this.panel_Detail.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBox_Series
            // 
            this.comboBox_Series.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Series.FormattingEnabled = true;
            this.comboBox_Series.Location = new System.Drawing.Point(98, 13);
            this.comboBox_Series.Name = "comboBox_Series";
            this.comboBox_Series.Size = new System.Drawing.Size(159, 20);
            this.comboBox_Series.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button_Detail);
            this.groupBox1.Controls.Add(this.comboBox_ChartType);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.groupBox_MarkerSettings);
            this.groupBox1.Controls.Add(this.groupBox_AxisSelect);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.comboBox_Port);
            this.groupBox1.Location = new System.Drawing.Point(19, 52);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(340, 238);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "設定";
            // 
            // button_Detail
            // 
            this.button_Detail.Location = new System.Drawing.Point(13, 200);
            this.button_Detail.Name = "button_Detail";
            this.button_Detail.Size = new System.Drawing.Size(152, 24);
            this.button_Detail.TabIndex = 9;
            this.button_Detail.Text = "全系列の一括設定(&D)";
            this.button_Detail.UseVisualStyleBackColor = true;
            this.button_Detail.Click += new System.EventHandler(this.button_Detail_Click);
            // 
            // comboBox_ChartType
            // 
            this.comboBox_ChartType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_ChartType.FormattingEnabled = true;
            this.comboBox_ChartType.Location = new System.Drawing.Point(79, 44);
            this.comboBox_ChartType.Name = "comboBox_ChartType";
            this.comboBox_ChartType.Size = new System.Drawing.Size(159, 20);
            this.comboBox_ChartType.TabIndex = 8;
            this.comboBox_ChartType.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.comboBox_ChartType_DrawItem);
            this.comboBox_ChartType.SelectedIndexChanged += new System.EventHandler(this.comboBox_ChartType_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "グラフの種類";
            // 
            // groupBox_MarkerSettings
            // 
            this.groupBox_MarkerSettings.Controls.Add(this.label5);
            this.groupBox_MarkerSettings.Controls.Add(this.label4);
            this.groupBox_MarkerSettings.Controls.Add(this.numericUpDown_markerSize);
            this.groupBox_MarkerSettings.Controls.Add(this.comboBox_markerStyle);
            this.groupBox_MarkerSettings.Controls.Add(this.radioButton_custom);
            this.groupBox_MarkerSettings.Controls.Add(this.radioButton_none);
            this.groupBox_MarkerSettings.Controls.Add(this.radioButton_default);
            this.groupBox_MarkerSettings.Location = new System.Drawing.Point(171, 80);
            this.groupBox_MarkerSettings.Name = "groupBox_MarkerSettings";
            this.groupBox_MarkerSettings.Size = new System.Drawing.Size(152, 144);
            this.groupBox_MarkerSettings.TabIndex = 6;
            this.groupBox_MarkerSettings.TabStop = false;
            this.groupBox_MarkerSettings.Text = "マーカーの種類";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 113);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 12);
            this.label5.TabIndex = 13;
            this.label5.Text = "サイズ:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 12);
            this.label4.TabIndex = 12;
            this.label4.Text = "種類:";
            // 
            // numericUpDown_markerSize
            // 
            this.numericUpDown_markerSize.Location = new System.Drawing.Point(82, 111);
            this.numericUpDown_markerSize.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown_markerSize.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDown_markerSize.Name = "numericUpDown_markerSize";
            this.numericUpDown_markerSize.Size = new System.Drawing.Size(56, 19);
            this.numericUpDown_markerSize.TabIndex = 11;
            this.numericUpDown_markerSize.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // comboBox_markerStyle
            // 
            this.comboBox_markerStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_markerStyle.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.comboBox_markerStyle.FormattingEnabled = true;
            this.comboBox_markerStyle.Items.AddRange(new object[] {
            "■",
            "●",
            "×",
            "▲"});
            this.comboBox_markerStyle.Location = new System.Drawing.Point(82, 85);
            this.comboBox_markerStyle.Name = "comboBox_markerStyle";
            this.comboBox_markerStyle.Size = new System.Drawing.Size(56, 20);
            this.comboBox_markerStyle.TabIndex = 9;
            // 
            // radioButton_custom
            // 
            this.radioButton_custom.AutoSize = true;
            this.radioButton_custom.Location = new System.Drawing.Point(25, 63);
            this.radioButton_custom.Name = "radioButton_custom";
            this.radioButton_custom.Size = new System.Drawing.Size(69, 16);
            this.radioButton_custom.TabIndex = 2;
            this.radioButton_custom.TabStop = true;
            this.radioButton_custom.Text = "組み込み";
            this.radioButton_custom.UseVisualStyleBackColor = true;
            this.radioButton_custom.CheckedChanged += new System.EventHandler(this.radioButton_custom_CheckedChanged);
            // 
            // radioButton_none
            // 
            this.radioButton_none.AutoSize = true;
            this.radioButton_none.Location = new System.Drawing.Point(25, 41);
            this.radioButton_none.Name = "radioButton_none";
            this.radioButton_none.Size = new System.Drawing.Size(42, 16);
            this.radioButton_none.TabIndex = 1;
            this.radioButton_none.TabStop = true;
            this.radioButton_none.Text = "なし";
            this.radioButton_none.UseVisualStyleBackColor = true;
            // 
            // radioButton_default
            // 
            this.radioButton_default.AutoSize = true;
            this.radioButton_default.Checked = true;
            this.radioButton_default.Location = new System.Drawing.Point(25, 19);
            this.radioButton_default.Name = "radioButton_default";
            this.radioButton_default.Size = new System.Drawing.Size(47, 16);
            this.radioButton_default.TabIndex = 0;
            this.radioButton_default.TabStop = true;
            this.radioButton_default.Text = "自動";
            this.radioButton_default.UseVisualStyleBackColor = true;
            // 
            // groupBox_AxisSelect
            // 
            this.groupBox_AxisSelect.Controls.Add(this.radioButton_SubAxis);
            this.groupBox_AxisSelect.Controls.Add(this.radioButton_MainAxis);
            this.groupBox_AxisSelect.Location = new System.Drawing.Point(13, 80);
            this.groupBox_AxisSelect.Name = "groupBox_AxisSelect";
            this.groupBox_AxisSelect.Size = new System.Drawing.Size(152, 69);
            this.groupBox_AxisSelect.TabIndex = 5;
            this.groupBox_AxisSelect.TabStop = false;
            this.groupBox_AxisSelect.Text = "使用する軸";
            // 
            // radioButton_SubAxis
            // 
            this.radioButton_SubAxis.AutoSize = true;
            this.radioButton_SubAxis.Location = new System.Drawing.Point(25, 42);
            this.radioButton_SubAxis.Name = "radioButton_SubAxis";
            this.radioButton_SubAxis.Size = new System.Drawing.Size(100, 16);
            this.radioButton_SubAxis.TabIndex = 1;
            this.radioButton_SubAxis.TabStop = true;
            this.radioButton_SubAxis.Text = "第2軸(右側)(&S)";
            this.radioButton_SubAxis.UseVisualStyleBackColor = true;
            // 
            // radioButton_MainAxis
            // 
            this.radioButton_MainAxis.AutoSize = true;
            this.radioButton_MainAxis.Checked = true;
            this.radioButton_MainAxis.Location = new System.Drawing.Point(25, 19);
            this.radioButton_MainAxis.Name = "radioButton_MainAxis";
            this.radioButton_MainAxis.Size = new System.Drawing.Size(94, 16);
            this.radioButton_MainAxis.TabIndex = 0;
            this.radioButton_MainAxis.TabStop = true;
            this.radioButton_MainAxis.Text = "主軸(左側)(&P)";
            this.radioButton_MainAxis.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "ポート";
            // 
            // comboBox_Port
            // 
            this.comboBox_Port.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Port.FormattingEnabled = true;
            this.comboBox_Port.Location = new System.Drawing.Point(79, 18);
            this.comboBox_Port.Name = "comboBox_Port";
            this.comboBox_Port.Size = new System.Drawing.Size(159, 20);
            this.comboBox_Port.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "系列を選択";
            // 
            // button_OK
            // 
            this.button_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button_OK.Location = new System.Drawing.Point(12, 3);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(165, 33);
            this.button_OK.TabIndex = 3;
            this.button_OK.Text = "OK(&C)";
            this.button_OK.UseVisualStyleBackColor = true;
            this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
            // 
            // button_Cancel
            // 
            this.button_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_Cancel.Location = new System.Drawing.Point(194, 3);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(169, 33);
            this.button_Cancel.TabIndex = 4;
            this.button_Cancel.Text = "キャンセル(&X)";
            this.button_Cancel.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Series,
            this.COM,
            this.Label,
            this.Splitter,
            this.ChartType,
            this.a,
            this.b,
            this.YAxisType,
            this.Marker,
            this.MarkerSize});
            this.dataGridView1.Location = new System.Drawing.Point(6, 13);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 21;
            this.dataGridView1.Size = new System.Drawing.Size(805, 229);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridView1_DataError);
            // 
            // Series
            // 
            this.Series.HeaderText = "系列名";
            this.Series.MaxInputLength = 20;
            this.Series.Name = "Series";
            this.Series.ReadOnly = true;
            // 
            // COM
            // 
            this.COM.FillWeight = 55F;
            this.COM.HeaderText = "COM";
            this.COM.Name = "COM";
            this.COM.Width = 55;
            // 
            // Label
            // 
            this.Label.HeaderText = "ラベル";
            this.Label.MaxInputLength = 20;
            this.Label.Name = "Label";
            // 
            // Splitter
            // 
            this.Splitter.FillWeight = 70F;
            this.Splitter.HeaderText = "スプリッタ";
            this.Splitter.MaxInputLength = 4;
            this.Splitter.Name = "Splitter";
            this.Splitter.Width = 70;
            // 
            // ChartType
            // 
            this.ChartType.FillWeight = 150F;
            this.ChartType.HeaderText = "グラフの種類";
            this.ChartType.Items.AddRange(new object[] {
            "散布図",
            "折れ線（マーカーなし）",
            "折れ線（マーカー有り）",
            "線（スムージング）",
            "ステップ",
            "棒"});
            this.ChartType.Name = "ChartType";
            this.ChartType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ChartType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ChartType.Width = 150;
            // 
            // a
            // 
            this.a.FillWeight = 60F;
            this.a.HeaderText = "a";
            this.a.MaxInputLength = 10;
            this.a.Name = "a";
            this.a.Width = 50;
            // 
            // b
            // 
            this.b.FillWeight = 60F;
            this.b.HeaderText = "b";
            this.b.MaxInputLength = 10;
            this.b.Name = "b";
            this.b.Width = 50;
            // 
            // YAxisType
            // 
            this.YAxisType.FillWeight = 70F;
            this.YAxisType.HeaderText = "使用軸";
            this.YAxisType.Items.AddRange(new object[] {
            "主軸",
            "第2軸"});
            this.YAxisType.Name = "YAxisType";
            this.YAxisType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.YAxisType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.YAxisType.Width = 70;
            // 
            // Marker
            // 
            this.Marker.FillWeight = 50F;
            this.Marker.HeaderText = "マーカー";
            this.Marker.Items.AddRange(new object[] {
            "■",
            "●",
            "×",
            "▲",
            "なし"});
            this.Marker.Name = "Marker";
            this.Marker.Width = 50;
            // 
            // MarkerSize
            // 
            this.MarkerSize.FillWeight = 50F;
            this.MarkerSize.HeaderText = "サイズ";
            this.MarkerSize.Items.AddRange(new object[] {
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.MarkerSize.Name = "MarkerSize";
            this.MarkerSize.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.MarkerSize.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.MarkerSize.Width = 50;
            // 
            // button_Simple
            // 
            this.button_Simple.Location = new System.Drawing.Point(20, 248);
            this.button_Simple.Name = "button_Simple";
            this.button_Simple.Size = new System.Drawing.Size(152, 24);
            this.button_Simple.TabIndex = 10;
            this.button_Simple.Text = "簡易設定(&D)";
            this.button_Simple.UseVisualStyleBackColor = true;
            this.button_Simple.Click += new System.EventHandler(this.button_Simple_Click);
            // 
            // panel_Simple
            // 
            this.panel_Simple.Controls.Add(this.label1);
            this.panel_Simple.Controls.Add(this.comboBox_Series);
            this.panel_Simple.Controls.Add(this.groupBox1);
            this.panel_Simple.Location = new System.Drawing.Point(2, -1);
            this.panel_Simple.Name = "panel_Simple";
            this.panel_Simple.Size = new System.Drawing.Size(363, 294);
            this.panel_Simple.TabIndex = 11;
            // 
            // panel_Detail
            // 
            this.panel_Detail.Controls.Add(this.button_Simple);
            this.panel_Detail.Controls.Add(this.dataGridView1);
            this.panel_Detail.Location = new System.Drawing.Point(2, 2);
            this.panel_Detail.Name = "panel_Detail";
            this.panel_Detail.Size = new System.Drawing.Size(814, 290);
            this.panel_Detail.TabIndex = 12;
            this.panel_Detail.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button_OK);
            this.panel1.Controls.Add(this.button_Cancel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 297);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(375, 48);
            this.panel1.TabIndex = 13;
            // 
            // PlotSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 345);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel_Detail);
            this.Controls.Add(this.panel_Simple);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PlotSettings";
            this.Text = "データ系列の書式設定";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox_MarkerSettings.ResumeLayout(false);
            this.groupBox_MarkerSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_markerSize)).EndInit();
            this.groupBox_AxisSelect.ResumeLayout(false);
            this.groupBox_AxisSelect.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel_Simple.ResumeLayout(false);
            this.panel_Simple.PerformLayout();
            this.panel_Detail.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_Series;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBox_Port;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_ChartType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox_MarkerSettings;
        private System.Windows.Forms.ComboBox comboBox_markerStyle;
        private System.Windows.Forms.RadioButton radioButton_custom;
        private System.Windows.Forms.RadioButton radioButton_none;
        private System.Windows.Forms.RadioButton radioButton_default;
        private System.Windows.Forms.GroupBox groupBox_AxisSelect;
        private System.Windows.Forms.RadioButton radioButton_SubAxis;
        private System.Windows.Forms.RadioButton radioButton_MainAxis;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDown_markerSize;
        private System.Windows.Forms.Button button_OK;
        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button_Detail;
        private System.Windows.Forms.Button button_Simple;
        private System.Windows.Forms.Panel panel_Simple;
        private System.Windows.Forms.Panel panel_Detail;
        private System.Windows.Forms.DataGridViewTextBoxColumn Series;
        private System.Windows.Forms.DataGridViewComboBoxColumn COM;
        private System.Windows.Forms.DataGridViewTextBoxColumn Label;
        private System.Windows.Forms.DataGridViewTextBoxColumn Splitter;
        private System.Windows.Forms.DataGridViewComboBoxColumn ChartType;
        private System.Windows.Forms.DataGridViewTextBoxColumn a;
        private System.Windows.Forms.DataGridViewTextBoxColumn b;
        private System.Windows.Forms.DataGridViewComboBoxColumn YAxisType;
        private System.Windows.Forms.DataGridViewComboBoxColumn Marker;
        private System.Windows.Forms.DataGridViewComboBoxColumn MarkerSize;
        private System.Windows.Forms.Panel panel1;
    }
}