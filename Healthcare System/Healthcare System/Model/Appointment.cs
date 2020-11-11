using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healthcare_System.Model
{
    public class Appointment
    {
        public int PatientId { get; set; }
        public DateTime DateTime { get; set; }
        public int DoctorId { get; set; }
        public string Reasons { get; set; }

        public Appointment(int patientId, DateTime dateTime, int doctorId, string reasons)
        {
            this.PatientId = patientId;
            this.DateTime = dateTime;
            this.DoctorId = doctorId;
            this.Reasons = reasons;
        }
    }

}
