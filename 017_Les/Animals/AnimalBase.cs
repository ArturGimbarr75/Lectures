internal abstract class AnimalBase
{
    public virtual string AnimalType => nameof(AnimalBase);
	public string Name { get; }

    public AnimalBase() : this("Unknown")
    {

    }

    public AnimalBase(string name)
    {
		Name = name;
	}
}
