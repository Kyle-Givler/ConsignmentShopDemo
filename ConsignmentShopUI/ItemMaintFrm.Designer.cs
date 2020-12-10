
namespace ConsignmentShopUI
{
    partial class ItemMaintFrm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.headerText = new System.Windows.Forms.Label();
            this.btnItemDelete = new System.Windows.Forms.Button();
            this.allItemsListBox = new System.Windows.Forms.ListBox();
            this.lblAllItems = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxDesc = new System.Windows.Forms.TextBox();
            this.textBoxPrice = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblDesc = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.listBoxVendors = new System.Windows.Forms.ListBox();
            this.groupBoxAddItem = new System.Windows.Forms.GroupBox();
            this.checkBoxVendorPaid = new System.Windows.Forms.CheckBox();
            this.checkBoxSold = new System.Windows.Forms.CheckBox();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.groupBoxAllItems = new System.Windows.Forms.GroupBox();
            this.btnDeleteSold = new System.Windows.Forms.Button();
            this.radioButtonSold = new System.Windows.Forms.RadioButton();
            this.radioButtonAll = new System.Windows.Forms.RadioButton();
            this.radioButtonUnsold = new System.Windows.Forms.RadioButton();
            this.groupBoxAddItem.SuspendLayout();
            this.groupBoxAllItems.SuspendLayout();
            this.SuspendLayout();
            // 
            // headerText
            // 
            this.headerText.AutoSize = true;
            this.headerText.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.headerText.ForeColor = System.Drawing.Color.DarkBlue;
            this.headerText.Location = new System.Drawing.Point(18, 14);
            this.headerText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.headerText.Name = "headerText";
            this.headerText.Size = new System.Drawing.Size(285, 37);
            this.headerText.TabIndex = 1;
            this.headerText.Text = "Item Maintenance";
            // 
            // btnItemDelete
            // 
            this.btnItemDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Aquamarine;
            this.btnItemDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnItemDelete.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnItemDelete.Location = new System.Drawing.Point(191, 279);
            this.btnItemDelete.Name = "btnItemDelete";
            this.btnItemDelete.Size = new System.Drawing.Size(155, 48);
            this.btnItemDelete.TabIndex = 4;
            this.btnItemDelete.Text = "Remove Selected";
            this.btnItemDelete.UseVisualStyleBackColor = true;
            this.btnItemDelete.Click += new System.EventHandler(this.btnItemDelete_Click);
            // 
            // allItemsListBox
            // 
            this.allItemsListBox.FormattingEnabled = true;
            this.allItemsListBox.ItemHeight = 20;
            this.allItemsListBox.Location = new System.Drawing.Point(17, 49);
            this.allItemsListBox.Name = "allItemsListBox";
            this.allItemsListBox.Size = new System.Drawing.Size(329, 224);
            this.allItemsListBox.TabIndex = 6;
            // 
            // lblAllItems
            // 
            this.lblAllItems.AutoSize = true;
            this.lblAllItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblAllItems.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblAllItems.Location = new System.Drawing.Point(13, 26);
            this.lblAllItems.Name = "lblAllItems";
            this.lblAllItems.Size = new System.Drawing.Size(79, 20);
            this.lblAllItems.TabIndex = 7;
            this.lblAllItems.Text = "All Items";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(118, 27);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(272, 26);
            this.textBoxName.TabIndex = 0;
            // 
            // textBoxDesc
            // 
            this.textBoxDesc.Location = new System.Drawing.Point(118, 57);
            this.textBoxDesc.Multiline = true;
            this.textBoxDesc.Name = "textBoxDesc";
            this.textBoxDesc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxDesc.Size = new System.Drawing.Size(272, 73);
            this.textBoxDesc.TabIndex = 1;
            // 
            // textBoxPrice
            // 
            this.textBoxPrice.Location = new System.Drawing.Point(118, 146);
            this.textBoxPrice.Name = "textBoxPrice";
            this.textBoxPrice.Size = new System.Drawing.Size(100, 26);
            this.textBoxPrice.TabIndex = 2;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblName.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblName.Location = new System.Drawing.Point(6, 30);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(55, 20);
            this.lblName.TabIndex = 7;
            this.lblName.Text = "Name";
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblDesc.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblDesc.Location = new System.Drawing.Point(6, 60);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(100, 20);
            this.lblDesc.TabIndex = 7;
            this.lblDesc.Text = "Description";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblPrice.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblPrice.Location = new System.Drawing.Point(6, 149);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(49, 20);
            this.lblPrice.TabIndex = 7;
            this.lblPrice.Text = "Price";
            // 
            // listBoxVendors
            // 
            this.listBoxVendors.FormattingEnabled = true;
            this.listBoxVendors.ItemHeight = 20;
            this.listBoxVendors.Location = new System.Drawing.Point(10, 188);
            this.listBoxVendors.Name = "listBoxVendors";
            this.listBoxVendors.Size = new System.Drawing.Size(380, 124);
            this.listBoxVendors.TabIndex = 9;
            // 
            // groupBoxAddItem
            // 
            this.groupBoxAddItem.Controls.Add(this.checkBoxVendorPaid);
            this.groupBoxAddItem.Controls.Add(this.checkBoxSold);
            this.groupBoxAddItem.Controls.Add(this.btnAddItem);
            this.groupBoxAddItem.Controls.Add(this.lblDesc);
            this.groupBoxAddItem.Controls.Add(this.listBoxVendors);
            this.groupBoxAddItem.Controls.Add(this.lblName);
            this.groupBoxAddItem.Controls.Add(this.textBoxPrice);
            this.groupBoxAddItem.Controls.Add(this.lblPrice);
            this.groupBoxAddItem.Controls.Add(this.textBoxDesc);
            this.groupBoxAddItem.Controls.Add(this.textBoxName);
            this.groupBoxAddItem.Location = new System.Drawing.Point(12, 54);
            this.groupBoxAddItem.Name = "groupBoxAddItem";
            this.groupBoxAddItem.Size = new System.Drawing.Size(420, 376);
            this.groupBoxAddItem.TabIndex = 10;
            this.groupBoxAddItem.TabStop = false;
            this.groupBoxAddItem.Text = "New Item";
            // 
            // checkBoxVendorPaid
            // 
            this.checkBoxVendorPaid.AutoSize = true;
            this.checkBoxVendorPaid.Location = new System.Drawing.Point(300, 148);
            this.checkBoxVendorPaid.Name = "checkBoxVendorPaid";
            this.checkBoxVendorPaid.Size = new System.Drawing.Size(115, 24);
            this.checkBoxVendorPaid.TabIndex = 11;
            this.checkBoxVendorPaid.Text = "Vendor Paid";
            this.checkBoxVendorPaid.UseVisualStyleBackColor = true;
            // 
            // checkBoxSold
            // 
            this.checkBoxSold.AutoSize = true;
            this.checkBoxSold.Location = new System.Drawing.Point(234, 148);
            this.checkBoxSold.Name = "checkBoxSold";
            this.checkBoxSold.Size = new System.Drawing.Size(60, 24);
            this.checkBoxSold.TabIndex = 10;
            this.checkBoxSold.Text = "Sold";
            this.checkBoxSold.UseVisualStyleBackColor = true;
            // 
            // btnAddItem
            // 
            this.btnAddItem.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Aquamarine;
            this.btnAddItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddItem.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnAddItem.Location = new System.Drawing.Point(126, 318);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(168, 48);
            this.btnAddItem.TabIndex = 3;
            this.btnAddItem.Text = "Add Item";
            this.btnAddItem.UseVisualStyleBackColor = true;
            this.btnAddItem.Click += new System.EventHandler(this.btmAddItem_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Aquamarine;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnEdit.Location = new System.Drawing.Point(17, 279);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(155, 48);
            this.btnEdit.TabIndex = 11;
            this.btnEdit.Text = "Edit Selected";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // groupBoxAllItems
            // 
            this.groupBoxAllItems.Controls.Add(this.btnDeleteSold);
            this.groupBoxAllItems.Controls.Add(this.radioButtonSold);
            this.groupBoxAllItems.Controls.Add(this.radioButtonAll);
            this.groupBoxAllItems.Controls.Add(this.radioButtonUnsold);
            this.groupBoxAllItems.Controls.Add(this.allItemsListBox);
            this.groupBoxAllItems.Controls.Add(this.btnEdit);
            this.groupBoxAllItems.Controls.Add(this.btnItemDelete);
            this.groupBoxAllItems.Controls.Add(this.lblAllItems);
            this.groupBoxAllItems.Location = new System.Drawing.Point(444, 54);
            this.groupBoxAllItems.Name = "groupBoxAllItems";
            this.groupBoxAllItems.Size = new System.Drawing.Size(368, 376);
            this.groupBoxAllItems.TabIndex = 12;
            this.groupBoxAllItems.TabStop = false;
            this.groupBoxAllItems.Text = "All Items";
            // 
            // btnDeleteSold
            // 
            this.btnDeleteSold.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Aquamarine;
            this.btnDeleteSold.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteSold.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnDeleteSold.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnDeleteSold.Location = new System.Drawing.Point(214, 333);
            this.btnDeleteSold.Name = "btnDeleteSold";
            this.btnDeleteSold.Size = new System.Drawing.Size(132, 37);
            this.btnDeleteSold.TabIndex = 15;
            this.btnDeleteSold.Text = "Delete Sold Items";
            this.btnDeleteSold.UseVisualStyleBackColor = true;
            this.btnDeleteSold.Click += new System.EventHandler(this.btnDeleteSold_Click);
            // 
            // radioButtonSold
            // 
            this.radioButtonSold.AutoSize = true;
            this.radioButtonSold.Location = new System.Drawing.Point(63, 346);
            this.radioButtonSold.Name = "radioButtonSold";
            this.radioButtonSold.Size = new System.Drawing.Size(59, 24);
            this.radioButtonSold.TabIndex = 14;
            this.radioButtonSold.Text = "Sold";
            this.radioButtonSold.UseVisualStyleBackColor = true;
            this.radioButtonSold.CheckedChanged += new System.EventHandler(this.radioButtonOption_CheckedChanged);
            // 
            // radioButtonAll
            // 
            this.radioButtonAll.AutoSize = true;
            this.radioButtonAll.Checked = true;
            this.radioButtonAll.Location = new System.Drawing.Point(13, 346);
            this.radioButtonAll.Name = "radioButtonAll";
            this.radioButtonAll.Size = new System.Drawing.Size(44, 24);
            this.radioButtonAll.TabIndex = 13;
            this.radioButtonAll.TabStop = true;
            this.radioButtonAll.Text = "All";
            this.radioButtonAll.UseVisualStyleBackColor = true;
            this.radioButtonAll.CheckedChanged += new System.EventHandler(this.radioButtonOption_CheckedChanged);
            // 
            // radioButtonUnsold
            // 
            this.radioButtonUnsold.AutoSize = true;
            this.radioButtonUnsold.Location = new System.Drawing.Point(128, 346);
            this.radioButtonUnsold.Name = "radioButtonUnsold";
            this.radioButtonUnsold.Size = new System.Drawing.Size(77, 24);
            this.radioButtonUnsold.TabIndex = 12;
            this.radioButtonUnsold.Text = "Unsold";
            this.radioButtonUnsold.UseVisualStyleBackColor = true;
            this.radioButtonUnsold.CheckedChanged += new System.EventHandler(this.radioButtonOption_CheckedChanged);
            // 
            // ItemMaintFrm
            // 
            this.AcceptButton = this.btnAddItem;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FloralWhite;
            this.ClientSize = new System.Drawing.Size(824, 444);
            this.Controls.Add(this.groupBoxAllItems);
            this.Controls.Add(this.groupBoxAddItem);
            this.Controls.Add(this.headerText);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ItemMaintFrm";
            this.Text = "Item Maintance";
            this.Load += new System.EventHandler(this.ItemMaintFrm_Load);
            this.groupBoxAddItem.ResumeLayout(false);
            this.groupBoxAddItem.PerformLayout();
            this.groupBoxAllItems.ResumeLayout(false);
            this.groupBoxAllItems.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label headerText;
        private System.Windows.Forms.Button btnItemDelete;
        private System.Windows.Forms.ListBox allItemsListBox;
        private System.Windows.Forms.Label lblAllItems;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxDesc;
        private System.Windows.Forms.TextBox textBoxPrice;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.ListBox listBoxVendors;
        private System.Windows.Forms.GroupBox groupBoxAddItem;
        private System.Windows.Forms.Button btnAddItem;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.CheckBox checkBoxSold;
        private System.Windows.Forms.GroupBox groupBoxAllItems;
        private System.Windows.Forms.RadioButton radioButtonSold;
        private System.Windows.Forms.RadioButton radioButtonAll;
        private System.Windows.Forms.RadioButton radioButtonUnsold;
        private System.Windows.Forms.Button btnDeleteSold;
        private System.Windows.Forms.CheckBox checkBoxVendorPaid;
    }
}