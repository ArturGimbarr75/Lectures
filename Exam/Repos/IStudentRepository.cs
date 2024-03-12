using Exam.Models;

namespace Exam.Repos;

public interface IStudentRepository
{
	Task<IEnumerable<Student>> GetStudentsAsync();
	Task<Student?> GetStudentAsync(Guid id);
	Task<Student> AddStudentAsync(Student student);
	Task<Student?> UpdateStudentAsync(Student student);
	Task<Student?> DeleteStudentAsync(Guid id);
	Task<IEnumerable<Student>> GetStudentsByDepartmentIdAsync(Guid departmentId);
	Task<IEnumerable<Student>> GetStudentsNotInDepartmentAsync(Guid departmentId);
	Task<Lecture?> IncludeLectureAsync(Guid studentId, Guid lectureId);
	Task<Lecture?> ExcludeLectureAsync(Guid studentId, Guid lectureId);
	Task<IEnumerable<Lecture>> GetLecturesAsync(Guid studentId);
	Task<IEnumerable<Lecture>> GetLecturesNotAsignedToStudentAsync(Guid studentId);
}
