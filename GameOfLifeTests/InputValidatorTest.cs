using System.Collections.Generic;
using GameOfLife;
using Xunit;

namespace GameOfLifeTests
{
    public class InputValidatorTest
    {
        
        private InputValidator _validate = new InputValidator();

        [Theory]
        [InlineData("1 1",  1, 1)]
        public void ShouldTakeInputCoordinatesAndReturnValidCoordinatesInList(string input, int x, int y)

        {
            var actual = _validate.Coordinate(input);
            var expected = new List<int> {x, y};
            Assert.Equal(expected, actual);

        }
        
        [Theory]
        [InlineData("1 1",  1, 1)]
        public void ShouldTakeInputGridSizeAndReturnValidGridSize(string input, int x, int y)

        {
            var actual = _validate.InputGridSize(input);
            var expected = new List<int> {x, y};
            Assert.Equal(expected, actual);

        }


    }
}