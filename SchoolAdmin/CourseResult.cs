using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAdmin
{
    internal class CourseResult
    {
        private string name;
        private byte result;


        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        public byte Result
        {
            get
            {
                return this.result;
            }
            set
            {
                if (value >= 0 && value <= 20)
                {
                    this.result = value;
                }
                else
                {
                    Console.WriteLine("Resultaat moet tussen 0 en 20 liggen.");
                }
            }
        }

    }
}
