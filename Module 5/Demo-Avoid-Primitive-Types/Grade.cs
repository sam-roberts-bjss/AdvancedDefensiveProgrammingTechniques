namespace Demo_Avoid_Primitive_Types
{
    public sealed class Grade
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="Grade"/> class.
        /// </summary>
        private Grade()
        {
        }

        public static Grade A { get; } = new Grade();
        public static Grade B { get; } = new Grade();
        public static Grade C { get; } = new Grade();
        public static Grade D { get; } = new Grade();
        public static Grade E { get; } = new Grade();
        public static Grade F { get; } = new Grade();
    }
}
