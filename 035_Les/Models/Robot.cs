class Robot
{
	public Guid Id { get; set; }
	public List<Arm> Arms { get; set; }
	public List<Leg> Legs { get; set; }
	public Torso Torso { get; set; }
	public HeadType Head { get; set; }
}
