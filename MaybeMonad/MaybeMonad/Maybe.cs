﻿namespace MaybeMonad
{
    public class Maybe<T>
    {
        public readonly static Maybe<T> Nothing = new Maybe<T>();
        
        public T Value { get; private set; }
        public bool HasValue { get; private set; }

        private Maybe()
        {
            HasValue = false;
        }
        
        public Maybe(T value)
        {
            Value = value;
            HasValue = true;
        }
    }
}