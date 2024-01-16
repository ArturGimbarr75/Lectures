public class Carp : IFish
{
	public string AnimalName => "Carp";
	public float Energy { get; private set;  }
	public float EnergyVolume { get; }

	public Carp(float energy, float energyVolume)
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

	public float Swim(float distance)
	{
		float requiredEnergy = distance * 2;
		float energyToSwim = Math.Min(requiredEnergy, Energy);
		Energy -= energyToSwim;
		return energyToSwim;
	}
}