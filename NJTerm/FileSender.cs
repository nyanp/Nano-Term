using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;

namespace NanoTerm
{
    public partial class FileSender : Form
    {
        string path = "";
        System.IO.StreamReader sr;
        public Thread FileSendThread;
        private int index = 0;
        private int sleepMilliSeconds = 0;
        private int com = 0;
        public MainForm pointer;
        private bool enableThread = false;

        public FileSender(string[] PortNames,MainForm Pointer)
        {
            InitializeComponent();
            this.toolStripStatusLabel1.Text = "";
            this.pointer = Pointer;
            this.textBox_fileName.Text = this.pointer.P.SEND_FILE_PATH;
            if (this.textBox_fileName.Text.Length != 0)
            {
                this.path = this.textBox_fileName.Text;
                try
                {
                    this.sr = new System.IO.StreamReader(path, Encoding.GetEncoding("Shift_JIS"));
                    showlist(path);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "ファイル読み込みエラー");
                }
            }

            foreach (string port in PortNames)
            {
                this.comboBox_com.Items.Add(port);
            }
            if (this.comboBox_com.Items.Count > 0)
            {
                this.comboBox_com.SelectedIndex = 0;
            }
        }

        private void button_fileSelect_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.listView1.Items.Clear();
                this.path = this.openFileDialog1.FileName;
                this.textBox_fileName.Text = this.path;
                try
                {
                    this.sr = new System.IO.StreamReader(path, Encoding.GetEncoding("Shift_JIS"));
                    showlist(path);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "ファイル読み込みエラー");
                }
            }
        }

        private void showlist(string path)
        {
            long line = 0;
            while (this.sr.Peek() > -1)
            {
                string[] l = {line.ToString(),sr.ReadLine()};
                this.listView1.Items.Add(new ListViewItem(l));
                line++;
            }
            this.listView1.Items[0].Selected = true;
            this.listView1.Select();
        }

        private void button_start_Click(object sender, EventArgs e)
        {
            if (this.path == "" || this.listView1.Items.Count == 0)
            {
                MessageBox.Show("ファイルが選択されていません．");
                return;
            }
            this.index = this.listView1.SelectedItems[0].Index;
            try
            {
                this.sleepMilliSeconds = int.Parse(this.textBox_ms.Text);
                this.com = MainForm.portNumber(this.comboBox_com.Text);
            }
            catch
            {
                MessageBox.Show("秒数の指定が不正です．");
                return;
            }
            if (this.sleepMilliSeconds < 10)
            {
                MessageBox.Show("送信間隔は10ms以上開けてください．");
                return;
            }
            this.enableThread = true;
            NanoTerm.Properties.Settings.Default.SEND_FILE_PATH = this.path;
            NanoTerm.Properties.Settings.Default.Save();
            this.FileSendThread = new Thread(new ThreadStart(fileSendThread));
            this.FileSendThread.Start();
            this.button_start.Enabled = false;
        }

        private void button_reset_Click(object sender, EventArgs e)
        {
            this.index = 0;
            this.listView1.Items[0].Selected = true;
            this.listView1.Select();
        }

        #region{File Sending Thread}
        private void fileSendThread()
        {
            while (this.enableThread)
            {
                try
                {
                    Thread.Sleep(this.sleepMilliSeconds);
                    if (this.listView1.Items.Count <= this.index)
                    {
                        endFileSendDelegate e = new endFileSendDelegate(endSend);
                        Invoke(e);
                        break;
                    }
                    fileSendDelegate p = new fileSendDelegate(fileSend);
                    Invoke(p);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("fileSendThreadError:" + ex.Message);
                }
            }
            //endFileSendDelegate end = new endFileSendDelegate(endSend);
            //Invoke(end);
        }

        private delegate void endFileSendDelegate();

        private void endSend()
        {
            setMessage("ファイル送信を完了しました．");
            this.button_start.Enabled = true;
        }

        private delegate void fileSendDelegate();

        private void fileSend()
        {
            string command = this.listView1.Items[this.index].SubItems[1].Text;
            this.pointer.Tx_FileSend(command, this.com);
            this.listView1.Items[this.index].Selected = true;
            this.listView1.EnsureVisible(index);
            this.listView1.Select();
            this.index++;
        }

        #endregion

        #region{StatusStrip}

        private void button_start_MouseEnter(object sender, EventArgs e)
        {
            setMessage("ファイルの選択された位置から送信を開始します．");
        }

        private void button_stop_MouseEnter(object sender, EventArgs e)
        {
            setMessage("送信を停止します．");
        }

        private void button_reset_MouseEnter(object sender, EventArgs e)
        {
            setMessage("ファイル先頭に戻ります．");
        }

        private void button_close_MouseEnter(object sender, EventArgs e)
        {
            setMessage("ファイル送信ウィンドウを終了します．");
        }

        private void button_start_MouseLeave(object sender, EventArgs e)
        {
            setMessage("");
        }

        private void button_stop_MouseLeave(object sender, EventArgs e)
        {
            setMessage("");
        }

        private void button_reset_MouseLeave(object sender, EventArgs e)
        {
            setMessage("");
        }

        private void button_close_MouseLeave(object sender, EventArgs e)
        {
            setMessage("");
        }

        #endregion

        private void button_stop_Click(object sender, EventArgs e)
        {
            this.enableThread = false;
            this.button_start.Enabled = true;
        }


        private void setMessage(string Message)
        {
            this.toolStripStatusLabel1.Text = Message;
        }

        private void button_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FileSender_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.enableThread)
            {
                this.enableThread = false;
                Thread.Sleep(this.sleepMilliSeconds);
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count != 0)
            {
                if (this.index != this.listView1.SelectedItems[0].Index)
                {
                    this.index = this.listView1.SelectedItems[0].Index;
                }
            }
        }

        private void textBox_ms_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

    }
}
