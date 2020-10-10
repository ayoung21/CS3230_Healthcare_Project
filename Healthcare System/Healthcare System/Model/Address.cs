namespace Healthcare_System.Model
{
    /// <summary>
    ///     Class to create an address for a user of the application
    /// </summary>
    public class Address
    {
        /// <summary>
        ///     Gets or sets the street address.
        /// </summary>
        /// <value>The street address.</value>
        public string StreetAddress { get; set; }


        /// <summary>
        ///     Gets or sets the address line 2.
        /// </summary>
        /// <value>
        /// The address line 2.
        /// </value>
        public string AddressLine2 { get; set; }

        /// <summary>
        ///     Gets or sets the city.
        /// </summary>
        /// <value>The street city.</value>
        public string City { get; set; }

        /// <summary>
        ///     Gets or sets the State.
        /// </summary>
        /// <value>The State</value>
        public string State { get; set; }

        /// <summary>
        ///     Gets or sets the zip code.
        /// </summary>
        /// <value>The zip code.</value>
        public string Zip { get; set; }
    }
}