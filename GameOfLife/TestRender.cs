namespace GameOfLife
{
    public class TestRenderer : IRenderer
    {

        public string message;
        
        public void DisplayGreeting()
        {
            message =  "Hi, Welcome To Conways Game Of Life";
        }
    }
}