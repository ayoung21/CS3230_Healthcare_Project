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
            this.button1 = new System.Windows.Forms.Button();
            this.buttonEditPatient = new System.Windows.Forms.Button();
            this.buttonDeletePatient = new System.Windows.Forms.Button();
            this.buttonAddPatient = new System.Windows.Forms.Button();
            this.tabAppointments = new System.Windows.Forms.TabPage();
            this.tabSearch = new System.Windows.Forms.TabPage();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.dateTimePickerDob = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxFirstName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxLastName = new System.Windows.Forms.TextBox();
            this.loggedInUser = new System.Windows.Forms.Label();
            this.logOut = new System.Windows.Forms.Button();
            this.appComponents.SuspendLayout();
            this.tabPatients.SuspendLayout();
            this.tabSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // appComponents
            // 
            this.appComponents.Controls.Add(this.tabPatients);
            this.appComponents.Controls.Add(this.tabAppointments);
            this.appComponents.Controls.Add(this.tabSearch);
            this.appComponents.Location = new System.Drawing.Point(16, 50);
            this.appComponents.Margin = new System.Windows.Forms.Padding(4);
            this.appComponents.Name = "appComponents";
            this.appComponents.SelectedIndex = 0;
            this.appComponents.Size = new System.Drawing.Size(1695, 807);
            this.appComponents.TabIndex = 0;
            // 
            // tabPatients
            // 
            this.tabPatients.Controls.Add(this.button1);
            this.tabPatients.Controls.Add(this.buttonEditPatient);
            this.tabPatients.Controls.Add(this.buttonDeletePatient);
            this.tabPatients.Controls.Add(this.buttonAddPatient);
            this.tabPatients.Location = new System.Drawing.Point(4, 25);
            this.tabPatients.Margin = new System.Windows.Forms.Padding(4);
            this.tabPatients.Name = "tabPatients";
            this.tabPatients.Padding = new System.Windows.Forms.Padding(4);
            this.tabPatients.Size = new System.Drawing.Size(1687, 778);
            this.tabPatients.TabIndex = 0;
            this.tabPatients.Text = "Patients";
            this.tabPatients.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1496, 159);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(147, 28);
            this.button1.TabIndex = 3;
            this.button1.Text = "Add Appointment";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // buttonEditPatient
            // 
            this.buttonEditPatient.Location = new System.Drawing.Point(1496, 86);
            this.buttonEditPatient.Margin = new System.Windows.Forms.Padding(4);
            this.buttonEditPatient.Name = "buttonEditPatient";
            this.buttonEditPatient.Size = new System.Drawing.Size(147, 28);
            this.buttonEditPatient.TabIndex = 2;
            this.buttonEditPatient.Text = "Edit Patient";
            this.buttonEditPatient.UseVisualStyleBackColor = true;
            // 
            // buttonDeletePatient
            // 
            this.buttonDeletePatient.Location = new System.Drawing.Point(1496, 123);
            this.buttonDeletePatient.Margin = new System.Windows.Forms.Padding(4);
            this.buttonDeletePatient.Name = "buttonDeletePatient";
            this.buttonDeletePatient.Size = new System.Drawing.Size(147, 28);
            this.buttonDeletePatient.TabIndex = 1;
            this.buttonDeletePatient.Text = "Delete Patient";
            this.buttonDeletePatient.UseVisualStyleBackColor = true;
            this.buttonDeletePatient.Click += new System.EventHandler(this.buttonDeletePatient_Click);
            // 
            // buttonAddPatient
            // 
            this.buttonAddPatient.Location = new System.Drawing.Point(1496, 50);
            this.buttonAddPatient.Margin = new System.Windows.Forms.Padding(4);
            this.buttonAddPatient.Name = "buttonAddPatient";
            this.buttonAddPatient.Size = new System.Drawing.Size(147, 28);
            this.buttonAddPatient.TabIndex = 0;
            this.buttonAddPatient.Text = "Add Patient";
            this.buttonAddPatient.UseVisualStyleBackColor = true;
            this.buttonAddPatient.Click += new System.EventHandler(this.buttonAddPerson_Click);
            // 
            // tabAppointments
            // 
            this.tabAppointments.Location = new System.Drawing.Point(4, 25);
            this.tabAppointments.Margin = new System.Windows.Forms.Padding(4);
            this.tabAppointments.Name = "tabAppointments";
            this.tabAppointments.Padding = new System.Windows.Forms.Padding(4);
            this.tabAppointments.Size = new System.Drawing.Size(1687, 778);
            this.tabAppointments.TabIndex = 1;
            this.tabAppointments.Text = "Appointments";
            this.tabAppointments.UseVisualStyleBackColor = true;
            // 
            // tabSearch
            // 
            this.tabSearch.Controls.Add(this.buttonSearch);
            this.tabSearch.Controls.Add(this.dateTimePickerDob);
            this.tabSearch.Controls.Add(this.label3);
            this.tabSearch.Controls.Add(this.label2);
            this.tabSearch.Controls.Add(this.textBoxFirstName);
            this.tabSearch.Controls.Add(this.label1);
            this.tabSearch.Controls.Add(this.textBoxLastName);
            this.tabSearch.Location = new System.Drawing.Point(4, 25);
            this.tabSearch.Name = "tabSearch";
            this.tabSearch.Padding = new System.Windows.Forms.Padding(3);
            this.tabSearch.Size = new System.Drawing.Size(1687, 778);
            this.tabSearch.TabIndex = 2;
            this.tabSearch.Text = "Search";
            this.tabSearch.UseVisualStyleBackColor = true;
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(758, 14);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(75, 23);
            this.buttonSearch.TabIndex = 6;
            this.buttonSearch.Text = "Search";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // dateTimePickerDob
            // 
            this.dateTimePickerDob.Checked = false;
            this.dateTimePickerDob.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerDob.Location = new System.Drawing.Point(607, 14);
            this.dateTimePickerDob.Name = "dateTimePickerDob";
            this.dateTimePickerDob.ShowCheckBox = true;
            this.dateTimePickerDob.Size = new System.Drawing.Size(131, 22);
            this.dateTimePickerDob.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(564, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "DOB";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(281, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "First Name";
            // 
            // textBoxFirstName
            // 
            this.textBoxFirstName.Location = new System.Drawing.Point(360, 14);
            this.textBoxFirstName.Name = "textBoxFirstName";
            this.textBoxFirstName.Size = new System.Drawing.Size(149, 22);
            this.textBoxFirstName.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Last Name";
            // 
            // textBoxLastName
            // 
            this.textBoxLastName.Location = new System.Drawing.Point(97, 14);
            this.textBoxLastName.Name = "textBoxLastName";
            this.textBoxLastName.Size = new System.Drawing.Size(149, 22);
            this.textBoxLastName.TabIndex = 0;
            // 
            // loggedInUser
            // 
            this.loggedInUser.AutoSize = true;
            this.loggedInUser.Location = new System.Drawing.Point(1305, 11);
            this.loggedInUser.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.loggedInUser.MinimumSize = new System.Drawing.Size(400, 0);
            this.loggedInUser.Name = "loggedInUser";
            this.loggedInUser.Size = new System.Drawing.Size(400, 16);
            this.loggedInUser.TabIndex = 0;
            this.loggedInUser.Text = "Hello, PERSON";
            this.loggedInUser.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // logOut
            // 
            this.logOut.Location = new System.Drawing.Point(1611, 31);
            this.logOut.Margin = new System.Windows.Forms.Padding(4);
            this.logOut.Name = "logOut";
            this.logOut.Size = new System.Drawing.Size(100, 28);
            this.logOut.TabIndex = 1;
            this.logOut.Text = "Log Out";
            this.logOut.UseVisualStyleBackColor = true;
            this.logOut.Click += new System.EventHandler(this.logOut_Click);
            // 
            // MainApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1727, 873);
            this.Controls.Add(this.logOut);
            this.Controls.Add(this.loggedInUser);
            this.Controls.Add(this.appComponents);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainApp";
            this.Text = "Healthcare System";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Wrapper_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.appComponents.ResumeLayout(false);
            this.tabPatients.ResumeLayout(false);
            this.tabSearch.ResumeLayout(false);
            this.tabSearch.PerformLayout();
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
        private System.Windows.Forms.TabPage tabSearch;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxFirstName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxLastName;
        private System.Windows.Forms.DateTimePicker dateTimePickerDob;
    }
}