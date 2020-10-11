using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healthcare_System.Validation
{
    class FormValidation
    {
        public static bool isValidUsername(string username)
        {
            return !String.IsNullOrEmpty(username);
        }
    }
}
