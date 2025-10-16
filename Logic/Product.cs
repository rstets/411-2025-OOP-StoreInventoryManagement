namespace StoreInventoryManagement.Logic;

/// <summary>
/// Represents a single product in the inventory.
/// </summary>
public class Product
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public required int Quantity { get; set; }
    public required decimal Price { get; set; }
}
