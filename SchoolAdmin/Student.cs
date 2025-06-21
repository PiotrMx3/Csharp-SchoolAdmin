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
        //private List<string> courses = new();
        private List<CourseResult> coursesResult = new();
        public static uint StudentCounter = 1;

        public string GenerateNameCard()
        {
            return $"{this.Name} (STUDENT)";
        }

        public double DetermineWorkload()
        {
            return this.coursesResult.Count * 10.00;
        }


        public void RegisterCourseResult(string course, byte result)
        {
            if(result > 20)
            {
                Console.WriteLine("Ongeldig cijfer!");
                return;
            }

            CourseResult newResult = new();
            newResult.Name = course;
            newResult.Result = result;

            coursesResult.Add(newResult);

        }


        public double Average()
        {

            byte total = 0;

            foreach (var course in this.coursesResult)
            {
                total += course.Result;
            }

            return Math.Round((double)total / coursesResult.Count, 1);
        }

        public void ShowOverview()
        {
            Console.WriteLine("");
            Console.WriteLine($"{this.Name}");
            Console.WriteLine($"Werkbelasting: {this.DetermineWorkload()} uren");
            Console.WriteLine("Cijferrapport");
            Console.WriteLine("*************");

            foreach (var item in this.coursesResult)
            {
              
                Console.WriteLine($"{item.Name + ":",-20} {item.Result}");     
            }

            Console.WriteLine($"{"Gemiddelde:",-20} {Average()}");
            Console.WriteLine("");

        }


    }
}
