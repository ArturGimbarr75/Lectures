class Bike : Vehicle
{
	public float Speed { get; private set; }

	public Bike(float maxSpeed) : base(maxSpeed)
	{

	}

	public override void Move()
	{
		Console.WriteLine("Moving with Bike");
	}
}
