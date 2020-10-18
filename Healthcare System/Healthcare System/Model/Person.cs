using System;
using System.Collections.Generic;

namespace Healthcare_System.Model
{
    /// <summary>
    /// Class to create a user of the application
    /// </summary>
    public class Person
    {
        /// <summary>
        /// Gets or sets the user's id.
        /// </summary>
        /// <value>
        /// The user's id.
        /// </value>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the date of birth.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <value>
        /// The address.
        /// </value>
        public Address Address { get; set; }

        /// <summary>
        /// Gets or sets the phone number.
        /// </summary>
        /// <value>
        /// The phone number.
        /// </value>
        public string Phone { get; set; }

        /// <summary>
        /// Gets the person's roles.
        /// </summary>
        /// <value>
        /// The roles.
        /// </value>
        public IList<PersonRoles> Roles { get; }

        private int? _doctorId;

        /// <summary>
        /// Gets or sets the doctor id.
        /// </summary>
        /// <value>
        /// The doctor id.
        /// </value>
        /// <exception cref="ArgumentException">Cannot set Doctor ID for non doctor</exception>
        public int? DoctorId
        {
            get
            {
                if (this.Roles.Contains(PersonRoles.Doctor))
                    return this._doctorId;
                else
                    return null;
            }

            set
            {
                if (!this.Roles.Contains(PersonRoles.Doctor))
                    throw new ArgumentException("Cannot set Doctor ID for non doctor");

                this._doctorId = value;
            }
        }

        private int? _patientId;

        /// <summary>
        /// Gets or sets the patient id.
        /// </summary>
        /// <value>
        /// The patient id.
        /// </value>
        /// <exception cref="ArgumentException">Cannot set Doctor ID for non doctor</exception>
        public int? PatientID
        {
            get
            {
                if (this.Roles.Contains(PersonRoles.Patient))
                    return this._patientId;
                else
                    return null;
            }

            set
            {
                if (!this.Roles.Contains(PersonRoles.Patient))
                    throw new ArgumentException("Cannot set Patient ID for non patient");

                this._patientId = value;
            }
        }

        /// <summary>
        /// Gets or sets the gender.
        /// </summary>
        /// <value>
        /// The gender.
        /// </value>
        public Gender? Gender { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Person" /> class.
        /// </summary>
        public Person(int id)
        {
            this.UserId = id;
            this.Roles = new List<PersonRoles>();
        }

        /// <summary>
        /// Adds the specified role to this person.
        /// </summary>
        /// <param name="role">The role.</param>
        /// <returns>
        /// True if successful, false if not
        /// </returns>
        public bool AddRole(PersonRoles role)
        {
            int sizeBefore = this.Roles.Count;
            this.Roles.Add(role);

            return this.Roles.Count == (sizeBefore + 1);
        }

        /// <summary>
        /// Removes the role.
        /// </summary>
        /// <param name="role">The role.</param>
        /// <returns>
        /// True if successful, false if not
        /// </returns>
        public bool RemoveRole(PersonRoles role)
        {
            int sizeBefore = this.Roles.Count;
            this.Roles.Remove(role);

            return this.Roles.Count == (sizeBefore - 1);
        }
    }
}