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

using ConsignmentShopLibrary;
using System;
using System.ComponentModel;
using System.Windows.Forms;
using ConsignmentShopLibrary.Models;
using System.Diagnostics;
using System.Linq;

namespace ConsignmentShopUI
{
    public partial class ConsignmentShop : Form
    {
        private readonly BindingList<Item> shoppingCart = new BindingList<Item>();
        private readonly BindingList<Vendor> vendors = new BindingList<Vendor>();
        private readonly BindingList<Item> items = new BindingList<Item>();
        private Store store;

        public ConsignmentShop()
        {
            InitializeComponent();

            SetupStore();

            SetupData();

            UpdateTotal();
        }

        private void SetupStore()
        {
            string storeName = GlobalConfig.Configuration.GetSection("Store:Name").Value;
            store = GlobalConfig.Connection.LoadStore(storeName);
        }

        private void SetupData()
        {
            shoppingCartListBox.DataSource = shoppingCart;
            shoppingCartListBox.DisplayMember = "Display";
            shoppingCartListBox.ValueMember = "Display";

            lblStoreName.Text = store.Name;

            UpdateVendors();
            UpdateItems();
            UpdateBankData();
        }

        private void UpdateBankData()
        {
            storeProfitValue.Text = $"{ store.StoreProfit:C2}";
            lblStoreBankValue.Text = $"{ store.StoreBank:C2}";
        }

        private void UpdateVendors()
        {
            vendors.Clear();

            foreach(Vendor v in GlobalConfig.Connection.LoadAllVendors())
            {
                vendors.Add(v);
            }

            vendorListBox.DataSource = vendors;
            vendorListBox.DisplayMember = "Display";
            vendorListBox.ValueMember = "Display";

            vendors.ResetBindings();
        }

        private void UpdateItems()
        {
            items.Clear();

            foreach(Item itm in GlobalConfig.Connection.LoadUnsoldItems())
            {
                items.Add(itm);
            }

            itemsListbox.DataSource = items;
            itemsListbox.DisplayMember = "Display";
            itemsListbox.ValueMember = "Display";

            items.ResetBindings();
        }

        private void SetupDemoData()
        {
            vendors.Add(new Vendor { FirstName = "Bill", LastName = "Smith" });
            vendors.Add(new Vendor { FirstName = "Sue", LastName = "Jones" });

            items.Add(new Item
            {
                Name = "Moby Dick",
                Description = "A book about a whale",
                Price = 4.50M,
                Owner = vendors[0]
            });

            items.Add(new Item
            {
                Name = "A Tale of Two Cities",
                Description = "A book about a revolution",
                Price = 3.80M,
                Owner = vendors[1]
            });

            items.Add(new Item
            {
                Name = "Harry Potter Book 1",
                Description = "A book about a boy",
                Price = 5.20M,
                Owner = vendors[1]
            });

            items.Add(new Item
            {
                Name = "Jane Eyre",
                Description = "A book about a girl",
                Price = 1.50M,
                Owner = vendors[0]
            });

            vendors.ResetBindings();
            items.ResetBindings();
        }

        private void addToCart_Click(object sender, EventArgs e)
        {
            Item selectedItem = (Item)itemsListbox.SelectedItem;

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

        private void makePurchase_Click(object sender, EventArgs e)
        {
            foreach (Item item in shoppingCart)
            {
                item.Sold = true;
                item.Owner.PaymentDue += (decimal)item.Owner.CommissionRate * item.Price;

                store.StoreProfit += (1 - (decimal)item.Owner.CommissionRate) * item.Price;
                store.StoreBank += item.Price;

                GlobalConfig.Connection.UpdateItem(item);
                GlobalConfig.Connection.UpdateVendor(item.Owner);
                GlobalConfig.Connection.UpdateStore(store);
            }

            shoppingCart.Clear();

            UpdateVendors();
            UpdateItems();
            UpdateBankData();
            UpdateTotal();

            ClearItemLabels();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            Item selectedItem = (Item)shoppingCartListBox.SelectedItem;

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
            Item selectedItem = (Item)itemsListbox.SelectedItem;

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
    }
}
