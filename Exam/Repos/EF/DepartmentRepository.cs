using Exam.Models;
using Microsoft.EntityFrameworkCore;

namespace Exam.Repos.EF;

public class DepartmentRepository : IDepartmentRepository
{
    private readonly ApplicationContext _context;

    public DepartmentRepository(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<Department> AddDepartmentAsync(Department department)
    {
        await _context.Departments.AddAsync(department);
        await _context.SaveChangesAsync();
        return department;
    }

    public async Task<Department?> DeleteDepartmentAsync(Guid id)
    {
        Department? department = await _context.Departments.FindAsync(id);

        if (department != null)
        {
            _context.Departments.Remove(department);
            await _context.SaveChangesAsync();
        }

        return department;
    }

	public async Task<Lecture?> ExcludeLectureAsync(Guid departmentId, Guid lectureId)
	{
        Department? department = await _context.Departments.Include(d => d.Lectures).FirstOrDefaultAsync(d => d.Id == departmentId);
		Lecture? lecture = await _context.Lectures.FindAsync(lectureId);

        if (department is not null && lecture is not null)
        {
			department.Lectures.Remove(lecture);
			await _context.SaveChangesAsync();
		}

        return lecture;
	}

	public async Task<Department?> GetDepartmentAsync(Guid id)
    {
        return await _context.Departments.FindAsync(id);
    }

    public async Task<IEnumerable<Department>> GetDepartmentsAsync()
    {
        return await Task.FromResult(_context.Departments.AsEnumerable());
    }

	public async Task<IEnumerable<Department>> GetDepartmentsWithLecturesAsync()
	{
		return await Task.FromResult(_context.Departments.Include(d => d.Lectures).AsEnumerable());
	}

	public async Task<Lecture?> IncludeLectureAsync(Guid departmentId, Guid lectureId)
	{
		Department? department = await _context.Departments.Include(d => d.Lectures).FirstOrDefaultAsync(d => d.Id == departmentId);
        Lecture? lecture = await _context.Lectures.FindAsync(lectureId);

        if (department is not null && lecture is not null)
        {
            department.Lectures.Add(lecture);
            await _context.SaveChangesAsync();
        }

        return lecture;
	}

	public async Task<Department?> UpdateDepartmentAsync(Department department)
    {
        Department? existingDepartment = await _context.Departments.FindAsync(department.Id);

        if (existingDepartment is not null)
        {
            existingDepartment.Name = department.Name;
            await _context.SaveChangesAsync();
        }

        return existingDepartment;
    }
}
