// 1

// 2
public class FourSideGeometricFigure
{
	public string Name { get; set; }
	public double Base { get; set; }
	public double Height { get; set; }

	public FourSideGeometricFigure(string name, double baseLength, double height)
	{
		Name = name;
		Base = baseLength;
		Height = height;
	}

	public double GetArea()
	{
		return Base * Height;
	}

	public override string ToString()
	{
		return $"Name: {Name}, Base: {Base}, Height: {Height}, Area: {GetArea()}";
	}
}
