/*
MIT License

Copyright(c) 2020 Kyle Givler
https://github.com/JoyfulReaper

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/

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
                items = connection.Query<Item>("dbo.spItemGetAll", CommandType.StoredProcedure).ToList();

                //foreach (var item in items)
                //{
                //    var p = new DynamicParameters();
                //    p.Add("@Id", item.OwnerId);
                //    item.Owner = connection.Query<Vendor>("dbo.spVendorGetById", p, commandType: CommandType.StoredProcedure).First();
                //}

                if(GlobalConfig.Store.Vendors.Count == 0)
                {
                    LoadAllVendors();
                }
                foreach (var item in items)
                {
                    item.Owner = GlobalConfig.Store.Vendors.Where(x => x.Id == item.OwnerId).First();
                }
            }

            return items;
        }

        public void UpdateVendor(Vendor vendor)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnectionString()))
            {
                var p = new DynamicParameters();

                p.Add("@FirstName", vendor.FirstName);
                p.Add("@LastName", vendor.LastName);
                p.Add("@CommisionRate", vendor.CommisonRate);
                p.Add("@PaymentDue", vendor.PaymentDue);
                p.Add("@Id",vendor.Id);

                connection.Execute("dbo.spVendorUpdate", p, commandType: CommandType.StoredProcedure);
            }
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
                p.Add("@OwnerId", item.Owner.Id);
                p.Add("@PaymentDistributed", item.PaymentDistrubuted);
                p.Add("@Id", 0, DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute("dbo.spItemInsert", p, commandType: CommandType.StoredProcedure);

                item.Id = p.Get<int>("@Id");
            }
        }

        public void UpdateItem(Item item)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnectionString()))
            {
                var p = new DynamicParameters();

                p.Add("@Name", item.Name);
                p.Add("@Description", item.Description);
                p.Add("@Price", item.Price);
                p.Add("@Sold", item.Sold);
                p.Add("@OwnerId", item.Owner.Id);
                p.Add("@PaymentDistributed", item.PaymentDistrubuted);
                p.Add("@Id", item.Id);

                connection.Execute("dbo.spItemUpdate", p, commandType: CommandType.StoredProcedure);
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

        public void UpdateStoreBank(decimal storeBank, decimal storeProfit)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnectionString()))
            {
                var p = new DynamicParameters();

                p.Add("@StoreBank", GlobalConfig.Store.StoreBank);
                p.Add(@"StoreProfit", GlobalConfig.Store.StoreProfit);

                connection.Execute("dbo.spUpdateStoreBank", p, commandType: CommandType.StoredProcedure);
            }
        }

        public void LoadStoreBank()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnectionString()))
            {
                var p = new DynamicParameters();

                p.Add("@StoreBank", 0, dbType: DbType.Decimal, direction: ParameterDirection.Output);
                p.Add("@StoreProfit", 0, dbType: DbType.Decimal, direction: ParameterDirection.Output);

                connection.Execute("dbo.spStoreBankGet", p, commandType: CommandType.StoredProcedure);

                GlobalConfig.Store.StoreBank = p.Get<decimal>("@StoreBank");
                GlobalConfig.Store.StoreProfit = p.Get<decimal>("@StoreProfit");
            }
        }

        public void RemoveVendor(Vendor vendor)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnectionString()))
            {
                var p = new DynamicParameters();

                p.Add("@Id", vendor.Id);

                connection.Execute("dbo.spVendorDeleteById", p, commandType: CommandType.StoredProcedure);
            }
        }

        public void RemoveItem(Item item)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnectionString()))
            {
                var p = new DynamicParameters();

                p.Add("@Id", item.Id);

                connection.Execute("dbo.spItemDeleteById", p, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
