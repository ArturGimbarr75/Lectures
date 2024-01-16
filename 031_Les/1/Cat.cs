public class Cat : IMammal
{
	public string AnimalName => "Cat";
	public float Energy { get; private set;  }
	public float EnergyVolume { get; }

	public Cat(float energy, float energyVolume)
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
		if (partner is Cat cat)
		{
			if (Energy > EnergyVolume / 2 && cat.Energy > cat.EnergyVolume / 2)
			{
				Energy -= EnergyVolume / 2;
				cat.Energy -= cat.EnergyVolume / 2;
				return new Cat(EnergyVolume / 2, EnergyVolume);
			}
		}

		return null;
	}
}
