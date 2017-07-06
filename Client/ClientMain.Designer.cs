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
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Txt_password
            // 
            this.Txt_password.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.Txt_password.Location = new System.Drawing.Point(234, 12);
            this.Txt_password.Name = "Txt_password";
            this.Txt_password.Size = new System.Drawing.Size(215, 29);
            this.Txt_password.TabIndex = 22;
            this.Txt_password.Text = "0592";
            this.Txt_password.UseSystemPasswordChar = true;
            // 
            // Txt_username
            // 
            this.Txt_username.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Txt_username.Location = new System.Drawing.Point(13, 12);
            this.Txt_username.Name = "Txt_username";
            this.Txt_username.Size = new System.Drawing.Size(215, 29);
            this.Txt_username.TabIndex = 21;
            this.Txt_username.Text = "yjw";
            // 
            // Txt_send
            // 
            this.Txt_send.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Txt_send.Location = new System.Drawing.Point(13, 340);
            this.Txt_send.Multiline = true;
            this.Txt_send.Name = "Txt_send";
            this.Txt_send.Size = new System.Drawing.Size(608, 105);
            this.Txt_send.TabIndex = 19;
            // 
            // Btn_send
            // 
            this.Btn_send.Enabled = false;
            this.Btn_send.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_send.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_send.Location = new System.Drawing.Point(627, 340);
            this.Btn_send.Name = "Btn_send";
            this.Btn_send.Size = new System.Drawing.Size(145, 105);
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
            this.statusStrip1.Size = new System.Drawing.Size(784, 22);
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
            this.Btn_connect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_connect.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.Btn_connect.Location = new System.Drawing.Point(627, 47);
            this.Btn_connect.Name = "Btn_connect";
            this.Btn_connect.Size = new System.Drawing.Size(145, 36);
            this.Btn_connect.TabIndex = 24;
            this.Btn_connect.Text = "Connect";
            this.Btn_connect.UseVisualStyleBackColor = true;
            this.Btn_connect.Click += new System.EventHandler(this.Btn_connect_Click);
            // 
            // Rtxt_chat
            // 
            this.Rtxt_chat.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.Rtxt_chat.Location = new System.Drawing.Point(13, 52);
            this.Rtxt_chat.Name = "Rtxt_chat";
            this.Rtxt_chat.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.Rtxt_chat.Size = new System.Drawing.Size(608, 282);
            this.Rtxt_chat.TabIndex = 25;
            this.Rtxt_chat.Text = "";
            // 
            // ClientMain
            // 
            this.AcceptButton = this.Btn_send;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.Rtxt_chat);
            this.Controls.Add(this.Btn_connect);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.Txt_password);
            this.Controls.Add(this.Txt_username);
            this.Controls.Add(this.Txt_send);
            this.Controls.Add(this.Btn_send);
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
    }
}

