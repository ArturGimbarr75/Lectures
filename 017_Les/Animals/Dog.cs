internal class Dog : AnimalBase
{
	public override string AnimalType => nameof(Dog);

	public Dog() : this("Dog")
	{

	}

	public Dog(string name) : base(name)
	{

	}
}
