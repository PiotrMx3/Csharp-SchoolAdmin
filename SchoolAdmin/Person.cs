using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAdmin
{
    internal abstract class Person
    {
        private uint _id;
        private static uint maxId = 1;
        private string _name;
        private DateTime _birthDate;

        private static ImmutableList<Person> _allPersons = ImmutableList<Person>.Empty;

        public Person(string name, DateTime birthDate)
        {
            this._name = name;
            this._birthDate = birthDate;
            this._id = maxId;
            maxId++;
            
            _allPersons = _allPersons.Add(this);
        }


        public abstract string GenerateNameCard();
        public abstract double DetermineWorkload();

        public string Name
        {
            get { return this._name; }
            set { this._name = value; }
        }

        public int Age
        {
            get
            {
                DateTime now = DateTime.Now;


                int years = now.Year - this._birthDate.Year;

                if (this._birthDate.Month > now.Month)
                {
                    years--;
                }
                else if (this._birthDate.Month == now.Month)
                {

                    if (this._birthDate.Day > now.Day)
                    {
                        years--;
                    }

                }

                return years;
            }
        }

        public uint Id 
        {
            get { return this._id; }
        }

        public DateTime BirthDate
        {
            get { return this._birthDate; }
        }

        public static ImmutableList<Person> AllPersons
        {
            get { return _allPersons; }
        }

    }
}
