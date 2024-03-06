using Exam.Models;

namespace Exam.Repos;

public interface ILectureRepository
{
	Task<IEnumerable<Lecture>> GetLecturesAsync();
	Task<Lecture?> GetLectureAsync(Guid id);
	Task<Lecture> AddLectureAsync(Lecture lecture);
	Task<Lecture?> UpdateLectureAsync(Lecture lecture);
	Task<Lecture?> DeleteLectureAsync(Guid id);
	Task<IEnumerable<Lecture>> GetLecturesByDepartmentIdAsync(Guid departmentId);
	Task<IEnumerable<Lecture>> GetLecturesNotInDepartmentAsync(Guid departmentId);
}
