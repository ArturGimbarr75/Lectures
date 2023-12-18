// 1_1
{
	Car car = new() { Speed = 100 };
	Bike bike = new() { Speed = 50 };

	Console.WriteLine($"Car speed: {car.Speed}");
	Console.WriteLine($"Bike speed: {bike.Speed}");
}

PrintSeparator();

// 1_2
{
	Manager employee = new()
	{
		Name = "Employee 1",
		Salary = 1000,
		Employees = new Employee[]
		{
			new () { Name = "Employee 2", Salary = 500 },
			new () { Name = "Employee 3", Salary = 500 },
		}
	};

	Console.WriteLine($"Employee name: {employee.Name}");
	Console.WriteLine($"Employee salary: {employee.Salary}");
	Console.WriteLine($"Employee employees count: {employee.Employees.Length}");
}

PrintSeparator();

{
	Manager manager = new()
	{
		Name = "Manager 1",
		Salary = 1000,
		Employees = new Employee[]
		{
			new () { Name = "Employee 1", Salary = 500 },
			new () { Name = "Employee 2", Salary = 500 },
			new Programmer() { Name = "Programmer 1", Salary = 500, ProgrammingLanguage = "C#" },
			new Programmer() { Name = "Programmer 2", Salary = 500, ProgrammingLanguage = "C++" },
			new Programmer() { Name = "Programmer 3", Salary = 500, ProgrammingLanguage = "Java" },
			new Programmer() { Name = "Programmer 4", Salary = 500, ProgrammingLanguage = "Python" }
		}
	};

	void PrintInfoAboutProgrammers(Manager manager)
	{
		foreach (Employee employee in manager.Employees)
		{
			if (employee is Programmer programmer)
			{
				Console.WriteLine($"Programmer name: {programmer.Name}");
				Console.WriteLine($"Programmer salary: {programmer.Salary}");
				Console.WriteLine($"Programmer programming language: {programmer.ProgrammingLanguage}");
				Console.WriteLine();
			}
		}
	}

	PrintInfoAboutProgrammers(manager);
}

void PrintSeparator() => Console.WriteLine("\n\n" + new string('-', 50) + "\n\n");
