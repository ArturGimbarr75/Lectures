{
	// 1
	Student student = new Student("John", new DateTime(2000, 1, 1));
	Teacher teacher = new Teacher("Jack", new DateTime(1980, 1, 1), "Math");

	student.PrintInfo();
	teacher.PrintInfo();
}

{
	// 4
	Employee[] employees = [new Manager("John", 30, 1000), new Programmer("Jack", 25, 500)];

	foreach (Employee employee in employees)
	{
		Console.WriteLine(employee.GetSalary());
	}
}
