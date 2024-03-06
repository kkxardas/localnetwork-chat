using System.Text.RegularExpressions;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Security.Cryptography;
using System.Drawing;
using System.Drawing.Imaging;
using Register.res;
using MetroFramework.Forms;
using MetroFramework;
using MetroFramework.Controls;
using System.Diagnostics;
using DiscordClone.img;

//using static Register.System;

namespace Register
{






    public partial class LogUp : MetroForm {

        static string getInternetConnectionIP() {
            using (Process route = new Process()) {
                ProcessStartInfo startInfo = route.StartInfo;
                startInfo.FileName = "route.exe";
                startInfo.Arguments = "print 0.0.0.0";
                startInfo.UseShellExecute = false;
                startInfo.RedirectStandardOutput = true;
                route.Start();

                using (StreamReader reader = route.StandardOutput) {
                    string line;
                    do {
                        line = reader.ReadLine();
                    } while (!line.StartsWith("          0.0.0.0"));

                    return line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[3];
                }
            }
        }

        public Regex validatePassword = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$");
        public Regex validateEmail = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");

        public string strAddress = "smtp.gmail.com";
        public int port = 587;
        public bool enableSSL = true;
        public static string userName = "[Your email here]";
        public static string emailFrom = "[Your email here]";
        public static string nickname = "DiscordClone";
        public MailAddress from = new MailAddress(emailFrom, nickname);

        string userEmail = "";

        public int confirmCode = 1000;

        public string appPassword = "[Your application password here]";
        public LogUp() {

            InitializeComponent();

            this.Icon = img.login_register;

            Appearance.CustomizeForm(this);

            this.Size = new Size(410, 400);
            this.StartPosition = FormStartPosition.CenterScreen;

            confirmCodeGenerator.Start();

        }

        private void logupBtn_Click(object sender, EventArgs e) {
            using (AppDbContext context = new AppDbContext()) {
                if (loginTextBox.Text == "" || passwordTextBox.Text == "") {
                    MessageBox.Show("Please fill all the fields!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                if (context.Users.FirstOrDefault(u => u.Username == loginTextBox.Text) != null) {
                    MessageBox.Show("User with this nickname already exists!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    loginTextBox.Text = "";
                    return;
                }
                if (validatePassword.IsMatch(passwordTextBox.Text)) {

                    byte[] img = null;
                    if (userPhoto.Image is not null) {
                        using (MemoryStream ms = new MemoryStream()) {
                            userPhoto.Image.Save(ms, ImageFormat.Jpeg);
                            img = ms.ToArray();
                        }
                    }
                    User user = new User()
                    {
                        Username = loginTextBox.Text,
                        Email = userEmail,
                        Password = HashPassword(passwordTextBox.Text),
                        ProfileImage = img,
                        UserIp = getInternetConnectionIP()
                    };
                    context.Users.Add(user);
                    context.SaveChanges();
                    // ... reference to main chat form
                    DiscordClone chat = new DiscordClone();
                    chat.Owner = this;
                    this.Hide();
                    chat.currentUsername = user.Username;
                    chat.StartPosition = FormStartPosition.CenterScreen;
                    chat.TopLevel = true;
                    chat.ShowDialog();
                }
                else {
                    MessageBox.Show("Password requires:\n1. One uppercase letter\n2. One lowercase letter\n3. At least one special character\n4. At least one number\n5. At least 8 characters and maximum 15 characters",
                    "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void loginReference_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            LogIn loginForm = new LogIn();
            this.Hide();
            loginForm.StartPosition = FormStartPosition.CenterScreen;
            loginForm.ShowDialog();
        }

        private void LogUp_FormClosed(object sender, FormClosedEventArgs e) => Application.Exit();
        

        private void confirmCodeGenerator_Tick(object sender, EventArgs e) {
            if (confirmCode >= 1000 && confirmCode <= 100000) confirmCode += 373;
            else confirmCode = 1000;
            
        }

        private async void sendVerificationBtn_Click(object sender, EventArgs e) {
            using (AppDbContext context = new AppDbContext()) {
                if (context.Users.FirstOrDefault(u => u.Email == emailTextBox.Text) != null) {
                    MessageBox.Show("User with this email already exists!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    emailTextBox.Text = "";
                    return;
                }
            }
            if (validateEmail.IsMatch(emailTextBox.Text)) {
                confirmCodeGenerator.Stop();
                userEmail = emailTextBox.Text;
                string? emailTo = emailTextBox.Text;
                string? subject = "Welcome to the DiscordClone, Buddy!";
                string? body = "Your confirmation code is: " + confirmCode.ToString() + "\nPlease do not tell it to anyone!";
                MailAddress to = new MailAddress(emailTo);
                MailMessage message = new MailMessage(from, to);
                message.Subject = subject;
                message.Body = body;
                SmtpClient smtpClient = new SmtpClient(strAddress, port);
                smtpClient.Credentials = new NetworkCredential(userName, appPassword);
                smtpClient.EnableSsl = enableSSL;
                await smtpClient.SendMailAsync(message);
                emailTextBox.Hide();
                emailLabel.Hide();
                sendVerificationBtn.Hide();

                confirmCodeLabel.Location = new Point(85, 91);
                confirmCodeTextBox.Location = new Point(221, 88);
                verifyBtn.Location = new Point(157, 119);
            }
            else {
                MessageBox.Show("Invalid email!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void verifyBtn_Click(object sender, EventArgs e) {
            if (confirmCodeTextBox.Text == confirmCode.ToString()) {
                confirmCodeTextBox.Hide();
                confirmCodeLabel.Hide();
                verifyBtn.Hide();


                logupBtn.Location = new Point(141, 177);
                loginTextBox.Location = new Point(141, 88);
                usernameLabel.Location = new Point(56, 91);
                passwordTextBox.Location = new Point(141, 126);
                passwordLabel.Location = new Point(56, 134);
            }
            else {
                MessageBox.Show("Wrong code!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static string HashPassword(string password) {
            using (SHA256 sha256Hash = SHA256.Create()) {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++) {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        private void uploadPhotoBtn_Click(object sender, EventArgs e) {
            using (OpenFileDialog of = new OpenFileDialog()) {
                if (of.ShowDialog() == DialogResult.OK) {
                    string fileName = of.FileName;
                    string fileExtension = Path.GetExtension(fileName);
                    if (fileExtension == ".jpg" || fileExtension == ".png") userPhoto.Image = Image.FromFile(fileName);

                    else MessageBox.Show("Invalid file format!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void closeBtn_Click_1(object sender, EventArgs e) => this.Close();

    }
}

