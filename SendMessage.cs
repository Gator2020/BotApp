using Microsoft.Web.WebView2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using SendKeys.BLL.ActiveWindow;
using SendKeys.Common;
using SendKeys.BLL;
using System.Windows.Forms;
using System.Diagnostics.Contracts;
using Microsoft.VisualBasic;

namespace BotApp
{
    public partial class SendMessage : Form
    {
        public SendMessage()
        {
            InitializeComponent();
        }
        private ActiveWindowWatcher activeWindowWatcher;
        private ActiveWindowModel activeWindow = ActiveWindowModel.CreateEmpty();
        public IntPtr ActiveWindow;
        [DllImport("user32.dll")]
         public static extern bool SetForeGroundWindow(IntPtr hWnd);


        [DllImport("user32.dll")]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        [DllImport("user32.dll")]
        public static extern bool IsIconic(IntPtr hWnd);

        [DllImport("user32.dll", SetLastError = true)]
        #region declerations
        static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);

        public const int KEYEVENTF_KEYDOWN = 0x0000; // New definition
        public const int KEYEVENTF_EXTENDEDKEY = 0x0001; //Key down flag
        public const int KEYEVENTF_KEYUP = 0x0002; //Key up flag
        public const int VK_LCONTROL = 0xA2; //Left Control key code
        public const int A = 0x41; //A key code
        public const int B = 0x42;
        public const int C = 0x43; //C key code 
        public const int D = 0x44;
        public const int E = 0x45;
        public const int F = 0x46;
        public const int G = 0x47;
        public const int H = 0x48;
        public const int I = 0x49;
        public const int J = 0x4A;
        public const int K = 0x4B;
        public const int L = 0x4C;
        public const int M = 0x4D;
        public const int N = 0x4E;
        public const int O = 0x4F;
        public const int P = 0x50;
        public const int Q = 0x51;
        public const int R = 0x52;
        public const int S = 0x53;
        public const int T = 0x54;
        public const int U = 0x55;
        public const int V = 0x56;
        public const int W = 0x57;
        public const int X = 0x58;
        public const int Y = 0x59;
        public const int Enter = 0x0D;
        public const int VK_LEFT = 0x01;
        public const int Z = 0x5A;
        public static int XCordinate;
        public static int YCordinate;
        public static IntPtr CursorHandle;
        public static IntPtr WebHandle;
        public static IntPtr MainWindow;
        public static string Email;
        public string httpMessage;
        public static string Password;
        #endregion
        // public static string Loginscript = "Login();\r\ndocument.querySelector('form__input login-form__input ng-pristine ng-empty ng-valid-email ng-invalid ng-invalid-required ng-touched').value=" + Email + ";\r\ndocument.querySelector('form__input login-form__input ng-pristine ng-empty ng-invalid ng-invalid-required ng-touched').value=" + Password + "\"\";\r\ndocument.getElementsByClassName('form__input login-form__input ng-pristine ng-empty ng-valid-email ng-invalid ng-invalid-required ng-touched').value=" + Email + "\"\";\r\ndocument.getElementsByClassName('form__input login-form__input ng-pristine ng-empty ng-invalid ng-invalid-required ng-touched').value=" + Password + "\"\";\r\ndocument.querySelector('login-form__button habbo-login-button').click();\r\nvar ClickBtn = document.getElementsByClassName('login-form__button habbo-login-button');\r\nvar Rate = ClickBtn[0];\r\nRate.click;\r\nRate.click();\r\nfunction Login()\r\n{\r\n\r\n    document.querySelector('form__input login-form__input ng-pristine ng-empty ng-valid-email ng-invalid ng-invalid-required ng-touched').value = '100';\r\ndocument.querySelector('form__input login-form__input ng-pristine ng-empty ng-invalid ng-invalid-required ng-touched').value=\"\";\r\ndocument.getElementsByClassName('form__input login-form__input ng-pristine ng-empty ng-valid-email ng-invalid ng-invalid-required ng-touched').value=\"\";\r\ndocument.getElementsByClassName('form__input login-form__input ng-pristine ng-empty ng-invalid ng-invalid-required ng-touched').value=\"\";\r\ndocument.querySelector('login-form__button habbo-login-button').click();\r\nvar ClickBtn = document.getElementsByClassName('login-form__button habbo-login-button');\r\nvar Rate = ClickBtn[0];\r\nRate.click;\r\nRate.click();\r\n\r\n}";
        #region sendMessagePacket
        //  public static
        // string script = "var net = require(\"net\");\r\nvar client =new net.Socket();\r\nclient.connect(3000,\"127.0.0.1\",function()\r\n{\r\n\r\n    console.log(\"connected\");\r\n    client.write(" + SendMessageWeb() + ")" +
        //    ";\r\n\r\n})\r\nclient.on('data',function(data) {\r\n    console.log(data);\r\n\r\n})\r\nclient.on('close',function(){\r\n    console.log(\"Connection closed\");\r\n}) ";
        #endregion
        private void ActiveWindowWatcher_ActiveWindowChanged(object sender, ActiveWindowChangedEventArgs e)
        {
            activeWindow = ActiveWindowModel.Create(e.WindowHandle, e.WindowTitle);

            //  activeWindow.WindowHandle == IntPtr.Zero;
        }

