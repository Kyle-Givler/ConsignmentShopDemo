using ConsignmentShopLibrary.Models;
using System.Collections.Generic;

namespace ConsignmentShopLibrary.DataAccess
{
    public interface IDataConnection
    {
        void SaveVendor(Vendor vendor);

        List<Vendor> LoadAllVendors();

        void SaveItem(Item item);

        List<Item> LoadAllItems();

    }
}
