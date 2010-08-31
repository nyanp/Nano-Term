using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms.DataVisualization.Charting;
using System.Collections;
using System.Globalization;
using System.Drawing.Imaging;
using System.Reflection;

namespace NanoTerm
{
    public partial class MainForm : Form
    {
        public SerialPortWindow[] SerialPorts;

        public List<string> LogFiles;

        public class SerialPortWindow
        {
            /// <summary>
            /// COMポートの名称．
            /// </summary>
            public string COM;
            /// <summary>
            /// ハンドルするシリアルポートのインスタンス．
            /// </summary>
            public SerialPort Port;
            /// <summary>
            /// 送信側フォーム．
            /// </summary>
            public Form FormTx;
            /// <summary>
            /// 受信側フォーム．
            /// </summary>
            public Form FormRx;
            /// <summary>
            /// バイナリ受信フォーム．
            /// </summary>
            public Form FormBinary;
            /// <summary>
            /// デフォルトでTxウィンドウを立ち上げるか．
            /// </summary>
            public bool FormTxVisible;
            /// <summary>
            /// デフォルトでRxウィンドウを立ち上げるか．
            /// </summary>
            public bool FormRxVisible;
            /// <summary>
            /// デフォルトでバイナリウィンドウを立ち上げるか．
            /// </summary>
            public bool FormBinaryVisible;
            /// <summary>
            /// 最後に受信側が更新された日時．
            /// </summary>
            public DateTime LastUpdate;
            /// <summary>
            /// ポートが開いてからの総送信バイト数．
            /// </summary>
            public ulong SendBytes;
            /// <summary>
            /// ポートが開いてからの総受信バイト数．
            /// </summary>
            public ulong ReceiveBytes;
            /// <summary>
            /// ポートがフォーカスされているか．
            /// </summary>
            public bool isFocused;
            /// <summary>
            /// ポートが接続されているか．
            /// </summary>
            public bool isConnected;
            /// <summary>
            /// 送信ログファイルストリーム．
            /// </summary>
            public StreamWriter TxFile;
            /// <summary>
            /// 受信ログファイルストリーム．
            /// </summary>
            public StreamWriter RxFile;
            /// <summary>
            /// 受信バイナリログファイルストリーム．
            /// </summary>
            public StreamWriter BinaryFile;
            /// <summary>
            /// 送信ウインドウのログファイル名．
            /// </summary>
            public string TxFileName;
            /// <summary>
            /// 受信ウインドウのログファイル名．
            /// </summary>
            public string RxFileName;
            /// <summary>
            /// 受信バイナリウインドウのログファイル名．
            /// </summary>
            public string BinaryFileName;
            /// <summary>
            /// 送信ログを取るか．
            /// </summary>
            public bool TxLogEnable;
            /// <summary>
            /// 受信ログを取るか．
            /// </summary>
            public bool RxLogEnable;
            /// <summary>
            /// 受信バイナリログを取るか．
            /// </summary>
            public bool BinaryLogEnable;
            /// <summary>
            /// Txの送信をバイナリで送るか．
            /// </summary>
            public bool TxBinaryMode;
            /// <summary>
            /// 送信ログファイルの記録済み位置．
            /// </summary>
            public ulong TxLogIndex;
            /// <summary>
            /// 受信ログファイルの記録済み位置．
            /// </summary>
            public ulong RxLogIndex;
            /// <summary>
            /// 受信バイナリファイルの記録済み位置．
            /// </summary>
            public ulong BinaryLogIndex;
            /// <summary>
            /// 送信側最終タイムスタンプ日時．
            /// </summary>
            public DateTime TxLastTimeStamp;
            /// <summary>
            /// 受信側最終タイムスタンプ日時．
            /// </summary>
            public DateTime RxLastTimeStamp;
            /// <summary>
            /// グラフ描画用インデックス．
            /// </summary>
            public ulong DrawedIndex;
            /// <summary>
            /// デリミタの文字列．
            /// </summary>
            public string ReturnCode;
            /// <summary>
            /// 文字列を入力と同時に送信．
            /// </summary>
            public bool SendSoon;
            /// <summary>
            /// 送信側にタイムスタンプを使用するか
            /// </summary>
            public bool TxTimeStamp;
            /// <summary>
            /// 受信側にタイムスタンプを使用するか
            /// </summary>
            public bool RxTimeStamp;
            /// <summary>
            /// ポートをOpen/Closeした最後の日時．
            /// </summary>
            public DateTime ConnectedStateusLastUpdate;

            public SerialPortWindow()
            {
                this.ReturnCode = ParamToNewLine(NanoTerm.Properties.Settings.Default.RETURN_CODE.Trim(' '));
                this.SendSoon = NanoTerm.Properties.Settings.Default.SEND_AT_ONCE;
                this.TxTimeStamp = NanoTerm.Properties.Settings.Default.TX_TIMESTAMP;
                this.RxTimeStamp = NanoTerm.Properties.Settings.Default.RX_TIMESTAMP;
            }
            public SerialPortWindow(string returnCode, bool sendSoon, bool TxTimestamp, bool RxTimestamp)
            {
                this.ReturnCode = returnCode;
                this.SendSoon = sendSoon;
                this.TxTimeStamp = TxTimestamp;
                this.RxTimeStamp = RxTimestamp;
            }
        }

        public struct ListViewAutoSave
        {
            public int Columns;
            public string FileHeadName;
            public string Folder;
            public int CurrentIndex;
            public bool AutoSaveSettingDone;
        }

        public struct WindowFormatter
        {
            public int TabControlHeightToForm;
            public int ChartControlHeightToForm;
            public int ListViewControlHeightToForm;
        }

        private int windowHeight;
        private int windowWidth;
        private Thread PortChecker;
        private Thread BackUpSaver;
        private Thread GraphDraw;
        private Thread DummyDataDraw;
        public Params P;
        private Hashtable DataSeries;
        private DateTime FirstPlotTime;
        private ListViewAutoSave ListViewSaver;
        private KeysConverter kv;
        private WindowFormatter Format;
        private readonly Font BaseFont = new Font("ＭＳ ゴシック", 10);
        private readonly int minimumFontSize = 6;
        private readonly int maximumFontSize = 32;

        private bool endSaveThread = false;

        private string workingDirectory;

        public readonly MarkerStyle dafaultMarkerStyle = MarkerStyle.Square;
        public readonly int defaultMarkerSize = 5;

        public MainForm()
        {
            try
            {
                InitializeComponent();

                this.Text += " Ver" + Application.ProductVersion;

                this.IsMdiContainer = true;
                System.Threading.Thread.CurrentThread.Name = "メインスレッド";

                this.Format = new WindowFormatter();
                this.Format.ChartControlHeightToForm = this.Height - this.chart1.Height;
                this.Format.ListViewControlHeightToForm = this.Height - this.listView1.Height;
                this.Format.TabControlHeightToForm = this.Height - this.tabControl1.Height;

                int height = NanoTerm.Properties.Settings.Default.FORM_HEIGHT;
                int width = NanoTerm.Properties.Settings.Default.FORM_WIDTH;
                if (NanoTerm.Properties.Settings.Default.FORM_WINDOWSTATE != FormWindowState.Minimized)
                {
                    this.WindowState = NanoTerm.Properties.Settings.Default.FORM_WINDOWSTATE;
                }
                if (height > 0 && width > 0)
                {
                    this.Height = height;
                    this.Width = width;
                }

                this.windowHeight = (int)((this.tabControl1.Height - this.statusStrip1.Height - 8) * 0.5);
                this.windowWidth = this.tabControl1.Width - 8;

                this.kv = new KeysConverter();
                //this.SerialPortsList = new List<SerialPortWindow>();
                this.DataSeries = new Hashtable();
                //this.CapturedDataPairs = new List<Plot>();

                this.fontDialog1.Font = this.BaseFont;

                SetParams();

                //保存パスが指定されていない時はカレントディレクトリを指定
                if (P.SAVE_PATH.Length == 0)
                {
                    P.SAVE_PATH = System.IO.Directory.GetCurrentDirectory();
                }

                this.workingDirectory = P.SAVE_PATH;

                #region{グラフ種類選択ComboBoxにデータとアイコンを追加}
                this.comboBox_Graph_Type.DrawMode = DrawMode.OwnerDrawFixed;
                DataTable table = new DataTable();
                //テーブルにValueMemberとDisplayMemberの列とイメージの列を追加
                table.Columns.Add("ValueMember", typeof(SeriesChartType));//ValueMember（項目の値）
                table.Columns.Add("DisplayMember", typeof(string)); //DisplayMember（項目の表示名）
                table.Columns.Add("Image", typeof(Image));  //項目のイメージ

                Assembly asm = Assembly.GetExecutingAssembly();

                table.Rows.Add(SeriesChartType.FastPoint, "散布図", new Bitmap(asm.GetManifestResourceStream("NanoTerm.Images.point.BMP")));
                table.Rows.Add(SeriesChartType.FastLine, "折れ線（マーカーなし）", new Bitmap(asm.GetManifestResourceStream("NanoTerm.Images.fastline.BMP")));
                table.Rows.Add(SeriesChartType.Line, "折れ線（マーカー有り）", new Bitmap(asm.GetManifestResourceStream("NanoTerm.Images.line.BMP")));
                table.Rows.Add(SeriesChartType.Spline, "線（スムージング）", new Bitmap(asm.GetManifestResourceStream("NanoTerm.Images.spline.BMP")));
                table.Rows.Add(SeriesChartType.StepLine, "ステップ", new Bitmap(asm.GetManifestResourceStream("NanoTerm.Images.stepline.BMP")));
                table.Rows.Add(SeriesChartType.Column, "棒", new Bitmap(asm.GetManifestResourceStream("NanoTerm.Images.column.BMP")));

                this.comboBox_Graph_Type.ValueMember = "ValueMember";
                this.comboBox_Graph_Type.DisplayMember = "DisplayMember";
                this.comboBox_Graph_Type.DataSource = table;
                #endregion

                this.toolStripStatusLabel2.Text = this.P.THREAD_DRAWGRAPH_INTERVAL.ToString() + "ms毎に更新";
                this.toolStripStatusLabel1.Text = "";
                this.toolStripStatusLabel3.Text = "";
                this.toolStripStatusLabel4.Text = "";
                this.toolStripStatusLabel5.Text = "";
                this.label.Text = "";

                this.LogFiles = new List<string>();
                this.SerialPorts = new SerialPortWindow[P.MAX_PORT_NUMBER];
                for (int i = 0; i < P.MAX_PORT_NUMBER; i++)
                {
                    this.SerialPorts[i] = new SerialPortWindow();
                }

                this.comboBox_Graph_Type.SelectedIndex = 2;
                this.comboBox_graph_x_from.SelectedIndex = 0;
                this.ListViewSaver.CurrentIndex = 1;
                this.ListViewSaver.AutoSaveSettingDone = false;

                if (P.AUTO_SAVE_FORMOPENING)
                {
                    string[] ports = SerialPort.GetPortNames();
                    foreach (string port in ports)
                    {
                        openPort(port);
                    }
                    updateStatusStrip("ポートの自動接続が実行されました．起動時の設定を変更するには「編集」→「ターミナルと自動保存の設定」を実行してください．");
                }


                this.tabControl1.Height = this.Height - Format.TabControlHeightToForm;
                this.chart1.Height = this.Height - Format.ChartControlHeightToForm;
                this.listView1.Height = this.Height - Format.ListViewControlHeightToForm;
                resizeWindows();

                this.PortChecker = new Thread(new ThreadStart(portWatchThread));
                this.PortChecker.Name = "COM Port Watcher";
                this.PortChecker.Start();

                this.BackUpSaver = new Thread(new ThreadStart(saveLogThread));
                this.BackUpSaver.Name = "File Saver";
                this.BackUpSaver.Start();

                this.GraphDraw = new Thread(new ThreadStart(updateGraphThread));
                this.GraphDraw.Name = "Graph Updater";
                this.GraphDraw.Start();

                //this.ToolStripMenuItem_Dummydata.Enabled = false;

                //this.DummyDataDraw = new Thread(new ThreadStart(addDummyThread));
                //this.DummyDataDraw.Name = "Dummy Data Controller";
                //this.DummyDataDraw.Start();
            }
            catch (Exception e)
            {
                MessageBox.Show("初期化エラー："+e.Message);
            }
        }

        /// <summary>
        /// ポートを開きます。新規にSerialPortWindow,SerialPortインスタンスを生成し、ログファイルはP.AUTO_SAVE,P.SAVE_PATHに従います
        /// </summary>
        /// <param name="port">”COM1”等の書式で表されるシリアルポート名。</param>
        private void openPort(string port)
        {
            openPort(port, P.AUTO_SAVE, P.AUTO_SAVE, P.AUTO_SAVE, P.TX_SHOW, P.RX_SHOW, P.BINARY_SHOW);
        }

        /// <summary>
        /// ポートを開きます。新規にSerialPortWindow,SerialPortインスタンスを生成し、ログファイルはP.SAVE_PATHに生成されます
        /// </summary>
        /// <param name="port">”COM1”等の書式で表されるシリアルポート名。</param>
        /// <param name="TxLog">TXウインドウのログを取るか。</param>
        /// <param name="RxLog">RXウインドウのログを取るか。</param>
        private void openPort(string port, bool TxLog, bool RxLog, bool BinaryLog, bool TxShow, bool RxShow, bool BinaryShow)
        {
            #region{ポート接続}
            SerialPort Port = new SerialPort();
            bool connectError = false;
            try
            {
                Port.BaudRate = this.P.BAUD_RATE;
                Port.PortName = port;
                Port.Parity = this.P.SERIAL_PARITY;
                Port.DataBits = this.P.SERIAL_DATABITS;
                Port.StopBits = this.P.SERIAL_STOPBITS;
                Port.Handshake = this.P.SERIAL_HANDSHAKE;
                Port.DtrEnable = this.P.SERIAL_DTR_ENABLE;
                Port.Encoding = Encoding.ASCII;
                Port.ReadTimeout = -1;
                Port.NewLine = P.RETURN_CODE;
                Port.Open();
            }
            catch (Exception e)
            {
                MessageBox.Show("ポートを開けません:" + e.Message);
                connectError = true;
            }

            #endregion

            openPort(Port, connectError, TxLog, RxLog, BinaryLog, TxShow, RxShow, BinaryShow);
        }

        /// <summary>
        /// ポートを開きます。新規にSerialPortWindowインスタンスを生成してSerialPortをセットし、ログファイルはP.SAVE_PATHに生成されます
        /// </summary>
        /// <param name="Port">セットするSerialPortインスタンス。</param>
        /// <param name="connectError">接続失敗かどうか。</param>
        /// <param name="TxLog">TXウインドウのログを取るか。</param>
        /// <param name="RxLog">RXウインドウのログを取るか。</param>
        private void openPort(SerialPort Port, bool connectError, bool TxLog, bool RxLog, bool BinaryLog, bool TxShow, bool RxShow, bool BinaryShow)
        {
            openPort(Port, connectError, TxLog, RxLog, BinaryLog, TxShow, RxShow, BinaryShow, P.SAVE_PATH + "\\" + DateTime.Now.ToString("yyyyMMdd_HHmm") + "_" + Port.PortName);
        }

        /// <summary>
        /// ポートを開きます。新規にSerialPortWindowインスタンスを生成してSerialPortをセットし、ログファイルは指定ディレクトリに生成されます
        /// </summary>
        /// <param name="Port">セットするSerialPortインスタンス。</param>
        /// <param name="connectError">接続失敗かどうか。</param>
        /// <param name="TxLog">TXウインドウのログを取るか。</param>
        /// <param name="RxLog">RXウインドウのログを取るか。</param>
        /// <param name="baseFileName">Tx,Rxファイルを保存するディレクトリ＋拡張子を除く基本ファイル名。</param>
        private void openPort(SerialPort Port, bool connectError, bool TxLog, bool RxLog, bool BinaryLog, bool TxShow, bool RxShow, bool BinaryShow, string baseFileName)
        {
            try
            {
                SerialPortWindow window = new SerialPortWindow();
                window.LastUpdate = DateTime.Now;
                window.COM = Port.PortName;
                window.TxLogEnable = TxLog;
                window.RxLogEnable = RxLog;
                window.BinaryLogEnable = BinaryLog;
                window.FormTxVisible = TxShow;
                window.FormRxVisible = RxShow;
                window.FormBinaryVisible = BinaryShow;
                window.TxBinaryMode = false;

                if (TxLog)
                {
                    string TxLogFileName = baseFileName + "_Tx.txt";
                    try
                    {
                        window.TxFile = new StreamWriter(TxLogFileName, false, Encoding.GetEncoding("Shift_JIS"));
                        window.TxFileName = TxLogFileName;
                        this.LogFiles.Add(TxLogFileName);
                    }
                    #region{StreamWriter用例外処理ブロック}
                    catch (UnauthorizedAccessException)
                    {
                        MessageBox.Show("ログファイルの生成に失敗しました。設定されたパスにアクセスする権限があるか確認して下さい。\n\n"+ TxLogFileName, "ファイル新規作成時エラー");
                        window.TxFile = null;
                        window.TxLogEnable = false;
                    }
                    catch (ArgumentException)
                    {
                        MessageBox.Show("ログファイルの生成に失敗しました。ファイル名が空の文字列でないか確認して下さい。\n\n" + TxLogFileName, "ファイル新規作成時エラー");
                        window.TxFile = null;
                        window.TxLogEnable = false;
                    }
                    catch (PathTooLongException)
                    {
                        MessageBox.Show("ログファイルの生成に失敗しました。指定したパス、ファイル名、またはその両方がシステム定義の最大長を超えています。\n\n" + TxLogFileName, "ファイル新規作成時エラー");
                        window.TxFile = null;
                        window.TxLogEnable = false;
                    }
                    catch (IOException)
                    {
                        MessageBox.Show("ログファイルの生成に失敗しました。ファイル名、ディレクトリ名、またはボリューム ラベルの不正な構文または無効な構文が含まれています。\n\n" + TxLogFileName, "ファイル新規作成時エラー");
                        window.TxFile = null;
                        window.TxLogEnable = false;
                    }
                    #endregion
                }
                if (RxLog)
                {
                    string RxLogFileName = baseFileName + "_Rx.txt";
                    try
                    {
                        window.RxFile = new StreamWriter(RxLogFileName, false, Encoding.GetEncoding("Shift_JIS"));
                        window.RxFileName = RxLogFileName;
                        this.LogFiles.Add(RxLogFileName);
                    }
                    #region{StreamWriter用例外処理ブロック}
                    catch (UnauthorizedAccessException)
                    {
                        MessageBox.Show("ログファイルの生成に失敗しました。設定されたパスにアクセスする権限があるか確認して下さい。\n\n" + RxLogFileName, "ファイル新規作成時エラー");
                        window.RxFile = null;
                        window.RxLogEnable = false;
                    }
                    catch (ArgumentException)
                    {
                        MessageBox.Show("ログファイルの生成に失敗しました。ファイル名が空の文字列でないか確認して下さい。\n\n" + RxLogFileName, "ファイル新規作成時エラー");
                        window.RxFile = null;
                        window.RxLogEnable = false;
                    }
                    catch (PathTooLongException)
                    {
                        MessageBox.Show("ログファイルの生成に失敗しました。指定したパス、ファイル名、またはその両方がシステム定義の最大長を超えています。\n\n" + RxLogFileName, "ファイル新規作成時エラー");
                        window.RxFile = null;
                        window.RxLogEnable = false;
                    }
                    catch (IOException)
                    {
                        MessageBox.Show("ログファイルの生成に失敗しました。ファイル名、ディレクトリ名、またはボリューム ラベルの不正な構文または無効な構文が含まれています。\n\n" + RxLogFileName, "ファイル新規作成時エラー");
                        window.RxFile = null;
                        window.RxLogEnable = false;
                    }
                    #endregion
                }
                if (BinaryLog)
                {
                    string BinaryLogFileName = baseFileName + "_Bin.txt";
                    try
                    {
                        window.BinaryFile = new StreamWriter(BinaryLogFileName, false, Encoding.GetEncoding("Shift_JIS"));
                        window.BinaryFileName = BinaryLogFileName;
                        this.LogFiles.Add(BinaryLogFileName);
                    }
                    #region{StreamWriter用例外処理ブロック}
                    catch (UnauthorizedAccessException)
                    {
                        MessageBox.Show("ログファイルの生成に失敗しました。設定されたパスにアクセスする権限があるか確認して下さい。\n\n" + BinaryLogFileName, "ファイル新規作成時エラー");
                        window.BinaryFile = null;
                        window.BinaryLogEnable = false;
                    }
                    catch (ArgumentException)
                    {
                        MessageBox.Show("ログファイルの生成に失敗しました。ファイル名が空の文字列でないか確認して下さい。\n\n" + BinaryLogFileName, "ファイル新規作成時エラー");
                        window.BinaryFile = null;
                        window.BinaryLogEnable = false;
                    }
                    catch (PathTooLongException)
                    {
                        MessageBox.Show("ログファイルの生成に失敗しました。指定したパス、ファイル名、またはその両方がシステム定義の最大長を超えています。\n\n" + BinaryLogFileName, "ファイル新規作成時エラー");
                        window.BinaryFile = null;
                        window.BinaryLogEnable = false;
                    }
                    catch (IOException)
                    {
                        MessageBox.Show("ログファイルの生成に失敗しました。ファイル名、ディレクトリ名、またはボリューム ラベルの不正な構文または無効な構文が含まれています。\n\n" + BinaryLogFileName, "ファイル新規作成時エラー");
                        window.BinaryFile = null;
                        window.BinaryLogEnable = false;
                    }
                    #endregion
                }

                window.BinaryLogIndex = 0;
                window.RxLogIndex = 0;
                window.TxLogIndex = 0;
                window.ReceiveBytes = 0;
                window.SendBytes = 0;
                window.isConnected = !connectError;
                window.TxLastTimeStamp = DateTime.Now;
                window.RxLastTimeStamp = DateTime.Now;
                for (int i = 0; i < P.MAX_PORT_NUMBER; i++)
                {
                    this.SerialPorts[i].isFocused = false;
                }
                window.isFocused = true;
                window.Port = Port;
                window.DrawedIndex = 0;
                if (portNumber(Port.PortName) < P.MAX_PORT_NUMBER)
                {
                    this.SerialPorts[portNumber(Port.PortName)] = window;
                }

                openWindow(Port.PortName, Port, ref window, connectError);

                //this.SerialPortsList.Add(window);

                resizeWindows();

                //ウィンドウ作成が終わってから受信開始
                Port.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
                Port.PinChanged += new SerialPinChangedEventHandler(this.serialPort1_PinChanged);
            }
            catch (Exception)
            {

            }
        }

