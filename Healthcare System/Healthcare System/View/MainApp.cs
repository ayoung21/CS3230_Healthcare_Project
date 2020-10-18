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

            if (this.isNurse)
            {
                this.userId = Helpers.GetUserIdFromTable(username, NurseDAL.tableName);
            } else
            {
                this.userId = Helpers.GetUserIdFromTable(username, AdministratorDAL.tableName);
            }

            this.loggedInUser.Text = $"Hello, {UserDAL.GetFullName(this.userId)}! ({username})";

            this.initializeColumnHeaders();
        }

        private void initializeColumnHeaders()
        {
            this.listViewPatients.Columns.Add("Last Name", 100);
            this.listViewPatients.Columns.Add("First Name", 100);
            this.listViewPatients.Columns.Add("Date of Birth", 100);
            this.listViewPatients.Columns.Add("Patient ID", 60);
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
            Console.WriteLine("SEARCH");
            DateTime? dob = null;
            if (this.dateTimePickerDob.Checked)
                dob = this.dateTimePickerDob.Value;

            List<Person> matches = PatientDAL.GetSearchResults(this.textBoxLastName.Text, this.textBoxFirstName.Text, dob);

            this.listViewPatients.Items.Clear();

            foreach(Person person in matches)
            {
                ListViewItem row = new ListViewItem(new[] {person.LastName, person.FirstName, person.DateOfBirth.ToString(), person.PatientID.ToString()});
                this.listViewPatients.Items.Add(row);
            }
        }
    }
}
