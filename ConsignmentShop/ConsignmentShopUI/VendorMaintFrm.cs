using System.ComponentModel;
using System.Windows.Forms;
using ConsignmentShopLibrary;

namespace ConsignmentShopUI
{
    public partial class VendorMaintFrm : Form
    {
        private readonly BindingList<Vendor> vendors = new BindingList<Vendor>(GlobalConfig.Store.Vendors);

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

            ClearVendorTextBoxes();

            GlobalConfig.Store.Vendors.Add(vendor);
            vendors.ResetBindings();
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
    }
}
