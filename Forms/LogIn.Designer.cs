using Register.res;

namespace Register
{
    partial class LogIn
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
            loginTextBox = new TextBox();
            passwordTextBox = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            LogupReference = new LinkLabel();
            loginBtn = new Button();
            closeBtn = new Button();
            rememberMe = new CheckBox();
            SuspendLayout();
            // 
            // loginTextBox
            // 
            loginTextBox.Location = new Point(155, 122);
            loginTextBox.Margin = new Padding(3, 4, 3, 4);
            loginTextBox.Name = "loginTextBox";
            loginTextBox.Size = new Size(197, 27);
            loginTextBox.TabIndex = 0;
            // 
            // passwordTextBox
            // 
            passwordTextBox.Location = new Point(155, 185);
            passwordTextBox.Margin = new Padding(3, 4, 3, 4);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.Size = new Size(197, 27);
            passwordTextBox.TabIndex = 1;
            passwordTextBox.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(64, 126);
            label1.Name = "label1";
            label1.Size = new Size(82, 20);
            label1.TabIndex = 2;
            label1.Text = "Username: ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(64, 188);
            label2.Name = "label2";
            label2.Size = new Size(77, 20);
            label2.TabIndex = 3;
            label2.Text = "Password: ";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Location = new Point(142, 408);
            label3.Name = "label3";
            label3.Size = new Size(163, 20);
            label3.TabIndex = 4;
            label3.Text = "Don't have an account?";
            // 
            // LogupReference
            // 
            LogupReference.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            LogupReference.AutoSize = true;
            LogupReference.LinkColor = Color.FromArgb(50, 50, 255);
            LogupReference.Location = new Point(199, 427);
            LogupReference.Name = "LogupReference";
            LogupReference.Size = new Size(57, 20);
            LogupReference.TabIndex = 6;
            LogupReference.TabStop = true;
            LogupReference.Text = "Log Up";
            LogupReference.LinkClicked += LogupReference_LinkClicked;
            // 
            // loginBtn
            // 
            loginBtn.Location = new Point(199, 238);
            loginBtn.Margin = new Padding(3, 4, 3, 4);
            loginBtn.Name = "loginBtn";
            loginBtn.Size = new Size(95, 29);
            loginBtn.TabIndex = 7;
            loginBtn.Text = "Login";
            loginBtn.UseVisualStyleBackColor = true;
            loginBtn.Click += loginBtn_Click;
            // 
            // closeBtn
            // 
            closeBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            closeBtn.Location = new Point(432, 18);
            closeBtn.Margin = new Padding(3, 4, 3, 4);
            closeBtn.Name = "closeBtn";
            closeBtn.Size = new Size(34, 29);
            closeBtn.TabIndex = 8;
            closeBtn.Text = "X";
            closeBtn.UseVisualStyleBackColor = true;
            closeBtn.Click += closeBtn_Click_1;
            // 
            // rememberMe
            // 
            rememberMe.AutoSize = true;
            rememberMe.Location = new Point(62, 241);
            rememberMe.Margin = new Padding(3, 4, 3, 4);
            rememberMe.Name = "rememberMe";
            rememberMe.Size = new Size(129, 24);
            rememberMe.TabIndex = 9;
            rememberMe.Text = "Remember Me";
            rememberMe.UseVisualStyleBackColor = true;
            rememberMe.CheckedChanged += rememberMe_CheckedChanged;
            // 
            // LogIn
            // 
            AllowDrop = true;
            ClientSize = new Size(475, 471);
            Controls.Add(rememberMe);
            Controls.Add(closeBtn);
            Controls.Add(loginBtn);
            Controls.Add(LogupReference);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(passwordTextBox);
            Controls.Add(loginTextBox);
            Margin = new Padding(3, 4, 3, 4);
            Name = "LogIn";
            Padding = new Padding(23, 71, 23, 24);
            Text = "Login";
            FormClosed += LogIn_FormClosed;
            Load += LogIn_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox loginTextBox;
        private TextBox passwordTextBox;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private LinkLabel LogupReference;
        private Button loginBtn;
        private Button closeBtn;
        private CheckBox rememberMe;
    }
}