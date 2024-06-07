namespace Gradebook.Domain.Entities;

public class Subject : BaseEntity
{
    public string Name { get; set; }
    public List<Group> Groups { get; set; }
}