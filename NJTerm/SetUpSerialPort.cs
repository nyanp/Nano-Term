using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;

namespace NanoTerm
{
    public partial class SetUpSerialPort : Form
    {
        public SerialPort Port;
        public bool TxLog;
        public bool RxLog;
        public bool BinaryLog = false;
        public bool TxShow;
        public bool RxShow;
        public bool BinaryShow;
        public string BaseFileName;
        public string DirectoryName;

        public SetUpSerialPort(string[] portNames,string baseDirectory)
        {
            InitializeComponent();
            foreach (string port in portNames)
            {
                this.comboBox_PortName.Items.Add(port);
            }
            if (portNames.Count() != 0)
            {
                this.comboBox_PortName.SelectedIndex = 0;
            }

            this.comboBox_BaudRate.Text = NanoTerm.Properties.Settings.Default.NEWPORT_BAUDRATE;
            this.comboBox_DataBits.Text = NanoTerm.Properties.Settings.Default.NEWPORT_DATABITS;
            this.comboBox_HandShake.Text = NanoTerm.Properties.Settings.Default.NEWPORT_HANDSHAKE;
            this.comboBox_Parity.Text = NanoTerm.Properties.Settings.Default.NEWPORT_PARITY;
            this.comboBox_StopBits.Text = NanoTerm.Properties.Settings.Default.NEWPORT_STOPBITS;

            //this.textBox_saveDirectory.Text = baseDirectory;
            this.textBox_saveDirectory.Text = NanoTerm.Properties.Settings.Default.NEWPORT_SAVEDIRECTORY;
            this.checkBox_LogTx.Checked = NanoTerm.Properties.Settings.Default.NEWPORT_SAVETX;
            this.checkBox_LogRx.Checked = NanoTerm.Properties.Settings.Default.NEWPORT_SAVERX;
            this.checkBox_TxVisible.Checked = NanoTerm.Properties.Settings.Default.NEWPORT_TXSHOW;
            this.checkBox_RxVisible.Checked = NanoTerm.Properties.Settings.Default.NEWPORT_RXSHOW;
            this.checkBox_BinaryVisible.Checked = NanoTerm.Properties.Settings.Default.NEWPORT_BINARYSHOW;
            this.checkBox_LogEnable.Checked = NanoTerm.Properties.Settings.Default.NEWPORT_LOGENABLE;

            this.textBox_saveFile.Text = "%TIME%";
        }

