using Core.DataAccess.InMemory;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : InMemoryEntityRepositoryBase<Car, int>, ICarDal
    {
        protected override int generateId()
        {
            int nextId = _entities.Count == 0
           ? 1
           : _entities.Max(e => e.Id) + 1;
            return nextId;
        }
    }
}
