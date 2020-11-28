using Dapper;
using System.Collections.Generic;
using System.Data;
using ConsignmentShopLibrary.Models;
using System.Linq;

namespace ConsignmentShopLibrary.DataAccess
{
    public class SQLConnector : IDataConnection
    {
        public List<Item> LoadAllItems()
        {
            List<Item> items;

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnectionString()))
            {
                items = connection.Query<Item>("dbo.spItemGetAll").ToList();
            }

            return items;
        }

        public List<Vendor> LoadAllVendors()
        {
            List<Vendor> vendors;

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnectionString()))
            {
                vendors = connection.Query<Vendor>("dbo.spVendorGetAll").ToList();
            }

            return vendors;
        }

        public void SaveItem(Item item)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnectionString()))
            {
                var p = new DynamicParameters();

                p.Add("@Name", item.Name);
                p.Add("@Description", item.Description);
                p.Add("@Price", item.Price);
                p.Add("@Sold", item.Sold);
                p.Add("@Owner", item.Owner.Id);
                p.Add("@PaymentDistributed", item.PaymentDistrubuted);
                p.Add("@Id", 0, DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute("dbo.spItemInsert", p, commandType: CommandType.StoredProcedure);

                item.Id = p.Get<int>("@Id");
            }
        }

        public void SaveVendor(Vendor vendor)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnectionString()))
            {
                var p = new DynamicParameters();

                p.Add("@FirstName", vendor.FirstName);
                p.Add("@LastName", vendor.LastName);
                p.Add("@CommisionRate", vendor.CommisonRate);
                p.Add("@PaymentDue", vendor.PaymentDue);
                p.Add("@Id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute("dbo.spVendorInsert", p, commandType: CommandType.StoredProcedure);

                vendor.Id = p.Get<int>("@Id");
            }
        }
    }
}
