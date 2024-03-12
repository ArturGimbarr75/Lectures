using Exam.Models;

namespace Exam.Repos;

public interface IDepartmentRepository
{
    Task<IEnumerable<Department>> GetDepartmentsAsync();
    Task<IEnumerable<Department>> GetDepartmentsWithLecturesAsync();
    Task<IEnumerable<Student>> GetAllStudents(Guid departmentId); 
    Task<Department?> GetDepartmentAsync(Guid id);
    Task<Department> AddDepartmentAsync(Department department);
    Task<Department?> UpdateDepartmentAsync(Department department);
    Task<Department?> DeleteDepartmentAsync(Guid id);
    Task<Lecture?> IncludeLectureAsync(Guid departmentId, Guid lectureId);
    Task<Lecture?> ExcludeLectureAsync(Guid departmentId, Guid lectureId);
    Task<bool> HasLectureAsync(Guid departmentId, Guid lectureId);
	Task<bool> HasStudentAsync(Guid departmentId, Guid studentId);
}
