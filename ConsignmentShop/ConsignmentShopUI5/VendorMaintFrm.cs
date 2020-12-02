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

using System.ComponentModel;
using System.Windows.Forms;
using ConsignmentShopLibrary;
using ConsignmentShopLibrary.Models;

namespace ConsignmentShopUI
{
    public partial class VendorMaintFrm : Form
    {
        private readonly BindingList<Vendor> vendors = new BindingList<Vendor>(GlobalConfig.Store.Vendors);
        private bool editing = false;
        private Vendor editingVendor = null;

        public VendorMaintFrm()
        {
            InitializeComponent();

            listBoxVendors.DataSource = vendors;
            listBoxVendors.DisplayMember = "Display";
            listBoxVendors.ValueMember = "Display";
            vendors.ResetBindings();
        }

        private void btnAddVendor_Click(object sender, System.EventArgs e)
        {
            Vendor output = null;

            if (!ValidateData())
            {
                return;
            }

            if (editing)
            {
                editingVendor.FirstName = textBoxFirstName.Text;
                editingVendor.LastName = textBoxLastName.Text;
                editingVendor.CommisonRate = double.Parse(textBoxCommison.Text) / 100;

                GlobalConfig.Connection.UpdateVendor(editingVendor);

                btnAddVendor.Text = "Add Vendor";
                btnEdit.Enabled = true;
                editing = false;

                output = editingVendor;
            }
            else
            {
                output = new Vendor()
                {
                    FirstName = textBoxFirstName.Text,
                    LastName = textBoxLastName.Text,
                    CommisonRate = double.Parse(textBoxCommison.Text) / 100
                };

                GlobalConfig.Connection.SaveVendor(output);
            }


            vendors.Add(output);
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

        private void btnItemDelete_Click(object sender, System.EventArgs e)
        {
            Vendor selectedVendor = (Vendor)listBoxVendors.SelectedItem;

            if (selectedVendor == null)
            {
                return;
            }

            if (selectedVendor.PaymentDue > 0)
            {
                MessageBox.Show($"{selectedVendor.FullName} cannot be deleted until being payed {selectedVendor.PaymentDue:C2}",
                    "Vendor must be paid",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }



            var result = MessageBox.Show($"Delete vendor: {selectedVendor.FullName}?\nThis action cannot be undone!",
                "Delete Vendor?",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result != DialogResult.Yes)
            {
                return;
            }

            vendors.Remove(selectedVendor);
            GlobalConfig.Connection.RemoveVendor(selectedVendor);
        }

        private void btnEdit_Click(object sender, System.EventArgs e)
        {
            Vendor selectedVendor = (Vendor)listBoxVendors.SelectedItem;
            editingVendor = selectedVendor;

            if (editingVendor == null)
            {
                return;
            }

            editing = true;

            PopulateVendorTextBoxes();
            vendors.Remove(selectedVendor);

            btnAddVendor.Text = "Update Vendor";
            btnEdit.Enabled = false;
        }

        private void PopulateVendorTextBoxes()
        {
            Vendor selectedVendor = (Vendor)listBoxVendors.SelectedItem;

            if (selectedVendor == null)
            {
                return;
            }

            textBoxFirstName.Text = selectedVendor.FirstName;
            textBoxLastName.Text = selectedVendor.LastName;
            textBoxCommison.Text = (selectedVendor.CommisonRate * 100).ToString();
            textboxOwed.Text = $"{selectedVendor.PaymentDue:C2}";
        }
    }
}
