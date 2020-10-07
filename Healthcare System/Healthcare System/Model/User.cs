using System;

namespace Healthcare_System.Model
{
    /// <summary>
    ///     Class to create a user of the application
    /// </summary>
    internal class User
    {
        /// <summary>
        ///     Gets or sets the first name.
        /// </summary>
        /// <value>The first name.</value>
        public string FirstName { get; set; }

        /// <summary>
        ///     Gets or sets the last name.
        /// </summary>
        /// <value>The last name.</value>
        public string LastName { get; set; }

        /// <summary>
        ///     Gets or sets the date of birth.
        /// </summary>
        /// <value>The first name.</value>
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        ///     Gets or sets the address.
        /// </summary>
        /// <value>The address.</value>
        public Address Address { get; set; }
    }
}