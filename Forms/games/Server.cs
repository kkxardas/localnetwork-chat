using DiscordClone.img;
using MetroFramework.Forms;
using Register.Forms.games;
using Register.Forms.tictactoe;

namespace Register.Forms
{
    public partial class Server : MetroForm {
        public string Game;

        private bool forward = true;
        private int stepSize = 1;

        public Server(string UserIp, string Game) {
            InitializeComponent();
            this.Game = Game;
            this.Icon = img.game;
            Appearance.CustomizeForm(this);

            ipTextBox.Text = UserIp;
        }

        private void closeBtn_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void connectBtn_Click(object sender, EventArgs e) {
            if (Game == "tictactoe") {
                Game newGame = new Game(false, ipTextBox.Text);
                Visible = false;
                if (!newGame.IsDisposed)
                    newGame.ShowDialog();
                Visible = true;
            }
            else if (Game == "rockpaperscissors") {
                RockPaperScissors newGame = new RockPaperScissors(false, ipTextBox.Text);
                Visible = false;
                if (!newGame.IsDisposed)
                    newGame.ShowDialog();
                Visible = true;
            }
        }

        private void hostBtn_Click(object sender, EventArgs e) {
            hostBtn.Size = new Size(270, 35);
            hostBtn.Text = "Waiting for the opponent...";
            connectBtn.Enabled = false;
            connectBtn.Visible = false;
            hostBtn.Enabled = false;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 100;
            progressBar1.Value = 0;
            progressBarTimer.Start();
            if (Game == "tictactoe") {
                Task.Run(() => {
                    Game newGame = new Game(true);
                    Visible = false;
                    if (!newGame.IsDisposed)
                        newGame.ShowDialog();
                    Visible = true;
                });
            }
            else if (Game == "rockpaperscissors") {
                Task.Run(() => {
                    RockPaperScissors newGame = new RockPaperScissors(true);
                    Visible = false;
                    if (!newGame.IsDisposed)
                        newGame.ShowDialog();
                    Visible = true;
                });
            }
        }

        private void progressBarTimer_Tick(object sender, EventArgs e) {
            if (forward) {
                progressBar1.Value += stepSize;
                if (progressBar1.Value >= progressBar1.Maximum) {
                    forward = false;
                }
            }
            else {
                progressBar1.Value -= stepSize;
                if (progressBar1.Value <= progressBar1.Minimum) {
                    forward = true;
                }
            }
        }
    }
}
