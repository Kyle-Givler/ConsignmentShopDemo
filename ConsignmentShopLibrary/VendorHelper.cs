using ConsignmentShopLibrary.Data;
using ConsignmentShopLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsignmentShopLibrary
{
    public static class VendorHelper
    {
        public async static Task PayVendor(VendorModel vendor)
        {
            if (vendor == null)
            {
                throw new ArgumentNullException("vendor", "Vendor cannot be null.");
            }

            IVendorData vendorData = new VendorData(GlobalConfig.Connection);
            IItemData itemData = new ItemData(GlobalConfig.Connection);
            IStoreData storeData = new StoreData(GlobalConfig.Connection);

            string storeName = GlobalConfig.Configuration.GetSection("Store:Name").Value;
            StoreModel store = await storeData.LoadStore(storeName);

            var itemsOwnedByVendor = await itemData.LoadSoldItemsByVendor(vendor);

            foreach (ItemModel item in itemsOwnedByVendor)
            {
                if (!item.PaymentDistributed)
                {
                    decimal amountOwed = (decimal)item.Owner.CommissionRate * item.Price;

                    if (store.StoreBank > amountOwed)
                    {
                        store.StoreBank -= amountOwed;

                        vendor.PaymentDue -= amountOwed;

                        item.PaymentDistributed = true;
                    }
                    else
                    {
                        throw new InvalidOperationException("The store bank does not contain enough money to pay the vendor!");
                    }
                }

                itemData.UpdateItem(item);
                vendorData.UpdateVendor(vendor);
            }

            storeData.UpdateStore(store);
        }
    }
}
