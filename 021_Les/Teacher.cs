class Teacher : Person
{
	private string _subject;

	public Teacher(string name, DateTime birthDate, string subject) : base(name, birthDate)
	{
		_subject = subject;
	}

	public string GetSubject()
	{
		return _subject;
	}
}