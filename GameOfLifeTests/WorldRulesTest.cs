using GameOfLife;
using Xunit;

namespace GameOfLifeTests
{
    public class WorldRulesTest
    {
        
        [Fact]
        public void ShouldDecideToKillTwoCellsWhenWorldHasHorizontalPattern()
        {
            var life = new World(5, 5);
            var cellOne = new Cell(1, 1);
            var cellTwo = new Cell(1, 2);
            var cellThree = new Cell(1, 3);
            
            life.InsertCell(cellOne);
            life.InsertCell(cellTwo);
            life.InsertCell(cellThree);
            
            var rules = new WorldRules();        
            rules.DecideDead(life);
            
            Assert.Equal(2, rules._cellsToBeDestroyed.Count); 
        }
        
        [Fact]
        public void ShouldDecideToCreateTwoCellsWhenWorldHasHorizontalPattern()
        {
            var life = new World(5, 5);
            var cellOne = new Cell(1, 1);
            var cellTwo = new Cell(1, 2);
            var cellThree = new Cell(1, 3);
            
            life.InsertCell(cellOne);
            life.InsertCell(cellTwo);
            life.InsertCell(cellThree);
            
            var rules = new WorldRules();        
            rules.DecideNewLife(life);
            
            Assert.Equal(2, rules._cellsToBeCreated.Count); 
        }
        
        [Fact]
        public void ShouldDeleteTwoCellsWhenWorldHasHorizontalPattern()
        {
            var life = new World(5, 5);
            var cellOne = new Cell(1, 1);
            var cellTwo = new Cell(1, 2);
            var cellThree = new Cell(1, 3);
            
            life.InsertCell(cellOne);
            life.InsertCell(cellTwo);
            life.InsertCell(cellThree);
            
            var rules = new WorldRules();        
            rules.DecideDead(life);
            rules.Eradicate(life);
            
            Assert.Single(life.Cells); 
        }
        
        [Fact]
        public void ShouldPopulateTwoCellsWhenWorldHasHorizontalPattern()
        {
            var life = new World(5, 5);
            var cellOne = new Cell(1, 1);
            var cellTwo = new Cell(1, 2);
            var cellThree = new Cell(1, 3);
            
            life.InsertCell(cellOne);
            life.InsertCell(cellTwo);
            life.InsertCell(cellThree);
            
            var rules = new WorldRules();        
            rules.DecideNewLife(life);
            rules.Populate(life);
            
            Assert.Equal(5, life.Cells.Count); 
        }
    }
}