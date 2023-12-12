// 1_1

// 1_2

// 1_3

// 1_4
class School
{
	public string Name { get; set; } = string.Empty;
	public string City { get; set; } = string.Empty;
	public int StudentsCount { get; set; }

	public School(string name, string city)
	{
		Name = name;
		City = city;
		StudentsCount = 0;
	}

	public School(string name, string city, int studentsCount) : this(name, city)
	{
		StudentsCount = studentsCount;
	}
}