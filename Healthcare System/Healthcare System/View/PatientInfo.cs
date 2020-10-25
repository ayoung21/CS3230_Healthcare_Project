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
using Healthcare_System.Model;

namespace Healthcare_System.View
{
    public partial class PatientInfo : Form
    {
        private Person patient;
        private bool detailsTabEditMode;

        public PatientInfo(Person patientInfo)
        {
            InitializeComponent();

            this.patient = patientInfo;
            this.detailsTabEditMode = false;

            this.EnableDetailsTabAllowEdit(false);
            this.hideDetailsTabErrorMessages();
            this.comboBoxStates.DataSource = Enum.GetValues(typeof(StateAbbreviations));
            this.buttonSave.Enabled = detailsTabEditMode;
            this.buttonCancel.Enabled = detailsTabEditMode;
            this.populateFields();
            
        }

        private void EnableDetailsTabAllowEdit(bool allowEdit)
        {
            // Patient Info
            this.textBoxFirstName.Enabled = allowEdit;
            this.textBoxLastName.Enabled = allowEdit;
            this.comboBoxGender.Enabled = allowEdit;
            this.dateTimeBirthday.Enabled = allowEdit;
            this.textBoxPhoneNumber.Enabled = allowEdit;

            // Patient Address
            this.textBoxAddressOne.Enabled = allowEdit;
            this.textBoxAddressTwo.Enabled = allowEdit;
            this.textBoxCity.Enabled = allowEdit;
            this.comboBoxStates.Enabled = allowEdit;
            this.textBoxZipCode.Enabled = allowEdit;
        }

        private void hideDetailsTabErrorMessages()
        {
            this.labelInvalidFirstName.Visible = false;
            this.labelInvalidLastName.Visible = false;
            this.labelInvalidAddressOne.Visible = false;
            this.labelInvalidCity.Visible = false;
            this.labelInvalidState.Visible = false;
            this.labelInvalidZipCode.Visible = false;
            this.labelInvalidPhoneNumber.Visible = false;
            this.labelInvalidBirthday.Visible = false;
            this.labelInvalidGender.Visible = false;
        }

        private void populateFields()
        {
            this.textBoxFirstName.Text = patient.FirstName;
            this.textBoxLastName.Text = patient.LastName;
            this.textBoxAddressOne.Text = patient.Address.StreetAddress;
            this.textBoxAddressTwo.Text = patient.Address.AddressLine2;
            this.textBoxCity.Text = patient.Address.City;
            this.comboBoxStates.SelectedItem = patient.Address.State;
            this.textBoxZipCode.Text = patient.Address.Zip.ToString();
            this.textBoxPhoneNumber.Text = patient.Phone;
            this.dateTimeBirthday.Value = patient.DateOfBirth;
            this.comboBoxGender.SelectedItem = (patient.Gender == Gender.M) ? "Male" : "Female";
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            this.EnableDetailsTabAllowEdit(true);

            this.buttonEdit.Enabled = false;
            this.buttonCancel.Enabled = true;
            this.buttonSave.Enabled = true;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.populateFields();
            this.EnableDetailsTabAllowEdit(false);
            this.hideDetailsTabErrorMessages();

            this.buttonEdit.Enabled = true;
            this.buttonCancel.Enabled = false;
            this.buttonSave.Enabled = false;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            this.hideDetailsTabErrorMessages();
            var validFields = this.validateDetailsTabFields();

            if (validFields)
            {
                this.buttonSave.Enabled = false;
                this.buttonCancel.Enabled = false;
                this.buttonEdit.Enabled = true;
                this.hideDetailsTabErrorMessages();

                // Update Person
                patient.FirstName = this.textBoxFirstName.Text;
                patient.LastName = this.textBoxLastName.Text;
                patient.Address.StreetAddress = this.textBoxAddressOne.Text;
                patient.Address.AddressLine2 = this.textBoxAddressTwo.Text;
                patient.Address.City = this.textBoxCity.Text;
                patient.Address.State = this.comboBoxStates.SelectedItem.ToString();
                patient.Address.Zip = Int32.Parse(this.textBoxZipCode.Text);
                patient.Phone = this.textBoxPhoneNumber.Text;
                patient.DateOfBirth = this.dateTimeBirthday.Value;
                patient.Gender = (this.comboBoxGender.SelectedItem.ToString().ToUpper().Equals("MALE"))
                    ? Gender.M
                    : Gender.F;

                // Update Database
                var isSuccessful = UserDAL.UpdateUser(patient);

                if (isSuccessful)
                {
                    // TODO: Need to refactor -- same logic as cancel button
                    // NOTE: this needs to be before message box
                    this.populateFields();
                    this.EnableDetailsTabAllowEdit(false);
                    this.hideDetailsTabErrorMessages();

                    this.buttonEdit.Enabled = true;
                    this.buttonCancel.Enabled = false;
                    this.buttonSave.Enabled = false;

                    MessageBox.Show("Patient has been updated!");
                }
            }
        }

