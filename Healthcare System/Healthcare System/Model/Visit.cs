using System;

namespace Healthcare_System.Model
{
    /// <summary>
    /// Contains information about a visit
    /// </summary>
    class Visit
    {
        /// <summary>
        /// Gets the patient identifier.
        /// </summary>
        /// <value>
        /// The patient identifier.
        /// </value>
        public int PatientId { get; private set; }

        /// <summary>
        /// Gets the appointment date time.
        /// </summary>
        /// <value>
        /// The appointment date time.
        /// </value>
        public DateTime AppointmentDateTime { get; private set; }

        /// <summary>
        /// Gets or sets the patient's systolic blood pressure.
        /// </summary>
        /// <value>
        /// The patient's systolic blood pressure.
        /// </value>
        public int BpSystolic { get; set; }

        /// <summary>
        /// Gets or sets the patient's diastolic blood pressure.
        /// </summary>
        /// <value>
        /// The patient's diastolic blood pressure.
        /// </value>
        public int BpDiastolic { get; set; }

        /// <summary>
        /// Gets or sets the patient's temperature.
        /// </summary>
        /// <value>
        /// The patient's temperature.
        /// </value>
        public decimal Temperature { get; set; }

        /// <summary>
        /// Gets or sets the patient's weight.
        /// </summary>
        /// <value>
        /// The patient's weight.
        /// </value>
        public decimal Weight { get; set; }

        /// <summary>
        /// Gets or sets the patient's pulse.
        /// </summary>
        /// <value>
        /// The patient's pulse.
        /// </value>
        public int Pulse { get; set; }

        /// <summary>
        /// Gets or sets the patient's symptoms.
        /// </summary>
        /// <value>
        /// The patient's symptoms.
        /// </value>
        public string Symptoms { get; set; }

        /// <summary>
        /// Gets or sets the nurse user id.
        /// </summary>
        /// <value>
        /// The nurse user id.
        /// </value>
        public int NurseUserId { get; set; }

        /// <summary>
        /// Gets or sets the doctor id.
        /// </summary>
        /// <value>
        /// The doctor id.
        /// </value>
        public int DoctorId { get; set; }

        /// <summary>
        /// Gets or sets the diagnoses.
        /// </summary>
        /// <value>
        /// The diagnoses.
        /// </value>
        public string Diagnoses { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether final diagnosis has been made.
        /// </summary>
        /// <value>
        ///   <c>true</c> if final diagnosis made; otherwise, <c>false</c>.
        /// </value>
        public bool FinalDiagnosisMade { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Visit"/> class.
        /// </summary>
        /// <param name="patientId">The patient identifier.</param>
        /// <param name="appoinmentDateTime">The appoinment date time.</param>
        /// <param name="bpSystolic">The patient's systolic blood pressure.</param>
        /// <param name="bpDiastolic">The patient's diastolic blood pressure.</param>
        /// <param name="temperature">The patient's temperature.</param>
        /// <param name="weight">The patient's weight.</param>
        /// <param name="pulse">The patient's pulse.</param>
        /// <param name="symptoms">The patient's symptoms.</param>
        /// <param name="nurseUserId">The nurse user id.</param>
        /// <param name="doctorId">The doctor id.</param>
        /// <param name="diagnoses">The diagnoses.</param>
        /// <param name="finalDiagnosisMade">if set to <c>true</c> final diagnosis is made.</param>
        public Visit(int patientId, DateTime appoinmentDateTime, int bpSystolic, int bpDiastolic, decimal temperature,
            decimal weight, int pulse, string symptoms, int nurseUserId, int doctorId, string diagnoses, bool finalDiagnosisMade)
        {
            this.PatientId = patientId;
            this.AppointmentDateTime = appoinmentDateTime;
            this.BpSystolic = bpSystolic;
            this.BpDiastolic = bpDiastolic;
            this.Temperature = temperature;
            this.Weight = weight;
            this.Pulse = pulse;
            this.Symptoms = symptoms;
            this.NurseUserId = nurseUserId;
            this.DoctorId = doctorId;
            this.Diagnoses = diagnoses;
            this.FinalDiagnosisMade = finalDiagnosisMade;
        }
    }
}
