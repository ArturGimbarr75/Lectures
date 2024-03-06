namespace Exam.Models;

public class Student
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public Guid DepartmentId { get; set; }

    public virtual Department Department { get; set; } = default!;
    public virtual ICollection<Lecture> Lectures { get; set; } = default!;
}
