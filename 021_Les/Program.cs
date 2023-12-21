Employee[] employees = [new Manager("John", 30, 1000), new Programmer("Jack", 25, 500)];

foreach (Employee employee in employees)
{
	Console.WriteLine(employee.GetSalary());
}
