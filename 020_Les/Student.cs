// 2_1

// 2_2-3
class Student : Person
{
	public string School { get; set; }

	public Student(string name, string school, Vehicle vehicle) : base(name, vehicle)
	{
		School = school;
	}

	public override void Move()
	{
		Console.WriteLine($"Student {Name} is moving to {School} with {Vehicle.GetType().Name}");
	}
}
