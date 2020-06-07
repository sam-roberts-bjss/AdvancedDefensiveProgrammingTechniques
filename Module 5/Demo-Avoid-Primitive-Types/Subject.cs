using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo_Avoid_Primitive_Types
{
    public sealed class Subject
    {
        public string Name { get; }
        
        public IList<Student> EnlistedStudents { get; } = new List<Student>();

        public Subject(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        public void Enlist(Student student)
        {
            if (student is null) 
                throw new ArgumentNullException(nameof(student));

            EnlistedStudents.Add(student);
        }

        public void AssignGrades(IEnumerable<(PersonalName name, Grade grade)> grades)
        {
            var listedGrades = grades
                .Select(item => new
                {
                    Student = EnlistedStudents.First(student => student.Name.Equals(item.name)),
                    Grade = item.grade
                });

            foreach (var studentGrade in listedGrades)
            {
                studentGrade.Student.AddGrade(this, studentGrade.Grade);
            }
        }
    }
}
