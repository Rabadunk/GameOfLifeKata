using System;
using System.Linq;

namespace GameOfLife
{
    public class Renderer
    {
        public void ShowGreeting()
        {
            Console.WriteLine();
            Console.WriteLine("Hi, Welcome To Conway's Game Of Life.");
            Console.WriteLine("A cellular automaton devised by the British mathematician John Horton Conway in 1970.");
        }

        public string ShowMenu(string optionOne, string optionTwo)
        {
            Console.WriteLine();
            Console.WriteLine("Enter a number from the menu below: ");
            Console.WriteLine($"[0] {optionOne}");
            Console.WriteLine($"[1] {optionTwo}");
            return AskForAnswer();
        }
        
        private string AskForAnswer()
        {
            Console.WriteLine();
            Console.Write("Your answer: ");
            return Console.ReadLine();
        }

        public void DrawWorld(World world)
        {
            Console.WriteLine();
            Console.WriteLine("This is your grid: ");          
            for (var i = 1; i <= world.Height; i++) 
            {
                for (var j = 1; j <= world.Width; j++)
                {
                    var cell = new Cell(i, j);

                    Console.Write(world.Cells.Keys.ToList().Contains(cell) ? "* " : ". ");
                }
                Console.WriteLine();
            }
        }

        public string ShowWorldSetup()
        {
            Console.WriteLine();
            Console.WriteLine("Please enter Grid dimensions in the format 'height width', eg. '3 3'.");
            return AskForAnswer();
        }

        public string AskForStartingCells()
        {
            Console.WriteLine();
            Console.WriteLine("Enter a cell you would like to be alive, eg. '2 2' or 'done' when you're done.");
            return AskForAnswer();
        }

        public void ShowGoodBye()
        {
            Console.WriteLine();
            Console.WriteLine("See you later alligator ;)");
        }

        public string ShowErrorWrongGridInput(string error)
        {
            Console.WriteLine();
            Console.WriteLine($"Sorry, that is an invalid {error}.");
            Console.WriteLine("This may be because you typed letters instead of numbers,");
            Console.WriteLine("put more than two numbers or it's out of range.");
            Console.WriteLine("Please make sure your input is as follows: ");
            Console.WriteLine("'number number' eg. '1 1' or '50 20'");
            return AskForAnswer();

        }

        public string WrongMenuOption(string optionOne, string optionTwo)
        {
            Console.WriteLine();
            Console.WriteLine("Sorry, that is an invalid menu option.");
            return ShowMenu(optionOne, optionTwo);
        }
    }
}