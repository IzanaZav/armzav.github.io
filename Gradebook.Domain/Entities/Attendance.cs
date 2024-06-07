namespace Gradebook.Domain.Entities;

public class Attendance : BaseEntity
{
    public bool Attended { get; set; }
    public bool HasReason { get; set; }
    public DateTime Date { get; set; }
    public Student Student { get; set; }
    public Subject Subject { get; set; }
}