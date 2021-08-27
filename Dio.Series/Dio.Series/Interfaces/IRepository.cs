using System.Collections.Generic;

namespace Dio.Series.Interfaces
{
    public interface IRepository<T>
    {
        List<T> List();
        T GetById(int id);
        void Insert(T entity);
        void Update(int id, T entity);
        int GetNextId();
        void Delete(int id);
    }
}
