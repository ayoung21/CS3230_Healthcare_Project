using Healthcare_System.DAL;
using Healthcare_System.DAL.Helpers;
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
        private int patientId;
        private DateTime visitDateTime;
        private bool orderSubmitted;
        private LabTestOrder order;
        private bool currentTestHasResults;
        private int currentTestCode;

        #region Initialization
        public Labs(int patientId, DateTime visitDateTime)
        {
            InitializeComponent();

            this.patientId = patientId;
            this.visitDateTime = visitDateTime;

            this.dateTimePickerTest.CustomFormat = Constants.Constants.DATE_TIME_PICKER_FORMAT;

            this.switchMode(LabTestOrderDAL.HasTestOrder(patientId, visitDateTime));

            if (this.orderSubmitted)
            {
                this.order = LabTestOrderDAL.GetTestOrder(patientId, visitDateTime);
            }

            this.initializeTestsComboBox();
            this.initializeTestsListView();
        }

        private void initializeTestsComboBox()
        {
            List<LabTest> allTests = LabTestDAL.GetAllTests();
            this.comboBoxTestOrder.ValueMember = "Code";
            this.comboBoxTestOrder.DisplayMember = "CodeAndName";
            this.comboBoxTestOrder.DataSource = allTests;
        }

        private void initializeTestsListView()
        {
            this.listViewTests.FullRowSelect = true;
            this.listViewTests.Columns.Add("Code", 100);
            this.listViewTests.Columns.Add("Name", 400);
            
            if (this.orderSubmitted)
            {
                foreach (LabTest test in LabTestHelpers.GetTestsFromOrder(this.order.OrderId))
                {
                    this.addRowToTestsListView(test.Code, test.Name);
                }
            }
        }
        #endregion

        private void buttonAddTestToOrder_Click(object sender, EventArgs e)
        {
            int code = int.Parse(this.comboBoxTestOrder.SelectedValue.ToString());

            if (this.listViewTests.Items.ContainsKey(code.ToString()))
            {
                MessageBox.Show("This test has already been added to the order.");
            }
            else
            {
                string name = ((LabTest)this.comboBoxTestOrder.SelectedItem).Name;
                this.addRowToTestsListView(code, name);
            }
        }

        private void addRowToTestsListView(int code, string name)
        {
            ListViewItem row = new ListViewItem(new[] { code.ToString(), name });
            row.Name = code.ToString();
            row.Tag = code;
            this.listViewTests.Items.Add(row);
        }

        private void buttonRemoveTest_Click(object sender, EventArgs e)
        {
            if (this.listViewTests.SelectedIndices.Count > 0)
            {
                int selectedIndex = this.listViewTests.SelectedIndices[0];
                this.listViewTests.Items.RemoveAt(selectedIndex);
            }
            else
            {
                MessageBox.Show("Please select a test to remove");
            }
        }

        private void buttonSubmitOrder_Click(object sender, EventArgs e)
        {
            if (this.listViewTests.Items.Count > 0)
            {
                DialogResult okToProceed = MessageBox.Show("After submitting an order, you will NOT be able to edit it!", "Please confirm you would like to continue", MessageBoxButtons.YesNo);

                if (okToProceed == DialogResult.No)
                {
                    return;
                }

                if (LabTestOrderDAL.HasTestOrder(this.patientId, this.visitDateTime))
                {
                    MessageBox.Show("A test order has already been placed for this visit");
                    return;
                }

                List<int> testCodes = new List<int>();

                foreach (ListViewItem item in this.listViewTests.Items)
                {
                    int code = int.Parse(item.Tag.ToString());
                    testCodes.Add(code);
                }

                int orderId = LabTestHelpers.CreateTestOrder(this.patientId, this.visitDateTime, testCodes);

                if (orderId == -1)
                {
                    MessageBox.Show("Creating test order failed");
                }
                else
                {
                    this.switchMode(true);
                }
            }
            else
            {
                MessageBox.Show("Please add at least one test to the order");
            }
        }

        private void switchMode(bool orderSubmitted)
        {
            this.orderSubmitted = orderSubmitted;

            //Hide if order submitted
            this.buttonRemoveTest.Visible = !orderSubmitted;
            this.buttonSubmitOrder.Visible = !orderSubmitted;
            this.groupBoxOrderTest.Visible = !orderSubmitted;

            //Show if order submitted
            this.buttonEditResults.Visible = orderSubmitted;
            this.groupBoxResults.Visible = orderSubmitted;
        }

        private void listViewTests_MouseUp(object sender, MouseEventArgs e)
        {
            if (this.listViewTests.SelectedItems.Count > 0)
            {
                int testCode = Convert.ToInt32(this.listViewTests.SelectedItems[0].Tag);
                this.currentTestCode = testCode;
                LabTestResults results = LabTestResultDAL.GetResults(this.order.OrderId, testCode);

                if (results != null)
                {
                    this.currentTestHasResults = true;
                    this.textBoxResults.Text = results.Results;
                    this.checkBoxAbnormal.Checked = results.IsAbnormal;
                    this.dateTimePickerTest.Value = results.TakenOn;
                }
                else
                {
                    this.currentTestHasResults = false;
                    this.resetResults();
                }
                
            }
        }

        private void buttonEditResults_Click(object sender, EventArgs e)
        {
            if (this.listViewTests.SelectedIndices.Count > 0)
            {
                this.listViewTests.Enabled = false;
                this.buttonEditResults.Enabled = false;
                this.groupBoxResults.Enabled = true;
            }
            else
            {
                MessageBox.Show("Please select a test to edit results for");
            }
        }

        private void buttonCancelEditResults_Click(object sender, EventArgs e)
        {
            this.resetResults();
        }

        private void buttonSaveResults_Click(object sender, EventArgs e)
        {
            if (this.currentTestHasResults)
            {
                bool successful = LabTestResultDAL.UpdateResults(this.order.OrderId, this.currentTestCode, this.textBoxResults.Text, this.checkBoxAbnormal.Checked, this.dateTimePickerTest.Value);

                if (!successful)
                {
                    MessageBox.Show("Updating test results failed!");
                    return;
                }
            }
            else
            {
                bool successful = LabTestResultDAL.AddResults(this.order.OrderId, this.currentTestCode, this.textBoxResults.Text, this.checkBoxAbnormal.Checked, this.dateTimePickerTest.Value);

                if (!successful)
                {
                    MessageBox.Show("Adding test results failed!");
                    return;
                }
            }

            this.resetResults();
        }

        private void resetResults()
        {
            this.groupBoxResults.Enabled = false;
            this.textBoxResults.Clear();
            this.checkBoxAbnormal.Checked = false;
            this.dateTimePickerTest.Value = DateTime.Now;
            this.listViewTests.Enabled = true;
            this.buttonEditResults.Enabled = true;
        }
    }
}
