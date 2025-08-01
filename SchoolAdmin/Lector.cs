﻿using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAdmin
{
    internal class Lector : Employee
    {
        private static ImmutableList<Lector> _allLectoren = ImmutableList<Lector>.Empty;
        private Dictionary<Course, double> _courses;

        public Lector(string name, DateTime birthDate, ImmutableDictionary<string, byte> tasks, Dictionary<Course, double> courses) : base(name, birthDate, tasks)
        {
            _allLectoren = _allLectoren.Add(this);
            this._courses = courses ?? new Dictionary<Course, double>();
        }

        public override uint CalculateSalary()
        {
            double basisSalary = 2200.00 + (Math.Floor(Seniority / 4.00) * 120.00);

            if (DetermineWorkload() < 40) return (uint)(Math.Round((basisSalary / 40.00) * DetermineWorkload()));

            return (uint)basisSalary;
        }

        public override double DetermineWorkload()
        {
            double workLoad = 0.00;

            foreach (var item in _courses.Values)
            {
                workLoad += item;
            }

            return workLoad;
        }

        public override string GenerateNameCard()
        {
            return $"{Name}\n" +
                $"Lecotor voor :";
        }

        public static ImmutableList<Lector> AllLecotren
        {
            get { return _allLectoren; }
        }

        public Dictionary<Course, double> Courses
        {
            get { return this._courses; }
        }

        public void AddCourse(Course course, double workload)
        {
            this._courses[course] = workload;
        }
    }
}
