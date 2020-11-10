﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Healthcare_System.DAL;
using Healthcare_System.Messages;
using Healthcare_System.Model;

namespace Healthcare_System.View
{
    public partial class PatientInfo : Form
    {
        private Person patient;
        private int nurseUserId;
        private bool detailsTabEditMode;
        private bool appointmentUpdateMode;
        private bool visitUpdateMode;
        private bool currentlyEditingAppointment;
        private bool currentlyEditingVisit;
        private const string DATE_TIME_PICKER_FORMAT = "MM/dd/yyyy HH:mm";

        public PatientInfo(Person patientInfo, int nurseUserId)
        {
            InitializeComponent();

            this.patient = patientInfo;
            this.nurseUserId = nurseUserId;
            this.detailsTabEditMode = false;
            this.toggleCurrentlyEditingAppointment(false);
            this.currentlyEditingVisit = false;

            this.enableDetailsTabAllowEdit(false);
            this.hideDetailsTabErrorMessages();
            this.comboBoxStates.DataSource = Enum.GetValues(typeof(StateAbbreviations));
            this.buttonSavePatient.Enabled = detailsTabEditMode;
            this.buttonCancelEditPatient.Enabled = detailsTabEditMode;
            this.populateFields();
            this.dateTimeAppointmentDate.CustomFormat = DATE_TIME_PICKER_FORMAT;
            this.dateTimePickerVisit.CustomFormat = DATE_TIME_PICKER_FORMAT;
            List<Person> allDoctors = DoctorDAL.GetAllDoctors();
            this.comboBoxAppointmentDoctor.ValueMember = "DoctorId";
            this.comboBoxAppointmentDoctor.DisplayMember = "FullNameLastFirst";
            this.comboBoxAppointmentDoctor.DataSource = allDoctors;
            this.comboBoxVisitDoctor.ValueMember = "DoctorId";
            this.comboBoxVisitDoctor.DisplayMember = "FullNameLastFirst";
            this.comboBoxVisitDoctor.DataSource = allDoctors;

            this.initializeAppointmentsListView();
            this.listViewVisits.Columns.Add("Date & Time", 150);
            this.reloadAppointments();
            this.disableAppointmentEditFields();
            this.loadVisits();
        }

        #region Patient Details Tab
        private void initializeAppointmentsListView()
        {
            this.listViewAppointments.Columns.Add("Date & Time", 150);
            this.listViewAppointments.Columns.Add("Reasons", 400);
        }

        private void enableDetailsTabAllowEdit(bool allowEdit)
        {
            // Patient Info
            this.textBoxFirstName.Enabled = allowEdit;
            this.textBoxLastName.Enabled = allowEdit;
            this.comboBoxGender.Enabled = allowEdit;
            this.dateTimeBirthday.Enabled = allowEdit;
            this.textBoxPhoneNumber.Enabled = allowEdit;

            // Patient Address
            this.textBoxAddressOne.Enabled = allowEdit;
            this.textBoxAddressTwo.Enabled = allowEdit;
            this.textBoxCity.Enabled = allowEdit;
            this.comboBoxStates.Enabled = allowEdit;
            this.textBoxZipCode.Enabled = allowEdit;
        }

        private void hideDetailsTabErrorMessages()
        {
            this.labelInvalidFirstName.Visible = false;
            this.labelInvalidLastName.Visible = false;
            this.labelInvalidAddressOne.Visible = false;
            this.labelInvalidCity.Visible = false;
            this.labelInvalidState.Visible = false;
            this.labelInvalidZipCode.Visible = false;
            this.labelInvalidPhoneNumber.Visible = false;
            this.labelInvalidBirthday.Visible = false;
            this.labelInvalidGender.Visible = false;
        }

        private void populateFields()
        {
            this.textBoxFirstName.Text = patient.FirstName;
            this.textBoxLastName.Text = patient.LastName;
            this.textBoxAddressOne.Text = patient.Address.StreetAddress;
            this.textBoxAddressTwo.Text = patient.Address.AddressLine2;
            this.textBoxCity.Text = patient.Address.City;
            this.comboBoxStates.SelectedItem = patient.Address.State;
            this.textBoxZipCode.Text = patient.Address.Zip.ToString();
            this.textBoxPhoneNumber.Text = patient.Phone;
            this.dateTimeBirthday.Value = patient.DateOfBirth;
            this.comboBoxGender.SelectedItem = (patient.Gender == Gender.M) ? "Male" : "Female";
        }

