namespace NanoTerm
{
    partial class SetUpSerialPort
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetUpSerialPort));
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_PortName = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBox_BaudRate = new System.Windows.Forms.ComboBox();
            this.comboBox_DataBits = new System.Windows.Forms.ComboBox();
            this.comboBox_StopBits = new System.Windows.Forms.ComboBox();
            this.comboBox_Parity = new System.Windows.Forms.ComboBox();
            this.comboBox_HandShake = new System.Windows.Forms.ComboBox();
            this.button_Connect = new System.Windows.Forms.Button();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button_selectSaveDirectory = new System.Windows.Forms.Button();
            this.textBox_saveDirectory = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.checkBox_LogEnable = new System.Windows.Forms.CheckBox();
            this.panel_logWindowSelect = new System.Windows.Forms.Panel();
            this.checkBox_LogBinary = new System.Windows.Forms.CheckBox();
            this.checkBox_LogRx = new System.Windows.Forms.CheckBox();
            this.checkBox_LogTx = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox_saveFile = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBox_BinaryVisible = new System.Windows.Forms.CheckBox();
            this.checkBox_RxVisible = new System.Windows.Forms.CheckBox();
            this.checkBox_TxVisible = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.panel_logWindowSelect.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "接続ポート(&P)";
            // 
            // comboBox_PortName
            // 
            this.comboBox_PortName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_PortName.FormattingEnabled = true;
            this.comboBox_PortName.Location = new System.Drawing.Point(120, 25);
            this.comboBox_PortName.Name = "comboBox_PortName";
            this.comboBox_PortName.Size = new System.Drawing.Size(121, 20);
            this.comboBox_PortName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "ボーレート(&O)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "データ長(&I)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "ストップビット(&U)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(33, 128);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 5;
            this.label5.Text = "パリティ(&Y)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(33, 153);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 12);
            this.label6.TabIndex = 6;
            this.label6.Text = "フロー制御(&F)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(247, 58);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(23, 12);
            this.label7.TabIndex = 7;
            this.label7.Text = "bps";
            // 
            // comboBox_BaudRate
            // 
            this.comboBox_BaudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_BaudRate.FormattingEnabled = true;
            this.comboBox_BaudRate.Items.AddRange(new object[] {
            "1200",
            "4800",
            "9600",
            "19200",
            "38400",
            "57600",
            "115200"});
            this.comboBox_BaudRate.Location = new System.Drawing.Point(120, 50);
            this.comboBox_BaudRate.Name = "comboBox_BaudRate";
            this.comboBox_BaudRate.Size = new System.Drawing.Size(121, 20);
            this.comboBox_BaudRate.TabIndex = 8;
            // 
            // comboBox_DataBits
            // 
            this.comboBox_DataBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_DataBits.FormattingEnabled = true;
            this.comboBox_DataBits.Items.AddRange(new object[] {
            "8 bit",
            "7 bit",
            "6 bit",
            "5 bit",
            "4 bit"});
            this.comboBox_DataBits.Location = new System.Drawing.Point(120, 75);
            this.comboBox_DataBits.Name = "comboBox_DataBits";
            this.comboBox_DataBits.Size = new System.Drawing.Size(121, 20);
            this.comboBox_DataBits.TabIndex = 9;
            // 
            // comboBox_StopBits
            // 
            this.comboBox_StopBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_StopBits.FormattingEnabled = true;
            this.comboBox_StopBits.Items.AddRange(new object[] {
            "1",
            "1.5",
            "2"});
            this.comboBox_StopBits.Location = new System.Drawing.Point(120, 100);
            this.comboBox_StopBits.Name = "comboBox_StopBits";
            this.comboBox_StopBits.Size = new System.Drawing.Size(121, 20);
            this.comboBox_StopBits.TabIndex = 10;
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
            this.comboBox_Parity.Location = new System.Drawing.Point(120, 125);
            this.comboBox_Parity.Name = "comboBox_Parity";
            this.comboBox_Parity.Size = new System.Drawing.Size(121, 20);
            this.comboBox_Parity.TabIndex = 11;
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
            this.comboBox_HandShake.Location = new System.Drawing.Point(120, 150);
            this.comboBox_HandShake.Name = "comboBox_HandShake";
            this.comboBox_HandShake.Size = new System.Drawing.Size(121, 20);
            this.comboBox_HandShake.TabIndex = 12;
            // 
            // button_Connect
            // 
            this.button_Connect.Location = new System.Drawing.Point(400, 237);
            this.button_Connect.Name = "button_Connect";
            this.button_Connect.Size = new System.Drawing.Size(109, 75);
            this.button_Connect.TabIndex = 13;
            this.button_Connect.Text = "接続(&C)";
            this.button_Connect.UseVisualStyleBackColor = true;
            this.button_Connect.Click += new System.EventHandler(this.button_Connect_Click);
            // 
            // button_Cancel
            // 
            this.button_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_Cancel.Location = new System.Drawing.Point(400, 318);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(109, 55);
            this.button_Cancel.TabIndex = 14;
            this.button_Cancel.Text = "キャンセル(&X)";
            this.button_Cancel.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button_selectSaveDirectory);
            this.groupBox1.Controls.Add(this.textBox_saveDirectory);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.checkBox_LogEnable);
            this.groupBox1.Controls.Add(this.panel_logWindowSelect);
            this.groupBox1.Location = new System.Drawing.Point(35, 190);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(359, 183);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "スタートアップログ";
            // 
            // button_selectSaveDirectory
            // 
            this.button_selectSaveDirectory.Location = new System.Drawing.Point(325, 128);
            this.button_selectSaveDirectory.Name = "button_selectSaveDirectory";
            this.button_selectSaveDirectory.Size = new System.Drawing.Size(21, 23);
            this.button_selectSaveDirectory.TabIndex = 8;
            this.button_selectSaveDirectory.Text = "...";
            this.button_selectSaveDirectory.UseVisualStyleBackColor = true;
            this.button_selectSaveDirectory.Click += new System.EventHandler(this.button_selectSaveDirectory_Click);
            // 
            // textBox_saveDirectory
            // 
            this.textBox_saveDirectory.Enabled = false;
            this.textBox_saveDirectory.Location = new System.Drawing.Point(6, 128);
            this.textBox_saveDirectory.Multiline = true;
            this.textBox_saveDirectory.Name = "textBox_saveDirectory";
            this.textBox_saveDirectory.Size = new System.Drawing.Size(312, 42);
            this.textBox_saveDirectory.TabIndex = 7;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(4, 112);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(153, 12);
            this.label11.TabIndex = 6;
            this.label11.Text = "現在設定されているログフォルダ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(174, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(156, 12);
            this.label8.TabIndex = 3;
            this.label8.Text = "ログファイル名(拡張子を除く)(&Q)";
            // 
            // checkBox_LogEnable
            // 
            this.checkBox_LogEnable.AutoSize = true;
            this.checkBox_LogEnable.Location = new System.Drawing.Point(6, 18);
            this.checkBox_LogEnable.Name = "checkBox_LogEnable";
            this.checkBox_LogEnable.Size = new System.Drawing.Size(153, 16);
            this.checkBox_LogEnable.TabIndex = 1;
            this.checkBox_LogEnable.Text = "接続と同時にログを取る(&G)";
            this.checkBox_LogEnable.UseVisualStyleBackColor = true;
            this.checkBox_LogEnable.CheckedChanged += new System.EventHandler(this.checkBox_LogEnable_CheckedChanged);
            // 
            // panel_logWindowSelect
            // 
            this.panel_logWindowSelect.Controls.Add(this.checkBox_LogBinary);
            this.panel_logWindowSelect.Controls.Add(this.checkBox_LogRx);
            this.panel_logWindowSelect.Controls.Add(this.checkBox_LogTx);
            this.panel_logWindowSelect.Controls.Add(this.label10);
            this.panel_logWindowSelect.Controls.Add(this.textBox_saveFile);
            this.panel_logWindowSelect.Controls.Add(this.label9);
            this.panel_logWindowSelect.Enabled = false;
            this.panel_logWindowSelect.Location = new System.Drawing.Point(29, 40);
            this.panel_logWindowSelect.Name = "panel_logWindowSelect";
            this.panel_logWindowSelect.Size = new System.Drawing.Size(317, 69);
            this.panel_logWindowSelect.TabIndex = 0;
            // 
            // checkBox_LogBinary
            // 
            this.checkBox_LogBinary.AutoSize = true;
            this.checkBox_LogBinary.Location = new System.Drawing.Point(3, 47);
            this.checkBox_LogBinary.Name = "checkBox_LogBinary";
            this.checkBox_LogBinary.Size = new System.Drawing.Size(144, 16);
            this.checkBox_LogBinary.TabIndex = 3;
            this.checkBox_LogBinary.Text = "受信バイナリウインドウ(&E)";
            this.checkBox_LogBinary.UseVisualStyleBackColor = true;
            // 
            // checkBox_LogRx
            // 
            this.checkBox_LogRx.AutoSize = true;
            this.checkBox_LogRx.Location = new System.Drawing.Point(3, 25);
            this.checkBox_LogRx.Name = "checkBox_LogRx";
            this.checkBox_LogRx.Size = new System.Drawing.Size(109, 16);
            this.checkBox_LogRx.TabIndex = 1;
            this.checkBox_LogRx.Text = "受信ウインドウ(&R)";
            this.checkBox_LogRx.UseVisualStyleBackColor = true;
            // 
            // checkBox_LogTx
            // 
            this.checkBox_LogTx.AutoSize = true;
            this.checkBox_LogTx.Location = new System.Drawing.Point(3, 3);
            this.checkBox_LogTx.Name = "checkBox_LogTx";
            this.checkBox_LogTx.Size = new System.Drawing.Size(108, 16);
            this.checkBox_LogTx.TabIndex = 0;
            this.checkBox_LogTx.Text = "送信ウインドウ(&T)";
            this.checkBox_LogTx.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(155, 41);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(75, 12);
            this.label10.TabIndex = 5;
            this.label10.Text = "変換されます。";
            // 
            // textBox_saveFile
            // 
            this.textBox_saveFile.Location = new System.Drawing.Point(147, 7);
            this.textBox_saveFile.Name = "textBox_saveFile";
            this.textBox_saveFile.Size = new System.Drawing.Size(156, 19);
            this.textBox_saveFile.TabIndex = 2;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(155, 29);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(134, 12);
            this.label9.TabIndex = 4;
            this.label9.Text = "%TIME％はログ開始時刻に";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBox_BinaryVisible);
            this.groupBox2.Controls.Add(this.checkBox_RxVisible);
            this.groupBox2.Controls.Add(this.checkBox_TxVisible);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Location = new System.Drawing.Point(286, 20);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(223, 125);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ウィンドウ表示設定";
            // 
            // checkBox_BinaryVisible
            // 
            this.checkBox_BinaryVisible.AutoSize = true;
            this.checkBox_BinaryVisible.Location = new System.Drawing.Point(31, 89);
            this.checkBox_BinaryVisible.Name = "checkBox_BinaryVisible";
            this.checkBox_BinaryVisible.Size = new System.Drawing.Size(143, 16);
            this.checkBox_BinaryVisible.TabIndex = 3;
            this.checkBox_BinaryVisible.Text = "受信バイナリウィンドウ(&B)";
            this.checkBox_BinaryVisible.UseVisualStyleBackColor = true;
            // 
            // checkBox_RxVisible
            // 
            this.checkBox_RxVisible.AutoSize = true;
            this.checkBox_RxVisible.Checked = true;
            this.checkBox_RxVisible.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_RxVisible.Location = new System.Drawing.Point(31, 67);
            this.checkBox_RxVisible.Name = "checkBox_RxVisible";
            this.checkBox_RxVisible.Size = new System.Drawing.Size(107, 16);
            this.checkBox_RxVisible.TabIndex = 2;
            this.checkBox_RxVisible.Text = "受信ウィンドウ(&A)";
            this.checkBox_RxVisible.UseVisualStyleBackColor = true;
            // 
            // checkBox_TxVisible
            // 
            this.checkBox_TxVisible.AutoSize = true;
            this.checkBox_TxVisible.Checked = true;
            this.checkBox_TxVisible.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_TxVisible.Location = new System.Drawing.Point(31, 45);
            this.checkBox_TxVisible.Name = "checkBox_TxVisible";
            this.checkBox_TxVisible.Size = new System.Drawing.Size(106, 16);
            this.checkBox_TxVisible.TabIndex = 1;
            this.checkBox_TxVisible.Text = "送信ウィンドウ(&S)";
            this.checkBox_TxVisible.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(29, 26);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(112, 12);
            this.label12.TabIndex = 0;
            this.label12.Text = "※立ち上げるウィンドウ";
            // 
            // SetUpSerialPort
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 399);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.button_Connect);
            this.Controls.Add(this.comboBox_HandShake);
            this.Controls.Add(this.comboBox_Parity);
            this.Controls.Add(this.comboBox_StopBits);
            this.Controls.Add(this.comboBox_DataBits);
            this.Controls.Add(this.comboBox_BaudRate);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox_PortName);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SetUpSerialPort";
            this.Text = "接続設定ダイアログ";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel_logWindowSelect.ResumeLayout(false);
            this.panel_logWindowSelect.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_PortName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBox_BaudRate;
        private System.Windows.Forms.ComboBox comboBox_DataBits;
        private System.Windows.Forms.ComboBox comboBox_StopBits;
        private System.Windows.Forms.ComboBox comboBox_Parity;
        private System.Windows.Forms.ComboBox comboBox_HandShake;
        private System.Windows.Forms.Button button_Connect;
        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox_saveDirectory;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox_saveFile;
        private System.Windows.Forms.CheckBox checkBox_LogEnable;
        private System.Windows.Forms.Panel panel_logWindowSelect;
        private System.Windows.Forms.CheckBox checkBox_LogRx;
        private System.Windows.Forms.CheckBox checkBox_LogTx;
        private System.Windows.Forms.Button button_selectSaveDirectory;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.CheckBox checkBox_LogBinary;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox checkBox_BinaryVisible;
        private System.Windows.Forms.CheckBox checkBox_RxVisible;
        private System.Windows.Forms.CheckBox checkBox_TxVisible;
        private System.Windows.Forms.Label label12;
    }
}