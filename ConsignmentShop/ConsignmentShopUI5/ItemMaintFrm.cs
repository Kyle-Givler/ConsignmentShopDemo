using ConsignmentShopLibrary;
using System.ComponentModel;
using System.Windows.Forms;

namespace ConsignmentShopUI
{
    public partial class ItemMaintFrm : Form
    {
        private readonly BindingList<Item> items = new BindingList<Item>(GlobalConfig.Store.Items);
        private readonly BindingList<Vendor> vendors = new BindingList<Vendor>(GlobalConfig.Store.Vendors);

        private bool editing = false;

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
            if (!validateData())
            {
                return;
            }

            Item newItem = new Item()
            {
                Name = textBoxName.Text,
                Price = decimal.Parse(textBoxPrice.Text),
                Description = textBoxDesc.Text,
                Owner = (Vendor)listBoxVendors.SelectedItem
            };

            GlobalConfig.Store.Items.Add(newItem);
            items.ResetBindings();

            ClearItemInput();

            if(editing)
            {
                btnAddItem.Text = "Add Item";

                btnEdit.Enabled = true;

                editing = false;
            }
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
            textBoxPrice.Text = selectedItem.Price.ToString();

            listBoxVendors.SelectedItem = selectedItem.Owner;
        }
    }
}
