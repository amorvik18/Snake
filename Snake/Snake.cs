using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Snake : ISnake
    {
        public int Lenght { get; set; } = 5; // dlugosc poczatkowa

        public Direction Direction { get; set; } = Direction.Right; // w ktora strone zaczyna

        public Coordinate HeadPosition { get; set; } = new Coordinate(); // gdzie ma byc glowa

        List<Coordinate> Tail { get; set; } = new List<Coordinate>();

        private bool outOfRange = false; // gdy wyjdzie poza zasieg

        public bool GameOver
        {
            // koniec gry nastapi gdy glowa (x i y) wejdziemy w ktoras czesc ogona
            get {
                return (Tail.Where(c => c.X == HeadPosition.X
                     && c.Y == HeadPosition.Y).ToList().Count > 1) || outOfRange;
            } 
        }
        public void EatMeal()
        {
            Lenght++;
        }

        public void Move()
        {
            switch(Direction)
            {
                case Direction.Left:
                    HeadPosition.X--;
                    break;
                case Direction.Right:
                    HeadPosition.X++;
                    break;
                case Direction.Up:
                    HeadPosition.Y--;
                    break;
                case Direction.Down:
                    HeadPosition.Y++;
                    break;
            }
            try
            {
                Console.SetCursorPosition(HeadPosition.X, HeadPosition.Y);
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("@");
                Tail.Add(new Coordinate(HeadPosition.X, HeadPosition.Y));
                if(Tail.Count > this.Lenght)
                {
                    var endTail = Tail.First();
                    Console.SetCursorPosition(endTail.X, endTail.Y);
                    Console.Write(" ");
                    Tail.Remove(endTail);
                }
            }
            catch(ArgumentOutOfRangeException)
            {
                outOfRange = true;
            }
        }
    }

    public enum Direction { Left, Right, Up, Down}
}
