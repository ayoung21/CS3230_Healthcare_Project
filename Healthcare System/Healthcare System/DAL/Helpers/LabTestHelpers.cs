using Healthcare_System.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healthcare_System.DAL.Helpers
{
    static class LabTestHelpers
    {
        public static int CreateTestOrder(int patientId, DateTime appointmentDateTime, List<LabTest> tests)
        {
            MySqlTransaction transaction = TransactionHelpers.BeginTransaction();

            int orderId = LabTestOrderDAL.OrderTest(patientId, appointmentDateTime);

            foreach (LabTest test in tests)
            {
                if (!HasTestsDAL.AddTestToOrder(orderId, test.Code))
                {
                    transaction.Rollback();
                    return -1;
                }
            }

            TransactionHelpers.CommitTransaction(transaction);
            return orderId;
        }
    }
}
