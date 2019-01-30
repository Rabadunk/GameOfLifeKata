namespace GameOfLife
{
    public class InputValidator
    {   
        public bool ValidCoordinate(string input, World world)
        {
            var positions = input.Split();
            return positions.Length == 2 &&
                   int.TryParse(positions[0], out var row) &&
                   int.TryParse(positions[1], out var col) &&
                   world.Width >= col && world.Height >= row;
        }

        public bool ValidWorldSize(string input)
        {
            var dimensions = input.Split();   
            return dimensions.Length == 2 &&
                   int.TryParse(dimensions[0], out var row) &&
                   int.TryParse(dimensions[1], out var col);
        }

        public bool ValidMenuOption(string input)
        {
            return input == "0" || input == "1";
        }
    }
}