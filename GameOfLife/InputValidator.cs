using System;
using System.Collections.Generic;

namespace GameOfLife
{
    public class InputValidator
    {
        private readonly Renderer _render = new Renderer();
        
        public List<int> Coordinate(string input)
        {
            var positions = input.Split();   
            int row; int col;
            while(positions.Length < 2 ||
                  !int.TryParse(positions[0], out row) ||
                  !int.TryParse(positions[1], out col))
            {
                _render.ErrorWrongCoordinates();
                _render.AskForAnswer();
                positions = Console.ReadLine().Split();
            }     
            return new List<int> {row, col};
        }


        public List<int> InputGridSize(string input)
        {
            throw new NotImplementedException();
        }
        
    }
}