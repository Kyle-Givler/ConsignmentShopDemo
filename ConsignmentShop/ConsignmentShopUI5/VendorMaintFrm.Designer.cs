
namespace ConsignmentShopUI
{
    partial class VendorMaintFrm
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
            this.lbFirstlName = new System.Windows.Forms.Label();
            this.textBoxFirstName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxLastName = new System.Windows.Forms.TextBox();
            this.lblCommison = new System.Windows.Forms.Label();
            this.textBoxCommison = new System.Windows.Forms.TextBox();
            this.listBoxVendors = new System.Windows.Forms.ListBox();
            this.btnAddVendor = new System.Windows.Forms.Button();
            this.lblPercent = new System.Windows.Forms.Label();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnItemDelete = new System.Windows.Forms.Button();
            this.groupBoxVendors = new System.Windows.Forms.GroupBox();
            this.groupBoxVendors.SuspendLayout();
            this.SuspendLayout();
            // 
            // headerText
            // 
            this.headerText.AutoSize = true;
            this.headerText.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.headerText.ForeColor = System.Drawing.Color.DarkBlue;
            this.headerText.Location = new System.Drawing.Point(13, 9);
            this.headerText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.headerText.Name = "headerText";
            this.headerText.Size = new System.Drawing.Size(330, 37);
            this.headerText.TabIndex = 2;
            this.headerText.Text = "Vendor Maintenance";
            // 
            // lbFirstlName
            // 
            this.lbFirstlName.AutoSize = true;
            this.lbFirstlName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbFirstlName.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lbFirstlName.Location = new System.Drawing.Point(6, 52);
            this.lbFirstlName.Name = "lbFirstlName";
            this.lbFirstlName.Size = new System.Drawing.Size(101, 20);
            this.lbFirstlName.TabIndex = 9;
            this.lbFirstlName.Text = "First Name:";
            // 
            // textBoxFirstName
            // 
            this.textBoxFirstName.Location = new System.Drawing.Point(118, 49);
            this.textBoxFirstName.Name = "textBoxFirstName";
            this.textBoxFirstName.Size = new System.Drawing.Size(272, 26);
            this.textBoxFirstName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label1.Location = new System.Drawing.Point(6, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 20);
            this.label1.TabIndex = 11;
            this.label1.Text = "Last Name:";
            // 
            // textBoxLastName
            // 
            this.textBoxLastName.Location = new System.Drawing.Point(118, 92);
            this.textBoxLastName.Name = "textBoxLastName";
            this.textBoxLastName.Size = new System.Drawing.Size(272, 26);
            this.textBoxLastName.TabIndex = 1;
            // 
            // lblCommison
            // 
            this.lblCommison.AutoSize = true;
            this.lblCommison.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCommison.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblCommison.Location = new System.Drawing.Point(7, 139);
            this.lblCommison.Name = "lblCommison";
            this.lblCommison.Size = new System.Drawing.Size(97, 20);
            this.lblCommison.TabIndex = 13;
            this.lblCommison.Text = "Commison:";
            // 
            // textBoxCommison
            // 
            this.textBoxCommison.Location = new System.Drawing.Point(119, 136);
            this.textBoxCommison.Name = "textBoxCommison";
            this.textBoxCommison.Size = new System.Drawing.Size(43, 26);
            this.textBoxCommison.TabIndex = 2;
            // 
            // listBoxVendors
            // 
            this.listBoxVendors.FormattingEnabled = true;
            this.listBoxVendors.ItemHeight = 20;
            this.listBoxVendors.Location = new System.Drawing.Point(449, 60);
            this.listBoxVendors.Name = "listBoxVendors";
            this.listBoxVendors.Size = new System.Drawing.Size(329, 164);
            this.listBoxVendors.TabIndex = 14;
            // 
            // btnAddVendor
            // 
            this.btnAddVendor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Aquamarine;
            this.btnAddVendor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddVendor.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnAddVendor.Location = new System.Drawing.Point(119, 188);
            this.btnAddVendor.Name = "btnAddVendor";
            this.btnAddVendor.Size = new System.Drawing.Size(168, 48);
            this.btnAddVendor.TabIndex = 3;
            this.btnAddVendor.Text = "Add Vendor";
            this.btnAddVendor.UseVisualStyleBackColor = true;
            this.btnAddVendor.Click += new System.EventHandler(this.btnAddVendor_Click);
            // 
            // lblPercent
            // 
            this.lblPercent.AutoSize = true;
            this.lblPercent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblPercent.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblPercent.Location = new System.Drawing.Point(168, 139);
            this.lblPercent.Name = "lblPercent";
            this.lblPercent.Size = new System.Drawing.Size(24, 20);
            this.lblPercent.TabIndex = 16;
            this.lblPercent.Text = "%";
            // 
            // btnEdit
            // 
            this.btnEdit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Aquamarine;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnEdit.Location = new System.Drawing.Point(449, 242);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(155, 48);
            this.btnEdit.TabIndex = 18;
            this.btnEdit.Text = "Edit Selected";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnItemDelete
            // 
            this.btnItemDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Aquamarine;
            this.btnItemDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnItemDelete.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnItemDelete.Location = new System.Drawing.Point(623, 242);
            this.btnItemDelete.Name = "btnItemDelete";
            this.btnItemDelete.Size = new System.Drawing.Size(155, 48);
            this.btnItemDelete.TabIndex = 17;
            this.btnItemDelete.Text = "Remove Selected";
            this.btnItemDelete.UseVisualStyleBackColor = true;
            this.btnItemDelete.Click += new System.EventHandler(this.btnItemDelete_Click);
            // 
            // groupBoxVendors
            // 
            this.groupBoxVendors.Controls.Add(this.lbFirstlName);
            this.groupBoxVendors.Controls.Add(this.textBoxFirstName);
            this.groupBoxVendors.Controls.Add(this.textBoxLastName);
            this.groupBoxVendors.Controls.Add(this.lblPercent);
            this.groupBoxVendors.Controls.Add(this.label1);
            this.groupBoxVendors.Controls.Add(this.btnAddVendor);
            this.groupBoxVendors.Controls.Add(this.textBoxCommison);
            this.groupBoxVendors.Controls.Add(this.lblCommison);
            this.groupBoxVendors.Location = new System.Drawing.Point(12, 49);
            this.groupBoxVendors.Name = "groupBoxVendors";
            this.groupBoxVendors.Size = new System.Drawing.Size(406, 241);
            this.groupBoxVendors.TabIndex = 19;
            this.groupBoxVendors.TabStop = false;
            this.groupBoxVendors.Text = "New Vendor";
            // 
            // VendorMaintFrm
            // 
            this.AcceptButton = this.btnAddVendor;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FloralWhite;
            this.ClientSize = new System.Drawing.Size(790, 302);
            this.Controls.Add(this.groupBoxVendors);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnItemDelete);
            this.Controls.Add(this.listBoxVendors);
            this.Controls.Add(this.headerText);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "VendorMaintFrm";
            this.Text = "VendorMaintFrm";
            this.groupBoxVendors.ResumeLayout(false);
            this.groupBoxVendors.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label headerText;
        private System.Windows.Forms.Label lbFirstlName;
        private System.Windows.Forms.TextBox textBoxFirstName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxLastName;
        private System.Windows.Forms.Label lblCommison;
        private System.Windows.Forms.TextBox textBoxCommison;
        private System.Windows.Forms.ListBox listBoxVendors;
        private System.Windows.Forms.Button btnAddVendor;
        private System.Windows.Forms.Label lblPercent;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnItemDelete;
        private System.Windows.Forms.GroupBox groupBoxVendors;
    }
}