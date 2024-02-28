using _036_Les.DB;
using _036_V2_Les.Models;
using Microsoft.EntityFrameworkCore;

namespace _036_V2_Les.DB.Repositories;

public class TagRepository : ITagRepository
{
	private readonly AppDbContext _context;

	public TagRepository(AppDbContext context)
	{
		_context = context;
	}

	public async Task<List<Tag>> GetTags()
	{
		return await _context.Tags.ToListAsync();
	}

	public async Task<Tag> GetTag(int id)
	{
		return await _context.Tags.FindAsync(id);
	}

	public async Task<Tag> AddTag(Tag tag)
	{
		_context.Tags.Add(tag);
		await _context.SaveChangesAsync();
		return tag;
	}

	public async Task<Tag> UpdateTag(Tag tag)
	{
		Tag? tagToUpdate = await _context.Tags.FindAsync(tag.Id);

		if (tagToUpdate is not null)
		{
			tagToUpdate.Name = tag.Name;
			_context.Tags.Update(tagToUpdate);
			await _context.SaveChangesAsync();
			return tag;
		}

		return null;
	}

	public async Task<Tag> DeleteTag(int id)
	{
		var tag = await _context.Tags.FindAsync(id);
		_context.Tags.Remove(tag);
		await _context.SaveChangesAsync();
		return tag;
	}
}