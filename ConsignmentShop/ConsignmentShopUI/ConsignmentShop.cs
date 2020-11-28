using ConsignmentShopLibrary;
using System;
using System.ComponentModel;
using System.Windows.Forms;

// TODO Add vendors form
// TODO Add items form
// TODO Save to DB / load from DB
// TODO other moderinzations

namespace ConsignmentShopUI
{
    public partial class ConsignmentShop : Form
    {
        readonly BindingList<Item> shoppingCart = new BindingList<Item>();
        readonly BindingList<Vendor> vendors = new BindingList<Vendor>(GlobalConfig.Store.Vendors);
        readonly BindingList<Item> items = new BindingList<Item>(GlobalConfig.Store.Items);

        private decimal storeProfit = 0;

        public ConsignmentShop()
        {
            InitializeComponent();
            SetupData();

            itemsListbox.DataSource = items;
            itemsListbox.DisplayMember = "Display";
            itemsListbox.ValueMember = "Display";

            shoppingCartListBox.DataSource = shoppingCart;
            shoppingCartListBox.DisplayMember = "Display";
            shoppingCartListBox.ValueMember = "Display";

            vendorListBox.DataSource = vendors;
            vendorListBox.DisplayMember = "Display";
            vendorListBox.ValueMember = "Display";
        }

        private void SetupData()
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

            GlobalConfig.Store.Name = "Seconds are Better";

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

            items.Remove(selectedItem);
            shoppingCart.Add(selectedItem);

            itemsListbox_SelectedIndexChanged(this, EventArgs.Empty);
        }

        private void makePurchase_Click(object sender, EventArgs e)
        {
            foreach (Item item in shoppingCart)
            {
                item.Sold = true;
                item.Owner.PaymenDue += (decimal)item.Owner.CommisonRate * item.Price;
                storeProfit += (1 - (decimal)item.Owner.CommisonRate) * item.Price;
            }

            shoppingCart.Clear();

            vendors.ResetBindings();
            

            storeProfitValue.Text = string.Format("{0:C2}", storeProfit);

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
        }

        private void btnItemMaint_Click(object sender, EventArgs e)
        {
            ItemMaintFrm frm = new ItemMaintFrm();
            frm.ShowDialog();
            items.ResetBindings();
        }

        private void itemsListbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Item selectedItem = (Item)itemsListbox.SelectedItem;

            if(selectedItem == null)
            {
                ClearItemLabels();
            }

            lblNameValue.Text = $"{selectedItem.Name}";
            lblDescValue.Text = $"{selectedItem.Description}";
            lblPriceValue.Text = $"${selectedItem.Price}";
            lblVendorValue.Text = $"{selectedItem.Owner.FullName}";
        }

        private void ClearItemLabels()
        {
            lblNameValue.Text = string.Empty;
            lblDescValue.Text = string.Empty;
            lblPriceValue.Text = string.Empty;
            lblVendorValue.Text = string.Empty;
        }
    }
}
