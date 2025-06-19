using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAdmin
{
    internal class Student
    {

        public string Name;
        public DateTime BirthDate;
        public uint StudentNumber;
        public List<string> Courses = new();
        public static uint StudentCounter = 1;

        public string GenerateNameCard()
        {
            return $"{this.Name} (STUDENT)";
        }

        public double DetermineWorkload()
        {
            return this.Courses.Count * 10.00;
        }


    }
}
