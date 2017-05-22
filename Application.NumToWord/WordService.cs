using NumToWord.Domain;
using NumToWord.Infrastructure.Logging;
using NumToWord.Infrastructure.Repositories;

namespace NumToWord.Application
{
    public class WordService : IService<Word>
    {

        /// <summary>
        /// Converts the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public Word Convert(Word entity)
        {
            Word result = new Word();
            WordRep repository = new WordRep();
            try
            {
                result = repository.ConvertNumber(entity);
            }
            catch (System.Exception ex)
            {
                TraceLog.WriteAppExLog("WordService - Error", ex.Message);
            }
            return result;
        }
    }
}
