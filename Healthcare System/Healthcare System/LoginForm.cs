using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Healthcare_System.DAL;
using Healthcare_System.Messages;

namespace Healthcare_System
{
    public partial class LoginForm : Form
    {
        private IList<string> errorMessages;
        public LoginForm()
        {
            InitializeComponent();
            this.errorMessages = new List<string>();
            this.labelErrorMessages.Hide();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email = this.textBoxUsername.Text;
            string password = this.textBoxPassword.Text;

            this.errorMessages.Clear();
            this.validateEmail(email);
            this.validatePassword(password);



            if (this.errorMessages.Count > 0)
            {
                this.displayErrorMessages();
            }
            else
            {
                this.errorMessages.Clear();
                int result = UserDAL.Authenticate(email, password);
                if (result == 1)
                {
                    // TODO: Login and display next page
                }
                else
                {
                    this.errorMessages.Add(UIMessages.USER_DOESNT_EXIST);
                    this.displayErrorMessages();
                }
            }
        }

        private void labelRegister_Click(object sender, EventArgs e)
        {
            var registerForm = new formRegister();
            this.Hide();
            registerForm.Show();
        }

        private void validateEmail(string email)
        {
            if (String.IsNullOrEmpty(email.Trim()))
            {
                this.errorMessages.Add(UIMessages.INVALID_EMAIL);
            }
            else
            {
                this.errorMessages.Remove(UIMessages.INVALID_EMAIL);
            }
        }

        private void validatePassword(string password)
        {
            if (String.IsNullOrEmpty(password.Trim()))
            {
                this.errorMessages.Add(UIMessages.INVALID_PASSWORD);
            }
            else
            {
                this.errorMessages.Remove(UIMessages.INVALID_PASSWORD);
            }
        }

        private void displayErrorMessages()
        {
            var errors = "";
            foreach (var currentError in this.errorMessages)
            {
                errors += currentError + Environment.NewLine;
            }

            this.labelErrorMessages.Text = errors;
            this.labelErrorMessages.Show();
        }
    }
}