        private void buttonEditPatient_Click(object sender, EventArgs e)
        {
            this.enableDetailsTabAllowEdit(true);

            this.buttonEditPatient.Enabled = false;
            this.buttonCancelEditPatient.Enabled = true;
            this.buttonSavePatient.Enabled = true;
        }

        private void buttonCancelEditPatient_Click(object sender, EventArgs e)
        {
            this.populateFields();
            this.enableDetailsTabAllowEdit(false);
            this.hideDetailsTabErrorMessages();

            this.buttonEditPatient.Enabled = true;
            this.buttonCancelEditPatient.Enabled = false;
            this.buttonSavePatient.Enabled = false;
        }

        private void buttonSavePatient_Click(object sender, EventArgs e)
        {
            this.hideDetailsTabErrorMessages();
            var validFields = this.validateDetailsTabFields();

            if (validFields)
            {
                this.buttonSavePatient.Enabled = false;
                this.buttonCancelEditPatient.Enabled = false;
                this.buttonEditPatient.Enabled = true;
                this.hideDetailsTabErrorMessages();

                // Update Person
                patient.FirstName = this.textBoxFirstName.Text;
                patient.LastName = this.textBoxLastName.Text;
                patient.Address.StreetAddress = this.textBoxAddressOne.Text;
                patient.Address.AddressLine2 = this.textBoxAddressTwo.Text;
                patient.Address.City = this.textBoxCity.Text;
                patient.Address.State = this.comboBoxStates.SelectedItem.ToString();
                patient.Address.Zip = Int32.Parse(this.textBoxZipCode.Text);
                patient.Phone = this.textBoxPhoneNumber.Text;
                patient.DateOfBirth = this.dateTimeBirthday.Value;
                patient.Gender = (this.comboBoxGender.SelectedItem.ToString().ToUpper().Equals("MALE"))
                    ? Gender.M
                    : Gender.F;

                // Update Database
                var isSuccessful = UserDAL.UpdateUser(patient);

                if (isSuccessful)
                {
                    // TODO: Need to refactor -- same logic as cancel button
                    // NOTE: this needs to be before message box
                    this.populateFields();
                    this.enableDetailsTabAllowEdit(false);
                    this.hideDetailsTabErrorMessages();

                    this.buttonEditPatient.Enabled = true;
                    this.buttonCancelEditPatient.Enabled = false;
                    this.buttonSavePatient.Enabled = false;

                    MessageBox.Show("Patient has been updated!");
                }
            }
        }

