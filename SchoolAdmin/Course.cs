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
        public List<Student> Students;
        private int id;
        private static int maxId = 1;
        private byte creditPoints;

        public static List<Course> AllCourses = new();


        public static Course? SearchCourseById(int searchId)
        {


            for (int i = 0; i < AllCourses.Count; i++)
            {
                if (AllCourses[i].Id == searchId)
                {
                    return AllCourses[i];
                } 
            }

            return null;
        }


        public Course(string title, List<Student> students, byte creditPoints)
        {
            this.Title = title;
            this.Students = students;
            CreditPoints = creditPoints;
            this.id = maxId;

            AllCourses.Add(this);
            maxId++;

        }

        public Course(string title, List<Student> students) : this(title, students, 3)
        {

        }


        public Course(string title) : this(title, new List<Student>(), 3)
        {

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
            Console.WriteLine($"{this.Title} ({Id}) ({CreditPoints}stp)");

            foreach (var student in this.Students) 
            {
                Console.WriteLine($"{student.Name}");
            }

                Console.WriteLine($"");

        }
    }

}
