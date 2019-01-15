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
            var life = new Grid(5, 5);
            var tribunal = new Tribunal();
            var cellOne = new Cell(0, 1);
            var cellTwo = new Cell(0, 2);
            var cellThree = new Cell(0, 3);

            life.InsertCell(cellOne);
            life.InsertCell(cellTwo);
            life.InsertCell(cellThree);

            tribunal.DecideDead(life);
            
            Assert.Equal(2, tribunal.DeadCells.Count);
        }
        
        [Fact]
        public void ShouldKillCellWhenOverpopulated()
        {
            var life = new Grid(5, 5);
            var tribunal = new Tribunal();
            var cellOne = new Cell(1, 1);
            var cellTwo = new Cell(1, 2);
            var cellThree = new Cell(1, 3);
            var cellFour = new Cell(0, 2);
            var cellFive = new Cell(2, 2);

            life.InsertCell(cellOne);
            life.InsertCell(cellTwo);
            life.InsertCell(cellThree);
            life.InsertCell(cellFour);
            life.InsertCell(cellFive);

            tribunal.DecideDead(life);
            
            Assert.Equal(1, tribunal.DeadCells.Count());
        }
        
        [Fact]
        public void ShouldPopulateCellsWhenGrowthIsPossible()
        {
            var life = new Grid(5, 5);
            var tribunal = new Tribunal();
            var cellOne = new Cell(0, 1);
            var cellTwo = new Cell(1, 1);
            var cellThree = new Cell(2, 1);
            var cellFour = new Cell(1, 0);
            var cellFive = new Cell(1, 2);

            life.InsertCell(cellOne);
            life.InsertCell(cellTwo);
            life.InsertCell(cellThree);
            life.InsertCell(cellFour);
            life.InsertCell(cellFive);

            tribunal.DecideDead(life);
            tribunal.UpdateUniverse(life, 4, 4);
            
            Assert.Equal(8, life.Cells.Count);      
        }
    }
}