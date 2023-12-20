class Car : Vehicle
{
	public float Speed { get; private set; }

	public Car(float maxSpeed) : base(maxSpeed)
	{

	}

	public override void Move()
	{
        Console.WriteLine("Moving with Car");
    }
}
