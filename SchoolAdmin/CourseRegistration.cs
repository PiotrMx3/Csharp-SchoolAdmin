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
        private  Course _course;
        private byte? _result;
        private  Student _student; 

        public static ImmutableList<CourseRegistration> AllCourseRegistrations = ImmutableList<CourseRegistration>.Empty;



        public CourseRegistration(Course course, byte? result, Student student)

        {
            Course = course;
            Result = result;
            Student = student;

            AllCourseRegistrations = AllCourseRegistrations.Add(this);
        }



        public Student Student
        {
            get
            {
                return this._student;
            }
            private set
            {
                if (value is null) throw new ArgumentException("Student/cursus mag niet ontbreken.");
                this._student = value;
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
                 if (value is null) throw new ArgumentException("Student/cursus mag niet ontbreken.");
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
                if (value is null || value <= 20 && value >= 0)
                {
                    this._result = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Resultaat moet tussen 0 en 20 liggen.");
                }
            }
        }

    }
}