        private void button_Connect_Click(object sender, EventArgs e)
        {
            Handshake handShake = Handshake.None;
            int baudRate = 9600;
            Parity parity = Parity.None;
            int dataBits = 8;
            StopBits stopBits = StopBits.One;
            bool rts = false;

            #region{Port Name}
            string portName = this.comboBox_PortName.Text;
            if (portName.Length == 0)
            {
                MessageBox.Show("ポート名を空にすることはできません。");
                return;
            }
            #endregion
            #region{Baud Rate}
            switch (this.comboBox_BaudRate.SelectedIndex)
            {
                case 0:
                    baudRate = 1200;
                    break;
                case 1:
                    baudRate = 4800;
                    break;
                case 2:
                    baudRate = 9600;
                    break;
                case 3:
                    baudRate = 19200;
                    break;
                case 4:
                    baudRate = 38400;
                    break;
                case 5:
                    baudRate = 57600;
                    break;
                case 6:
                    baudRate = 115200;
                    break;
            }
            #endregion
            #region{Data Bits}
            switch (this.comboBox_DataBits.SelectedIndex)
            {
                case 0:
                    dataBits = 8;
                    break;
                case 1:
                    dataBits = 7;
                    break;
                case 2:
                    dataBits = 6;
                    break;
                case 3:
                    dataBits = 5;
                    break;
                case 4:
                    dataBits = 4;
                    break;
            }
            #endregion
            #region{Hand Shake}
            switch (this.comboBox_HandShake.SelectedIndex)
            {
                case 0:
                    handShake = Handshake.None;
                    break;
                case 1:
                    handShake = Handshake.RequestToSend;
                    break;
                case 2:
                    handShake = Handshake.None;
                    rts = true;
                    break;
                case 3:
                    handShake = Handshake.XOnXOff;
                    break;
            }
            #endregion
            #region{Parity}
            switch (this.comboBox_Parity.SelectedIndex)
            {
                case 0:
                    parity = Parity.None;
                    break;
                case 1:
                    parity = Parity.Even;
                    break;
                case 2:
                    parity = Parity.Odd;
                    break;
                case 3:
                    parity = Parity.Space;
                    break;
                case 4:
                    parity = Parity.Mark;
                    break;
            }
            #endregion
            #region{Stop Bits}
            switch (this.comboBox_StopBits.SelectedIndex)
            {
                case 0:
                    stopBits = StopBits.One;
                    break;
                case 1:
                    stopBits = StopBits.OnePointFive;
                    break;
                case 2:
                    stopBits = StopBits.Two;
                    break;
            }
            #endregion

            #region{window view}
            if (checkBox_BinaryVisible.Checked)
            {
                this.BinaryShow = true;
            }
            else
            {
                this.BinaryShow = false;
            }
            if (checkBox_RxVisible.Checked)
            {
                this.RxShow = true;
            }
            else
            {
                this.RxShow = false;
            }
            if (checkBox_TxVisible.Checked)
            {
                this.TxShow = true;
            }
            else
            {
                this.TxShow = false;
            }
            #endregion

            if (this.checkBox_LogEnable.Checked && this.textBox_saveFile.Text.Length == 0)
            {
                MessageBox.Show("ログファイル名を指定してください。");
                return;
            }
            if (this.checkBox_LogEnable.Checked && this.textBox_saveDirectory.Text.Length == 0)
            {
                MessageBox.Show("ログフォルダの設定が不正です。");
                return;
            }
            this.DirectoryName = this.textBox_saveDirectory.Text;
            this.BaseFileName = this.DirectoryName + @"\" + this.textBox_saveFile.Text;
            this.BaseFileName = this.BaseFileName.Replace(@"%TIME%", DateTime.Now.ToString("yyyyMMdd_HHmm"));
            
            this.TxLog = this.checkBox_LogTx.Checked;
            this.RxLog = this.checkBox_LogRx.Checked;

            this.Port = new SerialPort(portName, baudRate, parity, dataBits, stopBits);
            Port.Handshake = handShake;
            Port.DtrEnable = rts;

            NanoTerm.Properties.Settings.Default.NEWPORT_BAUDRATE = this.comboBox_BaudRate.Text;
            NanoTerm.Properties.Settings.Default.NEWPORT_DATABITS = this.comboBox_DataBits.Text;
            NanoTerm.Properties.Settings.Default.NEWPORT_HANDSHAKE = this.comboBox_HandShake.Text;
            NanoTerm.Properties.Settings.Default.NEWPORT_PARITY = this.comboBox_Parity.Text;
            NanoTerm.Properties.Settings.Default.NEWPORT_STOPBITS = this.comboBox_StopBits.Text;
            NanoTerm.Properties.Settings.Default.NEWPORT_SAVERX = this.checkBox_LogRx.Checked;
            NanoTerm.Properties.Settings.Default.NEWPORT_SAVETX = this.checkBox_LogTx.Checked;
            NanoTerm.Properties.Settings.Default.NEWPORT_SAVEDIRECTORY = this.textBox_saveDirectory.Text;
            NanoTerm.Properties.Settings.Default.NEWPORT_BINARYSHOW = this.checkBox_BinaryVisible.Checked;
            NanoTerm.Properties.Settings.Default.NEWPORT_RXSHOW = this.checkBox_RxVisible.Checked;
            NanoTerm.Properties.Settings.Default.NEWPORT_TXSHOW = this.checkBox_TxVisible.Checked;
            NanoTerm.Properties.Settings.Default.NEWPORT_LOGENABLE = this.checkBox_LogEnable.Checked;
            NanoTerm.Properties.Settings.Default.Save();

            this.DialogResult = DialogResult.OK;
        }

        private void button_selectSaveDirectory_Click(object sender, EventArgs e)
        {
            if (this.folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.textBox_saveDirectory.Text = this.folderBrowserDialog1.SelectedPath;
            }
        }

        private void checkBox_LogEnable_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_LogEnable.Checked)
            {
                panel_logWindowSelect.Enabled = true;
            }
            else
            {
                panel_logWindowSelect.Enabled = false;
            }
        }

        //ショートカット処理
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if ((int)keyData == (int)Keys.Alt + (int)Keys.P)
            {
                this.comboBox_PortName.Focus();
                this.comboBox_PortName.DroppedDown = true;
                return true;
            }
            if ((int)keyData == (int)Keys.Alt + (int)Keys.O)
            {
                this.comboBox_BaudRate.Focus();
                this.comboBox_BaudRate.DroppedDown = true;
                return true;
            }
            if ((int)keyData == (int)Keys.Alt + (int)Keys.I)
            {
                this.comboBox_DataBits.Focus();
                this.comboBox_DataBits.DroppedDown = true;
                return true;
            }
            if ((int)keyData == (int)Keys.Alt + (int)Keys.U)
            {
                this.comboBox_StopBits.Focus();
                this.comboBox_StopBits.DroppedDown = true;
                return true;
            }
            if ((int)keyData == (int)Keys.Alt + (int)Keys.Y)
            {
                this.comboBox_Parity.Focus();
                this.comboBox_Parity.DroppedDown = true;
                return true;
            }
            if ((int)keyData == (int)Keys.Alt + (int)Keys.F)
            {
                this.comboBox_HandShake.Focus();
                this.comboBox_HandShake.DroppedDown = true;
                return true;
            }
            if ((int)keyData == (int)Keys.Alt + (int)Keys.Q)
            {
                this.textBox_saveFile.Focus();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

    }
}
