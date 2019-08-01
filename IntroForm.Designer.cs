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
            this.Host_RadioBtn = new System.Windows.Forms.RadioButton();
            this.Client_RadioBtn = new System.Windows.Forms.RadioButton();
            this.Client_GroupBox = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Client_IP_TxtBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Client_Port_TxtBox = new System.Windows.Forms.TextBox();
            this.Host_GroupBox = new System.Windows.Forms.GroupBox();
            this.Host_Port_TxtBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Play_Btn = new System.Windows.Forms.Button();
            this.Single_RadBtn = new System.Windows.Forms.RadioButton();
            this.Client_GroupBox.SuspendLayout();
            this.Host_GroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // Host_RadioBtn
            // 
            this.Host_RadioBtn.AutoSize = true;
            this.Host_RadioBtn.Location = new System.Drawing.Point(56, 94);
            this.Host_RadioBtn.Margin = new System.Windows.Forms.Padding(2);
            this.Host_RadioBtn.Name = "Host_RadioBtn";
            this.Host_RadioBtn.Size = new System.Drawing.Size(47, 17);
            this.Host_RadioBtn.TabIndex = 6;
            this.Host_RadioBtn.TabStop = true;
            this.Host_RadioBtn.Text = "Host";
            this.Host_RadioBtn.UseVisualStyleBackColor = true;
            this.Host_RadioBtn.CheckedChanged += new System.EventHandler(this.Host_RadioBtn_CheckedChanged);
            // 
            // Client_RadioBtn
            // 
            this.Client_RadioBtn.AutoSize = true;
            this.Client_RadioBtn.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Client_RadioBtn.Location = new System.Drawing.Point(270, 94);
            this.Client_RadioBtn.Margin = new System.Windows.Forms.Padding(2);
            this.Client_RadioBtn.Name = "Client_RadioBtn";
            this.Client_RadioBtn.Size = new System.Drawing.Size(52, 17);
            this.Client_RadioBtn.TabIndex = 7;
            this.Client_RadioBtn.TabStop = true;
            this.Client_RadioBtn.Text = "Client";
            this.Client_RadioBtn.UseVisualStyleBackColor = true;
            this.Client_RadioBtn.CheckedChanged += new System.EventHandler(this.Client_RadioBtn_CheckedChanged);
            // 
            // Client_GroupBox
            // 
            this.Client_GroupBox.Controls.Add(this.label1);
            this.Client_GroupBox.Controls.Add(this.Client_IP_TxtBox);
            this.Client_GroupBox.Controls.Add(this.label2);
            this.Client_GroupBox.Controls.Add(this.Client_Port_TxtBox);
            this.Client_GroupBox.Location = new System.Drawing.Point(270, 130);
            this.Client_GroupBox.Name = "Client_GroupBox";
            this.Client_GroupBox.Size = new System.Drawing.Size(219, 100);
            this.Client_GroupBox.TabIndex = 8;
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
            // Host_GroupBox
            // 
            this.Host_GroupBox.Controls.Add(this.Host_Port_TxtBox);
            this.Host_GroupBox.Controls.Add(this.label3);
            this.Host_GroupBox.Location = new System.Drawing.Point(56, 130);
            this.Host_GroupBox.Name = "Host_GroupBox";
            this.Host_GroupBox.Size = new System.Drawing.Size(186, 100);
            this.Host_GroupBox.TabIndex = 9;
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
            // Play_Btn
            // 
            this.Play_Btn.Location = new System.Drawing.Point(188, 292);
            this.Play_Btn.Name = "Play_Btn";
            this.Play_Btn.Size = new System.Drawing.Size(134, 30);
            this.Play_Btn.TabIndex = 10;
            this.Play_Btn.Text = "Play";
            this.Play_Btn.UseVisualStyleBackColor = true;
            this.Play_Btn.Click += new System.EventHandler(this.Play_Btn_Click);
            // 
            // Single_RadBtn
            // 
            this.Single_RadBtn.AutoSize = true;
            this.Single_RadBtn.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Single_RadBtn.Location = new System.Drawing.Point(51, 255);
            this.Single_RadBtn.Margin = new System.Windows.Forms.Padding(2);
            this.Single_RadBtn.Name = "Single_RadBtn";
            this.Single_RadBtn.Size = new System.Drawing.Size(83, 17);
            this.Single_RadBtn.TabIndex = 11;
            this.Single_RadBtn.TabStop = true;
            this.Single_RadBtn.Text = "SinglePlayer";
            this.Single_RadBtn.UseVisualStyleBackColor = true;
            this.Single_RadBtn.CheckedChanged += new System.EventHandler(this.Single_RadBtn_CheckedChanged);
            // 
            // IntroForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 360);
            this.Controls.Add(this.Single_RadBtn);
            this.Controls.Add(this.Play_Btn);
            this.Controls.Add(this.Host_GroupBox);
            this.Controls.Add(this.Client_GroupBox);
            this.Controls.Add(this.Client_RadioBtn);
            this.Controls.Add(this.Host_RadioBtn);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "IntroForm";
            this.Text = "IntroForm";
            this.Client_GroupBox.ResumeLayout(false);
            this.Client_GroupBox.PerformLayout();
            this.Host_GroupBox.ResumeLayout(false);
            this.Host_GroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RadioButton Host_RadioBtn;
        private System.Windows.Forms.RadioButton Client_RadioBtn;
        private System.Windows.Forms.GroupBox Client_GroupBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Client_IP_TxtBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Client_Port_TxtBox;
        private System.Windows.Forms.GroupBox Host_GroupBox;
        private System.Windows.Forms.TextBox Host_Port_TxtBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Play_Btn;
        private System.Windows.Forms.RadioButton Single_RadBtn;
    }
}