        private void openWindow(string port, SerialPort Port, ref SerialPortWindow serialPorts, bool connectError)
        {
            try
            {
                #region{ウインドウ接続}
                //窓サイズをシリアルポート数で分割
                this.windowWidth = (int)(this.tabPage1.Width / (1 + getActiveSerialPortWindows()));

                #region{Tx}
                if (serialPorts.FormTxVisible && (serialPorts.FormTx == null || serialPorts.FormTx.Visible == false))
                {
                    Form FormTx = new Form();
                    TextBox Tx = new TextBox();

                    FormTx.Icon = this.Icon;
                    FormTx.TopLevel = false ;

                    FormTx.Width = this.windowWidth;
                    FormTx.Height = this.windowHeight;
                    FormTx.Text = getFormTitle(port, FormType.Tx, serialPorts.TxFileName, Port.BaudRate, connectError, Port.IsOpen, Tx);
                    FormTx.MaximizeBox = false;
                    FormTx.MinimizeBox = false;
                    FormTx.AutoScroll = true;
                    FormTx.Left = 0;
                    FormTx.Top = 0;
                    FormTx.Tag = portNumber(port);
                    FormTx.FormClosing += new FormClosingEventHandler(serialWindow_FormClosing);
                    this.toolTip1.SetToolTip(FormTx, FormTx.Text);
                    Tx.Font = this.BaseFont;
                    Tx.Tag = portNumber(port);
                    Tx.KeyDown += new KeyEventHandler(Tx_KeyDown);
                    Tx.KeyPress += new KeyPressEventHandler(Tx_KeyPress);
                    Tx.Multiline = true;
                    FormTx.Controls.Add(Tx);
                    Tx.Dock = DockStyle.Fill;
                    Tx.MaxLength = 0;
                    Tx.ScrollBars = ScrollBars.Vertical;
                    Tx.MouseDown += new MouseEventHandler(Tx_MouseDown);
                    Tx.Click += new EventHandler(Port_OnClick);
                    Tx.DragDrop += new DragEventHandler(Port_DragDrop);
                    Tx.DragEnter += new DragEventHandler(Port_DragEnter);
                    Tx.AllowDrop = true;

                    this.tabPage1.Controls.Add(FormTx);
                    FormTx.Show();
                    FormTx.BringToFront();
                    serialPorts.FormTx = FormTx;
                    serialPorts.TxLogIndex = 0;
                }
                #endregion

                #region{Rx}
                if (serialPorts.FormRxVisible && (serialPorts.FormRx == null || serialPorts.FormRx.Visible == false))
                {
                    Form FormRx = new Form();
                    TextBox Rx = new TextBox();

                    FormRx.Icon = this.Icon;
                    FormRx.TopLevel = false;
                    FormRx.Width = this.windowWidth;
                    FormRx.Height = this.windowHeight;
                    FormRx.Tag = portNumber(port);
                    FormRx.FormClosing += new FormClosingEventHandler(serialWindow_FormClosing);
                    FormRx.Text = getFormTitle(port, FormType.Rx, serialPorts.RxFileName, Port.BaudRate, connectError, Port.IsOpen, Rx);
                    FormRx.MaximizeBox = false;
                    FormRx.MinimizeBox = false;
                    FormRx.AutoScroll = true;
                    FormRx.Left = 0;
                    FormRx.Top = this.windowHeight;
                    this.toolTip1.SetToolTip(FormRx, FormRx.Text);
                    Rx.Font = this.BaseFont;
                    Rx.Tag = portNumber(port);
                    Rx.Multiline = true;
                    Rx.ReadOnly = true;
                    FormRx.Controls.Add(Rx);
                    Rx.Dock = DockStyle.Fill;
                    Rx.MaxLength = 0;
                    Rx.ScrollBars = ScrollBars.Vertical;
                    Rx.MouseDown += new MouseEventHandler(Rx_MouseDown);
                    Rx.Click += new EventHandler(Port_OnClick);
                    Rx.DragDrop += new DragEventHandler(Port_DragDrop);
                    Rx.DragEnter += new DragEventHandler(Port_DragEnter);
                    Rx.AllowDrop = true;

                    this.tabPage1.Controls.Add(FormRx);
                    FormRx.Show();
                    FormRx.BringToFront();
                    serialPorts.FormRx = FormRx;
                    serialPorts.RxLogIndex = 0;
                    serialPorts.DrawedIndex = 0;
                }
                #endregion

                #region{Rx Binary}
                if (serialPorts.FormBinaryVisible && (serialPorts.FormBinary == null || serialPorts.FormBinary.Visible == false))
                {
                    Form FormBinary = new Form();
                    TextBox Binary = new TextBox();

                    FormBinary.Icon = this.Icon;
                    FormBinary.TopLevel = false;
                    FormBinary.Width = this.windowWidth;
                    FormBinary.Height = this.windowHeight;
                    FormBinary.Tag = portNumber(port);
                    FormBinary.FormClosing += new FormClosingEventHandler(serialWindow_FormClosing);
                    FormBinary.Text = getFormTitle(port, FormType.Binary, serialPorts.BinaryFileName, Port.BaudRate, connectError, Port.IsOpen, Binary);
                    FormBinary.MaximizeBox = false;
                    FormBinary.MinimizeBox = false;
                    FormBinary.AutoScroll = true;
                    FormBinary.Left = 0;
                    FormBinary.Top = this.windowHeight;
                    this.toolTip1.SetToolTip(FormBinary, FormBinary.Text);
                    Binary.Font = this.BaseFont;
                    Binary.Tag = portNumber(port);
                    Binary.Multiline = true;
                    Binary.ReadOnly = true;
                    FormBinary.Controls.Add(Binary);
                    Binary.Dock = DockStyle.Fill;
                    Binary.MaxLength = 0;
                    Binary.ScrollBars = ScrollBars.Vertical;
                    Binary.MouseDown += new MouseEventHandler(Rx_MouseDown);
                    Binary.Click += new EventHandler(Port_OnClick);
                    Binary.DragDrop += new DragEventHandler(Port_DragDrop);
                    Binary.DragEnter += new DragEventHandler(Port_DragEnter);
                    Binary.AllowDrop = true;

                    this.tabPage1.Controls.Add(FormBinary);
                    FormBinary.Show();
                    FormBinary.BringToFront();
                    serialPorts.FormBinary = FormBinary;
                    serialPorts.BinaryLogIndex = 0;
                }
                #endregion

                #endregion
                this.SerialPorts[portNumber(serialPorts.COM)].FormTx.Controls[0].Focus();
                activateWindow(this.SerialPorts[portNumber(serialPorts.COM)]);
            }
            catch (Exception ex)
            {
                Console.WriteLine("error at openWindow:" + ex.Message);
            }
        }

        private void reconnectPort(string port)
        {
            try
            {
                int BaudRate = this.SerialPorts[portNumber(port)].Port.BaudRate;
                this.SerialPorts[portNumber(port)].Port.Dispose();
                SerialPort Port = new SerialPort();
                try
                {
                    Port.BaudRate = this.P.BAUD_RATE;
                    Port.PortName = port;
                    Port.Parity = this.P.SERIAL_PARITY;
                    Port.DataBits = this.P.SERIAL_DATABITS;
                    Port.StopBits = this.P.SERIAL_STOPBITS;
                    Port.Handshake = this.P.SERIAL_HANDSHAKE;
                    Port.DtrEnable = this.P.SERIAL_DTR_ENABLE;
                    Port.Encoding = Encoding.ASCII;
                    Port.ReadTimeout = -1;
                    Port.NewLine = P.RETURN_CODE;
                    Port.Open();
                }
                catch (Exception)
                {
                    this.SerialPorts[portNumber(port)].Port = Port;
                    return;
                    //MessageBox.Show("reconnectPortError:"+e.Message);
                }
                this.SerialPorts[portNumber(port)].FormTx.Text = Port.PortName + " 送信ウィンドウ(" + Port.BaudRate + "Bps)";
                this.SerialPorts[portNumber(port)].FormRx.Text = Port.PortName + " 受信ウィンドウ(" + Port.BaudRate + "Bps)";
                if (this.P.AUTO_SAVE)
                {
                    string path = P.SAVE_PATH + this.SerialPorts[portNumber(port)].TxFileName;
                    if (P.SAVE_PATH.Length == 0)
                    {
                        path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + this.SerialPorts[portNumber(port)].TxFileName;
                    }
                    this.SerialPorts[portNumber(port)].FormTx.Text += "　ログ：" + path;
                    path = P.SAVE_PATH + this.SerialPorts[portNumber(port)].RxFileName;
                    if (P.SAVE_PATH.Length == 0)
                    {
                        path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + this.SerialPorts[portNumber(port)].RxFileName;
                    }
                    this.SerialPorts[portNumber(port)].FormRx.Text += "　ログ：" + path;
                }
                else
                {
                    this.SerialPorts[portNumber(port)].FormTx.Text += "ログはとっていません";
                    this.SerialPorts[portNumber(port)].FormRx.Text += "ログはとっていません";
                }
                this.SerialPorts[portNumber(port)].isConnected = true;
                //ウィンドウ作成が終わってから受信開始
                Port.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
                Port.PinChanged += new SerialPinChangedEventHandler(this.serialPort1_PinChanged);
                this.SerialPorts[portNumber(port)].Port = Port;
            }
            catch(Exception ex)
            {
                Console.WriteLine("error at reconnectport:" + ex.Message);
            }
        }

        private void sendString(SerialPort port, string text)
        {
            try
            {
                if (port.IsOpen)
                {
                    port.WriteLine(text);
                }
            }
            catch (Exception)
            {
                //MessageBox.Show("sendStringError:" + e.Message, "データ送信エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void sendByte(SerialPort port, byte[] buffer)
        {
            try
            {
                if (port.IsOpen)
                {
                    port.Write(buffer, 0, buffer.Count());
                }
            }
            catch
            {

            }
        }

        private void sendStringWithoutNewLine(SerialPort port, string text)
        {
            try
            {
                if (port.IsOpen)
                {
                    port.Write(text);
                }
            }
            catch (Exception)
            {
                //MessageBox.Show("sendStringError:" + e.Message, "データ送信エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region{シリアルポートからの受信（別スレッドで実行）}
        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {

                string thread = System.Threading.Thread.CurrentThread.Name;
                SerialPort port = (SerialPort)sender;
                string portName = ((SerialPort)sender).PortName;

                TimeSpan ts = DateTime.Now - this.SerialPorts[portNumber(portName)].LastUpdate;
                if (ts.CompareTo(P.MAX_UPDATE_FREQ) > 0 && port.IsOpen)
                {
                    SerialPortWindow w = this.SerialPorts[portNumber(portName)];
                    string receivedData;
                    receivedData = port.ReadExisting();
                    this.SerialPorts[portNumber(portName)].ReceiveBytes += (ulong)Encoding.ASCII.GetByteCount(receivedData);
                    if (w.RxTimeStamp && this.P.TIMESTAMP_SPAN.CompareTo(DateTime.Now - w.RxLastTimeStamp) < 0)
                    {
                        if (this.P.TIMESTAMP_LINEHEAD)
                        {
                            receivedData.Replace("\r\n", "\n");
                            for (int i = 0; i < receivedData.Length; i++)
                            {
                                string s = receivedData.Substring(i, 1);
                                if (s == "\r" || s == "\n")
                                {
                                    if (i + 1 == receivedData.Length)
                                    {
                                        receivedData += "[" + DateTime.Now.ToString(this.P.TIMESTAMP_FORMAT) + "R]";
                                    }
                                    else
                                    {
                                        receivedData = receivedData.Substring(0, i + 1) + "[" + DateTime.Now.ToString(this.P.TIMESTAMP_FORMAT) + "R]" + receivedData.Substring(i + 1);
                                    }
                                    this.SerialPorts[portNumber(portName)].RxLastTimeStamp = DateTime.Now;
                                    break;
                                }
                            }
                        }
                        else
                        {
                            receivedData = "[" + DateTime.Now.ToString(this.P.TIMESTAMP_FORMAT) + "R]" + receivedData;
                            this.SerialPorts[portNumber(portName)].RxLastTimeStamp = DateTime.Now;
                        }
                    }
                    //receivedData = receivedData.Replace("\n", "\r\n"); 
                    //receivedData = receivedData.Replace(port.NewLine, "\r\n");
                    AddRecievedDataDelegate add = new AddRecievedDataDelegate(AddRecievedData);
                    if (w.FormRx.Controls.Count != 0)
                    {
                        TextBox t = (TextBox)w.FormRx.Controls[0];
                        this.BeginInvoke(add, receivedData, t);
                        this.SerialPorts[portNumber(portName)].LastUpdate = DateTime.Now;
                    }
                    if (w.FormBinary != null && w.FormBinary.Controls.Count != 0) //バイナリモード
                    {
                        TextBox t = (TextBox)w.FormBinary.Controls[0];
                        byte[] receivedBytes = Encoding.ASCII.GetBytes(receivedData);
                        StringBuilder sb = new StringBuilder();
                        foreach (byte b in receivedBytes)
                        {
                            sb.Append(b.ToString("X2") + " ");
                        }
                        this.BeginInvoke(add, sb.ToString(), t);
                        this.SerialPorts[portNumber(portName)].LastUpdate = DateTime.Now;
                    }
                    if (w.isFocused)
                    {
                        updateStatusStrip(w);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("serialPort1_DataReceivedError:"+ex.Message);
            }
        }

        private delegate void AddRecievedDataDelegate(string data, TextBox textbox);

        private void AddRecievedData(string data, TextBox textbox)
        {
            try
            {
                data = data.Replace("\n", "\r\n");

                textbox.AppendText(data);
                //textbox.Text += data;
                textbox.SelectionStart = textbox.Text.Length;
                textbox.ScrollToCaret();
            }
            catch (Exception ex)
            {
                Console.WriteLine("AddRecievedDataErroe:" + ex.Message);
            }
        }
        #endregion

        #region{イベント　ハンドラ}

        #region{フォーム全般のイベント}

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.Width < 200)
                {
                    this.Width = 200;
                }
                if (this.Height < 120)
                {
                    this.Height = 120;
                }
                if (this.Height - Format.TabControlHeightToForm > 0)
                {
                    this.tabControl1.Height = this.Height - Format.TabControlHeightToForm;
                }
                if (this.Height - Format.ChartControlHeightToForm > 0)
                {
                    this.chart1.Height = this.Height - Format.ChartControlHeightToForm;
                }
                if (this.Height - Format.ListViewControlHeightToForm > 0)
                {
                    this.listView1.Height = this.Height - Format.ListViewControlHeightToForm;
                }
                resizeWindows();
            }
            catch (Exception ex)
            {

            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                NanoTerm.Properties.Settings.Default.FORM_WINDOWSTATE = this.WindowState;
                if (this.WindowState != FormWindowState.Minimized)
                {
                    NanoTerm.Properties.Settings.Default.FORM_WIDTH = Math.Max(480,this.Width);
                    NanoTerm.Properties.Settings.Default.FORM_HEIGHT = Math.Max(320,this.Height);
                }
                NanoTerm.Properties.Settings.Default.Save();

                if (this.P.REMOVE_EMPTY_LOG)
                {
                    this.endSaveThread = true;
                    for (int i = 0; i < P.MAX_PORT_NUMBER; i++)
                    {
                        if (this.SerialPorts[i].TxFile != null)
                        {
                            this.SerialPorts[i].TxFile.Close();
                        }
                        if (this.SerialPorts[i].RxFile != null)
                        {
                            this.SerialPorts[i].RxFile.Close();
                        }
                        if (this.SerialPorts[i].BinaryFile != null)
                        {
                            this.SerialPorts[i].BinaryFile.Close();
                        }
                    }

                    string deletedList = "";
                    foreach (string path in this.LogFiles)
                    {
                        if (File.Exists(path))
                        {
                            FileInfo f = new FileInfo(path);
                            if (f.Length == 0)
                            {
                                deletedList += Path.GetFileName(path) + "\n";
                                File.Delete(path);
                            }
                        }
                    }
                    if (deletedList.Length != 0)
                    {
                        MessageBox.Show("以下のファイルが0バイトだったため自動的に削除されました。自動削除を無効にするには「設定」→「ターミナルと自動保存の設定」からログファイル削除の設定を解除して下さい。\n\n" + deletedList, "ファイルの削除");
                    }
                }
                Environment.Exit(0);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void tabControl1_TabIndexChanged(object sender, EventArgs e)
        {
            resizeWindows();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Height - Format.TabControlHeightToForm > 0)
            {
                this.tabControl1.Height = this.Height - Format.TabControlHeightToForm;
            }
            if (this.Height - Format.ChartControlHeightToForm > 0)
            {
                this.chart1.Height = this.Height - Format.ChartControlHeightToForm;
            }
            if (this.Height - Format.ListViewControlHeightToForm > 0)
            {
                this.listView1.Height = this.Height - Format.ListViewControlHeightToForm;
            }
            resizeWindows();
        }

        //ショートカット処理
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if ((int)keyData == (int)Keys.Control + (int)Keys.D1)
            {
                this.tabControl1.SelectedIndex = 0;
                return true;
            }
            if ((int)keyData == (int)Keys.Control + (int)Keys.D2)
            {
                this.tabControl1.SelectedIndex = 1;
                return true;
            }
            if ((int)keyData == (int)Keys.Control + (int)Keys.D3)
            {
                this.tabControl1.SelectedIndex = 2;
                return true;
            }
            if ((int)keyData == (int)Keys.Control + (int)Keys.P)
            {
                changeFontSize(1);
                return true;
            }
            if ((int)keyData == (int)Keys.Control + (int)Keys.M)
            {
                changeFontSize(-1);
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        #endregion

        #region{ボーレート設定関係のイベント}

        private void bpsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SerialPortWindow Com = this.SerialPorts[(int)(((ToolStripMenuItem)sender).Tag)];
                changeBaudRate(Com, 1200);
            }
            catch (Exception ex)
            {
                Console.WriteLine("changeBaudRateError:" + ex.Message);
            }
        }

        private void bpsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                SerialPortWindow Com = this.SerialPorts[(int)(((ToolStripMenuItem)sender).Tag)];
                changeBaudRate(Com, 4800);
            }
            catch (Exception ex)
            {
                Console.WriteLine("changeBaudRateError:" + ex.Message);
            }
        }

