internal class Rhombus : Rectangle
{
	public override string Name => nameof(Rhombus);
	public float Angle { get; private init; }

	public Rhombus(float a, float angle) : base(a, a)
	{
		Angle = angle;
		Perimeter = 4 * A;
	}
}
