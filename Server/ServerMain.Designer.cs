namespace Server
{
    partial class ServerMain
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
            this.Btn_send = new System.Windows.Forms.Button();
            this.Txt_send = new System.Windows.Forms.TextBox();
            this.Btn_start = new System.Windows.Forms.Button();
            this.Rtxt_chat = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // Btn_send
            // 
            this.Btn_send.Enabled = false;
            this.Btn_send.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_send.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_send.Location = new System.Drawing.Point(645, 357);
            this.Btn_send.Name = "Btn_send";
            this.Btn_send.Size = new System.Drawing.Size(103, 105);
            this.Btn_send.TabIndex = 25;
            this.Btn_send.Text = "Send";
            this.Btn_send.UseVisualStyleBackColor = true;
            // 
            // Txt_send
            // 
            this.Txt_send.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Txt_send.Location = new System.Drawing.Point(12, 357);
            this.Txt_send.Multiline = true;
            this.Txt_send.Name = "Txt_send";
            this.Txt_send.Size = new System.Drawing.Size(593, 105);
            this.Txt_send.TabIndex = 24;
            // 
            // Btn_start
            // 
            this.Btn_start.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_start.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.Btn_start.Location = new System.Drawing.Point(652, 64);
            this.Btn_start.Name = "Btn_start";
            this.Btn_start.Size = new System.Drawing.Size(96, 43);
            this.Btn_start.TabIndex = 22;
            this.Btn_start.Text = "Start";
            this.Btn_start.UseVisualStyleBackColor = true;
            this.Btn_start.Click += new System.EventHandler(this.Btn_start_Click);
            // 
            // Rtxt_chat
            // 
            this.Rtxt_chat.BackColor = System.Drawing.SystemColors.Window;
            this.Rtxt_chat.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.Rtxt_chat.Location = new System.Drawing.Point(12, 64);
            this.Rtxt_chat.Name = "Rtxt_chat";
            this.Rtxt_chat.ReadOnly = true;
            this.Rtxt_chat.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.Rtxt_chat.Size = new System.Drawing.Size(593, 287);
            this.Rtxt_chat.TabIndex = 27;
            this.Rtxt_chat.Text = "";
            this.Rtxt_chat.TextChanged += new System.EventHandler(this.Rtxt_chat_TextChanged);
            // 
            // ServerMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.Rtxt_chat);
            this.Controls.Add(this.Btn_send);
            this.Controls.Add(this.Txt_send);
            this.Controls.Add(this.Btn_start);
            this.Name = "ServerMain";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.ServerMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Btn_send;
        private System.Windows.Forms.TextBox Txt_send;
        private System.Windows.Forms.Button Btn_start;
        private System.Windows.Forms.RichTextBox Rtxt_chat;
    }
}

