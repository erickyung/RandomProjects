using System;

namespace MaybeMonad
{
    public static class MaybeExtensions
    {
        public static Maybe<T> ToMaybe<T>(this T value)
        {
            return new Maybe<T>(value);
        }

        public static Maybe<V> SelectMany<T, V>(this Maybe<T> m, Func<T, Maybe<V>> k)
        {
            if (!m.HasValue)
            {
                return Maybe<V>.Nothing;
            }

            return k(m.Value);
        }

        public static Maybe<V> SelectMany<T, U, V>(this Maybe<T> m, Func<T, Maybe<U>> k, Func<T, U, V> s)
        {
            if (!m.HasValue)
            {
                return Maybe<V>.Nothing;
            }

            var mU = k(m.Value);

            /*
            if (!mU.HasValue)
            {
                return Maybe<V>.Nothing;
            }
            */

            if (mU.HasValue)
            {
                return s(m.Value, mU.Value).ToMaybe();
            }

            return s(m.Value, default(U)).ToMaybe();
        }
    }
}