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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email = this.textBoxUsername.Text;
            string password = this.textBoxPassword.Text;
            Console.WriteLine($"AUTHENTICATE: {UserDAL.Authenticate(email, password)}");
        }

        private void labelRegister_Click(object sender, EventArgs e)
        {
            var registerForm = new formRegister();
            registerForm.Show();
        }
    }
}
