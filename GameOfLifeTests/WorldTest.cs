using GameOfLife;
using Xunit;

namespace GameOfLifeTests
{
    public class GridTest
    {
        [Fact]
        public void ShouldNotBeEmptyWhenCellIsAdded()
        {
            var life = new World(3, 3);
            var cell = new Cell(1, 1);

            life.InsertCell(cell);
            
            Assert.NotEmpty(life.Cells);
        }
        
        [Fact]
        public void ShouldNotInsertCellToGridWhenCellAlreadyExists()
        {
            var grid = new World(3, 3);
            var cellOne = new Cell(1, 1);
            var cellTwo = new Cell(1, 1);
            
            grid.InsertCell(cellOne);
            grid.InsertCell(cellTwo);
            
            Assert.Equal(1, grid.Cells.Count);
        }

        [Fact]
        public void ShouldRemoveCellFromGridWhenCellIsInGrid()
        {
            var grid = new World(3, 3);
            var cellOne = new Cell(1, 1);
            var cellTwo = new Cell(1, 2);

            grid.InsertCell(cellOne);
            grid.InsertCell(cellTwo);
            grid.RemoveCell(cellOne);
            
            Assert.Equal(1, grid.Cells.Count);
        }
        
        [Fact]
        public void ShouldHoldCorrectNeighborCountWhenCellsAreInGrid()
        {
            var grid = new World(5, 5);
            var cellOne = new Cell(1, 1);
            var cellTwo = new Cell(1, 2);
            var cellThree = new Cell(3, 3);

            grid.InsertCell(cellOne);
            grid.InsertCell(cellTwo);
            grid.InsertCell(cellThree);
    
            Assert.Equal(1, grid.Cells[cellOne]);
            Assert.Equal(1, grid.Cells[cellTwo]);
            Assert.Equal(0, grid.Cells[cellThree]);
        }
        
        [Fact]
        public void ShouldCountSevenNeighboursWhenCellsAreInChestShape()
        {         
            var grid = new World(3, 3);
            var cellOne = new Cell(1, 1);
            var cellTwo = new Cell(1, 2);
            var cellThree = new Cell(1, 3);
            var cellFour = new Cell(2, 1);
            var cellFive = new Cell(2, 3);
            var cellSix = new Cell(3, 1);
            var cellSeven = new Cell(3, 2);
            var cellEight = new Cell(3, 3);

            grid.InsertCell(cellOne);
            grid.InsertCell(cellTwo);
            grid.InsertCell(cellThree);
            grid.InsertCell(cellFour);
            grid.InsertCell(cellFive);
            grid.InsertCell(cellSix);
            grid.InsertCell(cellSeven);
            grid.InsertCell(cellEight);
    
            Assert.Equal(7, grid.Cells[cellOne]);
            Assert.Equal(7, grid.Cells[cellTwo]);
            Assert.Equal(7, grid.Cells[cellThree]);
        }
        
        [Fact]
        public void ShouldCreateSquarePatternWhenCrossPatternIsInputted()
        {
            var life = new World(5, 5);
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

            life.UpdateWorld();
            
            Assert.Equal(8, life.Cells.Count);      
        }

    }
}