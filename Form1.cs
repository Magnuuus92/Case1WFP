using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Case1WFP
{
    public partial class Form1 : Form
    {
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

            private TetrisPiece CurrentPiece; //USIKKER HER <========
        }
        private void UpdateGame(object sender, EventArgs e)
        { 
            this.Invalidate(); 
        }

        private void DrawGame(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            for (int x = 0; x < GridWidth; x++) {
                for int y = 0; y < GridHeight; y++)
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
            }
            [STAThread]
            static void Main()
            {
                Application.Run(new TetrisGame());
            }
    }
}
