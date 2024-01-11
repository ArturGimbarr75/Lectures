public class Pet
{
	public string Name { get; set; }
	public int Age { get; set; }

	override public string ToString()
	{
		return $"{Name} ({Age})";
	}
}