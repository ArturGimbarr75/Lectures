public class Square : IPolygon
{
	public Vector2 Center { get; }
	public float Size { get; }
	public float Rotation { get; }

	public Vector2 A { get; private set; }
	public Vector2 B { get; private set; }
	public Vector2 C { get; private set; }
	public Vector2 D { get; private set; }

    public Square() : this(Vector2.Zero, 1, 0) { }

	public Square(Vector2 center, float size, float rotation)
	{
		Center = center;
		Size = size;
		Rotation = rotation;
		UpdatePoints();
	}

	private void UpdatePoints()
	{
		A = Center + new Vector2(-Size / 2, -Size / 2).Rotate(Rotation);
		B = Center + new Vector2(Size / 2, -Size / 2).Rotate(Rotation);
		C = Center + new Vector2(Size / 2, Size / 2).Rotate(Rotation);
		D = Center + new Vector2(-Size / 2, Size / 2).Rotate(Rotation);
	}

	public IEnumerable<Vector2> GetPoints()
	{
		return new[] { A, B, C, D };
	}

	public override string ToString()
	{
		return $"Square: A: {A}, B: {B}, C: {C}, D: {D}";
	}
}