
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
            this.label3 = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.listBoxVendors = new System.Windows.Forms.ListBox();
            this.groupBoxAddItem = new System.Windows.Forms.GroupBox();
            this.btmAddItem = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.groupBoxAddItem.SuspendLayout();
            this.SuspendLayout();
            // 
            // headerText
            // 
            this.headerText.AutoSize = true;
            this.headerText.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.btnItemDelete.Location = new System.Drawing.Point(650, 367);
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
            this.allItemsListBox.Location = new System.Drawing.Point(476, 137);
            this.allItemsListBox.Name = "allItemsListBox";
            this.allItemsListBox.Size = new System.Drawing.Size(329, 224);
            this.allItemsListBox.TabIndex = 6;
            // 
            // lblAllItems
            // 
            this.lblAllItems.AutoSize = true;
            this.lblAllItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAllItems.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblAllItems.Location = new System.Drawing.Point(472, 114);
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
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.lblDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDesc.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblDesc.Location = new System.Drawing.Point(6, 60);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(100, 20);
            this.lblDesc.TabIndex = 7;
            this.lblDesc.Text = "Description";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label3.Location = new System.Drawing.Point(-527, 163);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Shopping Cart";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrice.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblPrice.Location = new System.Drawing.Point(6, 149);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(49, 20);
            this.lblPrice.TabIndex = 7;
            this.lblPrice.Text = "Price";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label5.Location = new System.Drawing.Point(-519, 247);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(124, 20);
            this.label5.TabIndex = 7;
            this.label5.Text = "Shopping Cart";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label6.Location = new System.Drawing.Point(-1057, 283);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(124, 20);
            this.label6.TabIndex = 7;
            this.label6.Text = "Shopping Cart";
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
            this.groupBoxAddItem.Controls.Add(this.btmAddItem);
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
            // btmAddItem
            // 
            this.btmAddItem.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Aquamarine;
            this.btmAddItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btmAddItem.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btmAddItem.Location = new System.Drawing.Point(126, 318);
            this.btmAddItem.Name = "btmAddItem";
            this.btmAddItem.Size = new System.Drawing.Size(168, 48);
            this.btmAddItem.TabIndex = 3;
            this.btmAddItem.Text = "Add Item";
            this.btmAddItem.UseVisualStyleBackColor = true;
            this.btmAddItem.Click += new System.EventHandler(this.btmAddItem_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Aquamarine;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnEdit.Location = new System.Drawing.Point(476, 367);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(155, 48);
            this.btnEdit.TabIndex = 11;
            this.btnEdit.Text = "Edit Selected";
            this.btnEdit.UseVisualStyleBackColor = true;
            // 
            // ItemMaintFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FloralWhite;
            this.ClientSize = new System.Drawing.Size(824, 444);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.groupBoxAddItem);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblAllItems);
            this.Controls.Add(this.allItemsListBox);
            this.Controls.Add(this.btnItemDelete);
            this.Controls.Add(this.headerText);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ItemMaintFrm";
            this.Text = "Item Maintance";
            this.groupBoxAddItem.ResumeLayout(false);
            this.groupBoxAddItem.PerformLayout();
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
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox listBoxVendors;
        private System.Windows.Forms.GroupBox groupBoxAddItem;
        private System.Windows.Forms.Button btmAddItem;
        private System.Windows.Forms.Button btnEdit;
    }
}