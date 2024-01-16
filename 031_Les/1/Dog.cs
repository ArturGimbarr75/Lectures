public class Dog : IMammal
{
	public string AnimalName => "Dog";
	public float Energy { get; private set;  }
	public float EnergyVolume { get; }

	public Dog(float energy, float energyVolume)
	{
		Energy = energy;
		EnergyVolume = energyVolume;
	}

	public float Eat(float foodAmount)
	{
		float requiredEnergy = EnergyVolume - Energy;
		float energyToEat = Math.Min(requiredEnergy, foodAmount);
		Energy += energyToEat;
		return energyToEat;
	}

	public IMammal? GiveBirth(IMammal partner)
	{
		if (partner is Dog dog)
		{
			if (Energy > EnergyVolume / 2 && dog.Energy > dog.EnergyVolume / 2)
			{
				Energy -= EnergyVolume / 2;
				dog.Energy -= dog.EnergyVolume / 2;
				return new Dog(EnergyVolume / 2, EnergyVolume);
			}
		}

		return null;
	}
}
