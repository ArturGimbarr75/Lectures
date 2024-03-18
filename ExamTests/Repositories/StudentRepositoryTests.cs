using Exam.Models;
using Exam.Repos.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExamTests.Repositories;

[TestClass]
public class StudentRepositoryTests
{
    private ApplicationContext _context = default!;

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
    }

    [TestCleanup]
    public void Cleanup()
    {
        _context.Dispose();
    }

    [TestMethod]
    public async Task AddStudent()
    {
        // Arrange
        var studentRepository = new StudentRepository(_context);
        var departmentRepository = new DepartmentRepository(_context);

        var department = new Department { Name = "HR" };
        await departmentRepository.AddDepartmentAsync(department);

        var student = new Student { Name = "John", Department = department };
        await studentRepository.AddStudentAsync(student);

        // Act
        var students = await studentRepository.GetStudentsAsync();

        // Assert
        Assert.AreEqual(1, students.Count());
    }

    [TestMethod]
    public async Task GetStudents()
    {
        // Arrange
        var studentRepository = new StudentRepository(_context);
        var departmentRepository = new DepartmentRepository(_context);

        var department = new Department { Name = "HR" };
        await departmentRepository.AddDepartmentAsync(department);

        var student = new Student { Name = "John", Department = department };
        await studentRepository.AddStudentAsync(student);

        // Act
        var students = await studentRepository.GetStudentsAsync();

        // Assert
        Assert.AreEqual(1, students.Count());
        Assert.AreEqual("John", students.First().Name);

    }

    [TestMethod]
    public async Task GetStudentById()
    {
        // Arrange
        var studentRepository = new StudentRepository(_context);
        var departmentRepository = new DepartmentRepository(_context);

        var department = new Department { Name = "HR" };
        await departmentRepository.AddDepartmentAsync(department);

        var student = new Student { Name = "John", Department = department };
        await studentRepository.AddStudentAsync(student);

        // Act
        var studentFromDb = await studentRepository.GetStudentAsync(student.Id);

        // Assert
        Assert.AreEqual("John", studentFromDb!.Name);
    }

    [TestMethod]
    public async Task UpdateStudent()
    {
        // Arrange
        var studentRepository = new StudentRepository(_context);
        var departmentRepository = new DepartmentRepository(_context);

        var department = new Department { Name = "HR" };
        await departmentRepository.AddDepartmentAsync(department);

        var student = new Student { Name = "John", Department = department };
        await studentRepository.AddStudentAsync(student);

        // Act
        student.Name = "Jane";
        await studentRepository.UpdateStudentAsync(student);

        // Assert
        var studentFromDb = await studentRepository.GetStudentAsync(student.Id);
        Assert.AreEqual("Jane", studentFromDb!.Name);
    }

    [TestMethod]
    public async Task DeleteStudent()
    {
        // Arrange
        var studentRepository = new StudentRepository(_context);
        var departmentRepository = new DepartmentRepository(_context);

        var department = new Department { Name = "HR" };
        await departmentRepository.AddDepartmentAsync(department);

        var student = new Student { Name = "John", Department = department };
        await studentRepository.AddStudentAsync(student);

        // Act
        await studentRepository.DeleteStudentAsync(student.Id);

        // Assert
        Assert.AreEqual(0, (await studentRepository.GetStudentsAsync()).Count());
    }

    [TestMethod]
    public async Task GetStudentsByDepartment()
    {
        // Arrange
        var studentRepository = new StudentRepository(_context);
        var departmentRepository = new DepartmentRepository(_context);

        var hrDepartment = new Department { Name = "HR" };
        await departmentRepository.AddDepartmentAsync(hrDepartment);

        var itDepartment = new Department { Name = "IT" };
        await departmentRepository.AddDepartmentAsync(itDepartment);

        var student1 = new Student { Name = "John", Department = hrDepartment };
        await studentRepository.AddStudentAsync(student1);

        var student2 = new Student { Name = "Jane", Department = itDepartment };
        await studentRepository.AddStudentAsync(student2);

        // Act
        var students = await studentRepository.GetStudentsByDepartmentIdAsync(hrDepartment.Id);

        // Assert
        Assert.AreEqual(1, students.Count());
        Assert.AreEqual("John", students.First().Name);
    }
}