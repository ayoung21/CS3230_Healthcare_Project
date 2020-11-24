using Healthcare_System.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healthcare_System.DAL.Helpers
{
    /// <summary>
    /// Contains various helper methods involving multiple lab tables
    /// </summary>
    static class LabTestHelpers
    {
        /// <summary>
        /// Creates a test order.
        /// </summary>
        /// <param name="patientId">The patient id.</param>
        /// <param name="appointmentDateTime">The appointment date time.</param>
        /// <param name="testCodes">The codes of the tests to order.</param>
        /// <returns>The lab order id if successful, -1 if not</returns>
        public static int CreateTestOrder(int patientId, DateTime appointmentDateTime, List<int> testCodes)
        {
            MySqlTransaction transaction = TransactionHelpers.BeginTransaction();

            int orderId = LabTestOrderDAL.OrderTest(patientId, appointmentDateTime);

            foreach (int code in testCodes)
            {
                if (!HasTestsDAL.AddTestToOrder(orderId, code))
                {
                    transaction.Rollback();
                    return -1;
                }
            }

            TransactionHelpers.CommitTransaction(transaction);
            return orderId;
        }


        /// <summary>Gets the tests from order.</summary>
        /// <param name="orderId">The order identifier.</param>
        /// <returns>List of lab tests</returns>
        public static List<LabTest> GetTestsFromOrder(int orderId)
        {
            List<int> testCodes = HasTestsDAL.GetTestCodesFromOrder(orderId);

            List<LabTest> testsOrdered = new List<LabTest>();

            foreach (int code in testCodes)
            {
                string name = LabTestDAL.GetTestName(code);
                testsOrdered.Add(new LabTest(code, name));
            }

            return testsOrdered;
        }
    }
}
