namespace Exam.Models;

public class Lecture
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    
    public virtual ICollection<Student> Students { get; set; } = default!;
    public virtual ICollection<Department> Departments { get; set; } = default!;
}
