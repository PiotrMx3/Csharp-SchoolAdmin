

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
                Console.WriteLine("2. DemonstreerCurssusen Uitvoeren\n");
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

            said.RegisterCourseResult("Communicatie", 12);
            said.RegisterCourseResult("Programmeren", 15);
            said.RegisterCourseResult("Webtechnologie", 13);


            mieke.RegisterCourseResult("Communicatie", 13);
            mieke.RegisterCourseResult("Programmeren", 16);
            mieke.RegisterCourseResult("Databanken", 14);



            Course communicatie = new("Communicatie", new Student[] { mieke, said }, 3);
            communicatie.Title = "Communicatie";

            communicatie.Students.Add(said);
            communicatie.Students.Add(mieke);

            communicatie.ShowOverview();

       

            Course programmeren = new();
            programmeren.Title = "Programmeren";

            programmeren.Students.Add(said);
            programmeren.Students.Add(mieke);

            programmeren.ShowOverview();

            Course webtechnologie = new();
            webtechnologie.Title = "Webtechnologie";

            webtechnologie.Students.Add(said);

            webtechnologie.ShowOverview();


            Course databanken = new();
            databanken.Title = "Databanken";

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

    }
}
