using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14.Labyrinth
{
    class Program
    {
        static void Main(string[] args)
        {
            Labyrinth myLabyrinth = new Labyrinth();
            Cell startingPoint = myLabyrinth.GetStartingPoint();

            myLabyrinth.BFS(startingPoint);
            myLabyrinth.MapUnreachableCells();

            Console.WriteLine(myLabyrinth.ToString());
        }
    }
}
