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

namespace ServerTCP
{
    public partial class MainForm : Form
    {
        private IPAddress initIP;
        private int initPort;

        /// <summary>保存连接的所有用户</summary>
        private List<User> userList = new List<User>();
        /// <summary>选择发送消息的所有用户</summary>
        private List<User> chooseUser = new List<User>();
        private TcpListener myListener;
        /// <summary>是否正常退出所有接收线程</summary>
        bool isNormalExit = false;
        /// <summary>接收的消息</summary>
        private static byte[] message = new byte[1024];   

        public MainForm()
        {
            InitializeComponent();
            L_ClientList.HorizontalScrollbar = true;
        }

        private void InitNetWork()
        {
            this.isNormalExit = false;
            myListener = new TcpListener(IPAddress.Any, initPort);
            myListener.Start();
            R_ReceiveMessage.AppendText(string.Format("开始在{0}:{1}监听客户连接", initIP, initPort) + Environment.NewLine);
            L_Information.Text += "Listening...";
            //创建一个线程监听客户端连接请求
            Thread myThread = new Thread(ListenClientConnect);
            myThread.Start();
        }

        /// <summary>接收客户端连接</summary>
        private void ListenClientConnect()
        {
            TcpClient newClient = null;
            while (true)
            {
                try
                {
                    newClient = myListener.AcceptTcpClient();
                }
                catch
                {
                    //当单击“停止监听”或者退出此窗体时AcceptTcpClient()会产生异常
                    //因此可以利用此异常退出循环
                    break;
                }
                //每接受一个客户端连接,就创建一个对应的线程循环接收该客户端发来的信息
                User user = new User(newClient);
                //客户端的端口号
                user.port = newClient.Client.RemoteEndPoint.ToString().Split(':')[1];
                Thread threadReceive = new Thread(ReceiveData);
                threadReceive.Start(user);
                userList.Add(user);
                AddItemToListBox(string.Format("[{0}]进入", newClient.Client.RemoteEndPoint));
                AddItemToListBox(string.Format("当前连接用户数：{0}", userList.Count));
            }
        }

