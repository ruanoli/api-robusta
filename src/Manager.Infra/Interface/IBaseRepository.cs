using Manager.Domain.Entities;

namespace Manager.Infra.Inteface
{
    public interface IBaseRepository<T> where T : Base
    {
        Task<T> Create(T obj);
        Task<T> Update(T obj);
        Task Delete(long id);
        Task<T> Get(long id);
        Task<List<T>> GetAll();
    }
}