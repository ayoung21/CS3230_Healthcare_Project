using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Healthcare_System.DAL;
using Healthcare_System.Messages;
using Healthcare_System.Model;

namespace Healthcare_System
{
    public enum FormType
    {
        Register,
        Update
    }

    /// <summary>
    /// Controller for the registration form.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class RegisterForm : Form
    {
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
        private PersonRoles roleRegisteringFor;

        public Form LoginForm { get; set; }

        private IList<string> errorMessages;

        private FormType formType;

        private Person person;

        /// <summary>
        ///     Initializes a new instance of the <see cref="RegisterForm" /> class.
        ///     Shows username and password fields if the form is being opened to register the initial admin account.
        /// </summary>
        /// <param name="role">The role.</param>
        /// <exception cref="ArgumentOutOfRangeException">This form only supports registering administrators and patients</exception>
        public RegisterForm(PersonRoles roleRegisteringFor = PersonRoles.Patient)
        {
            InitializeComponent();
            this.labelErrorMessages.Hide();
            this.errorMessages = new List<string>();
            this.roleRegisteringFor = roleRegisteringFor;

            LoginForm?.Hide();

            this.formType = FormType.Register;

            if (this.roleRegisteringFor == PersonRoles.Patient)
            {
                this.textBoxUsername.Hide();
                this.textBoxPassword.Hide();

                this.usernameLabel.Hide();
                this.passwordLabel.Hide();
            }
        }

        public RegisterForm(Person person)
        {
            InitializeComponent();
            this.labelErrorMessages.Hide();
            this.errorMessages = new List<string>();
            this.roleRegisteringFor = PersonRoles.Patient;

            LoginForm?.Hide();

            this.formType = FormType.Update;

            this.textBoxUsername.Hide();
            this.textBoxPassword.Hide();

            this.usernameLabel.Hide();
            this.passwordLabel.Hide();

            this.btnRegister.Text = "UPDATE!";

            this.person = person;
            this.populateFields(person);
        }

        public void populateFields(Person person)
        {
            this.textBoxFirstName.Text = person.FirstName;
            this.textBoxLastName.Text = person.LastName;
            this.textBoxAddress1.Text = person.Address.StreetAddress;
            this.textBoxAddress2.Text = person.Address.AddressLine2;
            this.textBoxCity.Text = person.Address.City;
            this.comboBoxStates.SelectedItem = person.Address.State;
            this.textBoxZip.Text = person.Address.Zip.ToString();
            this.textBoxPhone.Text = person.Phone;
            this.dateTimePicker.Value = person.DateOfBirth;
            this.comboBoxGender.SelectedItem = (person.Gender == Gender.MALE) ? "Male" : "Female";
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            this.errorMessages.Clear();

            if (this.formType == FormType.Register)
            {
                this.register();
            }
            else
            {
                this.updateInfo();
            }
        }

        private void updateInfo()
        {
            this.preValidate();
            this.validateFields();

            if (this.errorMessages.Count > 0)
            {
                this.displayErrorMessages();
            }
            else
            { 
                person.FirstName = this.firstName;
                person.LastName = this.lastName;
                person.Address.StreetAddress = this.address1;
                person.Address.AddressLine2 = this.address2;
                person.Address.City = this.city;
                person.Address.State = this.state;
                person.Address.Zip = this.zip;
                person.Phone = this.phone;
                person.DateOfBirth = this.dateTimePicker.Value;
                person.Gender = (this.comboBoxGender.SelectedItem.ToString().ToUpper().Equals("MALE"))
                    ? Gender.MALE
                    : Gender.FEMALE;
                var isSuccessful = UserDAL.UpdateUser(person);

                if (isSuccessful)
                {
                    this.Close();
                }
            }
        }

        private void preValidate()
        {
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
        }

        private void register()
        {
            this.errorMessages.Clear();

            if (this.roleRegisteringFor == PersonRoles.Administrator)
            {
                this.username = this.textBoxUsername.Text;
                this.password = this.textBoxPassword.Text;
            }

            this.preValidate();

            this.validateFields();


            if (string.IsNullOrEmpty(address2))
            {
                address2 = null;
            }


            if (this.errorMessages.Count > 0)
            {
                this.displayErrorMessages();
            }
            else
            {
                if (this.roleRegisteringFor == PersonRoles.Administrator)
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
                this.Close();
            }
        }

        private void formRegister_Load(object sender, EventArgs e)
        {

        }

        private void validateFields()
        {
            if (this.roleRegisteringFor != PersonRoles.Patient)
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
            if (String.IsNullOrEmpty(this.phone.Trim()))
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
