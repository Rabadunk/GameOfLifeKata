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
            var life = new Grid(3, 3);
            var cell = new Cell(1, 1);

            life.InsertCell(cell);
            
            Assert.NotEmpty(life.Cells);
        }
        
        [Fact]
        public void ShouldNotInsertCellToGridWhenCellAlreadyExists()
        {
            var grid = new Grid(3, 3);
            var cellOne = new Cell(1, 1);
            var cellTwo = new Cell(1, 1);
            
            grid.InsertCell(cellOne);
            grid.InsertCell(cellTwo);
            
            Assert.Equal(1, grid.Cells.Count);
        }

        [Fact]
        public void ShouldRemoveCellFromGridWhenCellIsInGrid()
        {
            var grid = new Grid(3, 3);
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
            var grid = new Grid(5, 5);
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
        public void ShouldHoldCorrectNeighborCountWhenCellsAreOverlappedToOtherSide()
        {         
            var grid = new Grid(3, 3);
            var cellOne = new Cell(0, 0);
            var cellTwo = new Cell(0, 1);
            var cellThree = new Cell(0, 2);
            var cellFour = new Cell(1, 0);
            var cellFive = new Cell(1, 2);
            var cellSix = new Cell(2, 0);
            var cellSeven = new Cell(2, 1);
            var cellEight = new Cell(2, 2);

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

    }
}