namespace NanoTerm
{
    partial class FileSender
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileSender));
            this.comboBox_com = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.Line = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Command = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button_fileSelect = new System.Windows.Forms.Button();
            this.textBox_fileName = new System.Windows.Forms.TextBox();
            this.textBox_ms = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button_start = new System.Windows.Forms.Button();
            this.button_stop = new System.Windows.Forms.Button();
            this.button_reset = new System.Windows.Forms.Button();
            this.button_close = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBox_com
            // 
            this.comboBox_com.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_com.FormattingEnabled = true;
            this.comboBox_com.Location = new System.Drawing.Point(51, 11);
            this.comboBox_com.Name = "comboBox_com";
            this.comboBox_com.Size = new System.Drawing.Size(83, 20);
            this.comboBox_com.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "ポート";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "送信ファイル";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(149, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "間隔";
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Line,
            this.Command});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.FullRowSelect = true;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(293, 244);
            this.listView1.TabIndex = 4;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // Line
            // 
            this.Line.Text = "Line";
            this.Line.Width = 73;
            // 
            // Command
            // 
            this.Command.Text = "Command";
            this.Command.Width = 213;
            // 
            // button_fileSelect
            // 
            this.button_fileSelect.Location = new System.Drawing.Point(260, 60);
            this.button_fileSelect.Name = "button_fileSelect";
            this.button_fileSelect.Size = new System.Drawing.Size(20, 23);
            this.button_fileSelect.TabIndex = 5;
            this.button_fileSelect.Text = "...";
            this.button_fileSelect.UseVisualStyleBackColor = true;
            this.button_fileSelect.Click += new System.EventHandler(this.button_fileSelect_Click);
            // 
            // textBox_fileName
            // 
            this.textBox_fileName.Enabled = false;
            this.textBox_fileName.Location = new System.Drawing.Point(14, 60);
            this.textBox_fileName.Multiline = true;
            this.textBox_fileName.Name = "textBox_fileName";
            this.textBox_fileName.Size = new System.Drawing.Size(240, 37);
            this.textBox_fileName.TabIndex = 6;
            // 
            // textBox_ms
            // 
            this.textBox_ms.Location = new System.Drawing.Point(180, 12);
            this.textBox_ms.Name = "textBox_ms";
            this.textBox_ms.Size = new System.Drawing.Size(66, 19);
            this.textBox_ms.TabIndex = 7;
            this.textBox_ms.Text = "1000";
            this.textBox_ms.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_ms_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(251, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "ms";
            // 
            // button_start
            // 
            this.button_start.Location = new System.Drawing.Point(12, 103);
            this.button_start.Name = "button_start";
            this.button_start.Size = new System.Drawing.Size(133, 37);
            this.button_start.TabIndex = 9;
            this.button_start.Text = "送信開始(&S)";
            this.button_start.UseVisualStyleBackColor = true;
            this.button_start.Click += new System.EventHandler(this.button_start_Click);
            this.button_start.MouseEnter += new System.EventHandler(this.button_start_MouseEnter);
            this.button_start.MouseLeave += new System.EventHandler(this.button_start_MouseLeave);
            // 
            // button_stop
            // 
            this.button_stop.Location = new System.Drawing.Point(150, 103);
            this.button_stop.Name = "button_stop";
            this.button_stop.Size = new System.Drawing.Size(130, 37);
            this.button_stop.TabIndex = 10;
            this.button_stop.Text = "一時停止(&H)";
            this.button_stop.UseVisualStyleBackColor = true;
            this.button_stop.Click += new System.EventHandler(this.button_stop_Click);
            this.button_stop.MouseEnter += new System.EventHandler(this.button_stop_MouseEnter);
            this.button_stop.MouseLeave += new System.EventHandler(this.button_stop_MouseLeave);
            // 
            // button_reset
            // 
            this.button_reset.Location = new System.Drawing.Point(12, 146);
            this.button_reset.Name = "button_reset";
            this.button_reset.Size = new System.Drawing.Size(133, 37);
            this.button_reset.TabIndex = 11;
            this.button_reset.Text = "先頭に戻る(&R)";
            this.button_reset.UseVisualStyleBackColor = true;
            this.button_reset.Click += new System.EventHandler(this.button_reset_Click);
            this.button_reset.MouseEnter += new System.EventHandler(this.button_reset_MouseEnter);
            this.button_reset.MouseLeave += new System.EventHandler(this.button_reset_MouseLeave);
            // 
            // button_close
            // 
            this.button_close.Location = new System.Drawing.Point(151, 146);
            this.button_close.Name = "button_close";
            this.button_close.Size = new System.Drawing.Size(130, 37);
            this.button_close.TabIndex = 12;
            this.button_close.Text = "ファイル送信の終了(&X)";
            this.button_close.UseVisualStyleBackColor = true;
            this.button_close.Click += new System.EventHandler(this.button_close_Click);
            this.button_close.MouseEnter += new System.EventHandler(this.button_close_MouseEnter);
            this.button_close.MouseLeave += new System.EventHandler(this.button_close_MouseLeave);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 441);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(293, 23);
            this.statusStrip1.TabIndex = 13;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(134, 18);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.listView1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 197);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(293, 244);
            this.panel1.TabIndex = 14;
            // 
            // FileSender
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(293, 464);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.button_close);
            this.Controls.Add(this.button_reset);
            this.Controls.Add(this.button_stop);
            this.Controls.Add(this.button_start);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox_ms);
            this.Controls.Add(this.textBox_fileName);
            this.Controls.Add(this.button_fileSelect);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox_com);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FileSender";
            this.Text = "ファイル送信ウィンドウ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FileSender_FormClosing);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_com;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader Line;
        private System.Windows.Forms.ColumnHeader Command;
        private System.Windows.Forms.Button button_fileSelect;
        private System.Windows.Forms.TextBox textBox_fileName;
        private System.Windows.Forms.TextBox textBox_ms;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button_start;
        private System.Windows.Forms.Button button_stop;
        private System.Windows.Forms.Button button_reset;
        private System.Windows.Forms.Button button_close;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Panel panel1;
    }
}