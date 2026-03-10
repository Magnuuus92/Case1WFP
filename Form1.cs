using System;
using System.Drawing;
using System.Windows.Forms;


namespace Case1WFP
{
    public partial class Form1 : Form
    {
        private TetrisPiece currentPiece;


        private Timer timer;
        private const int GridWidth = 10;
        private const int GridHeight = 20;
        private const int CellSize = 30;
        private int[,] grid = new int[GridWidth, GridHeight];

        public Form1() // Form1 Constructor
        {

            InitializeComponent();
            currentPiece = new TetrisPiece();

            this.Text = "Tetris";
            this.ClientSize = new Size(GridWidth * CellSize, GridHeight * CellSize);
            this.DoubleBuffered = true;

            timer = new Timer();
            timer.Interval = 500;
            timer.Tick += UpdateGame;
            timer.Start();
            this.Paint += DrawGame;

            this.KeyDown += Form1_KeyDown;

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
            //Her lages rutenettet som er bakgrunnen i tetris. Tomme ruter blir fylt med svart og fulle ruter med rød. rutenettet er hvitt.
            Graphics g = e.Graphics;
            for (int x = 0; x < GridWidth; x++)
            {
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
            }
            DrawPiece(g);
        }
        private void DrawPiece(Graphics g)
        {
            for (int x = 0; x < currentPiece.Shape.GetLength(0); x++)
            {
                for (int y = 0; y < currentPiece.Shape.GetLength(1); y++)
                {
                    if (currentPiece.Shape[x, y] == 1)
                    {
                        Rectangle rect = new Rectangle(
                            (currentPiece.X + x) * CellSize,
                            (currentPiece.Y + y) * CellSize,
                            CellSize,
                            CellSize);
                        using (Brush brush = new SolidBrush(currentPiece.Color))
                        {
                            g.FillRectangle(brush, rect);
                        }
                        g.DrawRectangle(Pens.White, rect);
                    }
                }
            }
        }


        private bool Collision()
        {
            for (int x = 0; x < currentPiece.Shape.GetLength(0); x++)
            {
                for (int y = 0; y < currentPiece.Shape.GetLength(1); y++)
                {
                    if (currentPiece.Shape[x, y] == 1)
                    {
                        int newX = currentPiece.X + x;
                        int newY = currentPiece.Y + y;

                        if (newY >= GridHeight ||
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
                    if (currentPiece.Shape[x, y] == 1)
                    {
                        grid[currentPiece.X + x, currentPiece.Y + y] = 1;
                    }
                }
            }
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                currentPiece.X--;
                if (Collision())
                    currentPiece.X++;
            }
            if (e.KeyCode == Keys.Right)
            {
                currentPiece.X++;
                if (Collision())
                    currentPiece.X--;
            }
            if (e.KeyCode == Keys.Down)
            {
                currentPiece.Y++;
                if (Collision())
                    currentPiece.Y--;
            }
            if (e.KeyCode == Keys.Up)
            {
                currentPiece.Rotate();
                if (Collision())
                    currentPiece.RotateBack();
            }
        }
    }
}
