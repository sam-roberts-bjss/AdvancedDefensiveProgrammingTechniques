using System;

namespace Demo
{
    public abstract class Either<TLeft, TRight>
    {
        public abstract Either<TNewLeft, TRight> MapLeft<TNewLeft>(Func<TLeft, TNewLeft> mapping);

        public abstract Either<TLeft, TNewRight> MapRight<TNewRight>(Func<TRight, TNewRight> mapping);

        public abstract TLeft Reduce(Func<TRight, TLeft> mapping);
    }

    public sealed class Left<TLeft, TRight> : Either<TLeft, TRight>
    {
        private TLeft Value { get; }

        public Left(TLeft value)
        {
            Value = value;
        }

        public override Either<TNewLeft, TRight> MapLeft<TNewLeft>(Func<TLeft, TNewLeft> mapping) => 
            new Left<TNewLeft, TRight>(mapping(Value));

        public override Either<TLeft, TNewRight> MapRight<TNewRight>(Func<TRight, TNewRight> mapping) => 
            new Left<TLeft, TNewRight>(Value);

        public override TLeft Reduce(Func<TRight, TLeft> mapping) => 
            Value;
    }

    public sealed class Right<TLeft, TRight> : Either<TLeft, TRight>
    {
        private TRight Value { get; }

        public Right(TRight value)
        {
            Value = value;
        }

        public override Either<TNewLeft, TRight> MapLeft<TNewLeft>(Func<TLeft, TNewLeft> mapping) => 
            new Right<TNewLeft, TRight>(Value);

        public override Either<TLeft, TNewRight> MapRight<TNewRight>(Func<TRight, TNewRight> mapping) => 
            new Right<TLeft, TNewRight>(mapping(Value));

        public override TLeft Reduce(Func<TRight, TLeft> mapping) => 
            mapping(Value);
    }
}
