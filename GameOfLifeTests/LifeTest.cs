using System;
using System.Linq;
using GameOfLife;
using Xunit;

namespace GameOfLifeTests
{
    public class GridTest
    {
        [Fact]
        public void ShouldNotBeEmptyWhenCellIsAdded()
        {
            var life = new Life();
            var cell = new Cell(1, 1);

            life.InsertCell(cell);
            
            Assert.NotEmpty(life.Cells);
        }
        
        [Fact]
        public void ShouldNotInsertCellToGridWhenCellAlreadyExists()
        {
            var grid = new Life();
            var cellOne = new Cell(1, 1);
            var cellTwo = new Cell(1, 1);
            
            grid.InsertCell(cellOne);
            grid.InsertCell(cellTwo);
            
            Assert.Equal(1, grid.Cells.Count);
        }

        [Fact]
        public void ShouldRemoveCellFromGridWhenCellIsInGrid()
        {
            var grid = new Life();
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
            var grid = new Life();
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
        
        
    }
}