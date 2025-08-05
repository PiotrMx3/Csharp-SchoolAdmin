using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAdmin
{
    internal abstract class Employee : Person
    {
        private DateTime _hireDate;
        private protected ImmutableDictionary<string, byte> _tasks = ImmutableDictionary<string, byte>.Empty;


        public Employee(string name, DateTime birthDate, ImmutableDictionary<string, byte> tasks) : base(name, birthDate)
        {
            this._tasks = _tasks.AddRange(tasks);
            this._hireDate = DateTime.Now;
        }


        public byte Seniority
        {
            get 
            {
                int years = DateTime.Now.Year - this._hireDate.Year;

                if(this._hireDate > DateTime.Now.AddYears(-years))
                {
                    years--;
                }

                return (byte)(years > 50 ? 50 : years);
            }
        }

        public ImmutableDictionary<string, byte> Tasks
        {
            get { return this._tasks; }
        }
        
        public static ImmutableList<Employee> AllEmployees
        {
            get 
            {
                List<Employee> employees = new();

                foreach (var item in AllPersons)
                {
                    if (item is Employee e) employees.Add(e);
                }

                return employees.ToImmutableList();
            }
        }

        public abstract uint CalculateSalary();

    }
}
