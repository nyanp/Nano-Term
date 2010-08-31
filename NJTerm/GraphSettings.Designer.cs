namespace NanoTerm
{
    partial class GraphSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GraphSettings));
            this.textBox_GraphTitle = new System.Windows.Forms.TextBox();
            this.textBox_AxisXTitle = new System.Windows.Forms.TextBox();
            this.textBox_AxisYTitle = new System.Windows.Forms.TextBox();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.button_OK = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_Axis2ndYTitle = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBox_GraphTitle
            // 
            this.textBox_GraphTitle.Location = new System.Drawing.Point(96, 29);
            this.textBox_GraphTitle.Name = "textBox_GraphTitle";
            this.textBox_GraphTitle.Size = new System.Drawing.Size(183, 19);
            this.textBox_GraphTitle.TabIndex = 0;
            // 
            // textBox_AxisXTitle
            // 
            this.textBox_AxisXTitle.Location = new System.Drawing.Point(96, 63);
            this.textBox_AxisXTitle.Name = "textBox_AxisXTitle";
            this.textBox_AxisXTitle.Size = new System.Drawing.Size(183, 19);
            this.textBox_AxisXTitle.TabIndex = 1;
            // 
            // textBox_AxisYTitle
            // 
            this.textBox_AxisYTitle.Location = new System.Drawing.Point(96, 97);
            this.textBox_AxisYTitle.Name = "textBox_AxisYTitle";
            this.textBox_AxisYTitle.Size = new System.Drawing.Size(183, 19);
            this.textBox_AxisYTitle.TabIndex = 2;
            // 
            // button_Cancel
            // 
            this.button_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_Cancel.Location = new System.Drawing.Point(156, 173);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(123, 33);
            this.button_Cancel.TabIndex = 6;
            this.button_Cancel.Text = "キャンセル(&X)";
            this.button_Cancel.UseVisualStyleBackColor = true;
            // 
            // button_OK
            // 
            this.button_OK.Location = new System.Drawing.Point(27, 173);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(123, 33);
            this.button_OK.TabIndex = 5;
            this.button_OK.Text = "OK(&C)";
            this.button_OK.UseVisualStyleBackColor = true;
            this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "グラフタイトル";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "X軸ラベル";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "Y軸ラベル";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 12);
            this.label4.TabIndex = 10;
            this.label4.Text = "第2Y軸ラベル";
            // 
            // textBox_Axis2ndYTitle
            // 
            this.textBox_Axis2ndYTitle.Location = new System.Drawing.Point(96, 132);
            this.textBox_Axis2ndYTitle.Name = "textBox_Axis2ndYTitle";
            this.textBox_Axis2ndYTitle.Size = new System.Drawing.Size(183, 19);
            this.textBox_Axis2ndYTitle.TabIndex = 11;
            // 
            // GraphSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 222);
            this.Controls.Add(this.textBox_Axis2ndYTitle);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.button_OK);
            this.Controls.Add(this.textBox_AxisYTitle);
            this.Controls.Add(this.textBox_AxisXTitle);
            this.Controls.Add(this.textBox_GraphTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GraphSettings";
            this.Text = "グラフの書式設定";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_GraphTitle;
        private System.Windows.Forms.TextBox textBox_AxisXTitle;
        private System.Windows.Forms.TextBox textBox_AxisYTitle;
        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.Button button_OK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_Axis2ndYTitle;
    }
}