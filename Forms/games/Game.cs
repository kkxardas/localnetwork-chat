using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using Register.res;
using DiscordClone.img;

namespace Register.Forms.tictactoe
{
    public partial class Game : MetroForm {
        
        char PlayerChar;
        char OpponentChar;
        Socket sock;
        BackgroundWorker MessageReceiver = new();
        TcpListener server = null;
        TcpClient client;

        public Game(bool isHost, string ip = null) {
            InitializeComponent();
            MessageReceiver.DoWork += MessageReceiver_DoWork;
            CheckForIllegalCrossThreadCalls = false;

            this.Icon = img.game;

            if (isHost) {
                PlayerChar = 'X';
                OpponentChar = 'O';
                server = new TcpListener(System.Net.IPAddress.Any, 5732);
                server.Start();
                sock = server.AcceptSocket();
            }
            else {
                PlayerChar = 'O';
                OpponentChar = 'X';
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

            this.FormBorderStyle = FormBorderStyle.None;
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

        private void closeBtn_Click(object sender, EventArgs e) {
            sock   = null;
            server = null;
            client = null;
            this.Close();
        }
        private bool CheckState() {
            if (btn1.Text == btn2.Text && btn2.Text == btn3.Text && btn3.Text != "") {
                if (btn1.Text[0] == PlayerChar)
                    YouWon();
                else
                    YouLost();
                return true;
            }

            else if (btn4.Text == btn5.Text && btn5.Text == btn6.Text && btn6.Text != "") {
                if (btn4.Text[0] == PlayerChar)
                    YouWon();
                else
                    YouLost();
                return true;
            }

            else if (btn7.Text == btn8.Text && btn8.Text == btn9.Text && btn9.Text != "") {
                if (btn7.Text[0] == PlayerChar)
                    YouWon();
                else
                    YouLost();
                return true;
            }


            else if (btn1.Text == btn4.Text && btn4.Text == btn7.Text && btn7.Text != "") {
                if (btn1.Text[0] == PlayerChar)
                    YouWon();
                else
                    YouLost();
                return true;
            }

            else if (btn2.Text == btn5.Text && btn5.Text == btn8.Text && btn8.Text != "") {
                if (btn2.Text[0] == PlayerChar)
                    YouWon();
                else
                    YouLost();
                return true;
            }

            else if (btn3.Text == btn6.Text && btn6.Text == btn9.Text && btn9.Text != "") {
                if (btn3.Text[0] == PlayerChar)
                    YouWon();
                else
                    YouLost();
                return true;
            }

            else if (btn1.Text == btn5.Text && btn5.Text == btn9.Text && btn9.Text != "") {
                if (btn1.Text[0] == PlayerChar)
                    YouWon();
                else
                    YouLost();
                return true;
            }

            else if (btn3.Text == btn5.Text && btn5.Text == btn7.Text && btn7.Text != "") {
                if (btn3.Text[0] == PlayerChar)
                    YouWon();
                else
                    YouLost();
                return true;
            }


            else if (btn1.Text != "" && btn2.Text != "" && btn3.Text != "" && btn4.Text != "" && btn5.Text != ""
                && btn6.Text != "" && btn7.Text != "" && btn8.Text != "" && btn9.Text != "") {
                label1.ForeColor = Color.Blue;
                label1.Text = "It's a draw!";
                return true;
            }
            return false;
        }
        private void FreezeBoard() {
            foreach (var control in this.Controls) {
                if (control is Button) {
                    Button btn = control as Button;
                    if(btn.Name != "closeBtn") btn.Enabled = false;
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
        private void ReceiveMove() {
            byte[] buffer = new byte[1];
            sock.Receive(buffer);
            switch(buffer[0]) {
                case 1:
                    btn1.Text = OpponentChar.ToString();
                    break;
                case 2:
                    btn2.Text = OpponentChar.ToString();
                    break;
                case 3:
                    btn3.Text = OpponentChar.ToString();
                    break;
                case 4:
                    btn4.Text = OpponentChar.ToString();
                    break;
                case 5:
                    btn5.Text = OpponentChar.ToString();
                    break;
                case 6:
                    btn6.Text = OpponentChar.ToString();
                    break;
                case 7:
                    btn7.Text = OpponentChar.ToString();
                    break;
                case 8:
                    btn8.Text = OpponentChar.ToString();
                    break;
                case 9:
                    btn9.Text = OpponentChar.ToString();
                    break;
            }

        }

        private void btn1_Click(object sender, EventArgs e) {
            byte[] num = { 1 };
            sock.Send(num);
            btn1.Text = PlayerChar.ToString();
            MessageReceiver.RunWorkerAsync();
        }

        private void btn2_Click(object sender, EventArgs e) {
            byte[] num = { 2 };
            sock.Send(num);
            btn2.Text = PlayerChar.ToString();
            MessageReceiver.RunWorkerAsync();
        }

        private void btn3_Click(object sender, EventArgs e) {
            byte[] num = { 3 };
            sock.Send(num);
            btn3.Text = PlayerChar.ToString();
            MessageReceiver.RunWorkerAsync();
        }

        private void btn4_Click(object sender, EventArgs e) {
            byte[] num = { 4 };
            sock.Send(num);
            btn4.Text = PlayerChar.ToString();
            MessageReceiver.RunWorkerAsync();
        }

        private void btn5_Click(object sender, EventArgs e) {
            byte[] num = { 5 };
            sock.Send(num);
            btn5.Text = PlayerChar.ToString();
            MessageReceiver.RunWorkerAsync();
        }

        private void btn6_Click(object sender, EventArgs e) {
            byte[] num = { 6 };
            sock.Send(num);
            btn6.Text = PlayerChar.ToString();
            MessageReceiver.RunWorkerAsync();
        }

        private void btn7_Click(object sender, EventArgs e) {
            byte[] num = { 7 };
            sock.Send(num);
            btn7.Text = PlayerChar.ToString();
            MessageReceiver.RunWorkerAsync();
        }

        private void btn8_Click(object sender, EventArgs e) {
            byte[] num = { 8 };
            sock.Send(num);
            btn8.Text = PlayerChar.ToString();
            MessageReceiver.RunWorkerAsync();
        }

        private void btn9_Click(object sender, EventArgs e) {
            byte[] num = { 9 };
            sock.Send(num);
            btn9.Text = PlayerChar.ToString();
            MessageReceiver.RunWorkerAsync();
        }
    }
}
