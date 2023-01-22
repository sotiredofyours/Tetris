using System.Collections.Generic;
using System.Linq;

namespace Tetris.Data
{
    public abstract class Figure
    {
        public List<Block> FigureBlocks { get; set; }
        public void MoveDown()
        {
            foreach (var block in FigureBlocks)
            {
                block.Y += 50;
            }
        }

        public void MoveLeft()
        {
            if (FigureBlocks.Where(x => x.X - 50 <0).ToList().Count > 1) return;
            foreach (var block in FigureBlocks)
            {
                block.X -= 50;
            }
        }

        public void MoveRight()
        {
            if (FigureBlocks.Where(x => x.X + 50 > 900).ToList().Count > 1) return;
            foreach (var block in FigureBlocks)
            {
                 block.X += 50;
            }
        }
        
    }
}