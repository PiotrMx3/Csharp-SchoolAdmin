using System;
using System.Collections.Generic;
using System.Collections.Immutable;
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

        private static ImmutableList<Course> allCourses = ImmutableList<Course>.Empty;



        public Course(string title, List<Student> students, byte creditPoints)
        {
            this.Title = title;
            this.Students = students;
            CreditPoints = creditPoints;
            this.id = maxId;
            allCourses = allCourses.Add(this);

            maxId++;

        }

        public Course(string title, List<Student> students) : this(title, students, 3)
        {

        }


        public static ImmutableList<Course> AllCourses
        {
            get
            {
                return allCourses;
            }
        }


        public Course(string title) : this(title, new List<Student>(), 3)
        {

        }

        public static Course? SearchCourseById(int searchId)
        {


            for (int i = 0; i < allCourses.Count; i++)
            {
                if (allCourses[i].Id == searchId)
                {
                    return allCourses[i];
                }
            }

            return null;
        }

        public override bool Equals(object? obj)
        {
            if (obj is not Course other) return false;

            return this.Id == other.Id;
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        public static List<Course> coursesCopy(List<Course> coursesList)
        {
            List<Course> copy = new();

            for (int i = 0; i < coursesList.Count; i++)
            {
                Course copyCourse = coursesList[i].Clone();
                copy.Add(copyCourse);
            }

            return copy;
        }
        public Course Clone()
        {
            Course copy = new Course(this.Title);
            copy.Students = this.Students;
            copy.id = this.Id;
            copy.creditPoints = this.CreditPoints;

            return copy;
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
