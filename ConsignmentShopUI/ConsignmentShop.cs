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

using ConsignmentShopLibrary;
using System;
using System.ComponentModel;
using System.Windows.Forms;
using ConsignmentShopLibrary.Models;
using System.Diagnostics;
using System.Linq;
using ConsignmentShopLibrary.Data;
using System.Threading.Tasks;

namespace ConsignmentShopUI
{
    public partial class ConsignmentShop : Form
    {
        private readonly BindingList<ItemModel> shoppingCart = new BindingList<ItemModel>();
        private readonly BindingList<VendorModel> vendors = new BindingList<VendorModel>();
        private readonly BindingList<ItemModel> items = new BindingList<ItemModel>();

        private StoreModel store;

        // Maybe some DI would be helpful for these, will have to look into it more
        private readonly IStoreData storeData = new StoreData(GlobalConfig.Connection);
        private readonly IVendorData vendorData = new VendorData(GlobalConfig.Connection);
        private readonly IItemData itemData = new ItemData(GlobalConfig.Connection);

        public ConsignmentShop()
        {
            InitializeComponent();
        }

        private async void ConsignmentShop_Load(object sender, EventArgs e)
        {
            await SetupStore();

            await SetupData();

            UpdateTotal();
        }

        private async Task SetupStore()
        {
            string storeName = GlobalConfig.Configuration.GetSection("Store:Name").Value;
            store = await storeData.LoadStore(storeName);
        }

        private async Task SetupData()
        {
            shoppingCartListBox.DataSource = shoppingCart;
            shoppingCartListBox.DisplayMember = "Display";
            shoppingCartListBox.ValueMember = "Display";

            lblStoreName.Text = store.Name;

            await UpdateVendors();
            await UpdateItems();
            UpdateBankData();
        }

        private async Task UpdateBankData()
        {
            store = await storeData.LoadStore(store.Name);

            storeProfitValue.Text = $"{ store.StoreProfit:C2}";
            lblStoreBankValue.Text = $"{ store.StoreBank:C2}";
        }

        private async Task UpdateVendors()
        {
            vendors.Clear();

            var allVendors = await vendorData.LoadAllVendors();

            foreach(VendorModel v in allVendors)
            {
                vendors.Add(v);
            }

            vendorListBox.DataSource = vendors;
            vendorListBox.DisplayMember = "Display";
            vendorListBox.ValueMember = "Display";

            vendors.ResetBindings();
        }

        private async Task UpdateItems()
        {
            items.Clear();

            var unsoldItems = await itemData.LoadUnsoldItems();

            foreach(ItemModel itm in unsoldItems)
            {
                items.Add(itm);
            }

            itemsListbox.DataSource = items;
            itemsListbox.DisplayMember = "Display";
            itemsListbox.ValueMember = "Display";

            items.ResetBindings();
        }

        private void addToCart_Click(object sender, EventArgs e)
        {
            ItemModel selectedItem = (ItemModel)itemsListbox.SelectedItem;

            if(selectedItem == null)
            {
                return;
            }

            items.Remove(selectedItem); // Remove from available items
            shoppingCart.Add(selectedItem); // Add to shopping cart

            itemsListbox_SelectedIndexChanged(this, EventArgs.Empty);

            UpdateTotal();
        }

        private void UpdateTotal()
        {
            decimal total = 0;

            foreach (var item in shoppingCart)
            {
                total += item.Price;
            }

            lblTotal.Text = $"Total: {total:C2}";
        }

        private async void makePurchase_Click(object sender, EventArgs e)
        {
            await ItemHelper.PurchaseItems(shoppingCart.ToList());

            shoppingCart.Clear();

            UpdateVendors();
            UpdateItems();
            UpdateBankData();
            UpdateTotal();

            ClearItemLabels();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            ItemModel selectedItem = (ItemModel)shoppingCartListBox.SelectedItem;

            if(selectedItem == null)
            {
                return;
            }

            items.Add(selectedItem);
            shoppingCart.Remove(selectedItem);

            UpdateTotal();
        }

        private void btnItemMaint_Click(object sender, EventArgs e)
        {
            ItemMaintFrm frm = new ItemMaintFrm();
            frm.ShowDialog();

            UpdateItems();
        }

        private void itemsListbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ItemModel selectedItem = (ItemModel)itemsListbox.SelectedItem;

            if(selectedItem == null)
            {
                ClearItemLabels();
                return;
            }

            lblNameValue.Text = $"{selectedItem.Name}";
            lblDescValue.Text = $"{selectedItem.Description}";
            lblPriceValue.Text = $"{selectedItem.Price:C2}";
            lblVendorValue.Text = $"{selectedItem.Owner.FullName}";
        }

        private void ClearItemLabels()
        {
            lblNameValue.Text = string.Empty;
            lblDescValue.Text = string.Empty;
            lblPriceValue.Text = string.Empty;
            lblVendorValue.Text = string.Empty;
        }

        private void btnVenderMaint_Click(object sender, EventArgs e)
        {
            VendorMaintFrm frm = new VendorMaintFrm(store);
            frm.ShowDialog(this);

            UpdateVendors();
            UpdateBankData();
        }

        private void linkLabelGitHub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://github.com/JoyfulReaper") { UseShellExecute = true });
        }

        private void SetupDemoData()
        {
            vendors.Add(new VendorModel { FirstName = "Bill", LastName = "Smith" });
            vendors.Add(new VendorModel { FirstName = "Sue", LastName = "Jones" });

            items.Add(new ItemModel
            {
                Name = "Moby Dick",
                Description = "A book about a whale",
                Price = 4.50M,
                Owner = vendors[0]
            });

            items.Add(new ItemModel
            {
                Name = "A Tale of Two Cities",
                Description = "A book about a revolution",
                Price = 3.80M,
                Owner = vendors[1]
            });

            items.Add(new ItemModel
            {
                Name = "Harry Potter Book 1",
                Description = "A book about a boy",
                Price = 5.20M,
                Owner = vendors[1]
            });

            items.Add(new ItemModel
            {
                Name = "Jane Eyre",
                Description = "A book about a girl",
                Price = 1.50M,
                Owner = vendors[0]
            });

            vendors.ResetBindings();
            items.ResetBindings();
        }
    }
}
