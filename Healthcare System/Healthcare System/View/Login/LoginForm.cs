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
using Healthcare_System.Validation;
using Healthcare_System.View;

namespace Healthcare_System
{
    public partial class LoginForm : Form
    {
        private IList<string> errorMessages;
        public LoginForm()
        {
            InitializeComponent();
            this.openRegisterIfNoAdministrator();
            this.errorMessages = new List<string>();
            this.labelErrorMessages.Hide();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = this.textBoxUsername.Text;
            string password = this.textBoxPassword.Text;

            this.errorMessages.Clear();
            this.validateEmail(username);
            this.validatePassword(password);



            if (this.errorMessages.Count > 0)
            {
                this.displayErrorMessages();
            }
            else
            {
                this.errorMessages.Clear();
                int result = AccountDAL.Authenticate(username, password);
                if (result == 1)
                {
                    Wrapper wrapper = new Wrapper(username, this);
                    this.textBoxUsername.Clear();
                    this.textBoxPassword.Clear();
                    wrapper.ShowDialog();
                }
                else
                {
                    this.errorMessages.Add(UIMessages.USER_DOESNT_EXIST);
                    this.displayErrorMessages();
                }
            }
        }

        private void openRegisterIfNoAdministrator()
        {
            if (AdministratorDAL.GetNumberAdministrators() == 0)
            {
                var registerForm = new RegisterForm(this);
                registerForm.ShowDialog();
            }
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

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
