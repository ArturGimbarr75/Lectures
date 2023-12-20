// 2_1
{
	Vehicle[] vehicles = new Vehicle[]
	{
		new Car(200),
		new Bike(50)
	};

	foreach (Vehicle vehicle in vehicles)
	{
		vehicle.Move();
	}
}

// 2_2-3
{
	Bike bike = new(50);
	Person person = new Student("John", "Hogwarts", bike);

	person.Move();
}
