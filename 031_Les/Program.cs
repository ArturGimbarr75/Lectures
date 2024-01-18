// 1
List<IAnimal> animals = new()
{
	new Dog(40, 80),
	new Cat(20, 40),
	new Dog(30, 60),
	new Cat(10, 20),
	new Dog(20, 40),
	new Carp(4, 20),
	new Bass(6, 30),
	new Carp(8, 40)
};

animals.Sort();

foreach (IAnimal animal in animals)
{
    Console.WriteLine($"{animal.AnimalName} has {animal.Energy} / {animal.EnergyVolume} energy.");
	float eaten = animal.Eat(Random.Shared.Next(1, 20));
	Console.WriteLine($"{animal.AnimalName} ate {eaten} food and now have {animal.Energy} energy.");
}
Console.WriteLine("\n\n");

// 2
IPolygon[] polygons =
{
	new Triangle(new(-2, 0), new(2, 0), new(2, 3)),
	new Square(new (5, 5), 3, 45)
};

foreach (IPolygon polygon in polygons)
{
	Console.WriteLine($"Polygon: {polygon.GetType().Name}");
	Console.WriteLine(polygon);
	Console.WriteLine($"Area: {polygon.GetArea()}");
	Console.WriteLine($"Perimeter: {polygon.GetPerimeter()}");
	Console.WriteLine();
}
Console.WriteLine("\n\n");

// 3
FileWriter writer = new();
writer.AppendPool(animals);
writer.AppendPool(polygons);
writer.WriteToFile("output.txt");