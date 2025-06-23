using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAdmin
{
    internal class Course
    {
        public string Title;
        public List<Student> Students = new();
        private int id;
        private static int maxId = 1;
        private byte creditPoints;

        public static List<Course> AllCourses = new();



        public Course()
        {
            this.id = maxId;
            maxId++;

        }


        public byte CreditPoints
        {
            get
            {
                return this.creditPoints;
            }
            private set
            {
                this.creditPoints = value;
            }
        }



        public int Id
        {
         get
            {
                return this.id;
            }
           
        }


        public void ShowOverview()
        {
            Console.WriteLine($"{this.Title}");

            foreach (var student in this.Students) 
            {
                Console.WriteLine($"{student.Name}");
            }

                Console.WriteLine($"");

        }
    }

}
