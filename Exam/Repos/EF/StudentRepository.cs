using Exam.Models;
using Microsoft.EntityFrameworkCore;

namespace Exam.Repos.EF;

public class StudentRepository : IStudentRepository
{
	private readonly ApplicationContext _context;

	public StudentRepository(ApplicationContext dbContext)
	{
		_context = dbContext;
	}

	public async Task<IEnumerable<Student>> GetStudentsAsync()
	{
		return await Task.FromResult(_context.Students.AsEnumerable());
	}

	public async Task<Student?> GetStudentAsync(Guid id)
	{
		return await _context.Students.FindAsync(id);
	}

	public async Task<Student> AddStudentAsync(Student student)
	{
		var result = await _context.Students.AddAsync(student);
		await _context.SaveChangesAsync();
		return result.Entity;
	}

	public async Task<Student?> UpdateStudentAsync(Student student)
	{
		var result = _context.Students.Update(student);
		await _context.SaveChangesAsync();
		return result.Entity;
	}

	public async Task<Student?> DeleteStudentAsync(Guid id)
	{
		var student = await _context.Students.FindAsync(id);
		if (student is not null)
		{
			_context.Students.Remove(student);
			await _context.SaveChangesAsync();
		}
		return student;
	}

	public async Task<IEnumerable<Student>> GetStudentsByDepartmentIdAsync(Guid departmentId)
	{
		return await _context.Students
			.Where(s => s.DepartmentId == departmentId)
			.ToListAsync();
	}

	public async Task<IEnumerable<Student>> GetStudentsNotInDepartmentAsync(Guid departmentId)
	{
		return await _context.Students
			.Where(s => s.DepartmentId != departmentId)
			.ToListAsync();
	}

	public async Task<Lecture?> IncludeLectureAsync(Guid studentId, Guid lectureId)
	{
		Student? student = await _context.Students.Include(s => s.Lectures).FirstOrDefaultAsync(s => s.Id == studentId);
		Lecture? lecture = await _context.Lectures.FindAsync(lectureId);

		if (student is null || lecture is null)
			return null;

		student.Lectures.Add(lecture);
		await _context.SaveChangesAsync();
		return lecture;
    }

	public async Task<Lecture?> ExcludeLectureAsync(Guid studentId, Guid lectureId)
	{
		Student? student = _context.Students.Include(s => s.Lectures).FirstOrDefault(s => s.Id == studentId);
		Lecture? lecture = _context.Lectures.Find(lectureId);

		if (student is null || lecture is null)
			return null;

		student.Lectures.Remove(lecture);
		await _context.SaveChangesAsync();
		return lecture;
	}

	public async Task<IEnumerable<Lecture>> GetLecturesAsync(Guid studentId)
	{
		Student? student = await _context.Students
								.Include(s => s.Lectures)
								.FirstOrDefaultAsync(s => s.Id == studentId);

		return student is null ? Enumerable.Empty<Lecture>() : student.Lectures.AsEnumerable();
	}

	public async Task<IEnumerable<Lecture>> GetLecturesNotAsignedToStudentAsync(Guid studentId)
	{
		Guid? departmentId = await _context.Students
			.Where(s => s.Id == studentId)
			.Select(s => s.DepartmentId)
			.FirstOrDefaultAsync();

		if (departmentId is null)
			return Enumerable.Empty<Lecture>();

		List<Lecture> studentLectures = await _context.Students
				.Where(s => s.Id == studentId)
				.SelectMany(s => s.Lectures)
				.ToListAsync();

		if (!studentLectures.Any())
			return await _context.Departments
				.Where(d => d.Id == departmentId)
				.SelectMany(d => d.Lectures)
				.ToListAsync();

		List<Lecture> lecturesNotAssignedToStudent = await _context.Departments
			.Where(d => d.Id == departmentId)
			.SelectMany(d => d.Lectures)
			.Where(l => !studentLectures.Contains(l))
			.ToListAsync();

		return lecturesNotAssignedToStudent;
	}
}
