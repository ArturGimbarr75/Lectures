// 1
Console.WriteLine("1 " + new string('-', 20));
List<int> list = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
var list2 = list.Select(x => x * x);
list2.Print();

// 2
Console.WriteLine("\n\n2 " + new string('-', 20));
var list3 = Enumerable.Range(0, 20).Select(_ => Random.Shared.Next(-100, 100)).ToList();
Console.WriteLine("All:");
list3.Print();
Console.WriteLine("Positive:");
list3.Where(x => x > 0).Print();

// 3
Console.WriteLine("\n\n3 " + new string('-', 20));
list3.Print();
Console.WriteLine("Positive less than 10:");
list3.Where(x => x > 0 && x < 10).Print();

// 4
Console.WriteLine("\n\n4 " + new string('-', 20));
list3.Print();
Console.WriteLine("Sorted:");
list3.OrderBy(x => x).Print();

// 5
Console.WriteLine("\n\n5 " + new string('-', 20));
list3.Print();
Console.WriteLine("Sorted by descending:");
list3.OrderByDescending(x => x).Print();

// 6
Console.WriteLine("\n\n6 " + new string('-', 20));
list3.Print();
Console.WriteLine("Max:");
Console.WriteLine(list3.Max());

// 7
Console.WriteLine("\n\n7 " + new string('-', 20));

var people = new List<Person>
{
	new ("John", 25),
	new ("Bob", 30),
	new ("Alice", 20),
	new ("Jack", 18),
	new ("Ann", 27),
	new ("Kate", 23),
	new ("Tom", 40),
	new ("Bill", 35),
	new ("Nick", 15),
	new ("Helen", 17),
};

Console.WriteLine("People:");
people.Print();

Console.WriteLine("People sorted by age:");
people.OrderBy(x => x.Age).Print();

Console.WriteLine("People whose names starts with 'A':");
people.Where(x => x.Name.StartsWith("A")).Print();

Console.WriteLine("People whose age is less than 30 sorted by name:");
people.Where(x => x.Age < 30).OrderBy(x => x.Name).Print();

// 2
Console.WriteLine("\n\n2 " + new string('-', 20));
List<PetOwner> petOwners = new()
{
	new() { Name = "Higa, Sidney", Pets = new List<Pet>
	{
		new () { Name = "Scruffy", Age = 8 },
		new () { Name = "Sam", Age = 4 },
		new () { Name = "Walker", Age = 5 }
	}},
	new() { Name = "Ashkenazi, Ronen", Pets = new List<Pet>
	{
		new () { Name = "Walker", Age = 3 },
		new () { Name = "Sugar", Age = 7 },
		new () { Name = "Spotty", Age = 1 }
	}},
	new() { Name = "Price, Vernette", Pets = new List<Pet>
	{
		new () { Name = "Scratches", Age = 4 },
		new () { Name = "Diesel", Age = 2 }
	}}, 
	new() { Name = "Hines, Patrick", Pets = new List<Pet>
	{
		new () { Name = "Dusty", Age = 4 },
		new () { Name = "Patches", Age = 1 }
	}}
};

petOwners.Print();

// 2.1
Console.WriteLine("\n\n2.1 " + new string('-', 20));

Console.WriteLine("Animals whose names starts with 'S'");
petOwners.SelectMany(x => x.Pets).Distinct().Where(x => x.Name.StartsWith("S")).Print();

// 2.2
Console.WriteLine("\n\n2.2 " + new string('-', 20));

Console.WriteLine("Animals whose age is over 5 and names starts with 'S'");
petOwners.SelectMany(x => x.Pets).Distinct().Where(x => x.Age > 5 && x.Name.StartsWith("S")).Print();

// 2.3
Console.WriteLine("\n\n2.3 " + new string('-', 20));

string sentence = "the quick brown FOX jumps over the lazy dog";
Console.WriteLine("Sentence:");
Console.WriteLine(sentence);
Console.WriteLine("Upper case word:");
Console.WriteLine(sentence.Split(' ').FirstOrDefault(x => x.All(char.IsUpper)));

// 3.1
Console.WriteLine("\n\n3.1 " + new string('-', 20));

Console.WriteLine("Files from folder:");
Directory.GetFiles("Folder").Print();

// 3.2
Console.WriteLine("\n\n3.2 " + new string('-', 20));
Console.WriteLine("*.txt files: ");
Directory.GetFiles("Folder").Where(x => x.EndsWith(".txt")).Print();

// 3.3
Console.WriteLine("\n\n3.3 " + new string('-', 20));
Console.WriteLine("File names: ");
Directory.GetFiles("Folder").Select(x => Path.GetFileName(x)).Print();
