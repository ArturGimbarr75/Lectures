// 2_1
abstract class Vehicle
{
	public float MaxSpeed { get; protected set; }

    public Vehicle(float maxSpeed)
    {
		MaxSpeed = maxSpeed;
	}

	public abstract void Move();
}
