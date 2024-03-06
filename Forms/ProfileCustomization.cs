using MetroFramework.Forms;
using Register.res;
using System.Text.RegularExpressions;
using System.Drawing.Imaging;
using DiscordClone.img;

namespace Register.Forms
{
    public partial class ProfileCustomization : MetroForm {

        public string? currentUsername;
        public Image ProfileImage;

        public Regex validateEmail = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");

        public bool isChanging = true;
        public ProfileCustomization() {
            InitializeComponent();

            this.Icon = img.customization;

            Appearance.CustomizeForm(this);

            Task.Run(() => {
                using (AppDbContext context = new AppDbContext()) {
                    User user = context.Users.FirstOrDefault(u => u.Username == currentUsername);
                    if (user is not null) {
                        usernameTextBox.Invoke(() => { usernameTextBox.Text = currentUsername; });
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
        
        private void saveChangesBtn_Click(object sender, EventArgs e) {
            if (isChanging) {
                if (passwordTextBox.Text == confirmTextBox.Text && validateEmail.IsMatch(emailTextBox.Text) && (passwordTextBox.Text != "" || confirmTextBox.Text != "")) {
                    using (AppDbContext context = new AppDbContext()) {
                        User user = context.Users.FirstOrDefault(u => u.Username == currentUsername);
                        if (user.Password == LogUp.HashPassword(passwordTextBox.Text)) {
                            if (user != null) {
                                // Check if the new username already exists
                                if (context.Users.Any(u => u.Username == usernameTextBox.Text && u.Id != user.Id)) {
                                    MessageBox.Show("This login already exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }

                                // Check if the new email already exists
                                if (context.Users.Any(u => u.Email == emailTextBox.Text && u.Id != user.Id)) {
                                    MessageBox.Show("This email already exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }

                                // Update the user's properties
                                user.Username = usernameTextBox.Text;
                                user.Email = emailTextBox.Text;


                                //FIX LATER------------ fixed 21:11:20 2/9/2024
                                byte[] img = null;
                                if (userPhoto.Image is not null) {
                                    using (MemoryStream ms = new()) {
                                        userPhoto.Image.Save(ms, ImageFormat.Jpeg);
                                        img = ms.ToArray();
                                    }
                                }
                                user.ProfileImage = img;
                                //---------------------

                                // Save changes to the database
                                context.SaveChanges();
                                ProfileImage = userPhoto.Image;
                                MessageBox.Show("User updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                            }
                        }
                        else {
                            MessageBox.Show("User NOT FOUND", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else {
                    MessageBox.Show("Something went wrong...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } else {
                using(AppDbContext context = new()) {
                    User user = context.Users.FirstOrDefault(u => u.Username == currentUsername);
                    if(LogUp.HashPassword(passwordTextBox.Text) == user.Password && confirmTextBox.Text != "") {
                        user.Password = LogUp.HashPassword(confirmTextBox.Text);
                        context.Update(user);
                        context.SaveChanges();
                        MessageBox.Show("User updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    } else {
                        MessageBox.Show("Something went wrong...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void uploadBtn_Click(object sender, EventArgs e) {
            using (OpenFileDialog of = new OpenFileDialog()) {
                if (of.ShowDialog() == DialogResult.OK) {
                    string fileName = of.FileName;
                    string fileExtension = Path.GetExtension(fileName);
                    if (fileExtension == ".jpg" || fileExtension == ".png") userPhoto.Image = Image.FromFile(fileName);
                    else MessageBox.Show("Invalid file format!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void closeBtn_Click(object sender, EventArgs e) {
            ProfileImage = userPhoto.Image;
            this.Close();
        }

        private void closeBtn2_Click(object sender, EventArgs e) {
            ProfileImage = userPhoto.Image;
            this.Close();
        }

        public Point labelOldPos;
        public Point btnOldPos;

        public Point confirmLabelOldPos;
        public Point confirmBtnOldPos;
        

        private void changePwdBtn_Click(object sender, EventArgs e) {
            if (changePwdBtn.Text == "Change Password") {
                isChanging = false;
                changePwdBtn.Text = "Back";
                usernameLabel.Visible = false;
                usernameTextBox.Visible = false;

                emailLabel.Visible = false;
                emailTextBox.Visible = false;

                pwdLabel.Text = "Old Password: ";

                labelOldPos = pwdLabel.Location;
                btnOldPos = passwordTextBox.Location;
                confirmBtnOldPos = confirmTextBox.Location;
                confirmLabelOldPos = confirmLabel.Location;

                pwdLabel.Location = new Point(161, 110);
                passwordTextBox.Location = new Point(284, 107);

                confirmLabel.Text = "New Password: ";
                confirmLabel.Location = new Point(161, 158);
                confirmTextBox.Location = new Point(284, 155);

            } else {
                isChanging = true;
                changePwdBtn.Text = "Change Password";
                usernameLabel.Visible = true;
                usernameTextBox.Visible = true;

                emailLabel.Visible = true;
                emailTextBox.Visible = true;

                pwdLabel.Text = "Password: ";
                pwdLabel.Location = labelOldPos;
                passwordTextBox.Location = btnOldPos;

                confirmLabel.Text = "Confirm Password: ";
                confirmLabel.Location = confirmLabelOldPos;
                confirmTextBox.Location = confirmBtnOldPos;
            }
        }
    }
}
