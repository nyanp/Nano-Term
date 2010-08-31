namespace NanoTerm
{
    partial class MainForm
    {
        /// <summary>
        /// 必要なデザイナ変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナで生成されたコード

        /// <summary>
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディタで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.label = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.statusStrip2 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage_graph1 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button_paramSave = new System.Windows.Forms.Button();
            this.button_paramLoad = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button_Wizard = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button_AddGraph = new System.Windows.Forms.Button();
            this.textBox_Graph_b = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox_Graph_Port = new System.Windows.Forms.ComboBox();
            this.textBox_Graph_Name = new System.Windows.Forms.TextBox();
            this.textBox_Graph_a = new System.Windows.Forms.TextBox();
            this.checkBox_Graph_SecondaryAxis = new System.Windows.Forms.CheckBox();
            this.textBox_Graph_Label = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox_Graph_Type = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button_deleteAll = new System.Windows.Forms.Button();
            this.checkBox_deleteFromDataList = new System.Windows.Forms.CheckBox();
            this.button_delete = new System.Windows.Forms.Button();
            this.comboBox_deleteList = new System.Windows.Forms.ComboBox();
            this.tabPage_graph2 = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.comboBox_graph_x_from = new System.Windows.Forms.ComboBox();
            this.textBox_graph_x_from = new System.Windows.Forms.TextBox();
            this.radioButton_graph_x_from = new System.Windows.Forms.RadioButton();
            this.radioButton_graph_all_fromnow = new System.Windows.Forms.RadioButton();
            this.radioButton_graph_x_all = new System.Windows.Forms.RadioButton();
            this.button_graph_xrange_update = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.button_saveImage = new System.Windows.Forms.Button();
            this.button_saveClipboard = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dataGridView_Series = new System.Windows.Forms.DataGridView();
            this.Delete = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Series = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button_graph_allview = new System.Windows.Forms.Button();
            this.button_graph_allhide = new System.Windows.Forms.Button();
            this.button_seriesview_update = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.contextMenuStrip_SetGraph = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItem_GraphSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.グラフの書式設定ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.statusStrip3 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox_ManualSave = new System.Windows.Forms.GroupBox();
            this.button_savecsv = new System.Windows.Forms.Button();
            this.checkBox_saveDeletedData = new System.Windows.Forms.CheckBox();
            this.groupbox_autoSave = new System.Windows.Forms.GroupBox();
            this.panel_ListAutoSave = new System.Windows.Forms.Panel();
            this.checkBox_ListAutoSave_SaveImage = new System.Windows.Forms.CheckBox();
            this.button_ListAutoSave_SelectFolder = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox_ListAutoSave_Folder = new System.Windows.Forms.TextBox();
            this.button_setAutoSave = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_ListAutoSave_FileName = new System.Windows.Forms.TextBox();
            this.textBox_ListAutoSave_LogLength = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.checkBox_ListAutoSave = new System.Windows.Forms.CheckBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.時刻 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.経過時間 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip_SetBaudRate = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItem_BaudRate = new System.Windows.Forms.ToolStripMenuItem();
            this.bpsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bpsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.bpsToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.bpsToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.bpsToolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.bpsToolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.bpsToolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_SendTiming = new System.Windows.Forms.ToolStripMenuItem();
            this.DelimiterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SoonSendToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Delimiter = new System.Windows.Forms.ToolStripMenuItem();
            this.cRToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cRLFrnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BinModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.表示フォントの変更ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.接続CToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.再接続RToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ポートを閉じるDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存SToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.ファイル送信FToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.終了ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.設定SToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.基本設定EToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.設定の初期化ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripMenuItem_Dummydata = new System.Windows.Forms.ToolStripMenuItem();
            this.系列の追加ウィザードToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.フォントの設定ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.デフォルトフォントに戻すGToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ヘルプToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.目次HToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.バージョン情報AToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ショートカットの表示SToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.saveFileDialog_csv = new System.Windows.Forms.SaveFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.saveFileDialog_saveImage = new System.Windows.Forms.SaveFileDialog();
            this.saveFileDialog_saveXML = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog_readXML = new System.Windows.Forms.OpenFileDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.statusStrip2.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage_graph1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabPage_graph2.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Series)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.contextMenuStrip_SetGraph.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.statusStrip3.SuspendLayout();
            this.groupBox_ManualSave.SuspendLayout();
            this.groupbox_autoSave.SuspendLayout();
            this.panel_ListAutoSave.SuspendLayout();
            this.contextMenuStrip_SetBaudRate.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tabControl1.HotTrack = true;
            this.tabControl1.Location = new System.Drawing.Point(0, 29);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(799, 620);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 1;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            this.tabControl1.TabIndexChanged += new System.EventHandler(this.tabControl1_TabIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.statusStrip1);
            this.tabPage1.Location = new System.Drawing.Point(4, 21);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(791, 595);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "シリアルポート";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.label});
            this.statusStrip1.Location = new System.Drawing.Point(3, 569);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(785, 23);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // label
            // 
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(134, 18);
            this.label.Text = "toolStripStatusLabel1";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel3);
            this.tabPage2.Controls.Add(this.chart1);
            this.tabPage2.Location = new System.Drawing.Point(4, 21);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(791, 595);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "グラフ";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.statusStrip2);
            this.panel3.Controls.Add(this.tabControl2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(3, 417);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(785, 175);
            this.panel3.TabIndex = 7;
            // 
            // statusStrip2
            // 
            this.statusStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel4,
            this.toolStripStatusLabel2});
            this.statusStrip2.Location = new System.Drawing.Point(0, 152);
            this.statusStrip2.Name = "statusStrip2";
            this.statusStrip2.Size = new System.Drawing.Size(785, 23);
            this.statusStrip2.TabIndex = 12;
            this.statusStrip2.Text = "statusStrip2";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 18);
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(0, 18);
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(13, 18);
            this.toolStripStatusLabel4.Text = "|";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(134, 18);
            this.toolStripStatusLabel2.Text = "toolStripStatusLabel2";
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage_graph1);
            this.tabControl2.Controls.Add(this.tabPage_graph2);
            this.tabControl2.Location = new System.Drawing.Point(0, 3);
            this.tabControl2.Multiline = true;
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(785, 147);
            this.tabControl2.TabIndex = 6;
            // 
            // tabPage_graph1
            // 
            this.tabPage_graph1.Controls.Add(this.panel1);
            this.tabPage_graph1.Location = new System.Drawing.Point(4, 21);
            this.tabPage_graph1.Name = "tabPage_graph1";
            this.tabPage_graph1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_graph1.Size = new System.Drawing.Size(777, 122);
            this.tabPage_graph1.TabIndex = 0;
            this.tabPage_graph1.Text = "データ系列";
            this.tabPage_graph1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Location = new System.Drawing.Point(6, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(772, 120);
            this.panel1.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button_paramSave);
            this.groupBox1.Controls.Add(this.button_paramLoad);
            this.groupBox1.Location = new System.Drawing.Point(604, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(161, 111);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "設定ファイル";
            // 
            // button_paramSave
            // 
            this.button_paramSave.AllowDrop = true;
            this.button_paramSave.Location = new System.Drawing.Point(6, 16);
            this.button_paramSave.Name = "button_paramSave";
            this.button_paramSave.Size = new System.Drawing.Size(148, 40);
            this.button_paramSave.TabIndex = 20;
            this.button_paramSave.Text = "設定の保存(&W)";
            this.toolTip1.SetToolTip(this.button_paramSave, "グラフ設定をXMLファイルとして保存し、次回以降に呼び出せるようにします。");
            this.button_paramSave.UseVisualStyleBackColor = true;
            this.button_paramSave.Click += new System.EventHandler(this.button_paramSave_Click);
            // 
            // button_paramLoad
            // 
            this.button_paramLoad.AllowDrop = true;
            this.button_paramLoad.Location = new System.Drawing.Point(6, 65);
            this.button_paramLoad.Name = "button_paramLoad";
            this.button_paramLoad.Size = new System.Drawing.Size(148, 41);
            this.button_paramLoad.TabIndex = 21;
            this.button_paramLoad.Text = "設定の読み込み(&R)";
            this.toolTip1.SetToolTip(this.button_paramLoad, "XML形式の設定ファイルを読み込み、グラフ設定を行います。");
            this.button_paramLoad.UseVisualStyleBackColor = true;
            this.button_paramLoad.Click += new System.EventHandler(this.button_paramLoad_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.button_Wizard);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.button_AddGraph);
            this.groupBox3.Controls.Add(this.textBox_Graph_b);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.comboBox_Graph_Port);
            this.groupBox3.Controls.Add(this.textBox_Graph_Name);
            this.groupBox3.Controls.Add(this.textBox_Graph_a);
            this.groupBox3.Controls.Add(this.checkBox_Graph_SecondaryAxis);
            this.groupBox3.Controls.Add(this.textBox_Graph_Label);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.comboBox_Graph_Type);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(411, 112);
            this.groupBox3.TabIndex = 19;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "系列の追加";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(196, 70);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 12);
            this.label6.TabIndex = 14;
            this.label6.Text = "x+";
            // 
            // button_Wizard
            // 
            this.button_Wizard.Location = new System.Drawing.Point(191, 90);
            this.button_Wizard.Name = "button_Wizard";
            this.button_Wizard.Size = new System.Drawing.Size(214, 21);
            this.button_Wizard.TabIndex = 8;
            this.button_Wizard.Text = "系列の追加ウィザードを起動(&W)";
            this.toolTip1.SetToolTip(this.button_Wizard, "より高度な設定が可能なセットアップウィザードを起動します。");
            this.button_Wizard.UseVisualStyleBackColor = true;
            this.button_Wizard.Click += new System.EventHandler(this.button_Wizard_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "ポート";
            // 
            // button_AddGraph
            // 
            this.button_AddGraph.Location = new System.Drawing.Point(278, 65);
            this.button_AddGraph.Name = "button_AddGraph";
            this.button_AddGraph.Size = new System.Drawing.Size(127, 21);
            this.button_AddGraph.TabIndex = 7;
            this.button_AddGraph.Text = "追加(&A)";
            this.toolTip1.SetToolTip(this.button_AddGraph, "指定した設定でグラフに系列を追加します。");
            this.button_AddGraph.UseVisualStyleBackColor = true;
            this.button_AddGraph.Click += new System.EventHandler(this.button_AddGraph_Click);
            // 
            // textBox_Graph_b
            // 
            this.textBox_Graph_b.Location = new System.Drawing.Point(215, 67);
            this.textBox_Graph_b.MaxLength = 6;
            this.textBox_Graph_b.Name = "textBox_Graph_b";
            this.textBox_Graph_b.Size = new System.Drawing.Size(49, 19);
            this.textBox_Graph_b.TabIndex = 6;
            this.textBox_Graph_b.Text = "0";
            this.textBox_Graph_b.MouseLeave += new System.EventHandler(this.textBox_Graph_b_MouseLeave);
            this.textBox_Graph_b.MouseHover += new System.EventHandler(this.textBox_Graph_b_MouseHover);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(133, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "表示値→物理値変換  y=";
            // 
            // comboBox_Graph_Port
            // 
            this.comboBox_Graph_Port.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Graph_Port.FormattingEnabled = true;
            this.comboBox_Graph_Port.Location = new System.Drawing.Point(62, 19);
            this.comboBox_Graph_Port.Name = "comboBox_Graph_Port";
            this.comboBox_Graph_Port.Size = new System.Drawing.Size(89, 20);
            this.comboBox_Graph_Port.TabIndex = 0;
            this.toolTip1.SetToolTip(this.comboBox_Graph_Port, "データソースとなるCOMポートを選択します。");
            this.comboBox_Graph_Port.MouseLeave += new System.EventHandler(this.comboBox_Graph_Port_MouseLeave);
            this.comboBox_Graph_Port.MouseHover += new System.EventHandler(this.comboBox_Graph_Port_MouseHover);
            // 
            // textBox_Graph_Name
            // 
            this.textBox_Graph_Name.Location = new System.Drawing.Point(324, 11);
            this.textBox_Graph_Name.MaxLength = 20;
            this.textBox_Graph_Name.Name = "textBox_Graph_Name";
            this.textBox_Graph_Name.Size = new System.Drawing.Size(77, 19);
            this.textBox_Graph_Name.TabIndex = 3;
            this.toolTip1.SetToolTip(this.textBox_Graph_Name, "グラフに表示される系列の名前を入力します。");
            this.textBox_Graph_Name.MouseLeave += new System.EventHandler(this.textBox_Graph_Name_MouseLeave);
            this.textBox_Graph_Name.MouseHover += new System.EventHandler(this.textBox_Graph_Name_MouseHover);
            // 
            // textBox_Graph_a
            // 
            this.textBox_Graph_a.Location = new System.Drawing.Point(142, 67);
            this.textBox_Graph_a.MaxLength = 6;
            this.textBox_Graph_a.Name = "textBox_Graph_a";
            this.textBox_Graph_a.Size = new System.Drawing.Size(53, 19);
            this.textBox_Graph_a.TabIndex = 5;
            this.textBox_Graph_a.Text = "1";
            this.textBox_Graph_a.MouseLeave += new System.EventHandler(this.textBox_Graph_a_MouseLeave);
            this.textBox_Graph_a.MouseHover += new System.EventHandler(this.textBox_Graph_a_MouseHover);
            // 
            // checkBox_Graph_SecondaryAxis
            // 
            this.checkBox_Graph_SecondaryAxis.AutoSize = true;
            this.checkBox_Graph_SecondaryAxis.Location = new System.Drawing.Point(157, 20);
            this.checkBox_Graph_SecondaryAxis.Name = "checkBox_Graph_SecondaryAxis";
            this.checkBox_Graph_SecondaryAxis.Size = new System.Drawing.Size(84, 16);
            this.checkBox_Graph_SecondaryAxis.TabIndex = 1;
            this.checkBox_Graph_SecondaryAxis.Text = "第2y軸使用";
            this.checkBox_Graph_SecondaryAxis.UseVisualStyleBackColor = true;
            // 
            // textBox_Graph_Label
            // 
            this.textBox_Graph_Label.Location = new System.Drawing.Point(324, 37);
            this.textBox_Graph_Label.MaxLength = 20;
            this.textBox_Graph_Label.Name = "textBox_Graph_Label";
            this.textBox_Graph_Label.Size = new System.Drawing.Size(77, 19);
            this.textBox_Graph_Label.TabIndex = 4;
            this.toolTip1.SetToolTip(this.textBox_Graph_Label, "データの抽出に使用するための文字または正規表現を入力します。たとえば「V:324 T:255」という受信文字からVの値を取り出したい場合は「V」を入力します。詳細" +
                    "はヘルプを参照下さい。");
            this.textBox_Graph_Label.MouseLeave += new System.EventHandler(this.textBox_Graph_Label_MouseLeave);
            this.textBox_Graph_Label.MouseHover += new System.EventHandler(this.textBox_Graph_Label_MouseHover);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(263, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "系列名";
            // 
            // comboBox_Graph_Type
            // 
            this.comboBox_Graph_Type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Graph_Type.FormattingEnabled = true;
            this.comboBox_Graph_Type.Items.AddRange(new object[] {
            "散布図",
            "折れ線（マーカーなし）",
            "折れ線（マーカー有り）"});
            this.comboBox_Graph_Type.Location = new System.Drawing.Point(62, 42);
            this.comboBox_Graph_Type.Name = "comboBox_Graph_Type";
            this.comboBox_Graph_Type.Size = new System.Drawing.Size(156, 20);
            this.comboBox_Graph_Type.TabIndex = 2;
            this.toolTip1.SetToolTip(this.comboBox_Graph_Type, "グラフの形式を選択します。");
            this.comboBox_Graph_Type.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.comboBox_Graph_Type_DrawItem);
            this.comboBox_Graph_Type.MouseLeave += new System.EventHandler(this.comboBox_Graph_Type_MouseLeave);
            this.comboBox_Graph_Type.MouseHover += new System.EventHandler(this.comboBox_Graph_Type_MouseHover);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "グラフ形式";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(263, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "ラベル";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button_deleteAll);
            this.groupBox2.Controls.Add(this.checkBox_deleteFromDataList);
            this.groupBox2.Controls.Add(this.button_delete);
            this.groupBox2.Controls.Add(this.comboBox_deleteList);
            this.groupBox2.Location = new System.Drawing.Point(420, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(178, 112);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "系列の削除";
            // 
            // button_deleteAll
            // 
            this.button_deleteAll.AllowDrop = true;
            this.button_deleteAll.Location = new System.Drawing.Point(16, 84);
            this.button_deleteAll.Name = "button_deleteAll";
            this.button_deleteAll.Size = new System.Drawing.Size(146, 22);
            this.button_deleteAll.TabIndex = 11;
            this.button_deleteAll.Text = "全系列を削除(&Z)";
            this.toolTip1.SetToolTip(this.button_deleteAll, "すべての系列を削除します。");
            this.button_deleteAll.UseVisualStyleBackColor = true;
            this.button_deleteAll.Click += new System.EventHandler(this.button_deleteAll_Click);
            // 
            // checkBox_deleteFromDataList
            // 
            this.checkBox_deleteFromDataList.AutoSize = true;
            this.checkBox_deleteFromDataList.Checked = true;
            this.checkBox_deleteFromDataList.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_deleteFromDataList.Location = new System.Drawing.Point(16, 44);
            this.checkBox_deleteFromDataList.Name = "checkBox_deleteFromDataList";
            this.checkBox_deleteFromDataList.Size = new System.Drawing.Size(127, 16);
            this.checkBox_deleteFromDataList.TabIndex = 9;
            this.checkBox_deleteFromDataList.Text = "データリストからも削除";
            this.toolTip1.SetToolTip(this.checkBox_deleteFromDataList, "「データリスト」タブからも指定した系列を削除します。");
            this.checkBox_deleteFromDataList.UseVisualStyleBackColor = true;
            // 
            // button_delete
            // 
            this.button_delete.AllowDrop = true;
            this.button_delete.Location = new System.Drawing.Point(16, 60);
            this.button_delete.Name = "button_delete";
            this.button_delete.Size = new System.Drawing.Size(146, 22);
            this.button_delete.TabIndex = 10;
            this.button_delete.Text = "削除(&X)";
            this.toolTip1.SetToolTip(this.button_delete, "選択された系列を削除します。");
            this.button_delete.UseVisualStyleBackColor = true;
            this.button_delete.Click += new System.EventHandler(this.button_delete_Click);
            // 
            // comboBox_deleteList
            // 
            this.comboBox_deleteList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_deleteList.FormattingEnabled = true;
            this.comboBox_deleteList.Location = new System.Drawing.Point(16, 18);
            this.comboBox_deleteList.Name = "comboBox_deleteList";
            this.comboBox_deleteList.Size = new System.Drawing.Size(146, 20);
            this.comboBox_deleteList.TabIndex = 8;
            this.toolTip1.SetToolTip(this.comboBox_deleteList, "削除するデータ系列を選択します。");
            // 
            // tabPage_graph2
            // 
            this.tabPage_graph2.Controls.Add(this.groupBox6);
            this.tabPage_graph2.Controls.Add(this.groupBox5);
            this.tabPage_graph2.Controls.Add(this.groupBox4);
            this.tabPage_graph2.Location = new System.Drawing.Point(4, 21);
            this.tabPage_graph2.Name = "tabPage_graph2";
            this.tabPage_graph2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_graph2.Size = new System.Drawing.Size(777, 122);
            this.tabPage_graph2.TabIndex = 1;
            this.tabPage_graph2.Text = "データの表示と保存";
            this.tabPage_graph2.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label10);
            this.groupBox6.Controls.Add(this.comboBox_graph_x_from);
            this.groupBox6.Controls.Add(this.textBox_graph_x_from);
            this.groupBox6.Controls.Add(this.radioButton_graph_x_from);
            this.groupBox6.Controls.Add(this.radioButton_graph_all_fromnow);
            this.groupBox6.Controls.Add(this.radioButton_graph_x_all);
            this.groupBox6.Controls.Add(this.button_graph_xrange_update);
            this.groupBox6.Location = new System.Drawing.Point(378, 3);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(223, 112);
            this.groupBox6.TabIndex = 28;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "表示範囲";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(156, 60);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(50, 12);
            this.label10.TabIndex = 33;
            this.label10.Text = "のみ表示";
            // 
            // comboBox_graph_x_from
            // 
            this.comboBox_graph_x_from.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_graph_x_from.FormattingEnabled = true;
            this.comboBox_graph_x_from.Items.AddRange(new object[] {
            "秒",
            "分",
            "時間"});
            this.comboBox_graph_x_from.Location = new System.Drawing.Point(93, 57);
            this.comboBox_graph_x_from.Name = "comboBox_graph_x_from";
            this.comboBox_graph_x_from.Size = new System.Drawing.Size(57, 20);
            this.comboBox_graph_x_from.TabIndex = 32;
            // 
            // textBox_graph_x_from
            // 
            this.textBox_graph_x_from.Location = new System.Drawing.Point(60, 57);
            this.textBox_graph_x_from.MaxLength = 4;
            this.textBox_graph_x_from.Name = "textBox_graph_x_from";
            this.textBox_graph_x_from.Size = new System.Drawing.Size(27, 19);
            this.textBox_graph_x_from.TabIndex = 31;
            this.textBox_graph_x_from.Text = "10";
            // 
            // radioButton_graph_x_from
            // 
            this.radioButton_graph_x_from.AutoSize = true;
            this.radioButton_graph_x_from.Location = new System.Drawing.Point(6, 59);
            this.radioButton_graph_x_from.Name = "radioButton_graph_x_from";
            this.radioButton_graph_x_from.Size = new System.Drawing.Size(57, 16);
            this.radioButton_graph_x_from.TabIndex = 30;
            this.radioButton_graph_x_from.TabStop = true;
            this.radioButton_graph_x_from.Text = "直近の";
            this.toolTip1.SetToolTip(this.radioButton_graph_x_from, "直近のデータのみを表示します。（データは保存されています）");
            this.radioButton_graph_x_from.UseVisualStyleBackColor = true;
            // 
            // radioButton_graph_all_fromnow
            // 
            this.radioButton_graph_all_fromnow.AutoSize = true;
            this.radioButton_graph_all_fromnow.Location = new System.Drawing.Point(6, 37);
            this.radioButton_graph_all_fromnow.Name = "radioButton_graph_all_fromnow";
            this.radioButton_graph_all_fromnow.Size = new System.Drawing.Size(104, 16);
            this.radioButton_graph_all_fromnow.TabIndex = 29;
            this.radioButton_graph_all_fromnow.TabStop = true;
            this.radioButton_graph_all_fromnow.Text = "現在以降を表示";
            this.toolTip1.SetToolTip(this.radioButton_graph_all_fromnow, "X軸原点を現在時刻とし、現在以降のデータのみプロットします。（データは保存されています）");
            this.radioButton_graph_all_fromnow.UseVisualStyleBackColor = true;
            // 
            // radioButton_graph_x_all
            // 
            this.radioButton_graph_x_all.AutoSize = true;
            this.radioButton_graph_x_all.Location = new System.Drawing.Point(6, 15);
            this.radioButton_graph_x_all.Name = "radioButton_graph_x_all";
            this.radioButton_graph_x_all.Size = new System.Drawing.Size(96, 16);
            this.radioButton_graph_x_all.TabIndex = 28;
            this.radioButton_graph_x_all.TabStop = true;
            this.radioButton_graph_x_all.Text = "全データを表示";
            this.toolTip1.SetToolTip(this.radioButton_graph_x_all, "取得開始時点からの全データをプロットします。");
            this.radioButton_graph_x_all.UseVisualStyleBackColor = true;
            // 
            // button_graph_xrange_update
            // 
            this.button_graph_xrange_update.Location = new System.Drawing.Point(6, 84);
            this.button_graph_xrange_update.Name = "button_graph_xrange_update";
            this.button_graph_xrange_update.Size = new System.Drawing.Size(104, 27);
            this.button_graph_xrange_update.TabIndex = 27;
            this.button_graph_xrange_update.Text = "更新";
            this.toolTip1.SetToolTip(this.button_graph_xrange_update, "指定した設定でグラフのX軸を再設定します。");
            this.button_graph_xrange_update.UseVisualStyleBackColor = true;
            this.button_graph_xrange_update.Click += new System.EventHandler(this.button_graph_xrange_update_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.button_saveImage);
            this.groupBox5.Controls.Add(this.button_saveClipboard);
            this.groupBox5.Location = new System.Drawing.Point(610, 2);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(161, 112);
            this.groupBox5.TabIndex = 27;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "グラフの保存";
            // 
            // button_saveImage
            // 
            this.button_saveImage.AllowDrop = true;
            this.button_saveImage.Location = new System.Drawing.Point(6, 14);
            this.button_saveImage.Name = "button_saveImage";
            this.button_saveImage.Size = new System.Drawing.Size(153, 45);
            this.button_saveImage.TabIndex = 15;
            this.button_saveImage.Text = "グラフを画像として保存(&S)";
            this.toolTip1.SetToolTip(this.button_saveImage, "表示されているグラフを、ビットマップ形式で保存します。");
            this.button_saveImage.UseVisualStyleBackColor = true;
            this.button_saveImage.Click += new System.EventHandler(this.button_saveImage_Click);
            // 
            // button_saveClipboard
            // 
            this.button_saveClipboard.AllowDrop = true;
            this.button_saveClipboard.Location = new System.Drawing.Point(6, 66);
            this.button_saveClipboard.Name = "button_saveClipboard";
            this.button_saveClipboard.Size = new System.Drawing.Size(153, 42);
            this.button_saveClipboard.TabIndex = 16;
            this.button_saveClipboard.Text = "クリップボードにコピー(&C)";
            this.toolTip1.SetToolTip(this.button_saveClipboard, "表示されている画像をクリップボードにコピーします。");
            this.button_saveClipboard.UseVisualStyleBackColor = true;
            this.button_saveClipboard.Click += new System.EventHandler(this.button_saveClipboard_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dataGridView_Series);
            this.groupBox4.Controls.Add(this.button_graph_allview);
            this.groupBox4.Controls.Add(this.button_graph_allhide);
            this.groupBox4.Controls.Add(this.button_seriesview_update);
            this.groupBox4.Location = new System.Drawing.Point(7, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(365, 112);
            this.groupBox4.TabIndex = 26;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "データ系列の表示/非表示";
            // 
            // dataGridView_Series
            // 
            this.dataGridView_Series.AllowUserToAddRows = false;
            this.dataGridView_Series.AllowUserToDeleteRows = false;
            this.dataGridView_Series.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Series.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Delete,
            this.Series});
            this.dataGridView_Series.Location = new System.Drawing.Point(6, 15);
            this.dataGridView_Series.Name = "dataGridView_Series";
            this.dataGridView_Series.RowTemplate.Height = 21;
            this.dataGridView_Series.Size = new System.Drawing.Size(212, 98);
            this.dataGridView_Series.TabIndex = 22;
            // 
            // Delete
            // 
            this.Delete.FillWeight = 60F;
            this.Delete.HeaderText = "表示";
            this.Delete.Name = "Delete";
            this.Delete.Width = 60;
            // 
            // Series
            // 
            this.Series.HeaderText = "系列";
            this.Series.Name = "Series";
            this.Series.ReadOnly = true;
            // 
            // button_graph_allview
            // 
            this.button_graph_allview.Location = new System.Drawing.Point(224, 23);
            this.button_graph_allview.Name = "button_graph_allview";
            this.button_graph_allview.Size = new System.Drawing.Size(131, 27);
            this.button_graph_allview.TabIndex = 25;
            this.button_graph_allview.Text = "すべて表示";
            this.toolTip1.SetToolTip(this.button_graph_allview, "全系列をチェックします。");
            this.button_graph_allview.UseVisualStyleBackColor = true;
            this.button_graph_allview.Click += new System.EventHandler(this.button_graph_allview_Click);
            // 
            // button_graph_allhide
            // 
            this.button_graph_allhide.Location = new System.Drawing.Point(224, 53);
            this.button_graph_allhide.Name = "button_graph_allhide";
            this.button_graph_allhide.Size = new System.Drawing.Size(131, 27);
            this.button_graph_allhide.TabIndex = 24;
            this.button_graph_allhide.Text = "すべて非表示";
            this.toolTip1.SetToolTip(this.button_graph_allhide, "全系列のチェックをはずします。");
            this.button_graph_allhide.UseVisualStyleBackColor = true;
            this.button_graph_allhide.Click += new System.EventHandler(this.button_graph_allhide_Click);
            // 
            // button_seriesview_update
            // 
            this.button_seriesview_update.Location = new System.Drawing.Point(224, 84);
            this.button_seriesview_update.Name = "button_seriesview_update";
            this.button_seriesview_update.Size = new System.Drawing.Size(131, 27);
            this.button_seriesview_update.TabIndex = 23;
            this.button_seriesview_update.Text = "更新";
            this.toolTip1.SetToolTip(this.button_seriesview_update, "チェックされた系列のみを用いてグラフを再描画します。");
            this.button_seriesview_update.UseVisualStyleBackColor = true;
            this.button_seriesview_update.Click += new System.EventHandler(this.button_seriesview_update_Click);
            // 
            // chart1
            // 
            chartArea1.AxisX.LabelStyle.Format = "MM/dd HH:mm:ss.FF";
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.ContextMenuStrip = this.contextMenuStrip_SetGraph;
            this.chart1.Dock = System.Windows.Forms.DockStyle.Top;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(3, 3);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(785, 411);
            this.chart1.TabIndex = 3;
            this.chart1.Text = "chart1";
            // 
            // contextMenuStrip_SetGraph
            // 
            this.contextMenuStrip_SetGraph.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_GraphSettings,
            this.グラフの書式設定ToolStripMenuItem});
            this.contextMenuStrip_SetGraph.Name = "contextMenuStrip_SetGraph";
            this.contextMenuStrip_SetGraph.Size = new System.Drawing.Size(197, 48);
            // 
            // ToolStripMenuItem_GraphSettings
            // 
            this.ToolStripMenuItem_GraphSettings.Name = "ToolStripMenuItem_GraphSettings";
            this.ToolStripMenuItem_GraphSettings.Size = new System.Drawing.Size(196, 22);
            this.ToolStripMenuItem_GraphSettings.Text = "データ系列の書式設定";
            this.ToolStripMenuItem_GraphSettings.Click += new System.EventHandler(this.ToolStripMenuItem_GraphSettings_Click);
            // 
            // グラフの書式設定ToolStripMenuItem
            // 
            this.グラフの書式設定ToolStripMenuItem.Name = "グラフの書式設定ToolStripMenuItem";
            this.グラフの書式設定ToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.グラフの書式設定ToolStripMenuItem.Text = "グラフの書式設定";
            this.グラフの書式設定ToolStripMenuItem.Click += new System.EventHandler(this.グラフの書式設定ToolStripMenuItem_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.panel2);
            this.tabPage3.Controls.Add(this.listView1);
            this.tabPage3.Location = new System.Drawing.Point(4, 21);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(791, 595);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "データリスト";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.statusStrip3);
            this.panel2.Controls.Add(this.groupBox_ManualSave);
            this.panel2.Controls.Add(this.groupbox_autoSave);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 473);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(791, 122);
            this.panel2.TabIndex = 4;
            // 
            // statusStrip3
            // 
            this.statusStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel5});
            this.statusStrip3.Location = new System.Drawing.Point(0, 99);
            this.statusStrip3.Name = "statusStrip3";
            this.statusStrip3.Size = new System.Drawing.Size(791, 23);
            this.statusStrip3.TabIndex = 6;
            this.statusStrip3.Text = "statusStrip3";
            // 
            // toolStripStatusLabel5
            // 
            this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            this.toolStripStatusLabel5.Size = new System.Drawing.Size(134, 18);
            this.toolStripStatusLabel5.Text = "toolStripStatusLabel5";
            // 
            // groupBox_ManualSave
            // 
            this.groupBox_ManualSave.Controls.Add(this.button_savecsv);
            this.groupBox_ManualSave.Controls.Add(this.checkBox_saveDeletedData);
            this.groupBox_ManualSave.Location = new System.Drawing.Point(634, 4);
            this.groupBox_ManualSave.Name = "groupBox_ManualSave";
            this.groupBox_ManualSave.Size = new System.Drawing.Size(147, 92);
            this.groupBox_ManualSave.TabIndex = 5;
            this.groupBox_ManualSave.TabStop = false;
            this.groupBox_ManualSave.Text = "マニュアル保存";
            // 
            // button_savecsv
            // 
            this.button_savecsv.Location = new System.Drawing.Point(6, 40);
            this.button_savecsv.Name = "button_savecsv";
            this.button_savecsv.Size = new System.Drawing.Size(133, 46);
            this.button_savecsv.TabIndex = 6;
            this.button_savecsv.Text = "CSVで保存(&S)";
            this.toolTip1.SetToolTip(this.button_savecsv, "マニュアルで現在表示されているすべてのデータを保存します。");
            this.button_savecsv.UseVisualStyleBackColor = true;
            this.button_savecsv.Click += new System.EventHandler(this.button_savecsv_Click);
            // 
            // checkBox_saveDeletedData
            // 
            this.checkBox_saveDeletedData.AutoSize = true;
            this.checkBox_saveDeletedData.Location = new System.Drawing.Point(6, 18);
            this.checkBox_saveDeletedData.Name = "checkBox_saveDeletedData";
            this.checkBox_saveDeletedData.Size = new System.Drawing.Size(133, 16);
            this.checkBox_saveDeletedData.TabIndex = 5;
            this.checkBox_saveDeletedData.Text = "削除された系列も保存";
            this.toolTip1.SetToolTip(this.checkBox_saveDeletedData, "現在表示されていない、削除された系列もCSVに書き出します。");
            this.checkBox_saveDeletedData.UseVisualStyleBackColor = true;
            // 
            // groupbox_autoSave
            // 
            this.groupbox_autoSave.Controls.Add(this.panel_ListAutoSave);
            this.groupbox_autoSave.Controls.Add(this.checkBox_ListAutoSave);
            this.groupbox_autoSave.Location = new System.Drawing.Point(3, 3);
            this.groupbox_autoSave.Name = "groupbox_autoSave";
            this.groupbox_autoSave.Size = new System.Drawing.Size(625, 92);
            this.groupbox_autoSave.TabIndex = 4;
            this.groupbox_autoSave.TabStop = false;
            this.groupbox_autoSave.Text = "自動保存";
            // 
            // panel_ListAutoSave
            // 
            this.panel_ListAutoSave.Controls.Add(this.checkBox_ListAutoSave_SaveImage);
            this.panel_ListAutoSave.Controls.Add(this.button_ListAutoSave_SelectFolder);
            this.panel_ListAutoSave.Controls.Add(this.label9);
            this.panel_ListAutoSave.Controls.Add(this.textBox_ListAutoSave_Folder);
            this.panel_ListAutoSave.Controls.Add(this.button_setAutoSave);
            this.panel_ListAutoSave.Controls.Add(this.label7);
            this.panel_ListAutoSave.Controls.Add(this.textBox_ListAutoSave_FileName);
            this.panel_ListAutoSave.Controls.Add(this.textBox_ListAutoSave_LogLength);
            this.panel_ListAutoSave.Controls.Add(this.label8);
            this.panel_ListAutoSave.Enabled = false;
            this.panel_ListAutoSave.Location = new System.Drawing.Point(6, 33);
            this.panel_ListAutoSave.Name = "panel_ListAutoSave";
            this.panel_ListAutoSave.Size = new System.Drawing.Size(613, 59);
            this.panel_ListAutoSave.TabIndex = 12;
            // 
            // checkBox_ListAutoSave_SaveImage
            // 
            this.checkBox_ListAutoSave_SaveImage.AutoSize = true;
            this.checkBox_ListAutoSave_SaveImage.Location = new System.Drawing.Point(471, 10);
            this.checkBox_ListAutoSave_SaveImage.Name = "checkBox_ListAutoSave_SaveImage";
            this.checkBox_ListAutoSave_SaveImage.Size = new System.Drawing.Size(139, 16);
            this.checkBox_ListAutoSave_SaveImage.TabIndex = 12;
            this.checkBox_ListAutoSave_SaveImage.Text = "グラフ画像も同時に保存";
            this.toolTip1.SetToolTip(this.checkBox_ListAutoSave_SaveImage, "CSVファイルを保存するタイミングで、グラフのキャプチャ画像も取得します。");
            this.checkBox_ListAutoSave_SaveImage.UseVisualStyleBackColor = true;
            // 
            // button_ListAutoSave_SelectFolder
            // 
            this.button_ListAutoSave_SelectFolder.Location = new System.Drawing.Point(462, 32);
            this.button_ListAutoSave_SelectFolder.Name = "button_ListAutoSave_SelectFolder";
            this.button_ListAutoSave_SelectFolder.Size = new System.Drawing.Size(24, 23);
            this.button_ListAutoSave_SelectFolder.TabIndex = 3;
            this.button_ListAutoSave_SelectFolder.Text = "...";
            this.toolTip1.SetToolTip(this.button_ListAutoSave_SelectFolder, "保存先フォルダを指定します。");
            this.button_ListAutoSave_SelectFolder.UseVisualStyleBackColor = true;
            this.button_ListAutoSave_SelectFolder.Click += new System.EventHandler(this.button_ListAutoSave_SelectFolder_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(180, 12);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 12);
            this.label9.TabIndex = 11;
            this.label9.Text = "_n(1,2...).CSV";
            // 
            // textBox_ListAutoSave_Folder
            // 
            this.textBox_ListAutoSave_Folder.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.textBox_ListAutoSave_Folder.Enabled = false;
            this.textBox_ListAutoSave_Folder.Location = new System.Drawing.Point(36, 34);
            this.textBox_ListAutoSave_Folder.Name = "textBox_ListAutoSave_Folder";
            this.textBox_ListAutoSave_Folder.Size = new System.Drawing.Size(425, 19);
            this.textBox_ListAutoSave_Folder.TabIndex = 3;
            this.textBox_ListAutoSave_Folder.TabStop = false;
            this.toolTip1.SetToolTip(this.textBox_ListAutoSave_Folder, "現在選択されているフォルダ名です。");
            // 
            // button_setAutoSave
            // 
            this.button_setAutoSave.AutoSize = true;
            this.button_setAutoSave.Location = new System.Drawing.Point(507, 32);
            this.button_setAutoSave.Name = "button_setAutoSave";
            this.button_setAutoSave.Size = new System.Drawing.Size(103, 22);
            this.button_setAutoSave.TabIndex = 4;
            this.button_setAutoSave.Text = "設定(&C)";
            this.toolTip1.SetToolTip(this.button_setAutoSave, "現在の設定で自動保存を行います。");
            this.button_setAutoSave.UseVisualStyleBackColor = true;
            this.button_setAutoSave.Click += new System.EventHandler(this.button_setAutoSave_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(326, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(135, 12);
            this.label7.TabIndex = 5;
            this.label7.Text = "行ごとに以下の場所へ保存";
            // 
            // textBox_ListAutoSave_FileName
            // 
            this.textBox_ListAutoSave_FileName.Location = new System.Drawing.Point(90, 9);
            this.textBox_ListAutoSave_FileName.MaxLength = 20;
            this.textBox_ListAutoSave_FileName.Name = "textBox_ListAutoSave_FileName";
            this.textBox_ListAutoSave_FileName.Size = new System.Drawing.Size(88, 19);
            this.textBox_ListAutoSave_FileName.TabIndex = 1;
            this.toolTip1.SetToolTip(this.textBox_ListAutoSave_FileName, "拡張子と番号を除いたファイル名を入力します。");
            // 
            // textBox_ListAutoSave_LogLength
            // 
            this.textBox_ListAutoSave_LogLength.Location = new System.Drawing.Point(254, 9);
            this.textBox_ListAutoSave_LogLength.MaxLength = 6;
            this.textBox_ListAutoSave_LogLength.Name = "textBox_ListAutoSave_LogLength";
            this.textBox_ListAutoSave_LogLength.Size = new System.Drawing.Size(51, 19);
            this.textBox_ListAutoSave_LogLength.TabIndex = 2;
            this.textBox_ListAutoSave_LogLength.Text = "65535";
            this.toolTip1.SetToolTip(this.textBox_ListAutoSave_LogLength, "指定した行数ごとに番号を変え、新しいファイルへ書き出します。");
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(34, 12);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 9;
            this.label8.Text = "ファイル名:";
            // 
            // checkBox_ListAutoSave
            // 
            this.checkBox_ListAutoSave.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.checkBox_ListAutoSave.AutoSize = true;
            this.checkBox_ListAutoSave.Location = new System.Drawing.Point(16, 18);
            this.checkBox_ListAutoSave.Name = "checkBox_ListAutoSave";
            this.checkBox_ListAutoSave.Size = new System.Drawing.Size(371, 16);
            this.checkBox_ListAutoSave.TabIndex = 0;
            this.checkBox_ListAutoSave.Text = "自動保存を有効化(保存のたびにリストとグラフ上の表示はクリアされします)";
            this.toolTip1.SetToolTip(this.checkBox_ListAutoSave, "CSVファイルへの自動書き出しを有効化します。");
            this.checkBox_ListAutoSave.UseVisualStyleBackColor = true;
            this.checkBox_ListAutoSave.CheckedChanged += new System.EventHandler(this.checkBox_ListAutoSave_CheckedChanged);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.時刻,
            this.経過時間});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Top;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(791, 467);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // 時刻
            // 
            this.時刻.Text = "時刻";
            this.時刻.Width = 140;
            // 
            // 経過時間
            // 
            this.経過時間.Text = "経過時間(ms)";
            this.経過時間.Width = 110;
            // 
            // contextMenuStrip_SetBaudRate
            // 
            this.contextMenuStrip_SetBaudRate.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_BaudRate,
            this.ToolStripMenuItem_SendTiming,
            this.ToolStripMenuItem_Delimiter,
            this.BinModeToolStripMenuItem,
            this.表示フォントの変更ToolStripMenuItem});
            this.contextMenuStrip_SetBaudRate.Name = "contextMenuStrip_SetBaudRate";
            this.contextMenuStrip_SetBaudRate.Size = new System.Drawing.Size(185, 136);
            this.contextMenuStrip_SetBaudRate.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip_SetBaudRate_Opening);
            // 
            // ToolStripMenuItem_BaudRate
            // 
            this.ToolStripMenuItem_BaudRate.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bpsToolStripMenuItem,
            this.bpsToolStripMenuItem1,
            this.bpsToolStripMenuItem2,
            this.bpsToolStripMenuItem3,
            this.bpsToolStripMenuItem4,
            this.bpsToolStripMenuItem5,
            this.bpsToolStripMenuItem6});
            this.ToolStripMenuItem_BaudRate.Name = "ToolStripMenuItem_BaudRate";
            this.ToolStripMenuItem_BaudRate.Size = new System.Drawing.Size(184, 22);
            this.ToolStripMenuItem_BaudRate.Text = "ボーレートの設定";
            // 
            // bpsToolStripMenuItem
            // 
            this.bpsToolStripMenuItem.Name = "bpsToolStripMenuItem";
            this.bpsToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.bpsToolStripMenuItem.Text = "1200Bps";
            this.bpsToolStripMenuItem.Click += new System.EventHandler(this.bpsToolStripMenuItem_Click);
            // 
            // bpsToolStripMenuItem1
            // 
            this.bpsToolStripMenuItem1.Name = "bpsToolStripMenuItem1";
            this.bpsToolStripMenuItem1.Size = new System.Drawing.Size(139, 22);
            this.bpsToolStripMenuItem1.Text = "4800Bps";
            this.bpsToolStripMenuItem1.Click += new System.EventHandler(this.bpsToolStripMenuItem1_Click);
            // 
            // bpsToolStripMenuItem2
            // 
            this.bpsToolStripMenuItem2.Name = "bpsToolStripMenuItem2";
            this.bpsToolStripMenuItem2.Size = new System.Drawing.Size(139, 22);
            this.bpsToolStripMenuItem2.Text = "9600Bps";
            this.bpsToolStripMenuItem2.Click += new System.EventHandler(this.bpsToolStripMenuItem2_Click);
            // 
            // bpsToolStripMenuItem3
            // 
            this.bpsToolStripMenuItem3.Name = "bpsToolStripMenuItem3";
            this.bpsToolStripMenuItem3.Size = new System.Drawing.Size(139, 22);
            this.bpsToolStripMenuItem3.Text = "19200Bps";
            this.bpsToolStripMenuItem3.Click += new System.EventHandler(this.bpsToolStripMenuItem3_Click);
            // 
            // bpsToolStripMenuItem4
            // 
            this.bpsToolStripMenuItem4.Name = "bpsToolStripMenuItem4";
            this.bpsToolStripMenuItem4.Size = new System.Drawing.Size(139, 22);
            this.bpsToolStripMenuItem4.Text = "38400Bps";
            this.bpsToolStripMenuItem4.Click += new System.EventHandler(this.bpsToolStripMenuItem4_Click);
            // 
            // bpsToolStripMenuItem5
            // 
            this.bpsToolStripMenuItem5.Name = "bpsToolStripMenuItem5";
            this.bpsToolStripMenuItem5.Size = new System.Drawing.Size(139, 22);
            this.bpsToolStripMenuItem5.Text = "57600Bps";
            this.bpsToolStripMenuItem5.Click += new System.EventHandler(this.bpsToolStripMenuItem5_Click);
            // 
            // bpsToolStripMenuItem6
            // 
            this.bpsToolStripMenuItem6.Name = "bpsToolStripMenuItem6";
            this.bpsToolStripMenuItem6.Size = new System.Drawing.Size(139, 22);
            this.bpsToolStripMenuItem6.Text = "115200Bps";
            this.bpsToolStripMenuItem6.Click += new System.EventHandler(this.bpsToolStripMenuItem6_Click);
            // 
            // ToolStripMenuItem_SendTiming
            // 
            this.ToolStripMenuItem_SendTiming.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DelimiterToolStripMenuItem,
            this.SoonSendToolStripMenuItem});
            this.ToolStripMenuItem_SendTiming.Name = "ToolStripMenuItem_SendTiming";
            this.ToolStripMenuItem_SendTiming.Size = new System.Drawing.Size(184, 22);
            this.ToolStripMenuItem_SendTiming.Text = "送信タイミング";
            // 
            // DelimiterToolStripMenuItem
            // 
            this.DelimiterToolStripMenuItem.Name = "DelimiterToolStripMenuItem";
            this.DelimiterToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.DelimiterToolStripMenuItem.Text = "デリミタを検出して送信";
            this.DelimiterToolStripMenuItem.Click += new System.EventHandler(this.DelimiterToolStripMenuItem_Click);
            // 
            // SoonSendToolStripMenuItem
            // 
            this.SoonSendToolStripMenuItem.Name = "SoonSendToolStripMenuItem";
            this.SoonSendToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.SoonSendToolStripMenuItem.Text = "入力と同時に送信";
            this.SoonSendToolStripMenuItem.Click += new System.EventHandler(this.SoonSendToolStripMenuItem_Click);
            // 
            // ToolStripMenuItem_Delimiter
            // 
            this.ToolStripMenuItem_Delimiter.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cRToolStripMenuItem,
            this.lFToolStripMenuItem,
            this.cRLFrnToolStripMenuItem});
            this.ToolStripMenuItem_Delimiter.Name = "ToolStripMenuItem_Delimiter";
            this.ToolStripMenuItem_Delimiter.Size = new System.Drawing.Size(184, 22);
            this.ToolStripMenuItem_Delimiter.Text = "デリミタ";
            // 
            // cRToolStripMenuItem
            // 
            this.cRToolStripMenuItem.Name = "cRToolStripMenuItem";
            this.cRToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.cRToolStripMenuItem.Text = "CR(\\r)";
            this.cRToolStripMenuItem.Click += new System.EventHandler(this.cRToolStripMenuItem_Click);
            // 
            // lFToolStripMenuItem
            // 
            this.lFToolStripMenuItem.Name = "lFToolStripMenuItem";
            this.lFToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.lFToolStripMenuItem.Text = "LF(\\n)";
            this.lFToolStripMenuItem.Click += new System.EventHandler(this.lFToolStripMenuItem_Click);
            // 
            // cRLFrnToolStripMenuItem
            // 
            this.cRLFrnToolStripMenuItem.Name = "cRLFrnToolStripMenuItem";
            this.cRLFrnToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.cRLFrnToolStripMenuItem.Text = "CR+LF(\\r\\n)";
            this.cRLFrnToolStripMenuItem.Click += new System.EventHandler(this.cRLFrnToolStripMenuItem_Click);
            // 
            // BinModeToolStripMenuItem
            // 
            this.BinModeToolStripMenuItem.Name = "BinModeToolStripMenuItem";
            this.BinModeToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.BinModeToolStripMenuItem.Text = "バイナリ送信モード";
            this.BinModeToolStripMenuItem.Click += new System.EventHandler(this.バイナリ送信モードToolStripMenuItem_Click);
            // 
            // 表示フォントの変更ToolStripMenuItem
            // 
            this.表示フォントの変更ToolStripMenuItem.Name = "表示フォントの変更ToolStripMenuItem";
            this.表示フォントの変更ToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.表示フォントの変更ToolStripMenuItem.Text = "表示フォントの変更";
            this.表示フォントの変更ToolStripMenuItem.Click += new System.EventHandler(this.表示フォントの変更ToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.接続CToolStripMenuItem,
            this.設定SToolStripMenuItem,
            this.ヘルプToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(799, 26);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 接続CToolStripMenuItem
            // 
            this.接続CToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.再接続RToolStripMenuItem,
            this.ポートを閉じるDToolStripMenuItem,
            this.保存SToolStripMenuItem,
            this.toolStripMenuItem1,
            this.ファイル送信FToolStripMenuItem,
            this.toolStripMenuItem3,
            this.終了ToolStripMenuItem});
            this.接続CToolStripMenuItem.Name = "接続CToolStripMenuItem";
            this.接続CToolStripMenuItem.Size = new System.Drawing.Size(62, 22);
            this.接続CToolStripMenuItem.Text = "接続(&C)";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.toolStripMenuItem2.Size = new System.Drawing.Size(345, 22);
            this.toolStripMenuItem2.Text = "新規接続(&C)";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // 再接続RToolStripMenuItem
            // 
            this.再接続RToolStripMenuItem.Name = "再接続RToolStripMenuItem";
            this.再接続RToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.再接続RToolStripMenuItem.Size = new System.Drawing.Size(345, 22);
            this.再接続RToolStripMenuItem.Text = "再接続(&R)";
            this.再接続RToolStripMenuItem.Click += new System.EventHandler(this.再接続RToolStripMenuItem_Click);
            // 
            // ポートを閉じるDToolStripMenuItem
            // 
            this.ポートを閉じるDToolStripMenuItem.Name = "ポートを閉じるDToolStripMenuItem";
            this.ポートを閉じるDToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.ポートを閉じるDToolStripMenuItem.Size = new System.Drawing.Size(345, 22);
            this.ポートを閉じるDToolStripMenuItem.Text = "ポートを閉じる(&D)";
            this.ポートを閉じるDToolStripMenuItem.Click += new System.EventHandler(this.ポートを閉じるDToolStripMenuItem_Click);
            // 
            // 保存SToolStripMenuItem
            // 
            this.保存SToolStripMenuItem.Name = "保存SToolStripMenuItem";
            this.保存SToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.保存SToolStripMenuItem.Size = new System.Drawing.Size(345, 22);
            this.保存SToolStripMenuItem.Text = "すべての開いているウィンドウを保存(&S)";
            this.保存SToolStripMenuItem.Click += new System.EventHandler(this.保存SToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(342, 6);
            // 
            // ファイル送信FToolStripMenuItem
            // 
            this.ファイル送信FToolStripMenuItem.Name = "ファイル送信FToolStripMenuItem";
            this.ファイル送信FToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.ファイル送信FToolStripMenuItem.Size = new System.Drawing.Size(345, 22);
            this.ファイル送信FToolStripMenuItem.Text = "ファイル送信(&F)";
            this.ファイル送信FToolStripMenuItem.Click += new System.EventHandler(this.ファイル送信FToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(342, 6);
            // 
            // 終了ToolStripMenuItem
            // 
            this.終了ToolStripMenuItem.Name = "終了ToolStripMenuItem";
            this.終了ToolStripMenuItem.Size = new System.Drawing.Size(345, 22);
            this.終了ToolStripMenuItem.Text = "終了(&X)";
            this.終了ToolStripMenuItem.Click += new System.EventHandler(this.終了ToolStripMenuItem_Click);
            // 
            // 設定SToolStripMenuItem
            // 
            this.設定SToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.基本設定EToolStripMenuItem,
            this.設定の初期化ToolStripMenuItem,
            this.toolStripMenuItem4,
            this.ToolStripMenuItem_Dummydata,
            this.系列の追加ウィザードToolStripMenuItem,
            this.toolStripMenuItem5,
            this.フォントの設定ToolStripMenuItem,
            this.デフォルトフォントに戻すGToolStripMenuItem});
            this.設定SToolStripMenuItem.Name = "設定SToolStripMenuItem";
            this.設定SToolStripMenuItem.Size = new System.Drawing.Size(61, 22);
            this.設定SToolStripMenuItem.Text = "設定(&E)";
            // 
            // 基本設定EToolStripMenuItem
            // 
            this.基本設定EToolStripMenuItem.Name = "基本設定EToolStripMenuItem";
            this.基本設定EToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.基本設定EToolStripMenuItem.Size = new System.Drawing.Size(295, 22);
            this.基本設定EToolStripMenuItem.Text = "ターミナルと自動保存の設定(&E)";
            this.基本設定EToolStripMenuItem.Click += new System.EventHandler(this.基本設定EToolStripMenuItem_Click);
            // 
            // 設定の初期化ToolStripMenuItem
            // 
            this.設定の初期化ToolStripMenuItem.Name = "設定の初期化ToolStripMenuItem";
            this.設定の初期化ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.設定の初期化ToolStripMenuItem.Size = new System.Drawing.Size(295, 22);
            this.設定の初期化ToolStripMenuItem.Text = "設定の初期化(&I)";
            this.設定の初期化ToolStripMenuItem.Click += new System.EventHandler(this.設定の初期化ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(292, 6);
            // 
            // ToolStripMenuItem_Dummydata
            // 
            this.ToolStripMenuItem_Dummydata.Name = "ToolStripMenuItem_Dummydata";
            this.ToolStripMenuItem_Dummydata.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.ToolStripMenuItem_Dummydata.Size = new System.Drawing.Size(295, 22);
            this.ToolStripMenuItem_Dummydata.Text = "ダミーデータの出力(&D)";
            this.ToolStripMenuItem_Dummydata.Click += new System.EventHandler(this.ToolStripMenuItem_Dummydata_Click);
            // 
            // 系列の追加ウィザードToolStripMenuItem
            // 
            this.系列の追加ウィザードToolStripMenuItem.Name = "系列の追加ウィザードToolStripMenuItem";
            this.系列の追加ウィザードToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.K)));
            this.系列の追加ウィザードToolStripMenuItem.Size = new System.Drawing.Size(295, 22);
            this.系列の追加ウィザードToolStripMenuItem.Text = "系列の追加ウィザード(&W)";
            this.系列の追加ウィザードToolStripMenuItem.Click += new System.EventHandler(this.系列の追加ウィザードToolStripMenuItem_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(292, 6);
            // 
            // フォントの設定ToolStripMenuItem
            // 
            this.フォントの設定ToolStripMenuItem.Name = "フォントの設定ToolStripMenuItem";
            this.フォントの設定ToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F7;
            this.フォントの設定ToolStripMenuItem.Size = new System.Drawing.Size(295, 22);
            this.フォントの設定ToolStripMenuItem.Text = "フォントの設定(&F)";
            this.フォントの設定ToolStripMenuItem.Click += new System.EventHandler(this.フォントの設定ToolStripMenuItem_Click);
            // 
            // デフォルトフォントに戻すGToolStripMenuItem
            // 
            this.デフォルトフォントに戻すGToolStripMenuItem.Name = "デフォルトフォントに戻すGToolStripMenuItem";
            this.デフォルトフォントに戻すGToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F8;
            this.デフォルトフォントに戻すGToolStripMenuItem.Size = new System.Drawing.Size(295, 22);
            this.デフォルトフォントに戻すGToolStripMenuItem.Text = "デフォルトフォントに戻す(&G)";
            this.デフォルトフォントに戻すGToolStripMenuItem.Click += new System.EventHandler(this.デフォルトフォントに戻すGToolStripMenuItem_Click);
            // 
            // ヘルプToolStripMenuItem
            // 
            this.ヘルプToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.目次HToolStripMenuItem,
            this.バージョン情報AToolStripMenuItem,
            this.ショートカットの表示SToolStripMenuItem});
            this.ヘルプToolStripMenuItem.Name = "ヘルプToolStripMenuItem";
            this.ヘルプToolStripMenuItem.Size = new System.Drawing.Size(75, 22);
            this.ヘルプToolStripMenuItem.Text = "ヘルプ(&H)";
            // 
            // 目次HToolStripMenuItem
            // 
            this.目次HToolStripMenuItem.Name = "目次HToolStripMenuItem";
            this.目次HToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.目次HToolStripMenuItem.Size = new System.Drawing.Size(236, 22);
            this.目次HToolStripMenuItem.Text = "目次(&H)";
            this.目次HToolStripMenuItem.Click += new System.EventHandler(this.目次HToolStripMenuItem_Click);
            // 
            // バージョン情報AToolStripMenuItem
            // 
            this.バージョン情報AToolStripMenuItem.Name = "バージョン情報AToolStripMenuItem";
            this.バージョン情報AToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.バージョン情報AToolStripMenuItem.Size = new System.Drawing.Size(236, 22);
            this.バージョン情報AToolStripMenuItem.Text = "バージョン情報(&A)";
            this.バージョン情報AToolStripMenuItem.Click += new System.EventHandler(this.バージョン情報AToolStripMenuItem_Click);
            // 
            // ショートカットの表示SToolStripMenuItem
            // 
            this.ショートカットの表示SToolStripMenuItem.Name = "ショートカットの表示SToolStripMenuItem";
            this.ショートカットの表示SToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.ショートカットの表示SToolStripMenuItem.Size = new System.Drawing.Size(236, 22);
            this.ショートカットの表示SToolStripMenuItem.Text = "ショートカットの表示(&S)";
            this.ショートカットの表示SToolStripMenuItem.Click += new System.EventHandler(this.ショートカットの表示SToolStripMenuItem_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "テキスト(.txt)|*.txt|すべてのファイル|*.*";
            // 
            // saveFileDialog_csv
            // 
            this.saveFileDialog_csv.Filter = "CSVファイル(.csv)|*.csv";
            // 
            // saveFileDialog_saveImage
            // 
            this.saveFileDialog_saveImage.Filter = "ビットマップ(.bmp)|*.bmp";
            // 
            // saveFileDialog_saveXML
            // 
            this.saveFileDialog_saveXML.Filter = "グラフ設定ファイル(.xml)|*.xml";
            // 
            // openFileDialog_readXML
            // 
            this.openFileDialog_readXML.AddExtension = false;
            this.openFileDialog_readXML.FileName = "openFileDialog1";
            this.openFileDialog_readXML.Filter = "グラフ設定ファイル(.xml)|*.xml";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(799, 649);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "NanoTerm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.statusStrip2.ResumeLayout(false);
            this.statusStrip2.PerformLayout();
            this.tabControl2.ResumeLayout(false);
            this.tabPage_graph1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabPage_graph2.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Series)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.contextMenuStrip_SetGraph.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.statusStrip3.ResumeLayout(false);
            this.statusStrip3.PerformLayout();
            this.groupBox_ManualSave.ResumeLayout(false);
            this.groupBox_ManualSave.PerformLayout();
            this.groupbox_autoSave.ResumeLayout(false);
            this.groupbox_autoSave.PerformLayout();
            this.panel_ListAutoSave.ResumeLayout(false);
            this.panel_ListAutoSave.PerformLayout();
            this.contextMenuStrip_SetBaudRate.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_SetBaudRate;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel label;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 接続CToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 再接続RToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 終了ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 設定SToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 保存SToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem 基本設定EToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_Graph_Port;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_Graph_Label;
        private System.Windows.Forms.Button button_AddGraph;
        private System.Windows.Forms.TextBox textBox_Graph_Name;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.ComboBox comboBox_Graph_Type;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox checkBox_Graph_SecondaryAxis;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_Graph_b;
        private System.Windows.Forms.TextBox textBox_Graph_a;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button_delete;
        private System.Windows.Forms.ComboBox comboBox_deleteList;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader 時刻;
        private System.Windows.Forms.ColumnHeader 経過時間;
        private System.Windows.Forms.Button button_savecsv;
        private System.Windows.Forms.SaveFileDialog saveFileDialog_csv;
        private System.Windows.Forms.CheckBox checkBox_deleteFromDataList;
        private System.Windows.Forms.StatusStrip statusStrip2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_SetGraph;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_GraphSettings;
        private System.Windows.Forms.CheckBox checkBox_saveDeletedData;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox checkBox_ListAutoSave;
        private System.Windows.Forms.GroupBox groupBox_ManualSave;
        private System.Windows.Forms.GroupBox groupbox_autoSave;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox_ListAutoSave_LogLength;
        private System.Windows.Forms.Button button_setAutoSave;
        private System.Windows.Forms.Button button_ListAutoSave_SelectFolder;
        private System.Windows.Forms.TextBox textBox_ListAutoSave_Folder;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox_ListAutoSave_FileName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel_ListAutoSave;
        private System.Windows.Forms.StatusStrip statusStrip3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        private System.Windows.Forms.SaveFileDialog saveFileDialog_saveImage;
        private System.Windows.Forms.CheckBox checkBox_ListAutoSave_SaveImage;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Dummydata;
        private System.Windows.Forms.SaveFileDialog saveFileDialog_saveXML;
        private System.Windows.Forms.OpenFileDialog openFileDialog_readXML;
        private System.Windows.Forms.ToolStripMenuItem 系列の追加ウィザードToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_BaudRate;
        private System.Windows.Forms.ToolStripMenuItem bpsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bpsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem bpsToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem bpsToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem bpsToolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem bpsToolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem bpsToolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_SendTiming;
        private System.Windows.Forms.ToolStripMenuItem DelimiterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SoonSendToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Delimiter;
        private System.Windows.Forms.ToolStripMenuItem cRToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lFToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cRLFrnToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button_Wizard;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.Button button_deleteAll;
        private System.Windows.Forms.ToolStripMenuItem グラフの書式設定ToolStripMenuItem;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage_graph1;
        private System.Windows.Forms.TabPage tabPage_graph2;
        private System.Windows.Forms.Button button_saveImage;
        private System.Windows.Forms.Button button_saveClipboard;
        private System.Windows.Forms.Button button_seriesview_update;
        private System.Windows.Forms.DataGridView dataGridView_Series;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button_paramSave;
        private System.Windows.Forms.Button button_paramLoad;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button button_graph_allview;
        private System.Windows.Forms.Button button_graph_allhide;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.RadioButton radioButton_graph_x_from;
        private System.Windows.Forms.RadioButton radioButton_graph_all_fromnow;
        private System.Windows.Forms.RadioButton radioButton_graph_x_all;
        private System.Windows.Forms.Button button_graph_xrange_update;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox comboBox_graph_x_from;
        private System.Windows.Forms.TextBox textBox_graph_x_from;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Delete;
        private System.Windows.Forms.DataGridViewTextBoxColumn Series;
        private System.Windows.Forms.ToolStripMenuItem ヘルプToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 目次HToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem バージョン情報AToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ファイル送信FToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem 設定の初期化ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem BinModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ポートを閉じるDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ショートカットの表示SToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem フォントの設定ToolStripMenuItem;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.ToolStripMenuItem 表示フォントの変更ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem デフォルトフォントに戻すGToolStripMenuItem;
    }
}

