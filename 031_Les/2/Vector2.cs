public struct Vector2
{
	public static Vector2 Zero => new(0, 0);
	public static Vector2 One => new(1, 1);
	public static Vector2 Up => new(0, 1);
	public static Vector2 Down => new(0, -1);
	public static Vector2 Left => new(-1, 0);
	public static Vector2 Right => new(1, 0);

	public float X { get; set; }
	public float Y { get; set; }

	public float Length
		=> MathF.Sqrt(X * X + Y * Y);

	public float LengthSquared
		=> X * X + Y * Y;

	public Vector2 Normalized
		=> this / Length;

    public Vector2() : this(0, 0) { }

    public Vector2(float x, float y)
	{
		X = x;
		Y = y;
	}

	public Vector2(Vector2 vector)
	{
		X = vector.X;
		Y = vector.Y;
	}

	public float Distance(Vector2 other)
	{
		return (this - other).Length;
	}

	public Vector2 Rotate(float angle)
	{
		float cos = MathF.Cos(angle);
		float sin = MathF.Sin(angle);
		return new Vector2(X * cos - Y * sin, X * sin + Y * cos);
	}

	public static Vector2 operator +(Vector2 a, Vector2 b)
	{
		return new Vector2(a.X + b.X, a.Y + b.Y);
	}

	public static Vector2 operator -(Vector2 a, Vector2 b)
	{
		return new Vector2(a.X - b.X, a.Y - b.Y);
	}

	public static Vector2 operator *(Vector2 a, float b)
	{
		return new Vector2(a.X * b, a.Y * b);
	}

	public static Vector2 operator *(float a, Vector2 b)
	{
		return new Vector2(a * b.X, a * b.Y);
	}

	public static Vector2 operator /(Vector2 a, float b)
	{
		return new Vector2(a.X / b, a.Y / b);
	}

	public static float Dot(Vector2 a, Vector2 b)
	{
		return a.X * b.X + a.Y * b.Y;
	}

	public static float Cross(Vector2 a, Vector2 b)
	{
		return a.X * b.Y - a.Y * b.X;
	}

	public static float Distance(Vector2 a, Vector2 b)
	{
		return (a - b).Length;
	}

	public static float Angle(Vector2 a, Vector2 b)
	{
		return (float)Math.Acos(Dot(a, b) / (a.Length * b.Length));
	}

	public override string ToString()
	{
		return $"({X}; {Y})";
	}
}