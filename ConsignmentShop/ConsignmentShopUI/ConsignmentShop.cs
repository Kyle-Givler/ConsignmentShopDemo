using ConsignmentShopLibrary;
using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

// TODO Add vendors form
// TODO Add items form
// TODO Save to DB / load from DB
// TODO other moderinzations

namespace ConsignmentShopUI
{
    public partial class ConsignmentShop : Form
    {
        private readonly Store store = new Store();

        readonly BindingList<Item> shoppingCart = new BindingList<Item>();
        BindingList<Vendor> vendors;
        readonly BindingList<Item> items = new BindingList<Item>();

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
            store.Vendors.Add(new Vendor { FirstName = "Bill", LastName = "Smith" });
            store.Vendors.Add(new Vendor { FirstName = "Sue", LastName = "Jones" });

            store.Items.Add(new Item
            {
                Title = "Moby Dick",
                Description = "A book about a whale",
                Price = 4.50M,
                Owner = store.Vendors[0]
            });

            store.Items.Add(new Item
            {
                Title = "A Tale of Two Cities",
                Description = "A book about a revolution",
                Price = 3.80M,
                Owner = store.Vendors[1]
            });

            store.Items.Add(new Item
            {
                Title = "Harry Potter Book1",
                Description = "A book about a boy",
                Price = 5.20M,
                Owner = store.Vendors[1]
            });

            store.Items.Add(new Item
            {
                Title = "Jane Eyre",
                Description = "A book about a girl",
                Price = 1.50M,
                Owner = store.Vendors[0]
            });

            store.Name = "Seconds are Better";

            vendors = new BindingList<Vendor>(store.Vendors);
            vendors.ResetBindings();

            foreach (Item i in store.Items.Where(x => x.Sold == false))
            {
                items.Add(i);
            }
        }

        private void addToCart_Click(object sender, EventArgs e)
        {
            // Figure out what is selected in the items list
            // Copy that item to the shopping cart
            // Do we remove the items from the items list? - no
            Item selectedItem = (Item)itemsListbox.SelectedItem;

            items.Remove(selectedItem);
            shoppingCart.Add(selectedItem);
        }

        private void makePurchase_Click(object sender, EventArgs e)
        {
            // Mark each item in the cart as sold
            // Clear the cart

            foreach (Item item in shoppingCart)
            {
                item.Sold = true;
                item.Owner.PaymenDue += (decimal)item.Owner.CommisonRate * item.Price;
                storeProfit += (1 - (decimal)item.Owner.CommisonRate) * item.Price;
            }

            shoppingCart.Clear();
            vendors.ResetBindings();
            storeProfitValue.Text = string.Format("{0:C2}", storeProfit);
        }
    }
}
