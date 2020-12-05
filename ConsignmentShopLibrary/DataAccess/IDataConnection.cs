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

using ConsignmentShopLibrary.Models;
using System.Collections.Generic;

namespace ConsignmentShopLibrary.DataAccess
{
    public interface IDataConnection
    {
        /// <summary>
        /// Update the amount of money in the storeBank and the total gross profit
        /// </summary>
        /// <param name="storeBank">Amount of money to set the store bank to</param>
        /// <param name="storeProfit">Amount to set the total gross profit to</param>
        void UpdateStoreBank(Store store);

        /// <summary>
        /// Load the gross profit and store bank amounts
        /// </summary>
        void LoadStoreBank(Store store);



        /// <summary>
        /// Save vendor to DB
        /// </summary>
        /// <param name="vendor">The vendor to save</param>
        void SaveVendor(Vendor vendor);

        /// <summary>
        /// Update an exiting vendor
        /// </summary>
        /// <param name="vendor">The vendor to update</param>
        void UpdateVendor(Vendor vendor);

        /// <summary>
        /// Retreive a list of all vendors
        /// </summary>
        /// <returns>List of all vendors</returns>
        List<Vendor> LoadAllVendors();

        /// <summary>
        /// Delete a vendor from the Database
        /// </summary>
        /// <param name="vendor">The vendor to delete</param>
        void RemoveVendor(Vendor vendor);



        /// <summary>
        /// Save an item to the database
        /// </summary>
        /// <param name="item">The item to save</param>
        void SaveItem(Item item);

        /// <summary>
        /// Update an existing Item
        /// </summary>
        /// <param name="item">The Item to update</param>
        void UpdateItem(Item item);

        /// <summary>
        /// Load all items from the Database
        /// </summary>
        /// <returns>A list of all items</returns>
        List<Item> LoadAllItems();

        List<Item> LoadUnsoldItems();

        List<Item> LoadSoldItems();

        List<Item> LoadSoldItemsByVendor(Vendor vendor);

        /// <summary>
        /// Delete an item from the database
        /// </summary>
        /// <param name="item"></param>
        void RemoveItem(Item item);

    }
}
