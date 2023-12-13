
internal class Hamster : AnimalBase
{
	public override string AnimalType => nameof(Hamster);

	public Hamster() : this("Hamster")
	{

	}

	public Hamster(string name) : base(name)
	{

	}
}
