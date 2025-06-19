

using System.Data;

namespace SchoolAdmin
{
    internal class Program
    {

        static void Main(string[] args)
        {

            Console.WriteLine("Wat wil jij doen ?\n");
            Console.WriteLine("1. DemonstreerStudenten Uitvoeren\n");

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

                    case "stop":
                        running = false;
                         break;
             

                    default:
                        Console.WriteLine("\nOnbekende keuze");
                        break;
                }

            }

        }



        public static void DemoStudents()
        {
            Student said = new();
            Student mieke = new();


            said.Name = "Said Aziz";
            said.BirthDate = new DateTime(2000, 12, 23);
            said.StudentNumber = Student.StudentCounter;
            said.RegisterForCourse("Programmeren");
            said.RegisterForCourse("Databanken");
            Student.StudentCounter++;
            Console.WriteLine($"\n{said.GenerateNameCard()}\n" +
                $"Werkbelasting van {said.Name}: {said.DetermineWorkload()}u/week");



            mieke.Name = "Mike Vermeulen";
            mieke.BirthDate = new DateTime(1998, 1, 1);
            mieke.StudentNumber = Student.StudentCounter;
            mieke.RegisterForCourse("Communicatie");
            Student.StudentCounter++;
            Console.WriteLine($"\n{mieke.GenerateNameCard()}\n" +
                $"Werkbelasting van {mieke.Name}: {mieke.DetermineWorkload()}u/week");

        }

    }
}
