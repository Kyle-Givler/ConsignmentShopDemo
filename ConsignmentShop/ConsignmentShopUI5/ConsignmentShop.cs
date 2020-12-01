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
        private readonly BindingList<Vendor> vendors = new BindingList<Vendor>(GlobalConfig.Store.Vendors);
        private BindingList<Item> items;

        public ConsignmentShop()
        {
            InitializeComponent();

            SetupData();

            UpdateTotal();
        }

        private void SetupData()
        {
            shoppingCartListBox.DataSource = shoppingCart;
            shoppingCartListBox.DisplayMember = "Display";
            shoppingCartListBox.ValueMember = "Display";

            lblStoreName.Text = GlobalConfig.Store.Name;

            SetupVendorBindings();
            SetupItemBindings();
            UpdateBankData();
        }

        private void UpdateBankData()
        {
            storeProfitValue.Text = $"{ GlobalConfig.Store.StoreProfit:C2}";
        }

        private void SetupVendorBindings()
        {
            vendorListBox.DataSource = vendors;
            vendorListBox.DisplayMember = "Display";
            vendorListBox.ValueMember = "Display";

            vendors.ResetBindings();
        }

        private void SetupItemBindings()
        {
            items = new BindingList<Item>(ItemHelper.GetUnsoldItems());

            // This seems to be needed when the list changes
            itemsListbox.DataSource = null; 

            itemsListbox.DataSource = items;
            itemsListbox.DisplayMember = "Display";
            itemsListbox.ValueMember = "Display";

            items.ResetBindings();
        }

        private void SetupDemoData()
        {
            GlobalConfig.Store.Vendors.Add(new Vendor { FirstName = "Bill", LastName = "Smith" });
            GlobalConfig.Store.Vendors.Add(new Vendor { FirstName = "Sue", LastName = "Jones" });

            GlobalConfig.Store.Items.Add(new Item
            {
                Name = "Moby Dick",
                Description = "A book about a whale",
                Price = 4.50M,
                Owner = GlobalConfig.Store.Vendors[0]
            });

            GlobalConfig.Store.Items.Add(new Item
            {
                Name = "A Tale of Two Cities",
                Description = "A book about a revolution",
                Price = 3.80M,
                Owner = GlobalConfig.Store.Vendors[1]
            });

            GlobalConfig.Store.Items.Add(new Item
            {
                Name = "Harry Potter Book 1",
                Description = "A book about a boy",
                Price = 5.20M,
                Owner = GlobalConfig.Store.Vendors[1]
            });

            GlobalConfig.Store.Items.Add(new Item
            {
                Name = "Jane Eyre",
                Description = "A book about a girl",
                Price = 1.50M,
                Owner = GlobalConfig.Store.Vendors[0]
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
                item.Owner.PaymentDue += (decimal)item.Owner.CommisonRate * item.Price;

                GlobalConfig.Store.StoreProfit += (1 - (decimal)item.Owner.CommisonRate) * item.Price;

                GlobalConfig.Connection.UpdateItem(item);
                GlobalConfig.Connection.UpdateVendor(item.Owner);
                GlobalConfig.Connection.UpdateStoreBank(GlobalConfig.Store.StoreBank, GlobalConfig.Store.StoreProfit);
            }

            shoppingCart.Clear();
            vendors.ResetBindings();
            UpdateBankData();
            ClearItemLabels();
            UpdateTotal();
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

            SetupItemBindings();
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
            VendorMaintFrm frm = new VendorMaintFrm();
            frm.ShowDialog(this);

            SetupVendorBindings();
        }

        private void linkLabelGitHub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://github.com/JoyfulReaper") { UseShellExecute = true });
        }
    }
}
