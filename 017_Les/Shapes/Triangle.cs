internal class Triangle : ShapeBase
{
	public override string Name => nameof(Triangle);

	public float A { get; private init; }
	public float B { get; private init; }
	public float C { get; private init; }

	public Triangle(float a, float b, float c)
	{
		A = a;
		B = b;
		C = c;

		Perimeter = A + B + C;
		float p = Perimeter / 2;
		Area = MathF.Sqrt(p * (p - A) * (p - B) * (p - C));
	}
}
