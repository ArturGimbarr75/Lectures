using Exam.Models;

namespace Exam.Repos.EF;

public class LectureRepository : ILectureRepository
{
	private readonly ApplicationContext _context;

	public LectureRepository(ApplicationContext context)
	{
		_context = context;
	}

	public async Task<Lecture> AddLectureAsync(Lecture lecture)
	{
		await _context.Lectures.AddAsync(lecture);
		await _context.SaveChangesAsync();
		return lecture;
	}

	public async Task<Lecture?> DeleteLectureAsync(Guid id)
	{
		Lecture? lecture = await _context.Lectures.FindAsync(id);

		if (lecture is not null)
		{
			_context.Lectures.Remove(lecture);
			await _context.SaveChangesAsync();
		}

		return lecture;
	}

	public async Task<Lecture?> GetLectureAsync(Guid id)
	{
		return await _context.Lectures.FindAsync(id);
	}

	public async Task<IEnumerable<Lecture>> GetLecturesAsync()
	{
		return await Task.FromResult(_context.Lectures.AsEnumerable());
	}

	public async Task<IEnumerable<Lecture>> GetLecturesByDepartmentIdAsync(Guid departmentId)
	{
		return await Task.FromResult(_context.Lectures.Where(l => l.Departments.Any(d => d.Id == departmentId)).AsEnumerable());
	}

	public Task<IEnumerable<Lecture>> GetLecturesNotInDepartmentAsync(Guid departmentId)
	{
		return Task.FromResult(_context.Lectures.Where(l => l.Departments.All(d => d.Id != departmentId)).AsEnumerable());
	}

	public async Task<Lecture?> UpdateLectureAsync(Lecture lecture)
	{
		Lecture? existingLecture = await _context.Lectures.FindAsync(lecture.Id);

		if (existingLecture is not null)
		{
			existingLecture.Name = lecture.Name;
			await _context.SaveChangesAsync();
		}

		return existingLecture;
	}
}
