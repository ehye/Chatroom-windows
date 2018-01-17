namespace ChatServer
{
    partial class ServerForm
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
            this.Btn_Start = new System.Windows.Forms.Button();
            this.Rtxt_Log = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Txt_port = new System.Windows.Forms.TextBox();
            this.Combo_IP = new System.Windows.Forms.ComboBox();
            this.Btn_GetPubIP = new System.Windows.Forms.Button();
            this.Dgv_Info = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.username = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ip = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_Info)).BeginInit();
            this.SuspendLayout();
            // 
            // Btn_Start
            // 
            this.Btn_Start.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_Start.Location = new System.Drawing.Point(715, 14);
            this.Btn_Start.Name = "Btn_Start";
            this.Btn_Start.Size = new System.Drawing.Size(75, 30);
            this.Btn_Start.TabIndex = 0;
            this.Btn_Start.Text = "Start";
            this.Btn_Start.UseVisualStyleBackColor = true;
            this.Btn_Start.Click += new System.EventHandler(this.Btn_Start_Click);
            // 
            // Rtxt_Log
            // 
            this.Rtxt_Log.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Rtxt_Log.Location = new System.Drawing.Point(12, 54);
            this.Rtxt_Log.Name = "Rtxt_Log";
            this.Rtxt_Log.Size = new System.Drawing.Size(697, 302);
            this.Rtxt_Log.TabIndex = 1;
            this.Rtxt_Log.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(277, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 19);
            this.label2.TabIndex = 38;
            this.label2.Text = "Port:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(23, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 19);
            this.label1.TabIndex = 39;
            this.label1.Text = "Server IP:";
            // 
            // Txt_port
            // 
            this.Txt_port.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.Txt_port.Location = new System.Drawing.Point(321, 14);
            this.Txt_port.Name = "Txt_port";
            this.Txt_port.Size = new System.Drawing.Size(100, 27);
            this.Txt_port.TabIndex = 37;
            this.Txt_port.Text = "6017";
            // 
            // Combo_IP
            // 
            this.Combo_IP.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.Combo_IP.FormattingEnabled = true;
            this.Combo_IP.Location = new System.Drawing.Point(97, 14);
            this.Combo_IP.Name = "Combo_IP";
            this.Combo_IP.Size = new System.Drawing.Size(174, 28);
            this.Combo_IP.TabIndex = 36;
            // 
            // Btn_GetPubIP
            // 
            this.Btn_GetPubIP.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.Btn_GetPubIP.Location = new System.Drawing.Point(584, 8);
            this.Btn_GetPubIP.Name = "Btn_GetPubIP";
            this.Btn_GetPubIP.Size = new System.Drawing.Size(115, 39);
            this.Btn_GetPubIP.TabIndex = 40;
            this.Btn_GetPubIP.Text = "Get Public IP";
            this.Btn_GetPubIP.UseVisualStyleBackColor = true;
            this.Btn_GetPubIP.Click += new System.EventHandler(this.Btn_GetPubIP_Click);
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
            this.Dgv_Info.Location = new System.Drawing.Point(12, 362);
            this.Dgv_Info.Name = "Dgv_Info";
            this.Dgv_Info.ReadOnly = true;
            this.Dgv_Info.RowHeadersVisible = false;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Dgv_Info.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.Dgv_Info.RowTemplate.Height = 23;
            this.Dgv_Info.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Dgv_Info.Size = new System.Drawing.Size(697, 125);
            this.Dgv_Info.TabIndex = 41;
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
            // ServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 499);
            this.Controls.Add(this.Dgv_Info);
            this.Controls.Add(this.Btn_GetPubIP);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Txt_port);
            this.Controls.Add(this.Combo_IP);
            this.Controls.Add(this.Rtxt_Log);
            this.Controls.Add(this.Btn_Start);
            this.Name = "ServerForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.ServerForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_Info)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Btn_Start;
        private System.Windows.Forms.RichTextBox Rtxt_Log;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Txt_port;
        private System.Windows.Forms.ComboBox Combo_IP;
        private System.Windows.Forms.Button Btn_GetPubIP;
        private System.Windows.Forms.DataGridView Dgv_Info;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn username;
        private System.Windows.Forms.DataGridViewTextBoxColumn ip;
    }
}

