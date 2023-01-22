using System.Collections.Generic;
using System.Drawing;

namespace Tetris.Data
{
    public class MyRectangle : Figure
    {
        public MyRectangle()
        {
            FigureBlocks = new List<Block>
            {
                new Block(0, 0, Color.Brown),
                new Block(0, 1, Color.Brown),
                new Block(1,1, Color.Brown),
                new Block(1,0, Color.Brown),
                new Block(2, 0, Color.Brown),
                new Block(2, 1, Color.Brown)
            };
        }
    }
}