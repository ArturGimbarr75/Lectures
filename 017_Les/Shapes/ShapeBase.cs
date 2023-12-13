internal abstract class ShapeBase
{
	public virtual string Name => "Base shape";

	public float Area { get; protected init; }
	public float Perimeter { get; protected init; }
}
