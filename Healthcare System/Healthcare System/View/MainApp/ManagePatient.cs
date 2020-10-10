using Healthcare_System.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Healthcare_System.View.MainApp
{
    public partial class ManagePatient : Form
    {
        private const int MIN_ZIP = 500;
        private const int MAX_ZIP = 99999;

        #region Form field aliases
        private string firstName 
        {
            get => this.textBoxFirstName.Text;
            set => this.textBoxFirstName.Text = value;
        }

        private string lastName
        {
            get => this.textBoxLastName.Text;
            set => this.textBoxLastName.Text = value;
        }

        private string address1
        {
            get => this.textBoxAddress1.Text;
            set => this.textBoxAddress2.Text = value;
        }

        private string address2
        {
            get => this.textBoxAddress2.Text;
            set => this.textBoxAddress2.Text = value;
        }

        private string city
        {
            get => this.textBoxCity.Text;
            set => this.textBoxCity.Text = value;
        }

        private string state
        {
            get => this.comboBoxState.Text;
            set
            {
                if (this.comboBoxState.Items.Contains(value))
                    this.comboBoxState.SelectedItem = value;
                else
                    throw new ArgumentException("state must be a valid 2-character abbreviation");
            }
        }

        private int zip
        {
            get => Int32.Parse(this.textBoxZip.Text);
            set
            {
                if (value >= MIN_ZIP && value <= MAX_ZIP)
                    this.textBoxZip.Text = value.ToString();
                else
                    throw new ArgumentException("zip must be 00500 through 99999");
            }
        }

        private string phone
        {
            get => this.textBoxPhone.Text;
            set => this.textBoxPhone.Text = value;
        }

        private DateTime dob
        {
            get => this.dateTimePickerDob.Value;
            set => this.dateTimePickerDob.Value = value;
        }

        private string gender
        {
            get => this.comboBoxGender.SelectedItem.ToString();
            set
            {
                if (value.ToUpper() == "MALE")
                    this.comboBoxGender.SelectedIndex = 0;
                else if (value.ToUpper() == "FEMALE")
                    this.comboBoxGender.SelectedIndex = 1;
                else
                    throw new ArgumentException("gender must be male or female (case insensitive)");
            }
        }
        #endregion

        private bool isAddingNewPerson;

        public ManagePatient(bool isAddingNewPerson)
        {
            InitializeComponent();
            this.isAddingNewPerson = isAddingNewPerson;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (isAddingNewPerson)
            {
                int userId = UserDAL.Register(this.firstName, this.lastName, this.city, this.state, this.zip, this.phone, this.dob, this.gender, this.address1, this.address2);

                if (!PatientDAL.Register(userId))
                    return; //TODO the current early returns should be error handling instead

                this.Close();
            }  
            else
            {
                //TODO handle editing existing patient
            }
                
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ManagePerson_Load(object sender, EventArgs e)
        {

        }
    }
}
