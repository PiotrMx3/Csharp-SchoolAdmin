

using System.Data;

namespace SchoolAdmin
{
    internal class Program
    {
        

        static void Main(string[] args)
        {

            Console.WriteLine("Wat wil jij doen ?\n");
            Console.WriteLine("1. DemonstreerStudenten Uitvoeren");
            Console.WriteLine("2. DemonstreerCurssusen Uitvoeren\n");


            bool running = true;

            while (running)
            { 
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
            
            Student said = new();
            Student mieke = new();

            said.Name = "Said Aziz";
            said.BirthDate = new DateTime(2000, 12, 23);
            said.StudentNumber = Student.StudentCounter;

            Student.StudentCounter++;

            said.RegisterCourseResult("Communicatie", 12);
            said.RegisterCourseResult("Programmeren", 15);
            said.RegisterCourseResult("Webtechnologie", 13);




            mieke.Name = "Mike Vermeulen";
            mieke.BirthDate = new DateTime(1998, 1, 1);
            mieke.StudentNumber = Student.StudentCounter;


            Student.StudentCounter++;

            mieke.RegisterCourseResult("Communicatie", 13);
            mieke.RegisterCourseResult("Programmeren", 16);
            mieke.RegisterCourseResult("Databanken", 14);

            


            Course communicatie = new();
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
            Student said = new();
            Student mieke = new();


            said.Name = "Said Aziz";
            said.BirthDate = new DateTime(2000, 12, 23);
            said.StudentNumber = Student.StudentCounter;

            said.RegisterCourseResult("Communicatie", 12);
            said.RegisterCourseResult("Programmeren", 15);
            said.RegisterCourseResult("Webtechnologie", 13);

            Student.StudentCounter++;
            said.ShowOverview();




            mieke.Name = "Mike Vermeulen";
            mieke.BirthDate = new DateTime(1998, 1, 1);
            mieke.StudentNumber = Student.StudentCounter;

            mieke.RegisterCourseResult("Communicatie", 13);
            mieke.RegisterCourseResult("Programmeren", 16);
            mieke.RegisterCourseResult("Databanken", 14);
            
            Student.StudentCounter++;
            mieke.ShowOverview();

        }

    }
}
