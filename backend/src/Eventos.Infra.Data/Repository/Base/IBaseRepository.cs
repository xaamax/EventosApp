using Eventos.Domain.Entities.Base;

namespace Eventos.Infra.Data.Repository.Interfaces
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        T Create(T item);
        T FindByID(long id);
        List<T> FindAll();
        T Update(T item);
        void Delete(long id);
    }
}
