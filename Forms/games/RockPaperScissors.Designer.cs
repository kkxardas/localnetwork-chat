

using DiscordClone.img;

namespace Register.Forms.games {
    partial class RockPaperScissors {
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
            rockBtn = new Button();
            paperBtn = new Button();
            scissorsBtn = new Button();
            rockEnemie = new Button();
            paperEnemie = new Button();
            scissorsEnemie = new Button();
            closeBtn = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // rockBtn
            // 
            rockBtn.BackgroundImage = GameImg.rock;
            rockBtn.BackgroundImageLayout = ImageLayout.Stretch;
            rockBtn.Location = new Point(23, 242);
            rockBtn.Name = "rockBtn";
            rockBtn.Size = new Size(112, 112);
            rockBtn.TabIndex = 0;
            rockBtn.UseVisualStyleBackColor = true;
            rockBtn.Click += rockBtn_Click;
            // 
            // paperBtn
            // 
            paperBtn.BackgroundImage = GameImg.paper;
            paperBtn.BackgroundImageLayout = ImageLayout.Stretch;
            paperBtn.Location = new Point(153, 242);
            paperBtn.Name = "paperBtn";
            paperBtn.Size = new Size(112, 112);
            paperBtn.TabIndex = 1;
            paperBtn.UseVisualStyleBackColor = true;
            paperBtn.Click += paperBtn_Click;
            // 
            // scissorsBtn
            // 
            scissorsBtn.BackgroundImage = GameImg.scissors;
            scissorsBtn.BackgroundImageLayout = ImageLayout.Stretch;
            scissorsBtn.Location = new Point(283, 242);
            scissorsBtn.Name = "scissorsBtn";
            scissorsBtn.Size = new Size(112, 112);
            scissorsBtn.TabIndex = 2;
            scissorsBtn.UseVisualStyleBackColor = true;
            scissorsBtn.Click += scissorsBtn_Click;
            // 
            // rockEnemie
            // 
            rockEnemie.BackgroundImage = GameImg.rock;
            rockEnemie.BackgroundImageLayout = ImageLayout.Stretch;
            rockEnemie.Enabled = false;
            rockEnemie.Location = new Point(23, 63);
            rockEnemie.Name = "rockEnemie";
            rockEnemie.Size = new Size(112, 112);
            rockEnemie.TabIndex = 3;
            rockEnemie.UseVisualStyleBackColor = true;
            // 
            // paperEnemie
            // 
            paperEnemie.BackgroundImage = GameImg.paper;
            paperEnemie.BackgroundImageLayout = ImageLayout.Stretch;
            paperEnemie.Enabled = false;
            paperEnemie.Location = new Point(153, 63);
            paperEnemie.Name = "paperEnemie";
            paperEnemie.Size = new Size(112, 112);
            paperEnemie.TabIndex = 4;
            paperEnemie.UseVisualStyleBackColor = true;
            // 
            // scissorsEnemie
            // 
            scissorsEnemie.BackColor = Color.White;
            scissorsEnemie.BackgroundImage = GameImg.scissors;
            scissorsEnemie.BackgroundImageLayout = ImageLayout.Stretch;
            scissorsEnemie.Enabled = false;
            scissorsEnemie.Location = new Point(283, 63);
            scissorsEnemie.Name = "scissorsEnemie";
            scissorsEnemie.Size = new Size(112, 112);
            scissorsEnemie.TabIndex = 5;
            scissorsEnemie.UseVisualStyleBackColor = false;
            // 
            // closeBtn
            // 
            closeBtn.Location = new Point(393, 13);
            closeBtn.Name = "closeBtn";
            closeBtn.Size = new Size(29, 25);
            closeBtn.TabIndex = 6;
            closeBtn.Text = "X";
            closeBtn.UseVisualStyleBackColor = true;
            closeBtn.Click += closeBtn_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 23.7735844F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(126, 184);
            label1.Name = "label1";
            label1.Size = new Size(179, 47);
            label1.TabIndex = 7;
            label1.Text = "Your Turn!";
            // 
            // RockPaperScissors
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(430, 387);
            Controls.Add(label1);
            Controls.Add(closeBtn);
            Controls.Add(scissorsEnemie);
            Controls.Add(paperEnemie);
            Controls.Add(rockEnemie);
            Controls.Add(scissorsBtn);
            Controls.Add(paperBtn);
            Controls.Add(rockBtn);
            Name = "RockPaperScissors";
            Text = "RockPaperScissors";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button rockBtn;
        private Button paperBtn;
        private Button scissorsBtn;
        private Button rockEnemie;
        private Button paperEnemie;
        private Button scissorsEnemie;
        private Button closeBtn;
        private Label label1;
    }
}