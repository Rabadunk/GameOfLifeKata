using System;
using System.Linq;

namespace GameOfLife
{
    public class Renderer
    {
        public void Greeting()
        {
            Console.WriteLine("Hi, Welcome To Conway's Game Of Life.");
            Console.WriteLine("A cellular automaton devised by the British mathematician John Horton Conway in 1970.");
            Console.WriteLine();
        }

        public void Menu()
        {
            Console.WriteLine("Enter a number from the menu below: ");
            Console.WriteLine("[0] Play");
            Console.WriteLine("[1] Exit");
            AskForAnswer();
        }

        public void Grid(Grid grid)
        {
            Console.WriteLine("This is your grid: ");
            
            for (var i = 1; i <= grid.Height; i++) 
            {

                for (var j = 1; j <= grid.Width; j++)
                {
                    var cell = new Cell(i, j);

                    Console.Write(grid.Cells.Keys.ToList().Contains(cell) ? "^ " : ". ");
                }
                
                Console.WriteLine();
            }

        }

        public void NextTurn()
        {
            Console.WriteLine("Press 0 to continue or 1 to exit: ");
            AskForAnswer();
        }

        public void GridSetup()
        {
            Console.WriteLine("Please enter Grid dimensions in the format 'height width', eg. '3 3'.");
            AskForAnswer();
        }

        public void AskForStartingCells()
        {
            Console.WriteLine("Enter a cell you would like to be alive, eg. '2 2' or 'done' when you're done.");
            AskForAnswer();
        }

        public void AskForAnswer()
        {
            Console.Write("Your answer: ");
        }

        public void GoodBye()
        {
            Console.WriteLine("See you later alligator ;)");
        }

        public void ErrorWrongCoordinates()
        {
            Console.WriteLine("Sorry, that is an invalid input.");
            Console.WriteLine("This may be because you typed letters instead of numbers");
            Console.WriteLine("or you put more than two numbers.");
            Console.WriteLine("Please make sure your input is as follows: ");
            Console.WriteLine("'number number' eg. '1 1' or '50 20'");
            Console.WriteLine();
        }
    }
}