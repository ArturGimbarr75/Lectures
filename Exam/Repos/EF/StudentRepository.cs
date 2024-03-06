using Exam.Models;
using Microsoft.EntityFrameworkCore;

namespace Exam.Repos.EF;

public class StudentRepository : IStudentRepository
{
	private readonly ApplicationContext _dbContext;

	public StudentRepository(ApplicationContext dbContext)
	{
		_dbContext = dbContext;
	}

	public async Task<IEnumerable<Student>> GetStudentsAsync()
	{
		return await Task.FromResult(_dbContext.Students.AsEnumerable());
	}

	public async Task<Student?> GetStudentAsync(Guid id)
	{
		return await _dbContext.Students.FindAsync(id);
	}

	public async Task<Student> AddStudentAsync(Student student)
	{
		var result = await _dbContext.Students.AddAsync(student);
		await _dbContext.SaveChangesAsync();
		return result.Entity;
	}

	public async Task<Student?> UpdateStudentAsync(Student student)
	{
		var result = _dbContext.Students.Update(student);
		await _dbContext.SaveChangesAsync();
		return result.Entity;
	}

	public async Task<Student?> DeleteStudentAsync(Guid id)
	{
		var student = await _dbContext.Students.FindAsync(id);
		if (student is not null)
		{
			_dbContext.Students.Remove(student);
			await _dbContext.SaveChangesAsync();
		}
		return student;
	}

	public async Task<IEnumerable<Student>> GetStudentsByDepartmentIdAsync(Guid departmentId)
	{
		return await _dbContext.Students
			.Where(s => s.DepartmentId == departmentId)
			.ToListAsync();
	}

	public async Task<IEnumerable<Student>> GetStudentsNotInDepartmentAsync(Guid departmentId)
	{
		return await _dbContext.Students
			.Where(s => s.DepartmentId != departmentId)
			.ToListAsync();
	}

}
