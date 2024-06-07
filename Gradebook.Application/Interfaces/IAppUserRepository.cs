using Gradebook.Domain.Entities;

namespace Gradebook.Application.Interfaces;

public interface IAppUserRepository : IRepository<AppUser>
{
    public IQueryable<AppUser> GetAll();
    public AppUser GetById(string id);
}