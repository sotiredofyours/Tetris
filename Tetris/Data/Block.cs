using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Tetris.Data
{
    public class Block
    {
        public const int BLOCKWIDTH = 50;
        public const int BLOCKHEIGHT = 50;
        public PictureBox Box { get; }
        public bool isBusy { get; set; }
        public int X
        {
            get => Box.Location.X;
            set => Box.Location = new Point(value, Box.Location.Y);
        }
        
        public int Y
        {
            get => Box.Location.Y;
            set
            {
                Box.Location = new Point(Box.Location.X, value);
            }
        }

        public Block(int x, int y, Color color)
        {
            Box = new PictureBox();
            Box.Location = new Point(x * BLOCKWIDTH, y * BLOCKHEIGHT);
            Box.Size = new Size(BLOCKWIDTH, BLOCKHEIGHT);
            Box.BackColor = color;
            Box.Visible = true;
        }
        
        
    
    }
}