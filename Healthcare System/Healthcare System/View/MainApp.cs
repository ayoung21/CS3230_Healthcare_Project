using Healthcare_System.DAL;
using Healthcare_System.Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Healthcare_System.View
{
    /// <summary>
    /// Controller for the main app wrapper.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class MainApp : Form
    {
        private LoginForm loginForm;
        private int userId;
        private bool isNurse;
        private bool isAdmin;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainApp"/> class.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="loginForm">The login form.</param>
        public MainApp(string username, LoginForm loginForm)
        {
            this.loginForm = loginForm;
            this.loginForm.Hide();
            InitializeComponent();
            this.isNurse = Helpers.IsUsernameInTable(username, NurseDAL.tableName);
            this.isAdmin = Helpers.IsUsernameInTable(username, AdministratorDAL.tableName);

            if (this.isNurse && !this.isAdmin)
            {
                this.userId = Helpers.GetUserIdFromTable(username, NurseDAL.tableName);
                this.appComponents.TabPages.Remove(this.tabAdmin);
            } else if (this.isAdmin && !this.isNurse)
            {
                this.userId = Helpers.GetUserIdFromTable(username, AdministratorDAL.tableName);
                this.appComponents.TabPages.Remove(this.tabPatients);
            }

            this.loggedInUser.Text = $"Hello, {UserDAL.GetFullName(this.userId)}! ({username})";

            this.initializeColumnHeaders();

            this.listViewPatients.FullRowSelect = true;
            this.labelAdminQuery.Visible = false;
        }

        private void initializeColumnHeaders()
        {
            this.listViewPatients.Columns.Add("Last Name", 100);
            this.listViewPatients.Columns.Add("First Name", 100);
            this.listViewPatients.Columns.Add("Date of Birth", 100);
            this.listViewPatients.Columns.Add("Patient ID", 60);

            this.listViewAppointmentsBetween.Columns.Add("Date / Time", 100);
            this.listViewAppointmentsBetween.Columns.Add("Patient ID", 100);
            this.listViewAppointmentsBetween.Columns.Add("First Name", 100);
            this.listViewAppointmentsBetween.Columns.Add("Last Name", 100);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void logOut_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonAddPerson_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            registerForm.ShowDialog();
        }

        private void Wrapper_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.loginForm.Show();
        }

        private void buttonDeletePatient_Click(object sender, EventArgs e)
        {
            //TODO handle deleting patients (must make sure patient has no appointments)
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            this.search();
        }

        private void search()
        {
            DateTime? dob = null;
            if (this.dateTimePickerDob.Checked)
                dob = this.dateTimePickerDob.Value;

            List<Person> matches = PatientDAL.GetSearchResults(this.textBoxLastName.Text, this.textBoxFirstName.Text, dob);

            this.listViewPatients.Items.Clear();

            foreach (Person person in matches)
            {
                ListViewItem row = new ListViewItem(new[] { person.LastName, person.FirstName, person.DateOfBirth.ToShortDateString(), person.PatientID.ToString() });
                this.listViewPatients.Items.Add(row);
            }
        }

        private void buttonEditPatient_Click(object sender, EventArgs e)
        {
            var isPatientSelected = (this.listViewPatients.SelectedItems.Count > 0) ? true : false;

            if (isPatientSelected)
            {
                // Get patient id
                var patientId = int.Parse(this.listViewPatients.SelectedItems[0].SubItems[3].Text);

                // Get patient user id
                var userId = int.Parse(PatientDAL.GetPatientUserId(patientId));

                // Get patient info
                var patientInfo = PatientDAL.GetPatient(userId, patientId);

                // Open multi-purpose register form
                // RegisterForm registerForm = new RegisterForm(patientInfo);
                // registerForm.ShowDialog();

                // Refresh?
                // this.search();

                PatientInfo patientInfoForm = new PatientInfo(patientInfo, this.userId);
                patientInfoForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select a patient if you wish to edit.");
            }
        }

        private void buttonClearSearchFields_Click(object sender, EventArgs e)
        {
            this.textBoxFirstName.Clear();
            this.textBoxLastName.Clear();
            this.dateTimePickerDob.Value = DateTime.Now;
            this.dateTimePickerDob.Checked = false;
            this.listViewPatients.Items.Clear();
        }

        private void buttonAdminQuery_Click(object sender, EventArgs e)
        {
            var query = this.textBoxAdminQuery.Text;
            var result = AdministratorDAL.Query(query);
            this.labelAdminQuery.Text = query;
            this.labelAdminQuery.Visible = true;
            this.textBoxAdminQuery.Text = "";

            this.dataGridView.DataSource = result;
        }

        private void buttonSearchAppointmentsBetween_Click(object sender, EventArgs e)
        {
            var dateTimeStart = this.dateTimePickerStartDate.Value;
            var dateTimeEnd = this.dateTimePickerEndDate.Value;
            var results = VisitDAL.GetAllVisitsBetween(dateTimeStart, dateTimeEnd);

            this.listViewAppointmentsBetween.Items.Clear();

            foreach (Visit currentVisit in results)
            {
                var patientUserId = Convert.ToInt32(PatientDAL.GetPatientUserId(currentVisit.PatientId));
                var patient = PatientDAL.GetPatient(patientUserId, currentVisit.PatientId);

                ListViewItem row = new ListViewItem(new[]
                {
                    currentVisit.AppointmentDateTime.ToString(),
                    currentVisit.PatientId.ToString(),
                    patient.FirstName,
                    patient.LastName

                });
                this.listViewAppointmentsBetween.Items.Add(row);
            }

        }
    }
}
