public interface IAnimal : IComparable<IAnimal>
{
	string AnimalName { get; }

	float Energy { get; }
	float EnergyVolume { get; }

	float Eat(float foodAmount);

	int IComparable<IAnimal>.CompareTo(IAnimal? other)
	{ 
		return AnimalName.CompareTo(other?.AnimalName);
	}
}
