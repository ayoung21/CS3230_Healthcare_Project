using Healthcare_System.DAL;
using Healthcare_System.Model;
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
    public partial class Labs : Form
    {
        public Labs()
        {
            InitializeComponent();

            this.dateTimePickerTest.CustomFormat = Constants.Constants.DATE_TIME_PICKER_FORMAT;

            List<LabTest> allTests = LabTestDAL.GetAllTests();
            this.comboBoxTestOrder.ValueMember = "Code";
            this.comboBoxTestOrder.DisplayMember = "Name";
            this.comboBoxTestOrder.DataSource = allTests;
        }

        private void buttonAddTestToOrder_Click(object sender, EventArgs e)
        {

        }

        private void buttonRemoveTest_Click(object sender, EventArgs e)
        {

        }

        private void buttonEditResults_Click(object sender, EventArgs e)
        {

        }

        private void buttonSubmitOrder_Click(object sender, EventArgs e)
        {

        }
    }
}
