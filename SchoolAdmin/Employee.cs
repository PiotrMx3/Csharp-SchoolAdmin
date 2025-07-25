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
        private ImmutableDictionary<string, byte> _tasks = ImmutableDictionary<string, byte>.Empty;
        private static ImmutableList<Employee> _allEmployees = ImmutableList<Employee>.Empty;

        public Employee(string name, DateTime birthDate, ImmutableDictionary<string, byte> tasks) : base(name, birthDate)
        {
            _tasks = _tasks.AddRange(tasks);
            _allEmployees = _allEmployees.Add(this);
            _hireDate = DateTime.Now;
        }


        public byte Seniority
        {
            get 
            {
                int years = DateTime.Now.Year - _hireDate.Year;

                if(_hireDate > DateTime.Now.AddYears(-years))
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
            get { return _allEmployees; }
        }

        public abstract uint CalculateSalary();

    }
}
