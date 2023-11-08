namespace _005_Les;

class Folder
{
	public string Name { get; set; } = "";
	public Folder[] Folders { get; set; } = new Folder[0];
	public Folder? Parrent { get; set; }
}
