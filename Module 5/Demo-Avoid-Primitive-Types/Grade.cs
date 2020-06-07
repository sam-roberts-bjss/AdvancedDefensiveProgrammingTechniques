namespace Demo_Avoid_Primitive_Types
{
    public sealed class Grade
    {
        private double NumericEquivalent { get; }

        /// <summary>
        /// Initialises a new instance of the <see cref="Grade"/> class.
        /// </summary>
        private Grade(double numericEquivalent)
        {
            NumericEquivalent = numericEquivalent;
        }

        public static Grade A { get; } = new Grade(5);
        public static Grade B { get; } = new Grade(4);
        public static Grade C { get; } = new Grade(3);
        public static Grade D { get; } = new Grade(2);
        public static Grade E { get; } = new Grade(1);
        public static Grade F { get; } = new Grade(0);
    }
}
