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

using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConsignmentShopLibrary;
using ConsignmentShopLibrary.Data;
using ConsignmentShopLibrary.Models;

namespace ConsignmentShopUI
{
    public partial class VendorMaintFrm : Form
    {
        private readonly BindingList<VendorModel> vendors = new BindingList<VendorModel>();
        private bool editing = false;
        private VendorModel editingVendor = null;

        private readonly IVendorData vendorData = new VendorData(GlobalConfig.Connection);
        private readonly IItemData itemData = new ItemData(GlobalConfig.Connection);

        public VendorMaintFrm(StoreModel store)
        {
            InitializeComponent();

            this.store = store;

            UpdateVendors();
        }

        private async Task UpdateVendors()
        {
            vendors.Clear();

            var allVendors = await vendorData.LoadAllVendors();

            foreach (var v in allVendors)
            {
                vendors.Add(v);
            }

            listBoxVendors.DataSource = vendors;
            listBoxVendors.DisplayMember = "Display";
            listBoxVendors.ValueMember = "Display";

            vendors.ResetBindings();
        }

        private void btnAddVendor_Click(object sender, System.EventArgs e)
        {
            VendorModel output = null;

            if (!ValidateData())
            {
                return;
            }

            if (editing)
            {
                editingVendor.FirstName = textBoxFirstName.Text;
                editingVendor.LastName = textBoxLastName.Text;
                editingVendor.CommissionRate = double.Parse(textBoxCommison.Text) / 100;

                btnAddVendor.Text = "Add Vendor";
                btnEdit.Enabled = true;
                editing = false;

                output = editingVendor;
                vendorData.UpdateVendor(output);
            }
            else
            {
                output = new VendorModel()
                {
                    FirstName = textBoxFirstName.Text,
                    LastName = textBoxLastName.Text,
                    CommissionRate = double.Parse(textBoxCommison.Text) / 100
                };

                vendorData.CreateVendor(output);
            }

            UpdateVendors();

            ClearVendorTextBoxes();
        }

        private void ClearVendorTextBoxes()
        {
            textBoxFirstName.Text = string.Empty;
            textBoxLastName.Text = string.Empty;
            textBoxCommison.Text = string.Empty;
            textboxOwed.Text = string.Empty;
        }

        private bool ValidateData()
        {
            string ErrorMessage = string.Empty;
            bool valid = true;
            double commison = 0;

            if (textBoxFirstName.Text == "")
            {
                ErrorMessage += "Please enter a valid first name.\n";
                valid = false;
            }

            if (textBoxLastName.Text == "")
            {
                ErrorMessage += "Please enter a valid last name.\n";
                valid = false;
            }

            if (textBoxCommison.Text == "" || !double.TryParse(textBoxCommison.Text, out commison))
            {
                ErrorMessage += "Please enter a valid commison.\n";
                valid = false;
            }

            if (commison < 0 || commison > 100)
            {
                ErrorMessage += "Commision must be between 0 and 100%\n";
                valid = false;
            }

            if (!valid)
            {
                MessageBox.Show(ErrorMessage, "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return valid;
        }

        private async void btnItemDelete_Click(object sender, System.EventArgs e)
        {
            //TODO extract this method to the Library
            VendorModel selectedVendor = (VendorModel)listBoxVendors.SelectedItem;

            if (selectedVendor == null)
            {
                return;
            }

            var items = await itemData.LoadItemsByVendor(selectedVendor);

            if (items.Count != 0)
            {
                MessageBox.Show($"{selectedVendor.FullName} cannot be deleted because they still have existing items.",
            "Vendor still has items",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            // Can't delete a vendor if we owe them money!
            if (selectedVendor.PaymentDue > 0)
            {
                MessageBox.Show($"{selectedVendor.FullName} cannot be deleted until being payed {selectedVendor.PaymentDue:C2}",
                    "Vendor must be paid",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            // Gonna delete them from the DB!
            var result = MessageBox.Show($"Delete vendor: {selectedVendor.FullName}?\nThis action cannot be undone!",
                "Delete Vendor?",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result != DialogResult.Yes)
            {
                return;
            }

            vendorData.RemoveVendor(selectedVendor);
            UpdateVendors();
        }

        private void PopulateVendorTextBoxes()
        {
            VendorModel selectedVendor = (VendorModel)listBoxVendors.SelectedItem;

            if (selectedVendor == null)
            {
                return;
            }

            textBoxFirstName.Text = selectedVendor.FirstName;
            textBoxLastName.Text = selectedVendor.LastName;
            textBoxCommison.Text = (selectedVendor.CommissionRate * 100).ToString();
            textboxOwed.Text = $"{selectedVendor.PaymentDue:C2}";
        }

        private async void btnPayVendor_Click(object sender, System.EventArgs e)
        {
            VendorModel selectedVendor = (VendorModel)listBoxVendors.SelectedItem;

            if (selectedVendor == null)
            {
                return;
            }

            try
            {
                await VendorHelper.PayVendor(selectedVendor);
            } 
            catch (InvalidOperationException)
            {
                MessageBox.Show("You can't afford to pay the vendor", "You have no money", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            UpdateVendors();
        }

        private void btnEdit_Click(object sender, System.EventArgs e)
        {
            VendorModel selectedVendor = (VendorModel)listBoxVendors.SelectedItem;
            editingVendor = selectedVendor;

            if (selectedVendor == null)
            {
                return;
            }

            editing = true;

            PopulateVendorTextBoxes();

            UpdateVendors();

            btnAddVendor.Text = "Update Vendor";
            btnEdit.Enabled = false;
        }
    }
}
