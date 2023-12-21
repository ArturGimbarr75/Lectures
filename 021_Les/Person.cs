class Person
{
	public string Name { get => _name; set => _name = value; }
	public DateTime BirthDate { get => _birthDate; set => _birthDate = value; }

	protected string _name;
	protected DateTime _birthDate;

	public Person(string name, DateTime birthDate)
	{
		_name = name;
		_birthDate = birthDate;
	}

	public void PrintInfo()
	{
		int years = DateTime.Now.Year - _birthDate.Year;
		Console.WriteLine($"Name: {_name}, Age: {years}");
	}
}
