namespace VideoSyncSpace
{
    partial class MainGUI
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainGUI));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textbox_ServerIP = new System.Windows.Forms.TextBox();
            this.button_Connect = new System.Windows.Forms.Button();
            this.mainTextBox = new System.Windows.Forms.RichTextBox();
            this.serverButton = new System.Windows.Forms.Button();
            this.clientButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.processName_TextBox = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button_State = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.textbox_ServerIP);
            this.groupBox2.Controls.Add(this.button_Connect);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox2.Location = new System.Drawing.Point(114, 63);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(175, 59);
            this.groupBox2.TabIndex = 55;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "3. 對方Server IP";
            // 
            // textbox_ServerIP
            // 
            this.textbox_ServerIP.Location = new System.Drawing.Point(7, 21);
            this.textbox_ServerIP.Name = "textbox_ServerIP";
            this.textbox_ServerIP.Size = new System.Drawing.Size(93, 22);
            this.textbox_ServerIP.TabIndex = 61;
            this.textbox_ServerIP.Text = "220.133.211.211";
            // 
            // button_Connect
            // 
            this.button_Connect.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_Connect.Location = new System.Drawing.Point(105, 21);
            this.button_Connect.Margin = new System.Windows.Forms.Padding(2);
            this.button_Connect.Name = "button_Connect";
            this.button_Connect.Size = new System.Drawing.Size(51, 28);
            this.button_Connect.TabIndex = 60;
            this.button_Connect.Text = "連線";
            this.button_Connect.UseVisualStyleBackColor = true;
            this.button_Connect.Click += new System.EventHandler(this.button_Connect_Click);
            // 
            // mainTextBox
            // 
            this.mainTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.mainTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.mainTextBox.DetectUrls = false;
            this.mainTextBox.ForeColor = System.Drawing.Color.Lime;
            this.mainTextBox.Location = new System.Drawing.Point(162, 313);
            this.mainTextBox.Name = "mainTextBox";
            this.mainTextBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mainTextBox.Size = new System.Drawing.Size(472, 105);
            this.mainTextBox.TabIndex = 57;
            this.mainTextBox.Text = "";
            // 
            // serverButton
            // 
            this.serverButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.serverButton.Location = new System.Drawing.Point(17, 29);
            this.serverButton.Margin = new System.Windows.Forms.Padding(2);
            this.serverButton.Name = "serverButton";
            this.serverButton.Size = new System.Drawing.Size(80, 29);
            this.serverButton.TabIndex = 59;
            this.serverButton.Text = "Server Mode";
            this.serverButton.UseVisualStyleBackColor = true;
            this.serverButton.Click += new System.EventHandler(this.serverButton_Click);
            // 
            // clientButton
            // 
            this.clientButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.clientButton.Location = new System.Drawing.Point(17, 77);
            this.clientButton.Margin = new System.Windows.Forms.Padding(2);
            this.clientButton.Name = "clientButton";
            this.clientButton.Size = new System.Drawing.Size(80, 32);
            this.clientButton.TabIndex = 60;
            this.clientButton.Text = "Client Mode";
            this.clientButton.UseVisualStyleBackColor = true;
            this.clientButton.Click += new System.EventHandler(this.clientButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.processName_TextBox);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox1.Location = new System.Drawing.Point(196, 76);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(163, 59);
            this.groupBox1.TabIndex = 62;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "1. 撥放器\"程序名稱\"";
            // 
            // processName_TextBox
            // 
            this.processName_TextBox.Location = new System.Drawing.Point(17, 21);
            this.processName_TextBox.Name = "processName_TextBox";
            this.processName_TextBox.Size = new System.Drawing.Size(117, 22);
            this.processName_TextBox.TabIndex = 61;
            this.processName_TextBox.Text = "PotPlayerMini";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.serverButton);
            this.groupBox3.Controls.Add(this.clientButton);
            this.groupBox3.Controls.Add(this.groupBox2);
            this.groupBox3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox3.Location = new System.Drawing.Point(280, 175);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(289, 122);
            this.groupBox3.TabIndex = 63;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "2. 模式選擇";
            // 
            // button_State
            // 
            this.button_State.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button_State.FlatAppearance.BorderSize = 0;
            this.button_State.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_State.Location = new System.Drawing.Point(162, 215);
            this.button_State.Name = "button_State";
            this.button_State.Size = new System.Drawing.Size(69, 46);
            this.button_State.TabIndex = 64;
            this.button_State.Text = "P";
            this.button_State.UseVisualStyleBackColor = false;
            // 
            // MainGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(634, 522);
            this.Controls.Add(this.button_State);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.mainTextBox);
            this.Name = "MainGUI";
            this.Text = " --VideoSync--     by Freeman";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        //private System.Windows.Forms.TextBox txtSaveName;
        private System.Windows.Forms.RichTextBox mainTextBox;
        private System.Windows.Forms.Button serverButton;
        private System.Windows.Forms.Button clientButton;
        private System.Windows.Forms.Button button_Connect;
        private System.Windows.Forms.TextBox textbox_ServerIP;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox processName_TextBox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button_State;
    } 
}

