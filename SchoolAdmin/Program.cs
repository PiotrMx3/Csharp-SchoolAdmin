

using System.Data;

namespace SchoolAdmin
{
    internal class Program
    {
        enum Weekdagen { Maandag, Dinsdag, Woensdag, Donderdag, Vrijdag, Zaterdag, Zondag };


        static void Main(string[] args)
        {



            Student said = new();
            Student mieke = new();


            said.Name = "Said Aziz";
            said.BirthDate = new DateTime(2000, 12, 23);
            said.StudentNumber = Student.StudentCounter;
            said.Courses.Add("Programmeren");
            said.Courses.Add("Databanken");
            Student.StudentCounter++;



            mieke.Name = "Mike Vermeulen";
            mieke.BirthDate = new DateTime(1998, 1, 1);
            mieke.StudentNumber = Student.StudentCounter;
            mieke.Courses.Add("Programmeren");
            mieke.Courses.Add("Databanken");
            Student.StudentCounter++;





        }

    }
}
