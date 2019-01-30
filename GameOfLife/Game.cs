using System;

namespace GameOfLife
{
    public class Game
    {
        private readonly Renderer _render = new Renderer();
        private readonly InputValidator _valid = new InputValidator();
        private string _option;
        private World _world;

        public void Start()
        {
            _render.Greeting();
            PlayOrExit();
        }

        private void PlayOrExit()
        {
            _render.Menu();
            _option = Console.ReadLine();
            if(_option == "0") PlayGame();
            else
            {
                Exit();
            }
        }
        
        private void PlayGame()
        {
            CreateWorld();
            while (_option == "0")
            {
                NextMove();
            }      
            PlayOrExit();
        }

        private void CreateWorld()
        {
            _render.WorldSetup();
            var dimensions = GetValidGridSize().Split();
            _world = new World(ParseStringToInt(dimensions[0]), ParseStringToInt(dimensions[1]));
            _render.World(_world);
            GetStartCellsForWorld();            
        }
        
        private string GetValidGridSize()
        {
            var input = Console.ReadLine();
            while (!_valid.ValidWorldSize(input))
            {
                _render.ErrorWrongGridInput("size");
                _render.AskForAnswer();
                input = Console.ReadLine();
            }
            return input;
        }

        private void GetStartCellsForWorld()
        {
            var input = GetValidCoordinates();
            while(input != "done")
            {
                var coordinates = input.Split();
                var newCell = new Cell(ParseStringToInt(coordinates[0]), ParseStringToInt(coordinates[1]));
                _world.InsertCell(newCell);
                _render.World(_world);
                input = GetValidCoordinates();
            }
        }
        
        private string GetValidCoordinates()
        {
            _render.AskForStartingCells();
            var input = Console.ReadLine();
            while (!_valid.ValidCoordinate(input, _world) && input != "done")
            {
                _render.ErrorWrongGridInput("coordinate");
                _render.AskForAnswer();
                input = Console.ReadLine();
            }
            return input;
        }

        private void NextMove()
        {
            _world.UpdateWorld();
            _render.World(_world);
            _render.NextTurn();
            _option = Console.ReadLine();            
        }

        private void Exit()
        {
            _render.GoodBye();
        }

        private static int ParseStringToInt(string input)
        {
            return int.Parse(input);         
        }
        
    }
}