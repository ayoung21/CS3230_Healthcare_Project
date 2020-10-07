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
    public partial class formRegister : Form
    {
        public formRegister()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            var username = this.textBoxUsername.Text;
            var email = this.textBoxEmail.Text;
            var password = this.textBoxPassword.Text;
            UserDAL.Register(username, email, password);
        }
    }
}
