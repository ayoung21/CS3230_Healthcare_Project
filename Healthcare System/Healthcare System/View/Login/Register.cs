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
    public partial class RegisterForm : Form
    {
        // private LoginForm loginForm;
        private bool initialAdminExists;
        private string username;
        private string password;
        private string firstName;
        private string lastName;
        private string address1;
        private string address2;
        private string city;
        private string state;
        private int zip;
        private string phone;
        private DateTime dob;
        private string gender;

        public Form LoginForm { get; set; }

        private IList<string> errorMessages;

        public RegisterForm()
        {
            InitializeComponent();
            this.initialAdminExists = false;
            this.labelErrorMessages.Hide();
            this.errorMessages = new List<string>();
            // this.loginForm = loginForm;

            LoginForm?.Hide();


            if (AdministratorDAL.GetNumberAdministrators() > 0)
            {
                this.initialAdminExists = true;
                this.textBoxUsername.Hide();
                this.textBoxPassword.Hide();

                this.usernameLabel.Hide();
                this.passwordLabel.Hide();
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            this.errorMessages.Clear();

            if (!this.initialAdminExists)
            {
                this.username = this.textBoxUsername.Text;
                this.password = this.textBoxPassword.Text;
            }

            this.firstName = this.textBoxFirstName.Text;
            this.lastName = this.textBoxLastName.Text;
            this.address1 = this.textBoxAddress1.Text;
            this.address2 = this.textBoxAddress2.Text; 
            this.city = this.textBoxCity.Text;
            this.state = (this.comboBoxStates.SelectedItem == null) ? "" : this.comboBoxStates.SelectedItem.ToString();
            this.zip = (String.IsNullOrEmpty(this.textBoxZip.Text) || this.textBoxZip.Text.Length != 5) ? Constants.Constants.INVALID_ZIP : Int32.Parse(this.textBoxZip.Text);
            this.phone = (String.IsNullOrEmpty(this.textBoxPhone.Text) || this.textBoxPhone.Text.Length != 10) ? "" : this.textBoxPhone.Text;
            this.dob = this.dateTimePicker.Value;
            this.gender = (this.comboBoxGender.SelectedItem == null) ? "" : this.comboBoxGender.SelectedItem.ToString();

            this.validateFields();

            
            if (string.IsNullOrEmpty(address2)) {
                address2 = null;
            }
            

            if (this.errorMessages.Count > 0)
            {
                this.displayErrorMessages();
            }
            else
            {
                if (!this.initialAdminExists)
                {

                    int userId = UserDAL.Register(firstName, lastName, city, state, zip, phone, dob, gender, address1,
                        address2);
                    bool accountRegistrationSuccess = AccountDAL.Register(username, password);
                    bool administratorRegistrationSuccess = AdministratorDAL.Register(userId, username);

                    bool registrationSuccess = accountRegistrationSuccess && administratorRegistrationSuccess;

                    Console.WriteLine("Register Successful? " + registrationSuccess + " " + userId.ToString());
                }
                else
                {
                    int userId = UserDAL.Register(firstName, lastName, city, state, zip, phone, dob, gender, address1, address2);
                    bool patientRegistrationSuccess = PatientDAL.Register(userId);
                }

                this.labelErrorMessages.Hide();
                /*
                if (accountRegistrationSuccess)
                {
                    this.Close();
                }
                */
                this.Close();
            }
            

        }

        private void formRegister_Load(object sender, EventArgs e)
        {

        }

        private void validateFields()
        {
            if (!this.initialAdminExists)
            {
                this.validateUsername();
                this.validatePassword();
            }

            this.validateFirstName();
            this.validateLastName();
            this.validateStreetAddress();
            this.validateCity();
            this.validateState();
            this.validateZip();
            this.validatePhone();
            this.validateGender();
        }

        private void validateUsername()
        {
            if (String.IsNullOrEmpty(this.username.Trim()))
            {
                this.errorMessages.Add(UIMessages.INVALID_USERNAME);
            }
        }

        private void validatePassword()
        {
            if (String.IsNullOrEmpty(this.password.Trim()))
            {
                this.errorMessages.Add(UIMessages.INVALID_PASSWORD);
            }
        }

        private void validateFirstName()
        {
            if (String.IsNullOrEmpty(this.firstName.Trim()))
            {
                this.errorMessages.Add(UIMessages.INVALID_FIRST_NAME);
            }
        }

        private void validateLastName()
        {
            if (String.IsNullOrEmpty(this.lastName.Trim()))
            {
                this.errorMessages.Add(UIMessages.INVALID_LAST_NAME);
            }
        }
        private void validateStreetAddress()
        {
            if (String.IsNullOrEmpty(this.address1.Trim()))
            {
                this.errorMessages.Add(UIMessages.INVALID_STREET_ADDRESS);
            }
        }

        private void validateCity()
        {
            if (String.IsNullOrEmpty(this.city.Trim()))
            {
                this.errorMessages.Add(UIMessages.INVALID_CITY);
            }
        }

        private void validateState()
        {
            if (String.IsNullOrEmpty(this.state.Trim()))
            {
                this.errorMessages.Add(UIMessages.INVALID_STATE);
            }
        }

        private void validateZip()
        {
            if (this.zip == Constants.Constants.INVALID_ZIP)
            {
                this.errorMessages.Add(UIMessages.INVALID_ZIP);
            }
        }

        private void validatePhone()
        {
            if (String.IsNullOrEmpty(this.gender.Trim()))
            {
                this.errorMessages.Add(UIMessages.INVALID_PHONE);
            }
        }

        private void validateGender()
        {
            if (String.IsNullOrEmpty(this.gender.Trim()))
            {
                this.errorMessages.Add(UIMessages.INVALID_GENDER);
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

        private void textBoxZip_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verify that the pressed key isn't CTRL or any non-numeric digit
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void textBoxPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verify that the pressed key isn't CTRL or any non-numeric digit
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
    }
}
