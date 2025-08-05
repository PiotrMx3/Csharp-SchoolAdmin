using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAdmin
{
    internal class CourseRegistration
    {
        private Course _course;
        private byte? _result;

        public static ImmutableList<CourseRegistration> AllCourseRegistrations = ImmutableList<CourseRegistration>.Empty;

        private readonly Student _student; 


        public CourseRegistration(Course course, byte? result, Student student)
        {
            _course = course;
            _result = result;
            _student = student;

            AllCourseRegistrations = AllCourseRegistrations.Add(this);
        }

        public Student Student
        {
            get
            {
                return this._student;
            }
        }

        public Course Course
        {
            get
            {
                return this._course;
            }
            private set
            {
                _course = value;
            }
        }

        public byte? Result
        {
            get
            {
                return this._result;
            }
            set
            {
                if (value is not null and <= 20)
                {
                    this._result = value;
                }
                else
                {
                    Console.WriteLine("Resultaat moet tussen 0 en 20 liggen.");
                }
            }
        }

    }
}
