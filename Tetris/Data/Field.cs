using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Tetris.Data
{
    public class Field
    {
        public PictureBox[][] field { get; set; }

        public Field(int width, int height)
        {
            field = new PictureBox[height / 50][];
            for (int i = 0; i < field.GetLength(0); i++)
            {
                field[i] = new PictureBox[width/50];
            }
        }
        public PictureBox this [int x, int y]
        {
            get => field[x][y];
            set => field[x] [y] = value;
        }

        public void DeleteFillRows()
        {
            for (int i = 0; i < field.GetLength(0); i++)
            {
                if (field[i].All(x => x != null))
                {
                    foreach (var x in field[i])
                    {
                        x.Hide();
                    }
                }
            }
        }
    }
}