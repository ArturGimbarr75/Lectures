class Programmer : Employee
{
	public Programmer(string name, int age, int salary)
		: base(name, age, salary) { }

	public override sealed int GetSalary()
	{
		return Salary;
	}
}