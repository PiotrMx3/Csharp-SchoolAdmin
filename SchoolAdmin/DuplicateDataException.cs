using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAdmin
{
    internal class DuplicateDataException: Exception
    {
        public object Object1 { get; }
        public object Object2 { get; }


        public DuplicateDataException(string msg, object obj1, object obj2) : base(msg)
        {
            this.Object1 = obj1;
            this.Object2 = obj2;
        }

    }
}
