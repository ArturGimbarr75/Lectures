using _036_V2_Les.DB.Repositories;
using _036_V2_Les.Models;
using _036_V2_Les.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace _036_V2_Les.Pages;

public partial class Index
{

	[Inject] private IMainFolderRepository _folderReository { get; set; } = default!;
	[Inject] private IPathReadService _pathReadService { get; set; } = default!;
	[Inject] private NavigationManager _navigationManager { get; set; } = default!;

	private List<MainFolder> _folders = new();
	private string _path = string.Empty;

	protected override async Task OnInitializedAsync()
	{
		await GetAll();
	}

	private async Task GetAll()
	{
		_folders = (await _folderReository.GetMainFolders()).ToList();
	}

	private async Task AddFolder(MouseEventArgs e)
	{
		if (Path.Exists(_path))
		{
			await _pathReadService.AddAllFilesToDb(_path);
			await GetAll();
		}
		else
		{
			Console.WriteLine("Path does not exist");
		}
	}

	private async Task DeleteFolder(int id)
	{
		await _folderReository.DeleteMainFolder(id);
		await GetAll();
	}
}