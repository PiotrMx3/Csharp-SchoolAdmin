

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
                Console.WriteLine("3. ReadTextFormatStudent Uitvoeren\n");
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


            said.RegisterCourseResult("Communicatie", 12);
            said.RegisterCourseResult("Programmeren", 15);
            said.RegisterCourseResult("Webtechnologie", 13);

            
            mieke.RegisterCourseResult("Communicatie", 13);
            mieke.RegisterCourseResult("Programmeren", 16);
            mieke.RegisterCourseResult("Databanken", 14);


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


        }




        public static void DemoStudents()
        {
            Student said = new("Said Aziz", new DateTime(2000, 12, 23));
            Student mieke = new("Mike Vermeulen", new DateTime(1998, 1, 1));

            said.RegisterCourseResult("Communicatie", 12);
            said.RegisterCourseResult("Programmeren", 15);
            said.RegisterCourseResult("Webtechnologie", 13);

            said.ShowOverview();

            mieke.RegisterCourseResult("Communicatie", 13);
            mieke.RegisterCourseResult("Programmeren", 16);
            mieke.RegisterCourseResult("Databanken", 14);
            

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

            foreach (var item in courseInfo)
            {
                Console.WriteLine(item);
            }

            for (int i = 0; i < courseInfo.Count; i += 2)  // hier was ook belangrijk dat de teller met 2 verhoogd wordt zo dat jij altijd string + getal hebt
            {
                byte result = Convert.ToByte(courseInfo[i + 1]);
                newStundent.RegisterCourseResult(courseInfo[i], result);
            }

            newStundent.ShowOverview();


        }

    }
}
