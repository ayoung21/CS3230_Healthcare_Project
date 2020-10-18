using System;
using System.Collections.Generic;

namespace Healthcare_System.Model
{
    /// <summary>
    ///     Class to create a user of the application
    /// </summary>
    public class Person
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

        /// <summary>
        ///     Gets or sets the phone number.
        /// </summary>
        /// <value>The phone number.</value>
        public int Phone { get; set; }

        /// <summary>
        ///     Gets the person's roles.
        /// </summary>
        /// <value>The roles.</value>
        public IList<PersonRoles> Roles { get; }

        /// <summary>
        /// Gets or sets the doctor identifier.
        /// </summary>
        /// <value>
        /// The doctor identifier.
        /// </value>
        /// <exception cref="ArgumentException">Cannot set Doctor ID for non doctor</exception>
        public int? DoctorId
        {
            get
            {
                if (this.Roles.Contains(PersonRoles.Doctor))
                    return DoctorId.Value;
                else
                    return null;
            }

            set
            {
                if (!this.Roles.Contains(PersonRoles.Doctor))
                    throw new ArgumentException("Cannot set Doctor ID for non doctor");

                this.DoctorId = value;
            }
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Person" /> class.
        /// </summary>
        public Person()
        {
            this.Roles = new List<PersonRoles>();
        }

        /// <summary>
        ///     Adds the specified role to this person.
        /// </summary>
        /// <param name="role">The role.</param>
        /// <returns>True if successful, false if not</returns>
        public bool AddRole(PersonRoles role)
        {
            int sizeBefore = this.Roles.Count;
            this.Roles.Add(role);

            return this.Roles.Count == (sizeBefore + 1);
        }

        /// <summary>
        ///     Removes the role.
        /// </summary>
        /// <param name="role">The role.</param>
        /// <returns>True if successful, false if not</returns>
        public bool RemoveRole(PersonRoles role)
        {
            int sizeBefore = this.Roles.Count;
            this.Roles.Remove(role);

            return this.Roles.Count == (sizeBefore - 1);
        }
    }
}