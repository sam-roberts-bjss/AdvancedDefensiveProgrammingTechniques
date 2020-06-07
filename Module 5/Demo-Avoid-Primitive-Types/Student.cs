using System;

namespace Demo_Avoid_Primitive_Types
{
    public sealed class Student
    {
        public PersonalName Name { get; }

        public Student(PersonalName name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        public void AddGrade(Subject subject, Grade grade)
        {
            if (subject is null) 
                throw new ArgumentNullException(nameof(subject));

            if (grade is null) 
                throw new ArgumentNullException(nameof(grade));


        }
    }
}
