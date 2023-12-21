
class Manager : Employee
{

	public Manager(string name, int age, int salary)
		: base(name, age, salary) {}

	public override sealed int GetSalary()
	{
		return Salary;
	}
}
