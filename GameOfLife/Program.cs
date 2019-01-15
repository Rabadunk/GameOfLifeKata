using System;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            var render = new Renderer();
            render.DisplayGreeting();
            render.DisplayMenu();
        }
    }
}