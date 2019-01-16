using System;
using System.Collections.Generic;

namespace GameOfLife
{
    public class Game
    {
        private readonly Renderer _render = new Renderer();
        private readonly Tribunal _tribunal = new Tribunal();
        private string _option;
        private Grid _grid;

        public void Start()
        {
            _render.Greeting();
            PlayOrExit();
        }

        private void PlayOrExit()
        {
            _render.Menu();
            _option = Console.ReadLine();
            switch (_option)
            {
                case "0":
                    PlayGame();
                    break;
                case "1":
                    Exit();
                    break;
            }
        }

        private void CreateGameGrid()
        {
            _render.GridSetup();
            var size = Console.ReadLine();
            var dimensions = InputCoordinateValidator(size);
            _grid = new Grid(dimensions[0], dimensions[1]);
            _render.Grid(_grid);
            GetStartCellsForGrid();            
        }

        private void GetStartCellsForGrid()
        {
            while(true)
            {
                _render.AskForStartingCells();
                var input = Console.ReadLine();
                if (input == "done")
                {
                    break;
                }

                var coordinates = InputCoordinateValidator(input);
                var newCell = new Cell(coordinates[0], coordinates[1]);
                _grid.InsertCell(newCell);
                _render.Grid(_grid);             
            }
        }


        private List<int> InputCoordinateValidator(string input)
        {
            var positions = input.Split();
             
            int row; int col;
            
            while( positions.Length < 2 ||
                  !int.TryParse(positions[0], out row) ||
                  !int.TryParse(positions[1], out col))
            {
                _render.ErrorWrongCoordinates();
                _render.AskForAnswer();
                positions = Console.ReadLine().Split();
            }
            
            return new List<int> {row, col};
        }
        
        

        private void PlayGame()
        {
            CreateGameGrid();
            
            while (_option == "0")
            {
                NextMove();
            }
            
            PlayOrExit();
        }

        private void NextMove()
        {
            _tribunal.UpdateUniverse(_grid);
            _render.Grid(_grid);
            _render.NextTurn();
            _option = Console.ReadLine();            
        }

        private void Exit()
        {
            _render.GoodBye();
        }
    }
}