using System.Collections.Generic;

namespace Tetris.Data
{
    public class Field
    {
        public int[,] field { get; set; }

        public Field(int width, int height)
        {
            field = new int[width / 50, height / 50];
        }
        public int this [int x, int y]
        {
            get => field[x, y];
            set => field[x, y] = value;
        } 
    }
}