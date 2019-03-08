using System.Collections.Generic;

namespace cqrs_example.dapper.Interfaces
{
    public interface IQueryRepository<T>
    {
        IEnumerable<T> GetAll();

        T GetById(int id);
    }
}
