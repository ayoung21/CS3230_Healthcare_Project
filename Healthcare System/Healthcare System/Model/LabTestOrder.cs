using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healthcare_System.Model
{
    class LabTestOrder
    {
        public int OrderId { get; set; }
        public int PatientId { get; set; }
        public DateTime VisitDateTime { get; set; }

        public LabTestOrder(int orderId, int patientId, DateTime visitDateTime)
        {
            this.OrderId = orderId;
            this.PatientId = patientId;
            this.VisitDateTime = visitDateTime;
        }
    }
}
