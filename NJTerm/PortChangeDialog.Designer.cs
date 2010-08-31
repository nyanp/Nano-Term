namespace NanoTerm
{
    partial class PortChangeDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PortChangeDialog));
            this.button_AllOK = new System.Windows.Forms.Button();
            this.button_OK = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox_COM = new System.Windows.Forms.ComboBox();
            this.label_COM = new System.Windows.Forms.Label();
            this.label_Series = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.radioButton_Change = new System.Windows.Forms.RadioButton();
            this.radioButton_Ignore = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_AllOK
            // 
            this.button_AllOK.Location = new System.Drawing.Point(12, 212);
            this.button_AllOK.Name = "button_AllOK";
            this.button_AllOK.Size = new System.Drawing.Size(255, 34);
            this.button_AllOK.TabIndex = 0;
            this.button_AllOK.Text = "処理を残り全ての系列にも適用(&A)";
            this.button_AllOK.UseVisualStyleBackColor = true;
            this.button_AllOK.Click += new System.EventHandler(this.button_AllOK_Click);
            // 
            // button_OK
            // 
            this.button_OK.Location = new System.Drawing.Point(12, 252);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(255, 32);
            this.button_OK.TabIndex = 1;
            this.button_OK.Text = "処理をこの系列だけに適用(&C)";
            this.button_OK.UseVisualStyleBackColor = true;
            this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(16, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "系列名:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(16, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "設定ファイルの接続先:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "新しい接続先:";
            // 
            // comboBox_COM
            // 
            this.comboBox_COM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_COM.FormattingEnabled = true;
            this.comboBox_COM.Location = new System.Drawing.Point(117, 38);
            this.comboBox_COM.Name = "comboBox_COM";
            this.comboBox_COM.Size = new System.Drawing.Size(95, 20);
            this.comboBox_COM.TabIndex = 5;
            // 
            // label_COM
            // 
            this.label_COM.AutoSize = true;
            this.label_COM.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label_COM.Location = new System.Drawing.Point(158, 87);
            this.label_COM.Name = "label_COM";
            this.label_COM.Size = new System.Drawing.Size(40, 12);
            this.label_COM.TabIndex = 6;
            this.label_COM.Text = "COM1";
            // 
            // label_Series
            // 
            this.label_Series.AutoSize = true;
            this.label_Series.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label_Series.Location = new System.Drawing.Point(158, 66);
            this.label_Series.Name = "label_Series";
            this.label_Series.Size = new System.Drawing.Size(38, 12);
            this.label_Series.TabIndex = 7;
            this.label_Series.Text = "系列1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(12, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(244, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "以下の系列は現在閉じられているポートを参照して";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(12, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(246, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "います．利用可能なポートを選択しなおして下さい．";
            // 
            // radioButton_Change
            // 
            this.radioButton_Change.AutoSize = true;
            this.radioButton_Change.Checked = true;
            this.radioButton_Change.Location = new System.Drawing.Point(6, 18);
            this.radioButton_Change.Name = "radioButton_Change";
            this.radioButton_Change.Size = new System.Drawing.Size(176, 16);
            this.radioButton_Change.TabIndex = 10;
            this.radioButton_Change.TabStop = true;
            this.radioButton_Change.Text = "利用可能なポートに変更する(&P)";
            this.radioButton_Change.UseVisualStyleBackColor = true;
            this.radioButton_Change.CheckedChanged += new System.EventHandler(this.radioButton_Change_CheckedChanged);
            // 
            // radioButton_Ignore
            // 
            this.radioButton_Ignore.AutoSize = true;
            this.radioButton_Ignore.Location = new System.Drawing.Point(6, 65);
            this.radioButton_Ignore.Name = "radioButton_Ignore";
            this.radioButton_Ignore.Size = new System.Drawing.Size(62, 16);
            this.radioButton_Ignore.TabIndex = 11;
            this.radioButton_Ignore.Text = "無視(&X)";
            this.radioButton_Ignore.UseVisualStyleBackColor = true;
            this.radioButton_Ignore.CheckedChanged += new System.EventHandler(this.radioButton_Ignore_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton_Change);
            this.groupBox1.Controls.Add(this.radioButton_Ignore);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.comboBox_COM);
            this.groupBox1.Location = new System.Drawing.Point(12, 114);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(255, 92);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "系列の処理";
            // 
            // PortChangeDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(279, 296);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label_Series);
            this.Controls.Add(this.label_COM);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_OK);
            this.Controls.Add(this.button_AllOK);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PortChangeDialog";
            this.Text = "ポート接続先の変更";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_AllOK;
        private System.Windows.Forms.Button button_OK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.ComboBox comboBox_COM;
        public System.Windows.Forms.RadioButton radioButton_Change;
        public System.Windows.Forms.RadioButton radioButton_Ignore;
        public System.Windows.Forms.Label label_COM;
        public System.Windows.Forms.Label label_Series;
    }
}