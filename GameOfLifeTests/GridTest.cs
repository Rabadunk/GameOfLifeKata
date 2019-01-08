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
            var grid = new Grid();
            var cell = new Cell(1, 1);

            grid.InsertCell(cell);
            
            Assert.NotEmpty(grid.LivingCells);
        }
        
        [Fact]
        public void ShouldNotInsertCellToGridWhenCellAlreadyExists()
        {
            var grid = new Grid();
            var cellOne = new Cell(1, 1);
            var cellTwo = new Cell(1, 1);
            
            grid.InsertCell(cellOne);
            grid.InsertCell(cellTwo);
            
            Assert.Equal(1, grid.LivingCells.Count());
        }

        [Fact]
        public void ShouldRemoveCellFromGridWhenCellIsInGrid()
        {
            var grid = new Grid();
            var cellOne = new Cell(1, 1);
            var cellTwo = new Cell(1, 2);

            grid.InsertCell(cellOne);
            grid.InsertCell(cellTwo);
            grid.RemoveCell(cellOne);
            
            Assert.Equal(1, grid.LivingCells.Count());
        }
    }
}