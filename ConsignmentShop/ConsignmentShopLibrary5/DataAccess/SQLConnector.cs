using Dapper;
using System.Collections.Generic;
using System.Data;

namespace ConsignmentShopLibrary.DataAccess
{
    public class SQLConnector : IDataConnection
    {
        public List<Item> LoadItems()
        {
            throw new System.NotImplementedException();
        }

        public List<Vendor> LoadVendors()
        {
            throw new System.NotImplementedException();
        }

        public void SaveItems()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnectionString()))
            {
                var p = new DynamicParameters();

                foreach (var item in GlobalConfig.Store.Items)
                {

                    p.Add("@Name", item.Name);
                    p.Add("@Description", item.Description);
                    p.Add("@Price", item.Price);
                    p.Add("@Sold", item.Sold);
                    p.Add("@Owner", item.Owner.Id);
                    p.Add("@PaymentDistributed", item.PaymentDistrubuted);

                    connection.Execute("dbo.spItemInsert", p, commandType: CommandType.StoredProcedure);

                    item.Id = p.Get<int>("@Id");
                }
            }
        }

        public void SaveVendors()
        {
            throw new System.NotImplementedException();
        }
    }
}
