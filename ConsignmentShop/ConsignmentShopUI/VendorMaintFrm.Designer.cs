
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
            this.btnAddIVendor = new System.Windows.Forms.Button();
            this.lblPercent = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // headerText
            // 
            this.headerText.AutoSize = true;
            this.headerText.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.lbFirstlName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFirstlName.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lbFirstlName.Location = new System.Drawing.Point(25, 67);
            this.lbFirstlName.Name = "lbFirstlName";
            this.lbFirstlName.Size = new System.Drawing.Size(101, 20);
            this.lbFirstlName.TabIndex = 9;
            this.lbFirstlName.Text = "First Name:";
            // 
            // textBoxFirstName
            // 
            this.textBoxFirstName.Location = new System.Drawing.Point(137, 64);
            this.textBoxFirstName.Name = "textBoxFirstName";
            this.textBoxFirstName.Size = new System.Drawing.Size(272, 26);
            this.textBoxFirstName.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label1.Location = new System.Drawing.Point(25, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 20);
            this.label1.TabIndex = 11;
            this.label1.Text = "Last Name:";
            // 
            // textBoxLastName
            // 
            this.textBoxLastName.Location = new System.Drawing.Point(137, 107);
            this.textBoxLastName.Name = "textBoxLastName";
            this.textBoxLastName.Size = new System.Drawing.Size(272, 26);
            this.textBoxLastName.TabIndex = 10;
            // 
            // lblCommison
            // 
            this.lblCommison.AutoSize = true;
            this.lblCommison.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCommison.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblCommison.Location = new System.Drawing.Point(26, 154);
            this.lblCommison.Name = "lblCommison";
            this.lblCommison.Size = new System.Drawing.Size(97, 20);
            this.lblCommison.TabIndex = 13;
            this.lblCommison.Text = "Commison:";
            // 
            // textBoxCommison
            // 
            this.textBoxCommison.Location = new System.Drawing.Point(138, 151);
            this.textBoxCommison.Name = "textBoxCommison";
            this.textBoxCommison.Size = new System.Drawing.Size(43, 26);
            this.textBoxCommison.TabIndex = 12;
            // 
            // listBoxVendors
            // 
            this.listBoxVendors.FormattingEnabled = true;
            this.listBoxVendors.ItemHeight = 20;
            this.listBoxVendors.Location = new System.Drawing.Point(511, 64);
            this.listBoxVendors.Name = "listBoxVendors";
            this.listBoxVendors.Size = new System.Drawing.Size(267, 164);
            this.listBoxVendors.TabIndex = 14;
            // 
            // btnAddIVendor
            // 
            this.btnAddIVendor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Aquamarine;
            this.btnAddIVendor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddIVendor.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnAddIVendor.Location = new System.Drawing.Point(138, 203);
            this.btnAddIVendor.Name = "btnAddIVendor";
            this.btnAddIVendor.Size = new System.Drawing.Size(168, 48);
            this.btnAddIVendor.TabIndex = 15;
            this.btnAddIVendor.Text = "Add Vendor";
            this.btnAddIVendor.UseVisualStyleBackColor = true;
            this.btnAddIVendor.Click += new System.EventHandler(this.btnAddIVendor_Click);
            // 
            // lblPercent
            // 
            this.lblPercent.AutoSize = true;
            this.lblPercent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPercent.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblPercent.Location = new System.Drawing.Point(187, 154);
            this.lblPercent.Name = "lblPercent";
            this.lblPercent.Size = new System.Drawing.Size(24, 20);
            this.lblPercent.TabIndex = 16;
            this.lblPercent.Text = "%";
            // 
            // VendorMaintFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FloralWhite;
            this.ClientSize = new System.Drawing.Size(790, 302);
            this.Controls.Add(this.lblPercent);
            this.Controls.Add(this.btnAddIVendor);
            this.Controls.Add(this.listBoxVendors);
            this.Controls.Add(this.lblCommison);
            this.Controls.Add(this.textBoxCommison);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxLastName);
            this.Controls.Add(this.lbFirstlName);
            this.Controls.Add(this.textBoxFirstName);
            this.Controls.Add(this.headerText);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "VendorMaintFrm";
            this.Text = "VendorMaintFrm";
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
        private System.Windows.Forms.Button btnAddIVendor;
        private System.Windows.Forms.Label lblPercent;
    }
}