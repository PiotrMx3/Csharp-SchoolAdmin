using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAdmin
{
    internal class AdministrativeStaff : Employee
    {
        private static ImmutableList<AdministrativeStaff> _allAdminStaff = ImmutableList<AdministrativeStaff>.Empty;


        public AdministrativeStaff(string name, DateTime birthDate, ImmutableDictionary<string, byte> tasks) : base(name, birthDate, tasks)
        {
            _allAdminStaff = _allAdminStaff.Add(this);
        }
        public override uint CalculateSalary()
        {
            double basisSalary = 2000.00 + (Math.Floor(Seniority / 3.00) * 75.00);

            if (DetermineWorkload() < 40) return (uint)(Math.Round((basisSalary / 40.00) * DetermineWorkload()));

            return (uint)basisSalary;

        }

        public override double DetermineWorkload()
        {
            double workLoad = 0.00;

            foreach (var item in _tasks.Values)
            {
                workLoad += item;
            }

            return workLoad;

        }

        public override string GenerateNameCard()
        {
            return $"{Name} (ADMINISTRATIE)";
        }

        public static ImmutableList<AdministrativeStaff> AllAdminStaff
        {
            get { return _allAdminStaff; }
        }
    }
}
