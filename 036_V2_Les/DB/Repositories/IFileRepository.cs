using _036_V2_Les.Models;

namespace _036_V2_Les.DB.Repositories;

public interface IFileRepository
{
	Task<List<Models.File>> GetFile(int id);
	Task<Models.File> AddFile(Models.File file);
	Task AddTag(int id, Tag tag);
	Task<Models.File> UpdateFile(Models.File file);
	Task<Models.File> DeleteFile(int id);
	Task<Models.File> DeleteFile(Models.File file);
	Task<IEnumerable<int>> GetFileTagsIds(int fileId);
	Task<IEnumerable<Models.File>> GetFilesByFolderIdWithTags(int folderId);
	Task RemoveAllTags(int id);
}
