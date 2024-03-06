using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using MetroFramework;
using Register.res;
using System.Diagnostics;
using Microsoft.Win32;
using Microsoft.VisualBasic.ApplicationServices;
using System.Configuration;
using DiscordClone.img;

namespace Register
{
    public partial class LogIn : MetroForm
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

        public bool Remember;
        public string login;
        public string pass;

        public LogIn()
        {
            InitRegistry();

            InitializeComponent();

            if (Remember)
            {
                loginTextBox.Text = login;
                passwordTextBox.Text = pass;
                rememberMe.Checked = true;
            }

            this.Icon = img.login_register;

            Appearance.CustomizeForm(this);
        }


        private void LogupReference_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LogUp logup = new LogUp();
            this.Hide();
            logup.StartPosition = FormStartPosition.CenterScreen;
            logup.ShowDialog();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {

            using (AppDbContext context = new AppDbContext())
            {
                if (loginTextBox.Text == "" || passwordTextBox.Text == "")
                {
                    MessageBox.Show("Please fill all the fields!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    User user = context.Users.FirstOrDefault(u => u.Username == loginTextBox.Text && u.Password == LogUp.HashPassword(passwordTextBox.Text));
                    if (user == null)
                    {
                        MessageBox.Show("User not found!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        if (user.isBanned)
                        {
                            MessageBox.Show("You are currently banned on this server!\n" +
                                "Please contact us if you do not agree with your ban", "Banned!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else
                        {
                            if (rememberMe.Checked)
                            {
                                using (var userKey = Registry.CurrentUser)
                                {
                                    using (var rememberMeKey = userKey.CreateSubKey("RememberMeFolder"))
                                    {
                                        rememberMeKey.SetValue("isRemember", true);
                                        rememberMeKey.SetValue("Login", loginTextBox.Text);
                                        rememberMeKey.SetValue("Password", passwordTextBox.Text);
                                    }
                                }
                            }
                            else
                            {
                                using (var userKey = Registry.CurrentUser)
                                {
                                    using (var rememberMeKey = userKey.CreateSubKey("RememberMeFolder"))
                                    {
                                        rememberMeKey.SetValue("isRemember", false);
                                        rememberMeKey.SetValue("Login", "");
                                        rememberMeKey.SetValue("Password", "");
                                    }
                                }
                            }
                            // ... Reference to main chat form

                            user.UserIp = getInternetConnectionIP();
                            context.Update(user);
                            context.SaveChanges();

                            this.Visible = false;

                            DiscordClone chat = new()
                            {
                                StartPosition = FormStartPosition.CenterScreen,
                                TopLevel = true,
                                currentUsername = loginTextBox.Text
                            };
                            chat.Show();
                        }

                    }
                }
            }
        }

        private void LogIn_FormClosed(object sender, FormClosedEventArgs e) => Application.Exit();



        private void closeBtn_Click_1(object sender, EventArgs e) => this.Close();



        private void InitRegistry()
        {
            using (var userKey = Registry.CurrentUser)
            {
                try
                {
                    using (var rememberMeKey = userKey.OpenSubKey("RememberMeFolder"))
                    {
                        login = rememberMeKey.GetValue("Login").ToString();
                        Remember = Convert.ToBoolean(rememberMeKey.GetValue("isRemember").ToString());
                        pass = rememberMeKey.GetValue("Password").ToString();
                    }
                }
                catch
                {
                    using (var rememberMeKey = userKey.CreateSubKey("RememberMeFolder"))
                    {
                        rememberMeKey.SetValue("isRemember", false);
                        rememberMeKey.SetValue("Login", "");
                        rememberMeKey.SetValue("Password", "");
                    }
                }
            }
        }


        private void rememberMe_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void LogIn_Load(object sender, EventArgs e)
        {
            
        }
    }
}
