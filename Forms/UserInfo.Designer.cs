namespace Register.Forms {
    partial class UserInfo {
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
            userPhoto = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            usernameTextBox = new TextBox();
            emailTextBox = new TextBox();
            closeBtn2 = new Button();
            rockpaperscissorsBtn = new Button();
            tictactoeBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)userPhoto).BeginInit();
            SuspendLayout();
            // 
            // closeBtn
            // 
            closeBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            closeBtn.Location = new Point(453, 19);
            closeBtn.Name = "closeBtn";
            closeBtn.Size = new Size(28, 25);
            closeBtn.TabIndex = 0;
            closeBtn.Text = "X";
            closeBtn.UseVisualStyleBackColor = true;
            closeBtn.Click += closeBtn_Click;
            // 
            // userPhoto
            // 
            userPhoto.Location = new Point(13, 63);
            userPhoto.Name = "userPhoto";
            userPhoto.Size = new Size(143, 143);
            userPhoto.SizeMode = PictureBoxSizeMode.StretchImage;
            userPhoto.TabIndex = 1;
            userPhoto.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(173, 76);
            label1.Name = "label1";
            label1.Size = new Size(82, 20);
            label1.TabIndex = 2;
            label1.Text = "Username: ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(172, 112);
            label2.Name = "label2";
            label2.Size = new Size(53, 20);
            label2.TabIndex = 3;
            label2.Text = "Email: ";
            // 
            // usernameTextBox
            // 
            usernameTextBox.Location = new Point(253, 73);
            usernameTextBox.Name = "usernameTextBox";
            usernameTextBox.ReadOnly = true;
            usernameTextBox.Size = new Size(210, 27);
            usernameTextBox.TabIndex = 4;
            // 
            // emailTextBox
            // 
            emailTextBox.Location = new Point(253, 109);
            emailTextBox.Name = "emailTextBox";
            emailTextBox.ReadOnly = true;
            emailTextBox.Size = new Size(210, 27);
            emailTextBox.TabIndex = 5;
            // 
            // closeBtn2
            // 
            closeBtn2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            closeBtn2.Location = new Point(380, 192);
            closeBtn2.Name = "closeBtn2";
            closeBtn2.Size = new Size(83, 25);
            closeBtn2.TabIndex = 6;
            closeBtn2.Text = "Close";
            closeBtn2.UseVisualStyleBackColor = true;
            closeBtn2.Click += closeBtn2_Click;
            // 
            // rockpaperscissorsBtn
            // 
            rockpaperscissorsBtn.Location = new Point(173, 154);
            rockpaperscissorsBtn.Name = "rockpaperscissorsBtn";
            rockpaperscissorsBtn.Size = new Size(181, 26);
            rockpaperscissorsBtn.TabIndex = 7;
            rockpaperscissorsBtn.Text = "Rock Paper Scissors";
            rockpaperscissorsBtn.UseVisualStyleBackColor = true;
            rockpaperscissorsBtn.Click += rockpaperscissorsBtn_Click;
            // 
            // tictactoeBtn
            // 
            tictactoeBtn.Location = new Point(172, 186);
            tictactoeBtn.Name = "tictactoeBtn";
            tictactoeBtn.Size = new Size(182, 26);
            tictactoeBtn.TabIndex = 8;
            tictactoeBtn.Text = "Tic Tac Toe";
            tictactoeBtn.UseVisualStyleBackColor = true;
            tictactoeBtn.Click += tictactoeBtn_Click;
            // 
            // UserInfo
            // 
            ClientSize = new Size(486, 240);
            Controls.Add(tictactoeBtn);
            Controls.Add(rockpaperscissorsBtn);
            Controls.Add(closeBtn2);
            Controls.Add(emailTextBox);
            Controls.Add(usernameTextBox);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(userPhoto);
            Controls.Add(closeBtn);
            Name = "UserInfo";
            Text = "UserInfo";
            ((System.ComponentModel.ISupportInitialize)userPhoto).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button closeBtn;
        private PictureBox userPhoto;
        private Label label1;
        private Label label2;
        private TextBox usernameTextBox;
        private TextBox emailTextBox;
        private Button closeBtn2;
        private Button rockpaperscissorsBtn;
        private Button tictactoeBtn;
    }
}