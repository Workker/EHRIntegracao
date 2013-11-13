
namespace EHRIntegracao.Domain.Common
{
    public interface IRepository<T>
    {
        T GetById(object id);
        void Save(T entity);
        T[] GetAll();
        void Delete(T entity);
    }
}
