using ConsignmentShopLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;

// This class seems pretty pointless in retrospect, but why not!
// TODO we could have the other methods with the Where() clause just call the GetItemsWhere()

namespace ConsignmentShopLibrary
{
    public static class ItemHelper
    {
        /// <summary>
        /// Get all unsold items
        /// </summary>
        /// <returns>All unsold items</returns>
        public static List<Item> GetUnsoldItems()
        {
            return GlobalConfig.Store.Items.Where(x => !x.Sold).ToList();
        }

        /// <summary>
        /// Get items where predicate is true
        /// </summary>
        /// <param name="predicate">Condition to check</param>
        /// <returns>Items where predicate is true</returns>
        public static List<Item> GetItemsWhere(Func <Item, bool> predicate)
        {
            return GlobalConfig.Store.Items.Where(predicate).ToList();
        }

        /// <summary>
        /// Get all items that have already been sold
        /// </summary>
        /// <returns></returns>
        public static List<Item> GetSoldItems()
        {
            return GlobalConfig.Store.Items.Where(x => x.Sold).ToList();
        }

        /// <summary>
        /// Get All items in the store
        /// </summary>
        /// <returns></returns>
        public static List<Item> GetAllItems()
        {
            return new List<Item>(GlobalConfig.Store.Items);
        }

        /// <summary>
        /// Get all items assigned to a specific vendor
        /// </summary>
        /// <param name="vendor">The vendor to get items owned by them</param>
        /// <returns>Items owned by vendor</returns>
        public static List<Item> GetItemsByVendor(Vendor vendor)
        {
            return GlobalConfig.Store.Items.Where(x => x.Owner == vendor).ToList();
        }

        public static List<Item> GetSoldItemsByVendor(Vendor vendor)
        {
            return GlobalConfig.Store.Items.Where(x => x.Owner == vendor && x.Sold).ToList();
        }
    }
}
