using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Meal
    {
        public Meal()
        {
            Random rand = new Random();
            var x = rand.Next(1, 20);
            var y = rand.Next(1, 20);
            CurrentTarget = new Coordinate(x, y);
            Draw();
        }

        public Coordinate CurrentTarget { get; set; }

        void Draw()
        {
            Console.SetCursorPosition(CurrentTarget.X, CurrentTarget.Y); // dodawanie pozycji kursora
            Console.ForegroundColor = ConsoleColor.Green; // dodawanie koloru
            Console.Write("$");
        }
    }
}
