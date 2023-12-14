class Circle
{
	public double Radius { get; private set; }

	public Circle(double radius)
	{
		Radius = radius;
	}

	public double GetArea() => Math.PI * Radius * Radius;
	public double GetPerimeter() => 2 * Math.PI * Radius;
}