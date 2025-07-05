using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAdmin
{
    internal class CourseRegistration
    {
        private Course course;
        private byte? result;



        public CourseRegistration(Course course, byte? result)
        {
            Course = course;
            Result = result;
        }


        public Course Course
        {
            get
            {
                return this.course;
            }
            private set
            {
                course = value;
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
