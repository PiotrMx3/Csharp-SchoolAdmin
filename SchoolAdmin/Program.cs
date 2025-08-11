

using System.Collections.Immutable;
using System.Data;

namespace SchoolAdmin
{
    internal class Program
    {


        static void Main(string[] args)
        {

            bool running = true;

            while (running)
            {
                Console.WriteLine("Wat wil jij doen ?\n");
                Console.WriteLine("1. Demonstreer Studenten Uitvoeren");
                Console.WriteLine("2. Demonstreer Cursusen Uitvoeren");
                Console.WriteLine("3. Student uit tekstformaat inlezen");
                Console.WriteLine("4. Demonstreer StudyProgram Uitvoeren");
                Console.WriteLine("5. Demonstreer AdministrativePersonnel Uitvoeren");
                Console.WriteLine("6. Demonstreer Lector Uitvoeren");
                Console.WriteLine("7. Student toevoegen");
                Console.WriteLine("8. Cursus toevoegen");
                Console.WriteLine("9. Vakinschrijving toevoegen");
                Console.WriteLine("10. Inschrijvingsgegevens tonen");





                Console.Write("\nMaak een keuze : ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        DemoStudents();
                        break;

                    case "2":
                        DemoCourses();        
                        break;
                    case "3":
                        ReadTextFormatStudent();
                        break;
                    case "4":
                        DemoStudyProgram();
                        break;
                    case "5":
                        DemoAdministrativeStaff();
                        break;
                    case "6":
                        DemoLecturers();
                        break;
                    case "7":
                        NewStudent();
                        break;
                    case "8":
                        NewCourse();
                        break;

                    case "9":
                        NewCourseRegistration();
                        break;

                    case "10":
                        ShowCourseRegistrations();
                        break;

                    case "stop":
                        running = false;
                         break;
             

                    default:
                        Console.WriteLine("\nOnbekende keuze");
                        break;
                }

            }

           
        }



        public static void ShowCourseRegistrations()
        {
            Console.WriteLine("Alle Studenten");
            Console.WriteLine();
            foreach (var item in Student.AllStudents)
            {
                Console.WriteLine(item.Name);
            }
            Console.WriteLine();


            Console.WriteLine("Alle Cursussen");
            Console.WriteLine();
            foreach (var item in Course.AllCourses)
            {
                Console.WriteLine(item.Title);
            }
            Console.WriteLine();


            foreach (var item in CourseRegistration.AllCourseRegistrations)
            {
                Console.WriteLine($"{item.Student.Name} ingeschrijven voor {item.Course.Title}");
            }

            Console.WriteLine();
        }

        public static void NewCourseRegistration()
        {
            var students = Student.AllStudents;
            var courses = Course.AllCourses;

            if (students.Count <= 0 || courses.Count <= 0)
            {
                Console.WriteLine("Er zijn geen studenten of cursussen --> inschrijving niet mogelijk !");
                return;
            }


            Console.WriteLine("Welke student ?");

            for (int i = 0; i < students.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {students[i].Name}");
            }

            int studentChoice = Convert.ToInt32(Console.ReadLine());



            Console.WriteLine("Welke cursus ? ");

            for (int i = 0; i < courses.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {courses[i].Title}");
            }


            int courseChoice = Convert.ToInt32(Console.ReadLine());


            Console.WriteLine("Wil jij een resultaat toekennen? (ja/nee) ");

            string answer = Console.ReadLine();

            if(answer.ToLower() == "ja")
            {

                Console.WriteLine("Wat is het resultaat (0-20) ? ");

                byte result = Convert.ToByte(Console.ReadLine());
                CourseRegistration newReg = new(courses[courseChoice - 1], result, students[studentChoice - 1]);

            }
            else if (answer.ToLower() == "nee")
            {
                CourseRegistration newReg = new(courses[courseChoice - 1], null, students[studentChoice - 1]);

            }
            else
            {
                Console.WriteLine("Er ging iets mis probeer opnieuw ");
                return;
            }



        } 


        public static void NewCourse()
        {
            Console.WriteLine("Titel van de cursus ?");
            string title = Console.ReadLine();

            Console.WriteLine("Aantal studiepunten ?");
            byte creditPoints = Convert.ToByte(Console.ReadLine());

            Course newCourse = new(title, creditPoints);

            Console.WriteLine($"Cursus met ID {newCourse.Id} is aangemaakt");
        }





        public static void NewStudent()
        {
            Console.WriteLine("Naam van de student ?");
            string name = Console.ReadLine();

            Console.WriteLine("Wat is de geborte datum van Student ? (dd/mm/jjjj)");
            string birthDate = Console.ReadLine();
    

            Student newStudent = new(name, DateTime.Parse(birthDate));

            if(newStudent is not null)
            {
                Console.WriteLine($"Student met ID: {newStudent.Id} is aangemaakt");
            }
            else
            {
                Console.WriteLine("Geen nieuwe student toegevoegd probeer op het nieuw");
            }

        }


