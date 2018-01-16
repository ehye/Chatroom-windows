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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Btn_start = new System.Windows.Forms.Button();
            this.Rtxt_chat = new System.Windows.Forms.RichTextBox();
            this.Dgv_Info = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.username = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ip = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.Combo_IP = new System.Windows.Forms.ComboBox();
            this.Txt_port = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Btn_getPubIP = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_Info)).BeginInit();
            this.SuspendLayout();
            // 
            // Btn_start
            // 
            this.Btn_start.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.Btn_start.Location = new System.Drawing.Point(689, 8);
            this.Btn_start.Name = "Btn_start";
            this.Btn_start.Size = new System.Drawing.Size(83, 39);
            this.Btn_start.TabIndex = 22;
            this.Btn_start.Text = "Start";
            this.Btn_start.UseVisualStyleBackColor = true;
            this.Btn_start.Click += new System.EventHandler(this.Btn_start_Click);
            // 
            // Rtxt_chat
            // 
            this.Rtxt_chat.BackColor = System.Drawing.SystemColors.Window;
            this.Rtxt_chat.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.Rtxt_chat.Location = new System.Drawing.Point(12, 57);
            this.Rtxt_chat.Name = "Rtxt_chat";
            this.Rtxt_chat.ReadOnly = true;
            this.Rtxt_chat.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.Rtxt_chat.Size = new System.Drawing.Size(760, 323);
            this.Rtxt_chat.TabIndex = 27;
            this.Rtxt_chat.Text = "";
            this.Rtxt_chat.TextChanged += new System.EventHandler(this.Rtxt_chat_TextChanged);
            // 
            // Dgv_Info
            // 
            this.Dgv_Info.AllowUserToAddRows = false;
            this.Dgv_Info.AllowUserToDeleteRows = false;
            this.Dgv_Info.AllowUserToResizeRows = false;
            this.Dgv_Info.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.Dgv_Info.BackgroundColor = System.Drawing.SystemColors.Window;
            this.Dgv_Info.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Dgv_Info.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.Dgv_Info.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Dgv_Info.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.Dgv_Info.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv_Info.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.username,
            this.ip});
            this.Dgv_Info.Location = new System.Drawing.Point(12, 386);
            this.Dgv_Info.Name = "Dgv_Info";
            this.Dgv_Info.ReadOnly = true;
            this.Dgv_Info.RowHeadersVisible = false;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Dgv_Info.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.Dgv_Info.RowTemplate.Height = 23;
            this.Dgv_Info.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Dgv_Info.Size = new System.Drawing.Size(760, 150);
            this.Dgv_Info.TabIndex = 29;
            // 
            // id
            // 
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Width = 48;
            // 
            // username
            // 
            this.username.HeaderText = "Username";
            this.username.Name = "username";
            this.username.ReadOnly = true;
            this.username.Width = 96;
            // 
            // ip
            // 
            this.ip.HeaderText = "IP : Port";
            this.ip.Name = "ip";
            this.ip.ReadOnly = true;
            this.ip.Width = 83;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 539);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(784, 22);
            this.statusStrip1.TabIndex = 31;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // Combo_IP
            // 
            this.Combo_IP.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.Combo_IP.FormattingEnabled = true;
            this.Combo_IP.Location = new System.Drawing.Point(86, 12);
            this.Combo_IP.Name = "Combo_IP";
            this.Combo_IP.Size = new System.Drawing.Size(174, 28);
            this.Combo_IP.TabIndex = 32;
            // 
            // Txt_port
            // 
            this.Txt_port.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.Txt_port.Location = new System.Drawing.Point(310, 12);
            this.Txt_port.Name = "Txt_port";
            this.Txt_port.Size = new System.Drawing.Size(100, 27);
            this.Txt_port.TabIndex = 33;
            this.Txt_port.Text = "6017";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(266, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 19);
            this.label2.TabIndex = 34;
            this.label2.Text = "Port:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 19);
            this.label1.TabIndex = 35;
            this.label1.Text = "Server IP:";
            // 
            // Btn_getPubIP
            // 
            this.Btn_getPubIP.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.Btn_getPubIP.Location = new System.Drawing.Point(568, 8);
            this.Btn_getPubIP.Name = "Btn_getPubIP";
            this.Btn_getPubIP.Size = new System.Drawing.Size(115, 39);
            this.Btn_getPubIP.TabIndex = 22;
            this.Btn_getPubIP.Text = "Get Public IP";
            this.Btn_getPubIP.UseVisualStyleBackColor = true;
            this.Btn_getPubIP.Click += new System.EventHandler(this.Btn_getPubIP_Click);
            // 
            // ServerMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Txt_port);
            this.Controls.Add(this.Combo_IP);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.Dgv_Info);
            this.Controls.Add(this.Rtxt_chat);
            this.Controls.Add(this.Btn_getPubIP);
            this.Controls.Add(this.Btn_start);
            this.MinimizeBox = false;
            this.Name = "ServerMain";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.ServerMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_Info)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button Btn_start;
        private System.Windows.Forms.RichTextBox Rtxt_chat;
        private System.Windows.Forms.DataGridView Dgv_Info;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn username;
        private System.Windows.Forms.DataGridViewTextBoxColumn ip;
        private System.Windows.Forms.ComboBox Combo_IP;
        private System.Windows.Forms.TextBox Txt_port;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Btn_getPubIP;
    }
}

