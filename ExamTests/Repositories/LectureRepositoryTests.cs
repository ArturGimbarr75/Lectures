using Exam.Models;
using Exam.Repos.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExamTests.Repositories;

[TestClass]
public class LectureRepositoryTests
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
    public async Task AddLecture()
    {
        // Arrange
        var repository = new LectureRepository(_context);
        var lecture = new Lecture { Name = "C#" };

        // Act
        await repository.AddLectureAsync(lecture);

        // Assert
        Assert.AreEqual(1, (await repository.GetLecturesAsync()).Count());
    }

    [TestMethod]
    public async Task GetLectures()
    {
        // Arrange
        var repository = new LectureRepository(_context);
        var lecture = new Lecture { Name = "C#" };
        await repository.AddLectureAsync(lecture);

        // Act
        var lectures = await repository.GetLecturesAsync();

        // Assert
        Assert.AreEqual(1, lectures.Count());
        Assert.AreEqual("C#", lectures.First().Name);
    }

    [TestMethod]
    public async Task GetLectureById()
    {
        // Arrange
        var repository = new LectureRepository(_context);
        var lecture = new Lecture { Name = "C#" };
        await repository.AddLectureAsync(lecture);

        // Act
        var lectureFromDb = await repository.GetLectureAsync(lecture.Id);

        // Assert
        Assert.AreEqual("C#", lectureFromDb!.Name);
    }

    [TestMethod]
    public async Task UpdateLecture()
    {
        // Arrange
        var repository = new LectureRepository(_context);
        var lecture = new Lecture { Name = "C#" };
        await repository.AddLectureAsync(lecture);

        // Act
        lecture.Name = "ASP.NET";
        await repository.UpdateLectureAsync(lecture);

        // Assert
        var lectureFromDb = await repository.GetLectureAsync(lecture.Id);
        Assert.AreEqual("ASP.NET", lectureFromDb!.Name);
    }

    [TestMethod]
    public async Task DeleteLecture()
    {
        // Arrange
        var repository = new LectureRepository(_context);
        var lecture = new Lecture { Name = "C#" };
        await repository.AddLectureAsync(lecture);

        // Act
        await repository.DeleteLectureAsync(lecture.Id);

        // Assert
        Assert.AreEqual(0, (await repository.GetLecturesAsync()).Count());
    }
}