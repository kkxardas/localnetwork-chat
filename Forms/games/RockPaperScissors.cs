using DiscordClone.img;
using MetroFramework.Forms;
using Register.res;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Register.Forms.games
{
    public partial class RockPaperScissors : MetroForm {
        Socket sock;
        BackgroundWorker MessageReceiver = new BackgroundWorker();
        TcpListener server = null;
        TcpClient client;

        public string choose = null;
        public string enemieChoose = null;

        public RockPaperScissors(bool isHost, string ip = null) {
            InitializeComponent();
            MessageReceiver.DoWork += MessageReceiver_DoWork;
            CheckForIllegalCrossThreadCalls = false;

            this.Icon = img.game;

            if (isHost) {
                server = new TcpListener(System.Net.IPAddress.Any, 5732);
                server.Start();
                sock = server.AcceptSocket();
            }
            else {
                try {
                    client = new TcpClient(ip, 5732);
                    sock = client.Client;
                    MessageReceiver.RunWorkerAsync();
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                    Close();
                }
            }
            Appearance.CustomizeForm(this);
        }

        private void MessageReceiver_DoWork(object sender, DoWorkEventArgs e) {
            if (CheckState())
                return;
            FreezeBoard();
            label1.Text = "Opponent's Turn!";
            ReceiveMove();
            label1.Text = "Your Turn!";
            if (!CheckState())
                UnfreezeBoard();
        }
        private void YouWon() {
            label1.ForeColor = Color.Green;
            label1.Text = "You Won!";
            FreezeBoard();
        }
        private void YouLost() {
            label1.ForeColor = Color.Red;
            label1.Text = "Loser!";
            FreezeBoard();
        }

        private void FreezeBoard() {
            foreach (var control in this.Controls) {
                if (control is Button) {
                    Button btn = control as Button;
                    if (btn.Name != "closeBtn") btn.Enabled = false;
                }
            }
        }
        private void UnfreezeBoard() {
            foreach (var control in this.Controls) {
                if (control is Button) {
                    Button btn = control as Button;
                    if (btn.Text == "") btn.Enabled = true;
                }
            }
        }

        private bool CheckState() {
            if (choose == "rock" && enemieChoose == "paper") {
                YouLost();
                paperEnemie.BackColor = Color.Red;
                return true;
            }
            else if (choose == "rock" && enemieChoose == "scissors") {
                scissorsEnemie.BackColor = Color.Red;
                YouWon();
                return true;
            }
            else if (choose == "paper" && enemieChoose == "scissors") {
                scissorsEnemie.BackColor = Color.Red;
                YouLost();
                return true;
            }
            else if (choose == "paper" && enemieChoose == "rock") {
                rockEnemie.BackColor = Color.Red;
                YouWon();
                return true;
            }
            else if (choose == "scissors" && enemieChoose == "rock") {
                rockEnemie.BackColor = Color.Red;
                YouLost();
                return true;
            }
            else if (choose == "scissors" && enemieChoose == "paper") {
                paperEnemie.BackColor = Color.Red;
                YouWon();
                return true;
            }
            else if (choose == enemieChoose && choose is not null) {
                label1.Text = "Tie!";
                label1.ForeColor = Color.Blue;
                return true;
            }
            return false;
        }
        private void ReceiveMove() {
            byte[] buffer = new byte[1];
            sock.Receive(buffer);
            if (buffer[0] == 1) {
                enemieChoose = "rock";
            }
            if (buffer[0] == 2) {
                enemieChoose = "paper";
            }
            if (buffer[0] == 3) {
                enemieChoose = "scissors";
            }
        }
        private void closeBtn_Click(object sender, EventArgs e) {
            sock = null;
            server = null;
            client = null;
            this.Close();
        }

        private void rockBtn_Click(object sender, EventArgs e) {
            byte[] num = { 1 };
            sock.Send(num);
            choose = "rock";
            rockBtn.BackColor = Color.Blue;
            MessageReceiver.RunWorkerAsync();
        }

        private void paperBtn_Click(object sender, EventArgs e) {
            byte[] num = { 2 };
            sock.Send(num);
            choose = "paper";
            paperBtn.BackColor = Color.Blue;
            MessageReceiver.RunWorkerAsync();
        }

        private void scissorsBtn_Click(object sender, EventArgs e) {
            byte[] num = { 3 };
            sock.Send(num);
            choose = "scissors";
            scissorsBtn.BackColor = Color.Blue;
            MessageReceiver.RunWorkerAsync();
        }
    }
}
