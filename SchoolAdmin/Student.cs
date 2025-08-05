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
        private ImmutableDictionary<DateTime, string> _studentFile = ImmutableDictionary<DateTime, string>.Empty;

        public Student(string name, DateTime birthDate) 
            : base(name, birthDate)
        {

        }

        public ImmutableList<Course> Courses
        {
            get
            {
                var builder = ImmutableList.CreateBuilder<Course>();

                foreach (var reg in CourseRegistrations)
                {
                    builder.Add(reg.Course);
                }

                return builder.ToImmutable();
            }
        }


        public ImmutableList<CourseRegistration> CourseRegistrations
        {
            get
            {
                var builder = ImmutableList.CreateBuilder<CourseRegistration>();

                foreach (var reg in CourseRegistration.AllCourseRegistrations)
                {

                   if (reg.Student.Id == this.Id) builder.Add(reg);

                }

                return builder.ToImmutable();
            }
        } 

            public static ImmutableList<Student> AllStudents
            {
                get 
                {
                   
                    List < Student > temp = new();

                    foreach (var item in AllPersons)
                    {
                        if (item is Student s) temp.Add(s);
                    }

                    return temp.ToImmutableList();
                }
            }

        public ImmutableDictionary<DateTime, string> StudentFile
        {
            get { return this._studentFile; }
        }



        public override string ToString()
        {
            return
                    base.ToString() + "\n" + "Student" ;
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
            return this.CourseRegistrations.Count * 10.00;
        }


        public void RegisterCourseResult(Course course, byte? result)
        {
            if(result > 20)
            {
                Console.WriteLine("Ongeldig cijfer!");
                return;
            }

            CourseRegistration newResult = new CourseRegistration(course, result,this);

        }


        public double Average()
        {

            double total = 0;
            int counter = 0;

            foreach (var course in this.CourseRegistrations)
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

            foreach (var item in this.CourseRegistrations)
            {

                Console.WriteLine($"{item.Course.Title + ":",-20} {item.Result}");

            }

            Console.WriteLine($"{"Gemiddelde:",-20} {Average()}");
            Console.WriteLine("");

        }


    }
}
