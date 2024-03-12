using Exam.Models;

namespace Exam.Services;

public interface IStudentLecturesService
{
	Task<Lecture?> AddLectureToStudent(Guid studentId, Guid lectureId);
	Task<Lecture?> RemoveLectureFromStudent(Guid studentId, Guid lectureId);
}
