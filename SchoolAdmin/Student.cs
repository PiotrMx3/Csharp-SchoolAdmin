using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAdmin
{
    internal class Student : Person
    {

        private List<CourseRegistration> coursesRegistrations = new();
        private static ImmutableList<Student> _allStudents = ImmutableList<Student>.Empty;
        private ImmutableDictionary<DateTime, string> _studentFile = ImmutableDictionary<DateTime, string>.Empty;

        public Student(string name, DateTime birthDate) 
            : base(name, birthDate)
        {

            _allStudents = _allStudents.Add(this);
        }


        public static ImmutableList<Student> Students
        {
            get { return _allStudents; }
        }

        public ImmutableDictionary<DateTime, string> StudentFile
        {
            get { return this._studentFile; }
        }

        public void AddRemark(string comment)
        {
            _studentFile = this._studentFile.Add(DateTime.Now, comment);
        }

        public override string GenerateNameCard()
        {
            return $"{this.Name} (STUDENT)";
        }

        public override double DetermineWorkload()
        {
            return this.coursesRegistrations.Count * 10.00;
        }


        public void RegisterCourseResult(Course course, byte? result)
        {
            if(result > 20)
            {
                Console.WriteLine("Ongeldig cijfer!");
                return;
            }

            CourseRegistration newResult = new CourseRegistration(course, result);

            coursesRegistrations.Add(newResult);

        }


        public double Average()
        {

            double total = 0;
            int counter = 0;

            foreach (var course in this.coursesRegistrations)
            {
                if (course.Result is not null)
                {
                    total += (double)course.Result;
                    counter++;
                }
            }

            return Math.Round(total / counter, 1);
        }

        public void ShowOverview()
        {
            Console.WriteLine("");
            Console.WriteLine($"{this.Name} ({Age} jaar)");
            Console.WriteLine($"Werkbelasting: {this.DetermineWorkload()} uren");
            Console.WriteLine("Cijferrapport");
            Console.WriteLine("*************");

            foreach (var item in this.coursesRegistrations)
            {

                Console.WriteLine($"{item.Course.Title + ":",-20} {item.Result}");

            }

            Console.WriteLine($"{"Gemiddelde:",-20} {Average()}");
            Console.WriteLine("");

        }


    }
}
