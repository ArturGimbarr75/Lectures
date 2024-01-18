abstract class Car : IVehicle
{
	public string Model { get; private set; }
	public int FuelUssage { get; private set; }
	public int Fuel { get; private set; }
	public int FuelCapacity { get; private set; }
	public bool HasFuel => Fuel > 0;

    public Car() : this("Unknown", 10, 0, 60) { }

	public Car(string model, int fuelUssage, int fuel, int fuelCapacity)
	{
		Model = model;
		FuelUssage = fuelUssage;
		Fuel = fuel;
		FuelCapacity = fuelCapacity;
	}

    public bool Drive()
	{
		if (!HasFuel)
		{
			Console.WriteLine($"{Model} No fuel!");
			return false;
		}

		Fuel -= FuelUssage;
		Fuel = Math.Max(Fuel, 0);
		Console.WriteLine($"Driving a {Model}. Fuel volume: {Fuel} L.\"");
		return true;
	}

	public void Refuel()
	{
		Fuel = FuelCapacity;
		Console.WriteLine($"Refueling a {Model}. Fuel volume: {Fuel} L.");
	}
}
