using GameOfLife;
using Xunit;

namespace GameOfLifeTests
{
    public class Renderer
    {
        [Fact]
        public void ShouldDisplayGreetingWhenGreetingFunctionIsCalled()
        {

            var render = new TestRenderer();
            render.DisplayGreeting();
            Assert.Equal("Hi, Welcome To Conways Game Of Life", render.message);

        }
        
        
        []
        
        
        
        
        
    }
}