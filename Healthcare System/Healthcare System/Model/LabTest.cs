using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healthcare_System.Model
{
    public class LabTest
    {
        public int Code { get; private set; }

        public string Name { get; private set; }

        public string CodeAndName { get => $"{this.Code} - {this.Name}";  }

        public LabTest(int code, string name)
        {
            this.Code = code;
            this.Name = name;
        }
    }
}
