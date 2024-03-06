using DiscordClone.img;
using MetroFramework.Forms;
using Register.res;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Register.Forms
{
    public partial class UserInfo : MetroForm {

        public string? transferedUsername;
        public string? currentUsername;
        public string? userIp;

        public UserInfo() {
            InitializeComponent();
            

            this.Icon = img.user;

            Appearance.CustomizeForm(this);

            Task.Run(() => {
                using (AppDbContext context = new AppDbContext()) {
                    User user = context.Users.FirstOrDefault(u => u.Username == transferedUsername);
                    if (user is not null) {
                        usernameTextBox.Invoke(() => { usernameTextBox.Text = transferedUsername; });

                        emailTextBox.Invoke(() => { emailTextBox.Text = user.Email; });
                        if (user.ProfileImage is null) {
                            userPhoto.Invoke(() => { userPhoto.Image = Image.FromFile(@"res\defaut-avatar.png"); });
                        }
                        else {
                            using (var ms = new MemoryStream(user.ProfileImage)) {
                                userPhoto.Invoke(() => { userPhoto.Image = Image.FromStream(ms); });
                            }
                        }
                    }
                    
                }
            });

        }

        private void closeBtn_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void closeBtn2_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void tictactoeBtn_Click(object sender, EventArgs e) {
            using (var context = new AppDbContext()) {
                string userIp = context.Users.FirstOrDefault(u => u.Username == transferedUsername).UserIp;
                Server server = new(userIp, "tictactoe");
                server.Show();
            }

        }

        private void rockpaperscissorsBtn_Click(object sender, EventArgs e) {
            using (var context = new AppDbContext()) {
                string userIp = context.Users.FirstOrDefault(u => u.Username == transferedUsername).UserIp;
                Server server = new(userIp, "rockpaperscissors");
                server.Show();
            }
        }
    }
}
