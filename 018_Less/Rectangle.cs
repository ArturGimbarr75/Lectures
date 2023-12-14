class Rectangle
{
	public int Width { get; set; }
	public int Height { get; set; }
	
	public Rectangle(int width, int height)
	{
		Width = width;
		Height = height;
	}

	public int GetArea()
	{
		return Width * Height;
	}

	public int GetPerimeter()
	{
		return 2 * (Width + Height);
	}
}