        private bool validateDetailsTabFields()
        {
            var firstName = this.textBoxFirstName.Text;
            var lastName = this.textBoxLastName.Text;
            var addressOne = this.textBoxAddressOne.Text;
            // var addressTwo = this.textBoxAddressTwo.Text;
            var city = this.textBoxCity.Text;
            var state = (this.comboBoxStates.SelectedItem == null) ? "" : this.comboBoxStates.SelectedItem.ToString();
            var zipCode = (String.IsNullOrEmpty(this.textBoxZipCode.Text) || this.textBoxZipCode.Text.Length != 5) ? Constants.Constants.INVALID_ZIP : Int32.Parse(this.textBoxZipCode.Text);
            var phoneNumber = (String.IsNullOrEmpty(this.textBoxPhoneNumber.Text) || this.textBoxPhoneNumber.Text.Length != 10) ? "" : this.textBoxPhoneNumber.Text;
            var gender = (this.comboBoxGender.SelectedItem == null) ? "" : this.comboBoxGender.SelectedItem.ToString();
            // var dateOfBirth = this.dateTimeBirthday.Value;

            var validFirstName = !String.IsNullOrEmpty(firstName.Trim());
            var validLastName = !String.IsNullOrEmpty(lastName.Trim());
            var validAddressOne = !String.IsNullOrEmpty(addressOne.Trim());
            var validCity = !String.IsNullOrEmpty(city.Trim());
            var validState = !String.IsNullOrEmpty(state.Trim());
            var validZipCode = (zipCode != -1);
            var validPhoneNumber = !String.IsNullOrEmpty(phoneNumber.Trim());
            var validGender = !String.IsNullOrEmpty(gender.Trim());

            if (!validFirstName)
            {
                this.labelInvalidFirstName.Text = UIMessages.INVALID_FIRST_NAME;
                this.labelInvalidFirstName.Visible = true;
            }

            if (!validLastName)
            {
                this.labelInvalidLastName.Text = UIMessages.INVALID_LAST_NAME;
                this.labelInvalidLastName.Visible = true;
            }

            if (!validAddressOne)
            {
                this.labelInvalidAddressOne.Text = UIMessages.INVALID_STREET_ADDRESS;
                this.labelInvalidAddressOne.Visible = true;
            }

            if (!validCity)
            {
                this.labelInvalidCity.Text = UIMessages.INVALID_CITY;
                this.labelInvalidCity.Visible = true;
            }

            if (!validState)
            {
                this.labelInvalidState.Text = UIMessages.INVALID_STATE;
                this.labelInvalidState.Visible = true;
            }

            if (!validZipCode)
            {
                this.labelInvalidZipCode.Text = UIMessages.INVALID_ZIP;
                this.labelInvalidZipCode.Visible = true;
            }

            if (!validPhoneNumber)
            {
                this.labelInvalidPhoneNumber.Text = UIMessages.INVALID_PHONE;
                this.labelInvalidPhoneNumber.Visible = true;
            }

            if (!validGender)
            {
                this.labelInvalidGender.Text = UIMessages.INVALID_GENDER;
                this.labelInvalidGender.Visible = true;
            }

            return (validFirstName &&
                    validLastName &&
                    validAddressOne &&
                    validCity &&
                    validState &&
                    validZipCode &&
                    validPhoneNumber &&
                    validGender);
        }

        private void textBoxPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verify that the pressed key isn't CTRL or any non-numeric digit
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void textBoxZipCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verify that the pressed key isn't CTRL or any non-numeric digit
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
        #endregion

        #region Appointments Tab
        private void buttonSaveAppointment_Click(object sender, EventArgs e)
        {
            if (this.comboBoxAppointmentDoctor.SelectedValue == null)
            {
                MessageBox.Show("Please select a doctor");
                return;
            }

            int patientId = this.patient.PatientID.Value;
            DateTime appointmentDateTime = this.dateTimeAppointmentDate.Value;
            string reasons = this.textBoxAppointmentReasons.Text;
            int doctorId = Int32.Parse(this.comboBoxAppointmentDoctor.SelectedValue.ToString());
            bool successful = false;

            if (this.appointmentUpdateMode)
            {
                Appointment oldAppointment = (Appointment)this.listViewAppointments.SelectedItems[0].Tag;
                if (this.validateAppointmentInfo(appointmentDateTime, patientId, doctorId, reasons, oldAppointment))
                {
                    DateTime oldDateTime = oldAppointment.DateTime;
                    successful = AppointmentDAL.UpdateAppointment(this.patient.PatientID.Value, oldDateTime, appointmentDateTime, doctorId, reasons);
                }
                else
                {
                    return;
                }
            } 
            else if (this.validateAppointmentInfo(appointmentDateTime, patientId, doctorId, reasons))
            {
                successful = AppointmentDAL.AddAppointment(patientId, appointmentDateTime, doctorId, reasons);
            } else
            {
                return;
            }
 
            if (successful)
            {
                this.reloadAppointments();
                this.clearAppointmentDetailsFields();
                this.disableAppointmentEditFields();
                this.toggleCurrentlyEditingAppointment(false);
            }
            else
            {
                MessageBox.Show("An error occured while saving the appointment");
            }
        }

        private void reloadAppointments()
        {
            this.listViewAppointments.Items.Clear();

            List<Appointment> appointments = AppointmentDAL.GetAllAppointmentsForPatient(this.patient.PatientID.Value);

            foreach (Appointment appointment in appointments)
            {
                string formattedDateTime = appointment.DateTime.ToShortDateString() + " " + appointment.DateTime.ToShortTimeString();
                ListViewItem row = new ListViewItem(new[] { formattedDateTime, appointment.Reasons });
                row.Tag = appointment;
                this.listViewAppointments.Items.Add(row);
            }

        }

