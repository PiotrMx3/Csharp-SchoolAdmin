using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAdmin
{
    internal class CourseRegistration
    {
        private string name;
        private byte? result;



        public CourseRegistration(string name, byte? result)
        {
            Name = name;
            Result = result;
        }


        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                this.name = value;
            }
        }

        public byte? Result
        {
            get
            {
                return this.result;
            }
            set
            {
                if (value is not null and <= 20)
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
