﻿namespace Models;

public class Author
{
	public Guid Id { get; set; }
	public string Name { get; set; } = default!;
	public string Surname { get; set; } = default!;

	public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}