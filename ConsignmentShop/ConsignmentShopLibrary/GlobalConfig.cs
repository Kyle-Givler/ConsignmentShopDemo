using ConsignmentShopLibrary.DataAccess;

namespace ConsignmentShopLibrary
{
    public static class GlobalConfig
    {
        public enum DatabaseType { MSSQL };
        public static IDataConnection Connection { get; private set; }
        public static Store Store { get; set; }

        public static void InitializeConnection(DatabaseType db)
        {
            if(db == DatabaseType.MSSQL)
            {
                SQLConnector sql = new SQLConnector();
                Connection = sql;
            }
        }
    }
}
