using _036_V2_Les.Models;

namespace _036_V2_Les.DB.Repositories;

public interface IMainFolderRepository
{
	Task<List<MainFolder>> GetMainFolders();
	Task<MainFolder> GetMainFolder(int id);
	Task<MainFolder> AddMainFolder(MainFolder mainFolder);
	Task<MainFolder> UpdateMainFolder(MainFolder mainFolder);
	Task<MainFolder> DeleteMainFolder(int id);
}
