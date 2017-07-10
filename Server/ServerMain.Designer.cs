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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServerMain));
            this.Btn_start = new System.Windows.Forms.Button();
            this.Rtxt_chat = new System.Windows.Forms.RichTextBox();
            this.dgv_info = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.username = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ip = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.connectToServerCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disconnectDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitQToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.settingSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_info)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Btn_start
            // 
            this.Btn_start.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.Btn_start.Location = new System.Drawing.Point(676, 12);
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
            this.Rtxt_chat.Location = new System.Drawing.Point(12, 46);
            this.Rtxt_chat.Name = "Rtxt_chat";
            this.Rtxt_chat.ReadOnly = true;
            this.Rtxt_chat.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.Rtxt_chat.Size = new System.Drawing.Size(760, 334);
            this.Rtxt_chat.TabIndex = 27;
            this.Rtxt_chat.Text = "";
            this.Rtxt_chat.TextChanged += new System.EventHandler(this.Rtxt_chat_TextChanged);
            // 
            // dgv_info
            // 
            this.dgv_info.AllowUserToAddRows = false;
            this.dgv_info.AllowUserToDeleteRows = false;
            this.dgv_info.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgv_info.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgv_info.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_info.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_info.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_info.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.username,
            this.ip});
            this.dgv_info.Location = new System.Drawing.Point(12, 386);
            this.dgv_info.Name = "dgv_info";
            this.dgv_info.ReadOnly = true;
            this.dgv_info.RowHeadersVisible = false;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgv_info.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_info.RowTemplate.Height = 23;
            this.dgv_info.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_info.Size = new System.Drawing.Size(760, 150);
            this.dgv_info.TabIndex = 29;
            // 
            // id
            // 
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            // 
            // username
            // 
            this.username.HeaderText = "Username";
            this.username.Name = "username";
            this.username.ReadOnly = true;
            // 
            // ip
            // 
            this.ip.HeaderText = "IP";
            this.ip.Name = "ip";
            this.ip.ReadOnly = true;
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSplitButton1,
            this.toolStripDropDownButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip1.Size = new System.Drawing.Size(784, 25);
            this.toolStrip1.TabIndex = 30;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripSplitButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectToServerCToolStripMenuItem,
            this.disconnectDToolStripMenuItem,
            this.quitQToolStripMenuItem});
            this.toolStripSplitButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton1.Image")));
            this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.ShowDropDownArrow = false;
            this.toolStripSplitButton1.Size = new System.Drawing.Size(31, 22);
            this.toolStripSplitButton1.Text = "&File";
            // 
            // connectToServerCToolStripMenuItem
            // 
            this.connectToServerCToolStripMenuItem.Name = "connectToServerCToolStripMenuItem";
            this.connectToServerCToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.connectToServerCToolStripMenuItem.Text = "&Connect to server";
            this.connectToServerCToolStripMenuItem.Click += new System.EventHandler(this.ConnectToServer_Click);
            // 
            // disconnectDToolStripMenuItem
            // 
            this.disconnectDToolStripMenuItem.Name = "disconnectDToolStripMenuItem";
            this.disconnectDToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.disconnectDToolStripMenuItem.Text = "&Disconnect";
            // 
            // quitQToolStripMenuItem
            // 
            this.quitQToolStripMenuItem.Name = "quitQToolStripMenuItem";
            this.quitQToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.quitQToolStripMenuItem.Text = "&Quit";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingSToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.ShowDropDownArrow = false;
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(34, 22);
            this.toolStripDropDownButton1.Text = "&Edit";
            // 
            // settingSToolStripMenuItem
            // 
            this.settingSToolStripMenuItem.Name = "settingSToolStripMenuItem";
            this.settingSToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.settingSToolStripMenuItem.Text = "&Setting";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 539);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(784, 22);
            this.statusStrip1.TabIndex = 31;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // ServerMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.dgv_info);
            this.Controls.Add(this.Rtxt_chat);
            this.Controls.Add(this.Btn_start);
            this.MinimizeBox = false;
            this.Name = "ServerMain";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.ServerMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_info)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button Btn_start;
        private System.Windows.Forms.RichTextBox Rtxt_chat;
        private System.Windows.Forms.DataGridView dgv_info;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn username;
        private System.Windows.Forms.DataGridViewTextBoxColumn ip;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripSplitButton1;
        private System.Windows.Forms.ToolStripMenuItem connectToServerCToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitQToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disconnectDToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem settingSToolStripMenuItem;
    }
}

