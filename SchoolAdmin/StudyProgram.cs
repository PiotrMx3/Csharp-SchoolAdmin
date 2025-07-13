using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAdmin
{
    internal class StudyProgram
    {
        private string name;
        private ImmutableList<Course> courses = ImmutableList<Course>.Empty;

        public StudyProgram(string nameProgram)
        {
            this.name = nameProgram;
        }
        public string Name
        {
            get
            {
                return this.name;
            }
        }

        public  ImmutableList<Course> Courses
        {
            get
            {
                return this.courses;
            }
        }

        public void AddCourses(List<Course> NewCourses)
        {
            this.courses = this.courses.AddRange(NewCourses);
        }

        public static void DemoStudyProgram()
        {
            Course communicatie = new Course("Communicatie");
            Course programmeren = new Course("Programmeren");
            Course databanken = new Course("Databanken");

            List<Course> courses = new List<Course>() { communicatie, programmeren, databanken };

            StudyProgram programmerenProgram = new StudyProgram("Programmeren");
            StudyProgram snbProgram = new StudyProgram("Systeem- en netwerkbeheer");

            programmerenProgram.AddCourses(courses);
            snbProgram.AddCourses(courses);


            programmerenProgram.ShowOverview();
            snbProgram.ShowOverview();
        }

        public void ShowOverview()
        {
            Console.WriteLine($"{Name}");
                Console.WriteLine("");

            foreach (Course item in Courses)
            {
                Console.WriteLine(item.Title);
            }
                Console.WriteLine("");
        }
    }
}
