using System.Collections.Generic;

/// <summary>
/// 
/// </summary>
namespace NumToWord.Domain
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IService<T> where T : class
    {
        /// <summary>
        /// Converts the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        Word Convert(T entity);        
    }
}
