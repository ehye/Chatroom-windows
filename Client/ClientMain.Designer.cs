namespace Client
{
    partial class ClientMain
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.Txt_password = new System.Windows.Forms.TextBox();
            this.Txt_username = new System.Windows.Forms.TextBox();
            this.Txt_send = new System.Windows.Forms.TextBox();
            this.Btn_send = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusLabel_conInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.Btn_connect = new System.Windows.Forms.Button();
            this.Rtxt_chat = new System.Windows.Forms.RichTextBox();
            this.Txt_host = new System.Windows.Forms.TextBox();
            this.Txt_port = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Txt_password
            // 
            this.Txt_password.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.Txt_password.Location = new System.Drawing.Point(479, 13);
            this.Txt_password.Name = "Txt_password";
            this.Txt_password.Size = new System.Drawing.Size(131, 29);
            this.Txt_password.TabIndex = 22;
            this.Txt_password.Text = "0592";
            this.Txt_password.UseSystemPasswordChar = true;
            // 
            // Txt_username
            // 
            this.Txt_username.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Txt_username.Location = new System.Drawing.Point(265, 13);
            this.Txt_username.Name = "Txt_username";
            this.Txt_username.Size = new System.Drawing.Size(131, 29);
            this.Txt_username.TabIndex = 21;
            this.Txt_username.Text = "user";
            // 
            // Txt_send
            // 
            this.Txt_send.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Txt_send.Location = new System.Drawing.Point(9, 421);
            this.Txt_send.Multiline = true;
            this.Txt_send.Name = "Txt_send";
            this.Txt_send.Size = new System.Drawing.Size(745, 114);
            this.Txt_send.TabIndex = 19;
            // 
            // Btn_send
            // 
            this.Btn_send.Enabled = false;
            this.Btn_send.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_send.Location = new System.Drawing.Point(760, 421);
            this.Btn_send.Name = "Btn_send";
            this.Btn_send.Size = new System.Drawing.Size(115, 115);
            this.Btn_send.TabIndex = 18;
            this.Btn_send.Text = "Send";
            this.Btn_send.UseVisualStyleBackColor = true;
            this.Btn_send.Click += new System.EventHandler(this.Btn_send_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel_conInfo});
            this.statusStrip1.Location = new System.Drawing.Point(0, 539);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(884, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 23;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusLabel_conInfo
            // 
            this.statusLabel_conInfo.BackColor = System.Drawing.SystemColors.Control;
            this.statusLabel_conInfo.Name = "statusLabel_conInfo";
            this.statusLabel_conInfo.Size = new System.Drawing.Size(100, 17);
            this.statusLabel_conInfo.Text = "Connection Info";
            // 
            // Btn_connect
            // 
            this.Btn_connect.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.Btn_connect.Location = new System.Drawing.Point(747, 11);
            this.Btn_connect.Name = "Btn_connect";
            this.Btn_connect.Size = new System.Drawing.Size(125, 30);
            this.Btn_connect.TabIndex = 24;
            this.Btn_connect.Text = "Connect";
            this.Btn_connect.UseVisualStyleBackColor = true;
            this.Btn_connect.Click += new System.EventHandler(this.Btn_connect_Click);
            // 
            // Rtxt_chat
            // 
            this.Rtxt_chat.BackColor = System.Drawing.SystemColors.Window;
            this.Rtxt_chat.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.Rtxt_chat.Location = new System.Drawing.Point(9, 48);
            this.Rtxt_chat.Name = "Rtxt_chat";
            this.Rtxt_chat.ReadOnly = true;
            this.Rtxt_chat.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.Rtxt_chat.Size = new System.Drawing.Size(863, 367);
            this.Rtxt_chat.TabIndex = 25;
            this.Rtxt_chat.Text = "";
            this.Rtxt_chat.TextChanged += new System.EventHandler(this.Rtxt_chat_TextChanged);
            // 
            // Txt_host
            // 
            this.Txt_host.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Txt_host.Location = new System.Drawing.Point(52, 13);
            this.Txt_host.Name = "Txt_host";
            this.Txt_host.Size = new System.Drawing.Size(131, 29);
            this.Txt_host.TabIndex = 21;
            this.Txt_host.Text = "58.23.42.121";
            // 
            // Txt_port
            // 
            this.Txt_port.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.Txt_port.Location = new System.Drawing.Point(660, 13);
            this.Txt_port.Name = "Txt_port";
            this.Txt_port.Size = new System.Drawing.Size(69, 29);
            this.Txt_port.TabIndex = 22;
            this.Txt_port.Text = "6017";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(5, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 19);
            this.label1.TabIndex = 26;
            this.label1.Text = "Host:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(402, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 19);
            this.label2.TabIndex = 26;
            this.label2.Text = "Username:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(189, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 19);
            this.label3.TabIndex = 26;
            this.label3.Text = "Password:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(616, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 19);
            this.label4.TabIndex = 26;
            this.label4.Text = "Port:";
            // 
            // ClientMain
            // 
            this.AcceptButton = this.Btn_send;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.Btn_send);
            this.Controls.Add(this.Rtxt_chat);
            this.Controls.Add(this.Txt_send);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Btn_connect);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.Txt_port);
            this.Controls.Add(this.Txt_host);
            this.Controls.Add(this.Txt_password);
            this.Controls.Add(this.Txt_username);
            this.MaximizeBox = false;
            this.Name = "ClientMain";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.ClientMain_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Txt_password;
        private System.Windows.Forms.TextBox Txt_username;
        private System.Windows.Forms.TextBox Txt_send;
        private System.Windows.Forms.Button Btn_send;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel_conInfo;
        private System.Windows.Forms.Button Btn_connect;
        private System.Windows.Forms.RichTextBox Rtxt_chat;
        private System.Windows.Forms.TextBox Txt_host;
        private System.Windows.Forms.TextBox Txt_port;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