        private void disableAppointmentEditFields()
        {
            this.dateTimeAppointmentDate.Enabled = false;
            this.comboBoxAppointmentDoctor.Enabled = false;
            this.textBoxAppointmentReasons.Enabled = false;
            this.buttonCancelAppointmentEdit.Enabled = false;
            this.buttonSaveAppointment.Enabled = false;
        }

        private void enableAppointmentEditFields()
        {
            this.dateTimeAppointmentDate.Enabled = true;
            this.comboBoxAppointmentDoctor.Enabled = true;
            this.textBoxAppointmentReasons.Enabled = true;
            this.buttonCancelAppointmentEdit.Enabled = true;
            this.buttonSaveAppointment.Enabled = true;
        }

        private void clearAppointmentDetailsFields()
        {
            this.dateTimeAppointmentDate.Value = DateTime.Now;
            this.comboBoxAppointmentDoctor.SelectedIndex = 0;
            this.comboBoxAppointmentDoctor.SelectedIndex = 0;
            this.textBoxAppointmentReasons.Clear();
        }

        private bool validateAppointmentInfo(DateTime appointmentDateTime, int patientId, int doctorId, string reasons, Appointment ignoredAppointment = null)
        {
            if (appointmentDateTime < DateTime.Now)
            {
                MessageBox.Show("You cannot schedule an appointment in the past");
                return false;
            }

            if (AppointmentDAL.HasMatchingAppointment(appointmentDateTime, patientId: patientId, ignoredAppointment: ignoredAppointment))
            {
                MessageBox.Show("The patient cannot be scheduled for 2 appointments at the same time!");
                return false;
            }
            else if (AppointmentDAL.HasMatchingAppointment(appointmentDateTime, doctorId: doctorId, ignoredAppointment: ignoredAppointment))
            {
                MessageBox.Show("The doctor cannot be at 2 appointments at the same time!");
                return false;
            }

            if (String.IsNullOrWhiteSpace(reasons))
            {
                MessageBox.Show("Please include appointment reasons.");
                return false;
            } else if (reasons.Length > 200)
            {
                MessageBox.Show("Reasons length cannot exceed 200 characters");
                return false;
            }

            return true;
        }

        private void buttonCancelAppointmentEdit_Click(object sender, EventArgs e)
        {
            this.clearAppointmentDetailsFields();
            this.disableAppointmentEditFields();
            this.toggleCurrentlyEditingAppointment(false);
        }

        private void buttonNewAppointment_Click(object sender, EventArgs e)
        {
            if (this.currentlyEditingAppointment)
            {
                this.showUnsavedAppointmentChangesError();
                return;
            }

            this.toggleCurrentlyEditingAppointment(true);
            this.clearAppointmentDetailsFields();
            this.changeAppointmentUpdateMode(false);
            this.enableAppointmentEditFields();
        }

        private void buttonEditAppointment_Click(object sender, EventArgs e)
        {
            if (this.currentlyEditingAppointment)
            {
                this.showUnsavedAppointmentChangesError();
            }
            else if (this.listViewAppointments.SelectedItems.Count > 0)
            {
                DateTime appointmentDateTime = ((Appointment)this.listViewAppointments.SelectedItems[0].Tag).DateTime;
                if (appointmentDateTime < DateTime.Now)
                {
                    MessageBox.Show("You cannot edit this appointment because its time has passed");
                    return;
                }
                this.toggleCurrentlyEditingAppointment(true);
                this.changeAppointmentUpdateMode(true);
                this.populateAppointmentDetails();
                this.enableAppointmentEditFields();
            }
            else
            {
                MessageBox.Show("Please select an appointment to edit");
            }
        }

        private void listViewAppointments_MouseUp(object sender, MouseEventArgs e)
        {
            if (!this.currentlyEditingAppointment)
            {
                this.populateAppointmentDetails();
            }
        }

        private void toggleCurrentlyEditingAppointment(bool currentlyEditing)
        {
            this.currentlyEditingAppointment = currentlyEditing;
            if (currentlyEditing)
            {
                this.buttonNewAppointment.Enabled = false;
                this.buttonEditAppointment.Enabled = false;
                this.buttonDeleteAppointment.Enabled = false;
                this.buttonMakeVisit.Enabled = false;
            }
            else
            {
                this.buttonNewAppointment.Enabled = true;
                this.buttonEditAppointment.Enabled = true;
                this.buttonDeleteAppointment.Enabled = true;
                this.buttonMakeVisit.Enabled = true;
            }
        }

