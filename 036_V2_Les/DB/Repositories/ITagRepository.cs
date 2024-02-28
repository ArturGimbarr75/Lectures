using _036_V2_Les.Models;

namespace _036_V2_Les.DB.Repositories;

public interface ITagRepository
{
	Task<List<Tag>> GetTags();
	Task<Tag> GetTag(int id);
	Task<Tag> AddTag(Tag tag);
	Task<Tag> UpdateTag(Tag tag);
	Task<Tag> DeleteTag(int id);
}
