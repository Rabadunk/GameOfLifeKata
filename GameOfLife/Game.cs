using System;
using System.Collections.Generic;

namespace GameOfLife
{
    public class Game
    {
        private readonly Renderer _render = new Renderer();
        private readonly InputValidator _validate = new InputValidator();
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

        private void CreateWorld()
        {
            _render.WorldSetup();
            var size = Console.ReadLine();
            var dimensions = _validate.Coordinate(size);
            _world = new World(dimensions[0], dimensions[1]);
            _render.World(_world);
            GetStartCellsForWorld();            
        }

        private void GetStartCellsForWorld()
        {
            while(true)
            {
                _render.AskForStartingCells();
                var input = Console.ReadLine();
                if (input == "done")
                {
                    break;
                }

                var coordinates = _validate.Coordinate(input);
                var newCell = new Cell(coordinates[0], coordinates[1]);
                _world.InsertCell(newCell);
                _render.World(_world);             
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
    }
}