        public IntPtr BeginInvokeHandle(string Message)
        {

            string MsgRecieved = Message;
            while (BeginInvokeHandle(MsgRecieved) != IntPtr.Zero)
            {
                MessageBox.Show(BeginInvokeHandle("").ToString());


            }
            Process process = Process.GetCurrentProcess();
            return process.MainWindowHandle;
        }


        public void Coordinates()
        {
            while (true)
            {
                int X = MousePosition.X;
                int Y = MousePosition.Y;
                XCordinate = X;
                YCordinate = Y;
                label1.Text = X.ToString();
                label2.Text = Y.ToString();
            }
        }
        public string SendMessageWeb()
        {



            // Simulate a key release
            keybd_event(A,
                         0x45,
                         KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP,
                         0);
            keybd_event(A, 0, KEYEVENTF_KEYDOWN, 0);
            // Simulate a key release
            keybd_event(A,
                         0x45,
                         KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP,
                         0);
            keybd_event(0x01, 0, KEYEVENTF_KEYUP, 0);
            keybd_event(0x01, 0, KEYEVENTF_KEYDOWN, 0);
            keybd_event(0x0D, 0, KEYEVENTF_KEYUP, 0);
            keybd_event(0x0D, 0, KEYEVENTF_KEYDOWN, 0);
            keybd_event(0x0D, 0, KEYEVENTF_KEYDOWN, 0);


            keybd_event(0x09, 0, KEYEVENTF_KEYUP, 0);
            keybd_event(0x09, 0, KEYEVENTF_KEYDOWN, 0);
            keybd_event(0x09, 0, KEYEVENTF_KEYUP, 0);
            keybd_event(0x09, 0, KEYEVENTF_KEYDOWN, 0);
            keybd_event(0x09, 0, KEYEVENTF_KEYDOWN, 0);
            string msg = null;

            return msg;

        }
        #region presskeys
        public static void PressKeys()
        {
            while (true)
            {
                // Hold Control down and press A
                keybd_event(VK_LCONTROL, 0, KEYEVENTF_KEYDOWN, 0);
                Process GetMaiproc = Process.GetCurrentProcess();
                PressKeys();
                IntPtr mainhandle = GetMaiproc.MainWindowHandle;
                while (mainhandle != IntPtr.Zero)
                {
                    MessageBox.Show(mainhandle.ToString());
                    keybd_event(A, 0, KEYEVENTF_KEYDOWN, 0);
                    keybd_event(0x0D, 0, KEYEVENTF_KEYUP, 0);
                    keybd_event(0x0D, 0, KEYEVENTF_KEYUP, 0);
                    keybd_event(0x0D, 0, KEYEVENTF_KEYUP, 0);
                    keybd_event(0x0D, 0, KEYEVENTF_KEYUP, 0);
                    keybd_event(0x0D, 0, KEYEVENTF_KEYUP, 0);


                }

                // GetMaiproc.Start();
                keybd_event(A, 0, KEYEVENTF_KEYDOWN, 0);
                keybd_event(0x0D, 0, KEYEVENTF_KEYUP, 0);
                keybd_event(0x0D, 0, KEYEVENTF_KEYUP, 0);
                keybd_event(0x0D, 0, KEYEVENTF_KEYUP, 0);
                keybd_event(0x0D, 0, KEYEVENTF_KEYUP, 0);
                keybd_event(0x0D, 0, KEYEVENTF_KEYUP, 0);






                keybd_event(VK_LCONTROL, 0, KEYEVENTF_KEYUP, 0);

                // Hold Control down and press C
                keybd_event(VK_LCONTROL, 0, KEYEVENTF_KEYDOWN, 0);
                keybd_event(C, 0, KEYEVENTF_KEYDOWN, 0);
                keybd_event(C, 0, KEYEVENTF_KEYUP, 0);
                keybd_event(VK_LCONTROL, 0, KEYEVENTF_KEYUP, 0);
            }
        }
        #endregion
        public void SetCursor(int x, int y)
        {

            webView21.PointToScreen(new Point(x, y));
            keybd_event(0x01, 0, KEYEVENTF_KEYUP, 0);
            keybd_event(0x02, 0, KEYEVENTF_KEYUP, 0);
            keybd_event(0x0D, 0, KEYEVENTF_KEYUP, 0);
            PressKeys();

            Thread GetCursor = new Thread(Coordinates);
            //  GetCursor.Start

        }
        public async void SendMesssage_()
        {
            while (true)
            {
                Process Getmainproc = Process.GetCurrentProcess();
                if (Getmainproc != null)
                {
                    MessageBox.Show(Getmainproc.MainWindowHandle.ToString());
                    keybd_event(0x0D, 0, KEYEVENTF_KEYUP, 0);
                    keybd_event(0x0D, 0, KEYEVENTF_KEYUP, 0);
                    timer1.Start();
                }
                keybd_event(A, 0, KEYEVENTF_KEYDOWN, 0);
                keybd_event(0x0D, 0, KEYEVENTF_KEYUP, 0);
                keybd_event(0x0D, 0, KEYEVENTF_KEYUP, 0);

            }

        }
        public void Hmessage()
        {
            Process getMainproc = Process.GetCurrentProcess();
            HMessage MessageClass = new HMessage();
            while (true)
            {
                string Url = "https://pastebin.com/raw/8XnZX3wH";

                Uri Webpage = new Uri(Url);
                MessageClass.GetReq(Webpage.ToString());
                richTextBox1.Text = MessageClass.ConsoleMessage.ToString();
                richTextBox1.AppendText(MessageClass.ConsoleMessage.ToString());
            }
        }
        #region Mainload

