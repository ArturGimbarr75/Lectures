namespace Exam.Models;

public class Department
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;

    public virtual ICollection<Lecture> Lectures { get; set; } = default!;
    public virtual ICollection<Student> Students { get; set; } = default!;
}