        public static void DemoLecturers()
        {
            Course economie = new Course("Economie");
            Course statics = new Course("Statistiek");
            Course analiticsMath = new Course("Amalystische Meetkunde");


            var temp = new Dictionary<Course, double>
            {
                [economie] = 3,
                [statics] = 3,
                [analiticsMath] = 4
            };

            Lector anna = new Lector("Anna Bolazno", new DateTime(1975, 06, 12), ImmutableDictionary<string, byte>.Empty, temp);

            Console.WriteLine();
            Console.WriteLine($"{anna.GenerateNameCard()}");
            foreach (var item in anna.Courses.Keys)
            {
                Console.WriteLine($"{item.Title}");
            }
            Console.WriteLine();

            Console.WriteLine($"{anna.DetermineWorkload()}");
            Console.WriteLine($"{anna.CalculateSalary()}");


            Console.WriteLine();


            Console.WriteLine("Alle Lectoren :");
            foreach (var item in Lector.AllLecotren)
            {
                Console.WriteLine($"{item.Name}");
            }



        }


        public static void DemoAdministrativeStaff()
        {

            var temp = new Dictionary<string, byte>
            {
                ["Roostering"] = 10,
                ["Correspondentie"] = 10,
                ["Animatie"] = 10
            };

            ImmutableDictionary<string, byte> userTasks = temp.ToImmutableDictionary();

            AdministrativeStaff ahmed = new AdministrativeStaff("Ahmed", new DateTime(1988, 02, 04), userTasks);




            foreach (var adminuser in AdministrativeStaff.AllAdminStaff)
            {
                Console.WriteLine($"{adminuser.GenerateNameCard()}\n" +
                    $"{adminuser.CalculateSalary()}\n" +
                    $"{adminuser.DetermineWorkload()}");
            }



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

        public static void ReadTextFormatStudent()
        {
            Console.WriteLine("Geef de tekstvoorstelling van 1 student in CSV-formaat:");
            string csv = Console.ReadLine();

            string[] readCsv = csv.Split(";");

            string[] newUser = new string[4];

            List<string> courseInfo = new List<string>();

            for (int i = 0; i < readCsv.Length; i++)
            {
                if (i <= 3)
                {
                    newUser[i] = readCsv[i];
                }
                else
                {
                    courseInfo.Add(readCsv[i]);

                }

            }

            int day = Convert.ToInt32(readCsv[1]);
            int month = Convert.ToInt32(readCsv[2]);
            int year = Convert.ToInt32(readCsv[3]);

            Student newStundent = new(readCsv[0], new DateTime(year, month, day));


            Course communicatie = new("Communicatie");
            Course programmeren = new("Programmeren");
            Course webtechnologie = new("Webtechnologie");
            Course databanken = new("Databanken");


            for (int i = 0; i < courseInfo.Count; i += 2)  // hier was ook belangrijk dat de teller met 2 verhoogd wordt zo dat jij altijd string + getal hebt
            {
                byte result = Convert.ToByte(courseInfo[i + 1]);

                Course? course = Course.SearchCourseById(Convert.ToInt32(courseInfo[i]));


                if (course is not null)
                {
                    newStundent.RegisterCourseResult(course, result);
                }

            }

            newStundent.ShowOverview();


        }



        public static void DemoCourses()
        {
            Student said = new("Said Aziz", new DateTime(2000, 12, 23));
            Student mieke = new("Mike Vermeulen", new DateTime(1998, 1, 1));



            Course communicatie = new("Communicatie", 6);
            Course programmeren = new("Programmeren");
            Course webtechnologie = new("Webtechnologie");
            Course databanken = new("Databanken");



            said.RegisterCourseResult(communicatie, 12);
            said.RegisterCourseResult(programmeren, 15);
            said.RegisterCourseResult(webtechnologie, 13);


            mieke.RegisterCourseResult(communicatie, 13);
            mieke.RegisterCourseResult(programmeren, 16);
            mieke.RegisterCourseResult(databanken, 14);


            communicatie.ShowOverview();
            programmeren.ShowOverview();
            webtechnologie.ShowOverview();
            databanken.ShowOverview();
        }






        public static void DemoStudents()
        {
            Student said = new("Said Aziz", new DateTime(2000, 12, 23));
            Student mieke = new("Mike Vermeulen", new DateTime(1998, 1, 1));



            Course communicatie = new("Communicatie", 6);
            Course programmeren = new("Programmeren");
            Course webtechnologie = new("Webtechnologie");
            Course databanken = new("Databanken");





            said.RegisterCourseResult(communicatie, 12);
            said.RegisterCourseResult(programmeren, null);
            said.RegisterCourseResult(webtechnologie, 13);

            said.ShowOverview();

            mieke.RegisterCourseResult(communicatie, 13);
            mieke.RegisterCourseResult(programmeren, 16);
            mieke.RegisterCourseResult(databanken, 14);


            mieke.ShowOverview();

        }

    }

}
