namespace ServerClientTCP
{
    partial class ClientForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.L_Information = new System.Windows.Forms.Label();
            this.R_ReceiveMessage = new System.Windows.Forms.RichTextBox();
            this.T_Port = new System.Windows.Forms.TextBox();
            this.T_IPAddress = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.R_SendMessage = new System.Windows.Forms.RichTextBox();
            this.B_SendMessage = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.L_OnlineStatus = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.T_UserName = new System.Windows.Forms.TextBox();
            this.B_Login = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // L_Information
            // 
            this.L_Information.AutoSize = true;
            this.L_Information.Location = new System.Drawing.Point(26, 345);
            this.L_Information.Name = "L_Information";
            this.L_Information.Size = new System.Drawing.Size(0, 12);
            this.L_Information.TabIndex = 21;
            // 
            // R_ReceiveMessage
            // 
            this.R_ReceiveMessage.Location = new System.Drawing.Point(302, 32);
            this.R_ReceiveMessage.Name = "R_ReceiveMessage";
            this.R_ReceiveMessage.Size = new System.Drawing.Size(240, 326);
            this.R_ReceiveMessage.TabIndex = 20;
            this.R_ReceiveMessage.Text = "";
            // 
            // T_Port
            // 
            this.T_Port.Enabled = false;
            this.T_Port.Location = new System.Drawing.Point(107, 57);
            this.T_Port.Name = "T_Port";
            this.T_Port.Size = new System.Drawing.Size(170, 21);
            this.T_Port.TabIndex = 19;
            this.T_Port.Text = "10001";
            // 
            // T_IPAddress
            // 
            this.T_IPAddress.Enabled = false;
            this.T_IPAddress.Location = new System.Drawing.Point(107, 17);
            this.T_IPAddress.Name = "T_IPAddress";
            this.T_IPAddress.Size = new System.Drawing.Size(170, 21);
            this.T_IPAddress.TabIndex = 18;
            this.T_IPAddress.Text = "127.0.0.1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 12);
            this.label4.TabIndex = 17;
            this.label4.Text = "Port:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 16;
            this.label3.Text = "IPAddress:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 210);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 12);
            this.label1.TabIndex = 14;
            this.label1.Text = "Send Message:";
            // 
            // R_SendMessage
            // 
            this.R_SendMessage.Location = new System.Drawing.Point(28, 244);
            this.R_SendMessage.Name = "R_SendMessage";
            this.R_SendMessage.Size = new System.Drawing.Size(249, 85);
            this.R_SendMessage.TabIndex = 13;
            this.R_SendMessage.Text = "";
            this.R_SendMessage.TextChanged += new System.EventHandler(this.R_SendMessage_TextChanged);
            this.R_SendMessage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.B_SendMessage_KeyPress);
            // 
            // B_SendMessage
            // 
            this.B_SendMessage.Enabled = false;
            this.B_SendMessage.Location = new System.Drawing.Point(175, 335);
            this.B_SendMessage.Name = "B_SendMessage";
            this.B_SendMessage.Size = new System.Drawing.Size(102, 23);
            this.B_SendMessage.TabIndex = 11;
            this.B_SendMessage.Text = "SendMessage";
            this.B_SendMessage.UseVisualStyleBackColor = true;
            this.B_SendMessage.Click += new System.EventHandler(this.B_SendMessage_Click);
            this.B_SendMessage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.B_SendMessage_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(300, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 12);
            this.label2.TabIndex = 22;
            this.label2.Text = "Chat Message:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(570, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 12);
            this.label5.TabIndex = 23;
            this.label5.Text = "Online List:";
            // 
            // L_OnlineStatus
            // 
            this.L_OnlineStatus.FormattingEnabled = true;
            this.L_OnlineStatus.ItemHeight = 12;
            this.L_OnlineStatus.Location = new System.Drawing.Point(572, 37);
            this.L_OnlineStatus.Name = "L_OnlineStatus";
            this.L_OnlineStatus.Size = new System.Drawing.Size(160, 316);
            this.L_OnlineStatus.TabIndex = 24;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 102);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 25;
            this.label6.Text = "User Name:";
            // 
            // T_UserName
            // 
            this.T_UserName.Location = new System.Drawing.Point(107, 99);
            this.T_UserName.Name = "T_UserName";
            this.T_UserName.Size = new System.Drawing.Size(170, 21);
            this.T_UserName.TabIndex = 26;
            // 
            // B_Login
            // 
            this.B_Login.Location = new System.Drawing.Point(202, 136);
            this.B_Login.Name = "B_Login";
            this.B_Login.Size = new System.Drawing.Size(75, 23);
            this.B_Login.TabIndex = 27;
            this.B_Login.Text = "Login";
            this.B_Login.UseVisualStyleBackColor = true;
            this.B_Login.Click += new System.EventHandler(this.B_Login_Click);
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 374);
            this.Controls.Add(this.B_Login);
            this.Controls.Add(this.T_UserName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.L_OnlineStatus);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.L_Information);
            this.Controls.Add(this.R_ReceiveMessage);
            this.Controls.Add(this.T_Port);
            this.Controls.Add(this.T_IPAddress);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.R_SendMessage);
            this.Controls.Add(this.B_SendMessage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "ClientForm";
            this.Text = "ClientForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ClientForm_FormClosing);
            this.Load += new System.EventHandler(this.ClientForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label L_Information;
        private System.Windows.Forms.RichTextBox R_ReceiveMessage;
        private System.Windows.Forms.TextBox T_Port;
        private System.Windows.Forms.TextBox T_IPAddress;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox R_SendMessage;
        private System.Windows.Forms.Button B_SendMessage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox L_OnlineStatus;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox T_UserName;
        private System.Windows.Forms.Button B_Login;
    }
}

