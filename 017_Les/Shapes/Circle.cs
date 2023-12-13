internal class Circle : ShapeBase
{
	public override string Name => nameof(Circle);
	public float R { get; private init; }
	public float D => 2 * R;

	public Circle(float r)
	{
		R = r;
		Area = MathF.PI * R * R;
		Perimeter = 2 * MathF.PI * R;
	}
}
