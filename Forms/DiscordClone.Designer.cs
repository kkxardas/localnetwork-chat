using MetroFramework.Forms;

namespace Register {
    partial class DiscordClone {
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
            components = new System.ComponentModel.Container();
            connectedUsers = new ListBox();
            connectedUsersLabel = new Label();
            chatOutput = new TextBox();
            messageInput = new TextBox();
            sendMsgBtn = new Button();
            messagesLabel = new Label();
            isOnline = new System.Windows.Forms.Timer(components);
            userPhoto = new PictureBox();
            closeBtn = new Button();
            searchUserTextBox = new TextBox();
            searchBtn = new Button();
            adminBtn = new Button();
            chatFontSize = new ComboBox();
            label1 = new Label();
            formColors = new ComboBox();
            Theme = new Label();
            changeColorTextBoxBtn = new Button();
            rgbBtn = new Button();
            rgbSpeed = new TrackBar();
            ((System.ComponentModel.ISupportInitialize)userPhoto).BeginInit();
            ((System.ComponentModel.ISupportInitialize)rgbSpeed).BeginInit();
            SuspendLayout();
            // 
            // connectedUsers
            // 
            connectedUsers.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            connectedUsers.FormattingEnabled = true;
            connectedUsers.ItemHeight = 20;
            connectedUsers.Location = new Point(23, 120);
            connectedUsers.Name = "connectedUsers";
            connectedUsers.Size = new Size(143, 404);
            connectedUsers.TabIndex = 0;
            connectedUsers.DoubleClick += connectedUsers_DoubleClick;
            // 
            // connectedUsersLabel
            // 
            connectedUsersLabel.AutoSize = true;
            connectedUsersLabel.Location = new Point(23, 97);
            connectedUsersLabel.Name = "connectedUsersLabel";
            connectedUsersLabel.Size = new Size(119, 20);
            connectedUsersLabel.TabIndex = 1;
            connectedUsersLabel.Text = "Connected Users";
            // 
            // chatOutput
            // 
            chatOutput.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            chatOutput.Location = new Point(182, 120);
            chatOutput.Multiline = true;
            chatOutput.Name = "chatOutput";
            chatOutput.ReadOnly = true;
            chatOutput.RightToLeft = RightToLeft.No;
            chatOutput.ScrollBars = ScrollBars.Vertical;
            chatOutput.Size = new Size(908, 500);
            chatOutput.TabIndex = 2;
            // 
            // messageInput
            // 
            messageInput.AccessibleDescription = "Enter message...";
            messageInput.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            messageInput.Location = new Point(182, 638);
            messageInput.Multiline = true;
            messageInput.Name = "messageInput";
            messageInput.PlaceholderText = "Enter message...";
            messageInput.Size = new Size(720, 59);
            messageInput.TabIndex = 3;
            messageInput.KeyPress += messageInput_KeyPress;
            // 
            // sendMsgBtn
            // 
            sendMsgBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            sendMsgBtn.Location = new Point(903, 638);
            sendMsgBtn.Name = "sendMsgBtn";
            sendMsgBtn.Size = new Size(197, 59);
            sendMsgBtn.TabIndex = 4;
            sendMsgBtn.Text = "Send Message";
            sendMsgBtn.UseVisualStyleBackColor = true;
            sendMsgBtn.Click += sendMsgBtn_Click;
            // 
            // messagesLabel
            // 
            messagesLabel.AutoSize = true;
            messagesLabel.Location = new Point(182, 97);
            messagesLabel.Name = "messagesLabel";
            messagesLabel.Size = new Size(76, 20);
            messagesLabel.TabIndex = 5;
            messagesLabel.Text = "Messages:";
            // 
            // isOnline
            // 
            isOnline.Interval = 1000;
            isOnline.Tick += isOnline_Tick;
            // 
            // userPhoto
            // 
            userPhoto.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            userPhoto.Cursor = Cursors.Hand;
            userPhoto.Location = new Point(23, 554);
            userPhoto.Name = "userPhoto";
            userPhoto.Size = new Size(143, 143);
            userPhoto.SizeMode = PictureBoxSizeMode.StretchImage;
            userPhoto.TabIndex = 6;
            userPhoto.TabStop = false;
            userPhoto.Click += userPhoto_Click;
            // 
            // closeBtn
            // 
            closeBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            closeBtn.Location = new Point(1066, 11);
            closeBtn.Name = "closeBtn";
            closeBtn.Size = new Size(24, 25);
            closeBtn.TabIndex = 7;
            closeBtn.Text = "X";
            closeBtn.UseVisualStyleBackColor = true;
            closeBtn.Click += closeBtn_Click_1;
            // 
            // searchUserTextBox
            // 
            searchUserTextBox.Location = new Point(23, 25);
            searchUserTextBox.Name = "searchUserTextBox";
            searchUserTextBox.PlaceholderText = "Enter username...";
            searchUserTextBox.Size = new Size(322, 27);
            searchUserTextBox.TabIndex = 8;
            // 
            // searchBtn
            // 
            searchBtn.Location = new Point(351, 25);
            searchBtn.Name = "searchBtn";
            searchBtn.Size = new Size(90, 27);
            searchBtn.TabIndex = 9;
            searchBtn.Text = "Search";
            searchBtn.UseVisualStyleBackColor = true;
            searchBtn.Click += searchBtn_Click;
            // 
            // adminBtn
            // 
            adminBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            adminBtn.Location = new Point(812, 14);
            adminBtn.Name = "adminBtn";
            adminBtn.Size = new Size(103, 25);
            adminBtn.TabIndex = 10;
            adminBtn.Text = "Admin Panel";
            adminBtn.UseVisualStyleBackColor = true;
            adminBtn.Visible = false;
            adminBtn.Click += clearChatBtn_Click;
            // 
            // chatFontSize
            // 
            chatFontSize.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            chatFontSize.FormattingEnabled = true;
            chatFontSize.Location = new Point(996, 81);
            chatFontSize.Name = "chatFontSize";
            chatFontSize.Size = new Size(94, 28);
            chatFontSize.TabIndex = 11;
            chatFontSize.SelectedIndexChanged += chatFontSize_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new Point(921, 84);
            label1.Name = "label1";
            label1.Size = new Size(69, 20);
            label1.TabIndex = 12;
            label1.Text = "Font Size";
            // 
            // formColors
            // 
            formColors.FormattingEnabled = true;
            formColors.Location = new Point(996, 42);
            formColors.Name = "formColors";
            formColors.Size = new Size(94, 28);
            formColors.TabIndex = 13;
            formColors.SelectedIndexChanged += formColors_SelectedIndexChanged;
            // 
            // Theme
            // 
            Theme.AutoSize = true;
            Theme.Location = new Point(921, 45);
            Theme.Name = "Theme";
            Theme.Size = new Size(54, 20);
            Theme.TabIndex = 14;
            Theme.Text = "Theme";
            // 
            // changeColorTextBoxBtn
            // 
            changeColorTextBoxBtn.Location = new Point(812, 45);
            changeColorTextBoxBtn.Name = "changeColorTextBoxBtn";
            changeColorTextBoxBtn.Size = new Size(103, 64);
            changeColorTextBoxBtn.TabIndex = 15;
            changeColorTextBoxBtn.Text = "Change Chat Color";
            changeColorTextBoxBtn.UseVisualStyleBackColor = true;
            changeColorTextBoxBtn.Click += changeColorTextBoxBtn_Click;
            // 
            // rgbBtn
            // 
            rgbBtn.Location = new Point(264, 88);
            rgbBtn.Name = "rgbBtn";
            rgbBtn.Size = new Size(92, 26);
            rgbBtn.TabIndex = 16;
            rgbBtn.Text = "R G B";
            rgbBtn.UseVisualStyleBackColor = true;
            rgbBtn.Click += rgbBtn_Click;
            // 
            // rgbSpeed
            // 
            rgbSpeed.Location = new Point(269, 62);
            rgbSpeed.MaximumSize = new Size(100, 20);
            rgbSpeed.Name = "rgbSpeed";
            rgbSpeed.Size = new Size(87, 20);
            rgbSpeed.TabIndex = 17;
            // 
            // DiscordClone
            // 
            ClientSize = new Size(1113, 726);
            Controls.Add(rgbSpeed);
            Controls.Add(rgbBtn);
            Controls.Add(changeColorTextBoxBtn);
            Controls.Add(Theme);
            Controls.Add(formColors);
            Controls.Add(label1);
            Controls.Add(chatFontSize);
            Controls.Add(adminBtn);
            Controls.Add(searchBtn);
            Controls.Add(searchUserTextBox);
            Controls.Add(closeBtn);
            Controls.Add(userPhoto);
            Controls.Add(messagesLabel);
            Controls.Add(sendMsgBtn);
            Controls.Add(messageInput);
            Controls.Add(chatOutput);
            Controls.Add(connectedUsersLabel);
            Controls.Add(connectedUsers);
            Name = "DiscordClone";
            Text = "DiscordClone";
            FormClosed += DiscordClone_FormClosed;
            ((System.ComponentModel.ISupportInitialize)userPhoto).EndInit();
            ((System.ComponentModel.ISupportInitialize)rgbSpeed).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox connectedUsers;
        private Label connectedUsersLabel;
        private TextBox chatOutput;
        private TextBox messageInput;
        private Button sendMsgBtn;
        private Label messagesLabel;
        private System.Windows.Forms.Timer isOnline;
        private PictureBox userPhoto;
        private Button closeBtn;
        private TextBox searchUserTextBox;
        private Button searchBtn;
        private Button adminBtn;
        private ComboBox chatFontSize;
        private Label label1;
        private ComboBox formColors;
        private Label Theme;
        private Button changeColorTextBoxBtn;
        private Button rgbBtn;
        private TrackBar rgbSpeed;
    }
}