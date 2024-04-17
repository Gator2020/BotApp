using System.Diagnostics;
using System.Net.Sockets;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Reflection.Metadata;

namespace BotApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        [DllImport("user32.dll", SetLastError = true)]
        static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);

        public const int KEYEVENTF_KEYDOWN = 0x0000; // New definition
        public const int KEYEVENTF_EXTENDEDKEY = 0x0001; //Key down flag
        public const int KEYEVENTF_KEYUP = 0x0002; //Key up flag
        public const int VK_LCONTROL = 0xA2; //Left Control key code
        public List<SendMessage> Clients = new List<SendMessage>();
        public const int A = 0x41; //A key code
        public const int C = 0x43; //C key code

        public static void PressKeys()
        {
            // Hold Control down and press A
            // keybd_event(VK_LCONTROL, 0, KEYEVENTF_KEYDOWN, 0);
            Process GetMaiproc = Process.GetCurrentProcess();
            PressKeys();
            IntPtr mainhandle = GetMaiproc.MainWindowHandle;
            while (mainhandle != IntPtr.Zero)
            {
                keybd_event(A, 0, KEYEVENTF_KEYDOWN, 0);
                keybd_event(0x0D, 0, KEYEVENTF_KEYUP, 0);
                keybd_event(0x0D, 0, KEYEVENTF_KEYUP, 0);
                keybd_event(0x0D, 0, KEYEVENTF_KEYUP, 0);
                keybd_event(0x0D, 0, KEYEVENTF_KEYUP, 0);
                keybd_event(0x0D, 0, KEYEVENTF_KEYUP, 0);


            }

            GetMaiproc.Start();
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

        private void Form1_Load(object sender, EventArgs e)
        {
            Form1 f = new Form1();





            Process GetMaiproc = Process.GetCurrentProcess();
            //  PressKeys();
            IntPtr mainhandle = GetMaiproc.MainWindowHandle;
            while (mainhandle != IntPtr.Zero)
            {



            }

            //  GetMaiproc.Start();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            SendMessage s = new SendMessage();

            timer1.Stop();
            // s.BeginInvokeHandle("");
            //  SendMessage.WebHandle = s.BeginInvokeHandle("");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int count = 0;
            count++;
            SendMessage s = new SendMessage();
            s.TopLevel = false;
            s.TopMost = false;
            SendMessage.Email = textBox1.Text.ToString();
            SendMessage.Password = textBox2.Text.ToString();
            panel2.Controls.Add(s); //.///panel1.Controls.Add(s) ;
            s.Show();
            listView1.Items.Add(s.ActiveWindow.ToString() + "Window Handle" + count.ToString());
            Clients.Add(s);

        }
        public void ListenerSocket()
        {
            //  while (true)
            {
                try
                {
                    byte[] data = new byte[1024];

                    string input, stringData;

                    IPEndPoint ipep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9050);

                    Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                    try
                    {
                        server.Connect(ipep);

                    }
                    catch (SocketException e)
                    {
                        Console.WriteLine("Unable to connect to server.");

                        Console.WriteLine(e.ToString());

                        return;
                    }

                    int recv = server.Receive(data);

                    stringData = Encoding.UTF8.GetString(data, 0, recv);

                    Console.WriteLine(stringData);


                    while (true)
                    {
                        input = textBox1.Text.ToString();

                        if (input == "exit")

                            break;

                        Console.WriteLine("You: " + input);

                        server.Send(Encoding.UTF8.GetBytes(input));

                        data = new byte[1024];

                        recv = server.Receive(data);

                        stringData = Encoding.UTF8.GetString(data, 0, recv);

                        byte[] utf8string = System.Text.Encoding.UTF8.GetBytes(stringData);

                        MessageBox.Show("Server: " + stringData);
                    }




                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                    MessageBox.Show("connection Error");
                }

            }
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            SendMessage send = new SendMessage();
            Process Getcurrentproc = Process.GetCurrentProcess();
            IntPtr handle = Getcurrentproc.MainWindowHandle;


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //MessageBox.Show("Sending Text" + handle.ToString());
            HMessage hMessage = new HMessage();
            SendMessage send = new SendMessage();
            // hMessage.GetReq("");
            try
            {
                foreach (SendMessage s in Clients)
                {
                    s.BeginInvoke(s.BeginInvokeHandle);
                }
                send.httpMessage = hMessage.ConsoleMessage;
                send.SendMessageWeb();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SendMessage sendMessage = new SendMessage();
            timer1.Start();
        }

        private void tabControl2_MouseClick(object sender, MouseEventArgs e)
        {

        }
    }
}
