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
using System.ComponentModel;
using System.Windows.Forms;
using ConsignmentShopLibrary.Models;
using System.Linq;
using System.Collections.Generic;

namespace ConsignmentShopUI
{
    public partial class ItemMaintFrm : Form
    {
        private BindingList<Item> items;
        private readonly BindingList<Vendor> vendors = new BindingList<Vendor>(GlobalConfig.Store.Vendors);

        private bool editing = false;
        private Item editingItem = null;

        public ItemMaintFrm()
        {
            InitializeComponent();

            UpdateItems();

            listBoxVendors.DataSource = vendors;
            listBoxVendors.DisplayMember = "FullName";
            listBoxVendors.ValueMember = "FullName";
        }

        private void UpdateItems()
        {
            if (radioButtonAll.Checked)
            {
                items = new BindingList<Item>(GlobalConfig.Store.Items);
            }
            else if (radioButtonSold.Checked)
            {
                items = new BindingList<Item>(ItemHelper.GetSoldItems());
            }
            else if (radioButtonUnsold.Checked)
            {
                items = new BindingList<Item>(ItemHelper.GetUnsoldItems());
            }

            // Annoying but it causes the listbox to actually update
            // Seems this has to be done if the datasource is replaced by a new object
            allItemsListBox.DataSource = null;

            allItemsListBox.DataSource = items;
            allItemsListBox.DisplayMember = "Display";
            allItemsListBox.ValueMember = "Display";

            items.ResetBindings();
        }

        private void btnItemDelete_Click(object sender, System.EventArgs e)
        {
            Item selectedItem = (Item)allItemsListBox.SelectedItem;

            if(selectedItem == null)
            {
                return;
            }

            GlobalConfig.Store.Items.Remove(selectedItem);
            GlobalConfig.Connection.RemoveItem(selectedItem);

            UpdateItems();
        }

        private void btmAddItem_Click(object sender, System.EventArgs e)
        {
            Item output = null;

            if (!validateData())
            {
                return;
            }

            if(editing)
            {
                editingItem.Name = textBoxName.Text;
                editingItem.Price = decimal.Parse(textBoxPrice.Text);
                editingItem.Description = textBoxDesc.Text;
                editingItem.Owner = (Vendor)listBoxVendors.SelectedItem;
                editingItem.Sold = checkBoxSold.Checked;

                GlobalConfig.Connection.UpdateItem(editingItem);

                btnAddItem.Text = "Add Item";
                btnEdit.Enabled = true;
                editing = false;

                output = editingItem;
            }
            else
            {
                output = new Item()
                {
                    Name = textBoxName.Text,
                    Price = decimal.Parse(textBoxPrice.Text),
                    Description = textBoxDesc.Text,
                    Owner = (Vendor)listBoxVendors.SelectedItem,
                    Sold = checkBoxSold.Checked
                };

                GlobalConfig.Connection.SaveItem(output);
            }

            GlobalConfig.Store.Items.Add(output);
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
            decimal price;

            if ((Vendor)listBoxVendors.SelectedItem == null)
            {
                ErrorMessage += "Please select a valid vendor.\n";
                valid = false;
            }

            if (textBoxName.Text == "")
            {
                valid = false;
                ErrorMessage += "Please enter a valid name.\n";
            }

            if (textBoxDesc.Text == "")
            {
                valid = false;
                ErrorMessage += "Please enter a valid description.\n";
            }

            if (textBoxPrice.Text == "" || !decimal.TryParse(textBoxPrice.Text, out price))
            {
                ErrorMessage += "Please enter a valid price.\n";
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
            Item selectedItem = (Item)allItemsListBox.SelectedItem;
            editingItem = selectedItem;

            if(selectedItem == null)
            {
                return;
            }

            editing = true;

            PopulateItemTextBoxes();
            //items.Remove(selectedItem);
            GlobalConfig.Store.Items.Remove(selectedItem);
            UpdateItems();

            btnAddItem.Text = "Update Item";
            btnEdit.Enabled = false;
        }

        private void PopulateItemTextBoxes()
        {
            Item selectedItem = (Item)allItemsListBox.SelectedItem;

            if(selectedItem == null)
            {
                return;
            }

            textBoxName.Text = selectedItem.Name;
            textBoxDesc.Text = selectedItem.Description;
            textBoxPrice.Text = $"{selectedItem.Price:F2}";

            checkBoxSold.Checked = selectedItem.Sold;
            checkBoxVendorPaid.Checked = selectedItem.PaymentDistrubuted;

            listBoxVendors.SelectedItem = selectedItem.Owner;
            vendors.ResetBindings();
        }

        private void radioButtonOption_CheckedChanged(object sender, System.EventArgs e)
        {
            UpdateItems();
        }

        private void btnDeleteSold_Click(object sender, System.EventArgs e)
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
                var soldItems = ItemHelper.GetSoldItems();

                foreach(var item in soldItems)
                {
                    if(item.PaymentDistrubuted)
                    {
                        GlobalConfig.Connection.RemoveItem(item);
                        GlobalConfig.Store.Items.Remove(item);
                    }
                }

                UpdateItems();
            }
        }
    }
}
