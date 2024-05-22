using NoteExam.Models;

namespace NoteExam.Persistence.Repositories;

public interface IImageRepository
{
	Task<bool> IsUserOwnsImageAsync(Guid userId, Guid imageId);
	Task<Image?> GetImageByIdAsync(Guid id);
	Task<IEnumerable<Image>> GetUserImagesAsync(Guid userId);
	Task<Image?> AddImageAsync(Image image);
	Task<Image?> UpdateImageAsync(Image image);
	Task<bool> DeleteImageAsync(Guid id);
}
