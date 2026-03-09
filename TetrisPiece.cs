using System.Drawing;

namespace Case1WFP
{
	public class TetrisPiece
	{
		public int[,] Shape { get; set; }
		public int X { get; set; }
		public int Y { get; set; }
		public Color Color { get; private set; }

		public TetrisPiece()
		{
			Shape = new int[,] {
			{1,1 }, {1,1}
		};
			X = 4;
			Y = 0;
			Color = Color.Yellow;
		}
	}
}