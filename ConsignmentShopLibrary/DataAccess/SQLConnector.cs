﻿/*
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
            List<Item> allItems;

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnectionString()))
            {
                allItems = connection.Query<Item>("dbo.spItemGetAll", CommandType.StoredProcedure).ToList();

                foreach (var item in allItems)
                {
                    var p = new DynamicParameters();
                    p.Add("@Id", item.OwnerId);

                    var owner = connection.Query<Vendor>("dbo.spVendorGetById", p, commandType: CommandType.StoredProcedure).First();
                    item.Owner = owner;
                }
            }

            return allItems;
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
                p.Add("@Id", vendor.Id);

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
                p.Add("@PaymentDistributed", item.PaymentDistributed);
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
                p.Add("@PaymentDistributed", item.PaymentDistributed);
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

        public void UpdateStoreBank(Store store)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnectionString()))
            {
                var p = new DynamicParameters();

                p.Add("@StoreBank", store.StoreBank);
                p.Add(@"StoreProfit", store.StoreProfit);

                connection.Execute("dbo.spStoreBankUpdate", p, commandType: CommandType.StoredProcedure);
            }
        }

        public void LoadStoreBank(Store store)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnectionString()))
            {
                var p = new DynamicParameters();

                p.Add("@StoreBank", 0, dbType: DbType.Decimal, direction: ParameterDirection.Output);
                p.Add("@StoreProfit", 0, dbType: DbType.Decimal, direction: ParameterDirection.Output);

                connection.Execute("dbo.spStoreBankGet", p, commandType: CommandType.StoredProcedure);

                store.StoreBank = p.Get<decimal>("@StoreBank");
                store.StoreProfit = p.Get<decimal>("@StoreProfit");
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

        public List<Item> LoadUnsoldItems()
        {
            List<Item> unsoldItems;

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnectionString()))
            {
                unsoldItems = connection.Query<Item>("dbo.spItemGetUnsold", CommandType.StoredProcedure).ToList();

                foreach (var item in unsoldItems)
                {
                    var p = new DynamicParameters();
                    p.Add("@Id", item.OwnerId);

                    var owner = connection.Query<Vendor>("dbo.spVendorGetById", p, commandType: CommandType.StoredProcedure).First();
                    item.Owner = owner;
                }
            }

            return unsoldItems;
        }

        public List<Item> LoadSoldItems()
        {
            List<Item> soldItems;

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnectionString()))
            {
                soldItems = connection.Query<Item>("dbo.spItemGetSold", CommandType.StoredProcedure).ToList();

                foreach (var item in soldItems)
                {
                    var p = new DynamicParameters();
                    p.Add("@Id", item.OwnerId);

                    var owner = connection.Query<Vendor>("dbo.spVendorGetById", p, commandType: CommandType.StoredProcedure).First();
                    item.Owner = owner;
                }
            }

            return soldItems;
        }

        public List<Item> LoadSoldItemsByVendor(Vendor vendor)
        {
            List<Item> items;

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnectionString()))
            {
                var p = new DynamicParameters();
                p.Add("@OwnerId", vendor.Id);

                items = connection.Query<Item>("dbo.spItemGetSoldByVendor", p, commandType: CommandType.StoredProcedure).ToList();

                foreach (var item in items)
                {
                    item.Owner = vendor;
                }
            }

            return items;
        }
    }
}
