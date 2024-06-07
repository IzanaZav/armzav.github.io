using Gradebook.Domain.Entities;

namespace Gradebook.Application.Interfaces;

public interface IGroupRepository : IRepository<Group>
{
    List<Group> GetAllGroups();
    Group GetById(string id);
}