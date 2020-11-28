using System.ComponentModel;
using System.Windows.Forms;
using ConsignmentShopLibrary;

namespace ConsignmentShopUI
{
    public partial class VendorMaintFrm : Form
    {
        private readonly BindingList<Vendor> vendors = new BindingList<Vendor>(GlobalConfig.Store.Vendors);
        private bool editing = false;

        public VendorMaintFrm()
        {
            InitializeComponent();

            listBoxVendors.DataSource = vendors;
            listBoxVendors.DisplayMember = "FullName";
            listBoxVendors.ValueMember = "FullName";
            vendors.ResetBindings();
        }

        private void btnAddIVendor_Click(object sender, System.EventArgs e)
        {
            if(!ValidateData())
            {
                return;
            }

            Vendor vendor = new Vendor()
            {
                FirstName = textBoxFirstName.Text,
                LastName = textBoxLastName.Text,
                CommisonRate = double.Parse(textBoxCommison.Text) / 100
            };

            GlobalConfig.Store.Vendors.Add(vendor);
            vendors.ResetBindings();

            ClearVendorTextBoxes();

            if (editing)
            {
                btnAddIVendor.Text = "Add Vendor";
                
                btnEdit.Enabled = true;

                editing = false;
            }
        }

        private void ClearVendorTextBoxes()
        {
            textBoxFirstName.Text = string.Empty;
            textBoxLastName.Text = string.Empty;
            textBoxCommison.Text = string.Empty;
        }

        private bool ValidateData()
        {
            string ErrorMessage = string.Empty;
            bool valid = true;
            double commison = 0;

            if(textBoxFirstName.Text == "")
            {
                ErrorMessage += "Please enter a valid first name.\n";
                valid = false;
            }

            if(textBoxLastName.Text == "")
            {
                ErrorMessage += "Please enter a valid last name.\n";
                valid = false;
            }

            if(textBoxCommison.Text == "" || !double.TryParse(textBoxCommison.Text, out commison))
            {
                ErrorMessage += "Please enter a valid commison.\n";
                valid = false;
            }

            if(commison < 0 || commison > 100)
            {
                ErrorMessage += "Commision must be between 0 and 100%\n";
                valid = false;
            }

            if(!valid)
            {
                MessageBox.Show(ErrorMessage, "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return valid;
        }

        private void btnItemDelete_Click(object sender, System.EventArgs e)
        {
            Vendor selectedVendor = (Vendor) listBoxVendors.SelectedItem;

            if(selectedVendor == null)
            {
                return;
            }

            if(selectedVendor.PaymentDue > 0)
            {
                MessageBox.Show($"{selectedVendor.FullName} Cannot be deleted until being payed {selectedVendor.PaymentDue:C2}", 
                    "Vendor must be paid",
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Warning);

                return;
            }

            vendors.Remove(selectedVendor);
        }

        private void btnEdit_Click(object sender, System.EventArgs e)
        {
            editing = true;
            btnEdit.Enabled = false;
            btnAddIVendor.Text = "Update Vendor";

            PopulateVendorTextBoxes();

            vendors.Remove((Vendor)listBoxVendors.SelectedItem);
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
        }
    }
}
