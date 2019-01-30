using GameOfLife;
using Xunit;

namespace GameOfLifeTests
{
    public class InputValidatorTest
    {
        
        private readonly InputValidator _valid = new InputValidator();

        [Theory]
        [InlineData("1 1")]
        [InlineData("5 6")]
        [InlineData("10 10")]
        public void ShouldTakeValidCoordinatesAndReturnTrue(string input)

        {
            var world = new World(10, 10);
            var actual = _valid.ValidCoordinate(input, world);
            const bool expected = true;
            Assert.Equal(expected, actual);

        }
        
        [Theory]
        [InlineData("11 11")]
        [InlineData("IT'S YO BOI JONO BACK AGAIN WITH ANOTHER YOUTUBE VIDEO")]
        public void ShouldTakeInvalidCoordinatesAndReturnFalse(string input)

        {
            var world = new World(10, 10);
            var actual = _valid.ValidCoordinate(input, world);
            const bool expected = false;
            Assert.Equal(expected, actual);

        }


        [Theory]
        [InlineData("10 10")]
        [InlineData("20 30")]
        public void ShouldTakeValidGridSizeAndReturnTrue(string input)
        {
            var actual = _valid.ValidWorldSize(input);
            const bool expected = true;
            Assert.Equal(expected, actual);
        }
        
        [Theory]
        [InlineData("10 1O")]
        [InlineData("SMASH THAT LIKE BUTTON")]
        public void ShouldTakeInvalidGridSizeAndReturnFalse(string input)
        {
            var actual = _valid.ValidWorldSize(input);
            const bool expected = false;
            Assert.Equal(expected, actual);
        }

    }
}