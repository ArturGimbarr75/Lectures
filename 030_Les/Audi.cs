
class Audi : Car
{
    public bool IsQuattro { get; private set; }

	public Audi() : this("Default Audi", 15, 85, 85, false) { }

	public Audi(string model, int fuelUssage, int fuel, int fuelCapacity, bool isQuattro)
		: base(model, fuelUssage, fuel, fuelCapacity)
	{
		IsQuattro = isQuattro;
	}
}