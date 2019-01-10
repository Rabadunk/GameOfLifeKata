using System.Linq;
using GameOfLife;
using Xunit;

namespace GameOfLifeTests
{
    public class TribunalTest
    {
        [Fact]
        public void ShouldKillCellWhenUnderpopulated()
        {
            var life = new Life();
            var tribunal = new Tribunal();
            var cellOne = new Cell(0, 1);
            var cellTwo = new Cell(0, 2);
            var cellThree = new Cell(0, 3);

            life.InsertCell(cellOne);
            life.InsertCell(cellTwo);
            life.InsertCell(cellThree);

            tribunal.DecideUnderpopulation(life);
            
            Assert.Equal(2, tribunal.DeadCells.Count());
        }
    }
}