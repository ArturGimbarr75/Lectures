internal class Square : Rectangle
{
	public override string Name => nameof(Square);

	public Square(float a) : base(a, a) { }
}
