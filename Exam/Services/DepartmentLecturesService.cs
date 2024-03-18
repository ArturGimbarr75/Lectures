using Exam.Models;
using Exam.Repos;

namespace Exam.Services;

public class DepartmentLecturesService : IDepartmentLecturesService
{
	private readonly IDepartmentRepository _departmentRepository;
	private readonly ILectureRepository _lectureRepository;
	private readonly IStudentRepository _studentRepository;

	public DepartmentLecturesService(IDepartmentRepository departmentRepository, ILectureRepository lectureRepository, IStudentRepository studentRepository)
	{
		_departmentRepository = departmentRepository;
		_lectureRepository = lectureRepository;
		_studentRepository = studentRepository;
	}

	public async Task<Lecture?> AddLectureToDepartment(Guid departmentId, Guid lectureId)
	{
		Department? department = await _departmentRepository.GetDepartmentAsync(departmentId);
		Lecture? lecture = await _lectureRepository.GetLectureAsync(lectureId);

		return await _departmentRepository.HasLectureAsync(departmentId, lectureId)
			? null
			: await _departmentRepository.IncludeLectureAsync(departmentId, lectureId);
	}

	public async Task<Lecture?> RemoveLectureFromDepartment(Guid departmentId, Guid lectureId)
	{
		Department? department = await _departmentRepository.GetDepartmentAsync(departmentId);

		if (department is null)
			return null;

		if (!await _departmentRepository.HasLectureAsync(departmentId, lectureId))
			return null;

		IEnumerable<Student> students = await _departmentRepository.GetAllStudents(departmentId);

		foreach (Student student in students)
		{
			await _studentRepository.ExcludeLectureAsync(student.Id, lectureId);
		}

		return await _departmentRepository.ExcludeLectureAsync(departmentId, lectureId);
	}
}