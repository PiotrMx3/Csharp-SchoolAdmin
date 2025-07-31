

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
                Console.WriteLine("1. DemonstreerStudenten Uitvoeren");
                Console.WriteLine("2. DemonstreerCurssusen Uitvoeren");
                Console.WriteLine("3. ReadTextFormatStudent Uitvoeren");
                Console.WriteLine("4. DemoStudyProgram Uitvoeren");
                Console.WriteLine("5. DemoAdministrativePersonnel Uitvoeren");
                Console.WriteLine("6. DemoLector Uitvoeren");


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
                        StudyProgram.DemoStudyProgram();
                        break;
                    case "5":
                        DemoAdministrativeStaff();
                        break;
                    case "6":
                        DemoLecturers();
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


        public static void DemoCourses()
        {
            Student said = new("Said Aziz", new DateTime(2000, 12, 23));
            Student mieke = new("Mike Vermeulen", new DateTime(1998, 1, 1));


            List<Student> students = new() { said, mieke };



            Course communicatie = new("Communicatie", students, 6);

            communicatie.ShowOverview();


            Course programmeren = new("Programmeren", students);

            programmeren.ShowOverview();


            Course webtechnologie = new("Webtechnologie");
            webtechnologie.Students.Add(said);


            webtechnologie.ShowOverview();


            Course databanken = new("Databanken");
            databanken.Students.Add(mieke);

            databanken.ShowOverview();

            said.RegisterCourseResult(communicatie, 12);
            said.RegisterCourseResult(programmeren, 15);
            said.RegisterCourseResult(webtechnologie, 13);


            mieke.RegisterCourseResult(communicatie, 13);
            mieke.RegisterCourseResult(programmeren, 16);
            mieke.RegisterCourseResult(databanken, 14);
            

        }




        public static void DemoStudents()
        {
            Student said = new("Said Aziz", new DateTime(2000, 12, 23));
            Student mieke = new("Mike Vermeulen", new DateTime(1998, 1, 1));

            List<Student> students = new() { said, mieke };


            Course communicatie = new("Communicatie", students, 6);

            Course programmeren = new("Programmeren", students);

            Course webtechnologie = new("Webtechnologie");
            webtechnologie.Students.Add(said);

            Course databanken = new("Databanken");
            databanken.Students.Add(mieke);




            said.RegisterCourseResult(communicatie, 12);
            said.RegisterCourseResult(programmeren, null);
            said.RegisterCourseResult(webtechnologie, 13);

            said.ShowOverview();

            mieke.RegisterCourseResult(communicatie, 13);
            mieke.RegisterCourseResult(programmeren, 16);
            mieke.RegisterCourseResult(databanken, 14);
            

            mieke.ShowOverview();

        }

        public static void ReadTextFormatStudent()
        {
            Console.WriteLine("Geef de tekstvoorstelling van 1 student in CSV-formaat:");
            string csv = Console.ReadLine();

            string[] readCsv = csv.Split(";");
            string[] spelerInfo = new string[4];
            List<string> courseInfo = new List<string>();

            for (int i = 0; i < readCsv.Length; i++)
            {
                if (i <= 3)
                {
                    spelerInfo[i] = readCsv[i]; 
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

            Lector anna = new Lector("Anna Bolazno", new DateTime(1975, 06, 12), ImmutableDictionary<string, byte>.Empty, temp );

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

    }

}