        /// <summary>【发送】按钮的Click事件</summary>
        private void B_SendMessage_Click(object sender, EventArgs e)
        {
            chooseUser.Clear();
            if (userList.Count > 0)
            {
                for (int i = 0; i < L_ClientList.Items.Count; i++)
                {
                    if (L_ClientList.GetSelected(i))
                    {
                        chooseUser.Add(userList[i]);
                    }
                }
                foreach (User target in chooseUser)
                {
                        SendToClient(target, "talk," + "admin" + "," + R_SendMessage.Text);
                }
            }
            else
            {
                MessageBox.Show("No client to connect...", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        /// <summary>
        /// 处理接收的客户端数据
        /// </summary>
        /// <param name="userState">客户端信息</param>
        private void ReceiveData(object userState)
        {
            User user = (User)userState;
            TcpClient client = user.client;
            while (isNormalExit == false)
            {
                string receiveString = null;
                try
                {
                    //从网络流中读出字符串，此方法会自动判断字符串长度前缀，并根据长度前缀读出字符串
                    receiveString = user.br.ReadString();
                }
                catch
                {
                    if (isNormalExit == false)
                    {
                        AddItemToListBox(string.Format("与[{0}]失去联系，已终止接收该用户信息", client.Client.RemoteEndPoint));
                        RemoveUser(user);
                    }
                    break;
                }
                AddItemToListBox(string.Format("来自[{0}]：{1}", user.client.Client.RemoteEndPoint, receiveString));
                string[] splitString = receiveString.Split(',');
                switch (splitString[0])
                {
                    case "Login":
                        user.userName = splitString[1];
                        AddItemToUserBox(user.userName);
                        SendToAllClient(user, receiveString+","+user.port);
                        break;
                    case "Logout":
                        RemoveItemFromUserBox(user.userName);
                        SendToAllClient(user, receiveString);
                        RemoveUser(user);
                        return;
                    case "Talk":
                        string talkString = receiveString.Substring(splitString[0].Length + splitString[1].Length + 2);
                        AddItemToListBox(string.Format("{0}对{1}说：{2}",
                            user.userName, splitString[1], talkString));
                        //以下语句返回给发言方
                        //SendToClient(user, "talk," + user.userName + "," + talkString);
                        //发送给接受方
                        foreach (User target in userList)
                        {
                            if (target.userName == splitString[1] && user.userName != splitString[1])
                            {
                                SendToClient(target, "talk," + user.userName + "," + talkString);
                                break;
                            }
                        }
                        break;
                    default:
                        AddItemToListBox("什么意思啊：" + receiveString);
                        break;
                }

            }
        }
        /// <summary>
        /// 发送message给user
        /// </summary>
        /// <param name="user">指定发给哪个用户</param>
        /// <param name="message">信息内容</param>
        private void SendToClient(User user, string message)
        {
            try
            {
                //将字符串写入网络流，此方法会自动附加字符串长度前缀
                user.bw.Write(message);
                user.bw.Flush();
                AddItemToListBox(string.Format("向[{0}]：{1}发送：{2}",user.userName, user.port, message));
            }
            catch
            {
                AddItemToListBox(string.Format("向[{0}]发送信息失败",user.userName,user.port));
            }
        }
        /// <summary>发送信息给所有客户</summary>
        /// <param name="user">指定发给哪个用户</param>
        /// <param name="message">信息内容</param>
        private void SendToAllClient(User user, string message)
        {
            string command = message.Split(',')[0].ToLower();
            if (command == "login")
            {
                for (int i = 0; i < userList.Count; i++)
                {
                    SendToClient(userList[i], message);
                    if (userList[i].userName != user.userName)
                    {
                        SendToClient(user, "login," + userList[i].userName +","+ userList[i].port);
                    }
                }
            }
            else if (command == "logout")
            {
                for (int i = 0; i < userList.Count; i++)
                {
                    if (userList[i].userName != user.userName)
                    {
                        SendToClient(userList[i], message);
                    }
                }
            }
        }
        /// <summary>移除用户</summary>
        /// <param name="user">指定要删除的用户</param>
        private void RemoveUser(User user)
        {
            userList.Remove(user);
            user.Close();
            AddItemToListBox(string.Format("当前连接用户数：{0}", userList.Count));
        }
       
        /// <summary>关闭窗口时触发的事件</summary>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            isNormalExit = true;
            for (int i = userList.Count - 1; i >= 0; i--)
            {
                RemoveUser(userList[i]);
            }
            //通过停止监听让myListener.AcceptTcpClient()产生异常退出监听线程
            myListener.Stop();
            Application.Exit();
        }
        /// <summary>加载窗口时触发的事件</summary>
        private void MainForm_Load(object sender, EventArgs e)
        {
            initIP = IPAddress.Parse(T_IPAddress.Text.ToString().Trim());
            initPort = Convert.ToInt32(T_Port.Text.ToString().Trim());
            InitNetWork();
        }

        private void B_SendMessage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                B_SendMessage.PerformClick();
            }
        }

        private delegate void AddItemToUserBoxDelegate(string user);
        /// <summary>在ListBox中追加状态信息</summary>
        /// <param name="user">要追加的信息</param>
        private void AddItemToUserBox(string user)
        {
            if (L_ClientList.InvokeRequired)
            {
                AddItemToUserBoxDelegate d = new AddItemToUserBoxDelegate(AddItemToUserBox);
                L_ClientList.Invoke(d, new object[] {user});
            }
            else
            {
                L_ClientList.Items.Add(user);
                L_ClientList.SelectedIndex = L_ClientList.Items.Count - 1;
                L_ClientList.ClearSelected();
            }
        }

        private delegate void RemoveItemFromUserBoxDelegate(string user);
        /// <summary>在ListBox中移除状态信息</summary>
        /// <param name="user">要移除的信息</param>
        private void RemoveItemFromUserBox(string user)
        {
            if (L_ClientList.InvokeRequired)
            {
                RemoveItemFromUserBoxDelegate d = AddItemToListBox;
                L_ClientList.Invoke(d, user);
            }
            else
            {
                L_ClientList.Items.Remove(user);
                L_ClientList.SelectedIndex = L_ClientList.Items.Count - 1;
                L_ClientList.ClearSelected();
            }
        }

        private delegate void AddItemToListBoxDelegate(string str);
        /// <summary>在ListBox中追加状态信息</summary>
        /// <param name="str">要追加的信息</param>
        private void AddItemToListBox(string str)
        {
            if (R_ReceiveMessage.InvokeRequired)
            {
                AddItemToListBoxDelegate d = AddItemToListBox;
                R_ReceiveMessage.Invoke(d, str);
            }
            else
            {
                R_ReceiveMessage.AppendText(str + Environment.NewLine);
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
