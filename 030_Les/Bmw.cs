class Bmw : Car
{
	public bool IsXDrive { get; private set; }

	public Bmw() : this("Default BMW", 15, 85, 85, false) { }

	public Bmw(string model, int fuelUssage, int fuel, int fuelCapacity, bool isXDrive)
		: base(model, fuelUssage, fuel, fuelCapacity)
	{
		IsXDrive = isXDrive;
	}
}
