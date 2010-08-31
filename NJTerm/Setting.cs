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
    public partial class Setting : Form
    {
        public Params p;

        public Setting(Params p)
        {
            InitializeComponent();
            this.p = p;

            this.checkBox_AUTO_CONNECT.Checked = this.p.AUTO_CONNECT;
            this.checkBox_AUTO_RECONNECT.Checked = this.p.AUTO_RECONNECT;
            this.checkBox_AUTOSAVE.Checked = this.p.AUTO_SAVE;
            this.checkBox_TIMESTAMPRX.Checked = this.p.RX_TIMESTAMP;
            this.checkBox_TIMESTAMPTX.Checked = this.p.TX_TIMESTAMP;
            this.checkBox_SHOW_BINARY.Checked = this.p.BINARY_SHOW;
            this.checkBox_SHOW_RX.Checked = this.p.RX_SHOW;
            this.checkBox_SHOW_TX.Checked = this.p.TX_SHOW;
            this.checkBox_TIMESTAMP_LINEHEAD.Checked = this.p.TIMESTAMP_LINEHEAD;

            if (this.p.RETURN_CODE == "\r")
            {
                this.radioButton_CR.Checked = true;
            }
            else if (this.p.RETURN_CODE == "\n")
            {
                this.radioButton_LF.Checked = true;
            }
            else if (this.p.RETURN_CODE == "\r\n")
            {
                this.radioButton_CRLF.Checked = true;
            }
            if (this.p.SEND_AT_ONCE)
            {
                this.radioButton_SYNC.Checked = true;
            }
            else
            {
                this.radioButton_DELIMITER.Checked = true;
            }
            if (this.p.AUTO_SAVE_FORMOPENING)
            {
                this.panel_autoconnect.Enabled = true;
                this.checkBox_AUTO_CONNECT_FORMOPENING.Checked = true;
            }
            if (this.p.REMOVE_EMPTY_LOG)
            {
                this.checkBox_removeEmptyLog.Checked = true;
            }
            else
            {
                this.checkBox_AUTO_CONNECT_FORMOPENING.Checked = false;
                this.panel_autoconnect.Enabled = false;
            }

            if (this.checkBox_AUTO_CONNECT.Checked || this.checkBox_AUTO_CONNECT_FORMOPENING.Checked)
            {
                this.panel_autoconnect.Enabled = true;
            }
            else
            {
                this.panel_autoconnect.Enabled = false;
            }
            if (this.checkBox_TIMESTAMPRX.Checked)
            {
                this.checkBox_TIMESTAMP_LINEHEAD.Enabled = true;
            }
            else
            {
                this.checkBox_TIMESTAMP_LINEHEAD.Enabled = false;
            }

            this.comboBox_BAUDRATE.Text = this.p.BAUD_RATE.ToString();
            this.comboBox_DataBits.Text = this.p.SERIAL_DATABITS.ToString();
            string parity = "";
            switch (this.p.SERIAL_PARITY)
            {
                case Parity.None:
                    parity = "なし";
                    break;
                case Parity.Even:
                    parity = "偶数";
                    break;
                case Parity.Odd:
                    parity = "奇数";
                    break;
                case Parity.Space:
                    parity = "スペース";
                    break;
                case Parity.Mark:
                    parity = "マーク";
                    break;
            }
            this.comboBox_Parity.Text = parity;

            string stopbits = "";
            switch (this.p.SERIAL_STOPBITS)
            {
                case StopBits.One:
                    stopbits = "1";
                    break;
                case StopBits.OnePointFive:
                    stopbits = "1.5";
                    break;
                case StopBits.Two:
                    stopbits = "2";
                    break;
            }
            this.comboBox_StopBits.Text = stopbits;

            if (this.p.SERIAL_DTR_ENABLE)
            {
                this.comboBox_HandShake.Text = "DTR/DSR";
            }
            else 
            {
                string handshake = "";
                switch (this.p.SERIAL_HANDSHAKE)
                {
                    case Handshake.None:
                        handshake = "なし";
                        break;
                    case Handshake.XOnXOff:
                        handshake = "Xon/Xoff";
                        break;
                    case Handshake.RequestToSend:
                        handshake = "RTS/CTS";
                        break;
                }
                this.comboBox_HandShake.Text = handshake;
            }

            this.comboBox_TIMESTAMP_FORMAT.Text = this.p.TIMESTAMP_FORMAT;
            this.textBox_TIMESTAMP_RATE.Text = this.p.TIMESTAMP_SPAN.TotalMilliseconds.ToString();

            this.comboBox_BAUDRATE.Text = this.p.BAUD_RATE.ToString();
            //this.textBox_RECONNECT_INTERVAL.Text = this.THREAD_RECONNECT_INTERVAL.ToString();
            this.textBox1_SAVE_INTERVAL.Text = this.p.THREAD_SAVELOG_INTERVAL.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //this.THREAD_RECONNECT_INTERVAL = int.Parse(this.textBox_RECONNECT_INTERVAL.Text);
            try
            {
                this.p.THREAD_SAVELOG_INTERVAL = int.Parse(this.textBox1_SAVE_INTERVAL.Text);
            }
            catch
            {
                MessageBox.Show("ログの保存間隔指定が不正です。正しい書式で数値を入力して下さい。", "数値指定エラー");
                return;
            }
            this.p.BAUD_RATE = int.Parse(this.comboBox_BAUDRATE.Text);
            if (this.radioButton_CR.Checked)
            {
                this.p.RETURN_CODE = "\r";
            }
            else if (this.radioButton_LF.Checked)
            {
                this.p.RETURN_CODE = "\n";
            }
            else if (this.radioButton_CRLF.Checked)
            {
                this.p.RETURN_CODE = "\r\n";
            }

            this.p.AUTO_CONNECT = this.checkBox_AUTO_CONNECT.Checked;
            this.p.AUTO_RECONNECT = this.checkBox_AUTO_RECONNECT.Checked;
            this.p.AUTO_SAVE = this.checkBox_AUTOSAVE.Checked;
            this.p.REMOVE_EMPTY_LOG = this.checkBox_removeEmptyLog.Checked;
            this.p.SEND_AT_ONCE = !radioButton_DELIMITER.Checked;
            this.p.TX_TIMESTAMP = checkBox_TIMESTAMPTX.Checked;
            this.p.RX_TIMESTAMP = checkBox_TIMESTAMPRX.Checked;
            this.p.AUTO_SAVE_FORMOPENING = this.checkBox_AUTO_CONNECT_FORMOPENING.Checked;
            this.p.TIMESTAMP_LINEHEAD = this.checkBox_TIMESTAMP_LINEHEAD.Checked;
            this.p.TX_SHOW = this.checkBox_SHOW_TX.Checked;
            this.p.RX_SHOW = this.checkBox_SHOW_RX.Checked;
            this.p.BINARY_SHOW = this.checkBox_SHOW_BINARY.Checked;
            this.p.TIMESTAMP_FORMAT = comboBox_TIMESTAMP_FORMAT.Text;

            try
            {
                this.p.TIMESTAMP_SPAN = new TimeSpan(0, 0, 0, 0, int.Parse(textBox_TIMESTAMP_RATE.Text));
            }
            catch
            {
                MessageBox.Show("タイムスタンプ間隔指定が不正です。正しい書式で数値を入力して下さい。", "数値指定エラー");
                return;
            }

            Handshake handShake = Handshake.None;
            int baudRate = int.Parse(this.comboBox_BAUDRATE.Text);
            Parity parity = Parity.None;
            int dataBits = 8;
            StopBits stopBits = StopBits.One;
            bool rts = false;

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

            this.p.SERIAL_HANDSHAKE = handShake;
            this.p.SERIAL_DTR_ENABLE = rts;
            this.p.SERIAL_DATABITS = dataBits;
            this.p.SERIAL_PARITY = parity;
            this.p.SERIAL_STOPBITS = stopBits;

            if (this.checkBox_saveConfig.Checked)
            {
                NanoTerm.Properties.Settings.Default.AUTO_CONNECT = this.p.AUTO_CONNECT;
                NanoTerm.Properties.Settings.Default.AUTO_RECONNECT = this.p.AUTO_RECONNECT;
                NanoTerm.Properties.Settings.Default.AUTO_SAVE = this.p.AUTO_SAVE;
                NanoTerm.Properties.Settings.Default.BAUD_RATE = this.p.BAUD_RATE;
                NanoTerm.Properties.Settings.Default.MAX_PORT_NUMBER = this.p.MAX_PORT_NUMBER;
                NanoTerm.Properties.Settings.Default.MAX_UPDATE_FREQ = this.p.MAX_UPDATE_FREQ;
                NanoTerm.Properties.Settings.Default.RETURN_CODE = MainForm.NewLineToParam(this.p.RETURN_CODE);
                NanoTerm.Properties.Settings.Default.RX_TIMESTAMP = this.p.RX_TIMESTAMP;
                NanoTerm.Properties.Settings.Default.SEND_AT_ONCE = this.p.SEND_AT_ONCE;
                NanoTerm.Properties.Settings.Default.THREAD_RECONNECT_INTERVAL = this.p.THREAD_RECONNECT_INTERVAL;
                NanoTerm.Properties.Settings.Default.THREAD_SAVELOG_INTERVAL = this.p.THREAD_SAVELOG_INTERVAL;
                NanoTerm.Properties.Settings.Default.TIMESTAMP_FORMAT = this.p.TIMESTAMP_FORMAT;
                NanoTerm.Properties.Settings.Default.TIMESTAMP_SPAN = this.p.TIMESTAMP_SPAN;
                NanoTerm.Properties.Settings.Default.TX_TIMESTAMP = this.p.TX_TIMESTAMP;
                NanoTerm.Properties.Settings.Default.SAVE_PATH = this.p.SAVE_PATH;
                NanoTerm.Properties.Settings.Default.AUTO_CONNECT_FORMOPENING = this.p.AUTO_SAVE_FORMOPENING;
                NanoTerm.Properties.Settings.Default.SERIAL_DATABITS = this.p.SERIAL_DATABITS;
                NanoTerm.Properties.Settings.Default.SERIAL_DTR_ENABLE = this.p.SERIAL_DTR_ENABLE;
                NanoTerm.Properties.Settings.Default.SERIAL_HANDSHAKE = this.p.SERIAL_HANDSHAKE;
                NanoTerm.Properties.Settings.Default.SERIAL_PARITY = this.p.SERIAL_PARITY;
                NanoTerm.Properties.Settings.Default.SERIAL_STOPBITS = this.p.SERIAL_STOPBITS;
                NanoTerm.Properties.Settings.Default.REMOVE_EMPTY_LOG = this.p.REMOVE_EMPTY_LOG;
                NanoTerm.Properties.Settings.Default.TIMESTAMP_LINEHEAD = this.p.TIMESTAMP_LINEHEAD;
                NanoTerm.Properties.Settings.Default.TX_SHOW = this.p.TX_SHOW;
                NanoTerm.Properties.Settings.Default.RX_SHOW = this.p.RX_SHOW;
                NanoTerm.Properties.Settings.Default.BINARY_SHOW = this.p.BINARY_SHOW;
                NanoTerm.Properties.Settings.Default.Save();
            }
        }

        private void textBox1_SAVE_INTERVAL_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private void textBox_RECONNECT_INTERVAL_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_RECONNECT_INTERVAL_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private void textBox_TIMESTAMP_RATE_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private void checkBox_AUTOSAVE_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBox_AUTOSAVE.Checked)
            {
                this.button_SelectSaveFolder.Enabled = true;
            }
            else
            {
                this.button_SelectSaveFolder.Enabled = false;
            }
        }

        private void button_SelectSaveFolder_Click(object sender, EventArgs e)
        {
            if (this.folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                this.p.SAVE_PATH = this.folderBrowserDialog1.SelectedPath;
                this.textBox_SaveFolder.Text = this.p.SAVE_PATH;
            }

        }

        private void checkBox_AUTO_CONNECT_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBox_AUTO_CONNECT.Checked || this.checkBox_AUTO_CONNECT_FORMOPENING.Checked)
            {
                this.panel_autoconnect.Enabled = true;
            }
            else
            {
                this.panel_autoconnect.Enabled = false;
            }
        }

        private void checkBox_AUTO_CONNECT_FORMOPENING_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBox_AUTO_CONNECT.Checked || this.checkBox_AUTO_CONNECT_FORMOPENING.Checked)
            {
                this.panel_autoconnect.Enabled = true;
            }
            else
            {
                this.panel_autoconnect.Enabled = false;
            }
        }

        private void checkBox_TIMESTAMPRX_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBox_TIMESTAMPRX.Checked)
            {
                this.checkBox_TIMESTAMP_LINEHEAD.Enabled = true;
            }
            else
            {
                this.checkBox_TIMESTAMP_LINEHEAD.Enabled = false;
            }
        }
    }
}
