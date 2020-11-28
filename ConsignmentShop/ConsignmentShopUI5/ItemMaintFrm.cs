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

namespace ConsignmentShopUI
{
    public partial class ItemMaintFrm : Form
    {
        private readonly BindingList<Item> items = new BindingList<Item>(GlobalConfig.Store.Items);
        private readonly BindingList<Vendor> vendors = new BindingList<Vendor>(GlobalConfig.Store.Vendors);

        private bool editing = false;
        private Item editingItem = null;

        public ItemMaintFrm()
        {
            InitializeComponent();

            allItemsListBox.DataSource = items;
            allItemsListBox.DisplayMember = "Display";
            allItemsListBox.ValueMember = "Display";
            items.ResetBindings();

            listBoxVendors.DataSource = vendors;
            listBoxVendors.DisplayMember = "FullName";
            listBoxVendors.ValueMember = "FullName";
            vendors.ResetBindings();
        }

        private void btnItemDelete_Click(object sender, System.EventArgs e)
        {
            Item selectedItem = (Item)allItemsListBox.SelectedItem;

            if(selectedItem == null)
            {
                return;
            }

            items.Remove(selectedItem);
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

            items.Add(output);
            ClearItemInput();
        }

        private void ClearItemInput()
        {
            textBoxName.Text = string.Empty;
            textBoxDesc.Text = string.Empty;
            textBoxPrice.Text = string.Empty;
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
            items.Remove(selectedItem);

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

            listBoxVendors.SelectedItem = selectedItem.Owner;
            vendors.ResetBindings();
        }
    }
}
