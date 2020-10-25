using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
            this.buttonSave.Enabled = detailsTabEditMode;
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

        }
    }
}
