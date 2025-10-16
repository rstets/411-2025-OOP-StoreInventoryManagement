namespace StoreInventoryManagement;

partial class MainForm
{
    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        this.productsListView = new System.Windows.Forms.ListView();
        this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
        this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
        this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
        this.columnHeader4 = new System.Windows.Forms.ColumnHeader();

        this.nameTextBox = new System.Windows.Forms.TextBox();
        this.quantityTextBox = new System.Windows.Forms.TextBox();
        this.priceTextBox = new System.Windows.Forms.TextBox();

        this.addButton = new System.Windows.Forms.Button();
        this.updateButton = new System.Windows.Forms.Button();
        this.deleteButton = new System.Windows.Forms.Button();
        this.clearButton = new System.Windows.Forms.Button();

        var nameLabel = new System.Windows.Forms.Label();
        var quantityLabel = new System.Windows.Forms.Label();
        var priceLabel = new System.Windows.Forms.Label();
        var productListLabel = new System.Windows.Forms.Label();
        var detailsGroupBox = new System.Windows.Forms.GroupBox();

        detailsGroupBox.SuspendLayout();
        this.SuspendLayout();

        // Product List Label
        productListLabel.AutoSize = true;
        productListLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
        productListLabel.Location = new System.Drawing.Point(12, 9);
        productListLabel.Name = "productListLabel";
        productListLabel.Size = new System.Drawing.Size(104, 21);
        productListLabel.Text = "Product List";

        // productsListView
        this.productsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
                this.columnHeader1, this.columnHeader2, this.columnHeader3, this.columnHeader4 });
        this.productsListView.FullRowSelect = true;
        this.productsListView.HideSelection = false;
        this.productsListView.Location = new System.Drawing.Point(20, 40);
        this.productsListView.Name = "productsListView";
        this.productsListView.Size = new System.Drawing.Size(760, 300);
        this.productsListView.TabIndex = 0;
        this.productsListView.UseCompatibleStateImageBehavior = false;
        this.productsListView.View = System.Windows.Forms.View.Details;
        this.productsListView.SelectedIndexChanged += new System.EventHandler(this.ProductsListView_SelectedIndexChanged);

        this.columnHeader1.Text = "ID";
        this.columnHeader1.Width = 40;
        this.columnHeader2.Text = "Name";
        this.columnHeader2.Width = 220;
        this.columnHeader3.Text = "Quantity";
        this.columnHeader3.Width = 80;
        this.columnHeader4.Text = "Price";
        this.columnHeader4.Width = 100;

        // Details GroupBox
        detailsGroupBox.Controls.Add(nameLabel);
        detailsGroupBox.Controls.Add(this.nameTextBox);
        detailsGroupBox.Controls.Add(quantityLabel);
        detailsGroupBox.Controls.Add(this.quantityTextBox);
        detailsGroupBox.Controls.Add(priceLabel);
        detailsGroupBox.Controls.Add(this.priceTextBox);
        detailsGroupBox.Controls.Add(this.addButton);
        detailsGroupBox.Controls.Add(this.updateButton);
        detailsGroupBox.Controls.Add(this.deleteButton);
        detailsGroupBox.Controls.Add(this.clearButton);
        detailsGroupBox.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        detailsGroupBox.Location = new System.Drawing.Point(20, 360);
        detailsGroupBox.Name = "detailsGroupBox";
        detailsGroupBox.Size = new System.Drawing.Size(760, 300);
        detailsGroupBox.TabIndex = 1;
        detailsGroupBox.TabStop = false;
        detailsGroupBox.Text = "Product Details";

        // Labels
        nameLabel.Location = new System.Drawing.Point(20, 30); nameLabel.Text = "Name:";
        quantityLabel.Location = new System.Drawing.Point(20, 60); quantityLabel.Text = "Quantity:";
        priceLabel.Location = new System.Drawing.Point(20, 90); priceLabel.Text = "Price:";

        // TextBoxes
        this.nameTextBox.Location = new System.Drawing.Point(120, 30); this.nameTextBox.Size = new System.Drawing.Size(360, 30);
        this.quantityTextBox.Location = new System.Drawing.Point(120, 60); this.quantityTextBox.Size = new System.Drawing.Size(150, 30);
        this.priceTextBox.Location = new System.Drawing.Point(120, 90); this.priceTextBox.Size = new System.Drawing.Size(150, 30);

        // Buttons
        this.addButton.Location = new System.Drawing.Point(20, 150); this.addButton.Size = new System.Drawing.Size(85, 40); this.addButton.Text = "Add"; this.addButton.Click += new System.EventHandler(this.AddButton_Click);
        this.updateButton.Location = new System.Drawing.Point(120, 150); this.updateButton.Size = new System.Drawing.Size(85, 40); this.updateButton.Text = "Update"; this.updateButton.Click += new System.EventHandler(this.UpdateButton_Click);
        this.deleteButton.Location = new System.Drawing.Point(220, 150); this.deleteButton.Size = new System.Drawing.Size(85, 40); this.deleteButton.Text = "Delete"; this.deleteButton.BackColor = Color.Salmon; this.deleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
        this.clearButton.Location = new System.Drawing.Point(320, 150); this.clearButton.Size = new System.Drawing.Size(85, 40); this.clearButton.Text = "Clear"; this.clearButton.Click += new System.EventHandler(this.ClearButton_Click);

        // MainForm
        this.ClientSize = new System.Drawing.Size(800, 600);
        this.Controls.Add(detailsGroupBox);
        this.Controls.Add(this.productsListView);
        this.Controls.Add(productListLabel);
        this.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        this.MaximizeBox = false;
        this.Name = "MainForm";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "Inventory Management System";
        detailsGroupBox.ResumeLayout(false);
        detailsGroupBox.PerformLayout();
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    private System.Windows.Forms.ColumnHeader columnHeader1;
    private System.Windows.Forms.ColumnHeader columnHeader2;
    private System.Windows.Forms.ColumnHeader columnHeader3;
    private System.Windows.Forms.ColumnHeader columnHeader4;
}
