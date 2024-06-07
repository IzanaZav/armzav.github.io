using Gradebook.Domain.Entities;

namespace Gradebook.Application.Interfaces;

public interface ISubjectRepository : IRepository<Subject>
{
    public List<Subject> GetAllSubjectsByGroupId(string groupId);
    public Subject GetById(string subjectId);
}