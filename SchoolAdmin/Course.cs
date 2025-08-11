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
        public string Title { get; set; }
        private int id;
        private static int maxId = 1;
        private byte _creditPoints;
            

        private static ImmutableList<Course> allCourses = ImmutableList<Course>.Empty;



        public Course(string title, byte creditPoints)
        {
            this.Title = title;
            CreditPoints = creditPoints;
            this.id = maxId;
            allCourses = allCourses.Add(this);

            maxId++;

        }

        public Course(string title) : this(title, 3)
        {

        }


        public  ImmutableList<Student> Students
        {
            get
            {
                var temp = ImmutableList.CreateBuilder<Student>();

                foreach (var reg in CourseRegistrations)
                {
                    temp.Add(reg.Student);
                }

                return temp.ToImmutable();
               
            }
        }

        public ImmutableList<CourseRegistration> CourseRegistrations
        {
           get
            {
                var temp = ImmutableList.CreateBuilder<CourseRegistration>();

                foreach (var reg in CourseRegistration.AllCourseRegistrations)
                {
                    if (reg.Course.Id == this.Id) temp.Add(reg);
                }

                return temp.ToImmutable();
            }
        }

        public static ImmutableList<Course> AllCourses
        {
            get
            {
                return allCourses;
            }
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

        //public static List<Course> coursesCopy(List<Course> coursesList)
        //{
        //    List<Course> copy = new();

        //    for (int i = 0; i < coursesList.Count; i++)
        //    {
        //        Course copyCourse = coursesList[i].Clone();
        //        copy.Add(copyCourse);
        //    }

        //    return copy;
        //}
        public Course Rename(string newName)
        {
            Course newCourseName = new Course(newName);
            newCourseName._creditPoints = this.CreditPoints;

            return newCourseName;
        }



        public byte CreditPoints
        {
            get
            {
                return this._creditPoints;
            }
            private set
            {
                this._creditPoints = value;
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

            foreach (var student in Students) 
            {
                Console.WriteLine($"{student.Name}");
            }

                Console.WriteLine($"");

        }
        
    }



}
