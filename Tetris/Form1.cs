
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Tetris.Data;


namespace Tetris
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            FormBorderStyle = FormBorderStyle.None;
            InitializeComponent();
            InitializeFigure();
            KeyDown += InputHandler;
            Height = 900;
            Width = 900;
            timer1.Tick += Update;
            timer1.Interval = 300; 
            timer1.Start();
            PictureBox pic1 = new PictureBox();
            pic1.BackColor = Color.Aqua;
            pic1.Location = new Point(0,0);
            pic1.Size = new Size(900,900);
            Controls.Add(pic1);
            Controls.SetChildIndex(pic1, -1);
        }

        public Figure CurrentFigure = new MyRectangle();
        public Field field = new Field(900, 900);
        public Direction dir { get; set; }
        private void Update(object sender, EventArgs e)
        {
            switch (dir)
            {
                case Direction.Down:
                {
                    CurrentFigure.MoveDown();
                    break;
                }
                case Direction.Left:
                {
                    CurrentFigure.MoveLeft();
                    break;
                }
                case Direction.Right:
                {
                    CurrentFigure.MoveRight();
                    break;
                }
            }
            Console.WriteLine(CurrentFigure.FigureBlocks[0].Y);
            CurrentFigure.MoveDown();
            var y = CurrentFigure.FigureBlocks.Any(x => x.Y >= 850);
            if (y || !canMove())
            {
                foreach (var x in CurrentFigure.FigureBlocks)
                {
                    field[x.X / 50, x.Y / 50] = 1;
                }
                CurrentFigure = RandomFigure();
                InitializeFigure();
            }
            dir = Direction.None;
        }

        public bool canMove()
        {
            foreach (var y in CurrentFigure.FigureBlocks)
            {
                if (field[y.X / 50, (y.Y+50) / 50] == 1) return false;
            }
            return true;
        }

        public Figure RandomFigure()
        {
            var rnd = new Random().Next(2);
            switch (rnd)
            {
                case 0: return new Square();
                case 1: return new MyRectangle();
            }

            return new Square();
        }

        private void InputHandler(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Down:
                {
                    dir = Direction.Down;
                    break;
                }
                case Keys.Right:
                {
                    dir = Direction.Right;
                    break;
                }
                case Keys.Left:
                {
                    dir = Direction.Left;
                    break;
                }
            }
        }

        public void InitializeFigure()
        {
            foreach (var x in CurrentFigure.FigureBlocks)
            {
                Controls.Add(x.Box);
                Controls.SetChildIndex(x.Box, 5);
            }
            for (int x = 0; x <= Height / 50; x++)
            {
                PictureBox pic = new PictureBox();
                pic.BackColor = Color.Gray;
                pic.Location = new Point(0, 50 * x);
                pic.Size = new Size(Width, 2);
                Controls.Add(pic);
                Controls.SetChildIndex(pic, 2);
                pic.BringToFront();
            }
            for (int y = 0; y <= Width / 50; y++)
            {
                PictureBox pic = new PictureBox();
                pic.BackColor = Color.Gray;
                pic.Location = new Point(y * 50, 0);
                pic.Size = new Size(2, Height);
                Controls.Add(pic);
                Controls.SetChildIndex(pic, 2);
                pic.BringToFront();
            }
        }

        
    }
}