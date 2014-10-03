using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlayCards
{
    public class Program
    {
        Random rand = new Random((int)DateTime.Now.Ticks & 0x0000FFFF);

        public static void Main(string[] args)
        {
            Console.WriteLine("running...");

            var winnerCount = 0;

            var prog = new Program();

            for (var i = 0; i < 10000; i++)
            {
                var deckOfCard = prog.GetShuffledDeckOfCard();

                var board = new int?[10];
                var discardCount = 0;

                var deckIndex = 0;
                while (!prog.IsBoardFilled(board.ToList()) && discardCount < 6)
                {
                    if (deckOfCard[deckIndex] == 8 || deckOfCard[deckIndex] == 9)
                    {
                        if (board[7].HasValue && board[7].Value != deckOfCard[deckIndex])
                        {
                            discardCount++;
                        }
                        else
                        {
                            board[7] = deckOfCard[deckIndex];
                        }
                        
                        deckIndex++;
                        continue;
                    }
                    else if (deckOfCard[deckIndex] == 10 || deckOfCard[deckIndex] == 11)
                    {
                        if (board[8].HasValue && board[8].Value != deckOfCard[deckIndex])
                        {
                            discardCount++;
                        }
                        else
                        {
                            board[8] = deckOfCard[deckIndex];
                        }

                        deckIndex++;
                        continue;
                    }
                    else if (deckOfCard[deckIndex] == 12 || deckOfCard[deckIndex] == 13)
                    {
                        if (board[9].HasValue && board[9].Value != deckOfCard[deckIndex])
                        {
                            discardCount++;
                        }
                        else
                        {
                            board[9] = deckOfCard[deckIndex];
                        }

                        deckIndex++;
                        continue;
                    }

                    //Console.WriteLine("Held: {0} - Count: {1}", deckOfCard[deckIndex], discardCount);
                    board[deckOfCard[deckIndex] - 1] = deckOfCard[deckIndex];
                    deckIndex++;

                    //prog.PrintBoard(board);
                }

                if (prog.IsBoardFilled(board.ToList()))
                {
                    //Console.WriteLine("Winner");
                    winnerCount++;
                }
                else
                {
                    //Console.WriteLine("Loser");
                }
            }

            Console.WriteLine("Winner {0} times", winnerCount);

            Console.ReadKey();
        }

        private void PrintBoard(IEnumerable<int?> board)
        {
            foreach (var i in board)
            {
                Console.Write("{0}, ", i);
            }
            Console.WriteLine();
        }

        private bool IsBoardFilled(List<int?> board)
        {
            return board.All(slot => slot.HasValue);
        }

        private int[] GetShuffledDeckOfCard()
        {
            var listOfSameKindCards = new List<int> {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13};
            var deckOfCards = listOfSameKindCards.Concat(listOfSameKindCards).Concat(listOfSameKindCards).Concat(listOfSameKindCards).ToArray();

            for (var i = 0; i < deckOfCards.Length; i++)
            {
                var posToSwap = rand.Next(i, deckOfCards.Length);

                var temp = deckOfCards[posToSwap];
                deckOfCards[posToSwap] = deckOfCards[i];
                deckOfCards[i] = temp;
            }
            
            return deckOfCards.ToArray();
        }
    }
}