namespace SimpleChatClient
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Txt_Send = new System.Windows.Forms.TextBox();
            this.Txt_Host = new System.Windows.Forms.TextBox();
            this.Txt_Port = new System.Windows.Forms.TextBox();
            this.Btn_Connect = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.Btn_Send = new System.Windows.Forms.Button();
            this.Txt_Username = new System.Windows.Forms.TextBox();
            this.Rtxt_chatArea = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label2, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.Txt_Send, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.Txt_Host, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.Txt_Port, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.Btn_Connect, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.listView1, 6, 1);
            this.tableLayoutPanel1.Controls.Add(this.Btn_Send, 6, 2);
            this.tableLayoutPanel1.Controls.Add(this.Txt_Username, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.Rtxt_chatArea, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 4, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(5);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 533);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(216, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 21);
            this.label2.TabIndex = 4;
            this.label2.Text = "Port";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 21);
            this.label1.TabIndex = 3;
            this.label1.Text = "Host";
            // 
            // Txt_Send
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.Txt_Send, 6);
            this.Txt_Send.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Txt_Send.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Txt_Send.Location = new System.Drawing.Point(3, 465);
            this.Txt_Send.Multiline = true;
            this.Txt_Send.Name = "Txt_Send";
            this.Txt_Send.Size = new System.Drawing.Size(693, 65);
            this.Txt_Send.TabIndex = 5;
            // 
            // Txt_Host
            // 
            this.Txt_Host.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Txt_Host.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Txt_Host.Location = new System.Drawing.Point(54, 3);
            this.Txt_Host.Name = "Txt_Host";
            this.Txt_Host.Size = new System.Drawing.Size(156, 29);
            this.Txt_Host.TabIndex = 6;
            this.Txt_Host.Text = "127.0.0.1";
            // 
            // Txt_Port
            // 
            this.Txt_Port.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Txt_Port.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Txt_Port.Location = new System.Drawing.Point(264, 3);
            this.Txt_Port.Name = "Txt_Port";
            this.Txt_Port.Size = new System.Drawing.Size(153, 29);
            this.Txt_Port.TabIndex = 7;
            this.Txt_Port.Text = "6017";
            // 
            // Btn_Connect
            // 
            this.Btn_Connect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_Connect.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.Btn_Connect.Location = new System.Drawing.Point(702, 3);
            this.Btn_Connect.Name = "Btn_Connect";
            this.Btn_Connect.Size = new System.Drawing.Size(95, 29);
            this.Btn_Connect.TabIndex = 9;
            this.Btn_Connect.Text = "Connect";
            this.Btn_Connect.UseVisualStyleBackColor = true;
            this.Btn_Connect.Click += new System.EventHandler(this.Btn_Connect_Click);
            // 
            // listView1
            // 
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listView1.Location = new System.Drawing.Point(702, 38);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(95, 421);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // Btn_Send
            // 
            this.Btn_Send.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_Send.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_Send.Location = new System.Drawing.Point(702, 465);
            this.Btn_Send.Name = "Btn_Send";
            this.Btn_Send.Size = new System.Drawing.Size(95, 65);
            this.Btn_Send.TabIndex = 0;
            this.Btn_Send.Text = "Send";
            this.Btn_Send.UseVisualStyleBackColor = true;
            this.Btn_Send.Click += new System.EventHandler(this.Btn_Send_Click);
            // 
            // Txt_Username
            // 
            this.Txt_Username.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Txt_Username.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.Txt_Username.Location = new System.Drawing.Point(485, 3);
            this.Txt_Username.Name = "Txt_Username";
            this.Txt_Username.Size = new System.Drawing.Size(211, 29);
            this.Txt_Username.TabIndex = 11;
            this.Txt_Username.Text = "Chieh";
            // 
            // Rtxt_chatArea
            // 
            this.Rtxt_chatArea.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Rtxt_chatArea.BackColor = System.Drawing.SystemColors.Window;
            this.tableLayoutPanel1.SetColumnSpan(this.Rtxt_chatArea, 6);
            this.Rtxt_chatArea.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Rtxt_chatArea.Location = new System.Drawing.Point(3, 38);
            this.Rtxt_chatArea.Name = "Rtxt_chatArea";
            this.Rtxt_chatArea.ReadOnly = true;
            this.Rtxt_chatArea.Size = new System.Drawing.Size(693, 421);
            this.Rtxt_chatArea.TabIndex = 8;
            this.Rtxt_chatArea.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label3.Location = new System.Drawing.Point(423, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 21);
            this.label3.TabIndex = 10;
            this.label3.Text = "Name";
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 533);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ClientForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.ClientForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Txt_Host;
        private System.Windows.Forms.TextBox Txt_Port;
        private System.Windows.Forms.RichTextBox Rtxt_chatArea;
        private System.Windows.Forms.Button Btn_Connect;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Txt_Username;
        private System.Windows.Forms.TextBox Txt_Send;
        private System.Windows.Forms.Button Btn_Send;
    }
}

