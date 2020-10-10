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

namespace Healthcare_System
{
    public partial class RegisterForm : Form
    {
        private LoginForm loginForm;

        public RegisterForm(LoginForm loginForm)
        {
            InitializeComponent();
            this.loginForm = loginForm;
            this.loginForm.Hide();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = this.textBoxUsername.Text;
            string password = this.textBoxPassword.Text;
            string firstName = this.textBoxFirstName.Text;
            string lastName = this.textBoxLastName.Text;
            string address1 = this.textBoxAddress1.Text;
            string address2 = this.textBoxAddress2.Text;
            string city = this.textBoxCity.Text;
            string state = this.comboBoxStates.SelectedItem.ToString();
            int zip = Int32.Parse(this.textBoxZip.Text);
            string phone = this.textBoxPhone.Text;
            DateTime dob = this.dateTimePicker.Value;
            string gender = this.comboBoxGender.SelectedItem.ToString();

            if (string.IsNullOrEmpty(address2)) {
                address2 = null;
            }

            int userId = UserDAL.Register(firstName, lastName, city, state, zip, phone, dob, gender, address1, address2);
            bool accountRegistrationSuccess = AccountDAL.Register(username, password);
            bool administratorRegistrationSuccess = AdministratorDAL.Register(userId, username);

            bool registrationSuccess = accountRegistrationSuccess && administratorRegistrationSuccess;

            Console.WriteLine("Register Successful? " + registrationSuccess + " " + userId.ToString());

            if (accountRegistrationSuccess)
            {
                this.Close();
            }
        }

        private void formRegister_Load(object sender, EventArgs e)
        {

        }
    }
}