        private void populateAppointmentDetails()
        {
            if (this.listViewAppointments.SelectedItems.Count > 0)
            {
                Appointment selectedAppointment = (Appointment)this.listViewAppointments.SelectedItems[0].Tag;
                this.dateTimeAppointmentDate.Value = selectedAppointment.DateTime;
                this.comboBoxAppointmentDoctor.SelectedValue = selectedAppointment.DoctorId;
                this.textBoxAppointmentReasons.Text = selectedAppointment.Reasons;
            }
        }

        private void showUnsavedAppointmentChangesError()
        {
            MessageBox.Show("Please save or cancel your current changes before proceding");
        }

        private void changeAppointmentUpdateMode(bool isUpdateMode)
        {
            this.appointmentUpdateMode = isUpdateMode;
            if (isUpdateMode)
            {
                this.buttonSaveAppointment.Text = "Save Changes";
            }
            else
            {
                this.buttonSaveAppointment.Text = "Schedule Appointment";
            }
        }

        private void buttonDeleteAppointment_Click(object sender, EventArgs e)
        {
            //TODO
            MessageBox.Show("Not implemented yet");
        }

        private void buttonMakeVisit_Click(object sender, EventArgs e)
        {
            this.visitUpdateMode = false;
            if (VisitDAL.HasMatchingVisit(this.patient.PatientID.Value, this.dateTimeAppointmentDate.Value))
            {
                MessageBox.Show("You cannot create multiple visits for an appointment");
            }
            else
            {
                this.currentlyEditingVisit = true;
                this.tabControlPatientInfo.SelectTab(2);
                this.comboBoxVisitDoctor.SelectedIndex = this.comboBoxAppointmentDoctor.SelectedIndex;
                this.enableVisitInfoFields();
                this.dateTimePickerVisit.Value = this.dateTimeAppointmentDate.Value;
            }
        }
        #endregion

        #region Visits Tab
        private void buttonSaveVisit_Click(object sender, EventArgs e)
        {
            if (this.comboBoxVisitDoctor.SelectedValue == null)
            {
                MessageBox.Show("Please select a doctor");
                return;
            }

            this.labelSymptomsError.Visible = false;
            int patientId = this.patient.PatientID.Value;
            DateTime apptDateTime = this.dateTimePickerVisit.Value;
            int doctorId = Int32.Parse(this.comboBoxVisitDoctor.SelectedValue.ToString());
            int bpSystolic = (int)this.numericUpDownSystolic.Value;
            int bpDiastolic = (int)this.numericUpDownDiastolic.Value;
            decimal temperature = this.numericUpDownTemperature.Value;
            decimal weight = this.numericUpDownWeight.Value;
            int pulse = (int)this.numericUpDownPulse.Value;
            string symptoms = this.textBoxSymptoms.Text;
            string diagnoses = this.textBoxDiagnoses.Text;
            if (string.IsNullOrWhiteSpace(diagnoses))
                diagnoses = null;

            if (string.IsNullOrWhiteSpace(symptoms))
            {
                this.labelSymptomsError.Visible = true;
                return;
            }

            bool isSuccessful;

            if (this.visitUpdateMode)
            {
                isSuccessful = VisitDAL.UpdateVisit(patientId, apptDateTime, bpSystolic, bpDiastolic, temperature, weight, pulse, symptoms, nurseUserId, doctorId, diagnoses);
            }
            else
            {
                isSuccessful = VisitDAL.AddVisit(patientId, apptDateTime, bpSystolic, bpDiastolic, temperature, weight, pulse, symptoms, this.nurseUserId, doctorId, diagnoses);
            }

            if (isSuccessful)
            {
                this.clearVisitInfoFields();
                this.disableVisitInfoFields();
                this.currentlyEditingVisit = false;
                this.loadVisits();
            }
            else
            {
                MessageBox.Show("An error occured when adding a visit");
            }
        }

        private void buttonCancelVisitInfo_Click(object sender, EventArgs e)
        {
            this.disableVisitInfoFields();
            this.clearVisitInfoFields();
            this.currentlyEditingVisit = false;
        }

