public class Triangle : IPolygon
{
	public Vector2 A { get; }
	public Vector2 B { get; }
	public Vector2 C { get; }

	public Triangle(Vector2 a, Vector2 b, Vector2 c)
	{
		A = a;
		B = b;
		C = c;
	}

	public IEnumerable<Vector2> GetPoints()
	{
		return new[] { A, B, C };
	}

	public override string ToString()
	{
		return $"Triangle: A: {A}, B: {B}, C: {C}";
	}
}
