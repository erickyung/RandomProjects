using System;
using System.Linq;

namespace WordPosition
{
    public class WordPosition
    {
        static void Main(string[] args)
        {
            if (args.Length != 1 || args[0].ToUpper().Any(c => c < 'A' || c > 'Z') || args[0].Length > 20 || args[0].Length < 2)
            {
                Console.WriteLine("Expected a string of capital letters with length between 2 and 20.");
                return;
            }

            var word = args[0].ToUpper();

            var wp = new WordPosition();

            var startTime = DateTime.Now;
            var number = wp.FindWordPosition(word);
            var endTime = DateTime.Now;

            Console.WriteLine("Number of {0}: {1}", word, number);
            Console.WriteLine("Elapsed time: {0} ms", endTime.Subtract(startTime).TotalMilliseconds);
        }

        public long FindWordPosition(string word)
        {
            var wordLength = word.Length;
            var sortedLetters = word.OrderBy(l => l);
            var sortedLetterOccurrences = sortedLetters.GroupBy(l => l).Select(g => new {Letter = g.Key, Occurrence = g.Count()});

            if (wordLength <= 2)
            {
                return word.Equals(string.Concat(sortedLetters)) ? 1 : 2;
            }

            var number = 0L;
            var positionsInSortedLettersBeforeFirstLetterOfWord = sortedLetterOccurrences.Where(l => l.Letter < word.First()).Sum(l => l.Occurrence);
            if (positionsInSortedLettersBeforeFirstLetterOfWord > 0)
            {
                var duplicateLetters = sortedLetterOccurrences.Where(l => l.Occurrence > 1).Aggregate(1L, (seed, l) => seed * Factorial(l.Occurrence));
                number = positionsInSortedLettersBeforeFirstLetterOfWord * Factorial(wordLength - 1) / duplicateLetters;
            }

            return number + FindWordPosition(word.Substring(1));
        }

        public long Factorial(long number)
        {
            if (number < 0)
            {
                throw new ArgumentException("number must be greater or equal to 0.");
            }

            if (number == 0 || number == 1)
            {
                return 1;
            }

            return number*Factorial(number - 1);
        }
    }
}