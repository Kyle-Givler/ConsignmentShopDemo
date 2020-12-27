using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConsignmentShopLibrary.DataAccess
{
    public interface IDataAccess
    {
        Task<List<T>> LoadData<T, U>(string storedProcedure, U parameters);

        Task<int> SaveData<T>(string storedProcedure, T parameters);

        Task<List<T>> QueryRawSQL<T, U>(string sql, U parameters);

        Task<int> ExecuteRawSQL<T, U>(string sql, U parameters);
    }
}