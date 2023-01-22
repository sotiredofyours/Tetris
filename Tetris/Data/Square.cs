using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Tetris.Data
{
    public class Square : Figure
    {
        public Square()
        {
            FigureBlocks = new List<Block>
            {
                new Block(0, 0, Color.Peru),
                new Block(0, 1, Color.Peru),
                new Block(1,1, Color.Peru),
                new Block(1,0, Color.Peru)
            };
        }
    }
}