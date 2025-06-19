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
        private List<string> courses = new();
        public static uint StudentCounter = 1;

        public string GenerateNameCard()
        {
            return $"{this.Name} (STUDENT)";
        }

        public double DetermineWorkload()
        {
            return this.courses.Count * 10.00;
        }

        public void RegisterForCourse(string course)
        {
            if (!this.courses.Contains(course))
            {
                this.courses.Add(course);
            }




        }

    }
}
