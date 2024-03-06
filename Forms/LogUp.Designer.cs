namespace Register
{
    partial class LogUp
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            loginTextBox = new TextBox();
            passwordTextBox = new TextBox();
            logupBtn = new Button();
            usernameLabel = new Label();
            passwordLabel = new Label();
            label3 = new Label();
            loginReference = new LinkLabel();
            emailTextBox = new TextBox();
            emailLabel = new Label();
            confirmCodeGenerator = new System.Windows.Forms.Timer(components);
            confirmCodeTextBox = new TextBox();
            confirmCodeLabel = new Label();
            sendVerificationBtn = new Button();
            verifyBtn = new Button();
            uploadPhotoBtn = new Button();
            userPhoto = new PictureBox();
            closeBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)userPhoto).BeginInit();
            SuspendLayout();
            // 
            // loginTextBox
            // 
            loginTextBox.Location = new Point(608, 259);
            loginTextBox.Name = "loginTextBox";
            loginTextBox.Size = new Size(173, 27);
            loginTextBox.TabIndex = 0;
            // 
            // passwordTextBox
            // 
            passwordTextBox.Location = new Point(608, 316);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.Size = new Size(173, 27);
            passwordTextBox.TabIndex = 1;
            passwordTextBox.UseSystemPasswordChar = true;
            // 
            // logupBtn
            // 
            logupBtn.Location = new Point(640, 357);
            logupBtn.Name = "logupBtn";
            logupBtn.Size = new Size(83, 25);
            logupBtn.TabIndex = 2;
            logupBtn.Text = "Log Up";
            logupBtn.UseVisualStyleBackColor = true;
            logupBtn.Click += logupBtn_Click;
            // 
            // usernameLabel
            // 
            usernameLabel.AutoSize = true;
            usernameLabel.Location = new Point(521, 262);
            usernameLabel.Name = "usernameLabel";
            usernameLabel.Size = new Size(78, 20);
            usernameLabel.TabIndex = 3;
            usernameLabel.Text = "Username:";
            // 
            // passwordLabel
            // 
            passwordLabel.AutoSize = true;
            passwordLabel.Location = new Point(531, 319);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new Size(77, 20);
            passwordLabel.TabIndex = 4;
            passwordLabel.Text = "Password: ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(102, 334);
            label3.Name = "label3";
            label3.Size = new Size(178, 20);
            label3.TabIndex = 5;
            label3.Text = "Already have an account?";
            // 
            // loginReference
            // 
            loginReference.AutoSize = true;
            loginReference.Location = new Point(142, 357);
            loginReference.Name = "loginReference";
            loginReference.Size = new Size(50, 20);
            loginReference.TabIndex = 6;
            loginReference.TabStop = true;
            loginReference.Text = "Log In";
            loginReference.LinkClicked += loginReference_LinkClicked;
            // 
            // emailTextBox
            // 
            emailTextBox.Location = new Point(102, 99);
            emailTextBox.Name = "emailTextBox";
            emailTextBox.Size = new Size(218, 27);
            emailTextBox.TabIndex = 8;
            // 
            // emailLabel
            // 
            emailLabel.AutoSize = true;
            emailLabel.Location = new Point(50, 102);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new Size(53, 20);
            emailLabel.TabIndex = 9;
            emailLabel.Text = "Email: ";
            // 
            // confirmCodeGenerator
            // 
            confirmCodeGenerator.Interval = 200;
            confirmCodeGenerator.Tick += confirmCodeGenerator_Tick;
            // 
            // confirmCodeTextBox
            // 
            confirmCodeTextBox.Location = new Point(580, 126);
            confirmCodeTextBox.Name = "confirmCodeTextBox";
            confirmCodeTextBox.Size = new Size(68, 27);
            confirmCodeTextBox.TabIndex = 10;
            // 
            // confirmCodeLabel
            // 
            confirmCodeLabel.AutoSize = true;
            confirmCodeLabel.Location = new Point(451, 130);
            confirmCodeLabel.Name = "confirmCodeLabel";
            confirmCodeLabel.Size = new Size(140, 20);
            confirmCodeLabel.TabIndex = 11;
            confirmCodeLabel.Text = "Confirmation code: ";
            // 
            // sendVerificationBtn
            // 
            sendVerificationBtn.Location = new Point(102, 130);
            sendVerificationBtn.Name = "sendVerificationBtn";
            sendVerificationBtn.Size = new Size(218, 25);
            sendVerificationBtn.TabIndex = 12;
            sendVerificationBtn.Text = "Send Code";
            sendVerificationBtn.UseVisualStyleBackColor = true;
            sendVerificationBtn.Click += sendVerificationBtn_Click;
            // 
            // verifyBtn
            // 
            verifyBtn.Location = new Point(489, 156);
            verifyBtn.Name = "verifyBtn";
            verifyBtn.Size = new Size(83, 25);
            verifyBtn.TabIndex = 13;
            verifyBtn.Text = "Verify";
            verifyBtn.UseVisualStyleBackColor = true;
            verifyBtn.Click += verifyBtn_Click;
            // 
            // uploadPhotoBtn
            // 
            uploadPhotoBtn.Location = new Point(286, 329);
            uploadPhotoBtn.Name = "uploadPhotoBtn";
            uploadPhotoBtn.Size = new Size(100, 25);
            uploadPhotoBtn.TabIndex = 14;
            uploadPhotoBtn.Text = "Upload Photo";
            uploadPhotoBtn.UseVisualStyleBackColor = true;
            uploadPhotoBtn.Click += uploadPhotoBtn_Click;
            // 
            // userPhoto
            // 
            userPhoto.Location = new Point(290, 220);
            userPhoto.Name = "userPhoto";
            userPhoto.Size = new Size(100, 100);
            userPhoto.SizeMode = PictureBoxSizeMode.StretchImage;
            userPhoto.TabIndex = 15;
            userPhoto.TabStop = false;
            // 
            // closeBtn
            // 
            closeBtn.Location = new Point(373, 14);
            closeBtn.Name = "closeBtn";
            closeBtn.Size = new Size(27, 25);
            closeBtn.TabIndex = 16;
            closeBtn.Text = "X";
            closeBtn.UseVisualStyleBackColor = true;
            closeBtn.Click += closeBtn_Click_1;
            // 
            // LogUp
            // 
            ClientSize = new Size(809, 400);
            Controls.Add(closeBtn);
            Controls.Add(userPhoto);
            Controls.Add(uploadPhotoBtn);
            Controls.Add(verifyBtn);
            Controls.Add(sendVerificationBtn);
            Controls.Add(confirmCodeLabel);
            Controls.Add(confirmCodeTextBox);
            Controls.Add(emailLabel);
            Controls.Add(emailTextBox);
            Controls.Add(loginReference);
            Controls.Add(label3);
            Controls.Add(passwordLabel);
            Controls.Add(usernameLabel);
            Controls.Add(logupBtn);
            Controls.Add(passwordTextBox);
            Controls.Add(loginTextBox);
            Name = "LogUp";
            Text = "Register";
            FormClosed += LogUp_FormClosed;
            ((System.ComponentModel.ISupportInitialize)userPhoto).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox loginTextBox;
        private TextBox passwordTextBox;
        private Button logupBtn;
        private Label usernameLabel;
        private Label passwordLabel;
        private Label label3;
        private LinkLabel loginReference;
        private TextBox emailTextBox;
        private Label emailLabel;
        private System.Windows.Forms.Timer confirmCodeGenerator;
        private TextBox confirmCodeTextBox;
        private Label confirmCodeLabel;
        private Button sendVerificationBtn;
        private Button verifyBtn;
        private Button uploadPhotoBtn;
        private PictureBox userPhoto;
        private Button closeBtn;
    }
}
