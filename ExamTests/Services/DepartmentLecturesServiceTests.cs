using Exam.Models;
using Exam.Repos.EF;
using Exam.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExamTests.Services;

[TestClass]
public class DepartmentLecturesServiceTests
{
	private DepartmentLecturesService _service = default!;
	private ApplicationContext _context = default!;
	private DepartmentRepository _departmentRepository = default!;
	private LectureRepository _lectureRepository = default!;
	private StudentRepository _studentRepository = default!;

	[TestInitialize]
	public void Initialize()
	{
		var options = new DbContextOptionsBuilder<ApplicationContext>()
			.UseInMemoryDatabase("ExamTestDb")
			.Options;

		using (var context = new ApplicationContext(options))
		{
			context.Database.EnsureDeleted();
			context.Database.EnsureCreated();
		}

		_context = new ApplicationContext(options);

		_lectureRepository = new LectureRepository(_context);
		_departmentRepository = new DepartmentRepository(_context);
		_studentRepository = new StudentRepository(_context);

		_service = new DepartmentLecturesService(_departmentRepository,
												 _lectureRepository,
												 _studentRepository);
	}

	[TestCleanup]
	public void Cleanup()
	{
		_context.Dispose();
	}

	[TestMethod]
	public async Task AddLectureToDepartment()
	{
		// Arrange
		var department = new Department { Name = "HR" };
		await _departmentRepository.AddDepartmentAsync(department);

		var lecture = new Lecture { Name = "C#" };
		await _lectureRepository.AddLectureAsync(lecture);

		// Act
		var result = await _service.AddLectureToDepartment(department.Id, lecture.Id);

		// Assert
		Assert.IsNotNull(result);
	}

	[TestMethod]
	public async Task AddExistingLectureToDepartment()
	{
		// Arrange
		var department = new Department { Name = "HR" };
		await _departmentRepository.AddDepartmentAsync(department);

		var lecture = new Lecture { Name = "C#" };
		await _lectureRepository.AddLectureAsync(lecture);

		await _service.AddLectureToDepartment(department.Id, lecture.Id);

		// Act
		var result = await _service.AddLectureToDepartment(department.Id, lecture.Id);

		// Assert
		Assert.IsNull(result);
	}

	[TestMethod]
	public async Task RemoveLectureFromDepartment()
	{
		// Arrange
		var department = new Department { Name = "HR" };
		await _departmentRepository.AddDepartmentAsync(department);

		var lecture = new Lecture { Name = "C#" };
		await _lectureRepository.AddLectureAsync(lecture);

		await _service.AddLectureToDepartment(department.Id, lecture.Id);

		// Act
		var result = await _service.RemoveLectureFromDepartment(department.Id, lecture.Id);

		// Assert
		Assert.IsNotNull(result);
	}

	[TestMethod]
	public async Task RemoveNonExistingLectureFromDepartment()
	{
		// Arrange
		var department = new Department { Name = "HR" };
		await _departmentRepository.AddDepartmentAsync(department);

		var lecture = new Lecture { Name = "C#" };
		await _lectureRepository.AddLectureAsync(lecture);

		// Act
		var result = await _service.RemoveLectureFromDepartment(department.Id, lecture.Id);

		// Assert
		Assert.IsNull(result);
	}
}
