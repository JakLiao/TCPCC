namespace ServerTCP
{
    partial class MainForm
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
            this.B_SendMessage = new System.Windows.Forms.Button();
            this.L_ClientList = new System.Windows.Forms.ListBox();
            this.R_SendMessage = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.T_IPAddress = new System.Windows.Forms.TextBox();
            this.T_Port = new System.Windows.Forms.TextBox();
            this.R_ReceiveMessage = new System.Windows.Forms.RichTextBox();
            this.L_Information = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // B_SendMessage
            // 
            this.B_SendMessage.Location = new System.Drawing.Point(198, 337);
            this.B_SendMessage.Name = "B_SendMessage";
            this.B_SendMessage.Size = new System.Drawing.Size(98, 23);
            this.B_SendMessage.TabIndex = 0;
            this.B_SendMessage.Text = "SendMessage";
            this.B_SendMessage.UseVisualStyleBackColor = true;
            this.B_SendMessage.Click += new System.EventHandler(this.B_SendMessage_Click);
            this.B_SendMessage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.B_SendMessage_KeyPress);
            // 
            // L_ClientList
            // 
            this.L_ClientList.FormattingEnabled = true;
            this.L_ClientList.ItemHeight = 12;
            this.L_ClientList.Location = new System.Drawing.Point(47, 106);
            this.L_ClientList.Name = "L_ClientList";
            this.L_ClientList.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.L_ClientList.Size = new System.Drawing.Size(249, 112);
            this.L_ClientList.TabIndex = 1;
            // 
            // R_SendMessage
            // 
            this.R_SendMessage.Location = new System.Drawing.Point(45, 253);
            this.R_SendMessage.Name = "R_SendMessage";
            this.R_SendMessage.Size = new System.Drawing.Size(251, 72);
            this.R_SendMessage.TabIndex = 2;
            this.R_SendMessage.Text = "";
            this.R_SendMessage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.B_SendMessage_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 238);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "Send Message:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "Client List:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "IPAddress:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(45, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "Port:";
            // 
            // T_IPAddress
            // 
            this.T_IPAddress.Location = new System.Drawing.Point(126, 13);
            this.T_IPAddress.Name = "T_IPAddress";
            this.T_IPAddress.Size = new System.Drawing.Size(170, 21);
            this.T_IPAddress.TabIndex = 7;
            this.T_IPAddress.Text = "127.0.0.1";
            // 
            // T_Port
            // 
            this.T_Port.Location = new System.Drawing.Point(126, 53);
            this.T_Port.Name = "T_Port";
            this.T_Port.Size = new System.Drawing.Size(170, 21);
            this.T_Port.TabIndex = 8;
            this.T_Port.Text = "10001";
            // 
            // R_ReceiveMessage
            // 
            this.R_ReceiveMessage.Location = new System.Drawing.Point(321, 37);
            this.R_ReceiveMessage.Name = "R_ReceiveMessage";
            this.R_ReceiveMessage.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.R_ReceiveMessage.Size = new System.Drawing.Size(240, 317);
            this.R_ReceiveMessage.TabIndex = 9;
            this.R_ReceiveMessage.Text = "";
            // 
            // L_Information
            // 
            this.L_Information.AutoSize = true;
            this.L_Information.Location = new System.Drawing.Point(45, 342);
            this.L_Information.Name = "L_Information";
            this.L_Information.Size = new System.Drawing.Size(0, 12);
            this.L_Information.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(319, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 12);
            this.label5.TabIndex = 23;
            this.label5.Text = "Received Message:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 366);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.L_Information);
            this.Controls.Add(this.R_ReceiveMessage);
            this.Controls.Add(this.T_Port);
            this.Controls.Add(this.T_IPAddress);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.R_SendMessage);
            this.Controls.Add(this.L_ClientList);
            this.Controls.Add(this.B_SendMessage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "ServerForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button B_SendMessage;
        private System.Windows.Forms.ListBox L_ClientList;
        private System.Windows.Forms.RichTextBox R_SendMessage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox T_IPAddress;
        private System.Windows.Forms.TextBox T_Port;
        private System.Windows.Forms.RichTextBox R_ReceiveMessage;
        private System.Windows.Forms.Label L_Information;
        private System.Windows.Forms.Label label5;

    }
}

