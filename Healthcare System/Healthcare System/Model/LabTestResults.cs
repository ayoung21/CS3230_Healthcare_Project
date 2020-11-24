using System;

namespace Healthcare_System.Model
{
    /// <summary>
    /// Contains information about test results
    /// </summary>
    class LabTestResults
    {
        /// <summary>
        /// Gets or sets the results.
        /// </summary>
        /// <value>
        /// The results.
        /// </value>
        public string Results { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this test is abnormal.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this test is abnormal; otherwise, <c>false</c>.
        /// </value>
        public bool IsAbnormal { get; set; }

        /// <summary>
        /// Gets or sets the date and time test was taken.
        /// </summary>
        /// <value>
        /// The date and time test was taken.
        /// </value>
        public DateTime TakenOn { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="LabTestResults"/> class.
        /// </summary>
        /// <param name="results">The results.</param>
        /// <param name="isAbnormal">if set to <c>true</c> [is abnormal].</param>
        /// <param name="takenOn">The date and time test was taken.</param>
        public LabTestResults(string results, bool isAbnormal, DateTime takenOn)
        {
            this.Results = results;
            this.IsAbnormal = isAbnormal;
            this.TakenOn = takenOn;
        }
    }
}