        private bool validateDetailsTabFields()
        {
            var firstName = this.textBoxFirstName.Text;
            var lastName = this.textBoxLastName.Text;
            var addressOne = this.textBoxAddressOne.Text;
            // var addressTwo = this.textBoxAddressTwo.Text;
            var city = this.textBoxCity.Text;
            var state = (this.comboBoxStates.SelectedItem == null) ? "" : this.comboBoxStates.SelectedItem.ToString();
            var zipCode = (String.IsNullOrEmpty(this.textBoxZipCode.Text) || this.textBoxZipCode.Text.Length != 5) ? Constants.Constants.INVALID_ZIP : Int32.Parse(this.textBoxZipCode.Text);
            var phoneNumber = (String.IsNullOrEmpty(this.textBoxPhoneNumber.Text) || this.textBoxPhoneNumber.Text.Length != 10) ? "" : this.textBoxPhoneNumber.Text;
            var gender = (this.comboBoxGender.SelectedItem == null) ? "" : this.comboBoxGender.SelectedItem.ToString();
            // var dateOfBirth = this.dateTimeBirthday.Value;

            var validFirstName = !String.IsNullOrEmpty(firstName.Trim());
            var validLastName = !String.IsNullOrEmpty(lastName.Trim());
            var validAddressOne = !String.IsNullOrEmpty(addressOne.Trim());
            var validCity = !String.IsNullOrEmpty(city.Trim());
            var validState = !String.IsNullOrEmpty(state.Trim());
            var validZipCode = (zipCode != -1);
            var validPhoneNumber = !String.IsNullOrEmpty(phoneNumber.Trim());
            var validGender = !String.IsNullOrEmpty(gender.Trim());

            if (!validFirstName)
            {
                this.labelInvalidFirstName.Text = UIMessages.INVALID_FIRST_NAME;
                this.labelInvalidFirstName.Visible = true;
            }

            if (!validLastName)
            {
                this.labelInvalidLastName.Text = UIMessages.INVALID_LAST_NAME;
                this.labelInvalidLastName.Visible = true;
            }

            if (!validAddressOne)
            {
                this.labelInvalidAddressOne.Text = UIMessages.INVALID_STREET_ADDRESS;
                this.labelInvalidAddressOne.Visible = true;
            }

            if (!validCity)
            {
                this.labelInvalidCity.Text = UIMessages.INVALID_CITY;
                this.labelInvalidCity.Visible = true;
            }

            if (!validState)
            {
                this.labelInvalidState.Text = UIMessages.INVALID_STATE;
                this.labelInvalidState.Visible = true;
            }

            if (!validZipCode)
            {
                this.labelInvalidZipCode.Text = UIMessages.INVALID_ZIP;
                this.labelInvalidZipCode.Visible = true;
            }

            if (!validPhoneNumber)
            {
                this.labelInvalidPhoneNumber.Text = UIMessages.INVALID_PHONE;
                this.labelInvalidPhoneNumber.Visible = true;
            }

            if (!validGender)
            {
                this.labelInvalidGender.Text = UIMessages.INVALID_GENDER;
                this.labelInvalidGender.Visible = true;
            }

            return (validFirstName &&
                    validLastName &&
                    validAddressOne &&
                    validCity &&
                    validState &&
                    validZipCode &&
                    validPhoneNumber &&
                    validGender);
        }
    }
}
