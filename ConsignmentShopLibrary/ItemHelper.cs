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


using ConsignmentShopLibrary.Data;
using ConsignmentShopLibrary.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsignmentShopLibrary
{
    public static class ItemHelper
    {
        public async static Task PurchaseItems(List<ItemModel> shoppingCart)
        {
            IVendorData vendorData = new VendorData(GlobalConfig.Connection);
            IItemData itemData = new ItemData(GlobalConfig.Connection);
            IStoreData storeData = new StoreData(GlobalConfig.Connection);

            StoreModel store = await storeData.LoadStore(GlobalConfig.GetStoreName());

            foreach (ItemModel item in shoppingCart)
            {
                var PayementDueFromDbList = await GlobalConfig.Connection.QueryRawSQL<decimal>($"select PaymentDue from Vendors where Id = {item.Owner.Id};");
                decimal paymentDueFromDb = PayementDueFromDbList.First();

                item.Owner.PaymentDue += paymentDueFromDb;

                item.Sold = true;
                item.Owner.PaymentDue += (decimal)item.Owner.CommissionRate * item.Price;

                store.StoreProfit += (1 - (decimal)item.Owner.CommissionRate) * item.Price;
                store.StoreBank += item.Price;

                await itemData.UpdateItem(item);
                await vendorData.UpdateVendor(item.Owner);
                await storeData.UpdateStore(store);
            }
        }
    }
}
