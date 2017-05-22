using System.Collections.Generic;
using NumToWord.Domain;

namespace NumToWord.Infrastructure.Base
{
    public abstract class Repository<T> : IRepository<T> where T : new()
    {
        public abstract Word ConvertNumber(T entity);
    }
}
