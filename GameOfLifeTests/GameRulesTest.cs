using System.Linq;
using GameOfLife;
using Xunit;

namespace GameOfLifeTests
{
    public class GameRulesTest
    {   
        [Fact]
        public void ShouldPopulateCellsWhenGrowthIsPossible()
        {
            var life = new World(5, 5);
            var tribunal = new WorldRules();
            var cellOne = new Cell(1, 2);
            var cellTwo = new Cell(2, 2);
            var cellThree = new Cell(3, 2);
            var cellFour = new Cell(2, 1);
            var cellFive = new Cell(2, 3);

            life.InsertCell(cellOne);
            life.InsertCell(cellTwo);
            life.InsertCell(cellThree);
            life.InsertCell(cellFour);
            life.InsertCell(cellFive);

            
            Assert.Equal(8, life.Cells.Count);      
        }
    }
}