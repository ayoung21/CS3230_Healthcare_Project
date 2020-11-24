using System;

namespace Healthcare_System.Model
{
    /// <summary>
    /// Contains information about a lab test order
    /// </summary>
    class LabTestOrder
    {
        /// <summary>
        /// Gets or sets the order identifier.
        /// </summary>
        /// <value>
        /// The order identifier.
        /// </value>
        public int OrderId { get; set; }

        /// <summary>
        /// Gets or sets the patient identifier.
        /// </summary>
        /// <value>
        /// The patient identifier.
        /// </value>
        public int PatientId { get; set; }

        /// <summary>
        /// Gets or sets the visit date time.
        /// </summary>
        /// <value>
        /// The visit date time.
        /// </value>
        public DateTime VisitDateTime { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="LabTestOrder"/> class.
        /// </summary>
        /// <param name="orderId">The order identifier.</param>
        /// <param name="patientId">The patient identifier.</param>
        /// <param name="visitDateTime">The visit date time.</param>
        public LabTestOrder(int orderId, int patientId, DateTime visitDateTime)
        {
            this.OrderId = orderId;
            this.PatientId = patientId;
            this.VisitDateTime = visitDateTime;
        }
    }
}
