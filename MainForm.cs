using StoreInventoryManagement.Logic;

namespace StoreInventoryManagement;

public partial class MainForm : Form
{
    private readonly InventoryService _inventoryService;
    private Product? _selectedProduct;
    private ListView productsListView = null!;
    private TextBox nameTextBox = null!;
    private TextBox quantityTextBox = null!;
    private TextBox priceTextBox = null!;
    private Button addButton = null!;
    private Button updateButton = null!;
    private Button deleteButton = null!;
    private Button clearButton = null!;

    public MainForm()
    {
        // This call is required by the Windows Form Designer.
        InitializeComponent();

        _inventoryService = new InventoryService();
        LoadProducts();
    }

    private void LoadProducts()
    {
        productsListView.Items.Clear();
        var products = _inventoryService.GetProducts();
        foreach (var product in products)
        {
            var item = new ListViewItem(product.Id.ToString());
            item.SubItems.Add(product.Name);
            item.SubItems.Add(product.Quantity.ToString());
            item.SubItems.Add(product.Price.ToString("C"));
            item.Tag = product; // Store the full product object in the item's Tag
            productsListView.Items.Add(item);
        }
    }

    private void ClearForm()
    {
        nameTextBox.Text = string.Empty;
        quantityTextBox.Text = string.Empty;
        priceTextBox.Text = string.Empty;
        _selectedProduct = null;
        if (productsListView.SelectedItems.Count > 0)
        {
            productsListView.SelectedItems[0].Selected = false;
        }
    }

    // Event Handlers
    private void AddButton_Click(object sender, EventArgs e)
    {
        if (!TryGetProductData(out string name, out int quantity, out decimal price))
        {
            return; // The helper method already showed the error message
        }

        _inventoryService.AddProduct(name, quantity, price);
        LoadProducts();
        ClearForm();
    }

    private void UpdateButton_Click(object sender, EventArgs e)
    {
        if (_selectedProduct == null)
        {
            MessageBox.Show("Please select a product to update.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (!TryGetProductData(out string name, out int quantity, out decimal price))
        {
            return; // The helper method already showed the error message
        }

        _inventoryService.UpdateProduct(_selectedProduct.Id, name, quantity, price);
        LoadProducts();
        ClearForm();
    }

    /// <summary>
    /// Validates and parses the product data from the form's text boxes.
    /// Shows an error message if validation fails.
    /// </summary>
    /// <returns>True if data is valid, otherwise false.</returns>
    private bool TryGetProductData(out string name, out int quantity, out decimal price)
    {
        name = nameTextBox.Text;
        // Initialize out parameters to default values
        quantity = 0;
        price = 0;

        if (string.IsNullOrWhiteSpace(name) ||
            !int.TryParse(quantityTextBox.Text, out quantity) ||
            !decimal.TryParse(priceTextBox.Text, out price))
        {
            MessageBox.Show("Please enter valid data for all fields.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        return true;
    }

    private void DeleteButton_Click(object sender, EventArgs e)
    {
        if (_selectedProduct == null)
        {
            MessageBox.Show("Please select a product to delete.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var confirmResult = MessageBox.Show($"Are you sure you want to delete {_selectedProduct.Name}?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (confirmResult == DialogResult.Yes)
        {
            _inventoryService.DeleteProduct(_selectedProduct.Id);
            LoadProducts();
            ClearForm();
        }
    }

    private void ClearButton_Click(object sender, EventArgs e)
    {
        ClearForm();
    }

    private void ProductsListView_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (productsListView.SelectedItems.Count > 0)
        {
            var selectedItem = productsListView.SelectedItems[0];
            _selectedProduct = selectedItem.Tag as Product;
            if (_selectedProduct != null)
            {
                nameTextBox.Text = _selectedProduct.Name;
                quantityTextBox.Text = _selectedProduct.Quantity.ToString();
                priceTextBox.Text = _selectedProduct.Price.ToString();
            }
        }
        else
        {
            _selectedProduct = null;
        }
    }
}
