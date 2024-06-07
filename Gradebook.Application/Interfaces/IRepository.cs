using System.Linq.Expressions;

namespace Gradebook.Application.Interfaces;

public interface IRepository<T> where T: class
{
    public void Add(T item);
    public void Delete(T item);

    public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
    public void SaveChanges();
}