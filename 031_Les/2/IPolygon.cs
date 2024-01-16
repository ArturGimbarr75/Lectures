interface IPolygon : IComparable<IPolygon>
{
	public IEnumerable<Vector2> GetPoints();

	public float GetArea()
	{
		IEnumerable<Vector2> pointsEnumerable = GetPoints();
		if (pointsEnumerable is not IList<Vector2> list)
			list = pointsEnumerable.ToList();

		// gauss area formula
		float area = 0;
		for (int i = 0; i < list.Count; i++)
		{
			Vector2 a = list[i];
			Vector2 b = list[(i + 1) % list.Count];
			area +=  Vector2.Cross(a, b);
		}

		return area / 2;
	}

	public float GetPerimeter()
	{
		IEnumerable<Vector2> pointsEnumerable = GetPoints();
		if (pointsEnumerable is not IList<Vector2> list)
			list = pointsEnumerable.ToList();

		float perimeter = 0;
		for (int i = 0; i < list.Count; i++)
		{
			Vector2 a = list[i];
			Vector2 b = list[(i + 1) % list.Count];
			perimeter += Vector2.Distance(a, b);
		}

		return perimeter;
	}

	int IComparable<IPolygon>.CompareTo(IPolygon? other)
	{
		return other == null ? 1 : GetArea().CompareTo(other.GetArea());
	}
}
