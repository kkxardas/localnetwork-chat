using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using DiscordClone.img;
using MetroFramework;
using MetroFramework.Forms;
using Microsoft.Data.SqlClient;
using Register.Forms;
using Register.res;

namespace Register
{







    public partial class DiscordClone : MetroForm
    {

        static string getInternetConnectionIP()
        {
            using (Process route = new Process())
            {
                ProcessStartInfo startInfo = route.StartInfo;
                startInfo.FileName = "route.exe";
                startInfo.Arguments = "print 0.0.0.0";
                startInfo.UseShellExecute = false;
                startInfo.RedirectStandardOutput = true;
                route.Start();

                using (StreamReader reader = route.StandardOutput)
                {
                    string line;
                    do
                    {
                        line = reader.ReadLine();
                    } while (!line.StartsWith("          0.0.0.0"));

                    // the interface is the fourth entry in the line
                    return line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[3];
                }
            }
        }

        UdpClient clientSend;
        UdpClient clientReceive;

        UdpClient msgSend;
        UdpClient msgReceive;

        public string currentUsername;
        public Image currentProfileImage;

        public string consoleMessage;


        public DiscordClone()
        {

            InitializeComponent();

            rgbSpeed.Value = 10;
            rgbSpeed.Maximum = 50;
            rgbSpeed.Minimum = 1;

            for (int i = 6; i <= 36; i++)
            {
                chatFontSize.Items.Add(i.ToString());
            }
            chatFontSize.SelectedIndex = chatFontSize.Items.IndexOf(Appearance.ChatFont.Size.ToString());

            formColors.Items.AddRange(new string[] { "Dark", "Light" });
            formColors.SelectedIndex = formColors.Items.IndexOf("Dark");

            this.Icon = img.discordclone_icon2;

            IPAddress ip = IPAddress.Parse(getInternetConnectionIP());
            try
            {
                clientSend = new UdpClient(new IPEndPoint(ip, 47023));
                clientReceive = new UdpClient(new IPEndPoint(ip, 47025));

                msgSend = new UdpClient(new IPEndPoint(ip, 47021));
                msgReceive = new UdpClient(new IPEndPoint(ip, 47020));
            }
            catch { }


            isOnline.Start();


            Appearance.CustomizeForm(this);


            // Check if user is online
            Task.Run(() =>
            {
                while (true)
                {
                    IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Any, 47025);
                    byte[] data = clientReceive.Receive(ref iPEndPoint);

                    Info myMessage = Serializer.ByteArrayToObject<Info>(data);

                    connectedUsers.Invoke(() =>
                    {
                        if (!connectedUsers.Items.Contains(myMessage.ComputerName))
                        {
                            connectedUsers.Items.Add(myMessage.ComputerName);
                        }
                        else if (connectedUsers.Items.Contains(myMessage.ComputerName) && !myMessage.IsOnline)
                        {
                            connectedUsers.Items.Remove(myMessage.ComputerName);
                        }
                    });
                }
            });

            // Receive messages
            Task.Run(() =>
            {
                while (true)
                {
                    IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Any, 47020);
                    byte[] data = msgReceive.Receive(ref iPEndPoint);

                    Info msg = Serializer.ByteArrayToObject<Info>(data);

                    if (msg.Message == "Chat was cleared by the Admin.")
                    {
                        chatOutput.Invoke(() =>
                        {
                            chatOutput.Text = "";
                        });
                    }

                    int currPos = chatOutput.SelectionStart;
                    string minute = String.Empty;
                    string month = String.Empty;
                    string day = String.Empty;
                    chatOutput.Invoke(() =>
                    {
                        chatOutput.SelectionStart = currPos;
                        if (msg.Minute < 10) minute = "0" + msg.Minute.ToString();
                        else { minute = msg.Minute.ToString(); }
                        if (msg.Month < 10) month = "0" + msg.Month.ToString();
                        else month = msg.Month.ToString();
                        if (msg.Day < 10) day = "0" + msg.Day.ToString();
                        else day = msg.Day.ToString();

                        chatOutput.AppendText($"{msg.ComputerName} [{day}.{month}.2024 | {msg.Hour}:{minute}] >>> {msg.Message}{Environment.NewLine}");
                        chatOutput.SelectionStart = currPos;
                    });

                }
            });

