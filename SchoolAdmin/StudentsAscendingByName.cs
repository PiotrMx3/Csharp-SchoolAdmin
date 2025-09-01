using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAdmin
{
    internal class StudentsAscendingByName : IComparer<Student>
    {
        public int Compare(Student? x, Student? y)
        {
            if (x is null || y is null) throw new ArgumentException("Objecten zijn null !");

            return x.Name.CompareTo(y.Name);
        }
    }

    internal class StudentsDescendingByName : IComparer<Student>
    {
        public int Compare(Student? x, Student? y)
        {
            if (x is null || y is null) throw new ArgumentException("Objecten zijn null !");

            return y.Name.CompareTo(x.Name);
        }
    }
}
