namespace wsClient
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Rtxt_chatArea = new System.Windows.Forms.RichTextBox();
            this.Txt_Username = new System.Windows.Forms.TextBox();
            this.Btn_Send = new System.Windows.Forms.Button();
            this.Btn_Connect = new System.Windows.Forms.Button();
            this.Txt_Port = new System.Windows.Forms.TextBox();
            this.Txt_Host = new System.Windows.Forms.TextBox();
            this.Txt_Send = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.list_users = new System.Windows.Forms.ListBox();
            this.lab_selected_user = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(189, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 21);
            this.label2.TabIndex = 4;
            this.label2.Text = "Port";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label3.Location = new System.Drawing.Point(312, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 21);
            this.label3.TabIndex = 10;
            this.label3.Text = "Name";
            // 
            // Rtxt_chatArea
            // 
            this.Rtxt_chatArea.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Rtxt_chatArea.BackColor = System.Drawing.SystemColors.Window;
            this.Rtxt_chatArea.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Rtxt_chatArea.Location = new System.Drawing.Point(21, 49);
            this.Rtxt_chatArea.Name = "Rtxt_chatArea";
            this.Rtxt_chatArea.ReadOnly = true;
            this.Rtxt_chatArea.Size = new System.Drawing.Size(486, 401);
            this.Rtxt_chatArea.TabIndex = 8;
            this.Rtxt_chatArea.Text = "";
            this.Rtxt_chatArea.TextChanged += new System.EventHandler(this.Rtxt_chatArea_TextChanged);
            // 
            // Txt_Username
            // 
            this.Txt_Username.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.Txt_Username.Location = new System.Drawing.Point(374, 14);
            this.Txt_Username.Name = "Txt_Username";
            this.Txt_Username.Size = new System.Drawing.Size(133, 29);
            this.Txt_Username.TabIndex = 11;
            this.Txt_Username.Text = "Chieh";
            // 
            // Btn_Send
            // 
            this.Btn_Send.Enabled = false;
            this.Btn_Send.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_Send.Location = new System.Drawing.Point(513, 456);
            this.Btn_Send.Name = "Btn_Send";
            this.Btn_Send.Size = new System.Drawing.Size(95, 62);
            this.Btn_Send.TabIndex = 0;
            this.Btn_Send.Text = "Send";
            this.Btn_Send.UseVisualStyleBackColor = true;
            this.Btn_Send.Click += new System.EventHandler(this.Btn_Send_Click);
            // 
            // Btn_Connect
            // 
            this.Btn_Connect.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.Btn_Connect.Location = new System.Drawing.Point(513, 13);
            this.Btn_Connect.Name = "Btn_Connect";
            this.Btn_Connect.Size = new System.Drawing.Size(95, 29);
            this.Btn_Connect.TabIndex = 9;
            this.Btn_Connect.Text = "Connect";
            this.Btn_Connect.UseVisualStyleBackColor = true;
            this.Btn_Connect.Click += new System.EventHandler(this.Btn_Connect_Click);
            // 
            // Txt_Port
            // 
            this.Txt_Port.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Txt_Port.Location = new System.Drawing.Point(237, 13);
            this.Txt_Port.Name = "Txt_Port";
            this.Txt_Port.Size = new System.Drawing.Size(69, 29);
            this.Txt_Port.TabIndex = 7;
            this.Txt_Port.Text = "6017";
            // 
            // Txt_Host
            // 
            this.Txt_Host.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Txt_Host.Location = new System.Drawing.Point(68, 13);
            this.Txt_Host.Name = "Txt_Host";
            this.Txt_Host.Size = new System.Drawing.Size(115, 29);
            this.Txt_Host.TabIndex = 6;
            this.Txt_Host.Text = "127.0.0.1";
            // 
            // Txt_Send
            // 
            this.Txt_Send.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Txt_Send.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Txt_Send.Location = new System.Drawing.Point(21, 456);
            this.Txt_Send.Multiline = true;
            this.Txt_Send.Name = "Txt_Send";
            this.Txt_Send.Size = new System.Drawing.Size(486, 62);
            this.Txt_Send.TabIndex = 5;
            this.Txt_Send.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txt_Send_KeyPress);
            this.Txt_Send.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Txt_Send_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(17, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 21);
            this.label1.TabIndex = 3;
            this.label1.Text = "Host";
            // 
            // list_users
            // 
            this.list_users.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.list_users.FormattingEnabled = true;
            this.list_users.ItemHeight = 21;
            this.list_users.Location = new System.Drawing.Point(513, 49);
            this.list_users.Name = "list_users";
            this.list_users.Size = new System.Drawing.Size(95, 403);
            this.list_users.TabIndex = 12;
            this.list_users.SelectedIndexChanged += new System.EventHandler(this.list_users_SelectedIndexChanged);
            // 
            // lab_selected_user
            // 
            this.lab_selected_user.AutoSize = true;
            this.lab_selected_user.Location = new System.Drawing.Point(682, 81);
            this.lab_selected_user.Name = "lab_selected_user";
            this.lab_selected_user.Size = new System.Drawing.Size(41, 12);
            this.lab_selected_user.TabIndex = 13;
            this.lab_selected_user.Text = "label4";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(889, 526);
            this.Controls.Add(this.lab_selected_user);
            this.Controls.Add(this.list_users);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Txt_Host);
            this.Controls.Add(this.Txt_Send);
            this.Controls.Add(this.Txt_Port);
            this.Controls.Add(this.Txt_Username);
            this.Controls.Add(this.Btn_Connect);
            this.Controls.Add(this.Rtxt_chatArea);
            this.Controls.Add(this.Btn_Send);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox Rtxt_chatArea;
        private System.Windows.Forms.TextBox Txt_Username;
        private System.Windows.Forms.Button Btn_Send;
        private System.Windows.Forms.Button Btn_Connect;
        private System.Windows.Forms.TextBox Txt_Port;
        private System.Windows.Forms.TextBox Txt_Host;
        private System.Windows.Forms.TextBox Txt_Send;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox list_users;
        private System.Windows.Forms.Label lab_selected_user;
    }
}

