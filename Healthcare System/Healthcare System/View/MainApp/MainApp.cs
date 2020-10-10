using Healthcare_System.DAL;
using Healthcare_System.View.MainApp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Healthcare_System.View
{
    public partial class Wrapper : Form
    {
        private LoginForm loginForm;
        private int userId;
        private bool isNurse;
        private bool isAdministrator;

        public Wrapper(string username, LoginForm loginForm)
        {
            this.loginForm = loginForm;
            this.loginForm.Hide();
            InitializeComponent();
            this.isNurse = Helpers.IsUsernameInTable(username, NurseDAL.tableName);
            this.isAdministrator = Helpers.IsUsernameInTable(username, AdministratorDAL.tableName);

            if (this.isNurse)
            {
                this.userId = Helpers.GetUserIdFromTable(username, NurseDAL.tableName);
            } else
            {
                this.userId = Helpers.GetUserIdFromTable(username, AdministratorDAL.tableName);
            }

            this.loggedInUser.Text = $"Hello, {UserDAL.GetFullName(this.userId)}! ({username})";
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
            ManagePatient managePersonForm = new ManagePatient(true);
            managePersonForm.ShowDialog();
        }

        private void Wrapper_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.loginForm.Show();
        }

        private void buttonDeletePatient_Click(object sender, EventArgs e)
        {
            //TODO handle deleting patients (must make sure patient has no appointments)
        }
    }
}
