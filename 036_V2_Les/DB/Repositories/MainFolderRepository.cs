using _036_Les.DB;
using _036_V2_Les.Models;
using Microsoft.EntityFrameworkCore;

namespace _036_V2_Les.DB.Repositories;

public class MainFolderRepository : IMainFolderRepository
{
	private readonly AppDbContext _context;

	public MainFolderRepository(AppDbContext context)
	{
		_context = context;
	}

	public async Task<List<MainFolder>> GetMainFolders()
	{
		return await _context.MainFolders.ToListAsync();
	}

	public async Task<MainFolder> GetMainFolder(int id)
	{
		return await _context.MainFolders.FindAsync(id);
	}

	public async Task<MainFolder> AddMainFolder(MainFolder mainFolder)
	{
		_context.MainFolders.Add(mainFolder);
		await _context.SaveChangesAsync();
		return mainFolder;
	}

	public async Task<MainFolder> UpdateMainFolder(MainFolder mainFolder)
	{
		_context.MainFolders.Update(mainFolder);
		await _context.SaveChangesAsync();
		return mainFolder;
	}

	public async Task<MainFolder> DeleteMainFolder(int id)
	{
		var mainFolder = await _context.MainFolders.FindAsync(id);
		_context.MainFolders.Remove(mainFolder);
		await _context.SaveChangesAsync();
		return mainFolder;
	}
}