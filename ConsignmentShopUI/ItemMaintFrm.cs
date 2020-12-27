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
using System.ComponentModel;
using System.Windows.Forms;
using ConsignmentShopLibrary.Models;
using System.Linq;
using ConsignmentShopLibrary.Data;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ConsignmentShopUI
{
    public partial class ItemMaintFrm : Form
    {
        private readonly BindingList<ItemModel> items = new BindingList<ItemModel>();
        private readonly BindingList<VendorModel> vendors = new BindingList<VendorModel>();

        private readonly IVendorData vendorData = new VendorData(GlobalConfig.Connection);
        private readonly IItemData itemData = new ItemData(GlobalConfig.Connection);

        private bool editing = false;
        private ItemModel editingItem = null;

        public ItemMaintFrm()
        {
            InitializeComponent();
        }

        private async void ItemMaintFrm_Load(object sender, System.EventArgs e)
        {
            await UpdateItems();
            await UpdateVendors();
        }

        private async Task UpdateVendors()
        {
            vendors.Clear();

            var allVendors = await vendorData.LoadAllVendors();
            allVendors = allVendors.OrderBy(x => x.LastName).ToList();

            foreach (var vendor in allVendors)
            {
                vendors.Add(vendor);
            }

            listBoxVendors.DataSource = vendors;
            listBoxVendors.DisplayMember = "FullName";
            listBoxVendors.ValueMember = "FullName";
        }

        private async Task UpdateItems()
        {
            items.Clear();
            List<ItemModel> currentItems = new List<ItemModel>();

            if (radioButtonAll.Checked)
            {
                currentItems = await itemData.LoadAllItems();
                currentItems = currentItems.OrderBy(x => x.Name).ToList();

                foreach (var item in currentItems)
                {
                    items.Add(item);
                }
            }
            else if (radioButtonSold.Checked)
            {
                currentItems = await itemData.LoadSoldItems();
                currentItems = currentItems.OrderBy(x => x.Name).ToList();

                foreach (var item in currentItems)
                {
                    items.Add(item);
                }
            }
            else if (radioButtonUnsold.Checked)
            {
                currentItems = await itemData.LoadUnsoldItems();
                currentItems = currentItems.OrderBy(x => x.Name).ToList();

                foreach (var item in currentItems)
                {
                    items.Add(item);
                }
            }

            allItemsListBox.DataSource = items;
            allItemsListBox.DisplayMember = "Display";
            allItemsListBox.ValueMember = "Display";

            items.ResetBindings();
        }

        private void btnItemDelete_Click(object sender, System.EventArgs e)
        {
            ItemModel selectedItem = (ItemModel)allItemsListBox.SelectedItem;

            if(selectedItem == null)
            {
                return;
            }

            if(selectedItem.Sold && !selectedItem.PaymentDistributed)
            {
                MessageBox.Show($"{selectedItem.Owner.FullName} needs to be paid before this item can be deleted.", "Pay the vendor", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                UpdateItems();

                return;
            }

            itemData.RemoveItem(selectedItem);

            UpdateItems();
        }

        private async void btmAddItem_Click(object sender, System.EventArgs e)
        {
            ItemModel output = null;

            if (!validateData())
            {
                return;
            }

            if(editing)
            {
                editingItem.Name = textBoxName.Text;
                editingItem.Price = decimal.Parse(textBoxPrice.Text);
                editingItem.Description = textBoxDesc.Text;
                editingItem.Owner = (VendorModel)listBoxVendors.SelectedItem;
                editingItem.OwnerId = editingItem.Owner.Id;
                editingItem.Sold = checkBoxSold.Checked;
                editingItem.PaymentDistributed = checkBoxVendorPaid.Checked;

                itemData.UpdateItem(editingItem);

                btnAddItem.Text = "Add Item";
                btnEdit.Enabled = true;
                editing = false;

                output = editingItem;
            }
            else
            {
                output = new ItemModel()
                {
                    Name = textBoxName.Text,
                    Price = decimal.Parse(textBoxPrice.Text),
                    Description = textBoxDesc.Text,
                    Owner = (VendorModel)listBoxVendors.SelectedItem,
                    Sold = checkBoxSold.Checked
                };

                await itemData.CreateItem(output);
            }

            UpdateItems();

            ClearItemInput();
        }

        private void ClearItemInput()
        {
            textBoxName.Text = string.Empty;
            textBoxDesc.Text = string.Empty;
            textBoxPrice.Text = string.Empty;

            checkBoxSold.Checked = false;
            listBoxVendors.ClearSelected();
        }

        private bool validateData()
        {
            string ErrorMessage = string.Empty;
            bool valid = true;
            decimal price = 0;

            if ((VendorModel)listBoxVendors.SelectedItem == null)
            {
                ErrorMessage += "Please select a valid vendor.\n";
                valid = false;
            }

            if (textBoxName.Text == "")
            {
                valid = false;
                ErrorMessage += "Please enter a valid name.\n";
            }

            //if (textBoxDesc.Text == "")
            //{
            //    valid = false;
            //    ErrorMessage += "Please enter a valid description.\n";
            //}

            if (textBoxPrice.Text == "" || !decimal.TryParse(textBoxPrice.Text, out price))
            {
                ErrorMessage += "Please enter a valid price.\n";
                valid = false;
            }

            if(price < 0)
            {
                ErrorMessage += "Price must be positive.\n";
                valid = false;
            }

            if(!valid)
            {
                MessageBox.Show(ErrorMessage, "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return valid;
        }

        private void btnEdit_Click(object sender, System.EventArgs e)
        {
            ItemModel selectedItem = (ItemModel)allItemsListBox.SelectedItem;
            editingItem = selectedItem;

            if(selectedItem == null)
            {
                return;
            }

            if (selectedItem.Sold && !selectedItem.PaymentDistributed)
            {
                MessageBox.Show($"{selectedItem.Owner.FullName} needs to be paid before this item can be edited.", "Pay the vendor", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            editing = true;

            PopulateItemTextBoxes();

            UpdateItems();

            btnAddItem.Text = "Update Item";
            btnEdit.Enabled = false;
        }

        private void PopulateItemTextBoxes()
        {
            ItemModel selectedItem = (ItemModel)allItemsListBox.SelectedItem;

            if(selectedItem == null)
            {
                return;
            }

            textBoxName.Text = selectedItem.Name;
            textBoxDesc.Text = selectedItem.Description;
            textBoxPrice.Text = $"{selectedItem.Price:F2}";

            checkBoxSold.Checked = selectedItem.Sold;
            checkBoxVendorPaid.Checked = selectedItem.PaymentDistributed;

            //There has to be a better way of doing this:
            var vendor = vendors.Where(x => x.Id == selectedItem.Owner.Id).First();
            listBoxVendors.SelectedItem = vendor; 

            // The below does not work, I think becasue the object reference is not equal
            //var vendor = selectedItem.Owner;
            //listBoxVendors.SelectedItem = vendor;

            vendors.ResetBindings();
        }

        private async void radioButtonOption_CheckedChanged(object sender, System.EventArgs e)
        {
            // This event fires twice, once on the new button being checked and once on the old button being unchecked
            // We only want to react to the new button being checked

            RadioButton rb = sender as RadioButton;

            if(rb != null)
            {
                if(rb.Checked)
                {
                    await UpdateItems();
                }
            }
        }

        private async void btnDeleteSold_Click(object sender, System.EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to delete all sold items?\n\nOnly items for which the vendor has been paid will be deleted!\n\nThis action cannot be undone!", 
                "Delete All Sold", 
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.No)
            {
                return;
            }
            else
            {
                var soldItems = await itemData.LoadSoldItems();

                foreach(var item in soldItems)
                {
                    if(item.PaymentDistributed)
                    {
                        await itemData.RemoveItem(item);
                    }
                    else
                    {
                        //MessageBox.Show($"Unable to delete {item.Name}. The vendor must be paid!");
                    }
                }

                UpdateItems();
            }
        }

        private void allItemsListBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            UpdateSelectedItemInfo();
        }

        private void UpdateSelectedItemInfo()
        {
            ItemModel item = (ItemModel)allItemsListBox.SelectedItem;

            if (item == null)
            {
                return;
            }

            lblNameValue.Text = item.Name;
            textBoxSelectedDesc.Text = item.Description;
            lblPriceValue.Text = $"{item.Price:C2}";
            lblVendorValue.Text = item.Owner.FullName;

            if(item.Sold)
            {
                lblSoldValue.Text = "True";
            }
            else
            {
                lblSoldValue.Text = "False";
            }

            if (item.PaymentDistributed)
            {
                lblVendorPaidValue.Text = "True";
            }
            else
            {
                lblVendorPaidValue.Text = "False";
            }
        }
    }
}
