internal class Cat : AnimalBase
{
	public override string AnimalType => nameof(Cat);

	public Cat() : this("Cat")
	{

	}

	public Cat(string name) : base(name)
	{

	}
}
