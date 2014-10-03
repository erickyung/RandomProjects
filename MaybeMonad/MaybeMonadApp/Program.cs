using System;
using System.Linq;
using MaybeMonad;

namespace MaybeMonadApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            /*
            var r = from x in 5.ToMaybe()
                    from y in Maybe<int>.Nothing
                    select x + y;

            var r1 = from x in Maybe<int>.Nothing
                     from y in 5.ToMaybe()
                     select x + y;

            var r2 = from x in 6.ToMaybe()
                     from y in 5.ToMaybe()
                     select x + y;

            var r3 = from x in 6.ToMaybe()
                     from y in 5.ToMaybe()
                     from z in 11.ToMaybe()
                     from t in Maybe<int>.Nothing
                     select x + y + z + t;

            Console.WriteLine(r.HasValue ? r.Value.ToString() : "Nothing");

            Console.WriteLine(r1.HasValue ? r1.Value.ToString() : "Nothing");

            Console.WriteLine(r2.HasValue ? r2.Value.ToString() : "Nothing");

            Console.WriteLine(r3.HasValue ? r3.Value.ToString() : "Nothing");


            var s = from x in "hello".ToMaybe()
                    from y in Maybe<string>.Nothing
                    select x + y;

            var s1 = from x in Maybe<string>.Nothing
                     from y in "hello".ToMaybe()
                     select x + y;

            var s2 = from x in "hello".ToMaybe()
                     from y in "helloAgain".ToMaybe()
                     select x + y;

            Console.WriteLine(s.HasValue ? s.Value : "Nothing");

            Console.WriteLine(s1.HasValue ? s1.Value : "Nothing");

            Console.WriteLine(s2.HasValue ? s2.Value : "Nothing");
            */

            
            Console.ReadKey();
        }
    }
}