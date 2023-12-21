class Student : Person
{

	private Guid _id;

	public Student(string name, DateTime birthDate) : this(name, birthDate, Guid.NewGuid())
	{

	}

    public Student(string name, DateTime birthDate, Guid id) : base(name, birthDate)
	{
        _id = id;
    }

	public Guid GetId()
	{
		return _id;
	}
}
