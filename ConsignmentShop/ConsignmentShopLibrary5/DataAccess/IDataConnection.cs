

using System.Collections.Generic;

namespace ConsignmentShopLibrary.DataAccess
{
    public interface IDataConnection
    {
        void SaveVendors(List<Vendor> vendors);

        List<Vendor> LoadVendors();

        void SaveItems(List<Item> items);

        List<Item> LoadItems();

    }
}
