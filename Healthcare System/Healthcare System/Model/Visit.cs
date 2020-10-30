using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healthcare_System.Model
{
    class Visit
    {
        public int PatientId { get; private set; }
        public DateTime AppointmentDateTime { get; private set; }
        public int BpSystolic { get; set; }
        public int BpDiastolic { get; set; }
        public decimal Temperature { get; set; }
        public int Pulse { get; set; }
        public string Symptoms { get; set; }
        public int NurseUserId { get; set; }
        public int DoctorId { get; set; }
        public string Diagnoses { get; set; }

        public Visit(int patientId, DateTime appoinmentDateTime, int bpSystolic, int bpDiastolic,
            decimal temperature, int pulse, string symptoms, int nurseUserId, int doctorId, string diagnoses = null)
        {
            this.PatientId = patientId;
            this.AppointmentDateTime = appoinmentDateTime;
            this.BpSystolic = bpSystolic;
            this.BpDiastolic = bpDiastolic;
            this.Temperature = temperature;
            this.Pulse = pulse;
            this.Symptoms = symptoms;
            this.NurseUserId = nurseUserId;
            this.DoctorId = doctorId;
            this.Diagnoses = diagnoses;
        }
    }
}
