using _036_V2_Les.DB.Repositories;
using _036_V2_Les.Models;

namespace _036_V2_Les.Services;

public class PathReadService : IPathReadService
{
	private readonly IFileRepository _fileRepository;
	private readonly IMainFolderRepository _mainFolderRepository;

	public PathReadService(IFileRepository fileRepository, IMainFolderRepository mainFolderRepository)
	{
		_fileRepository = fileRepository;
		_mainFolderRepository = mainFolderRepository;
	}

	public async Task AddAllFilesToDb(string path)
	{
		var mainFolder = new MainFolder
		{
			Name = Path.GetFileName(path),
			Path = path
		};

		await _mainFolderRepository.AddMainFolder(mainFolder);

		await AddFilesToDb(path, mainFolder.Id);
	}

	private async Task AddFilesToDb(string path, int mainFolderId)
	{
		var files = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);

		foreach (var file in files)
		{
			var fileInfo = new FileInfo(file);
			var fileModel = new Models.File
			{
				Name = fileInfo.Name,
				Path = fileInfo.FullName,
				Extension = fileInfo.Extension,
				Size = fileInfo.Length,
				MainFolderId = mainFolderId
			};

			await _fileRepository.AddFile(fileModel);
		}

		var directories = Directory.GetDirectories(path);

		foreach (var directory in directories)
		{
			await AddFilesToDb(directory, mainFolderId);
		}
	}
}
