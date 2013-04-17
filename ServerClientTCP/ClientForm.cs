using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;

namespace ServerClientTCP
{
    public partial class ClientForm : Form
    {
        private bool connected = false;
        private IPAddress initIP;
        private int initPort;
        private static byte[] message = new byte[1024];

        private bool isExit = false;
        private TcpClient client;
        private BinaryReader br;
        private BinaryWriter bw;

        public ClientForm()
        {
            InitializeComponent();
            Random r = new Random((int)DateTime.Now.Ticks);
            T_UserName.Text = "user" + r.Next(100, 999);
            L_OnlineStatus.HorizontalScrollbar = true;
        }
        /// <summary>加载窗口时触发的事件</summary>
        private void ClientForm_Load(object sender, EventArgs e)
        {
            this.initIP = IPAddress.Parse(T_IPAddress.Text.ToString().Trim());
            this.initPort = Convert.ToInt32(T_Port.Text.ToString().Trim());
            Control.CheckForIllegalCrossThreadCalls = false;
            
        }
        /// <summary>
        /// 【连接服务器】按钮的Click事件
        /// </summary>
        private void B_Login_Click(object sender, EventArgs e)
        {
            this.B_Login.Enabled = false;
            try
            {
                client = new TcpClient(Dns.GetHostName(), this.initPort);
                AddTalkMessage("Connected");
                L_Information.Text = "Success connected...";
            }
            catch
            {
                AddTalkMessage("Connect Failed");
                this.B_Login.Enabled = true;
                return;
            }
            //获取网络流
            NetworkStream networkStream = client.GetStream();
            //将网络流作为二进制读写对象
            br = new BinaryReader(networkStream);
            bw = new BinaryWriter(networkStream);
            SendMessage("Login," + T_UserName.Text);
            Thread threadReceive = new Thread(new ThreadStart(ReceiveData));
            threadReceive.IsBackground = true;
            threadReceive.Start();
        }
        /// <summary>【发送】按钮的Click事件</summary>
        private void B_SendMessage_Click(object sender, EventArgs e)
        {
            if (L_OnlineStatus.SelectedIndex != -1)
            {
                SendMessage("Talk," + L_OnlineStatus.SelectedItem + "," + R_SendMessage.Text);
                AddTalkMessage("我说：" + R_SendMessage.Text);
                R_SendMessage.Clear();
            }
            else
            {
                MessageBox.Show("请先在[当前在线]中选择一个对话者");
            }
        }
        /// <summary>处理接收的服务器端数据</summary>
        private void ReceiveData()
        {
            string receiveString = null;
            while (isExit == false)
            {
                try
                {
                    //从网络流中读出字符串
                    //此方法会自动判断字符串长度前缀，并根据长度前缀读出字符串
                    //如果服务器异常退出，则会产生异常
                    receiveString = br.ReadString();
                }
                catch
                {
                    if (isExit == false)
                    {
                        MessageBox.Show("与服务器失去联系。");
                    }
                    break;
                }
                string[] splitString = receiveString.Split(',');
                string command = splitString[0].ToLower();
                switch (command)
                {
                    case "login":  //格式：login,用户名
                        AddOnline(splitString[1]);
                        break;
                    case "logout":  //格式：logout,用户名
                        RemoveUserName(splitString[1]);
                        break;
                    case "talk":  //格式：talk,用户名,对话信息
                        //AddTalkMessage(splitString[1] + "：\r\n");
                        //AddTalkMessage(receiveString.Substring(
                        //    splitString[0].Length + splitString[1].Length+2));
                        AddTalkMessage(string.Format("[{0}]说：{1}",
                            splitString[1], receiveString.Substring(
                            splitString[0].Length + splitString[1].Length + 2)));
                        break;
                    default:
                        AddTalkMessage("什么意思啊：" + receiveString);
                        break;
                }
            }
            Application.Exit();  //服务器可能异常退出，则本方退出
        }
        /// <summary>向服务器端发送信息</summary>
        private void SendMessage(string message)
        {
            try
            {
                //将字符串写入网络流，此方法会自动附加字符串长度前缀
                bw.Write(message);
                bw.Flush();
            }
            catch
            {
                AddTalkMessage("发送失败!");
            }
        }
        /// <summary>【发送】按钮的Click事件</summary>
        private void buttonSend_Click(object sender, EventArgs e)
        {
            if (L_OnlineStatus.SelectedIndex != -1)
            {
                //SendMessage("Talk," + listBoxOnlineStatus.SelectedItem + "," + textBoxSend.Text+"\r\n");
                SendMessage("Talk," + L_OnlineStatus.SelectedItem + "," + R_SendMessage.Text);
                //本方发言书上例题是等服务器发回给本方后才显示出来，以下语句表示直接显示，不经过服务器绕回
                AddTalkMessage("我说：" + R_SendMessage.Text);
                R_SendMessage.Clear();
            }
            else
            {
                MessageBox.Show("请先在[当前在线]中选择一个对话者");
            }
        }
        /// <summary>关闭窗口时触发的事件</summary>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //未与服务器连接前client为null
            if (client != null)
            {
                SendMessage("Logout," + T_UserName.Text);
                isExit = true;
                br.Close();
                bw.Close();
                client.Close();
            }
        }
        private void B_SendMessage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (connected)
                {
                    B_SendMessage.PerformClick();
                }
                else
                {
                    MessageBox.Show("Has not detective server to connect...", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }
        private delegate void MessageDelegate(string message);
        /// <summary> 在R_ReceiveMessage中追加聊天信息</summary>
        private void AddTalkMessage(string message)
        {

            if (R_ReceiveMessage.InvokeRequired)
            {
                MessageDelegate d = new MessageDelegate(AddTalkMessage);
                R_ReceiveMessage.Invoke(d, new object[] { message });
            }
            else
            {
                R_ReceiveMessage.AppendText(message + Environment.NewLine);
                R_ReceiveMessage.ScrollToCaret();
            }
        }
        private delegate void AddOnlineDelegate(string message);
        /// <summary> 在L_OnlineStatus中添加在线的其它客户端信息</summary>
        private void AddOnline(string userName)
        {
            if (L_OnlineStatus.InvokeRequired)
            {
                AddOnlineDelegate d = new AddOnlineDelegate(AddOnline);
                L_OnlineStatus.Invoke(d, new object[] { userName });
            }
            else
            {
                L_OnlineStatus.Items.Add(userName);
                L_OnlineStatus.SelectedIndex = L_OnlineStatus.Items.Count - 1;
                L_OnlineStatus.ClearSelected();
            }
        }
        private delegate void RemoveUserNameDelegate(string userName);
        /// <summary> 在L_OnlineStatus中移除不在线的其它客户端信息</summary>
        private void RemoveUserName(string userName)
        {
            if (L_OnlineStatus.InvokeRequired)
            {
                RemoveUserNameDelegate d = RemoveUserName;
                L_OnlineStatus.Invoke(d, userName);
            }
            else
            {
                L_OnlineStatus.Items.Remove(userName);
                L_OnlineStatus.SelectedIndex = L_OnlineStatus.Items.Count - 1;
                L_OnlineStatus.ClearSelected();
            }
        }

        private void R_SendMessage_TextChanged(object sender, EventArgs e)
        {
            if (R_SendMessage.Text.Length == 0)
                B_SendMessage.Enabled = false;
            else
                B_SendMessage.Enabled = true;
        }  
    }
}
