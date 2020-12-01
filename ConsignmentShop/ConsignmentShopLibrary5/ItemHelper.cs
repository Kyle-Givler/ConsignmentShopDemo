using ConsignmentShopLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsignmentShopLibrary
{
    public static class ItemHelper
    {
        public static List<Item> GetUnsoldItems()
        {
            return GlobalConfig.Store.Items.Where(x => !x.Sold).ToList();
        }

        public static List<Item> GetItemsWhere(Func <Item, bool> predicate)
        {
            return GlobalConfig.Store.Items.Where(predicate).ToList();
        }

        public static List<Item> GetSoldItems()
        {
            return GlobalConfig.Store.Items.Where(x => x.Sold).ToList();
        }
    }
}
