using MetroFramework.Forms;
using Register.res;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Register.Forms
{
    public partial class AdminPanel : MetroForm
    {
        public AdminPanel()
        {
            InitializeComponent();
            Appearance.CustomizeForm(this);
        }

        private void closeBtn_Click(object sender, EventArgs e) => this.Close();
        

        private void closeBtn2_Click(object sender, EventArgs e) => this.Close();
        

        private void banUser_Click(object sender, EventArgs e)
        {
            if (userTextBox.Text == "admin")
            {
                MessageBox.Show("You can't ban or unban the admin!");
                return;
            }
            else if (userTextBox.Text == "")
            {
                MessageBox.Show("Please enter a username!");
                return;
            }
            else
            {
                using (var context = new AppDbContext())
                {
                    User user = context.Users.FirstOrDefault(u => u.Username == userTextBox.Text);
                    if (user != null)
                    {
                        if (!user.isBanned)
                        {
                            MessageBox.Show("User was banned successfully!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.Continue;
                            user.isBanned = true;
                        }
                        else { MessageBox.Show("You cannot ban the banned person.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
                        context.Update(user);
                        context.SaveChanges();
                    }
                }
            }
        }

        private void unbanBtn_Click(object sender, EventArgs e)
        {
            if (userTextBox.Text == "admin")
            {
                MessageBox.Show("You can't ban or unban the admin!");
                return;
            }
            else if (userTextBox.Text == "")
            {
                MessageBox.Show("Please enter a username!");
                return;
            }
            else
            {
                using (var context = new AppDbContext())
                {
                    User user = context.Users.FirstOrDefault(u => u.Username == userTextBox.Text);
                    if (user != null)
                    {
                        if (user.isBanned)
                        {
                            user.isBanned = false;
                            MessageBox.Show("User was unbanned successfully!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else { MessageBox.Show("You cannot unban the unbanned person.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
                        context.Update(user);
                        context.SaveChanges();
                    }
                }
            }
        }

        private void clearChatBtn_Click(object sender, EventArgs e)
        {
            using(var context = new AppDbContext())
            {
                var allMessages = context.Messages.ToList();
                context.Messages.RemoveRange(allMessages);
                context.SaveChanges();
                this.DialogResult = DialogResult.OK;
                MessageBox.Show("Chat was cleared successfully!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
