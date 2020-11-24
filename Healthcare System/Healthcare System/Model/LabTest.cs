namespace Healthcare_System.Model
{
    /// <summary>
    /// Contains information about a lab test
    /// </summary>
    public class LabTest
    {
        /// <summary>
        /// Gets the test code.
        /// </summary>
        /// <value>
        /// The test code.
        /// </value>
        public int Code { get; private set; }

        /// <summary>
        /// Gets the test name.
        /// </summary>
        /// <value>
        /// The test name.
        /// </value>
        public string Name { get; private set; }

        /// <summary>
        /// Gets a combination of the test code and name
        /// </summary>
        /// <value>
        /// A combination of the test code and name
        /// </value>
        public string CodeAndName { get => $"{this.Code} - {this.Name}"; }

        /// <summary>
        /// Initializes a new instance of the <see cref="LabTest"/> class.
        /// </summary>
        /// <param name="code">The test code.</param>
        /// <param name="name">The test name.</param>
        public LabTest(int code, string name)
        {
            this.Code = code;
            this.Name = name;
        }
    }
}
