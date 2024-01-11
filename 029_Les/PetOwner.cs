class PetOwner
{
	public string Name { get; set; }
	public List<Pet> Pets { get; set; }

	override public string ToString()
	{
		string separator = ", ";
		return $"{Name} {{{string.Join(separator, Pets)}}}";
	}
}