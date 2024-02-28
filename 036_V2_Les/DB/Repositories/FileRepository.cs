using _036_Les.DB;
using _036_V2_Les.Models;
using Microsoft.EntityFrameworkCore;

namespace _036_V2_Les.DB.Repositories;

public class FileRepository : IFileRepository
{
	private readonly AppDbContext _context;

	public FileRepository(AppDbContext context)
	{
		_context = context;
	}

	public async Task<List<Models.File>> GetFile(int id)
	{
		return await _context.Files.Where(f => f.Id == id).ToListAsync();
	}

	public async Task<Models.File> AddFile(Models.File file)
	{
		_context.Files.Add(file);
		await _context.SaveChangesAsync();
		return file;
	}

	public async Task<Models.File> UpdateFile(Models.File file)
	{
		_context.Files.Update(file);
		await _context.SaveChangesAsync();
		return file;
	}

	public async Task<Models.File> DeleteFile(int id)
	{
		var file = await _context.Files.Where(f => f.Id == id).FirstOrDefaultAsync();
		_context.Files.Remove(file);
		await _context.SaveChangesAsync();
		return file;
	}

	public async Task<Models.File> DeleteFile(Models.File file)
	{
		_context.Files.Remove(file);
		await _context.SaveChangesAsync();
		return file;
	}

	public async Task<IEnumerable<int>> GetFileTagsIds(int fileId)
	{
		return await _context.Files.FirstOrDefaultAsync(f => f.Id == fileId)
			.ContinueWith(f => f.Result?.Tags.Select(t => t.Id) ?? Enumerable.Empty<int>());
	}

    public Task<IEnumerable<Models.File>> GetFilesByFolderIdWithTags(int folderId)
    {
        return Task.FromResult(_context.Files.Include(f => f.Tags).Where(f => f.MainFolderId == folderId).AsEnumerable());
    }

	public async Task AddTag(int id, Tag tag)
	{
		Models.File? file = _context.Files.Find(id);

		if (file is not null)
		{
			file.Tags.Add(tag);
			_context.Files.Update(file);
			await _context.SaveChangesAsync();
		}
	}

	public async Task RemoveAllTags(int id)
	{
        Models.File? file = await _context.Files.Include(f => f.Tags).FirstOrDefaultAsync(f => f.Id == id);

		if (file is not null)
		{
            file.Tags.Clear();
            _context.Files.Update(file);
            await _context.SaveChangesAsync();
        }
	}
}