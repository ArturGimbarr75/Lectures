// 1_1
class Person
{
	public string Name { get; set; } = string.Empty;
	public int Age { get; set; }
	public float Height { get; set; }

    public Person() : this(1.8f)
    {
		Name = "John Doe";
		Age = 18;
	}

    public Person(float height)
    {
        Height = height;
    }
}