using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healthcare_System.Model
{
    /// <summary>
    /// Contains data about an appointment.
    /// </summary>
    public class Appointment
    {
        /// <summary>
        /// Gets or sets the patient identifier.
        /// </summary>
        /// <value>
        /// The patient identifier.
        /// </value>
        public int PatientId { get; set; }

        /// <summary>
        /// Gets or sets the date time.
        /// </summary>
        /// <value>
        /// The date time.
        /// </value>
        public DateTime DateTime { get; set; }

        /// <summary>
        /// Gets or sets the doctor identifier.
        /// </summary>
        /// <value>
        /// The doctor identifier.
        /// </value>
        public int DoctorId { get; set; }

        /// <summary>
        /// Gets or sets the reasons.
        /// </summary>
        /// <value>
        /// The reasons.
        /// </value>
        public string Reasons { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Appointment"/> class.
        /// </summary>
        /// <param name="patientId">The patient identifier.</param>
        /// <param name="dateTime">The date time.</param>
        /// <param name="doctorId">The doctor identifier.</param>
        /// <param name="reasons">The reasons for the appointment.</param>
        public Appointment(int patientId, DateTime dateTime, int doctorId, string reasons)
        {
            this.PatientId = patientId;
            this.DateTime = dateTime;
            this.DoctorId = doctorId;
            this.Reasons = reasons;
        }
    }

}
