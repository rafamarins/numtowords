using NumToWord.Infrastructure.DataAccess;
namespace NumToWord.Infrastructure.Base
{
    public class ConnectionDB : DbConnection
    {
        private static string ConnString
        {
            get
            {
                return System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            }
        }

        public ConnectionDB()
            : base(ConnString)
        {

        }
    }
}