        private void SendMessage_Load(object sender, EventArgs e)
        {
            activeWindowWatcher = new ActiveWindowWatcher(TimeSpan.FromSeconds(1));
            activeWindowWatcher.ActiveWindowChanged += ActiveWindowWatcher_ActiveWindowChanged;
            activeWindowWatcher.Start();
            string _Url = "https://www.habbo.com";
            Uri Load = new Uri(_Url);
          //ActiveWindow = webView21.Handle;
            Process P = Process.GetCurrentProcess();
           //ctiveWindow = P.Handle;
            ActiveWindow = P.MainWindowHandle;
          //ActiveWindow = Process.GetCurrentProcess().Handle; ActiveWindow = Process.GetCurrentProcess().MainWindowHandle;

            WindowAPI.SendKeys(ActiveWindow, "{ENTER}");
           
            webView21.Source = Load;

            //webView21.ExecuteScriptAsync(Loginscript);
            //  MouseEventHandler mouseEventHandler = (MouseEventHandler)sender; 
            Process getMainproc = Process.GetCurrentProcess();
            int BrowserPid = int.Parse(webView21.Handle.ToString());
            IntPtr browserHwnd = IntPtr.Zero;
            HMessage MessageClass = new HMessage();
            string Url = "https://pastebin.com/raw/8XnZX3wH";

            Uri Webpage = new Uri(Url);
            MessageClass.GetReq(Webpage.ToString());
            richTextBox1.Text = MessageClass.ConsoleMessage.ToString();
            //richTextBox1.AppendText(MessageClass.ConsoleMessage.ToString());

            #endregion
            Process GetMaiproc = Process.GetCurrentProcess();
            // ServerSocket();
            MainWindow = GetMaiproc.MainWindowHandle;
            MessageBox.Show(GetMaiproc.ToString());
            CursorHandle = webView21.Cursor.Handle;
            //PressKeys();
            IntPtr Handle = webView21.Handle;
            IntPtr cursorHandle_ = webView21.Cursor.Handle;
            CursorHandle = cursorHandle_;
            WebHandle = Handle;


            Thread GetCursor = new Thread(Coordinates);
            //Thread sendkeys = new Thread(PressKeys);
            // sendkeys.Start();
            GetCursor.Start();


        }

