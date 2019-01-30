namespace GameOfLife
{
    public class Game
    {
        private readonly Renderer _renderer = new Renderer();
        private readonly InputValidator _validator = new InputValidator();
        private bool _continueGame;
        private World _world;

        public void Start()
        {
            _renderer.ShowGreeting();
            PlayOrExit();
        }

        private void PlayOrExit()
        {
            _continueGame = GetValidMenuOption("Play", "Exit");
            if(_continueGame) PlayGame();
            else
            {
                Exit();
            }
        }

        private bool GetValidMenuOption(string optionOne, string optionTwo)
        {
            var input = _renderer.ShowMenu(optionOne, optionTwo);
            while (!_validator.ValidMenuOption(input))
            {
                input = _renderer.WrongMenuOption(optionOne, optionTwo);
            }

            return input == "0";
        }

        private void PlayGame()
        {
            CreateWorld();
            while (_continueGame)
            {
                NextMove();
            }      
            PlayOrExit();
        }

        private void CreateWorld()
        {
            var dimensions = GetValidGridSize().Split();
            _world = new World(ParseStringToInt(dimensions[0]), ParseStringToInt(dimensions[1]));
            _renderer.DrawWorld(_world);
            GetStartCellsForWorld();            
        }
        
        private string GetValidGridSize()
        {
            var input =  _renderer.ShowWorldSetup();
            while (!_validator.ValidWorldSize(input))
            {
                input = _renderer.ShowErrorWrongGridInput("size");
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
                _renderer.DrawWorld(_world);
                input = GetValidCoordinates();
            }
        }
        
        private string GetValidCoordinates()
        {
            var input = _renderer.AskForStartingCells();
            while (!_validator.ValidCoordinate(input, _world) && input != "done")
            {    
                input = _renderer.ShowErrorWrongGridInput("coordinate");
            }
            return input;
        }

        private void NextMove()
        {
            _world.UpdateWorld();
            _renderer.DrawWorld(_world);
            _continueGame = GetValidMenuOption("Next iteration", "Main menu");           
        }

        private void Exit()
        {
            _renderer.ShowGoodBye();
        }

        private static int ParseStringToInt(string input)
        {
            return int.Parse(input);         
        }
        
    }
}