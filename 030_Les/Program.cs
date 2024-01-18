Car[] vehicles =
{
	new Audi("Audi A4", 15, 85, 85, false),
	new Bmw("BMW 5", 15, 85, 85, false),
	new Audi("Audi A6", 15, 85, 85, false),
	new Bmw("BMW 3", 15, 85, 85, false),
};

Array.Sort(vehicles, new CarComparer());

foreach (Car vehicle in vehicles)
{
	while (vehicle.Drive());
	vehicle.Refuel();

    Console.WriteLine();
}
