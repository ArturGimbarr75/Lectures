using Microsoft.EntityFrameworkCore;
using NoteExam.Models;
using NoteExam.Persistence.Context;

namespace NoteExam.Persistence.Repositories.EF;

internal class ImageRepository : IImageRepository
{
	private readonly AppDbContext _context;

	public ImageRepository(AppDbContext context)
	{
		_context = context;
	}

	public async Task<Image?> AddImageAsync(Image image)
	{
		try
		{
			await _context.Images.AddAsync(image);
			await _context.SaveChangesAsync();
			return image;
		}
		catch (Exception)
		{
			return null;
		}
	}

	public async Task<bool> DeleteImageAsync(Guid id)
	{
		Image? image = _context.Images.Find(id);

		if (image is null)
		{
			return false;
		}

		_context.Remove(image);
		await _context.SaveChangesAsync();

		return true;
	}

	public async Task<Image?> GetImageByIdAsync(Guid id)
	{
		return await _context.Images.FindAsync(id);
	}

	public async Task<IEnumerable<Image>> GetUserImagesAsync(Guid userId)
	{
		return await _context.Images.Where(i => i.UserId == userId).ToListAsync();
	}

	public async Task<bool> IsUserOwnsImageAsync(Guid userId, Guid imageId)
	{
		return await _context.Images.AnyAsync(i => i.UserId == userId && i.Id == imageId);
	}

	public async Task<Image?> UpdateImageAsync(Image image)
	{
		Image? foundImage = _context.Images.Find(image.Id);

		if (foundImage is null)
		{
			return null;
		}

		_context.Entry(foundImage).CurrentValues.SetValues(image);
		_context.Update(foundImage);
		await _context.SaveChangesAsync();

		return foundImage;
	}
}
