using Gradebook.Domain.Entities;

namespace Gradebook.Application.Interfaces;

public interface IStudentRepository : IRepository<Student>
{
    public List<Student> GetAllStudentsByGroupId(string groupId);
    public Student GetById(string id);
    public List<Student> GetAllStudents();
}