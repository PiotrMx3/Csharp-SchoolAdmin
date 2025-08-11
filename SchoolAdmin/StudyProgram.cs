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
        private ImmutableDictionary<Course, byte> _studyCourses = ImmutableDictionary<Course,byte>.Empty;
        private Dictionary<Course, string> _studyAlias = new();


        public ImmutableDictionary<Course, byte> StudyCourses 
        {
            get { return this._studyCourses; }
        }


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

        public string ReadAlias(Course c)
        {
            return _studyAlias.TryGetValue(c, out var alias) ? alias : c.Title;
        }
        public void SetAlias(Course c, string alias)
        {
            _studyAlias[c] = alias;
        }

        public void AddCourses(Course course, byte semester )
        {

            if (course is null) return;

            if (_studyCourses.ContainsKey(course))
            {
                Console.WriteLine("Deze curssus bestaat al...");
                return;
            }

            if (semester != 1 && semester != 2)
            {
                Console.WriteLine("Toegelaten wardes 1 of 2");
                return;
            }

            _studyCourses = _studyCourses.Add(course, semester);


        }

        public static void DemoStudyProgram()
        {
            Course communicatie = new Course("Communicatie");
            Course programmeren = new Course("Programmeren");
            Course databanken = new Course("Databanken");


            StudyProgram programmerenProgram = new StudyProgram("Programmeren");
            StudyProgram snbProgram = new StudyProgram("Systeem- en netwerkbeheer");


            programmerenProgram.AddCourses(communicatie, 1);
            programmerenProgram.AddCourses(programmeren, 1);
            programmerenProgram.AddCourses(databanken, 1);


            snbProgram.AddCourses(communicatie, 2);
            snbProgram.AddCourses(programmeren, 1);
            snbProgram.AddCourses(databanken, 1);

            snbProgram.SetAlias(communicatie, "scripting");



            programmerenProgram.ShowOverview();
            snbProgram.ShowOverview();

        }

        public void ShowOverview()
        {
            List<Course> semester1 = new();
            List<Course> semester2 = new();


            foreach (var course in _studyCourses )
            {
                if (course.Value == 1) semester1.Add(course.Key);
                if (course.Value == 2) semester2.Add(course.Key);

            }

            Console.WriteLine($"Programma: {Name}");
                Console.WriteLine("");

            int counter = 1;

            Console.WriteLine("Semester 1 ");
            Console.WriteLine("");
            if(semester1.Count == 0)  Console.WriteLine("Geen cursussen");


            foreach (var item in semester1)
            {
                Console.WriteLine($"{this.ReadAlias(item)} ({counter}) ({item.CreditPoints}stp)");
                counter++;
            }
                Console.WriteLine("");

            counter = 1;

            Console.WriteLine("Semester 2 ");
            Console.WriteLine("");
            if (semester2.Count == 0) Console.WriteLine("Geen curssusen");

            foreach (var item in semester2)
            {
                Console.WriteLine($"{this.ReadAlias(item)} ({counter}) ({item.CreditPoints}stp)");
                counter++;
            }
                Console.WriteLine("");
        }
    }
}
