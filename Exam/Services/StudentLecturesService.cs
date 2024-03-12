using Exam.Models;
using Exam.Repos;

namespace Exam.Services;

public class StudentLecturesService : IStudentLecturesService
{
	private readonly IStudentRepository _studentRepository;
	private readonly IDepartmentRepository _departmentRepository;

	public StudentLecturesService(IStudentRepository studentRepository, IDepartmentRepository departmentRepository)
	{
		_studentRepository = studentRepository;
		_departmentRepository = departmentRepository;
	}

	public async Task<Lecture?> AddLectureToStudent(Guid studentId, Guid lectureId)
	{
		Student? student = await _studentRepository.GetStudentAsync(studentId);

		if (student is null)
			return null;
        
		Department? department = await _departmentRepository.GetDepartmentAsync(student.DepartmentId);

		if (department is null)
			return null;

		if (!await _departmentRepository.HasLectureAsync(department.Id, lectureId))
			return null;

		return await _studentRepository.IncludeLectureAsync(student.Id, lectureId);
    }

	public async Task<Lecture?> RemoveLectureFromStudent(Guid studentId, Guid lectureId)
	{
		Student? student = await _studentRepository.GetStudentAsync(studentId);

		return student is null ? null : await _studentRepository.ExcludeLectureAsync(student.Id, lectureId);
	}
}