using System;

namespace Demo_Avoid_Primitive_Types
{
    public sealed class PersonalName
    {
        public string FirstName { get; }
        public string MiddleName { get; }
        public string LastName { get; }

        /// <summary>
        /// Initialises a new instance of the <see cref="PersonalName"/> class.
        /// </summary>
        public PersonalName(string firstName, string middleName, string lastName)
        {
            if (IsBadMandatoryPart(firstName) 
                || IsBadOptionalPart(middleName)
                || IsBadMandatoryPart(lastName))
                throw new ArgumentException();

            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
        }

        private bool IsBadOptionalPart(string part) =>
            part is null ||
            part.Length > 0 && char.IsHighSurrogate(part[^1]);

        private bool IsBadMandatoryPart(string part) =>
            IsBadOptionalPart(part) || part == string.Empty;

        private bool ArePartsEqual(string part1, string part2) => 
            string.CompareOrdinal(part1, part2) == 0;

        private bool Equals(PersonalName other) =>
            other is object 
            && ArePartsEqual(FirstName, other.FirstName)
            && ArePartsEqual(MiddleName, other.MiddleName)
            && ArePartsEqual(LastName, other.LastName);

        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj) || obj is PersonalName other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(FirstName, MiddleName, LastName);
        }
    }
}
