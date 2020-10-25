namespace Healthcare_System.View
{
    partial class PatientInfo
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
            this.textBoxFirstName = new System.Windows.Forms.TextBox();
            this.textBoxLastName = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabDetails = new System.Windows.Forms.TabPage();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxPhoneNumber = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.dateTimeBirthday = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxCity = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBoxStates = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxZipCode = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxAddressTwo = new System.Windows.Forms.TextBox();
            this.textBoxAddressOne = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxGender = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabAppointments = new System.Windows.Forms.TabPage();
            this.tabVisits = new System.Windows.Forms.TabPage();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.labelInvalidFirstName = new System.Windows.Forms.Label();
            this.labelInvalidBirthday = new System.Windows.Forms.Label();
            this.labelInvalidLastName = new System.Windows.Forms.Label();
            this.labelInvalidPhoneNumber = new System.Windows.Forms.Label();
            this.labelInvalidGender = new System.Windows.Forms.Label();
            this.labelInvalidAddressOne = new System.Windows.Forms.Label();
            this.labelInvalidCity = new System.Windows.Forms.Label();
            this.labelInvalidState = new System.Windows.Forms.Label();
            this.labelInvalidZipCode = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabDetails.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxFirstName
            // 
            this.textBoxFirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxFirstName.Location = new System.Drawing.Point(106, 22);
            this.textBoxFirstName.Name = "textBoxFirstName";
            this.textBoxFirstName.Size = new System.Drawing.Size(137, 26);
            this.textBoxFirstName.TabIndex = 0;
            // 
            // textBoxLastName
            // 
            this.textBoxLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxLastName.Location = new System.Drawing.Point(107, 98);
            this.textBoxLastName.Name = "textBoxLastName";
            this.textBoxLastName.Size = new System.Drawing.Size(137, 26);
            this.textBoxLastName.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabDetails);
            this.tabControl1.Controls.Add(this.tabAppointments);
            this.tabControl1.Controls.Add(this.tabVisits);
            this.tabControl1.Location = new System.Drawing.Point(13, 13);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(556, 702);
            this.tabControl1.TabIndex = 2;
            // 
            // tabDetails
            // 
            this.tabDetails.Controls.Add(this.buttonCancel);
            this.tabDetails.Controls.Add(this.labelInvalidGender);
            this.tabDetails.Controls.Add(this.buttonSave);
            this.tabDetails.Controls.Add(this.buttonEdit);
            this.tabDetails.Controls.Add(this.labelInvalidPhoneNumber);
            this.tabDetails.Controls.Add(this.labelInvalidLastName);
            this.tabDetails.Controls.Add(this.labelInvalidBirthday);
            this.tabDetails.Controls.Add(this.labelInvalidFirstName);
            this.tabDetails.Controls.Add(this.label10);
            this.tabDetails.Controls.Add(this.textBoxPhoneNumber);
            this.tabDetails.Controls.Add(this.label9);
            this.tabDetails.Controls.Add(this.dateTimeBirthday);
            this.tabDetails.Controls.Add(this.groupBox1);
            this.tabDetails.Controls.Add(this.comboBoxGender);
            this.tabDetails.Controls.Add(this.label5);
            this.tabDetails.Controls.Add(this.label2);
            this.tabDetails.Controls.Add(this.label1);
            this.tabDetails.Controls.Add(this.textBoxFirstName);
            this.tabDetails.Controls.Add(this.textBoxLastName);
            this.tabDetails.Location = new System.Drawing.Point(4, 22);
            this.tabDetails.Name = "tabDetails";
            this.tabDetails.Padding = new System.Windows.Forms.Padding(3);
            this.tabDetails.Size = new System.Drawing.Size(548, 676);
            this.tabDetails.TabIndex = 0;
            this.tabDetails.Text = "Details";
            this.tabDetails.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(299, 98);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 20);
            this.label10.TabIndex = 15;
            this.label10.Text = "Phone";
            // 
            // textBoxPhoneNumber
            // 
            this.textBoxPhoneNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPhoneNumber.Location = new System.Drawing.Point(399, 98);
            this.textBoxPhoneNumber.Name = "textBoxPhoneNumber";
            this.textBoxPhoneNumber.Size = new System.Drawing.Size(137, 26);
            this.textBoxPhoneNumber.TabIndex = 14;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(298, 25);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 20);
            this.label9.TabIndex = 13;
            this.label9.Text = "Birthday";
            // 
            // dateTimeBirthday
            // 
            this.dateTimeBirthday.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimeBirthday.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimeBirthday.Location = new System.Drawing.Point(398, 22);
            this.dateTimeBirthday.Name = "dateTimeBirthday";
            this.dateTimeBirthday.Size = new System.Drawing.Size(137, 26);
            this.dateTimeBirthday.TabIndex = 12;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelInvalidZipCode);
            this.groupBox1.Controls.Add(this.labelInvalidState);
            this.groupBox1.Controls.Add(this.labelInvalidCity);
            this.groupBox1.Controls.Add(this.labelInvalidAddressOne);
            this.groupBox1.Controls.Add(this.textBoxCity);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.comboBoxStates);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.textBoxZipCode);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.textBoxAddressTwo);
            this.groupBox1.Controls.Add(this.textBoxAddressOne);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(11, 288);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(525, 250);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Address";
            // 
            // textBoxCity
            // 
            this.textBoxCity.Location = new System.Drawing.Point(15, 176);
            this.textBoxCity.Name = "textBoxCity";
            this.textBoxCity.Size = new System.Drawing.Size(218, 26);
            this.textBoxCity.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(15, 143);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 20);
            this.label8.TabIndex = 14;
            this.label8.Text = "City";
            // 
            // comboBoxStates
            // 
            this.comboBoxStates.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStates.FormattingEnabled = true;
            this.comboBoxStates.Items.AddRange(new object[] {
            "Male",
            "Female"});
            this.comboBoxStates.Location = new System.Drawing.Point(286, 174);
            this.comboBoxStates.Name = "comboBoxStates";
            this.comboBoxStates.Size = new System.Drawing.Size(69, 28);
            this.comboBoxStates.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(282, 143);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 20);
            this.label7.TabIndex = 11;
            this.label7.Text = "State";
            // 
            // textBoxZipCode
            // 
            this.textBoxZipCode.Location = new System.Drawing.Point(431, 174);
            this.textBoxZipCode.Name = "textBoxZipCode";
            this.textBoxZipCode.Size = new System.Drawing.Size(73, 26);
            this.textBoxZipCode.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(431, 141);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 20);
            this.label6.TabIndex = 9;
            this.label6.Text = "Zip Code";
            // 
            // textBoxAddressTwo
            // 
            this.textBoxAddressTwo.Location = new System.Drawing.Point(286, 66);
            this.textBoxAddressTwo.Name = "textBoxAddressTwo";
            this.textBoxAddressTwo.Size = new System.Drawing.Size(218, 26);
            this.textBoxAddressTwo.TabIndex = 6;
            // 
            // textBoxAddressOne
            // 
            this.textBoxAddressOne.Location = new System.Drawing.Point(15, 66);
            this.textBoxAddressOne.Name = "textBoxAddressOne";
            this.textBoxAddressOne.Size = new System.Drawing.Size(218, 26);
            this.textBoxAddressOne.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Address Line 1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(286, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Address Line 2";
            // 
            // comboBoxGender
            // 
            this.comboBoxGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxGender.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxGender.FormattingEnabled = true;
            this.comboBoxGender.Items.AddRange(new object[] {
            "Male",
            "Female"});
            this.comboBoxGender.Location = new System.Drawing.Point(106, 176);
            this.comboBoxGender.Name = "comboBoxGender";
            this.comboBoxGender.Size = new System.Drawing.Size(69, 28);
            this.comboBoxGender.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 176);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "Gender";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Last Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "First Name";
            // 
            // tabAppointments
            // 
            this.tabAppointments.Location = new System.Drawing.Point(4, 22);
            this.tabAppointments.Name = "tabAppointments";
            this.tabAppointments.Padding = new System.Windows.Forms.Padding(3);
            this.tabAppointments.Size = new System.Drawing.Size(562, 487);
            this.tabAppointments.TabIndex = 1;
            this.tabAppointments.Text = "Appointments";
            this.tabAppointments.UseVisualStyleBackColor = true;
            // 
            // tabVisits
            // 
            this.tabVisits.Location = new System.Drawing.Point(4, 22);
            this.tabVisits.Name = "tabVisits";
            this.tabVisits.Size = new System.Drawing.Size(562, 487);
            this.tabVisits.TabIndex = 2;
            this.tabVisits.Text = "Visits";
            this.tabVisits.UseVisualStyleBackColor = true;
            // 
            // buttonEdit
            // 
            this.buttonEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEdit.Location = new System.Drawing.Point(288, 631);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(121, 39);
            this.buttonEdit.TabIndex = 3;
            this.buttonEdit.Text = "Edit";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSave.Location = new System.Drawing.Point(415, 631);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(121, 39);
            this.buttonSave.TabIndex = 4;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.Location = new System.Drawing.Point(11, 631);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(121, 39);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // labelInvalidFirstName
            // 
            this.labelInvalidFirstName.AutoSize = true;
            this.labelInvalidFirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInvalidFirstName.ForeColor = System.Drawing.Color.Red;
            this.labelInvalidFirstName.Location = new System.Drawing.Point(8, 62);
            this.labelInvalidFirstName.Name = "labelInvalidFirstName";
            this.labelInvalidFirstName.Size = new System.Drawing.Size(96, 16);
            this.labelInvalidFirstName.TabIndex = 16;
            this.labelInvalidFirstName.Text = "first name error";
            // 
            // labelInvalidBirthday
            // 
            this.labelInvalidBirthday.AutoSize = true;
            this.labelInvalidBirthday.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInvalidBirthday.ForeColor = System.Drawing.Color.Red;
            this.labelInvalidBirthday.Location = new System.Drawing.Point(299, 62);
            this.labelInvalidBirthday.Name = "labelInvalidBirthday";
            this.labelInvalidBirthday.Size = new System.Drawing.Size(124, 16);
            this.labelInvalidBirthday.TabIndex = 17;
            this.labelInvalidBirthday.Text = "birthday name error";
            // 
            // labelInvalidLastName
            // 
            this.labelInvalidLastName.AutoSize = true;
            this.labelInvalidLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInvalidLastName.ForeColor = System.Drawing.Color.Red;
            this.labelInvalidLastName.Location = new System.Drawing.Point(8, 139);
            this.labelInvalidLastName.Name = "labelInvalidLastName";
            this.labelInvalidLastName.Size = new System.Drawing.Size(97, 16);
            this.labelInvalidLastName.TabIndex = 18;
            this.labelInvalidLastName.Text = "last name error";
            // 
            // labelInvalidPhoneNumber
            // 
            this.labelInvalidPhoneNumber.AutoSize = true;
            this.labelInvalidPhoneNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInvalidPhoneNumber.ForeColor = System.Drawing.Color.Red;
            this.labelInvalidPhoneNumber.Location = new System.Drawing.Point(300, 139);
            this.labelInvalidPhoneNumber.Name = "labelInvalidPhoneNumber";
            this.labelInvalidPhoneNumber.Size = new System.Drawing.Size(125, 16);
            this.labelInvalidPhoneNumber.TabIndex = 19;
            this.labelInvalidPhoneNumber.Text = "phone number error";
            // 
            // labelInvalidGender
            // 
            this.labelInvalidGender.AutoSize = true;
            this.labelInvalidGender.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInvalidGender.ForeColor = System.Drawing.Color.Red;
            this.labelInvalidGender.Location = new System.Drawing.Point(8, 218);
            this.labelInvalidGender.Name = "labelInvalidGender";
            this.labelInvalidGender.Size = new System.Drawing.Size(82, 16);
            this.labelInvalidGender.TabIndex = 20;
            this.labelInvalidGender.Text = "gender error";
            // 
            // labelInvalidAddressOne
            // 
            this.labelInvalidAddressOne.AutoSize = true;
            this.labelInvalidAddressOne.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInvalidAddressOne.ForeColor = System.Drawing.Color.Red;
            this.labelInvalidAddressOne.Location = new System.Drawing.Point(12, 106);
            this.labelInvalidAddressOne.Name = "labelInvalidAddressOne";
            this.labelInvalidAddressOne.Size = new System.Drawing.Size(115, 16);
            this.labelInvalidAddressOne.TabIndex = 21;
            this.labelInvalidAddressOne.Text = "address one error";
            // 
            // labelInvalidCity
            // 
            this.labelInvalidCity.AutoSize = true;
            this.labelInvalidCity.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInvalidCity.ForeColor = System.Drawing.Color.Red;
            this.labelInvalidCity.Location = new System.Drawing.Point(12, 215);
            this.labelInvalidCity.Name = "labelInvalidCity";
            this.labelInvalidCity.Size = new System.Drawing.Size(59, 16);
            this.labelInvalidCity.TabIndex = 22;
            this.labelInvalidCity.Text = "city error";
            // 
            // labelInvalidState
            // 
            this.labelInvalidState.AutoSize = true;
            this.labelInvalidState.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInvalidState.ForeColor = System.Drawing.Color.Red;
            this.labelInvalidState.Location = new System.Drawing.Point(283, 215);
            this.labelInvalidState.Name = "labelInvalidState";
            this.labelInvalidState.Size = new System.Drawing.Size(68, 16);
            this.labelInvalidState.TabIndex = 23;
            this.labelInvalidState.Text = "state error";
            // 
            // labelInvalidZipCode
            // 
            this.labelInvalidZipCode.AutoSize = true;
            this.labelInvalidZipCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInvalidZipCode.ForeColor = System.Drawing.Color.Red;
            this.labelInvalidZipCode.Location = new System.Drawing.Point(428, 215);
            this.labelInvalidZipCode.Name = "labelInvalidZipCode";
            this.labelInvalidZipCode.Size = new System.Drawing.Size(90, 16);
            this.labelInvalidZipCode.TabIndex = 24;
            this.labelInvalidZipCode.Text = "zip code error";
            // 
            // PatientInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 721);
            this.Controls.Add(this.tabControl1);
            this.Name = "PatientInfo";
            this.Text = "PatientInfo";
            this.tabControl1.ResumeLayout(false);
            this.tabDetails.ResumeLayout(false);
            this.tabDetails.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxFirstName;
        private System.Windows.Forms.TextBox textBoxLastName;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabDetails;
        private System.Windows.Forms.TabPage tabAppointments;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxAddressTwo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxAddressOne;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxGender;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxCity;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBoxStates;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxZipCode;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBoxPhoneNumber;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dateTimeBirthday;
        private System.Windows.Forms.TabPage tabVisits;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelInvalidFirstName;
        private System.Windows.Forms.Label labelInvalidPhoneNumber;
        private System.Windows.Forms.Label labelInvalidLastName;
        private System.Windows.Forms.Label labelInvalidBirthday;
        private System.Windows.Forms.Label labelInvalidGender;
        private System.Windows.Forms.Label labelInvalidAddressOne;
        private System.Windows.Forms.Label labelInvalidZipCode;
        private System.Windows.Forms.Label labelInvalidState;
        private System.Windows.Forms.Label labelInvalidCity;
    }
}