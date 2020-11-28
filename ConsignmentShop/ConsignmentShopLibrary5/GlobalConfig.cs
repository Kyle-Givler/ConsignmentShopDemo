using ConsignmentShopLibrary.DataAccess;
using Microsoft.Extensions.Configuration;
using System;

namespace ConsignmentShopLibrary
{
    public static class GlobalConfig
    {
        public enum DatabaseType { MSSQL };
        public static IDataConnection Connection { get; private set; }
        public static Store Store { get; set; }
        public static IConfiguration Configuration { get; private set; }
        public static DatabaseType DBType { get; private set; }

        static GlobalConfig ()
        {
            Configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", false, true).Build();
        }

        public static void InitializeConnection(DatabaseType db)
        {
            if(db == DatabaseType.MSSQL)
            {
                SQLConnector sql = new SQLConnector();
                Connection = sql;
                DBType = db;
            }
        }

        public static string ConnectionString()
        {
            if (DBType == DatabaseType.MSSQL)
            {
                return Configuration.GetConnectionString("MSSQL");
            }

            throw new InvalidOperationException("DBType is not valid");
        }
    }
}
