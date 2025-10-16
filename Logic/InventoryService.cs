using System.Text.Json;
using System.Diagnostics;

namespace StoreInventoryManagement.Logic;

/// <summary>
/// Manages the collection of products.
/// This version is adapted for a standard .NET environment like Windows Forms.
/// </summary>
public class InventoryService
{
    private List<Product> _products = new List<Product>();
    private readonly string _filePath;
    private int _nextId = 1;

    public InventoryService()
    {
        // Define a path in the user's AppData folder to store the inventory file.
        string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        string appFolder = Path.Combine(appDataPath, "StoreInventoryManagement");
        Directory.CreateDirectory(appFolder); // Ensure the directory exists.
        _filePath = Path.Combine(appFolder, "inventory.json");

        LoadProducts();
    }

    /// <summary>
    /// Loads the product list from the JSON file.
    /// </summary>
    private void LoadProducts()
    {
        if (!File.Exists(_filePath))
        {
            return;
        }

        try
        {
            string json = File.ReadAllText(_filePath);
            _products = JsonSerializer.Deserialize<List<Product>>(json) ?? new List<Product>();

            if (_products.Any())
            {
                _nextId = _products.Max(p => p.Id) + 1;
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error loading products: {ex.Message}");
            _products = new List<Product>();
        }
    }

    /// <summary>
    /// Saves the current product list to the JSON file.
    /// </summary>
    private void SaveProducts()
    {
        try
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(_products, options);
            File.WriteAllText(_filePath, json);
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error saving products: {ex.Message}");
        }
    }

    /// <summary>
    /// Adds a new product to the inventory.
    /// </summary>
    public Product AddProduct(string name, int quantity, decimal price)
    {
        var product = new Product
        {
            Id = _nextId++,
            Name = name,
            Quantity = quantity,
            Price = price
        };
        _products.Add(product);
        SaveProducts();
        return product;
    }

    /// <summary>
    /// Retrieves the complete list of products.
    /// </summary>
    public List<Product> GetProducts()
    {
        return new List<Product>(_products); // Return a copy
    }

    /// <summary>
    /// Updates an existing product's details.
    /// </summary>
    public bool UpdateProduct(int id, string newName, int newQuantity, decimal newPrice)
    {
        var product = _products.FirstOrDefault(p => p.Id == id);
        if (product != null)
        {
            product.Name = newName;
            product.Quantity = newQuantity;
            product.Price = newPrice;
            SaveProducts();
            return true;
        }
        return false;
    }

    /// <summary>
    /// Deletes a product from the inventory.
    /// </summary>
    public bool DeleteProduct(int id)
    {
        var product = _products.FirstOrDefault(p => p.Id == id);
        if (product != null)
        {
            _products.Remove(product);
            SaveProducts();
            return true;
        }
        return false;
    }
}
