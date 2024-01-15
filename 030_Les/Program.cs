Car[] vehicles =
{
	new Audi("Audi A4", 15, 85, 85, false),
	new Audi("Audi A6", 15, 85, 85, false),
	new Bmw("BMW 3", 15, 85, 85, false),
	new Bmw("BMW 5", 15, 85, 85, false)
};

foreach (Car vehicle in vehicles)
{
	while (vehicle.Fuel > 0)
	{
		vehicle.Drive();
	}

    Console.WriteLine();
}
