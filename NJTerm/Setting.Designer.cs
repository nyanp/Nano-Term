namespace NanoTerm
{
    partial class Setting
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Setting));
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.checkBox_saveConfig = new System.Windows.Forms.CheckBox();
            this.comboBox_TIMESTAMP_FORMAT = new System.Windows.Forms.ComboBox();
            this.textBox_TIMESTAMP_RATE = new System.Windows.Forms.TextBox();
            this.checkBox_TIMESTAMPTX = new System.Windows.Forms.CheckBox();
            this.checkBox_TIMESTAMPRX = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox_TIMESTAMP_LINEHEAD = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.radioButton_CRLF = new System.Windows.Forms.RadioButton();
            this.radioButton_LF = new System.Windows.Forms.RadioButton();
            this.radioButton_CR = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.radioButton_SYNC = new System.Windows.Forms.RadioButton();
            this.radioButton_DELIMITER = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBox_AUTO_RECONNECT = new System.Windows.Forms.CheckBox();
            this.checkBox_AUTO_CONNECT = new System.Windows.Forms.CheckBox();
            this.checkBox_AUTOSAVE = new System.Windows.Forms.CheckBox();
            this.textBox1_SAVE_INTERVAL = new System.Windows.Forms.TextBox();
            this.comboBox_BAUDRATE = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_SaveFolder = new System.Windows.Forms.TextBox();
            this.button_SelectSaveFolder = new System.Windows.Forms.Button();
            this.checkBox_AUTO_CONNECT_FORMOPENING = new System.Windows.Forms.CheckBox();
            this.comboBox_StopBits = new System.Windows.Forms.ComboBox();
            this.comboBox_Parity = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.comboBox_HandShake = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.comboBox_DataBits = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.checkBox_removeEmptyLog = new System.Windows.Forms.CheckBox();
            this.label13 = new System.Windows.Forms.Label();
            this.panel_autoconnect = new System.Windows.Forms.Panel();
            this.checkBox_SHOW_BINARY = new System.Windows.Forms.CheckBox();
            this.checkBox_SHOW_RX = new System.Windows.Forms.CheckBox();
            this.checkBox_SHOW_TX = new System.Windows.Forms.CheckBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel_autoconnect.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(423, 295);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(168, 34);
            this.button1.TabIndex = 6;
            this.button1.Text = "OK(&C)";
            this.toolTip1.SetToolTip(this.button1, "設定をすべてのウィンドウに適用し、このウィンドウを閉じます。");
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(597, 295);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(174, 34);
            this.button2.TabIndex = 7;
            this.button2.Text = "キャンセル(&X)";
            this.toolTip1.SetToolTip(this.button2, "設定を適用せずにこのウィンドウを閉じます。");
            this.button2.UseVisualStyleBackColor = true;
            // 
            // checkBox_saveConfig
            // 
            this.checkBox_saveConfig.AutoSize = true;
            this.checkBox_saveConfig.Checked = true;
            this.checkBox_saveConfig.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_saveConfig.Location = new System.Drawing.Point(401, 242);
            this.checkBox_saveConfig.Name = "checkBox_saveConfig";
            this.checkBox_saveConfig.Size = new System.Drawing.Size(100, 16);
            this.checkBox_saveConfig.TabIndex = 8;
            this.checkBox_saveConfig.Text = "設定を保存する";
            this.toolTip1.SetToolTip(this.checkBox_saveConfig, "設定を保存し、次回起動時にこの設定で開始します。");
            this.checkBox_saveConfig.UseVisualStyleBackColor = true;
            // 
            // comboBox_TIMESTAMP_FORMAT
            // 
            this.comboBox_TIMESTAMP_FORMAT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_TIMESTAMP_FORMAT.FormattingEnabled = true;
            this.comboBox_TIMESTAMP_FORMAT.Items.AddRange(new object[] {
            "yyyy/MM/dd HH:mm:ss",
            "yyyy/MM/dd HH:mm:ss.ff",
            "HH:mm:ss",
            "HH:mm:ss.ff"});
            this.comboBox_TIMESTAMP_FORMAT.Location = new System.Drawing.Point(7, 18);
            this.comboBox_TIMESTAMP_FORMAT.Name = "comboBox_TIMESTAMP_FORMAT";
            this.comboBox_TIMESTAMP_FORMAT.Size = new System.Drawing.Size(155, 20);
            this.comboBox_TIMESTAMP_FORMAT.TabIndex = 0;
            this.toolTip1.SetToolTip(this.comboBox_TIMESTAMP_FORMAT, "タイムタグの書式を選択します。");
            // 
            // textBox_TIMESTAMP_RATE
            // 
            this.textBox_TIMESTAMP_RATE.Location = new System.Drawing.Point(221, 46);
            this.textBox_TIMESTAMP_RATE.Name = "textBox_TIMESTAMP_RATE";
            this.textBox_TIMESTAMP_RATE.Size = new System.Drawing.Size(100, 19);
            this.textBox_TIMESTAMP_RATE.TabIndex = 1;
            this.toolTip1.SetToolTip(this.textBox_TIMESTAMP_RATE, "前回の受信からこの時間だけ受信が無いときにタイムタグが付加されます。");
            this.textBox_TIMESTAMP_RATE.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_TIMESTAMP_RATE_KeyPress);
            // 
            // checkBox_TIMESTAMPTX
            // 
            this.checkBox_TIMESTAMPTX.AutoSize = true;
            this.checkBox_TIMESTAMPTX.Location = new System.Drawing.Point(168, 20);
            this.checkBox_TIMESTAMPTX.Name = "checkBox_TIMESTAMPTX";
            this.checkBox_TIMESTAMPTX.Size = new System.Drawing.Size(92, 16);
            this.checkBox_TIMESTAMPTX.TabIndex = 2;
            this.checkBox_TIMESTAMPTX.Text = "送信タイムタグ";
            this.toolTip1.SetToolTip(this.checkBox_TIMESTAMPTX, "送信ウィンドウにタイムタグを設定します。");
            this.checkBox_TIMESTAMPTX.UseVisualStyleBackColor = true;
            // 
            // checkBox_TIMESTAMPRX
            // 
            this.checkBox_TIMESTAMPRX.AutoSize = true;
            this.checkBox_TIMESTAMPRX.Location = new System.Drawing.Point(266, 20);
            this.checkBox_TIMESTAMPRX.Name = "checkBox_TIMESTAMPRX";
            this.checkBox_TIMESTAMPRX.Size = new System.Drawing.Size(92, 16);
            this.checkBox_TIMESTAMPRX.TabIndex = 3;
            this.checkBox_TIMESTAMPRX.Text = "受信タイムタグ";
            this.toolTip1.SetToolTip(this.checkBox_TIMESTAMPRX, "受信ウィンドウにタイムタグを設定します。");
            this.checkBox_TIMESTAMPRX.UseVisualStyleBackColor = true;
            this.checkBox_TIMESTAMPRX.CheckedChanged += new System.EventHandler(this.checkBox_TIMESTAMPRX_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 49);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(208, 12);
            this.label7.TabIndex = 4;
            this.label7.Text = "タイムタグをつけるために必要な無受信時間";
            this.toolTip1.SetToolTip(this.label7, "前回の受信からこの時間だけ受信が無いときにタイムタグが付加されます。");
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(327, 49);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(20, 12);
            this.label8.TabIndex = 5;
            this.label8.Text = "ms";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox_TIMESTAMP_LINEHEAD);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.checkBox_TIMESTAMPRX);
            this.groupBox1.Controls.Add(this.checkBox_TIMESTAMPTX);
            this.groupBox1.Controls.Add(this.textBox_TIMESTAMP_RATE);
            this.groupBox1.Controls.Add(this.comboBox_TIMESTAMP_FORMAT);
            this.groupBox1.Location = new System.Drawing.Point(394, 134);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(377, 101);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "タイムタグ設定";
            // 
            // checkBox_TIMESTAMP_LINEHEAD
            // 
            this.checkBox_TIMESTAMP_LINEHEAD.AutoSize = true;
            this.checkBox_TIMESTAMP_LINEHEAD.Location = new System.Drawing.Point(8, 70);
            this.checkBox_TIMESTAMP_LINEHEAD.Name = "checkBox_TIMESTAMP_LINEHEAD";
            this.checkBox_TIMESTAMP_LINEHEAD.Size = new System.Drawing.Size(199, 16);
            this.checkBox_TIMESTAMP_LINEHEAD.TabIndex = 6;
            this.checkBox_TIMESTAMP_LINEHEAD.Text = "受信タイムタグを行の先頭に限定する";
            this.toolTip1.SetToolTip(this.checkBox_TIMESTAMP_LINEHEAD, "無受信時間が経過し，改行コードを受信した時点でタイムタグを打ちます．文字の途中にタグが割り込まないため，グラフ使用時には有効化が推奨されます．");
            this.checkBox_TIMESTAMP_LINEHEAD.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.radioButton_CRLF);
            this.panel1.Controls.Add(this.radioButton_LF);
            this.panel1.Controls.Add(this.radioButton_CR);
            this.panel1.Location = new System.Drawing.Point(17, 18);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(154, 86);
            this.panel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "デリミタコード";
            // 
            // radioButton_CRLF
            // 
            this.radioButton_CRLF.AutoSize = true;
            this.radioButton_CRLF.Location = new System.Drawing.Point(3, 69);
            this.radioButton_CRLF.Name = "radioButton_CRLF";
            this.radioButton_CRLF.Size = new System.Drawing.Size(148, 16);
            this.radioButton_CRLF.TabIndex = 2;
            this.radioButton_CRLF.Text = "0x0D 0x0A (CRLF, \\r\\n)";
            this.toolTip1.SetToolTip(this.radioButton_CRLF, "エンターを押した時に0D 0Aを送信します。");
            this.radioButton_CRLF.UseVisualStyleBackColor = true;
            // 
            // radioButton_LF
            // 
            this.radioButton_LF.AutoSize = true;
            this.radioButton_LF.Location = new System.Drawing.Point(3, 47);
            this.radioButton_LF.Name = "radioButton_LF";
            this.radioButton_LF.Size = new System.Drawing.Size(92, 16);
            this.radioButton_LF.TabIndex = 1;
            this.radioButton_LF.Text = "0x0A (LF, \\n)";
            this.toolTip1.SetToolTip(this.radioButton_LF, "エンターを押した時に0Aを送信します。");
            this.radioButton_LF.UseVisualStyleBackColor = true;
            // 
            // radioButton_CR
            // 
            this.radioButton_CR.AutoSize = true;
            this.radioButton_CR.Checked = true;
            this.radioButton_CR.Location = new System.Drawing.Point(3, 25);
            this.radioButton_CR.Name = "radioButton_CR";
            this.radioButton_CR.Size = new System.Drawing.Size(93, 16);
            this.radioButton_CR.TabIndex = 0;
            this.radioButton_CR.TabStop = true;
            this.radioButton_CR.Text = "0x0D (CR, \\r)";
            this.toolTip1.SetToolTip(this.radioButton_CR, "エンターを押した時に0Dを送信します。");
            this.radioButton_CR.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.radioButton_SYNC);
            this.panel2.Controls.Add(this.radioButton_DELIMITER);
            this.panel2.Location = new System.Drawing.Point(177, 18);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(193, 86);
            this.panel2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-2, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "送信タイミング";
            // 
            // radioButton_SYNC
            // 
            this.radioButton_SYNC.AutoSize = true;
            this.radioButton_SYNC.Location = new System.Drawing.Point(3, 47);
            this.radioButton_SYNC.Name = "radioButton_SYNC";
            this.radioButton_SYNC.Size = new System.Drawing.Size(127, 16);
            this.radioButton_SYNC.TabIndex = 1;
            this.radioButton_SYNC.Text = "入力と同時に送信(&S)";
            this.toolTip1.SetToolTip(this.radioButton_SYNC, "キーを入力した瞬間に送信します。");
            this.radioButton_SYNC.UseVisualStyleBackColor = true;
            // 
            // radioButton_DELIMITER
            // 
            this.radioButton_DELIMITER.AutoSize = true;
            this.radioButton_DELIMITER.Checked = true;
            this.radioButton_DELIMITER.Location = new System.Drawing.Point(3, 25);
            this.radioButton_DELIMITER.Name = "radioButton_DELIMITER";
            this.radioButton_DELIMITER.Size = new System.Drawing.Size(146, 16);
            this.radioButton_DELIMITER.TabIndex = 0;
            this.radioButton_DELIMITER.TabStop = true;
            this.radioButton_DELIMITER.Text = "デリミタを検出して送信(&D)";
            this.toolTip1.SetToolTip(this.radioButton_DELIMITER, "エンターキーを検出したタイミングで送信します。");
            this.radioButton_DELIMITER.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panel2);
            this.groupBox2.Controls.Add(this.panel1);
            this.groupBox2.Location = new System.Drawing.Point(394, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(377, 111);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "送信デリミタ設定";
            // 
            // checkBox_AUTO_RECONNECT
            // 
            this.checkBox_AUTO_RECONNECT.AutoSize = true;
            this.checkBox_AUTO_RECONNECT.Location = new System.Drawing.Point(7, 171);
            this.checkBox_AUTO_RECONNECT.Name = "checkBox_AUTO_RECONNECT";
            this.checkBox_AUTO_RECONNECT.Size = new System.Drawing.Size(219, 16);
            this.checkBox_AUTO_RECONNECT.TabIndex = 2;
            this.checkBox_AUTO_RECONNECT.Text = "一時切断されたポートへ自動的に再接続";
            this.toolTip1.SetToolTip(this.checkBox_AUTO_RECONNECT, "ウィンドウが開いたままポートが切断/再検出されたとき、自動的にウィンドウへ接続します。");
            this.checkBox_AUTO_RECONNECT.UseVisualStyleBackColor = true;
            // 
            // checkBox_AUTO_CONNECT
            // 
            this.checkBox_AUTO_CONNECT.AutoSize = true;
            this.checkBox_AUTO_CONNECT.Location = new System.Drawing.Point(7, 37);
            this.checkBox_AUTO_CONNECT.Name = "checkBox_AUTO_CONNECT";
            this.checkBox_AUTO_CONNECT.Size = new System.Drawing.Size(251, 16);
            this.checkBox_AUTO_CONNECT.TabIndex = 1;
            this.checkBox_AUTO_CONNECT.Text = "起動中にポートの追加を検出して自動的に接続";
            this.toolTip1.SetToolTip(this.checkBox_AUTO_CONNECT, "NanoTerm実行中に新しいポートを検出すると、指定した設定でウィンドウを自動接続します。");
            this.checkBox_AUTO_CONNECT.UseVisualStyleBackColor = true;
            this.checkBox_AUTO_CONNECT.CheckedChanged += new System.EventHandler(this.checkBox_AUTO_CONNECT_CheckedChanged);
            // 
            // checkBox_AUTOSAVE
            // 
            this.checkBox_AUTOSAVE.AutoSize = true;
            this.checkBox_AUTOSAVE.Location = new System.Drawing.Point(7, 193);
            this.checkBox_AUTOSAVE.Name = "checkBox_AUTOSAVE";
            this.checkBox_AUTOSAVE.Size = new System.Drawing.Size(144, 16);
            this.checkBox_AUTOSAVE.TabIndex = 0;
            this.checkBox_AUTOSAVE.Text = "自動接続時にログを保存";
            this.toolTip1.SetToolTip(this.checkBox_AUTOSAVE, "上記いずれかの自動接続が有効のとき、以下のフォルダにログファイルを自動保存します。");
            this.checkBox_AUTOSAVE.UseVisualStyleBackColor = true;
            this.checkBox_AUTOSAVE.CheckedChanged += new System.EventHandler(this.checkBox_AUTOSAVE_CheckedChanged);
            // 
            // textBox1_SAVE_INTERVAL
            // 
            this.textBox1_SAVE_INTERVAL.AcceptsTab = true;
            this.textBox1_SAVE_INTERVAL.Location = new System.Drawing.Point(211, 190);
            this.textBox1_SAVE_INTERVAL.Name = "textBox1_SAVE_INTERVAL";
            this.textBox1_SAVE_INTERVAL.Size = new System.Drawing.Size(71, 19);
            this.textBox1_SAVE_INTERVAL.TabIndex = 3;
            this.toolTip1.SetToolTip(this.textBox1_SAVE_INTERVAL, "ログファイルの保存間隔を指定します。");
            this.textBox1_SAVE_INTERVAL.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_SAVE_INTERVAL_KeyPress);
            // 
            // comboBox_BAUDRATE
            // 
            this.comboBox_BAUDRATE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_BAUDRATE.FormattingEnabled = true;
            this.comboBox_BAUDRATE.Items.AddRange(new object[] {
            "1200",
            "4800",
            "9600",
            "19200",
            "38400",
            "57600",
            "115200"});
            this.comboBox_BAUDRATE.Location = new System.Drawing.Point(71, 3);
            this.comboBox_BAUDRATE.Name = "comboBox_BAUDRATE";
            this.comboBox_BAUDRATE.Size = new System.Drawing.Size(111, 20);
            this.comboBox_BAUDRATE.TabIndex = 5;
            this.toolTip1.SetToolTip(this.comboBox_BAUDRATE, "自動接続時のボーレートを設定します。");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "ボーレート";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(191, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "bps";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(288, 193);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "ms間隔で保存";
            this.toolTip1.SetToolTip(this.label5, "ログファイルの保存間隔を指定します。");
            // 
            // textBox_SaveFolder
            // 
            this.textBox_SaveFolder.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.textBox_SaveFolder.Enabled = false;
            this.textBox_SaveFolder.Location = new System.Drawing.Point(27, 231);
            this.textBox_SaveFolder.Multiline = true;
            this.textBox_SaveFolder.Name = "textBox_SaveFolder";
            this.textBox_SaveFolder.Size = new System.Drawing.Size(298, 40);
            this.textBox_SaveFolder.TabIndex = 10;
            this.textBox_SaveFolder.TabStop = false;
            this.toolTip1.SetToolTip(this.textBox_SaveFolder, "自動保存時のログ保存フォルダを指定します。");
            // 
            // button_SelectSaveFolder
            // 
            this.button_SelectSaveFolder.Location = new System.Drawing.Point(328, 231);
            this.button_SelectSaveFolder.Name = "button_SelectSaveFolder";
            this.button_SelectSaveFolder.Size = new System.Drawing.Size(24, 23);
            this.button_SelectSaveFolder.TabIndex = 11;
            this.button_SelectSaveFolder.Text = "...";
            this.button_SelectSaveFolder.UseVisualStyleBackColor = true;
            this.button_SelectSaveFolder.Click += new System.EventHandler(this.button_SelectSaveFolder_Click);
            // 
            // checkBox_AUTO_CONNECT_FORMOPENING
            // 
            this.checkBox_AUTO_CONNECT_FORMOPENING.AutoSize = true;
            this.checkBox_AUTO_CONNECT_FORMOPENING.Location = new System.Drawing.Point(7, 18);
            this.checkBox_AUTO_CONNECT_FORMOPENING.Name = "checkBox_AUTO_CONNECT_FORMOPENING";
            this.checkBox_AUTO_CONNECT_FORMOPENING.Size = new System.Drawing.Size(215, 16);
            this.checkBox_AUTO_CONNECT_FORMOPENING.TabIndex = 12;
            this.checkBox_AUTO_CONNECT_FORMOPENING.Text = "起動時にすべてのポートへ自動的に接続";
            this.toolTip1.SetToolTip(this.checkBox_AUTO_CONNECT_FORMOPENING, "NanoTerm起動時にポートをスキャンし、指定した設定で接続可能な全ポートに自動接続します。");
            this.checkBox_AUTO_CONNECT_FORMOPENING.UseVisualStyleBackColor = true;
            this.checkBox_AUTO_CONNECT_FORMOPENING.CheckedChanged += new System.EventHandler(this.checkBox_AUTO_CONNECT_FORMOPENING_CheckedChanged);
            // 
            // comboBox_StopBits
            // 
            this.comboBox_StopBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_StopBits.FormattingEnabled = true;
            this.comboBox_StopBits.Items.AddRange(new object[] {
            "1",
            "1.5",
            "2"});
            this.comboBox_StopBits.Location = new System.Drawing.Point(238, 28);
            this.comboBox_StopBits.Name = "comboBox_StopBits";
            this.comboBox_StopBits.Size = new System.Drawing.Size(99, 20);
            this.comboBox_StopBits.TabIndex = 14;
            this.toolTip1.SetToolTip(this.comboBox_StopBits, "自動接続時のストップビット数を指定します。");
            // 
            // comboBox_Parity
            // 
            this.comboBox_Parity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Parity.FormattingEnabled = true;
            this.comboBox_Parity.Items.AddRange(new object[] {
            "なし",
            "偶数",
            "奇数",
            "スペース",
            "マーク"});
            this.comboBox_Parity.Location = new System.Drawing.Point(71, 54);
            this.comboBox_Parity.Name = "comboBox_Parity";
            this.comboBox_Parity.Size = new System.Drawing.Size(90, 20);
            this.comboBox_Parity.TabIndex = 15;
            this.toolTip1.SetToolTip(this.comboBox_Parity, "自動接続時のパリティモードを指定します。");
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(171, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 12);
            this.label6.TabIndex = 16;
            this.label6.Text = "ストップビット";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(4, 60);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 12);
            this.label9.TabIndex = 17;
            this.label9.Text = "パリティ";
            // 
            // comboBox_HandShake
            // 
            this.comboBox_HandShake.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_HandShake.FormattingEnabled = true;
            this.comboBox_HandShake.Items.AddRange(new object[] {
            "なし",
            "RTS/CTS",
            "DTR/DSR",
            "Xon/Xoff"});
            this.comboBox_HandShake.Location = new System.Drawing.Point(238, 54);
            this.comboBox_HandShake.Name = "comboBox_HandShake";
            this.comboBox_HandShake.Size = new System.Drawing.Size(99, 20);
            this.comboBox_HandShake.TabIndex = 18;
            this.toolTip1.SetToolTip(this.comboBox_HandShake, "自動接続時のフロー制御モードを指定します。");
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(171, 57);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 12);
            this.label10.TabIndex = 19;
            this.label10.Text = "フロー制御";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(4, 32);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(45, 12);
            this.label11.TabIndex = 20;
            this.label11.Text = "データ長";
            // 
            // comboBox_DataBits
            // 
            this.comboBox_DataBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_DataBits.FormattingEnabled = true;
            this.comboBox_DataBits.Items.AddRange(new object[] {
            "8",
            "7",
            "6",
            "5",
            "4"});
            this.comboBox_DataBits.Location = new System.Drawing.Point(71, 29);
            this.comboBox_DataBits.Name = "comboBox_DataBits";
            this.comboBox_DataBits.Size = new System.Drawing.Size(50, 20);
            this.comboBox_DataBits.TabIndex = 21;
            this.toolTip1.SetToolTip(this.comboBox_DataBits, "自動接続時のデータビット数を設定します。");
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.checkBox_removeEmptyLog);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.checkBox_AUTO_CONNECT_FORMOPENING);
            this.groupBox3.Controls.Add(this.button_SelectSaveFolder);
            this.groupBox3.Controls.Add(this.textBox_SaveFolder);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.textBox1_SAVE_INTERVAL);
            this.groupBox3.Controls.Add(this.checkBox_AUTOSAVE);
            this.groupBox3.Controls.Add(this.checkBox_AUTO_CONNECT);
            this.groupBox3.Controls.Add(this.panel_autoconnect);
            this.groupBox3.Controls.Add(this.checkBox_AUTO_RECONNECT);
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(376, 302);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "接続・バックアップ設定";
            // 
            // checkBox_removeEmptyLog
            // 
            this.checkBox_removeEmptyLog.AutoSize = true;
            this.checkBox_removeEmptyLog.Location = new System.Drawing.Point(6, 277);
            this.checkBox_removeEmptyLog.Name = "checkBox_removeEmptyLog";
            this.checkBox_removeEmptyLog.Size = new System.Drawing.Size(270, 16);
            this.checkBox_removeEmptyLog.TabIndex = 24;
            this.checkBox_removeEmptyLog.Text = "NanoTerm終了時に0バイトのログファイルを全て削除";
            this.toolTip1.SetToolTip(this.checkBox_removeEmptyLog, "自動または手動で保存されたファイルのうち、サイズが0のものを自動的に削除します。");
            this.checkBox_removeEmptyLog.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(27, 213);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(76, 12);
            this.label13.TabIndex = 23;
            this.label13.Text = "保存先フォルダ";
            // 
            // panel_autoconnect
            // 
            this.panel_autoconnect.Controls.Add(this.checkBox_SHOW_BINARY);
            this.panel_autoconnect.Controls.Add(this.checkBox_SHOW_RX);
            this.panel_autoconnect.Controls.Add(this.checkBox_SHOW_TX);
            this.panel_autoconnect.Controls.Add(this.label14);
            this.panel_autoconnect.Controls.Add(this.label12);
            this.panel_autoconnect.Controls.Add(this.comboBox_DataBits);
            this.panel_autoconnect.Controls.Add(this.comboBox_BAUDRATE);
            this.panel_autoconnect.Controls.Add(this.label11);
            this.panel_autoconnect.Controls.Add(this.label3);
            this.panel_autoconnect.Controls.Add(this.label10);
            this.panel_autoconnect.Controls.Add(this.label4);
            this.panel_autoconnect.Controls.Add(this.comboBox_HandShake);
            this.panel_autoconnect.Controls.Add(this.comboBox_StopBits);
            this.panel_autoconnect.Controls.Add(this.label9);
            this.panel_autoconnect.Controls.Add(this.comboBox_Parity);
            this.panel_autoconnect.Controls.Add(this.label6);
            this.panel_autoconnect.Location = new System.Drawing.Point(26, 56);
            this.panel_autoconnect.Name = "panel_autoconnect";
            this.panel_autoconnect.Size = new System.Drawing.Size(341, 104);
            this.panel_autoconnect.TabIndex = 22;
            // 
            // checkBox_SHOW_BINARY
            // 
            this.checkBox_SHOW_BINARY.AutoSize = true;
            this.checkBox_SHOW_BINARY.Location = new System.Drawing.Point(253, 83);
            this.checkBox_SHOW_BINARY.Name = "checkBox_SHOW_BINARY";
            this.checkBox_SHOW_BINARY.Size = new System.Drawing.Size(84, 16);
            this.checkBox_SHOW_BINARY.TabIndex = 26;
            this.checkBox_SHOW_BINARY.Text = "受信バイナリ";
            this.checkBox_SHOW_BINARY.UseVisualStyleBackColor = true;
            // 
            // checkBox_SHOW_RX
            // 
            this.checkBox_SHOW_RX.AutoSize = true;
            this.checkBox_SHOW_RX.Location = new System.Drawing.Point(155, 83);
            this.checkBox_SHOW_RX.Name = "checkBox_SHOW_RX";
            this.checkBox_SHOW_RX.Size = new System.Drawing.Size(77, 16);
            this.checkBox_SHOW_RX.TabIndex = 25;
            this.checkBox_SHOW_RX.Text = "受信ASCII";
            this.checkBox_SHOW_RX.UseVisualStyleBackColor = true;
            // 
            // checkBox_SHOW_TX
            // 
            this.checkBox_SHOW_TX.AutoSize = true;
            this.checkBox_SHOW_TX.Location = new System.Drawing.Point(92, 83);
            this.checkBox_SHOW_TX.Name = "checkBox_SHOW_TX";
            this.checkBox_SHOW_TX.Size = new System.Drawing.Size(48, 16);
            this.checkBox_SHOW_TX.TabIndex = 24;
            this.checkBox_SHOW_TX.Text = "送信";
            this.checkBox_SHOW_TX.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(5, 84);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(72, 12);
            this.label14.TabIndex = 23;
            this.label14.Text = "接続ウィンドウ";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(127, 32);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(24, 12);
            this.label12.TabIndex = 22;
            this.label12.Text = "bits";
            // 
            // textBox3
            // 
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Location = new System.Drawing.Point(517, 243);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(254, 35);
            this.textBox3.TabIndex = 12;
            this.textBox3.Text = "設定を保存しておくと、次回起動時に保存された設定で接続を開始します。";
            // 
            // Setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(783, 341);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.checkBox_saveConfig);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Setting";
            this.Text = "基本設定";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel_autoconnect.ResumeLayout(false);
            this.panel_autoconnect.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox checkBox_saveConfig;
        private System.Windows.Forms.ComboBox comboBox_TIMESTAMP_FORMAT;
        private System.Windows.Forms.TextBox textBox_TIMESTAMP_RATE;
        private System.Windows.Forms.CheckBox checkBox_TIMESTAMPTX;
        private System.Windows.Forms.CheckBox checkBox_TIMESTAMPRX;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton radioButton_CRLF;
        private System.Windows.Forms.RadioButton radioButton_LF;
        private System.Windows.Forms.RadioButton radioButton_CR;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioButton_SYNC;
        private System.Windows.Forms.RadioButton radioButton_DELIMITER;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox checkBox_AUTO_RECONNECT;
        private System.Windows.Forms.CheckBox checkBox_AUTO_CONNECT;
        private System.Windows.Forms.CheckBox checkBox_AUTOSAVE;
        private System.Windows.Forms.TextBox textBox1_SAVE_INTERVAL;
        private System.Windows.Forms.ComboBox comboBox_BAUDRATE;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_SaveFolder;
        private System.Windows.Forms.Button button_SelectSaveFolder;
        private System.Windows.Forms.CheckBox checkBox_AUTO_CONNECT_FORMOPENING;
        private System.Windows.Forms.ComboBox comboBox_StopBits;
        private System.Windows.Forms.ComboBox comboBox_Parity;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBox_HandShake;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox comboBox_DataBits;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Panel panel_autoconnect;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.CheckBox checkBox_removeEmptyLog;
        private System.Windows.Forms.CheckBox checkBox_TIMESTAMP_LINEHEAD;
        private System.Windows.Forms.CheckBox checkBox_SHOW_BINARY;
        private System.Windows.Forms.CheckBox checkBox_SHOW_RX;
        private System.Windows.Forms.CheckBox checkBox_SHOW_TX;
        private System.Windows.Forms.Label label14;
    }
}