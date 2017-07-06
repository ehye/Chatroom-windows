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
            this.txt_sendMes = new System.Windows.Forms.TextBox();
            this.txt_chatMes = new System.Windows.Forms.TextBox();
            this.Btn_start = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
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
            // txt_sendMes
            // 
            this.txt_sendMes.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_sendMes.Location = new System.Drawing.Point(12, 357);
            this.txt_sendMes.Multiline = true;
            this.txt_sendMes.Name = "txt_sendMes";
            this.txt_sendMes.Size = new System.Drawing.Size(593, 105);
            this.txt_sendMes.TabIndex = 24;
            // 
            // txt_chatMes
            // 
            this.txt_chatMes.BackColor = System.Drawing.SystemColors.Window;
            this.txt_chatMes.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.txt_chatMes.Location = new System.Drawing.Point(12, 64);
            this.txt_chatMes.Multiline = true;
            this.txt_chatMes.Name = "txt_chatMes";
            this.txt_chatMes.ReadOnly = true;
            this.txt_chatMes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_chatMes.Size = new System.Drawing.Size(593, 287);
            this.txt_chatMes.TabIndex = 23;
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
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(630, 134);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(120, 184);
            this.listBox1.TabIndex = 26;
            // 
            // ServerMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.Btn_send);
            this.Controls.Add(this.txt_sendMes);
            this.Controls.Add(this.txt_chatMes);
            this.Controls.Add(this.Btn_start);
            this.Name = "ServerMain";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Btn_send;
        private System.Windows.Forms.TextBox txt_sendMes;
        private System.Windows.Forms.TextBox txt_chatMes;
        private System.Windows.Forms.Button Btn_start;
        private System.Windows.Forms.ListBox listBox1;
    }
}

