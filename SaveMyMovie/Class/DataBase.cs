using System.Data.Linq;
using SaveMyMovie.Class.Tables;

namespace SaveMyMovie.Class
{
    public class DataBase : DataContext
    {
        public Table<MovieTable> MovieTables;
        
        private static DataBase connection = null;

        private DataBase(string connetionString) : base(connetionString)
        {
            
        }

        /// <summary>
        /// Gets the connection.
        /// </summary>
        /// <value>
        /// The connection.
        /// </value>
        public static DataBase Connection
        {
            get
            {
                if (connection == null)
                {
                    connection = new DataBase("isostore:movies2.sdf");
                }
                if(!connection.DatabaseExists())
                    connection.CreateDatabase();
                return connection;
            }   
            
        }

    }
}
