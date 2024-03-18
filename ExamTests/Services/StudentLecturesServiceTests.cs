using Exam.Models;
using Exam.Repos.EF;
using Exam.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExamTests.Services;

[TestClass]
public class StudentLecturesServiceTests
{
	private StudentLecturesService _studentService = default!;
    private DepartmentLecturesService _departmentService = default!;

    private ApplicationContext _context = default!;
    private StudentRepository _studentRepository = default!;
    private LectureRepository _lectureRepository = default!;
    private DepartmentRepository _departmentRepository = default!;

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

        _studentRepository = new StudentRepository(_context);
        _lectureRepository = new LectureRepository(_context);
        _departmentRepository = new DepartmentRepository(_context);

        _studentService = new StudentLecturesService(_studentRepository,
                                                     _departmentRepository);

        _departmentService = new DepartmentLecturesService(_departmentRepository,
                                                           _lectureRepository,
                                                           _studentRepository);
    }

    [TestCleanup]
    public void Cleanup()
    {
        _context.Dispose();
    }

    [TestMethod]
    public async Task AddNotExistingLectureToStudent()
    {
        // Arrange
        var department = new Department { Name = "HR" };
        await _departmentRepository.AddDepartmentAsync(department);

        var student = new Student { Name = "Pesho", Department = department };
        await _studentRepository.AddStudentAsync(student);

        var lecture = new Lecture { Name = "C#" };
        await _lectureRepository.AddLectureAsync(lecture);

        // Act
        var result = await _studentService.AddLectureToStudent(student.Id, lecture.Id);

        // Assert
        Assert.IsNull(result);
    }

    [TestMethod]
    public async Task AddLectureToStudent()
    {
		// Arrange
		var department = new Department { Name = "HR" };
		await _departmentRepository.AddDepartmentAsync(department);

		var student = new Student { Name = "Pesho", Department = department };
		await _studentRepository.AddStudentAsync(student);

		var lecture = new Lecture { Name = "C#" };
		await _lectureRepository.AddLectureAsync(lecture);

		await _departmentService.AddLectureToDepartment(department.Id, lecture.Id);

		// Act
		var result = await _studentService.AddLectureToStudent(student.Id, lecture.Id);

		// Assert
		Assert.IsNotNull(result);
	}

    [TestMethod]
    public async Task RemoveLectureFromStudent()
    {
		// Arrange
		var department = new Department { Name = "HR" };
		await _departmentRepository.AddDepartmentAsync(department);

		var student = new Student { Name = "Pesho", Department = department };
		await _studentRepository.AddStudentAsync(student);

		var lecture = new Lecture { Name = "C#" };
		await _lectureRepository.AddLectureAsync(lecture);

		await _departmentService.AddLectureToDepartment(department.Id, lecture.Id);
		await _studentService.AddLectureToStudent(student.Id, lecture.Id);

		// Act
		var result = await _studentService.RemoveLectureFromStudent(student.Id, lecture.Id);

		// Assert
		Assert.IsNotNull(result);
	}
}