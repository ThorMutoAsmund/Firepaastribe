using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Firepaastribe
{
    public class Game
    {
        public Board board = new Board();

        public void Run()
        {
            int winner = Color.None;

            int color = Color.First;

            int choice = -1;
            string choiceString;
            do
            {
                Visualizer.Show(board);
                do
                {
                    Console.Write("Your move (q to quit): ");
                    choiceString = Console.ReadLine();
                    if (choiceString == "q" || (Int32.TryParse(choiceString, out choice) && choice >= 0 && choice < Size.W))
                    {
                        break;
                    }
                    Console.WriteLine("Illegal move!");
                }
                while (true);

                if (choiceString == "q")
                {
                    break;
                }

                board.Push(choice, color);
                if (Evaluator.IsFinished(board, color))
                {
                    winner = color;
                    break;
                }
                color = Color.Next(color);
                choice = turn(color, 1);
                board.Push(choice, color);
                if (Evaluator.IsFinished(board, color))
                {
                    winner = color;
                    break;
                }
                color = Color.Next(color);
            }
            while (true);
            Visualizer.Show(board);
            Console.WriteLine($"Winner is {(winner == Color.None ? "none" : (winner == Color.Red ? "Red" : "Blue"))}");
        }

        public int turn(int color, int depth)
        {
            var bestScore = -10000;
            var bestMoves = new List<int>();
            board.GetMoves().Each(m =>
            {
                board.Push(m, color);
                var score = sub(Color.Next(color), depth - 1);

                Console.Write($"({m} {score}) ");
                if (score == bestScore)
                {
                    bestMoves.Add(m);
                }
                else if (score > bestScore)
                {
                    bestScore = score;
                    bestMoves.Clear();
                    bestMoves.Add(m);
                }
                board.Pop(m);
            });
            Console.WriteLine();
            //Console.WriteLine($"Best moves: [{String.Join(",",bestMoves)}] ({bestScore})");

            return bestMoves.Count() == 1 ?
                bestMoves.First() :
                bestMoves[Randomizer.Next(bestMoves.Count())];
        }

        public int sub(int color, int depth)
        {
            var bestScore = -10000;
            board.GetMoves().Each(m =>
            {
                board.Push(m, color);
                if (depth > 0)
                {
                    turn(Color.Next(color), depth - 1);
                }
                else
                {
                    var score = Evaluator.Evaluate(this.board, color);
                    if (score > bestScore)
                    {
                        bestScore = score;
                    }
                }
                board.Pop(m);
            });
            return -bestScore;
        }
    }
}
 