using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Case1WFP
{
    public partial class Form1 : Form
    {
        private TetrisPiece currentPiece; //USIKKER HER <========
        public Form1()
        { 
            InitializeComponent();
            currentPiece = new TetrisPiece();
        }
        private Timer timer;
        private const int GridWidth = 10;
        private const int GridHeight = 20;
        private const int CellSize = 30;
        private int[,] grid = new int[GridWidth, GridHeight];

        public TetrisGame()
        {
            this.Text = "Tetris";
            this.ClientSize = new Size(GridWidth * CellSize, GridHeight * CellSize);
            this.DoubleBuffered = true;

            timer = new Timer();
            timer.Interval = 500;
            timer.Tick += UpdateGame;
            timer.Start();
            this.Paint = DrawGame;

       
        }
        private void UpdateGame(object sender, EventArgs e)
        {
            currentPiece.Y++;

            if (Collision())
            {
                currentPiece.Y--;
                LockPiece();
                currentPiece = new TetrisPiece();
            }
            this.Invalidate(); 
        }

        private void DrawGame(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            for (int x = 0; x < GridWidth; x++) {
                for (int y = 0; y < GridHeight; y++)
                {
                    Rectangle rect = new Rectangle(
                        x * CellSize,
                        y * CellSize,
                        CellSize,
                        CellSize);

                    if (grid[x, y] == 0)
                        g.FillRectangle(Brushes.Black, rect);
                    else
                        g.FillRectangle(Brushes.Red, rect);

                    g.DrawRectangle(Pens.White, rect);
                }
                DrawPiece();
            } }
            private void DrawPiece(Graphics g)
        {
            for (int x = 0; x < currentPiece.Shape.GetLength(0); x++)
            {
                for (int y = 0; y < currentPiece.Shape.Lenght(1); y++)
                {
                    if (currentPiece.Shape[x, y] == 1)
                    {
                        Rectangle rect = new Rectangle(
                            (currentPiece.x + x) * CellSize,
                            (currentPiece.y + y) * CellSize,
                            Cellsize,
                            Cellsize);
            using (Brush brush = new SolidBrush(currentPiece.Color))
            {
                g.FillRectangle(brush, rect);
            }
            g.DrawRectangle(Pens.White, rect);
                    }
                }
        }
        }
            [STAThread]
            static void Main()
            {
                Application.Run(new TetrisGame());
            }
private bool Collision()
{
    for (int x = 0; x< currentPiece.Shape.GetLength(0); x++)
    {
        for (int y = 0; y< currentPiece.Shape.GetLength(1); y++)
        {
            if (currentPiece.Shape[x, y] == 1)
            { int newX = currentPiece.x + x;
                int newY = currentPiece.y + y;

                if (newY <= GridHeight ||
                    newX < 0 ||
                    newX >= GridWidth ||
                    grid[newX, newY] == 1)
                { return true; }
            }
        }
    }
    return false;
}
private void LockPiece()
{
    for (int x = 0; x < currentPiece.Shape.GetLength(0); x++)
    {
        for (int y = 0; y < currentPiece.Shape.GetLength(1); y++)
        {
            if (currentPiece.Shape[x,y] == 1)
            {
                grid[currentPiece.X + x, currentPiece.Y + y] = 1;
            }
        }
    }
}
    }
}