            // Load messages from database && Avatar
            Task.Run(() =>
            {
                using (AppDbContext context = new AppDbContext())
                {

                    string minute = String.Empty;
                    string month = String.Empty;
                    string day = String.Empty;
                    foreach (var msg in context.Messages)
                    {
                        this.Invoke((MethodInvoker)delegate
                        {
                            if (msg.Minute < 10) minute = "0" + msg.Minute.ToString();
                            else { minute = msg.Minute.ToString(); }
                            if (msg.Month < 10) month = "0" + msg.Month.ToString();
                            else month = msg.Month.ToString();
                            if (msg.Day < 10) day = "0" + msg.Day.ToString();
                            else { minute = msg.Minute.ToString(); }
                            chatOutput.Text += ($"{msg.Username} [{day}.{month}.2024 | {msg.Hour}:{minute}] >>> {msg.Message}{Environment.NewLine}");
                        });
                    }
                    byte[] imageByte = context.Users.FirstOrDefault(u => u.Username == currentUsername).ProfileImage;
                    if (imageByte is null) userPhoto.Image = Image.FromFile(@"res\defaut-avatar.png");
                    using (var ms = new MemoryStream(imageByte))
                    {
                        userPhoto.Image = Image.FromStream(ms);
                    }
                }
            });
        }


        private void sendMsgBtn_Click(object sender, EventArgs e) => SendMessage();


        private void SendMessage()
        {
            if (messageInput.Text == "") return;

            Info myMessage = new Info
            {
                ComputerName = currentUsername,
                Message = messageInput.Text,
                Month = DateTime.Now.Month,
                Day = DateTime.Now.Day,
                Hour = DateTime.Now.Hour,
                Minute = DateTime.Now.Minute
            };

            Task.Run(() =>
            {
                Messages msg = new Messages()
                {
                    Username = myMessage.ComputerName,
                    Month = DateTime.Now.Month,
                    Day = DateTime.Now.Day,
                    Hour = DateTime.Now.Hour,
                    Minute = DateTime.Now.Minute,
                    Message = myMessage.Message
                };

                using (AppDbContext context = new AppDbContext())
                {
                    context.Messages.Add(msg);
                    context.SaveChanges();
                }
            });

            byte[] data = Serializer.ObjectToByteArray(myMessage);
            messageInput.Text = "";

            try
            {
                msgSend.Connect(IPAddress.Broadcast, 47020);
            }
            catch { }

            msgSend.Send(data, data.Length);
        }

        private void isOnline_Tick(object sender, EventArgs e)
        {
            if (currentUsername == "") currentUsername = Environment.UserName;
            if (currentUsername.ToLower() == "admin") adminBtn.Visible = true;

            Info myMessage = new Info
            {
                ComputerName = currentUsername,
                IsOnline = true
            };

            byte[] data = Serializer.ObjectToByteArray(myMessage);

            try
            {
                clientSend.Connect(IPAddress.Broadcast, 47025);
            }
            catch { }
            clientSend.Send(data, data.Length);
        }

        private void DiscordClone_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (currentUsername == "") currentUsername = Environment.UserName;

            Info myMessage = new Info { ComputerName = currentUsername, IsOnline = false };

            byte[] data = Serializer.ObjectToByteArray(myMessage);

            try { clientSend.Connect(IPAddress.Broadcast, 47025); }
            catch { }
            clientSend.Send(data, data.Length);
            Application.Exit();
        }

        private void userPhoto_Click(object sender, EventArgs e)
        {
            ProfileCustomization customization = new ProfileCustomization();
            customization.currentUsername = currentUsername;
            customization.ShowDialog();
            userPhoto.Image = customization.ProfileImage;
        }

        private void messageInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {

                e.Handled = true;
                SendMessage();
            }
        }

        private void closeBtn_Click_1(object sender, EventArgs e) => this.Close();

        private void connectedUsers_DoubleClick(object sender, EventArgs e)
        {
            if (connectedUsers.SelectedItem is not null)
            {
                UserInfo ui = new UserInfo();
                ui.transferedUsername = connectedUsers.SelectedItem.ToString();
                ui.currentUsername = currentUsername;
                ui.ShowDialog();
            }
            else MessageBox.Show("Select user", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            if (searchUserTextBox.Text != "")
            {
                using (AppDbContext context = new())
                {
                    if (context.Users.FirstOrDefault(u => u.Username == searchUserTextBox.Text) is not null)
                    {
                        UserInfo ui = new();
                        ui.transferedUsername = searchUserTextBox.Text;
                        ui.ShowDialog();
                    }
                    else MessageBox.Show("Username was not found", "Oops...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else MessageBox.Show("Enter username!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void clearChatBtn_Click(object sender, EventArgs e)
        {
            AdminPanel adminPanel = new();
            DialogResult result = adminPanel.ShowDialog();
            if (result == DialogResult.OK)
            {
                Info myMessage = new Info
                {
                    ComputerName = "CONSOLE",
                    Message = "Chat was cleared by the Admin.",
                    Month = DateTime.Now.Month,
                    Day = DateTime.Now.Day,
                    Hour = DateTime.Now.Hour,
                    Minute = DateTime.Now.Minute
                };

                Task.Run(() =>
                {
                    Messages msg = new Messages()
                    {
                        Username = myMessage.ComputerName,
                        Month = DateTime.Now.Month,
                        Day = DateTime.Now.Day,
                        Hour = DateTime.Now.Hour,
                        Minute = DateTime.Now.Minute,
                        Message = myMessage.Message
                    };

                });

                byte[] data = Serializer.ObjectToByteArray(myMessage);
                messageInput.Text = "";

                try
                {
                    msgSend.Connect(IPAddress.Broadcast, 47020);
                }
                catch { }

                msgSend.Send(data, data.Length);
            }
        }

        private void chatFontSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (chatFontSize.SelectedIndex != -1)
            {
                int fontSize = Convert.ToInt32(chatFontSize.SelectedItem);
                chatOutput.Font = new Font("Arial", fontSize, FontStyle.Regular);
            }
        }





        private void formColors_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (formColors.SelectedIndex != -1)
            {
                if (formColors.SelectedIndex == formColors.Items.IndexOf("Dark"))
                {
                    Appearance.Theme = MetroThemeStyle.Dark;
                    Appearance.TextColor = Color.White;
                }
                else
                {
                    Appearance.Theme = MetroThemeStyle.Light;
                    Appearance.TextColor = Color.Black;
                }
                Appearance.CustomizeForm(this);
            }
        }

        private void changeColorTextBoxBtn_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new();
            cd.Color = chatOutput.BackColor;
            cd.ShowDialog();
            var color = cd.Color;
            var brightness = cd.Color.GetBrightness();
            if (brightness < 0.5) chatOutput.ForeColor = Color.White;
            else chatOutput.ForeColor = Color.Black;
            chatOutput.BackColor = color;
        }

        public bool isRGB = false;

        private void rgbBtn_Click(object sender, EventArgs e)
        {
            if (isRGB) isRGB = false;
            else isRGB = true;

            if (isRGB)
            {
                Task.Run(UpdateColor);
            }
            else
            {
                chatOutput.BackColor = SystemColors.Control;
            }
        }
        private void UpdateColor()
        {
            int R = 122, G = 11, B = 240;
            bool isReachEndR = false, isReachEndG = false, isReachEndB = false;
            while (isRGB)
            {
                if (R == 255) { isReachEndR = true; }
                if (G == 255) { isReachEndG = true; }
                if (B == 255) { isReachEndB = true; }

                if (R == 0) { isReachEndR = false; }
                if (G == 0) { isReachEndG = false; }
                if (B == 0) { isReachEndB = false; }

                if (isReachEndR)  R--;
                if (isReachEndG)  G--;
                if (isReachEndB)  B--;

                if (!isReachEndR) R++;
                if (!isReachEndG) G++;
                if (!isReachEndB) B++;



                chatOutput.BackColor = Color.FromArgb(R, G, B);
                Thread.Sleep(51 - rgbSpeed.Value);
            }
        }

    }
}