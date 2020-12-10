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


using ConsignmentShopLibrary.Data;
using ConsignmentShopLibrary.Models;
using System;
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
