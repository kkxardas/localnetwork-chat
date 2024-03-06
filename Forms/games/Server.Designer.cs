namespace Register.Forms {
    partial class Server {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            components = new System.ComponentModel.Container();
            label1 = new Label();
            ipTextBox = new TextBox();
            hostBtn = new Button();
            connectBtn = new Button();
            progressBar1 = new ProgressBar();
            closeBtn = new Button();
            progressBarTimer = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(113, 33);
            label1.Name = "label1";
            label1.Size = new Size(25, 17);
            label1.TabIndex = 0;
            label1.Text = "IP: ";
            // 
            // ipTextBox
            // 
            ipTextBox.Location = new Point(144, 30);
            ipTextBox.Name = "ipTextBox";
            ipTextBox.Size = new Size(149, 25);
            ipTextBox.TabIndex = 1;
            // 
            // hostBtn
            // 
            hostBtn.Location = new Point(23, 95);
            hostBtn.Name = "hostBtn";
            hostBtn.Size = new Size(131, 35);
            hostBtn.TabIndex = 2;
            hostBtn.Text = "Host Game";
            hostBtn.UseVisualStyleBackColor = true;
            hostBtn.Click += hostBtn_Click;
            // 
            // connectBtn
            // 
            connectBtn.Location = new Point(160, 95);
            connectBtn.Name = "connectBtn";
            connectBtn.Size = new Size(133, 35);
            connectBtn.TabIndex = 3;
            connectBtn.Text = "Connect";
            connectBtn.UseVisualStyleBackColor = true;
            connectBtn.Click += connectBtn_Click;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(23, 64);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(270, 25);
            progressBar1.TabIndex = 4;
            progressBar1.UseWaitCursor = true;
            // 
            // closeBtn
            // 
            closeBtn.Location = new Point(300, 9);
            closeBtn.Name = "closeBtn";
            closeBtn.Size = new Size(22, 25);
            closeBtn.TabIndex = 5;
            closeBtn.Text = "X";
            closeBtn.UseVisualStyleBackColor = true;
            closeBtn.Click += closeBtn_Click;
            // 
            // progressBarTimer
            // 
            progressBarTimer.Interval = 50;
            progressBarTimer.Tick += progressBarTimer_Tick;
            // 
            // Server
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(329, 153);
            Controls.Add(closeBtn);
            Controls.Add(progressBar1);
            Controls.Add(connectBtn);
            Controls.Add(hostBtn);
            Controls.Add(ipTextBox);
            Controls.Add(label1);
            Name = "Server";
            Text = "Server";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox ipTextBox;
        private Button hostBtn;
        private Button connectBtn;
        private ProgressBar progressBar1;
        private Button closeBtn;
        private System.Windows.Forms.Timer progressBarTimer;
    }
}