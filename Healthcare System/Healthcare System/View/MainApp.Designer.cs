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
            this.buttonAddPatient = new System.Windows.Forms.Button();
            this.loggedInUser = new System.Windows.Forms.Label();
            this.logOut = new System.Windows.Forms.Button();
            this.tabAppointments = new System.Windows.Forms.TabPage();
            this.buttonDeletePatient = new System.Windows.Forms.Button();
            this.buttonEditPatient = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
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
            // buttonAddPatient
            // 
            this.buttonAddPatient.Location = new System.Drawing.Point(1122, 41);
            this.buttonAddPatient.Name = "buttonAddPatient";
            this.buttonAddPatient.Size = new System.Drawing.Size(110, 23);
            this.buttonAddPatient.TabIndex = 0;
            this.buttonAddPatient.Text = "Add Patient";
            this.buttonAddPatient.UseVisualStyleBackColor = true;
            this.buttonAddPatient.Click += new System.EventHandler(this.buttonAddPerson_Click);
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
            // buttonEditPatient
            // 
            this.buttonEditPatient.Location = new System.Drawing.Point(1122, 70);
            this.buttonEditPatient.Name = "buttonEditPatient";
            this.buttonEditPatient.Size = new System.Drawing.Size(110, 23);
            this.buttonEditPatient.TabIndex = 2;
            this.buttonEditPatient.Text = "Edit Patient";
            this.buttonEditPatient.UseVisualStyleBackColor = true;
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
            // Wrapper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1295, 709);
            this.Controls.Add(this.logOut);
            this.Controls.Add(this.loggedInUser);
            this.Controls.Add(this.appComponents);
            this.Name = "Wrapper";
            this.Text = "Healthcare System";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Wrapper_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.appComponents.ResumeLayout(false);
            this.tabPatients.ResumeLayout(false);
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
    }
}