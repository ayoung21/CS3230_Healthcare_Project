using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healthcare_System.Model
{
    class LabTestResults
    {
        public string Results { get; private set; }

        public bool IsAbnormal { get; private set; }

        public LabTestResults(string results, bool isAbnormal)
        {
            this.Results = results;
            this.IsAbnormal = isAbnormal;
        }
    }
}
