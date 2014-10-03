using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScoreProbability
{
    public class Program
    {
        private double[] sp = new[] {0.5, 0.3, 0.2};

        public static void Main(string[] args)
        {
            var prog = new Program();

            List<Tuple<int, int, double>> matrix = new List<Tuple<int, int, double>>();

            for (var i = 0; i <= 10; i++)
            {
                for (var j = 0; j <= 10; j++)
                {
                    var t1 = prog.GetScoreProbability(j, 5);
                    var t2 = prog.GetScoreProbability(i, 5);

                    var prob = t1*t2;

                    matrix.Add(new Tuple<int, int, double>(j, i, prob));
                }
            }

            var ordered = matrix.OrderByDescending(m => m.Item3).Take(10);

            foreach (var tuple in ordered)
            {
                
            }

            Console.ReadKey();
        }

        public double GetScoreProbability(int score, int round)
        {
            if (score < 0 || score > round * 2)
            {
                return 0;
            }

            if (round == 1)
            {
                return sp[score];
            }

            return
                GetScoreProbability(score, round - 1)*sp[0] +
                GetScoreProbability(score - 1, round - 1)*sp[1] +
                GetScoreProbability(score - 2, round - 1)*sp[2];
        }
    }
}