using Exam.Models;

namespace Exam.Services;

public interface IDepartmentLecturesService
{
	Task<Lecture?> AddLectureToDepartment(Guid departmentId, Guid lectureId);
	Task<Lecture?> RemoveLectureFromDepartment(Guid departmentId, Guid lectureId);
}
