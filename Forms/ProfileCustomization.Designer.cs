namespace Register.Forms {
    partial class ProfileCustomization {
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
            userPhoto = new PictureBox();
            usernameLabel = new Label();
            emailLabel = new Label();
            pwdLabel = new Label();
            confirmLabel = new Label();
            saveChangesBtn = new Button();
            usernameTextBox = new TextBox();
            emailTextBox = new TextBox();
            passwordTextBox = new TextBox();
            confirmTextBox = new TextBox();
            uploadBtn = new Button();
            closeBtn = new Button();
            closeBtn2 = new Button();
            changePwdBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)userPhoto).BeginInit();
            SuspendLayout();
            // 
            // userPhoto
            // 
            userPhoto.Location = new Point(11, 68);
            userPhoto.Name = "userPhoto";
            userPhoto.Size = new Size(143, 143);
            userPhoto.SizeMode = PictureBoxSizeMode.StretchImage;
            userPhoto.TabIndex = 0;
            userPhoto.TabStop = false;
            // 
            // usernameLabel
            // 
            usernameLabel.AutoSize = true;
            usernameLabel.Location = new Point(161, 93);
            usernameLabel.Name = "usernameLabel";
            usernameLabel.Size = new Size(70, 17);
            usernameLabel.TabIndex = 1;
            usernameLabel.Text = "Username:";
            // 
            // emailLabel
            // 
            emailLabel.AutoSize = true;
            emailLabel.Location = new Point(161, 124);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new Size(42, 17);
            emailLabel.TabIndex = 2;
            emailLabel.Text = "Email:";
            // 
            // pwdLabel
            // 
            pwdLabel.AutoSize = true;
            pwdLabel.Location = new Point(161, 158);
            pwdLabel.Name = "pwdLabel";
            pwdLabel.Size = new Size(71, 17);
            pwdLabel.TabIndex = 3;
            pwdLabel.Text = "Password: ";
            // 
            // confirmLabel
            // 
            confirmLabel.AutoSize = true;
            confirmLabel.Location = new Point(160, 189);
            confirmLabel.Name = "confirmLabel";
            confirmLabel.Size = new Size(117, 17);
            confirmLabel.TabIndex = 4;
            confirmLabel.Text = "Confirm Password:";
            // 
            // saveChangesBtn
            // 
            saveChangesBtn.Location = new Point(366, 233);
            saveChangesBtn.Name = "saveChangesBtn";
            saveChangesBtn.Size = new Size(100, 25);
            saveChangesBtn.TabIndex = 5;
            saveChangesBtn.Text = "Save Changes";
            saveChangesBtn.UseVisualStyleBackColor = true;
            saveChangesBtn.Click += saveChangesBtn_Click;
            // 
            // usernameTextBox
            // 
            usernameTextBox.Location = new Point(284, 90);
            usernameTextBox.Name = "usernameTextBox";
            usernameTextBox.Size = new Size(182, 25);
            usernameTextBox.TabIndex = 6;
            // 
            // emailTextBox
            // 
            emailTextBox.Location = new Point(284, 121);
            emailTextBox.Name = "emailTextBox";
            emailTextBox.Size = new Size(182, 25);
            emailTextBox.TabIndex = 7;
            // 
            // passwordTextBox
            // 
            passwordTextBox.Location = new Point(284, 155);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.Size = new Size(182, 25);
            passwordTextBox.TabIndex = 8;
            passwordTextBox.UseSystemPasswordChar = true;
            // 
            // confirmTextBox
            // 
            confirmTextBox.Location = new Point(284, 186);
            confirmTextBox.Name = "confirmTextBox";
            confirmTextBox.Size = new Size(182, 25);
            confirmTextBox.TabIndex = 9;
            confirmTextBox.UseSystemPasswordChar = true;
            // 
            // uploadBtn
            // 
            uploadBtn.Location = new Point(33, 222);
            uploadBtn.Name = "uploadBtn";
            uploadBtn.Size = new Size(100, 25);
            uploadBtn.TabIndex = 10;
            uploadBtn.Text = "Upload Photo";
            uploadBtn.UseVisualStyleBackColor = true;
            uploadBtn.Click += uploadBtn_Click;
            // 
            // closeBtn
            // 
            closeBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            closeBtn.Location = new Point(439, 14);
            closeBtn.Name = "closeBtn";
            closeBtn.Size = new Size(29, 25);
            closeBtn.TabIndex = 11;
            closeBtn.Text = "X";
            closeBtn.UseVisualStyleBackColor = true;
            closeBtn.Click += closeBtn_Click;
            // 
            // closeBtn2
            // 
            closeBtn2.Location = new Point(279, 232);
            closeBtn2.Name = "closeBtn2";
            closeBtn2.Size = new Size(83, 25);
            closeBtn2.TabIndex = 12;
            closeBtn2.Text = "Close";
            closeBtn2.UseVisualStyleBackColor = true;
            closeBtn2.Click += closeBtn2_Click;
            // 
            // changePwdBtn
            // 
            changePwdBtn.Location = new Point(320, 59);
            changePwdBtn.Name = "changePwdBtn";
            changePwdBtn.Size = new Size(146, 25);
            changePwdBtn.TabIndex = 13;
            changePwdBtn.Text = "Change Password";
            changePwdBtn.UseVisualStyleBackColor = true;
            changePwdBtn.Click += changePwdBtn_Click;
            // 
            // ProfileCustomization
            // 
            ClientSize = new Size(491, 271);
            Controls.Add(changePwdBtn);
            Controls.Add(closeBtn2);
            Controls.Add(closeBtn);
            Controls.Add(uploadBtn);
            Controls.Add(confirmTextBox);
            Controls.Add(passwordTextBox);
            Controls.Add(emailTextBox);
            Controls.Add(usernameTextBox);
            Controls.Add(saveChangesBtn);
            Controls.Add(confirmLabel);
            Controls.Add(pwdLabel);
            Controls.Add(emailLabel);
            Controls.Add(usernameLabel);
            Controls.Add(userPhoto);
            Name = "ProfileCustomization";
            Text = "Profile Customization";
            ((System.ComponentModel.ISupportInitialize)userPhoto).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox userPhoto;
        private Label usernameLabel;
        private Label emailLabel;
        private Label pwdLabel;
        private Label confirmLabel;
        private Button saveChangesBtn;
        private TextBox usernameTextBox;
        private TextBox emailTextBox;
        private TextBox passwordTextBox;
        private TextBox confirmTextBox;
        private Button uploadBtn;
        private Button closeBtn;
        private Button closeBtn2;
        private Button changePwdBtn;
    }
}