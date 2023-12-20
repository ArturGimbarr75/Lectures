abstract class Person
{
	public string Name { get; set; }
	public Vehicle Vehicle { get; }

    public Person(string name, Vehicle vehicle)
    {
		Name = name;
        Vehicle = vehicle;
    }

	public abstract void Move();
}