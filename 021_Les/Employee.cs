
abstract class Employee
{
	public string Name { get; private set; }
	public int Age { get; private set; }
	public int Salary { get; private set; }

	public Employee(string name, int age, int salary)
	{
		Name = name;
		Age = age;
		Salary = salary;
	}

	public abstract int GetSalary();
}
