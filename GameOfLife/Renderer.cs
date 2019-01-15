using System;

namespace GameOfLife
{
    public class Renderer : IRenderer
    {
        public void DisplayGreeting()
        {
            Console.WriteLine("Hi, Welcome To Conway's Game Of Life.");
            Console.WriteLine("A cellular automaton devised by the British mathematician John Horton Conway in 1970.");
            Console.WriteLine();
        }

        public void DisplayMenu()
        {
            Console.WriteLine("Enter a number from the menu below: ");
            Console.WriteLine("[0] Play");
            Console.WriteLine("[1] Exit");
        }

        public void DisplayGrid(Grid grid)
        {
            for (var i = 0; i < grid.Height) 
            {
            }

        }
    }
}