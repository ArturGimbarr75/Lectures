internal class Rectangle : ShapeBase
{
	public override string Name => nameof(Rectangle);

	public float A { get; private init; }
	public float B { get; private init; }

	public Rectangle(float a, float b)
	{
		A = a;
		B = b;

		Area = A * B;
		Perimeter = 2 * (A + B);
	}
}
