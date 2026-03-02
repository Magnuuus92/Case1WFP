using System.Drawing;

public class TetrisPiece
{
	public int[,] Shape	 {  get; set; }
	public int x { get; set; }
	public int y { get; set; }
	public Color Color { get; private set;  }

	public Class1()
	{
		Shape = new int[,] {
			{1,1 }, {1,1}
		};
		x = 4;
		y = 0;
		Color = Color.Yellow;
	}
}