        private void bpsToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            try
            {
                SerialPortWindow Com = this.SerialPorts[(int)(((ToolStripMenuItem)sender).Tag)];
                changeBaudRate(Com, 9600);
            }
            catch (Exception ex)
            {
                Console.WriteLine("changeBaudRateError:" + ex.Message);
            }
        }

        private void bpsToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            try
            {
                SerialPortWindow Com = this.SerialPorts[(int)(((ToolStripMenuItem)sender).Tag)];
                changeBaudRate(Com, 19200);
            }
            catch (Exception ex)
            {
                Console.WriteLine("changeBaudRateError:" + ex.Message);
            }
        }

        private void bpsToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            try
            {
                SerialPortWindow Com = this.SerialPorts[(int)(((ToolStripMenuItem)sender).Tag)];
                changeBaudRate(Com, 38400);
            }
            catch (Exception ex)
            {
                Console.WriteLine("changeBaudRateError:" + ex.Message);
            }
        }

        private void bpsToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            try
            {
                SerialPortWindow Com = this.SerialPorts[(int)(((ToolStripMenuItem)sender).Tag)];
                changeBaudRate(Com, 57600);
            }
            catch (Exception ex)
            {
                Console.WriteLine("changeBaudRateError:" + ex.Message);
            }
        }

        private void bpsToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            try
            {
                SerialPortWindow Com = this.SerialPorts[(int)(((ToolStripMenuItem)sender).Tag)];
                changeBaudRate(Com, 115200);
            }
            catch (Exception ex)
            {
                Console.WriteLine("changeBaudRateError:" + ex.Message);
            }
        }

        private void changeBaudRate(SerialPortWindow Com, int BaudRate)
        {
            try
            {
                Com.Port.BaudRate = BaudRate;
                if (Com.FormTx != null)
                {
                    Com.FormTx.Text = getFormTitle(Com.COM, FormType.Tx, Com.TxFileName, Com.Port.BaudRate, !Com.isConnected, Com.Port.IsOpen, Com.FormTx.Controls[0]);
                }
                if (Com.FormRx != null)
                {
                    Com.FormRx.Text = getFormTitle(Com.COM, FormType.Rx, Com.RxFileName, Com.Port.BaudRate, !Com.isConnected, Com.Port.IsOpen, Com.FormRx.Controls[0]);
                }
                if (Com.FormBinary != null)
                {
                    Com.FormBinary.Text = getFormTitle(Com.COM, FormType.Binary, Com.BinaryFileName, Com.Port.BaudRate, !Com.isConnected, Com.Port.IsOpen, Com.FormBinary.Controls[0]);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("changeBaudRateError:" + ex.Message);
            }
        }

        #endregion

        #region{シリアル接続ページのイベント}

        private void serialWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form f = (Form)sender;
            int port = int.Parse(f.Tag.ToString());
            if (getOpenWindowCount(port) == 1)//今閉じようとしているウィンドウが最後の1個の場合，接続を切断
            {
                if (this.SerialPorts[port].Port != null)
                {
                    this.SerialPorts[port].Port.Dispose();
                }
                this.SerialPorts[port].Port = null;
                if (this.SerialPorts[port].TxFile != null)
                {
                    this.SerialPorts[port].TxFile.Close();
                }
                if (this.SerialPorts[port].RxFile != null)
                {
                    this.SerialPorts[port].RxFile.Close();
                }
                if (this.SerialPorts[port].BinaryFile != null)
                {
                    this.SerialPorts[port].BinaryFile.Close();
                }
                this.SerialPorts[port] = new SerialPortWindow();
            }
        }

        void serialPort1_PinChanged(object sender, SerialPinChangedEventArgs e)
        {
            try
            {
                SerialPort port = (SerialPort)sender;
                string portName = ((SerialPort)sender).PortName;
                int portnum = portNumber(portName);
            }
            catch (Exception ex)
            {
                Console.WriteLine("serialPort1_PinChangedError:" + ex.Message);
            }
        }

        void Tx_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                TextBox t = (TextBox)sender;
                // ContextMenuStripインスタンスは全ポート共有とし、MouseDownイベントごとにTagを貼り換える
                this.contextMenuStrip_SetBaudRate.Tag = t.Tag;
                foreach (ToolStripMenuItem item in this.contextMenuStrip_SetBaudRate.Items)
                {
                    item.Tag = t.Tag;
                }
                foreach (ToolStripMenuItem item in this.ToolStripMenuItem_BaudRate.DropDownItems)
                {
                    item.Tag = t.Tag;
                }
                foreach (ToolStripMenuItem item in this.ToolStripMenuItem_SendTiming.DropDownItems)
                {
                    item.Tag = t.Tag;
                }
                foreach (ToolStripMenuItem item in this.ToolStripMenuItem_Delimiter.DropDownItems)
                {
                    item.Tag = t.Tag;
                }
                int X = e.Location.X;// +this.SerialPorts[(int)t.Tag].FormTx.Location.X;
                int Y = e.Location.Y;// +100;
                this.contextMenuStrip_SetBaudRate.Show(t, X, Y);
            }
        }

        void Rx_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    TextBox t = (TextBox)sender;
                    // ContextMenuStripインスタンスは全ポート共有とし、MouseDownイベントごとにTagを貼り換える
                    this.contextMenuStrip_SetBaudRate.Tag = t.Tag;
                    foreach (ToolStripMenuItem item in this.contextMenuStrip_SetBaudRate.Items)
                    {
                        item.Tag = t.Tag;
                    }
                    foreach (ToolStripMenuItem item in this.ToolStripMenuItem_BaudRate.DropDownItems)
                    {
                        item.Tag = t.Tag;
                    }
                    foreach (ToolStripMenuItem item in this.ToolStripMenuItem_SendTiming.DropDownItems)
                    {
                        item.Tag = t.Tag;
                    }
                    foreach (ToolStripMenuItem item in this.ToolStripMenuItem_Delimiter.DropDownItems)
                    {
                        item.Tag = t.Tag;
                    }
                    int X = e.Location.X;// +this.SerialPorts[(int)t.Tag].FormTx.Location.X;
                    int Y = e.Location.Y;// +100 + this.windowHeight;
                    this.contextMenuStrip_SetBaudRate.Show(t, X, Y);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Rx_MouseDownError:" + ex.Message);
            }
        }

        void Tx_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\b')
            {
                e.Handled = true;
            }
            TextBox t = (TextBox)sender;
            t.SelectionStart = t.Text.Length;
            SerialPortWindow s = this.SerialPorts[int.Parse(t.Tag.ToString())];
            if (s.TxBinaryMode)
            {
                if (e.KeyChar == 'a' ||
                   e.KeyChar == 'b' ||
                   e.KeyChar == 'c' ||
                   e.KeyChar == 'd' ||
                   e.KeyChar == 'e' ||
                   e.KeyChar == 'f' ||
                   e.KeyChar == 'A' ||
                   e.KeyChar == 'B' ||
                   e.KeyChar == 'C' ||
                   e.KeyChar == 'D' ||
                   e.KeyChar == 'E' ||
                   e.KeyChar == 'F' ||
                   e.KeyChar == '0' ||
                   e.KeyChar == '1' ||
                   e.KeyChar == '2' ||
                   e.KeyChar == '3' ||
                   e.KeyChar == '4' ||
                   e.KeyChar == '5' ||
                   e.KeyChar == '6' ||
                   e.KeyChar == '7' ||
                   e.KeyChar == '8' ||
                   e.KeyChar == '9' ||
                    e.KeyChar == (char)(13))
                {
                    t.AppendText(e.KeyChar.ToString());
                    e.Handled = true;
                }
                else
                {
                    e.Handled = true;
                }
            }
        }

        public void Tx_FileSend(string command, int comNumber)
        {
            if (this.SerialPorts[comNumber].FormTx.Controls.Count == 0)
            {
                return;
            }
            TextBox t = (TextBox)(this.SerialPorts[comNumber].FormTx.Controls[0]);
            SerialPortWindow s = this.SerialPorts[int.Parse(t.Tag.ToString())];
            if (s.TxTimeStamp && this.P.TIMESTAMP_SPAN.CompareTo(DateTime.Now - s.TxLastTimeStamp) < 0)
            {
                t.AppendText("[" + DateTime.Now.ToString(this.P.TIMESTAMP_FORMAT) + "S]");
            }
            t.AppendText(command + "\r\n");
            this.SerialPorts[int.Parse(t.Tag.ToString())].SendBytes += (ulong)Encoding.ASCII.GetByteCount(command);
            sendString(s.Port, command);
        }

        private void Tx_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox t = (TextBox)sender;
            SerialPortWindow s = this.SerialPorts[int.Parse(t.Tag.ToString())];

            if (e.KeyCode == System.Windows.Forms.Keys.Enter && (!s.SendSoon || s.TxBinaryMode))
            {
                e.Handled = true;
                int start = t.GetFirstCharIndexOfCurrentLine();
                int line = t.GetLineFromCharIndex(start);
                int end = t.GetFirstCharIndexFromLine(line + 1);
                if (end == -1)
                {
                    end = t.Text.Length;
                }
                string command = t.Text.Substring(start, end - start);

                #region{通常の送信}
                if (s.TxBinaryMode == false)
                {
                    if (s.TxTimeStamp && this.P.TIMESTAMP_SPAN.CompareTo(DateTime.Now - s.TxLastTimeStamp) < 0)
                    {
                        t.AppendText("[" + DateTime.Now.ToString(this.P.TIMESTAMP_FORMAT) + "S]");
                    }
                    this.SerialPorts[int.Parse(t.Tag.ToString())].SendBytes += (ulong)Encoding.ASCII.GetByteCount(command);
                    sendString(s.Port, command);
                }
                #endregion
                #region{Binary Tx Mode}
                else
                {
                    char[] c = command.ToCharArray();
                    List<byte> byteCommand = new List<byte>();
                    for (int i = 0; i < c.Length - 1; i+=2)
                    {
                        string b = c[i].ToString() + c[i + 1].ToString();
                        byte byteNum = 0;
                        if (byte.TryParse(b,NumberStyles.HexNumber, CultureInfo.InvariantCulture,out byteNum))
                        {
                            byteCommand.Add(byteNum);
                        }
                    }
                    this.SerialPorts[int.Parse(t.Tag.ToString())].SendBytes += (ulong)byteCommand.Count();
                    sendByte(s.Port, byteCommand.ToArray());
                }
                #endregion

                updateStatusStrip(s);
            }
            else if (s.SendSoon == true)
            {
                if (kv.ConvertToString(e.KeyCode).Length == 1 || e.KeyCode == Keys.Space)//文字
                {
                    string command = "";
                    if (e.KeyCode == Keys.Space)
                    {
                        command = " ";
                    }
                    else
                    {
                        command = kv.ConvertToString(e.KeyCode);
                        if (!e.Shift && Console.CapsLock == false)
                        {
                            command = command.ToLower();
                        }
                    }

                    if (s.TxTimeStamp && this.P.TIMESTAMP_SPAN.CompareTo(DateTime.Now - s.TxLastTimeStamp) < 0)
                    {
                        t.AppendText("[" + DateTime.Now.ToString(this.P.TIMESTAMP_FORMAT) + "S]");
                    }
                    this.SerialPorts[int.Parse(t.Tag.ToString())].SendBytes += (ulong)Encoding.ASCII.GetByteCount(command);
                    sendStringWithoutNewLine(s.Port, command);
                }
                else if (e.KeyCode == Keys.Enter) //エンターの場合は既定のNewLineを送信
                {
                    sendString(s.Port, "");
                }
            }
        }

        void Port_OnClick(object sender, EventArgs e)
        {
            SerialPortWindow w = this.SerialPorts[(int)(((TextBox)sender).Tag)];
            activateWindow(w);
        }

        void Port_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        void Port_DragDrop(object sender, DragEventArgs e)
        {
            string[] path = (string[])e.Data.GetData(DataFormats.FileDrop);
            string com = "COM" + ((TextBox)sender).Tag.ToString();
            SerialPortWindow s = this.SerialPorts[int.Parse(((TextBox)sender).Tag.ToString())];
            if (System.IO.Path.GetExtension(path[0]) == ".mot")
            {
                if (MessageBox.Show(com + "を一時切断し，.motファイルに関連付られた外部アプリケーションを起動します．") == System.Windows.Forms.DialogResult.OK)
                {
                    s.Port.Close();
                    try
                    {
                        System.Diagnostics.Process p = System.Diagnostics.Process.Start(path[0], com);
                        p.WaitForExit();
                    }
                    catch (Win32Exception)
                    {
                        MessageBox.Show(".motファイルに関連付けられたファイルを開くときにエラーが発生しました．", "エラー");
                        return;
                    }
                    catch (FileNotFoundException)
                    {
                        MessageBox.Show("ファイルが見つかりません．", "エラー");
                        return;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("不明なエラーが発生しました：" + ex.Message, "エラー");
                        return;
                    }
                    s.Port.Open();
                }
                return;
            }
            if (System.IO.Path.GetExtension(path[0]) == ".txt")
            {
                if (MessageBox.Show("ファイルの内容を一括で送信しますか？") == System.Windows.Forms.DialogResult.OK)
                {
                    string command = "";
                    try
                    {
                        command = System.IO.File.ReadAllText(path[0]);
                    }
                    #region{File.ReadAllTextの例外処理}
                    catch (ArgumentException)
                    {
                        MessageBox.Show("パスがnull参照です．", "エラー");
                        return;
                    }
                    catch (PathTooLongException)
                    {
                        MessageBox.Show("指定したパス，ファイル名，またはその両方がシステム定義の最大長を超えています．", "エラー");
                        return;
                    }
                    catch (DirectoryNotFoundException)
                    {
                        MessageBox.Show("指定したパスが無効です．", "エラー");
                        return;
                    }
                    catch (IOException)
                    {
                        MessageBox.Show("ファイルを開くときにエラーが発生しました．ファイルが他のアプリケーションによって開かれていないか確認して下さい．", "エラー");
                        return;
                    }
                    catch (UnauthorizedAccessException)
                    {
                        MessageBox.Show("この操作は現在のプラットフォームではサポートされません．", "エラー");
                        return;
                    }
                    catch (System.Security.SecurityException)
                    {
                        MessageBox.Show("呼び出し元に必要なアクセス許可がありません．", "エラー");
                        return;
                    }
                    #endregion

                    if (s.FormTx != null && s.FormTx.Controls.Count != 0)
                    {
                        if (s.TxTimeStamp && this.P.TIMESTAMP_SPAN.CompareTo(DateTime.Now - s.TxLastTimeStamp) < 0)
                        {
                            ((TextBox)(s.FormTx.Controls[0])).AppendText("[" + DateTime.Now.ToString(this.P.TIMESTAMP_FORMAT) + "S]");
                        }
                        ((TextBox)(s.FormTx.Controls[0])).AppendText(command + "\r\n");
                    }
                    this.SerialPorts[int.Parse(((TextBox)sender).Tag.ToString())].SendBytes += (ulong)Encoding.ASCII.GetByteCount(command);
                    sendString(s.Port, command);
                }
            }
        }

        #endregion

        #region{グラフページのイベント}
        private void comboBox_Graph_Type_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (-1 < e.Index)
            {//描画対象となる項目のインデックスが有効なとき

                //コンボボックスを取得
                ComboBox cmbBox = (ComboBox)sender;

                //描画対象となる項目を取得
                DataRowView dataRowView = (DataRowView)cmbBox.Items[e.Index];

                //項目のテキストを取得
                string text = (string)dataRowView.Row["DisplayMember"];

                //項目のイメージを取得
                Image image = dataRowView.Row["Image"] as Image;

                //イメージの描画領域
                //イメージをコンボボックスの高さに合わせる。幅は高さを同じ比率にする
                Rectangle imgRect = new Rectangle(
                    e.Bounds.Left + 1,//左上X
                    e.Bounds.Top + 1,//左上Y
                     (cmbBox.ItemHeight - 2) * image.Width / image.Height,//幅
                    cmbBox.ItemHeight - 2);//高さ

                //テキストの描画領域
                //テキストはイメージの右に3px隙間を空け、上下中央-左寄せで表示。
                Rectangle textRect = new Rectangle(
                    e.Bounds.Left + imgRect.Width + 3,//左上X
                    e.Bounds.Top + (cmbBox.ItemHeight - e.Font.Height) / 2,//左上Y
                    e.Bounds.Width - (imgRect.Width + 2),//幅
                    e.Font.Height);//高さ

                if (cmbBox.Enabled)
                {//コンボボックスが有効なとき

                    //背景を描画
                    e.DrawBackground();

                    //項目のイメージを描画
                    e.Graphics.DrawImage(image, imgRect);

                    //項目のテキストを前景色で描画
                    e.Graphics.DrawString(text, e.Font, new SolidBrush(e.ForeColor), textRect);

                    //フォーカスを示す四角形を描画
                    e.DrawFocusRectangle();
                }
                else
                {//コンボボックスが無効なとき

                    //項目の描画サイズのイメージを作成
                    Bitmap drawSizeImage = new Bitmap(image, imgRect.Width, imgRect.Height);

                    //項目の無効状態のイメージを描画
                    ControlPaint.DrawImageDisabled(e.Graphics, drawSizeImage, imgRect.Left, imgRect.Top, e.BackColor);

                    //項目のテキストを淡色で描画
                    e.Graphics.DrawString(text, e.Font, new SolidBrush(Color.FromKnownColor(KnownColor.GrayText)), textRect);
                }
            }
        }

        private void button_saveClipboard_Click(object sender, EventArgs e)
        {
            Clipboard.SetImage(getChartBitMap());
        }

        private void button_saveImage_Click(object sender, EventArgs e)
        {
            if (this.saveFileDialog_saveImage.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    getChartBitMap().Save(saveFileDialog_saveImage.FileName, ImageFormat.Bmp);
                }
                catch (ArgumentNullException)
                {
                    MessageBox.Show("ファイル名を空にすることはできません．");
                }
                catch (System.Runtime.InteropServices.ExternalException)
                {
                    MessageBox.Show("このイメージは誤ったイメージ形式で保存されています。");
                }
            }
        }

        private void button_AddGraph_Click(object sender, EventArgs e)
        {
            bool isSecondaryAxis = this.checkBox_Graph_SecondaryAxis.Checked;
            SeriesChartType Type = (SeriesChartType)(((DataRowView)this.comboBox_Graph_Type.SelectedItem).Row["ValueMember"]);
            string Name = this.textBox_Graph_Name.Text;
            string Label = this.textBox_Graph_Label.Text;

            if (Name.Length == 0 || Label.Length == 0 || this.comboBox_Graph_Port.Text.Length == 0)
            {
                MessageBox.Show("入力されていない項目があります．");
                return;
            }

            int Com = int.Parse(this.comboBox_Graph_Port.Text.Substring(3));
            double a, b;

            try
            {
                a = double.Parse(this.textBox_Graph_a.Text);
                b = double.Parse(this.textBox_Graph_b.Text);
            }
            catch
            {
                MessageBox.Show("変換式の入力形式が不正です．");
                return;
            }
            addSeries(Name, Com, a, b, Label, isSecondaryAxis, Type);

        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            if (this.comboBox_deleteList.Text.Length == 0)
            {
                MessageBox.Show("削除するアイテムが選択されていません");
                return;
            }
            string name = this.comboBox_deleteList.Text;
            this.chart1.Series.Remove(this.chart1.Series[name]);
            int? index = null;
            foreach (DataGridViewRow row in this.dataGridView_Series.Rows)
            {
                if (row.Cells[1].Value.ToString() == name)
                {
                    index = row.Index;
                }
            }
            if (index != null)
            {
                this.dataGridView_Series.Rows.Remove(dataGridView_Series.Rows[(int)index]);
            }

            //実際には削除せず，幅ゼロのカラムとして保持しておく
            if (this.checkBox_deleteFromDataList.Checked)
            {
                this.listView1.Columns[name].Width = 0;
                string newName = System.IO.Path.GetRandomFileName() + name;
                this.listView1.Columns[name].Name = newName;
                this.listView1.Columns[newName].Text = name + " (" + DateTime.Now + " suspended)";
            }
            this.DataSeries.Remove(name);
            this.comboBox_deleteList.Items.Remove(name);
            if (this.chart1.Series.Count == 0)
            {
                this.FirstPlotTime = new DateTime();
            }
        }

        private void button_deleteAll_Click(object sender, EventArgs e)
        {
            if (
            MessageBox.Show("グラフとデータリスト上に表示された値は全て消去されます（タームの受信データは残ります）．消去してもよろしいですか？", "データ系列の全消去", MessageBoxButtons.OKCancel)
                == DialogResult.OK)
            {
                clearAllGraphAndListView();
            }
        }

        private void button_graph_xrange_update_Click(object sender, EventArgs e)
        {
            if (radioButton_graph_all_fromnow.Checked)
            {
                this.chart1.ChartAreas[0].AxisX.Minimum = this.chart1.ChartAreas[0].AxisX.Maximum;
            }
            else if (radioButton_graph_x_all.Checked)
            {
                if (this.FirstPlotTime.Year != 1)
                {
                    this.chart1.ChartAreas[0].AxisX.Minimum = this.FirstPlotTime.ToOADate();
                }
            }
            else if (radioButton_graph_x_from.Checked)
            {
                int time = 0;
                double oaTime = 0.0;
                if (int.TryParse(this.textBox_graph_x_from.Text, out time))
                {
                    if (time <= 0)
                    {
                        MessageBox.Show("時間を0または負の値に設定できません","エラー");
                        return;
                    }
                    switch (this.comboBox_graph_x_from.SelectedIndex)
                    {
                        case 0:
                            oaTime = DateTime.Now.AddSeconds(-time).ToOADate();
                            break;
                        case 1:
                            oaTime = DateTime.Now.AddMinutes(-time).ToOADate();
                            break;
                        case 2:
                            oaTime = DateTime.Now.AddHours(-time).ToOADate();
                            break;
                    }
                    if (this.FirstPlotTime.Year != 1)
                    {
                        this.chart1.ChartAreas[0].AxisX.Minimum = Math.Max(oaTime, this.FirstPlotTime.ToOADate());
                    }
                }
            }
            double d = this.chart1.ChartAreas[0].AxisX.Minimum;
        }

        private void button_graph_allview_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in this.dataGridView_Series.Rows)
            {
                row.Cells[0].Value = true;
            }
        }

        private void button_graph_allhide_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in this.dataGridView_Series.Rows)
            {
                row.Cells[0].Value = false;
            }
        }

        private void button_seriesview_update_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in this.dataGridView_Series.Rows)
            {
                if ((bool)(((DataGridViewCheckBoxCell)row.Cells[0]).Value) == false)
                {
                    if (((Plot)(this.DataSeries[row.Cells[1].Value.ToString()])).DefaultColor == null)
                    {
                        ((Plot)(this.DataSeries[row.Cells[1].Value.ToString()])).DefaultColor = this.chart1.Series[row.Cells[1].Value.ToString()].Color;
                    }
                    this.chart1.Series[row.Cells[1].Value.ToString()].MarkerColor = Color.Transparent;
                    this.chart1.Series[row.Cells[1].Value.ToString()].Color = Color.Transparent;
                }
                else
                {
                    if (((Plot)(this.DataSeries[row.Cells[1].Value.ToString()])).DefaultColor != null)
                    {
                        Color c = ((Plot)(this.DataSeries[row.Cells[1].Value.ToString()])).DefaultColor;
                        this.chart1.Series[row.Cells[1].Value.ToString()].MarkerColor = c;
                        this.chart1.Series[row.Cells[1].Value.ToString()].Color = c;
                    }
                    else
                    {
                        ((Plot)(this.DataSeries[row.Cells[1].Value.ToString()])).DefaultColor = this.chart1.Series[row.Cells[1].Value.ToString()].Color;
                    }
                }
            }
        }

        private void button_paramSave_Click(object sender, EventArgs e)
        {

            if (this.saveFileDialog_saveXML.ShowDialog() == DialogResult.OK)
            {
                xmlSerialize(saveFileDialog_saveXML.FileName);
            }
        }

        private void button_paramLoad_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog_readXML.ShowDialog() == DialogResult.OK)
            {
                xmlDeserialize(openFileDialog_readXML.FileName);
            }
        }

        private void button_Wizard_Click(object sender, EventArgs e)
        {
            if (getActiveSerialPortWindows() == 0)
            {
                MessageBox.Show("受信ウィンドウが全て閉じられています．1つ以上のポートに接続後再実行して下さい．","ウィザード起動エラー");
                return;
            }
            SeriesWizard s = new SeriesWizard();
            if (s.ShowDialog() == DialogResult.OK)
            {
                foreach (Plot p in s.plots)
                {
                    addSeries(p);
                }
            }
        }

        #endregion

        #region{リストビューページのイベント}

        private void checkBox_ListAutoSave_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBox_ListAutoSave.Checked)
            {
                this.panel_ListAutoSave.Enabled = true;
            }
            else
            {
                this.panel_ListAutoSave.Enabled = false;
            }
        }

        private void button_ListAutoSave_SelectFolder_Click(object sender, EventArgs e)
        {
            if (this.folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                this.textBox_ListAutoSave_Folder.Text = this.folderBrowserDialog1.SelectedPath;
            }
        }

        private void button_setAutoSave_Click(object sender, EventArgs e)
        {
            if (this.textBox_ListAutoSave_FileName.Text.Length == 0)
            {
                MessageBox.Show("ヘッダを指定してください");
                return;
            }
            if (this.ListViewSaver.FileHeadName != null && (this.textBox_ListAutoSave_FileName.Text != this.ListViewSaver.FileHeadName))
            {
                DialogResult d = MessageBox.Show("保存ファイルのヘッダ名が変更されました．番号を1から振り直しますか？\n   はい：ヘッダ名の変更と同時に，番号も1にリセットします\n   いいえ：ヘッダ名のみ変更し，番号は現在の値の続きとします)", "ヘッダ名の変更", MessageBoxButtons.YesNoCancel);
                if (d == DialogResult.Yes)
                {
                    this.ListViewSaver.CurrentIndex = 1;
                }
                else if (d == DialogResult.Cancel)
                {
                    return;
                }
            }
            this.ListViewSaver.FileHeadName = this.textBox_ListAutoSave_FileName.Text;

            try
            {
                this.ListViewSaver.Columns = int.Parse(this.textBox_ListAutoSave_LogLength.Text);
                if (this.ListViewSaver.Columns <= 0)
                {
                    MessageBox.Show("保存間隔を0以下の値にすることはできません。");
                    this.textBox_ListAutoSave_LogLength.Text = "1";
                    return;
                }
            }
            catch
            {
                MessageBox.Show("行数の指定が不正です");
                return;
            }
            if (this.textBox_ListAutoSave_Folder.Text.Length == 0)
            {
                MessageBox.Show("保存するフォルダを指定してください");
                return;
            }

            this.ListViewSaver.Folder = this.textBox_ListAutoSave_Folder.Text;
            this.ListViewSaver.AutoSaveSettingDone = true;
            this.toolStripStatusLabel5.Text = "設定を完了しました．";
        }

        private void button_savecsv_Click(object sender, EventArgs e)
        {
            if (saveFileDialog_csv.ShowDialog() == DialogResult.OK)
            {
                saveCSV(saveFileDialog_csv.FileName);
            }

        }

        #endregion

        #region{ContextStripMenu}
        private void contextMenuStrip_SetBaudRate_Opening(object sender, CancelEventArgs e)
        {
            SerialPortWindow s = this.SerialPorts[int.Parse(this.contextMenuStrip_SetBaudRate.Tag.ToString())];
            foreach (ToolStripMenuItem item in ToolStripMenuItem_BaudRate.DropDownItems)
            {
                item.Checked = false;
            }
            if (s.TxBinaryMode)
            {
                BinModeToolStripMenuItem.Checked = true;
            }
            switch (s.Port.BaudRate)
            {
                case 1200:
                    bpsToolStripMenuItem.Checked = true;
                    break;
                case 4800:
                    bpsToolStripMenuItem1.Checked = true;
                    break;
                case 9600:
                    bpsToolStripMenuItem2.Checked = true;
                    break;
                case 19200:
                    bpsToolStripMenuItem3.Checked = true;
                    break;
                case 38400:
                    bpsToolStripMenuItem4.Checked = true;
                    break;
                case 57600:
                    bpsToolStripMenuItem5.Checked = true;
                    break;
                case 115200:
                    bpsToolStripMenuItem6.Checked = true;
                    break;
            }
            foreach (ToolStripMenuItem item in ToolStripMenuItem_Delimiter.DropDownItems)
            {
                item.Checked = false;
            }
            switch (s.ReturnCode)
            {
                case "\r":
                    cRToolStripMenuItem.Checked = true;
                    break;
                case "\n":
                    lFToolStripMenuItem.Checked = true;
                    break;
                case "\r\n":
                    cRLFrnToolStripMenuItem.Checked = true;
                    break;
            }
            if (s.SendSoon)
            {
                SoonSendToolStripMenuItem.Checked = true;
                DelimiterToolStripMenuItem.Checked = false;
            }
            else
            {
                SoonSendToolStripMenuItem.Checked = false;
                DelimiterToolStripMenuItem.Checked = true;
            }
        }
        private void SoonSendToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.SerialPorts[(int)(((ToolStripMenuItem)sender).Tag)].SendSoon = true;
        }
        private void DelimiterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.SerialPorts[(int)(((ToolStripMenuItem)sender).Tag)].SendSoon = false;
        }
        private void cRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.SerialPorts[(int)(((ToolStripMenuItem)sender).Tag)].ReturnCode = "\r";
            this.SerialPorts[(int)(((ToolStripMenuItem)sender).Tag)].Port.NewLine = "\r";
        }
        private void lFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.SerialPorts[(int)(((ToolStripMenuItem)sender).Tag)].ReturnCode = "\n";
            this.SerialPorts[(int)(((ToolStripMenuItem)sender).Tag)].Port.NewLine = "\n";
        }
        private void cRLFrnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.SerialPorts[(int)(((ToolStripMenuItem)sender).Tag)].ReturnCode = "\r\n";
            this.SerialPorts[(int)(((ToolStripMenuItem)sender).Tag)].Port.NewLine = "\r\n";
        }
        private void バイナリ送信モードToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (((ToolStripMenuItem)sender).Checked)
            {
                ((ToolStripMenuItem)sender).Checked = false;
                SerialPortWindow s = this.SerialPorts[(int)(((ToolStripMenuItem)sender).Tag)];
                this.SerialPorts[(int)(((ToolStripMenuItem)sender).Tag)].TxBinaryMode = false;
                if (this.SerialPorts[(int)(((ToolStripMenuItem)sender).Tag)].FormTx != null)
                {
                    this.SerialPorts[(int)(((ToolStripMenuItem)sender).Tag)].FormTx.Text = getFormTitle(s.COM, FormType.Tx, s.TxFileName, s.Port.BaudRate, !s.isConnected, s.Port.IsOpen, s.FormTx.Controls[0]);
                }
                if (this.SerialPorts[(int)(((ToolStripMenuItem)sender).Tag)].FormRx != null)
                {
                    this.SerialPorts[(int)(((ToolStripMenuItem)sender).Tag)].FormRx.Text = getFormTitle(s.COM, FormType.Rx, s.RxFileName, s.Port.BaudRate, !s.isConnected, s.Port.IsOpen, s.FormRx.Controls[0]);
                }
                if (this.SerialPorts[(int)(((ToolStripMenuItem)sender).Tag)].FormBinary != null)
                {
                    this.SerialPorts[(int)(((ToolStripMenuItem)sender).Tag)].FormBinary.Text = getFormTitle(s.COM, FormType.Binary, s.BinaryFileName, s.Port.BaudRate, !s.isConnected, s.Port.IsOpen, s.FormBinary.Controls[0]);
                }
                updateStatusStrip(s.COM + "のバイナリ送信モードを解除しました．");
            }
            else
            {
                ((ToolStripMenuItem)sender).Checked = true;
                this.SerialPorts[(int)(((ToolStripMenuItem)sender).Tag)].TxBinaryMode = true;
                SerialPortWindow s = this.SerialPorts[(int)(((ToolStripMenuItem)sender).Tag)];
                if (this.SerialPorts[(int)(((ToolStripMenuItem)sender).Tag)].FormTx != null)
                {
                    this.SerialPorts[(int)(((ToolStripMenuItem)sender).Tag)].FormTx.Text = getFormTitle(s.COM, FormType.Tx, s.TxFileName, s.Port.BaudRate, !s.isConnected, s.Port.IsOpen, s.FormTx.Controls[0]);
                }
                if (this.SerialPorts[(int)(((ToolStripMenuItem)sender).Tag)].FormRx != null)
                {
                    this.SerialPorts[(int)(((ToolStripMenuItem)sender).Tag)].FormRx.Text = getFormTitle(s.COM, FormType.Rx, s.RxFileName, s.Port.BaudRate, !s.isConnected, s.Port.IsOpen, s.FormRx.Controls[0]);
                }
                if (this.SerialPorts[(int)(((ToolStripMenuItem)sender).Tag)].FormBinary != null)
                {
                    this.SerialPorts[(int)(((ToolStripMenuItem)sender).Tag)].FormBinary.Text = getFormTitle(s.COM, FormType.Binary, s.BinaryFileName, s.Port.BaudRate, !s.isConnected, s.Port.IsOpen, s.FormBinary.Controls[0]);
                }
                updateStatusStrip(s.COM + "をバイナリ送信モードに設定しました．0～Fのみ入力を受け付け，Enter入力でバイト列として送信します．");

            }

        }
        
        #endregion

        #region{ToolStripMenu}
        private void 目次HToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (System.IO.File.Exists("help.chm"))
            {
                Help.ShowHelp(this, "help.chm");
            }
            else
            {
                MessageBox.Show("ヘルプファイルが存在しません。");
            }
        }

        private void バージョン情報AToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VersionInfo v = new VersionInfo();
            v.ShowDialog();
        }

        private void ファイル送信FToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileSender fs = new FileSender(getWindowPortNames(), this);
            fs.Show();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            SetUpSerialPort p = new SetUpSerialPort(getNewPorts(), this.workingDirectory);
            if (p.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (isOpenPort(p.Port.PortName))
                    {
                        p.Port.Open();
                    }
                }
                catch
                {

                }
                this.workingDirectory = p.DirectoryName;
                openPort(p.Port, false, p.TxLog, p.RxLog, p.BinaryLog, p.TxShow, p.RxShow, p.BinaryShow, p.BaseFileName);
            }
        }

        private void グラフの書式設定ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GraphSettings g = new GraphSettings(this.chart1);

            if (g.ShowDialog() == DialogResult.OK)
            {
                this.chart1.ChartAreas[0].AxisX.Title = g.AXisXTitle;
                this.chart1.ChartAreas[0].AxisY.Title = g.AXisYTitle;
                this.chart1.ChartAreas[0].AxisY2.Title = g.AXisY2Title;
                this.chart1.Titles.Clear();
                this.chart1.Titles.Add(g.GraphTitle);
            }
        }

        private void ToolStripMenuItem_GraphSettings_Click(object sender, EventArgs e)
        {
            PlotSettings p = new PlotSettings(SerialPort.GetPortNames());
            p.DataSeries = this.DataSeries;
            p.SetInitiallizedValues();
            p.defaultMarkerSize = this.defaultMarkerSize;
            p.defaultMarkerStyle = this.dafaultMarkerStyle;
            if (p.ShowDialog() == DialogResult.OK)
            {
                this.DataSeries = p.DataSeries;
                foreach (Plot plot in this.DataSeries.Values)
                {
                    this.chart1.Series[plot.Series].ChartType = plot.ChartType;
                    this.chart1.Series[plot.Series].YAxisType = plot.YAxisType;
                    this.chart1.Series[plot.Series].MarkerSize = plot.MarkerSize;
                    this.chart1.Series[plot.Series].MarkerStyle = plot.MarkerStyle;
                }
            }
        }

        private void 終了ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void 再接続RToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            bool[] isOpen = new bool[P.MAX_PORT_NUMBER];

            for (int i = 0; i < P.MAX_PORT_NUMBER; i++)
            {
                isOpen[i] = false;
            }

            foreach (string port in ports)
            {
                isOpen[portNumber(port)] = true;
            }

            for (int i = 0; i < P.MAX_PORT_NUMBER; i++)
            {

                // ウィンドウが閉じており，インスタンスが生成されておらず，ポートが利用可能→新規追加
                if (isOpen[i] && getOpenWindowCount(i) == 0 && this.SerialPorts[i].Port == null)
                {
                    openPort("COM" + i.ToString());
                }
                else if (getOpenWindowCount(i) != 0 && getOpenWindowCount(i) != 3 && isOpen[i])
                {
                    openWindow(this.SerialPorts[i].COM, this.SerialPorts[i].Port, ref this.SerialPorts[i], false);
                }

                resizeWindows();

                // 再接続ポート
                if (isOpen[i] && !this.SerialPorts[i].isConnected)
                {
                    reconnectPort("COM" + i.ToString());
                }
            }
        }

        private void ポートを閉じるDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < P.MAX_PORT_NUMBER; i++)
            {
                if (this.SerialPorts[i].isFocused)
                {
                    closePort(i);
                }
            }
            string[] ports = getWindowPortNames();
            if (ports.Count() != 0)
            {
                this.SerialPorts[portNumber(ports[ports.Count() - 1])].isFocused = true;
                if (this.SerialPorts[portNumber(ports[ports.Count() - 1])].FormTx != null)
                {
                    this.SerialPorts[portNumber(ports[ports.Count() - 1])].FormTx.Controls[0].Focus();
                }
                updateStatusStrip(this.SerialPorts[portNumber(ports[ports.Count() - 1])]);
            }
            else
            {
                updateStatusStrip("新規接続するにはCtrl+Tを入力してください．");
            }
        }

        private void 保存SToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string Name = saveFileDialog1.FileName;
                for (int i = 0; i < P.MAX_PORT_NUMBER; i++)
                {
                    if (this.SerialPorts[i].FormTx != null)
                    {
                        WriteTx(Name, this.SerialPorts[i].FormTx);
                    }
                    if (this.SerialPorts[i].FormRx != null)
                    {
                        WriteRx(Name, this.SerialPorts[i].FormRx);
                    }
                }
            }

        }

        private void 基本設定EToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Setting s = new Setting(this.P);
            if (s.ShowDialog() == DialogResult.OK)
            {
                this.P = s.p;
            }
        }

        private void ToolStripMenuItem_Dummydata_Click(object sender, EventArgs e)
        {
            if (ToolStripMenuItem_Dummydata.Checked)
            {
                ToolStripMenuItem_Dummydata.Checked = false;
                this.DummyDataDraw.Abort();
            }
            else
            {
                ToolStripMenuItem_Dummydata.Checked = true;
                if (this.DummyDataDraw == null || !this.DummyDataDraw.IsAlive)
                {
                    this.DummyDataDraw = new Thread(new ThreadStart(addDummyThread));
                    this.DummyDataDraw.Name = "Dummy Data Controller";
                    this.DummyDataDraw.Start();
                }
            }
        }

        private void フォントの設定ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.fontDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                changeFont(this.fontDialog1.Font);
            }
        }

        private void デフォルトフォントに戻すGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            changeFont(this.BaseFont);
        }

        private void 表示フォントの変更ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.fontDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                changeFont(this.fontDialog1.Font);
            }
        }

        private void ショートカットの表示SToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = new Form();

            SortedDictionary<string, string> ht = new SortedDictionary<string, string>();

            StringBuilder ShortCutName = new StringBuilder();
            StringBuilder ShortCutButton = new StringBuilder();

            ht["F1"] = "ヘルプの起動";
            ht["F2"] = "バージョン情報の表示";
            ht["F3"] = "ショートカット一覧の表示";
            ht["Ctrl+T"] = "新規接続";
            ht["Ctrl+R"] = "接続可能な全ポートに接続";
            ht["Ctrl+W"] = "選択されている接続を閉じる";
            ht["Ctrl+S"] = "開いているポートのログを取る";
            ht["Ctrl+F"] = "ファイル送信";
            ht["Ctrl+E"] = "ターミナルと自動保存の設定を開く";
            ht["Ctrl+I"] = "設定の初期化";
            ht["Ctrl+D"] = "ダミーデータを受信ウィンドウに表示（デバッグ用）";
            ht["Ctrl+K"] = "系列の追加ウィザードを起動";
            ht["Ctrl+1"] = "「シリアルポート」タブに切り替え";
            ht["Ctrl+2"] = "「グラフ」タブに切り替え";
            ht["Ctrl+3"] = "「データリスト」タブに切り替え";
            ht["Ctrl+P"] = "フォントサイズを拡大";
            ht["Ctrl+M"] = "フォントサイズを縮小";
            ht["F7"] = "フォントの設定";

            int h = 20;
            int v = 20;
            int Height = 20;

            foreach (string s in ht.Keys)
            {
                Label l = new Label();
                Label l2 = new Label();
                l.Location = new Point(h, v);
                l2.Location = new Point(h + 305, v);
                l.TextAlign = ContentAlignment.TopLeft;
                l2.TextAlign = ContentAlignment.TopRight;
                l2.Text = s;
                l.Text = ht[s].ToString();
                l.AutoSize = false;
                l2.AutoSize = false;
                l.Size = new System.Drawing.Size(280, l.Height);
                l2.Size = new System.Drawing.Size(100, l2.Height);
                l.Font = l2.Font = new System.Drawing.Font("メイリオ", 9);
                f.Controls.Add(l);
                f.Controls.Add(l2);
                v += Height;
            }
            f.Width = 440;
            f.Height = v + 50;
            f.Icon = this.Icon;
            f.Text = "ショートカット一覧";
            f.Show();
        }

        private void 系列の追加ウィザードToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (getActiveSerialPortWindows() == 0)
            {
                MessageBox.Show("受信ウィンドウが全て閉じられています．1つ以上のポートに接続後再実行して下さい．", "ウィザード起動エラー");
                return;
            }
            SeriesWizard s = new SeriesWizard();
            if (s.ShowDialog() == DialogResult.OK)
            {
                foreach (Plot p in s.plots)
                {
                    addSeries(p);
                }
            }
        }

        private void 設定の初期化ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("ターミナルと自動保存の設定が初期化されます。よろしいですか？", "設定の初期化", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                NanoTerm.Properties.Settings.Default.Reset();
                MessageBox.Show("設定が初期化されました。", "設定の初期化", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SetParams();
            }
        }
        #endregion

        #endregion

        #region{ポートの接続状態を更新するスレッド}
        // シリアルポートの接続を確認し、切断されたポートを閉じる
        private void portWatchThread()
        {
            while (true)
            {
                try
                {
                    Thread.Sleep(P.THREAD_RECONNECT_INTERVAL);
                    portCheckDelegate p = new portCheckDelegate(portCheck);
                    Invoke(p);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("portWatchThreadError:" + ex.Message);
                }
            }
        }

        private delegate void portCheckDelegate();

        private void portCheck()
        {
            string[] ports = SerialPort.GetPortNames();
            bool[] isOpen = new bool[P.MAX_PORT_NUMBER];

            for (int i = 0; i < P.MAX_PORT_NUMBER; i++)
            {
                isOpen[i] = false;
            }

            foreach (string port in ports)
            {
                isOpen[portNumber(port)] = true;
            }

            for (int i = 0; i < P.MAX_PORT_NUMBER; i++)
            {
                SerialPortWindow w = this.SerialPorts[i];
                if (getTermWindowState(i) != TermWindowState.Null && getTermWindowState(i) != TermWindowState.BothClosed)
                {
                    if (getPortState(i) == PortState.OpenAndUnConnected)
                    {
                        reconnectPort("COM" + i.ToString());
                    }
                    else if (getPortState(i) == PortState.ClosedAndConnected || getPortState(i) == PortState.ClosedAndUnConnected)
                    {
                        if (w.FormTx != null)
                        {
                            w.FormTx.Text = getFormTitle(w.COM, FormType.Tx, w.TxFileName, w.Port.BaudRate, false, w.Port.IsOpen, w.FormTx.Controls[0]);
                        }
                        if (w.FormRx != null)
                        {
                            w.FormRx.Text = getFormTitle(w.COM, FormType.Rx, w.RxFileName, w.Port.BaudRate, false, w.Port.IsOpen, w.FormRx.Controls[0]);
                        }
                        if (w.FormBinary != null)
                        {
                            w.FormBinary.Text = getFormTitle(w.COM, FormType.Binary, w.BinaryFileName, w.Port.BaudRate, false, w.Port.IsOpen, w.FormBinary.Controls[0]);
                        }
                        this.SerialPorts[portNumber(w.COM)].isConnected = false;
                    }
                    else if (getPortState(i) == PortState.OpenAndConneced)
                    {
                        if (!w.Port.IsOpen && getOpenWindowCount(w.COM) == 0)
                        {
                            if (P.AUTO_RECONNECT)
                            {
                                try
                                {
                                    if (isOpenPort(w.COM))
                                    {
                                        w.Port.Open();
                                    }
                                }
                                catch
                                {

                                }
                                if (w.FormTx != null)
                                {
                                    w.FormTx.Text = getFormTitle(w.COM, FormType.Tx, w.TxFileName, w.Port.BaudRate, false, w.Port.IsOpen, w.FormTx.Controls[0]);
                                }
                                if (w.FormRx != null)
                                {
                                    w.FormRx.Text = getFormTitle(w.COM, FormType.Rx, w.RxFileName, w.Port.BaudRate, false, w.Port.IsOpen, w.FormRx.Controls[0]);
                                }
                                if (w.FormBinary != null)
                                {
                                    w.FormBinary.Text = getFormTitle(w.COM, FormType.Binary, w.BinaryFileName, w.Port.BaudRate, false, w.Port.IsOpen, w.FormBinary.Controls[0]);
                                }
                            }
                            else
                            {
                                return;
                            }
                        }
                        string receivedData = w.Port.ReadExisting();
                        if (receivedData.Length != 0)
                        {
                            this.SerialPorts[portNumber(w.COM)].ReceiveBytes += (ulong)Encoding.ASCII.GetByteCount(receivedData);
                            this.SerialPorts[portNumber(w.COM)].LastUpdate = DateTime.Now;
                            AddRecievedData(receivedData, (TextBox)w.FormRx.Controls[0]);
                            if (this.SerialPorts[portNumber(w.COM)].isFocused)
                            {
                                updateStatusStrip(this.SerialPorts[portNumber(w.COM)]);
                            }
                        }
                    }
                }
                else
                {
                    if (P.AUTO_CONNECT && getPortState(i) == PortState.OpenAndUnConnected)
                    {
                        openPort("COM" + i.ToString());
                    }
                }
            }

            #region{選択可能ポートの更新}
            if (SerialPort.GetPortNames().Count() != this.comboBox_Graph_Port.Items.Count)
            {
                this.comboBox_Graph_Port.Items.Clear();
                foreach (string portName in SerialPort.GetPortNames())
                {
                    this.comboBox_Graph_Port.Items.Add(portName);
                }
            }
            #endregion

        }
        #endregion

        #region{バックグラウンドでファイルを自動保存するスレッド}
        private void saveLogThread()
        {
            while (true)
            {
                try
                {
                    if (this.endSaveThread)
                    {
                        this.endSaveThread = false;
                        break;
                    }
                    Thread.Sleep(P.THREAD_SAVELOG_INTERVAL);
                    if (this.P.AUTO_SAVE)
                    {
                        saveLogDelegate s = new saveLogDelegate(saveLog);
                        Invoke(s);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("saveLogThreadError:" + ex.Message);
                }
            }
        }

        private delegate void saveLogDelegate();

        private void saveLog()
        {
            System.Diagnostics.Stopwatch s = new System.Diagnostics.Stopwatch();
            s.Start();

            for (int i = 0; i < P.MAX_PORT_NUMBER; i++)
            {
                if (TxWindowIsOpen(i) && this.SerialPorts[i].TxLogEnable)
                {
                    string append = ((TextBox)this.SerialPorts[i].FormTx.Controls[0]).Text.Substring((int)this.SerialPorts[i].TxLogIndex);
                    if (!endSaveThread)
                    {
                        this.SerialPorts[i].TxFile.Write(append);
                        this.SerialPorts[i].TxLogIndex = (ulong)((TextBox)this.SerialPorts[i].FormTx.Controls[0]).Text.Length;
                        this.SerialPorts[i].TxFile.Flush();
                    }
                }
                if (RxWindowIsOpen(i) && this.SerialPorts[i].RxLogEnable)
                {
                    string append = ((TextBox)this.SerialPorts[i].FormRx.Controls[0]).Text.Substring((int)this.SerialPorts[i].RxLogIndex);
                    if (!endSaveThread)
                    {
                        this.SerialPorts[i].RxFile.Write(append);
                        this.SerialPorts[i].RxLogIndex = (ulong)((TextBox)this.SerialPorts[i].FormRx.Controls[0]).Text.Length;
                        this.SerialPorts[i].RxFile.Flush();
                    }
                }
                if (BinaryWindowIsOpen(i) && this.SerialPorts[i].BinaryLogEnable)
                {
                    string append = ((TextBox)this.SerialPorts[i].FormBinary.Controls[0]).Text.Substring((int)this.SerialPorts[i].BinaryLogIndex);
                    if (!endSaveThread)
                    {
                        this.SerialPorts[i].BinaryFile.Write(append);
                        this.SerialPorts[i].BinaryLogIndex = (ulong)((TextBox)this.SerialPorts[i].FormBinary.Controls[0]).Text.Length;
                        this.SerialPorts[i].BinaryFile.Flush();
                    }
                }

            }

            s.Stop();
            //if (s.ElapsedMilliseconds > 2 * this.P.THREAD_SAVELOG_INTERVAL)
            //{
            //    this.P.THREAD_SAVELOG_INTERVAL = 4 * (int)s.ElapsedMilliseconds;
            //}
        }
        #endregion

        #region{ダミーデータをCOMに書き出すスレッド（デバッグ用）}
        private void addDummyThread()
        {
            while (true)
            {
                try
                {
                    Thread.Sleep(100);
                    addDummyDelegate s = new addDummyDelegate(addDummy);
                    Invoke(s);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("saveLogThreadError:" + ex.Message);
                }
            }
        }

        private delegate void addDummyDelegate();

        private void addDummy()
        {
            for (int i = 0; i < this.P.MAX_PORT_NUMBER; i++)
            {
                if (getTermWindowState(i) == TermWindowState.Opened || getTermWindowState(i) == TermWindowState.TxClosed)
                {
                    Random r = new Random();
                    Random r2 = new Random();
                    //string s = "[" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.ff") + "]" + "V:"+ r.NextDouble().ToString() + "I:" + (r.NextDouble() + 1).ToString() + " ,T:" + r.Next(65535).ToString("X") + "\r\n";
                    string s = "[" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.ff") + "]";
                    for (int j = 0; j < 10; j++)
                    {
                        s += r.NextDouble() + ",";
                    }
                    s += "\r\n";
                    ((TextBox)(this.SerialPorts[i].FormRx.Controls[0])).AppendText(s);
                }

            }
        }

        #endregion

        #region{受信ポートから有効なデータを抽出し，グラフ表示を更新するスレッド}

        private void updateGraphThread()
        {
            while (true)
            {
                try
                {
                    Thread.Sleep(P.THREAD_DRAWGRAPH_INTERVAL);
                    updateGraphDelegate u = new updateGraphDelegate(updateGraph);
                    Invoke(u);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("portWatchThreadError:" + ex.Message);
                }
            }
        }
        private delegate void updateGraphDelegate();

        private void updateGraph()
        {
            System.Diagnostics.Stopwatch s = new System.Diagnostics.Stopwatch();
            s.Start();

            string[] newStrings = new string[this.P.MAX_PORT_NUMBER];
            Hashtable h = new Hashtable();

            for (int i = 0; i < this.P.MAX_PORT_NUMBER; i++)
            {
                if (getTermWindowState(i) == TermWindowState.Opened || getTermWindowState(i) == TermWindowState.TxClosed)
                {
                    newStrings[i] = ((TextBox)(this.SerialPorts[i].FormRx.Controls[0])).Text.Substring((int)this.SerialPorts[i].DrawedIndex);
                    this.SerialPorts[i].DrawedIndex = (ulong)((TextBox)(this.SerialPorts[i].FormRx.Controls[0])).Text.Length;
                    Regex r = new Regex(@"\[");//タイムタグでSplit
                    h[i.ToString()] = r.Split(newStrings[i]);
                }
                else
                {
                    newStrings[i] = "";
                }
            }

            Hashtable ListViewData = new Hashtable();

            foreach (Plot p in this.DataSeries.Values)
            {
                if (newStrings[p.comNumber].Length == 0)
                {
                    continue; //系列が監視しているCOMに更新が無かったためパス
                }
                else//新規情報あり
                {
                    for (int i = 0; i < ((string[])h[p.comNumber.ToString()]).Count(); i++)
                    {
                        string str = ((string[])h[p.comNumber.ToString()])[i];
                        if (str.Length == 0)
                        {
                            continue;
                        }

                        try
                        {

                            string Regularexpressions = "";
                            int GroupIndex = 0;

                            KeyValuePair<DateTime, double> kv = new KeyValuePair<DateTime, double>();
                            KeyValuePair<DateTime, double> kv_convert = new KeyValuePair<DateTime, double>();

                            if (p.IsSeriesPlot == false)
                            {
                                Regularexpressions = p.Label + "[: ]?" + "([-0-9.a-fA-Fx]+)";
                                GroupIndex = 1;

                                kv = parseKeyValue(str, Regularexpressions, GroupIndex);
                                kv_convert = new KeyValuePair<DateTime, double>(kv.Key, kv.Value * p.a + p.b);
                            }
                            else
                            {
                                Regex r = new Regex(p.Splitter);
                                DateTime dt = parseTimeTag(str);

                                string[] str2;
                                if (p.Label.Length != 0)
                                {
                                    Regex r2 = new Regex(p.Label + "[: ]?");
                                    str2 = r2.Split(str);
                                }
                                else
                                {
                                    Regex r2 = new Regex(@"[0-9/ :.]+\][: ]?");//タイムタグでSplit
                                    str2 = r2.Split(str);
                                }

                                foreach (string strs in str2)
                                {
                                    if (strs.Length == 0)
                                    {
                                        continue;
                                    }
                                    string strs_trimmed = strs.Trim();//空白，改行コードなどは削除されるので注意
                                    string[] st = r.Split(strs_trimmed);
                                    if (st.Count() > p.SeriesIndex)
                                    {
                                        int dummyInt;
                                        double j;
                                        if (double.TryParse(st[p.SeriesIndex], NumberStyles.Number, CultureInfo.InvariantCulture, out j))
                                        {
                                            kv_convert = new KeyValuePair<DateTime, double>(dt, p.a * double.Parse(st[p.SeriesIndex]) + p.b);
                                            break;
                                        }
                                        else if (Int32.TryParse(st[p.SeriesIndex], NumberStyles.HexNumber, CultureInfo.InvariantCulture, out dummyInt))
                                        {
                                            kv_convert = new KeyValuePair<DateTime, double>(dt, p.a * Int32.Parse(st[p.SeriesIndex], NumberStyles.HexNumber) + p.b);
                                            break;
                                        }
                                    }
                                }

                            }

                            if (kv_convert.Key.Year != 1)
                            {
                                this.chart1.Series[p.Series].Points.AddXY(kv_convert.Key, kv_convert.Value);
                                this.chart1.ResetAutoValues();
                                if (ListViewData.ContainsKey(kv_convert.Key.ToString("yyyy/MM/dd HH:mm:ss.ff")))
                                {
                                    int index = this.listView1.Columns[p.Series].Index;
                                    ((string[])(ListViewData[kv_convert.Key.ToString("yyyy/MM/dd HH:mm:ss.ff")]))[index] = kv_convert.Value.ToString();
                                }
                                else
                                {
                                    if (this.FirstPlotTime.Year == 1)
                                    {
                                        this.FirstPlotTime = DateTime.Now;
                                    }
                                    ListViewData[kv_convert.Key.ToString("yyyy/MM/dd HH:mm:ss.ff")] = new string[this.listView1.Columns.Count];
                                    ((string[])(ListViewData[kv_convert.Key.ToString("yyyy/MM/dd HH:mm:ss.ff")]))[0] = kv_convert.Key.ToString("yyyy/MM/dd HH:mm:ss.ff");
                                    TimeSpan t = kv_convert.Key - this.FirstPlotTime;
                                    ((string[])(ListViewData[kv_convert.Key.ToString("yyyy/MM/dd HH:mm:ss.ff")]))[1] = t.TotalMilliseconds.ToString();
                                    int index = this.listView1.Columns[p.Series].Index;
                                    ((string[])(ListViewData[kv_convert.Key.ToString("yyyy/MM/dd HH:mm:ss.ff")]))[index] = kv_convert.Value.ToString();
                                }
                            }


                        }
                        catch (Exception)
                        {

                        }

                        ////XYPair
                        //DateTime d = parseTimeTag(str);
                        //double value;
                        //int intval = 0;

                        //#region{Valueの抽出}
                        //Regex r = new Regex(p.Label + "[: ]?" + "([-0-9.a-fA-Fx]+)");//系列名でマッチするものを探す
                        //Match m = r.Match(str);
                        //#endregion
                        //Console.WriteLine("label:" + p.Label + "& str:" + str + " & out:" + m.Groups[1]);
                        //try
                        //{
                        //    if (m.Success)
                        //    {
                        //        //10進数または16進数（0x形式も可）
                        //        if (double.TryParse(m.Groups[1].Value,NumberStyles.Number,CultureInfo.InvariantCulture,out value) || Int32.TryParse(m.Groups[1].Value, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out intval))
                        //        {
                        //            if (intval == 0)
                        //            {
                        //                value = value * p.a + p.b;
                        //            }
                        //            else
                        //            {
                        //                value = (double)intval * p.a + p.b;
                        //            }

                        //            this.chart1.Series[p.Series].Points.AddXY(d, value);
                        //            this.chart1.ResetAutoValues();
                        //            if (ListViewData.ContainsKey(d.ToString("yyyy/MM/dd HH:mm:ss.ff")))
                        //            {
                        //                int index = this.listView1.Columns[p.Series].Index;
                        //                ((string[])(ListViewData[d.ToString("yyyy/MM/dd HH:mm:ss.ff")]))[index] = value.ToString();
                        //            }
                        //            else
                        //            {
                        //                ListViewData[d.ToString("yyyy/MM/dd HH:mm:ss.ff")] = new string[this.listView1.Columns.Count];
                        //                ((string[])(ListViewData[d.ToString("yyyy/MM/dd HH:mm:ss.ff")]))[0] = d.ToString("yyyy/MM/dd HH:mm:ss.ff");
                        //                TimeSpan t = d - this.FirstPlotTime;
                        //                ((string[])(ListViewData[d.ToString("yyyy/MM/dd HH:mm:ss.ff")]))[1] = t.TotalMilliseconds.ToString();
                        //                int index = this.listView1.Columns[p.Series].Index;
                        //                ((string[])(ListViewData[d.ToString("yyyy/MM/dd HH:mm:ss.ff")]))[index] = value.ToString();
                        //            }
                        //        }
                        //    }
                        //}
                        //catch(Exception e)
                        //{
                        //    MessageBox.Show(e.Message,"グラフ描画時エラー");
                        //}
                    }
                }

            }
            SortedList so = new SortedList(ListViewData);

            foreach (string[] l in so.Values)
            {
                this.listView1.Items.Add(new ListViewItem(l));
            }

            checkAndSaveListView();

            s.Stop();
            //if (s.ElapsedMilliseconds > 2 * this.P.THREAD_DRAWGRAPH_INTERVAL)
            //{
            //    this.P.THREAD_DRAWGRAPH_INTERVAL = 4 * (int)s.ElapsedMilliseconds;
            //    this.toolStripStatusLabel2.Text = this.P.THREAD_DRAWGRAPH_INTERVAL.ToString() + "ms毎に更新";
            //}
        }

        #endregion

        #region{マウスオーバー時の解説}

        private void textBox_Graph_Name_MouseHover(object sender, EventArgs e)
        {
            this.toolStripStatusLabel3.Text = "系列の名前を設定します．";
        }

        private void textBox_Graph_Label_MouseHover(object sender, EventArgs e)
        {
            this.toolStripStatusLabel3.Text = "つなたーむ上の表示とデータを関連付けるラベルを設定します．(例)VBAT:2.00V→VBAT";
        }

        private void textBox_Graph_Label_MouseLeave(object sender, EventArgs e)
        {
            this.toolStripStatusLabel3.Text = "";
        }

        private void textBox_Graph_Name_MouseLeave(object sender, EventArgs e)
        {
            this.toolStripStatusLabel3.Text = "";
        }

        private void comboBox_Graph_Port_MouseHover(object sender, EventArgs e)
        {
            this.toolStripStatusLabel3.Text = "データ系列のソースとなるCOM番号を設定します．";
        }

        private void comboBox_Graph_Type_MouseHover(object sender, EventArgs e)
        {
            this.toolStripStatusLabel3.Text = "グラフの種類を指定します．";
        }

        private void comboBox_Graph_Type_MouseLeave(object sender, EventArgs e)
        {
            this.toolStripStatusLabel3.Text = "";
        }

        private void comboBox_Graph_Port_MouseLeave(object sender, EventArgs e)
        {
            this.toolStripStatusLabel3.Text = "";
        }

        private void textBox_Graph_b_MouseHover(object sender, EventArgs e)
        {
            this.toolStripStatusLabel3.Text = "つなたーむ上の表示値xをグラフおよびデータリストへの描画値yに変換する式を指定します．";
        }

        private void textBox_Graph_b_MouseLeave(object sender, EventArgs e)
        {
            this.toolStripStatusLabel3.Text = "";
        }

        private void textBox_Graph_a_MouseHover(object sender, EventArgs e)
        {
            this.toolStripStatusLabel3.Text = "つなたーむ上の表示値xをグラフおよびデータリストへの描画値yに変換する式を指定します．";
        }

        private void textBox_Graph_a_MouseLeave(object sender, EventArgs e)
        {
            this.toolStripStatusLabel3.Text = "";
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        #region{メインメソッドから呼び出されるUtility}
       
        private void closePort(int portNumber)
        {
            if (this.SerialPorts[portNumber].FormTx != null)
            {
                this.SerialPorts[portNumber].FormTx.Dispose();
            }
            if (this.SerialPorts[portNumber].FormRx != null)
            {
                this.SerialPorts[portNumber].FormRx.Dispose();
            }
            if (this.SerialPorts[portNumber].FormBinary != null)
            {
                this.SerialPorts[portNumber].FormBinary.Dispose();
            }
            this.SerialPorts[portNumber].Port.Dispose();
            if (this.SerialPorts[portNumber].TxFile != null)
            {
                this.SerialPorts[portNumber].TxFile.Flush();
                this.SerialPorts[portNumber].TxFile.Close();
            }
            if (this.SerialPorts[portNumber].RxFile != null)
            {
                this.SerialPorts[portNumber].RxFile.Flush();
                this.SerialPorts[portNumber].RxFile.Close();
            }
            this.SerialPorts[portNumber] = new SerialPortWindow();
            resizeWindows();
        }

        private void WriteTx(string fileName, Form TxForm)
        {
            TextBox t = (TextBox)(TxForm.Controls[0]);
            string path = Path.GetDirectoryName(fileName) + @"\" + Path.GetFileNameWithoutExtension(fileName) + "_" + Name + "_Tx.txt";
            try
            {
                StreamWriter f = new StreamWriter(path, false, Encoding.GetEncoding("Shift_JIS"));
                this.LogFiles.Add(path);
                f.Write(t.Text);
                f.Flush();
            }
            #region{StreamWriter用例外処理ブロック}
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("ログファイルの生成に失敗しました。設定されたパスにアクセスする権限があるか確認して下さい。\n\n" + path, "ファイル新規作成時エラー");
            }
            catch (ArgumentException)
            {
                MessageBox.Show("ログファイルの生成に失敗しました。ファイル名が空の文字列でないか確認して下さい。\n\n" + path, "ファイル新規作成時エラー");
            }
            catch (PathTooLongException)
            {
                MessageBox.Show("ログファイルの生成に失敗しました。指定したパス、ファイル名、またはその両方がシステム定義の最大長を超えています。\n\n" + path, "ファイル新規作成時エラー");
            }
            catch (IOException)
            {
                MessageBox.Show("ログファイルの生成に失敗しました。ファイル名、ディレクトリ名、またはボリューム ラベルの不正な構文または無効な構文が含まれています。\n\n" + path, "ファイル新規作成時エラー");
            }
            #endregion
        }

        private void WriteRx(string fileName, Form RxForm)
        {
            TextBox t = (TextBox)RxForm.Controls[0];
            string path = Path.GetDirectoryName(fileName) + @"\" + Path.GetFileNameWithoutExtension(fileName) + "_" + Name + "_Rx.txt";
            try
            {
                StreamWriter f = new StreamWriter(path, false, Encoding.GetEncoding("Shift_JIS"));
                this.LogFiles.Add(path);
                f.Write(t.Text);
                f.Flush();
            }
            #region{StreamWriter用例外処理ブロック}
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("ログファイルの生成に失敗しました。設定されたパスにアクセスする権限があるか確認して下さい。\n\n" + path, "ファイル新規作成時エラー");
            }
            catch (ArgumentException)
            {
                MessageBox.Show("ログファイルの生成に失敗しました。ファイル名が空の文字列でないか確認して下さい。\n\n" + path, "ファイル新規作成時エラー");
            }
            catch (PathTooLongException)
            {
                MessageBox.Show("ログファイルの生成に失敗しました。指定したパス、ファイル名、またはその両方がシステム定義の最大長を超えています。\n\n" + path, "ファイル新規作成時エラー");
            }
            catch (IOException)
            {
                MessageBox.Show("ログファイルの生成に失敗しました。ファイル名、ディレクトリ名、またはボリューム ラベルの不正な構文または無効な構文が含まれています。\n\n" + path, "ファイル新規作成時エラー");
            }
            #endregion
        }

        private void resizeWindows()
        {
            try
            {
                if (this.SerialPorts == null)
                {
                    return;
                }
                this.windowHeight = (int)((this.tabControl1.Height - this.statusStrip1.Height - 28) * 0.333);
                if (getActiveSerialPortWindows() != 0)
                {
                    this.windowWidth = (int)((this.tabControl1.Width - 8) / getActiveSerialPortWindows());
                }
                int xIndex = 0;

                foreach (SerialPortWindow w in this.SerialPorts)
                {
                    if (w.COM == null)
                    {
                        continue;
                    }
                    int windows = getOpenWindowCount(portNumber(w.COM));
                    if (windows != 0)
                    {
                        int comNumber = portNumber(w.COM);
                        int height = (int)((this.tabControl1.Height - this.statusStrip1.Height - 28) / windows);
                        int yIndex = 0;

                        if (this.SerialPorts[comNumber].FormTx != null)
                        {
                            this.SerialPorts[comNumber].FormTx.Height = height;
                            this.SerialPorts[comNumber].FormTx.Width = this.windowWidth;
                            this.SerialPorts[comNumber].FormTx.Left = xIndex;
                            if (TxWindowIsOpen(w.COM))
                            {
                                this.SerialPorts[comNumber].FormTx.Top = yIndex;
                                yIndex += height;
                            }
                        }
                        if (this.SerialPorts[comNumber].FormRx != null)
                        {
                            this.SerialPorts[comNumber].FormRx.Height = height;
                            this.SerialPorts[comNumber].FormRx.Width = this.windowWidth;
                            this.SerialPorts[comNumber].FormRx.Left = xIndex;
                            if (RxWindowIsOpen(w.COM))
                            {
                                this.SerialPorts[comNumber].FormRx.Top = yIndex;
                                yIndex += height;
                            }
                        }
                        if (this.SerialPorts[comNumber].FormBinary != null)
                        {
                            this.SerialPorts[comNumber].FormBinary.Height = height;
                            this.SerialPorts[comNumber].FormBinary.Width = this.windowWidth;
                            this.SerialPorts[comNumber].FormBinary.Left = xIndex;
                            this.SerialPorts[comNumber].FormBinary.Top = yIndex;
                        }

                        xIndex += this.windowWidth;
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// グラフとリストビューをすべてリセットします．
        /// </summary>
        private void clearAllGraphAndListView()
        {
            this.chart1.Series.Clear();
            this.chart1.Titles.Clear();
            this.listView1.Items.Clear();
            this.comboBox_deleteList.Items.Clear();
            this.DataSeries = new Hashtable();
            this.FirstPlotTime = new DateTime();
            this.dataGridView_Series.Rows.Clear();

            List<string> columns = new List<string>();
            for (int i = 2; i < this.listView1.Columns.Count; i++)
            {
                columns.Add(this.listView1.Columns[i].Name);
            }
            foreach (string column in columns)
            {
                this.listView1.Columns.Remove(this.listView1.Columns[column]);
            }
        }

        #region{ポート，ウィンドウの状態を得るメソッド類}

        /// <summary>
        /// String型のポート名配列からポート番号配列を取得します．
        /// </summary>
        /// <param name="comName"></param>
        /// <returns></returns>
        public static int[] portNumbers(string[] comName)
        {
            List<int> ports = new List<int>();
            foreach (string port in comName)
            {
                ports.Add(portNumber(port));
            }
            return ports.ToArray();
        }

        /// <summary>
        /// String型のポート名からポート番号を取得します．
        /// </summary>
        /// <param name="comName"></param>
        /// <returns></returns>
        public static int portNumber(string comName)
        {
            return int.Parse(comName.Substring(3));
        }

        /// <summary>
        /// 指定したポートがSerialPort.GetPortNames()メソッドに含まれているかを判定します．
        /// </summary>
        /// <param name="comNumber"></param>
        /// <returns></returns>
        public static bool isOpenPort(int comNumber)
        {
            int[] ports = portNumbers(SerialPort.GetPortNames());
            foreach (int port in ports)
            {
                if (port == comNumber)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 指定したポートがSerialPort.GetPortNames()メソッドに含まれているかを判定します．
        /// </summary>
        /// <param name="COM"></param>
        /// <returns></returns>
        public static bool isOpenPort(string COM)
        {
            string[] ports = SerialPort.GetPortNames();
            foreach (string port in ports)
            {
                if (port == COM)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// ウインドウが1個以上開かれているシリアルポートの数を取得します
        /// </summary>
        /// <returns></returns>
        private int getActiveSerialPortWindows()
        {
            int count = 0;
            for (int i = 0; i < this.P.MAX_PORT_NUMBER; i++)
            {
                if (getOpenWindowCount(i) != 0)
                {
                    count++;
                }
            }
            return count;
        }

        /// <summary>
        /// Tx/Rx/Binaryのうち，何個のウィンドウが開いているかを返します
        /// </summary>
        /// <param name="comNumber"></param>
        /// <returns></returns>
        private int getOpenWindowCount(string COM)
        {
            return getOpenWindowCount(portNumber(COM));
        }

        /// <summary>
        /// Tx/Rx/Binaryのうち，何個のウィンドウが開いているかを返します
        /// </summary>
        /// <param name="comNumber"></param>
        /// <returns></returns>
        private int getOpenWindowCount(int comNumber)
        {
            int count = 0;
            if (this.SerialPorts[comNumber].FormTx != null && this.SerialPorts[comNumber].FormTx.Controls.Count != 0)
            {
                count++;
            }
            if (this.SerialPorts[comNumber].FormRx != null && this.SerialPorts[comNumber].FormRx.Controls.Count != 0)
            {
                count++;
            }
            if (this.SerialPorts[comNumber].FormBinary != null && this.SerialPorts[comNumber].FormBinary.Controls.Count != 0)
            {
                count++;
            }
            return count;
        }

        /// <summary>
        /// ウインドウが開かれているシリアルポート名の配列を取得します
        /// </summary>
        /// <returns></returns>
        private string[] getWindowPortNames()
        {
            List<string> windows = new List<string>();
            foreach (SerialPortWindow w in this.SerialPorts)
            {
                if (w.COM != null && getOpenWindowCount(w.COM) != 0)
                {
                    windows.Add(w.COM);
                }
            }
            return windows.ToArray();
        }

        /// <summary>
        /// SerialPortクラスが返すCOMポートのうち，新規接続が可能なポートを返す
        /// </summary>
        /// <param name="portNames"></param>
        /// <returns></returns>
        private string[] getNewPorts()
        {
            string[] portNames = SerialPort.GetPortNames();
            List<string> newPorts = new List<string>();
            foreach (string port in portNames)
            {
                if (getPortState(port) == PortState.OpenAndUnConnected)
                {
                    newPorts.Add(port);
                }
            }
            return newPorts.ToArray();
        }

        /// <summary>
        /// COMポートとウィンドウの状態を取得します．
        /// </summary>
        /// <param name="COM"></param>
        /// <returns></returns>
        private PortState getPortState(string COM)
        {
            return getPortState(portNumber(COM));
        }

        /// <summary>
        /// COMポートが開いているか/NanoTermがハンドルしているかの状態を取得します．
        /// </summary>
        /// <param name="comNumber"></param>
        /// <returns></returns>
        private PortState getPortState(int comNumber)
        {
            bool isOpen = isOpenPort(comNumber);

            if (this.SerialPorts[comNumber].Port == null || !this.SerialPorts[comNumber].Port.IsOpen)
            {
                if (isOpen)
                {
                    return PortState.OpenAndUnConnected;
                }
                else
                {
                    return PortState.ClosedAndUnConnected;
                }
            }
            else
            {
                if (isOpen)
                {
                    return PortState.OpenAndConneced;
                }
                else
                {
                    return PortState.ClosedAndConnected;
                }
            }
        }

        /// <summary>
        /// Tx,Rxウィンドウの状態を取得します．
        /// </summary>
        /// <param name="COM"></param>
        /// <returns></returns>
        private TermWindowState getTermWindowState(string COM)
        {
            return getTermWindowState(portNumber(COM));
        }

        /// <summary>
        /// Tx,Rxウィンドウの状態を取得します．
        /// </summary>
        /// <param name="comNumber"></param>
        /// <returns></returns>
        private TermWindowState getTermWindowState(int comNumber)
        {
            if (this.SerialPorts[comNumber].FormTx == null || this.SerialPorts[comNumber].FormRx == null)
            {
                return TermWindowState.Null;
            }
            else if (this.SerialPorts[comNumber].FormTx != null && this.SerialPorts[comNumber].FormTx.Controls.Count == 0)
            {
                if (this.SerialPorts[comNumber].FormRx != null && this.SerialPorts[comNumber].FormRx.Controls.Count == 0)
                {
                    return TermWindowState.BothClosed;
                }
                else
                {
                    return TermWindowState.TxClosed;
                }
            }
            else if (this.SerialPorts[comNumber].FormRx != null && this.SerialPorts[comNumber].FormRx.Controls.Count == 0)
            {
                return TermWindowState.RxClosed;
            }
            else
            {
                return TermWindowState.Opened;
            }
        }

        private bool TxWindowIsOpen(string COM)
        {
            return TxWindowIsOpen(portNumber(COM));
        }

        private bool TxWindowIsOpen(int comNumber)
        {
            if (this.SerialPorts[comNumber].FormTx == null || this.SerialPorts[comNumber].FormTx.Controls.Count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }         
        }

        private bool RxWindowIsOpen(string COM)
        {
            return RxWindowIsOpen(portNumber(COM));           
        }
        private bool RxWindowIsOpen(int comNumber)
        {
            if (this.SerialPorts[comNumber].FormRx == null || this.SerialPorts[comNumber].FormRx.Controls.Count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool BinaryWindowIsOpen(string COM)
        {
            return BinaryWindowIsOpen(portNumber(COM));
        }

        private bool BinaryWindowIsOpen(int comNumber)
        {
            if (this.SerialPorts[comNumber].FormBinary == null || this.SerialPorts[comNumber].FormBinary.Controls.Count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        #endregion

        /// <summary>
        /// 全ポートのフォントを変更します．
        /// </summary>
        /// <param name="f">変更後のフォント</param>
        private void changeFont(Font f)
        {
            for (int i = 0; i < P.MAX_PORT_NUMBER; i++)
            {
                if (this.SerialPorts[i].FormTx != null && this.SerialPorts[i].FormTx.Controls.Count != 0)
                {
                    TextBox t = this.SerialPorts[i].FormTx.Controls[0] as TextBox;
                    t.Font = f;
                }
                if (this.SerialPorts[i].FormRx != null && this.SerialPorts[i].FormRx.Controls.Count != 0)
                {
                    TextBox t = this.SerialPorts[i].FormRx.Controls[0] as TextBox;
                    t.Font = f;
                }
                if (this.SerialPorts[i].FormBinary != null && this.SerialPorts[i].FormBinary.Controls.Count != 0)
                {
                    TextBox t = this.SerialPorts[i].FormBinary.Controls[0] as TextBox;
                    t.Font = f;
                }
            }
        }

        /// <summary>
        /// 全ポートのフォントサイズを指定した値分変化させます
        /// </summary>
        /// <param name="dSize">フォントサイズの変化分．（単位em）</param>
        private void changeFontSize(int dSize)
        {

            for (int i = 0; i < P.MAX_PORT_NUMBER; i++)
            {
                if (this.SerialPorts[i].FormTx != null && this.SerialPorts[i].FormTx.Controls.Count != 0)
                {
                    TextBox t = this.SerialPorts[i].FormTx.Controls[0] as TextBox;
                    if (t.Font.Size + dSize > this.minimumFontSize && t.Font.Size + dSize < this.maximumFontSize)
                    {
                        t.Font = new Font(t.Font.FontFamily, t.Font.Size + dSize);
                    }
                }
                if (this.SerialPorts[i].FormRx != null && this.SerialPorts[i].FormRx.Controls.Count != 0)
                {
                    TextBox t = this.SerialPorts[i].FormRx.Controls[0] as TextBox;
                    if (t.Font.Size + dSize > this.minimumFontSize && t.Font.Size + dSize < this.maximumFontSize)
                    {
                        t.Font = new Font(t.Font.FontFamily, t.Font.Size + dSize);
                    }
                }
                if (this.SerialPorts[i].FormBinary != null && this.SerialPorts[i].FormBinary.Controls.Count != 0)
                {
                    TextBox t = this.SerialPorts[i].FormBinary.Controls[0] as TextBox;
                    if (t.Font.Size + dSize > this.minimumFontSize && t.Font.Size + dSize < this.maximumFontSize)
                    {
                        t.Font = new Font(t.Font.FontFamily, t.Font.Size + dSize);
                    }
                }
            }
        }

        /// <summary>
        /// シリアルタブのステータスバーに現在の送受信バイト数を表示します。
        /// </summary>
        /// <param name="w">表示するシリアルポート</param>
        void updateStatusStrip(SerialPortWindow w)
        {
            if (w.Port != null)
            {
                this.label.Text = w.Port.PortName + "/" + w.Port.BaudRate + "bps 送信 " + w.SendBytes + "bytes / 受信 " + w.ReceiveBytes + "bytes";
            }
        }

        /// <summary>
        /// シリアルタブのステータスバーに文字列を表示します。
        /// </summary>
        /// <param name="w">表示する文字列</param>
        void updateStatusStrip(string w)
        {
            this.label.Text = w;
        }

        /// <summary>
        /// グラフ描画域のビットマップオブジェクトを取得します．
        /// </summary>
        /// <returns></returns>
        private Bitmap getChartBitMap()
        {
            Rectangle rec = this.RectangleToScreen(this.chart1.Bounds);
            Bitmap bitmap = new Bitmap(rec.Width, rec.Height, PixelFormat.Format32bppArgb);
            this.tabPage2.DrawToBitmap(bitmap, new Rectangle(0, 0, rec.Width, rec.Height));
            return bitmap;
        }

        /// <summary>
        /// リストビューの要素数が閾値をこえているとき，自動保存
        /// </summary>
        private void checkAndSaveListView()
        {
            if (!this.checkBox_ListAutoSave.Checked || this.ListViewSaver.AutoSaveSettingDone == false)
            {
                this.toolStripStatusLabel5.Text = "現在の行数:" + this.listView1.Items.Count + "(自動保存：無効)";
                return;
            }
            if (this.listView1.Items.Count >= this.ListViewSaver.Columns)
            {
                string path = this.ListViewSaver.Folder + @"\" + this.ListViewSaver.FileHeadName + "_" + this.ListViewSaver.CurrentIndex.ToString() + ".csv";

                if (checkBox_ListAutoSave_SaveImage.Checked)
                {
                    string imagePath = System.IO.Path.GetDirectoryName(path) + @"\" + System.IO.Path.GetFileNameWithoutExtension(path) + ".bmp";
                    getChartBitMap().Save(imagePath, ImageFormat.Bmp);
                }

                try
                {
                    saveCSV(path);
                }
                #region{StreamWriter用例外処理ブロック}
                catch (UnauthorizedAccessException)
                {
                    this.toolStripStatusLabel5.Text ="ログファイルの生成に失敗しました。設定されたパスにアクセスする権限があるか確認して下さい。";
                    return;
                }
                catch (ArgumentException)
                {
                    this.toolStripStatusLabel5.Text ="ログファイルの生成に失敗しました。ファイル名が空の文字列でないか確認して下さい。";
                    return;
                }
                catch (PathTooLongException)
                {
                    this.toolStripStatusLabel5.Text = "ログファイルの生成に失敗しました。指定したパス、ファイル名、またはその両方がシステム定義の最大長を超えています。";
                    return;
                }
                catch (IOException)
                {
                    this.toolStripStatusLabel5.Text ="ログファイルの生成に失敗しました。ファイル名、ディレクトリ名、またはボリューム ラベルの不正な構文または無効な構文が含まれています。";
                    return;
                }
                #endregion

                this.listView1.Items.Clear();
                for (int i = 0; i < this.chart1.Series.Count; i++)
                {
                    this.chart1.Series[i].Points.Clear();
                }
                GC.Collect(); //リソース解放後，強制的にガベージコレクトを実施
                this.ListViewSaver.CurrentIndex++;
                this.toolStripStatusLabel5.Text = "ファイル保存完了:" + path;
            }
            else
            {
                this.toolStripStatusLabel5.Text = "現在の行数:" + this.listView1.Items.Count + "(次の保存まで：" + (this.ListViewSaver.Columns - this.listView1.Items.Count) + "行)";
            }
        }

        /// <summary>
        /// ListViewの内容を指定したPathにCSVで保存します．
        /// </summary>
        /// <param name="path"></param>
        private void saveCSV(string path)
        {
            StringBuilder sb = new StringBuilder();

            if (checkBox_saveDeletedData.Checked)
            {
                foreach (ColumnHeader ch in this.listView1.Columns)
                {
                    sb.Append(ch.Text + ",");
                }
                sb.Append("\n");

                foreach (ListViewItem lvi in this.listView1.Items)
                {
                    foreach (ListViewItem.ListViewSubItem subItem in lvi.SubItems)
                    {

                        sb.Append(subItem.Text + ",");
                    }
                    sb.Append("\n");
                }
            }
            else
            {
                foreach (ColumnHeader ch in this.listView1.Columns)
                {
                    if (ch.Width == 0)
                    {
                        continue;
                    }
                    sb.Append(ch.Text + ",");
                }
                sb.Append("\n");

                int count = this.listView1.Columns.Count;

                foreach (ListViewItem lvi in this.listView1.Items)
                {
                    for (int i = 0; i < lvi.SubItems.Count; i++)
                    {
                        if (this.listView1.Columns[i].Width == 0)
                        {
                            continue;
                        }
                        sb.Append(lvi.SubItems[i].Text + ",");
                    }
                    sb.Append("\n");
                }
            }
            sb.Replace(",\n", "\n");
            System.IO.StreamWriter sw = new StreamWriter(path, false, Encoding.GetEncoding("Shift_JIS"));
            sw.Write(sb.ToString());
            sw.Flush();
        }

        /// <summary>
        /// 文字列から最初に出てきたタイムタグを抽出．一個も無い場合は現在時刻を返す
        /// </summary>
        /// <param name="String"></param>
        /// <returns></returns>
        private DateTime parseTimeTag(string String)
        {
            Regex r = new Regex(@"([0-9]{4}/[0-9]{2}/[0-9]{2} [0-9]{2}:[0-9]{2}:[0-9]{2})[a-zA-Z]?\]"); // yyyy/MM/dd HH:mm:ss

            Match m = r.Match(String);
            DateTime result = new DateTime();
            if (m.Success)
            {
                while (m.Success)
                {
                    if (DateTime.TryParse(m.Groups[1].Value, out result))
                    {
                        return DateTime.Parse(m.Groups[1].Value);
                    }
                    else
                    {
                        m = m.NextMatch();
                    }
                }
            }

            Regex r2 = new Regex(@"([0-9]{4}/[0-9]{2}/[0-9]{2} [0-9]{2}:[0-9]{2}:[0-9]{2}\.[0-9]{2})[a-zA-Z]?\]"); // yyyy/MM/dd HH:mm:ss.ff
            m = r2.Match(String);
            if (m.Success)
            {
                while (m.Success)
                {
                    if (DateTime.TryParse(m.Groups[1].Value, out result))
                    {
                        return DateTime.Parse(m.Groups[1].Value);
                    }
                    else
                    {
                        m = m.NextMatch();
                    }
                }
            }

            Regex r3 = new Regex(@"([0-9]{2}:[0-9]{2}:[0-9]{2})[a-zA-Z]?\]"); // HH:mm:ss
            m = r3.Match(String);
            if (m.Success)
            {
                while (m.Success)
                {
                    string val = DateTime.Now.ToString("yyyy/MM/dd") + " " + m.Groups[1].Value;
                    if (DateTime.TryParse(val, out result))
                    {
                        return DateTime.Parse(m.Groups[1].Value);
                    }
                    else
                    {
                        m = m.NextMatch();
                    }
                }
            }

            Regex r4 = new Regex(@"([0-9]{2}:[0-9]{2}:[0-9]{2}\.[0-9]{2})[a-zA-Z]?\]"); // HH:mm:ss.ff
            m = r4.Match(String);
            if (m.Success)
            {
                while (m.Success)
                {
                    string val = DateTime.Now.ToString("yyyy/MM/dd") + " " + m.Groups[1].Value;
                    if (DateTime.TryParse(val, out result))
                    {
                        return DateTime.Parse(m.Groups[1].Value);
                    }
                    else
                    {
                        m = m.NextMatch();
                    }
                }
            }

            return DateTime.Now;
        }

        /// <summary>
        /// グラフにデータ系列を新規追加
        /// </summary>
        /// <param name="Name">系列名</param>
        /// <param name="ComNumber">監視対象COM</param>
        /// <param name="a">表示値→物理値の一次変換係数(y=ax+b)</param>
        /// <param name="b">表示値→物理値の一次変換係数(y=ax+b)</param>
        /// <param name="Label">データ抽出に使用する正規表現</param>
        private void addSeries(string Name, int ComNumber, double a, double b, string Label)
        {
            addSeries(Name, ComNumber, a, b, Label, false, SeriesChartType.FastLine);
        }

        /// <summary>
        /// グラフにデータ系列を新規追加
        /// </summary>
        /// <param name="Name">系列名</param>
        /// <param name="ComNumber">監視対象COM</param>
        /// <param name="a">表示値→物理値の一次変換係数(y=ax+b)</param>
        /// <param name="b">表示値→物理値の一次変換係数(y=ax+b)</param>
        /// <param name="Label">データ抽出に使用する正規表現</param>
        /// <param name="isSecondaryAxis">y軸に第2軸を使用</param>
        /// <param name="Type">グラフの種類</param>
        private void addSeries(string Name, int ComNumber, double a, double b, string Label, bool isSecondaryAxis, SeriesChartType Type)
        {
            foreach (Plot Plot in this.DataSeries.Values)
            {
                if (Plot.Series == Name)
                {
                    MessageBox.Show("既にその系列名は使用されています");
                    return;
                }
            }
            if (ComNumber < 0 || ComNumber > this.P.MAX_PORT_NUMBER)
            {
                MessageBox.Show("ポート番号の指定が無効です");
                return;
            }

            Plot p = new Plot();
            p.a = a;
            p.b = b;
            p.comNumber = ComNumber;
            p.COM = "COM" + ComNumber.ToString();
            p.Series = Name;
            p.Label = Label;
            p.MarkerStyle = this.dafaultMarkerStyle;
            p.MarkerSize = this.defaultMarkerSize;
            if (isSecondaryAxis)
            {
                p.YAxisType = AxisType.Secondary;
            }
            else
            {
                p.YAxisType = AxisType.Primary;
            }
            p.ChartType = Type;

            addSeries(p);
        }

        /// <summary>
        /// グラフにデータ系列を新規追加
        /// </summary>
        /// <param name="p"></param>
        private void addSeries(Plot plot)
        {

            foreach (Plot Plot in this.DataSeries.Values)
            {
                if (Plot.Series == plot.Series)
                {
                    MessageBox.Show("既にその系列名は使用されています");
                    return;
                }
            }

            Series s = new Series(plot.Series);
            s.ChartType = plot.ChartType;
            s.XValueType = ChartValueType.DateTime;
            s.YAxisType = plot.YAxisType;
            s.MarkerStyle = plot.MarkerStyle;
            s.MarkerSize = plot.MarkerSize;


            if (!this.SerialPorts[plot.comNumber].RxTimeStamp)
            {
                if (MessageBox.Show("受信データから正しくデータをグラフ化するためには，" +
                    plot.COM + "の受信タイムタグを有効化する必要があります．\nタイムタグ設定を有効化しますか？", "タイムタグ設定の追加", MessageBoxButtons.YesNo)
                    == DialogResult.Yes)
                {
                    this.SerialPorts[plot.comNumber].RxTimeStamp = true;
                }
            }

            ColumnHeader h = new ColumnHeader();
            h.Name = plot.Series;
            h.Text = plot.Series;

            if (!this.listView1.Columns.Contains(h))
            {
                this.listView1.Columns.Add(h);
            }

            DataGridViewRow row = new DataGridViewRow();
            row.CreateCells(this.dataGridView_Series, true, plot.Series);
            this.dataGridView_Series.Rows.Add(row);

            this.comboBox_deleteList.Items.Add(plot.Series);

            this.chart1.Series.Add(s);
            this.chart1.ResetAutoValues();

            this.DataSeries[plot.Series] = plot;
        }

        /// <summary>
        /// グラフ設定をシリアライズしてxmlに書き出します。
        /// </summary>
        /// <param name="path"></param>
        private void xmlSerialize(string path)
        {
            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(Graph));
            FileStream fs;
            try
            {
                fs = new FileStream(path, FileMode.Create);
                List<Plot> p = new List<Plot>();
                foreach (Plot plot in this.DataSeries.Values)
                {
                    p.Add(plot);
                }
                Graph settings = new Graph();
                settings.Series = p.ToArray();
                settings.XAxisTitle = this.chart1.ChartAreas[0].AxisX.Title;
                settings.YAxisTitle = this.chart1.ChartAreas[0].AxisY.Title;
                settings.YAxis2Title = this.chart1.ChartAreas[0].AxisY2.Title;
                if (this.chart1.Titles.Count > 0)
                {
                    settings.ChartTitle = this.chart1.Titles[0].Text;
                }
                else
                {
                    settings.ChartTitle = "";
                }

                serializer.Serialize(fs, settings);
                fs.Close();
            }
            #region{FileStreamコンストラクタの例外処理}
            catch (ArgumentException)
            {
                MessageBox.Show("パスが空白か，または無効な文字列を含んでいます．", "設定ファイル書き出しエラー");
                return;
            }
            catch (NotSupportedException)
            {
                MessageBox.Show("パスがファイル以外のデバイスを参照しています．", "設定ファイル書き出しエラー");
                return;
            }
            catch (System.Security.SecurityException)
            {
                MessageBox.Show("呼び出し元に必要なアクセス許可がありません．", "設定ファイル書き出しエラー");
                return;
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("ファイルが見つかりません．", "設定ファイル書き出しエラー");
                return;
            }
            catch (DirectoryNotFoundException)
            {
                MessageBox.Show("指定されたパスが無効です．ドライブが割り当てられているか確認してください．", "設定ファイル書き出しエラー");
                return;
            }
            catch (PathTooLongException)
            {
                MessageBox.Show("指定したパス，ファイル名，またはその両方がシステム定義の最大長を超えています．", "設定ファイル書き出しエラー");
                return;
            }
            catch (IOException)
            {
                MessageBox.Show("指定されたファイルが他のプロセスで開かれています．", "設定ファイル書き出しエラー");
                return;
            }
            #endregion
        }

        /// <summary>
        /// グラフ設定をxmlからデシリアライズします。
        /// </summary>
        /// <param name="path"></param>
        private void xmlDeserialize(string path)
        {
            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(Graph));
            FileStream fs;
            try
            {
                fs = new FileStream(path, FileMode.Open);
            }
            #region{FileStreamコンストラクタの例外処理}
            catch (ArgumentException)
            {
                MessageBox.Show("パスが空白か，または無効な文字列を含んでいます．", "設定ファイル読み込みエラー");
                return;
            }
            catch (NotSupportedException)
            {
                MessageBox.Show("パスがファイル以外のデバイスを参照しています．", "設定ファイル読み込みエラー");
                return;
            }
            catch (System.Security.SecurityException)
            {
                MessageBox.Show("呼び出し元に必要なアクセス許可がありません．", "設定ファイル読み込みエラー");
                return;
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("ファイルが見つかりません．", "設定ファイル読み込みエラー");
                return;
            }
            catch (DirectoryNotFoundException)
            {
                MessageBox.Show("指定されたパスが無効です．ドライブが割り当てられているか確認してください．", "設定ファイル読み込みエラー");
                return;
            }
            catch (PathTooLongException)
            {
                MessageBox.Show("指定したパス，ファイル名，またはその両方がシステム定義の最大長を超えています．", "設定ファイル読み込みエラー");
                return;
            }
            catch (IOException)
            {
                MessageBox.Show("指定されたファイルが他のプロセスで開かれています．", "設定ファイル読み込みエラー");
                return;
            }
            #endregion
            try
            {
                Graph settings = (Graph)serializer.Deserialize(fs);
                Plot[] p = settings.Series;

                clearAllGraphAndListView();

                int defaultComNumber = -1;
                bool allChange = false;

                for (int i = 0; i < p.Count(); i++)
                {
                    try
                    {
                        if (allChange)
                        {
                            if (defaultComNumber != -1)
                            {
                                p[i].comNumber = defaultComNumber;
                                p[i].COM = "COM" + defaultComNumber;
                            }
                        }
                        else if (getPortState(p[i].COM) == PortState.ClosedAndUnConnected ||
                            getPortState(p[i].COM) == PortState.ClosedAndConnected)
                        {
                            PortChangeDialog pcd = new PortChangeDialog(SerialPort.GetPortNames());
                            pcd.label_COM.Text = p[i].COM;
                            pcd.label_Series.Text = p[i].Series;
                            DialogResult r = pcd.ShowDialog();
                            if (r == System.Windows.Forms.DialogResult.Yes) //残り全てのポートに適用
                            {
                                allChange = true;
                                if (pcd.radioButton_Change.Checked)
                                {
                                    defaultComNumber = portNumber(pcd.comboBox_COM.Text);
                                    p[i].comNumber = defaultComNumber;
                                    p[i].COM = pcd.comboBox_COM.Text;
                                }
                            }
                            else if (r == System.Windows.Forms.DialogResult.No)
                            {
                                if (pcd.radioButton_Change.Checked)
                                {
                                    p[i].comNumber = portNumber(pcd.comboBox_COM.Text);


                                    p[i].COM = pcd.comboBox_COM.Text;
                                }
                            }
                        }
                    }
                    catch
                    {
                        MessageBox.Show("以下の系列はCOMポートの書式が不正のため無視されました\n\nポート名: " + p[i].COM + "\n系列名: " + p[i].Series, "ポート設定エラー");
                        continue;
                    }
                    addSeries(p[i]);
                }
                this.chart1.Titles.Add(settings.ChartTitle);
                this.chart1.ChartAreas[0].AxisY2.Title = settings.YAxis2Title;
                this.chart1.ChartAreas[0].AxisY.Title = settings.YAxisTitle;
                this.chart1.ChartAreas[0].AxisX.Title = settings.XAxisTitle;
            }
            catch (InvalidCastException)
            {
                MessageBox.Show("ファイルの形式が不正です．NanoTermで生成されたファイルを指定して下さい．", "設定ファイル読み込みエラー");
                return;
            }
            fs.Close();
        }

        #region{改行コードを直接Settings.settingsに放り込むと具合が悪いので文字列へ変換}
        public static string ParamToNewLine(string param)
        {
            switch (param)
            {
                case "CR":
                    return "\r";
                case "LF":
                    return "\n";
                case "CRLF":
                    return "\r\n";
            }
            return "\r";
        }

        public static string NewLineToParam(string param)
        {
            switch (param)
            {
                case "\r":
                    return "CR";
                case "\n":
                    return "LF";
                case "\r\n":
                    return "CRLF";
            }
            return "CR";
        }
        #endregion

        /// <summary>
        /// シリアル接続フォームのタイトルを変更し、ToolStripを更新します。
        /// </summary>
        /// <param name="type">Tx、Rxの選択</param>
        /// <param name="fileName">ログファイル名</param>
        /// <param name="baudRate">COMのボーレート</param>
        /// <param name="isError">接続失敗か</param>
        /// <param name="isConnected">接続済みか</param>
        /// <param name="control">ToolStripを紐づけるコントロール（通常TextBox）</param>
        /// <returns></returns>
        private string getFormTitle(string portName, FormType type, string fileName, int baudRate, bool isError, bool isConnected, Control control)
        {
            string title = portName;
            if (!isConnected)
            {
                title += "(未接続) ";
            }
            if (isError)
            {
                title += "(接続失敗) ";
            }
            if (type == FormType.Tx)
            {
                title += "送信ウィンドウ";
                if (this.SerialPorts[portNumber(portName)].TxBinaryMode)
                {
                    title += "(バイナリモード)";
                }
            }
            else if (type == FormType.Rx)
            {
                title += "受信ウィンドウ";
            }
            else if (type == FormType.Binary)
            {
                title += "バイナリウィンドウ";
            }
            title += "(" + baudRate.ToString() + "Bps) ";

            SerialPortWindow w = this.SerialPorts[portNumber(portName)];

            if ((w.TxLogEnable && type == FormType.Tx) || (w.RxLogEnable && type == FormType.Rx) || (w.BinaryLogEnable && type == FormType.Binary))
            {
                string path = fileName;
                if (P.SAVE_PATH.Length == 0)
                {
                    path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + fileName;
                }
                title += "ログ：" + path;
            }
            else
            {
                title += "ログはとっていません";
            }

            if (control != null)
            {
                this.toolTip1.SetToolTip(control, title);
            }

            return title;
        }

        /// <summary>
        /// this.PにDefault値を読み込みます
        /// </summary>
        private void SetParams()
        {
            #region{アプリケーション設定の読み込み}
            this.P = new Params();
            P.AUTO_CONNECT = NanoTerm.Properties.Settings.Default.AUTO_CONNECT;
            P.AUTO_RECONNECT = NanoTerm.Properties.Settings.Default.AUTO_RECONNECT;
            P.AUTO_SAVE = NanoTerm.Properties.Settings.Default.AUTO_SAVE;
            P.RETURN_CODE = ParamToNewLine(NanoTerm.Properties.Settings.Default.RETURN_CODE.Trim(' '));
            P.BAUD_RATE = NanoTerm.Properties.Settings.Default.BAUD_RATE;
            P.MAX_PORT_NUMBER = NanoTerm.Properties.Settings.Default.MAX_PORT_NUMBER;
            P.MAX_UPDATE_FREQ = NanoTerm.Properties.Settings.Default.MAX_UPDATE_FREQ;
            P.THREAD_RECONNECT_INTERVAL = NanoTerm.Properties.Settings.Default.THREAD_RECONNECT_INTERVAL;
            P.THREAD_SAVELOG_INTERVAL = NanoTerm.Properties.Settings.Default.THREAD_SAVELOG_INTERVAL;
            P.SEND_AT_ONCE = NanoTerm.Properties.Settings.Default.SEND_AT_ONCE;
            P.TX_TIMESTAMP = NanoTerm.Properties.Settings.Default.TX_TIMESTAMP;
            P.RX_TIMESTAMP = NanoTerm.Properties.Settings.Default.RX_TIMESTAMP;
            P.TIMESTAMP_FORMAT = NanoTerm.Properties.Settings.Default.TIMESTAMP_FORMAT;
            P.TIMESTAMP_SPAN = NanoTerm.Properties.Settings.Default.TIMESTAMP_SPAN;
            P.THREAD_DRAWGRAPH_INTERVAL = NanoTerm.Properties.Settings.Default.THREAD_DRAWGRAPH_INTERVAL;
            P.SAVE_PATH = NanoTerm.Properties.Settings.Default.SAVE_PATH;
            P.AUTO_SAVE_FORMOPENING = NanoTerm.Properties.Settings.Default.AUTO_CONNECT_FORMOPENING;
            P.SERIAL_DATABITS = NanoTerm.Properties.Settings.Default.SERIAL_DATABITS;
            P.SERIAL_DTR_ENABLE = NanoTerm.Properties.Settings.Default.SERIAL_DTR_ENABLE;
            P.SERIAL_HANDSHAKE = NanoTerm.Properties.Settings.Default.SERIAL_HANDSHAKE;
            P.SERIAL_PARITY = NanoTerm.Properties.Settings.Default.SERIAL_PARITY;
            P.SERIAL_STOPBITS = NanoTerm.Properties.Settings.Default.SERIAL_STOPBITS;
            P.SEND_FILE_PATH = NanoTerm.Properties.Settings.Default.SEND_FILE_PATH;
            P.REMOVE_EMPTY_LOG = NanoTerm.Properties.Settings.Default.REMOVE_EMPTY_LOG;
            P.TIMESTAMP_LINEHEAD = NanoTerm.Properties.Settings.Default.TIMESTAMP_LINEHEAD;
            P.TX_SHOW = NanoTerm.Properties.Settings.Default.TX_SHOW;
            P.RX_SHOW = NanoTerm.Properties.Settings.Default.RX_SHOW;
            P.BINARY_SHOW = NanoTerm.Properties.Settings.Default.BINARY_SHOW;
            #endregion
        }

        /// <summary>
        /// 文字列からタイムタグをキー，正規表現にマッチした部分文字列を値としたKeyValuePairを生成します．
        /// </summary>
        /// <param name="str"></param>
        /// <param name="RegularExpressions"></param>
        /// <param name="GroupIndex"></param>
        /// <returns></returns>
        private KeyValuePair<DateTime, double> parseKeyValue(string str, string RegularExpressions, int GroupIndex)
        {
            DateTime key = parseTimeTag(str);
            double value = 0.0;

            Regex r = new Regex(RegularExpressions);
            Match m = r.Match(str);
            while (m.Success)
            {
                if (m.Groups.Count > GroupIndex)
                {
                    string val = m.Groups[GroupIndex].Value;
                    int i;
                    double j;
                    if (double.TryParse(m.Groups[GroupIndex].Value, NumberStyles.Number, CultureInfo.InvariantCulture, out j))
                    {
                        value = double.Parse(m.Groups[GroupIndex].Value);
                        return new KeyValuePair<DateTime, double>(key, value);
                    }
                    else if (Int32.TryParse(m.Groups[GroupIndex].Value, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out i))
                    {
                        value = Int32.Parse(m.Groups[GroupIndex].Value, NumberStyles.HexNumber);
                        return new KeyValuePair<DateTime, double>(key, value);
                    }
                }
                m = m.NextMatch();
            }

            return new KeyValuePair<DateTime, double>(new DateTime(), value);
        }

        /// <summary>
        /// sをアクティブ状態とし，それ以外を非アクティブ状態として各種処理を実行します．
        /// </summary>
        /// <param name="s"></param>
        private void activateWindow(SerialPortWindow s)
        {
            for (int i = 0; i < this.P.MAX_PORT_NUMBER; i++)
            {
                this.SerialPorts[i].isFocused = false;
                if (this.SerialPorts[i].FormTx != null && this.SerialPorts[i].FormTx.Controls.Count != 0)
                {
                    ((TextBox)(this.SerialPorts[i].FormTx.Controls[0])).BackColor = Color.FromArgb(255, 249, 235);
                }
            }
            s.isFocused = true;
            if (s.FormTx != null && s.FormTx.Controls.Count != 0)
            {
                s.FormTx.Focus();
                ((TextBox)(s.FormTx.Controls[0])).BackColor = Color.White ;
            }
            updateStatusStrip(s);
        }


        #endregion

        /// <summary>
        /// COMポートの状態を記述します．
        /// </summary>
        public enum PortState
        {
            /// <summary>
            /// ポートは利用可能で，かつSystem.IO.Ports.SerialPortsインスタンスが生成されている状態．
            /// </summary>
            OpenAndConneced,
            /// <summary>
            /// ポートは利用可能で，System.IO.Ports.SerialPortsインスタンスが生成されていない状態．
            /// </summary>
            OpenAndUnConnected,
            /// <summary>
            /// ポートは利用不可能で，インスタンスも生成されていない状態．
            /// </summary>
            ClosedAndUnConnected,
            /// <summary>
            /// ポートは利用不可能だが，COMに対応したSystem.IO.Ports.SerialPortsインスタンスが生成されている状態．
            /// </summary>
            ClosedAndConnected,
        }

        /// <summary>
        /// タームウインドウの状態を記述します．
        /// </summary>
        public enum TermWindowState
        {
            /// <summary>
            /// ポート用のフォーム インスタンスの少なくとも片方が生成されていない状態．
            /// </summary>
            Null,
            /// <summary>
            /// ポート用のフォームは生成されているが，送受信ウインドウとも閉じられた状態．
            /// </summary>
            BothClosed,
            /// <summary>
            /// ポート用のフォームは生成されているが，受信ウインドウのみアクティブな状態．
            /// </summary>
            TxClosed,
            /// <summary>
            /// ポート用のフォームは生成されているが，送信ウインドウのみアクティブな状態．
            /// </summary>
            RxClosed,
            /// <summary>
            /// ポート用のフォーム インスタンスが生成され，送受信ウインドウがアクティブな状態．
            /// </summary>
            Opened,
        }



    }


    /// <summary>
    /// シリアルポートの受信データからグラフ系列への変換を指定するクラス．
    /// </summary>
    public class Plot
    {
        /// <summary>
        /// グラフの系列名．
        /// </summary>
        public string Series;
        /// <summary>
        /// 監視するポート番号．
        /// </summary>
        public int comNumber;
        /// <summary>
        /// 監視するポート名．
        /// </summary>
        public string COM;//監視対象COM
        /// <summary>
        /// データ抽出に使用するラベル．正規表現が使用可能です．無しの場合，タイムタグ直後の値を取ります
        /// </summary>
        public string Label;
        /// <summary>
        /// モニタ表示値xから物理値yに変換する一次式y=ax+bの係数．
        /// </summary>
        public double a; // Scale Factor
        /// <summary>
        /// モニタ表示値xから物理値yに変換する一次式y=ax+bの定数．
        /// </summary>
        public double b; // Offset
        /// <summary>
        /// データ系列のマーカー書式．
        /// </summary>
        public MarkerStyle MarkerStyle;
        /// <summary>
        /// データ系列に使用するy軸．
        /// </summary>
        public AxisType YAxisType;
        /// <summary>
        /// データ系列のマーカーサイズ．
        /// </summary>
        public int MarkerSize;
        /// <summary>
        /// データ系列に使用するグラフの種類．
        /// </summary>
        public SeriesChartType ChartType;
        /// <summary>
        /// 配列形式で与えられるデータのときTrue．
        /// </summary>
        public bool IsSeriesPlot;
        /// <summary>
        /// 配列形式で与えられるデータのとき，データのインデックスを返します．
        /// </summary>
        public int SeriesIndex;
        /// <summary>
        /// 配列形式で与えられるデータのときのスプリッタ．
        /// </summary>
        public string Splitter;
        /// <summary>
        /// 最初の描画時に指定された系列の色．
        /// </summary>
        public Color DefaultColor;
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public Plot()
        {
            this.IsSeriesPlot = false;
            this.SeriesIndex = -1;
            this.Splitter = " ?, ?";
            this.a = 1;
            this.b = 0;
            this.ChartType = SeriesChartType.FastLine;
            this.MarkerSize = 5;
            this.MarkerStyle = MarkerStyle.Square;
            this.YAxisType = AxisType.Primary;
        }
    }

    public struct Params
    {
        /// <summary>
        /// シリアルポートの更新間隔．別スレッドでバッファに入った受信データを，ここで指定した間隔でメインスレッドに読み込みます
        /// </summary>
        public TimeSpan MAX_UPDATE_FREQ;
        /// <summary>
        /// シリアルポートの初期ボーレート．
        /// </summary>
        public int BAUD_RATE;
        /// <summary>
        /// 最大ポート数．PC上でハンドルされるCOMの数がこれを超えないようにします．
        /// </summary>
        public int MAX_PORT_NUMBER;
        /// <summary>
        /// 送受信時の改行コード．
        /// </summary>
        public string RETURN_CODE;
        /// <summary>
        /// 接続状態の監視と再接続を行うスレッドの実行間隔(ms)．
        /// </summary>
        public int THREAD_RECONNECT_INTERVAL;
        /// <summary>
        /// ファイルの自動保存を実行するスレッドの実行間隔(ms)．
        /// </summary>
        public int THREAD_SAVELOG_INTERVAL;
        /// <summary>
        /// グラフの更新を行うスレッドの実行間隔(ms)．
        /// </summary>
        public int THREAD_DRAWGRAPH_INTERVAL;
        /// <summary>
        /// Trueのとき，一度切断したCOMに再接続するとウィンドウを再度有効化します．
        /// </summary>
        public bool AUTO_RECONNECT;
        /// <summary>
        /// Trueのとき，新規ポートを検出すると自動でウインドウを追加します．
        /// </summary>
        public bool AUTO_CONNECT;
        /// <summary>
        /// Trueのとき，自動保存が有効となります．
        /// </summary>
        public bool AUTO_SAVE;
        /// <summary>
        /// Trueのとき，Enterを待たずに逐次送信を実行します．
        /// </summary>
        public bool SEND_AT_ONCE;
        /// <summary>
        /// 送信ウインドウにタイムスタンプを追加します．
        /// </summary>
        public bool TX_TIMESTAMP;
        /// <summary>
        /// 受信ウインドウにタイムスタンプを追加します．
        /// </summary>
        public bool RX_TIMESTAMP;
        /// <summary>
        /// タイムスタンプを追加するのに必要な時間間隔を設定します．
        /// </summary>
        public TimeSpan TIMESTAMP_SPAN;
        /// <summary>
        /// タイムスタンプのフォーマットをDateTime型の書式で指定します．
        /// </summary>
        public string TIMESTAMP_FORMAT;
        /// <summary>
        /// 受信タイムスタンプを行の頭に限定して挿入．
        /// </summary>
        public bool TIMESTAMP_LINEHEAD;
        /// <summary>
        /// 自動保存の保存先．
        /// </summary>
        public string SAVE_PATH;
        /// <summary>
        /// Trueのとき、NTerm起動時に全ポートへ接続します。
        /// </summary>
        public bool AUTO_SAVE_FORMOPENING;
        /// <summary>
        /// 自動接続時のストップビット。
        /// </summary>
        public StopBits SERIAL_STOPBITS;
        /// <summary>
        /// 自動接続時のDTRオンオフ指定。
        /// </summary>
        public bool SERIAL_DTR_ENABLE;
        /// <summary>
        /// 自動接続時のデータ長指定。
        /// </summary>
        public int SERIAL_DATABITS;
        /// <summary>
        /// 自動接続時のパリティ。
        /// </summary>
        public Parity SERIAL_PARITY;
        /// <summary>
        /// 自動接続時のフロー制御。
        /// </summary>
        public Handshake SERIAL_HANDSHAKE;
        /// <summary>
        /// 最後に送信したファイルのパス．
        /// </summary>
        public string SEND_FILE_PATH;
        /// <summary>
        /// アプリケーション終了時に、生成された0バイトのログファイルをすべて消去。
        /// </summary>
        public bool REMOVE_EMPTY_LOG;

        public bool TX_SHOW;

        public bool RX_SHOW;

        public bool BINARY_SHOW;
    }

    public class Graph
    {
        public string ChartTitle;
        public string XAxisTitle;
        public string YAxisTitle;
        public string YAxis2Title;
        public Plot[] Series;
    }

    public enum FormType
    {
        Tx,
        Rx,
        Binary,
    }
}