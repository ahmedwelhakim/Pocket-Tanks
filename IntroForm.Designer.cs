namespace Game
{
    partial class IntroForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IntroForm));
            this.Multiplayer_groupBox = new System.Windows.Forms.GroupBox();
            this.Client_GroupBox = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Client_IP_TxtBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Client_Port_TxtBox = new System.Windows.Forms.TextBox();
            this.Client_RadioBtn = new System.Windows.Forms.RadioButton();
            this.Host_GroupBox = new System.Windows.Forms.GroupBox();
            this.Host_Port_TxtBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Host_RadioBtn = new System.Windows.Forms.RadioButton();
            this.SinglePlayer_groupBox = new System.Windows.Forms.GroupBox();
            this.spclient_rdbutton1 = new System.Windows.Forms.RadioButton();
            this.Single_RadBtn = new System.Windows.Forms.RadioButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Singleplayer = new System.Windows.Forms.Button();
            this.MultiPlayer = new System.Windows.Forms.Button();
            this.Play_Btn = new System.Windows.Forms.Button();
            this.Multiplayer_groupBox.SuspendLayout();
            this.Client_GroupBox.SuspendLayout();
            this.Host_GroupBox.SuspendLayout();
            this.SinglePlayer_groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Multiplayer_groupBox
            // 
            this.Multiplayer_groupBox.BackColor = System.Drawing.Color.Transparent;
            this.Multiplayer_groupBox.Controls.Add(this.Client_GroupBox);
            this.Multiplayer_groupBox.Controls.Add(this.Client_RadioBtn);
            this.Multiplayer_groupBox.Controls.Add(this.Host_GroupBox);
            this.Multiplayer_groupBox.Controls.Add(this.Host_RadioBtn);
            this.Multiplayer_groupBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Multiplayer_groupBox.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.Multiplayer_groupBox.Location = new System.Drawing.Point(56, 169);
            this.Multiplayer_groupBox.Name = "Multiplayer_groupBox";
            this.Multiplayer_groupBox.Size = new System.Drawing.Size(468, 159);
            this.Multiplayer_groupBox.TabIndex = 15;
            this.Multiplayer_groupBox.TabStop = false;
            this.Multiplayer_groupBox.Text = "Multiplayer";
            this.Multiplayer_groupBox.Visible = false;
            this.Multiplayer_groupBox.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // Client_GroupBox
            // 
            this.Client_GroupBox.Controls.Add(this.label1);
            this.Client_GroupBox.Controls.Add(this.Client_IP_TxtBox);
            this.Client_GroupBox.Controls.Add(this.label2);
            this.Client_GroupBox.Controls.Add(this.Client_Port_TxtBox);
            this.Client_GroupBox.Enabled = false;
            this.Client_GroupBox.Location = new System.Drawing.Point(243, 37);
            this.Client_GroupBox.Name = "Client_GroupBox";
            this.Client_GroupBox.Size = new System.Drawing.Size(219, 100);
            this.Client_GroupBox.TabIndex = 13;
            this.Client_GroupBox.TabStop = false;
            this.Client_GroupBox.Text = "Client";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Host IP address";
            // 
            // Client_IP_TxtBox
            // 
            this.Client_IP_TxtBox.Location = new System.Drawing.Point(102, 23);
            this.Client_IP_TxtBox.Margin = new System.Windows.Forms.Padding(2);
            this.Client_IP_TxtBox.Name = "Client_IP_TxtBox";
            this.Client_IP_TxtBox.Size = new System.Drawing.Size(97, 20);
            this.Client_IP_TxtBox.TabIndex = 2;
            this.Client_IP_TxtBox.Text = "127.0.0.1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 54);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Port";
            // 
            // Client_Port_TxtBox
            // 
            this.Client_Port_TxtBox.Location = new System.Drawing.Point(102, 51);
            this.Client_Port_TxtBox.Margin = new System.Windows.Forms.Padding(2);
            this.Client_Port_TxtBox.Name = "Client_Port_TxtBox";
            this.Client_Port_TxtBox.Size = new System.Drawing.Size(97, 20);
            this.Client_Port_TxtBox.TabIndex = 3;
            this.Client_Port_TxtBox.Text = "7777";
            // 
            // Client_RadioBtn
            // 
            this.Client_RadioBtn.AutoSize = true;
            this.Client_RadioBtn.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Client_RadioBtn.Location = new System.Drawing.Point(243, 18);
            this.Client_RadioBtn.Margin = new System.Windows.Forms.Padding(2);
            this.Client_RadioBtn.Name = "Client_RadioBtn";
            this.Client_RadioBtn.Size = new System.Drawing.Size(52, 17);
            this.Client_RadioBtn.TabIndex = 12;
            this.Client_RadioBtn.Text = "Client";
            this.Client_RadioBtn.UseVisualStyleBackColor = true;
            this.Client_RadioBtn.CheckedChanged += new System.EventHandler(this.Client_RadioBtn_CheckedChanged_1);
            // 
            // Host_GroupBox
            // 
            this.Host_GroupBox.Controls.Add(this.Host_Port_TxtBox);
            this.Host_GroupBox.Controls.Add(this.label3);
            this.Host_GroupBox.Location = new System.Drawing.Point(17, 37);
            this.Host_GroupBox.Name = "Host_GroupBox";
            this.Host_GroupBox.Size = new System.Drawing.Size(186, 100);
            this.Host_GroupBox.TabIndex = 11;
            this.Host_GroupBox.TabStop = false;
            this.Host_GroupBox.Text = "Host";
            // 
            // Host_Port_TxtBox
            // 
            this.Host_Port_TxtBox.Location = new System.Drawing.Point(70, 30);
            this.Host_Port_TxtBox.Margin = new System.Windows.Forms.Padding(2);
            this.Host_Port_TxtBox.Name = "Host_Port_TxtBox";
            this.Host_Port_TxtBox.Size = new System.Drawing.Size(97, 20);
            this.Host_Port_TxtBox.TabIndex = 7;
            this.Host_Port_TxtBox.Text = "7777";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 30);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Port";
            // 
            // Host_RadioBtn
            // 
            this.Host_RadioBtn.AutoSize = true;
            this.Host_RadioBtn.Checked = true;
            this.Host_RadioBtn.Location = new System.Drawing.Point(17, 18);
            this.Host_RadioBtn.Margin = new System.Windows.Forms.Padding(2);
            this.Host_RadioBtn.Name = "Host_RadioBtn";
            this.Host_RadioBtn.Size = new System.Drawing.Size(47, 17);
            this.Host_RadioBtn.TabIndex = 10;
            this.Host_RadioBtn.TabStop = true;
            this.Host_RadioBtn.Text = "Host";
            this.Host_RadioBtn.UseVisualStyleBackColor = true;
            this.Host_RadioBtn.CheckedChanged += new System.EventHandler(this.Host_RadioBtn_CheckedChanged_1);
            // 
            // SinglePlayer_groupBox
            // 
            this.SinglePlayer_groupBox.BackColor = System.Drawing.Color.Transparent;
            this.SinglePlayer_groupBox.Controls.Add(this.spclient_rdbutton1);
            this.SinglePlayer_groupBox.Controls.Add(this.Single_RadBtn);
            this.SinglePlayer_groupBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SinglePlayer_groupBox.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.SinglePlayer_groupBox.Location = new System.Drawing.Point(56, 173);
            this.SinglePlayer_groupBox.Name = "SinglePlayer_groupBox";
            this.SinglePlayer_groupBox.Size = new System.Drawing.Size(468, 100);
            this.SinglePlayer_groupBox.TabIndex = 16;
            this.SinglePlayer_groupBox.TabStop = false;
            this.SinglePlayer_groupBox.Text = "SinglePlayer";
            this.SinglePlayer_groupBox.Visible = false;
            this.SinglePlayer_groupBox.Enter += new System.EventHandler(this.Singleplayer_Click);
            // 
            // spclient_rdbutton1
            // 
            this.spclient_rdbutton1.AutoSize = true;
            this.spclient_rdbutton1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.spclient_rdbutton1.Location = new System.Drawing.Point(319, 50);
            this.spclient_rdbutton1.Margin = new System.Windows.Forms.Padding(2);
            this.spclient_rdbutton1.Name = "spclient_rdbutton1";
            this.spclient_rdbutton1.Size = new System.Drawing.Size(66, 17);
            this.spclient_rdbutton1.TabIndex = 14;
            this.spclient_rdbutton1.TabStop = true;
            this.spclient_rdbutton1.Text = "sp Client";
            this.spclient_rdbutton1.UseVisualStyleBackColor = true;
            this.spclient_rdbutton1.CheckedChanged += new System.EventHandler(this.spclient_rdbutton1_CheckedChanged_1);
            // 
            // Single_RadBtn
            // 
            this.Single_RadBtn.AutoSize = true;
            this.Single_RadBtn.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Single_RadBtn.Location = new System.Drawing.Point(26, 50);
            this.Single_RadBtn.Margin = new System.Windows.Forms.Padding(2);
            this.Single_RadBtn.Name = "Single_RadBtn";
            this.Single_RadBtn.Size = new System.Drawing.Size(83, 17);
            this.Single_RadBtn.TabIndex = 13;
            this.Single_RadBtn.TabStop = true;
            this.Single_RadBtn.Text = "SinglePlayer";
            this.Single_RadBtn.UseVisualStyleBackColor = true;
            this.Single_RadBtn.CheckedChanged += new System.EventHandler(this.Single_RadBtn_CheckedChanged_1);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(33, 21);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(503, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            // 
            // Singleplayer
            // 
            this.Singleplayer.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Singleplayer.BackgroundImage")));
            this.Singleplayer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Singleplayer.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.Singleplayer.FlatAppearance.BorderSize = 0;
            this.Singleplayer.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.Singleplayer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Singleplayer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Singleplayer.Location = new System.Drawing.Point(307, 91);
            this.Singleplayer.Name = "Singleplayer";
            this.Singleplayer.Size = new System.Drawing.Size(229, 49);
            this.Singleplayer.TabIndex = 14;
            this.Singleplayer.UseVisualStyleBackColor = true;
            this.Singleplayer.Click += new System.EventHandler(this.Singleplayer_Click);
            // 
            // MultiPlayer
            // 
            this.MultiPlayer.BackColor = System.Drawing.Color.Transparent;
            this.MultiPlayer.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("MultiPlayer.BackgroundImage")));
            this.MultiPlayer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.MultiPlayer.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.MultiPlayer.FlatAppearance.BorderSize = 0;
            this.MultiPlayer.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.MultiPlayer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.MultiPlayer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MultiPlayer.Location = new System.Drawing.Point(33, 91);
            this.MultiPlayer.Name = "MultiPlayer";
            this.MultiPlayer.Size = new System.Drawing.Size(222, 49);
            this.MultiPlayer.TabIndex = 13;
            this.MultiPlayer.UseVisualStyleBackColor = false;
            this.MultiPlayer.Click += new System.EventHandler(this.button1_Click);
            // 
            // Play_Btn
            // 
            this.Play_Btn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Play_Btn.BackgroundImage")));
            this.Play_Btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Play_Btn.Enabled = false;
            this.Play_Btn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.Play_Btn.FlatAppearance.BorderSize = 0;
            this.Play_Btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.Play_Btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Play_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Play_Btn.Location = new System.Drawing.Point(205, 390);
            this.Play_Btn.Name = "Play_Btn";
            this.Play_Btn.Size = new System.Drawing.Size(114, 41);
            this.Play_Btn.TabIndex = 10;
            this.Play_Btn.UseVisualStyleBackColor = true;
            this.Play_Btn.Click += new System.EventHandler(this.Play_Btn_Click);
            // 
            // IntroForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SeaGreen;
            this.ClientSize = new System.Drawing.Size(567, 454);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.SinglePlayer_groupBox);
            this.Controls.Add(this.Singleplayer);
            this.Controls.Add(this.MultiPlayer);
            this.Controls.Add(this.Play_Btn);
            this.Controls.Add(this.Multiplayer_groupBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "IntroForm";
            this.Text = "IntroForm";
            this.Load += new System.EventHandler(this.IntroForm_Load);
            this.Multiplayer_groupBox.ResumeLayout(false);
            this.Multiplayer_groupBox.PerformLayout();
            this.Client_GroupBox.ResumeLayout(false);
            this.Client_GroupBox.PerformLayout();
            this.Host_GroupBox.ResumeLayout(false);
            this.Host_GroupBox.PerformLayout();
            this.SinglePlayer_groupBox.ResumeLayout(false);
            this.SinglePlayer_groupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button Play_Btn;
        private System.Windows.Forms.Button MultiPlayer;
        private System.Windows.Forms.Button Singleplayer;
        private System.Windows.Forms.GroupBox Multiplayer_groupBox;
        private System.Windows.Forms.GroupBox Client_GroupBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Client_IP_TxtBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Client_Port_TxtBox;
        private System.Windows.Forms.RadioButton Client_RadioBtn;
        private System.Windows.Forms.GroupBox Host_GroupBox;
        private System.Windows.Forms.TextBox Host_Port_TxtBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton Host_RadioBtn;
        private System.Windows.Forms.GroupBox SinglePlayer_groupBox;
        private System.Windows.Forms.RadioButton spclient_rdbutton1;
        private System.Windows.Forms.RadioButton Single_RadBtn;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}