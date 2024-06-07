namespace Gradebook.Domain.Entities;

public class Group : BaseEntity
{
    public string Name { get; set; }
    public string TutorName { get; set; }
    public int CourseNumber { get; set; }
    public List<Student> Students { get; set; }
    public List<Subject> Subjects { get; set; }
}