        private void disableVisitInfoFields()
        {
            this.comboBoxVisitDoctor.Enabled = false;
            this.numericUpDownTemperature.Enabled = false;
            this.numericUpDownWeight.Enabled = false;
            this.numericUpDownSystolic.Enabled = false;
            this.numericUpDownDiastolic.Enabled = false;
            this.numericUpDownPulse.Enabled = false;
            this.textBoxSymptoms.Enabled = false;
            this.textBoxDiagnoses.Enabled = false;
            this.buttonLabs.Enabled = false;
            this.buttonSaveVisit.Enabled = false;
            this.buttonCancelVisitInfo.Enabled = false;
        }

        private void enableVisitInfoFields()
        {
            this.comboBoxVisitDoctor.Enabled = true;
            this.numericUpDownTemperature.Enabled = true;
            this.numericUpDownWeight.Enabled = true;
            this.numericUpDownSystolic.Enabled = true;
            this.numericUpDownDiastolic.Enabled = true;
            this.numericUpDownPulse.Enabled = true;
            this.textBoxSymptoms.Enabled = true;
            this.textBoxDiagnoses.Enabled = true;
            this.buttonLabs.Enabled = true;
            this.buttonSaveVisit.Enabled = true;
            this.buttonCancelVisitInfo.Enabled = true;
        }

        private void clearVisitInfoFields()
        {
            this.comboBoxVisitDoctor.SelectedIndex = 0;
            this.dateTimePickerVisit.Value = DateTime.Now;
            this.numericUpDownTemperature.Value = this.numericUpDownTemperature.Minimum;
            this.numericUpDownWeight.Value = this.numericUpDownWeight.Minimum;
            this.numericUpDownSystolic.Value = this.numericUpDownSystolic.Minimum;
            this.numericUpDownDiastolic.Value = this.numericUpDownDiastolic.Minimum;
            this.numericUpDownTemperature.Value = this.numericUpDownTemperature.Minimum;
            this.textBoxSymptoms.Clear();
            this.textBoxDiagnoses.Clear();
        }

        private void loadVisits()
        {
            this.listViewVisits.Items.Clear();

            List<Visit> visits = VisitDAL.GetAllVisitsForPatient(this.patient.PatientID.Value);

            foreach (Visit visit in visits)
            {
                string formattedDateTime = visit.AppointmentDateTime.ToShortDateString() + " " + visit.AppointmentDateTime.ToShortTimeString();
                ListViewItem row = new ListViewItem(new[] { formattedDateTime });
                row.Tag = visit;
                this.listViewVisits.Items.Add(row);
            }
        }

        private void listViewVisits_MouseUp(object sender, MouseEventArgs e)
        {
            if (!this.currentlyEditingVisit)
            {
                this.populateVisitDetails();
            }
        }

        private void populateVisitDetails()
        {
            if (this.listViewVisits.SelectedItems.Count > 0)
            {
                Visit selectedVisit = (Visit)this.listViewVisits.SelectedItems[0].Tag;
                this.dateTimePickerVisit.Value = selectedVisit.AppointmentDateTime;
                this.comboBoxVisitDoctor.SelectedValue = selectedVisit.DoctorId;
                this.numericUpDownSystolic.Value = selectedVisit.BpSystolic;
                this.numericUpDownDiastolic.Value = selectedVisit.BpDiastolic;
                this.numericUpDownPulse.Value = selectedVisit.Pulse;
                this.numericUpDownTemperature.Value = selectedVisit.Temperature;
                this.numericUpDownWeight.Value = selectedVisit.Weight;
                this.textBoxSymptoms.Text = selectedVisit.Symptoms;
                this.textBoxDiagnoses.Text = selectedVisit.Diagnoses;
            }
        }

        private void buttonEditVisit_Click(object sender, EventArgs e)
        {
            if (this.currentlyEditingVisit)
            {
                MessageBox.Show("Please save or cancel your current visit changes");
            }
            else if (this.listViewVisits.SelectedItems.Count > 0)
            {
                this.visitUpdateMode = true;
                this.currentlyEditingVisit = true;
                this.enableVisitInfoFields();
                this.populateVisitDetails();
            } else
            {
                MessageBox.Show("Please select a visit to edit");
            }
        }

        private void buttonLabs_Click(object sender, EventArgs e)
        {
            Labs labsForm = new Labs();
            labsForm.ShowDialog();
        }
        #endregion
    }
}
