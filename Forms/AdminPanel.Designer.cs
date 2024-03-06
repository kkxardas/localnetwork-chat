namespace Register.Forms {
    partial class AdminPanel {
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
        private void InitializeComponent()
        {
            closeBtn = new Button();
            userTextBox = new TextBox();
            userLabel = new Label();
            banUser = new Button();
            unbanBtn = new Button();
            closeBtn2 = new Button();
            clearChatBtn = new Button();
            SuspendLayout();
            // 
            // closeBtn
            // 
            closeBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            closeBtn.Location = new Point(444, 16);
            closeBtn.Name = "closeBtn";
            closeBtn.Size = new Size(25, 25);
            closeBtn.TabIndex = 0;
            closeBtn.Text = "X";
            closeBtn.UseVisualStyleBackColor = true;
            closeBtn.Click += closeBtn_Click;
            // 
            // userTextBox
            // 
            userTextBox.Location = new Point(23, 74);
            userTextBox.Name = "userTextBox";
            userTextBox.Size = new Size(172, 25);
            userTextBox.TabIndex = 1;
            // 
            // userLabel
            // 
            userLabel.AutoSize = true;
            userLabel.Location = new Point(23, 54);
            userLabel.Name = "userLabel";
            userLabel.Size = new Size(38, 17);
            userLabel.TabIndex = 2;
            userLabel.Text = "User:";
            // 
            // banUser
            // 
            banUser.Location = new Point(201, 73);
            banUser.Name = "banUser";
            banUser.Size = new Size(55, 25);
            banUser.TabIndex = 3;
            banUser.Text = "Ban";
            banUser.UseVisualStyleBackColor = true;
            banUser.Click += banUser_Click;
            // 
            // unbanBtn
            // 
            unbanBtn.Location = new Point(262, 74);
            unbanBtn.Name = "unbanBtn";
            unbanBtn.Size = new Size(62, 25);
            unbanBtn.TabIndex = 4;
            unbanBtn.Text = "Unban";
            unbanBtn.UseVisualStyleBackColor = true;
            unbanBtn.Click += unbanBtn_Click;
            // 
            // closeBtn2
            // 
            closeBtn2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            closeBtn2.Location = new Point(378, 129);
            closeBtn2.Name = "closeBtn2";
            closeBtn2.Size = new Size(78, 25);
            closeBtn2.TabIndex = 5;
            closeBtn2.Text = "Close";
            closeBtn2.UseVisualStyleBackColor = true;
            closeBtn2.Click += closeBtn2_Click;
            // 
            // clearChatBtn
            // 
            clearChatBtn.Location = new Point(23, 129);
            clearChatBtn.Name = "clearChatBtn";
            clearChatBtn.Size = new Size(90, 25);
            clearChatBtn.TabIndex = 6;
            clearChatBtn.Text = "Clear Chat";
            clearChatBtn.UseVisualStyleBackColor = true;
            clearChatBtn.Click += clearChatBtn_Click;
            // 
            // AdminPanel
            // 
            ClientSize = new Size(479, 177);
            Controls.Add(clearChatBtn);
            Controls.Add(closeBtn2);
            Controls.Add(unbanBtn);
            Controls.Add(banUser);
            Controls.Add(userLabel);
            Controls.Add(userTextBox);
            Controls.Add(closeBtn);
            Name = "AdminPanel";
            Text = "AdminPanel";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button closeBtn;
        private TextBox userTextBox;
        private Label userLabel;
        private Button banUser;
        private Button unbanBtn;
        private Button closeBtn2;
        private Button clearChatBtn;
    }
}