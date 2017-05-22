using System.Collections.Generic;
using NumToWord.Domain;

namespace NumToWord.Infrastructure.Base
{
    public interface IRepository<T> where T : new()
    {        
        Word ConvertNumber(T entity);        
    }
}
