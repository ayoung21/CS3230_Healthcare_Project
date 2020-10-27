namespace Healthcare_System.View
{
    partial class MainApp
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.appComponents = new System.Windows.Forms.TabControl();
            this.tabPatients = new System.Windows.Forms.TabPage();
            this.listViewPatients = new System.Windows.Forms.ListView();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.dateTimePickerDob = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxFirstName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxLastName = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonEditPatient = new System.Windows.Forms.Button();
            this.buttonDeletePatient = new System.Windows.Forms.Button();
            this.buttonAddPatient = new System.Windows.Forms.Button();
            this.tabAppointments = new System.Windows.Forms.TabPage();
            this.loggedInUser = new System.Windows.Forms.Label();
            this.logOut = new System.Windows.Forms.Button();
            this.appComponents.SuspendLayout();
            this.tabPatients.SuspendLayout();
            this.SuspendLayout();
            // 
            // appComponents
            // 
            this.appComponents.Controls.Add(this.tabPatients);
            this.appComponents.Controls.Add(this.tabAppointments);
            this.appComponents.Location = new System.Drawing.Point(12, 41);
            this.appComponents.Name = "appComponents";
            this.appComponents.SelectedIndex = 0;
            this.appComponents.Size = new System.Drawing.Size(1271, 656);
            this.appComponents.TabIndex = 0;
            // 
            // tabPatients
            // 
            this.tabPatients.Controls.Add(this.listViewPatients);
            this.tabPatients.Controls.Add(this.buttonSearch);
            this.tabPatients.Controls.Add(this.dateTimePickerDob);
            this.tabPatients.Controls.Add(this.label3);
            this.tabPatients.Controls.Add(this.label2);
            this.tabPatients.Controls.Add(this.textBoxFirstName);
            this.tabPatients.Controls.Add(this.label1);
            this.tabPatients.Controls.Add(this.textBoxLastName);
            this.tabPatients.Controls.Add(this.button1);
            this.tabPatients.Controls.Add(this.buttonEditPatient);
            this.tabPatients.Controls.Add(this.buttonDeletePatient);
            this.tabPatients.Controls.Add(this.buttonAddPatient);
            this.tabPatients.Location = new System.Drawing.Point(4, 22);
            this.tabPatients.Name = "tabPatients";
            this.tabPatients.Padding = new System.Windows.Forms.Padding(3);
            this.tabPatients.Size = new System.Drawing.Size(1263, 630);
            this.tabPatients.TabIndex = 0;
            this.tabPatients.Text = "Patients";
            this.tabPatients.UseVisualStyleBackColor = true;
            // 
            // listViewPatients
            // 
            this.listViewPatients.AllowColumnReorder = true;
            this.listViewPatients.HideSelection = false;
            this.listViewPatients.Location = new System.Drawing.Point(16, 40);
            this.listViewPatients.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.listViewPatients.Name = "listViewPatients";
            this.listViewPatients.Size = new System.Drawing.Size(1083, 525);
            this.listViewPatients.TabIndex = 21;
            this.listViewPatients.UseCompatibleStateImageBehavior = false;
            this.listViewPatients.View = System.Windows.Forms.View.Details;
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(569, 9);
            this.buttonSearch.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(56, 19);
            this.buttonSearch.TabIndex = 20;
            this.buttonSearch.Text = "Search";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // dateTimePickerDob
            // 
            this.dateTimePickerDob.Checked = false;
            this.dateTimePickerDob.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerDob.Location = new System.Drawing.Point(455, 10);
            this.dateTimePickerDob.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dateTimePickerDob.Name = "dateTimePickerDob";
            this.dateTimePickerDob.ShowCheckBox = true;
            this.dateTimePickerDob.Size = new System.Drawing.Size(99, 20);
            this.dateTimePickerDob.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(423, 14);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "DOB";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(211, 14);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "First Name";
            // 
            // textBoxFirstName
            // 
            this.textBoxFirstName.Location = new System.Drawing.Point(270, 12);
            this.textBoxFirstName.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.textBoxFirstName.Name = "textBoxFirstName";
            this.textBoxFirstName.Size = new System.Drawing.Size(113, 20);
            this.textBoxFirstName.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Last Name";
            // 
            // textBoxLastName
            // 
            this.textBoxLastName.Location = new System.Drawing.Point(73, 12);
            this.textBoxLastName.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.textBoxLastName.Name = "textBoxLastName";
            this.textBoxLastName.Size = new System.Drawing.Size(113, 20);
            this.textBoxLastName.TabIndex = 14;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1122, 129);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(110, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Add Appointment";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // buttonEditPatient
            // 
            this.buttonEditPatient.Location = new System.Drawing.Point(1122, 70);
            this.buttonEditPatient.Name = "buttonEditPatient";
            this.buttonEditPatient.Size = new System.Drawing.Size(110, 23);
            this.buttonEditPatient.TabIndex = 2;
            this.buttonEditPatient.Text = "View Patient";
            this.buttonEditPatient.UseVisualStyleBackColor = true;
            this.buttonEditPatient.Click += new System.EventHandler(this.buttonEditPatient_Click);
            // 
            // buttonDeletePatient
            // 
            this.buttonDeletePatient.Location = new System.Drawing.Point(1122, 100);
            this.buttonDeletePatient.Name = "buttonDeletePatient";
            this.buttonDeletePatient.Size = new System.Drawing.Size(110, 23);
            this.buttonDeletePatient.TabIndex = 1;
            this.buttonDeletePatient.Text = "Delete Patient";
            this.buttonDeletePatient.UseVisualStyleBackColor = true;
            this.buttonDeletePatient.Click += new System.EventHandler(this.buttonDeletePatient_Click);
            // 
            // buttonAddPatient
            // 
            this.buttonAddPatient.Location = new System.Drawing.Point(1122, 40);
            this.buttonAddPatient.Name = "buttonAddPatient";
            this.buttonAddPatient.Size = new System.Drawing.Size(110, 23);
            this.buttonAddPatient.TabIndex = 0;
            this.buttonAddPatient.Text = "Add Patient";
            this.buttonAddPatient.UseVisualStyleBackColor = true;
            this.buttonAddPatient.Click += new System.EventHandler(this.buttonAddPerson_Click);
            // 
            // tabAppointments
            // 
            this.tabAppointments.Location = new System.Drawing.Point(4, 22);
            this.tabAppointments.Name = "tabAppointments";
            this.tabAppointments.Padding = new System.Windows.Forms.Padding(3);
            this.tabAppointments.Size = new System.Drawing.Size(1263, 630);
            this.tabAppointments.TabIndex = 1;
            this.tabAppointments.Text = "Appointments";
            this.tabAppointments.UseVisualStyleBackColor = true;
            // 
            // loggedInUser
            // 
            this.loggedInUser.AutoSize = true;
            this.loggedInUser.Location = new System.Drawing.Point(979, 9);
            this.loggedInUser.MinimumSize = new System.Drawing.Size(300, 0);
            this.loggedInUser.Name = "loggedInUser";
            this.loggedInUser.Size = new System.Drawing.Size(300, 13);
            this.loggedInUser.TabIndex = 0;
            this.loggedInUser.Text = "Hello, PERSON";
            this.loggedInUser.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // logOut
            // 
            this.logOut.Location = new System.Drawing.Point(1208, 25);
            this.logOut.Name = "logOut";
            this.logOut.Size = new System.Drawing.Size(75, 23);
            this.logOut.TabIndex = 1;
            this.logOut.Text = "Log Out";
            this.logOut.UseVisualStyleBackColor = true;
            this.logOut.Click += new System.EventHandler(this.logOut_Click);
            // 
            // MainApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1295, 709);
            this.Controls.Add(this.logOut);
            this.Controls.Add(this.loggedInUser);
            this.Controls.Add(this.appComponents);
            this.Name = "MainApp";
            this.Text = "Healthcare System";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Wrapper_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.appComponents.ResumeLayout(false);
            this.tabPatients.ResumeLayout(false);
            this.tabPatients.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl appComponents;
        private System.Windows.Forms.TabPage tabPatients;
        private System.Windows.Forms.Label loggedInUser;
        private System.Windows.Forms.Button logOut;
        private System.Windows.Forms.Button buttonAddPatient;
        private System.Windows.Forms.TabPage tabAppointments;
        private System.Windows.Forms.Button buttonDeletePatient;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonEditPatient;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.DateTimePicker dateTimePickerDob;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxFirstName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxLastName;
        private System.Windows.Forms.ListView listViewPatients;
    }
}