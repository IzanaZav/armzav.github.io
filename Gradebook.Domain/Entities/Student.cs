namespace Gradebook.Domain.Entities;

public class Student : BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    public Group Group { get; set; }
    public DateTime DateOfBirth { get; set; }
}