        private void webView21_Click(object sender, EventArgs e)
        {

        }
        public async void EnterSend()
        {
            try
            {
                string Url = "https://pastebin.com/raw/8XnZX3wH";
                Uri Load = new Uri(Url);

                WebRequest GetMessage = WebRequest.Create(Load.ToString());
                GetMessage.Method = "GET";
                GetMessage.Headers.Add("cookie", "cookie");
                Stream GetReqStream = GetMessage.GetResponse().GetResponseStream();
                StreamReader Reader = new StreamReader(GetReqStream);
                string SendMessage = Reader.ReadToEnd();
                while (SendMessage != null)
                {
                    foreach (char c in SendMessage.ToCharArray())
                    {
                        for (int i = 0; i < SendMessage.Length; i++)
                        {
                            richTextBox1.Text = c.ToString();
                            richTextBox1.Text += c.ToString();
                            KeyPressEventArgs keyPressEventArgs = new KeyPressEventArgs(c);
                            KeyEventArgs keyEventArgs = new KeyEventArgs(Keys.Return);
                            richTextBox1_KeyUp(Load, keyEventArgs);
                            richTextBox1_KeyPress(Load, keyPressEventArgs);
                            richTextBox1.Text = c.ToString();
                            richTextBox1.Text += c.ToString();
                        }

                    }
                }

            }
            catch (Exception ex)

            {

            }
        }
        public void SendToBrowser()
        {
            HMessage MessageClass = new HMessage();
            MessageClass.ActiveWindow = webView21.Handle;
            MessageClass.ActiveWindow = webView21.Cursor.Handle;

            IntPtr browserHandle = webView21.Handle;

            MessageClass.SendInputWithAPI();
            //IntPtr browser = webView21.Handle;
            MessageClass.SendMessage().Equals(webView21.Handle)

 ;
            MessageClass.SendMessage();
            MessageClass.PostMessage();
            browserHandle = MessageClass.SendMessage();

        }
        private async void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                Thread SendKeyMessage = new Thread(SendMesssage_);
                SendKeyMessage.Start();
                timer1.Start();
            }

        }
        public void SendKeys()
        {
            {
                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            keybd_event(0x0D, 0, KEYEVENTF_KEYUP, 0);
            keybd_event(0x0D, 0, KEYEVENTF_KEYDOWN, 0);
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            //// HMessage MessageClass = new HMessage();
            // richTextBox1_TextChanged(sender, e);
            const int MsgEnter = (int)Keys.Return;
            httpMessage = richTextBox1.Text.ToString();
            const int VK_A = (int)Keys.ShiftKey;
            const int VK_B = (int)Keys.Tab;
            const int VK_M = (int)Keys.M;
            KeyEventArgs SendMsg = new KeyEventArgs(Keys.Return);
            //(SendMessageWeb(), SendMsg);

            const int A = 0x02;
            const int VK_LEFT = 0x01;
            #region sendMessageToHabbo
            foreach (char c in richTextBox1.Text.ToString())
            {


                keybd_event(VK_LEFT, 0, KEYEVENTF_KEYDOWN, 0);
                if (c == 'A' || c == 'a')
                {
                    timer1.Start();
                    keybd_event(A, 0, KEYEVENTF_KEYUP, 0);
                    keybd_event(A, 0, KEYEVENTF_KEYDOWN, 0);
                    int[] msgPacket = { };
                    string MsgParam = Interaction.InputBox(SendMessageWeb());
                    //   string parmMessage = Interaction.InputBox(SendMessageWeb().ToString());
                    Process currentProc = Process.GetCurrentProcess();
                    IntPtr handle = currentProc.MainWindowHandle;

                    MessageBox.Show(MsgParam);
                    Message.Create(Handle, VK_A, Handle, Handle);
                    richTextBox1.Text += MsgParam.ToString();
                    SendMessageWeb();

                    // Message.Create(ActiveWindow, A, A, p.MainWindowHandle);
                }
                if (c == 'B' || c == 'b')
                {
                    string MsgParam = Interaction.InputBox(SendMessageWeb());
                    //   string parmMessage = Interaction.InputBox(SendMessageWeb().ToString());
                    Process currentProc = Process.GetCurrentProcess();
                    IntPtr handle = currentProc.MainWindowHandle;

                    MessageBox.Show(MsgParam);
                    Message.Create(Handle, VK_A, Handle, Handle);
                    richTextBox1.Text += MsgParam.ToString();
                    SendMessageWeb();

                    keybd_event(B, 0, KEYEVENTF_KEYDOWN, 0);
                    MessageBox.Show(MsgParam);
                    Message.Create(Handle, VK_A, Handle, Handle);
                    richTextBox1.Text += MsgParam.ToString();
                    SendMessageWeb();
                    // Message.Create(ActiveWindow, B, B, p.MainWindowHandle);
                }
                if (c == 'C' || c == 'c')
                {
                    string MsgParam = Interaction.InputBox(SendMessageWeb());
                    //   string parmMessage = Interaction.InputBox(SendMessageWeb().ToString());
                    Process currentProc = Process.GetCurrentProcess();
                    IntPtr handle = currentProc.MainWindowHandle;

                    MessageBox.Show(MsgParam);
                    Message.Create(Handle, VK_A, Handle, Handle);
                    richTextBox1.Text += MsgParam.ToString();
                    SendMessageWeb();
                    timer1.Stop();
                    keybd_event(C, 0, KEYEVENTF_KEYDOWN, 0);
                    // Message.Create(ActiveWindow, C, C, p.MainWindowHandle);
                }
                if (C == 'D' || C == 'd')
                {
                    timer1.Start();
                    keybd_event(A, 0, KEYEVENTF_KEYUP, 0);
                    keybd_event(A, 0, KEYEVENTF_KEYDOWN, 0);
                    int[] msgPacket = { };
                    string MsgParam = Interaction.InputBox(SendMessageWeb());
                    //   string parmMessage = Interaction.InputBox(SendMessageWeb().ToString());
                    Process currentProc = Process.GetCurrentProcess();
                    IntPtr handle = currentProc.MainWindowHandle;

                    MessageBox.Show(MsgParam);
                    Message.Create(Handle, VK_A, Handle, Handle);
                    richTextBox1.Text += MsgParam.ToString();
                    SendMessageWeb();
                    keybd_event(D, 0, KEYEVENTF_KEYDOWN, 0);
                    //Message.Create(ActiveWindow, D, D, p.MainWindowHandle);
                }
                if (C == 'E' || C == 'e')
                {
                    keybd_event(E, 0, KEYEVENTF_KEYDOWN, 0);
                    timer1.Start();
                    keybd_event(A, 0, KEYEVENTF_KEYUP, 0);
                    keybd_event(A, 0, KEYEVENTF_KEYDOWN, 0);
                    int[] msgPacket = { };
                    string MsgParam = Interaction.InputBox(SendMessageWeb());
                    //   string parmMessage = Interaction.InputBox(SendMessageWeb().ToString());
                    Process currentProc = Process.GetCurrentProcess();
                    IntPtr handle = currentProc.MainWindowHandle;

                    MessageBox.Show(MsgParam);
                    Message.Create(Handle, VK_A, Handle, Handle);
                    richTextBox1.Text += MsgParam.ToString();
                    SendMessageWeb();
                    //Message.Create(ActiveWindow, E, E, p.MainWindowHandle);
                }
                if (C == 'F' || C == 'f')
                {
                    keybd_event(F, 0, KEYEVENTF_KEYDOWN, 0);
                    timer1.Start();
                    keybd_event(A, 0, KEYEVENTF_KEYUP, 0);
                    keybd_event(A, 0, KEYEVENTF_KEYDOWN, 0);
                    int[] msgPacket = { };
                    string MsgParam = Interaction.InputBox(SendMessageWeb());
                    //   string parmMessage = Interaction.InputBox(SendMessageWeb().ToString());
                    Process currentProc = Process.GetCurrentProcess();
                    IntPtr handle = currentProc.MainWindowHandle;

                    MessageBox.Show(MsgParam);
                    Message.Create(Handle, VK_A, Handle, Handle);
                    richTextBox1.Text += MsgParam.ToString();
                    SendMessageWeb();
                    // Message.Create(ActiveWindow, F, F, p.MainWindowHandle);
                }
                if (C == 'G' || C == 'g')
                {
                    timer1.Start();
                    keybd_event(A, 0, KEYEVENTF_KEYUP, 0);
                    keybd_event(A, 0, KEYEVENTF_KEYDOWN, 0);
                    int[] msgPacket = { };
                    string MsgParam = Interaction.InputBox(SendMessageWeb());
                    //   string parmMessage = Interaction.InputBox(SendMessageWeb().ToString());
                    Process currentProc = Process.GetCurrentProcess();
                    IntPtr handle = currentProc.MainWindowHandle;

                    MessageBox.Show(MsgParam);
                    Message.Create(Handle, VK_A, Handle, Handle);
                    richTextBox1.Text += MsgParam.ToString();
                    SendMessageWeb();
                    keybd_event(G, 0, KEYEVENTF_KEYDOWN, 0);
                    // Message.Create(ActiveWindow, G, G, p.MainWindowHandle);
                }
                if (C == 'H' || C == 'h')

                {
                    timer1.Start();
                    keybd_event(A, 0, KEYEVENTF_KEYUP, 0);
                    keybd_event(A, 0, KEYEVENTF_KEYDOWN, 0);
                    int[] msgPacket = { };
                    string MsgParam = Interaction.InputBox(SendMessageWeb());
                    //   string parmMessage = Interaction.InputBox(SendMessageWeb().ToString());
                    Process currentProc = Process.GetCurrentProcess();
                    IntPtr handle = currentProc.MainWindowHandle;

                    MessageBox.Show(MsgParam);
                    Message.Create(Handle, VK_A, Handle, Handle);
                    richTextBox1.Text += MsgParam.ToString();
                    SendMessageWeb();
                    keybd_event(H, 0, KEYEVENTF_KEYDOWN, 0);
                    // Message.Create(ActiveWindow, H, H, p.MainWindowHandle);
                }
                if (C == 'I' || C == 'i')
                {
                    timer1.Start();
                    keybd_event(A, 0, KEYEVENTF_KEYUP, 0);
                    keybd_event(A, 0, KEYEVENTF_KEYDOWN, 0);
                    int[] msgPacket = { };
                    string MsgParam = Interaction.InputBox(SendMessageWeb());
                    //   string parmMessage = Interaction.InputBox(SendMessageWeb().ToString());
                    Process currentProc = Process.GetCurrentProcess();
                    IntPtr handle = currentProc.MainWindowHandle;

                    MessageBox.Show(MsgParam);
                    Message.Create(Handle, VK_A, Handle, Handle);
                    richTextBox1.Text += MsgParam.ToString();
                    SendMessageWeb();
                    keybd_event(D, 0, KEYEVENTF_KEYDOWN, 0);
                    // Message.Create(ActiveWindow, D, D, p.MainWindowHandle);
                }
                if (C == 'J' || C == 'j')
                {
                    timer1.Start();
                    keybd_event(A, 0, KEYEVENTF_KEYUP, 0);
                    keybd_event(A, 0, KEYEVENTF_KEYDOWN, 0);
                    int[] msgPacket = { };
                    string MsgParam = Interaction.InputBox(SendMessageWeb());
                    //   string parmMessage = Interaction.InputBox(SendMessageWeb().ToString());
                    Process currentProc = Process.GetCurrentProcess();
                    IntPtr handle = currentProc.MainWindowHandle;

                    MessageBox.Show(MsgParam);
                    Message.Create(Handle, VK_A, Handle, Handle);
                    richTextBox1.Text += MsgParam.ToString();
                    SendMessageWeb();
                    keybd_event(J, 0, KEYEVENTF_KEYDOWN, 0);
                    // Message.Create(ActiveWindow, J, SendMessage(), p.MainWindowHandle);
                }
                if (C == 'K' || C == 'k')
                {
                    timer1.Start();
                    keybd_event(A, 0, KEYEVENTF_KEYUP, 0);
                    keybd_event(A, 0, KEYEVENTF_KEYDOWN, 0);
                    int[] msgPacket = { };
                    string MsgParam = Interaction.InputBox(SendMessageWeb());
                    //   string parmMessage = Interaction.InputBox(SendMessageWeb().ToString());
                    Process currentProc = Process.GetCurrentProcess();
                    IntPtr handle = currentProc.MainWindowHandle;

                    MessageBox.Show(MsgParam);
                    Message.Create(Handle, VK_A, Handle, Handle);
                    richTextBox1.Text += MsgParam.ToString();
                    SendMessageWeb();
                    keybd_event(K, 0, KEYEVENTF_KEYDOWN, 0);
                    //    Message.Create(ActiveWindow, K, K, p.MainWindowHandle);
                }
                if (C == 'L' || C == 'l')
                {
                    keybd_event(L, 0, KEYEVENTF_KEYDOWN, 0);
                    // Message.Create(ActiveWindow, L, L, p.MainWindowHandle);
                }
                if (C == 'M' || C == 'm')
                {
                    keybd_event(D, 0, KEYEVENTF_KEYDOWN, 0);
                    // Message.Create(ActiveWindow, D, D, p.MainWindowHandle);
                }
                if (C == 'N' || C == 'n')
                {
                    keybd_event(N, 0, KEYEVENTF_KEYDOWN, 0);
                    //  Message.Create(ActiveWindow, N, N, p.MainWindowHandle);
                }
                if (C == 'O' || C == 'o')
                {
                    keybd_event(O, 0, KEYEVENTF_KEYDOWN, 0);
                    //  Message.Create(ActiveWindow, O, O, p.MainWindowHandle);
                }
                if (C == 'P' || C == 'p')
                {
                    keybd_event(P, 0, KEYEVENTF_KEYDOWN, 0);
                    // Message.Create(ActiveWindow, P, P, p.MainWindowHandle);
                }
                if (C == 'Q' || C == 'q')
                {
                    keybd_event(Q, 0, KEYEVENTF_KEYDOWN, 0);
                    // Message.Create(ActiveWindow, Q, Q, p.MainWindowHandle);
                }
                if (C == 'R' || C == 'r')
                {
                    keybd_event(R, 0, KEYEVENTF_KEYDOWN, 0);
                    // Message.Create(ActiveWindow, R, R, p.MainWindowHandle);
                }
                if (C == 'S' || C == 's')
                {
                    keybd_event(D, 0, KEYEVENTF_KEYDOWN, 0);
                    //Message.Create(ActiveWindow, S, S, p.MainWindowHandle);
                }
                if (C == 'T' || C == 't')
                {
                    keybd_event(T, 0, KEYEVENTF_KEYDOWN, 0);
                    // Message.Create(ActiveWindow, T, T, p.MainWindowHandle);
                }
                if (C == 'U' || C == 'u')
                {
                    keybd_event(U, 0, KEYEVENTF_KEYDOWN, 0);
                    // Message.Create(ActiveWindow, U, U, p.MainWindowHandle);
                }
                if (C == 'V' || C == 'v')
                {
                    keybd_event(V, 0, KEYEVENTF_KEYDOWN, 0);
                    //  Message.Create(ActiveWindow, V, V, p.MainWindowHandle);
                }
                if (C == 'W' || C == 'w')
                {
                    keybd_event(W, 0, KEYEVENTF_KEYDOWN, 0);
                    // Message.Create(ActiveWindow, W, W, p.MainWindowHandle);
                }
                if (C == 'X' || C == 'x')
                {
                    keybd_event(X, 0, KEYEVENTF_KEYDOWN, 0);
                    // Message.Create(ActiveWindow, X, X, p.MainWindowHandle);
                }
                if (C == 'Y' || C == 'y')
                {
                    keybd_event(Y, 0, KEYEVENTF_KEYDOWN, 0);
                    // Message.Create(ActiveWindow, Y, Y, p.MainWindowHandle);
                }
                if (C == 'Z' || C == 'z')
                {
                    keybd_event(Z, 0, KEYEVENTF_KEYDOWN, 0);
                    // Message.Create(ActiveWindow, Z, Z, p.MainWindowHandle); keybd_event(VK_LEFT, 0, KEYEVENTF_KEYDOWN, 0);
                }

                try
                {
                    Process getMainproc = Process.GetCurrentProcess();
                    IntPtr Handle = getMainproc.MainWindowHandle;
                    Message.Create(Handle, A, 0X0D, getMainproc.MainWindowHandle);


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Errror in creating message" + ex.Message.ToString());
                }
                IntPtr browserHandle = webView21.Handle;


                // MessageClass.PostMessage();
                //  browserHandle = MessageClass.SendMessage();

            }
            #endregion
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

            richTextBox1_TextChanged(sender, e);
            const int MsgEnter = (int)Keys.Return;
            const int VK_A = (int)Keys.ShiftKey;
            const int VK_B = (int)Keys.Tab;
            const int VK_M = (int)Keys.M;
            KeyEventArgs SendMsg = new KeyEventArgs(Keys.Return);
            richTextBox1_KeyUp(SendMessageWeb(), SendMsg);
            while (true)
            {
                try
                {
                    WindowAPI.SetActiveWindow(Process.GetCurrentProcess().Handle)
                    ;
                    WindowAPI.SendKeys(Process.GetCurrentProcess().Handle, "{ENTER}");
                    IntPtr handle = Process.GetCurrentProcess().MainWindowHandle;
                    if (handle == IntPtr.Zero)
                    {
                        WindowAPI.SetActiveWindow(handle);
                        WindowAPI.SendKeys(handle, e.KeyChar.ToString());
                        richTextBox1_TextChanged(sender, e);
                        keybd_event(0x0D, 0, KEYEVENTF_KEYUP, 0);
                        keybd_event(A, 0, KEYEVENTF_KEYUP, 0);
                        keybd_event(VK_A, 0, KEYEVENTF_KEYUP, 0);
                        keybd_event(VK_M, 0, KEYEVENTF_KEYUP, 0);
                        keybd_event(0x0D, 0, KEYEVENTF_KEYUP, 0);
                    }
                }
                catch (Exception s)
                {
                    MessageBox.Show(s.ToString());
                }
            }

        }

        private void richTextBox1_KeyUp(object sender, KeyEventArgs e)
        {
            richTextBox1_TextChanged(sender, e);
            while (true)
            {
                WindowAPI.SetActiveWindow(Process.GetCurrentProcess().Handle)
                    ;
                WindowAPI.SendKeys(Process.GetCurrentProcess().Handle, "{ENTER}");
                IntPtr handle = Process.GetCurrentProcess().MainWindowHandle;
                if (handle == IntPtr.Zero)
                {
                    WindowAPI.SetActiveWindow(handle);
                    WindowAPI.SendKeys(handle, "testing");
                }
                richTextBox1_TextChanged(sender, e);
                keybd_event(0x0D, 0, KEYEVENTF_KEYUP, 0);
                keybd_event(A, 0, KEYEVENTF_KEYUP, 0);
                keybd_event(B, 0, KEYEVENTF_KEYUP, 0);
                keybd_event(0x0D, 0, KEYEVENTF_KEYUP, 0);
            }
        }
        public void InvokeAction()
        {
            this.WindowState = FormWindowState.Maximized;
            this.WindowState = FormWindowState.Minimized;
        }
        public void SetWindows()
        {
            while (true)
            {
                SendMessage s = new SendMessage();
                s.BeginInvoke(new Action(() => { InvokeAction(); }));
                if (IsIconic(ActiveWindow))
                {
                    ShowWindow(ActiveWindow, 3);
                }
                else
                {
                    SetForeGroundWindow(ActiveWindow);
                }
            }
        }
        private void richTextBox1_ReadOnlyChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            WindowAPI.SetActiveWindow(Process.GetCurrentProcess().Handle)
                    ;
            WindowAPI.SendKeys(Process.GetCurrentProcess().Handle, "{ENTER}");
            IntPtr handle = Process.GetCurrentProcess().MainWindowHandle;
            if (handle == IntPtr.Zero)
            {
                WindowAPI.SetActiveWindow(handle);
                WindowAPI.SendKeys(handle, e.KeyCode.ToString());
            }
        }
    }
}
