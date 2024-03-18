using Exam.Models;
using Exam.Repos.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExamTests.Repositories;

[TestClass]
public class DepartmentRepositoryTests
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
    public async Task AddDepartment()
    {
        // Arrange
        var repository = new DepartmentRepository(_context);
        var department = new Department { Name = "HR" };

        // Act
        await repository.AddDepartmentAsync(department);

        // Assert
        Assert.AreEqual(1, (await repository.GetDepartmentsAsync()).Count());
    }

    [TestMethod]
    public async Task GetDepartments()
    {
        // Arrange
        var repository = new DepartmentRepository(_context);
        var department = new Department { Name = "HR" };
        await repository.AddDepartmentAsync(department);

        // Act
        var departments = await repository.GetDepartmentsAsync();

        // Assert
        Assert.AreEqual(1, departments.Count());
        Assert.AreEqual("HR", departments.First().Name);
    }

    [TestMethod]
    public async Task GetDepartmentById()
    {
        // Arrange
        var repository = new DepartmentRepository(_context);
        var department = new Department { Name = "HR" };
        await repository.AddDepartmentAsync(department);

        // Act
        var departmentFromDb = await repository.GetDepartmentAsync(department.Id);

        // Assert
        Assert.AreEqual("HR", departmentFromDb!.Name);
    }

    [TestMethod]
    public async Task UpdateDepartment()
    {
        // Arrange
        var repository = new DepartmentRepository(_context);
        var department = new Department { Name = "HR" };
        await repository.AddDepartmentAsync(department);

        // Act
        department.Name = "IT";
        await repository.UpdateDepartmentAsync(department);

        // Assert
        var departmentFromDb = await repository.GetDepartmentAsync(department.Id);
        Assert.AreEqual("IT", departmentFromDb!.Name);
    }

    [TestMethod]
    public async Task DeleteDepartment()
    {
        // Arrange
        var repository = new DepartmentRepository(_context);
        var department = new Department { Name = "HR" };
        await repository.AddDepartmentAsync(department);

        // Act
        await repository.DeleteDepartmentAsync(department.Id);

        // Assert
        Assert.AreEqual(0, (await repository.GetDepartmentsAsync()).Count());
    }
}
