using System.ComponentModel.DataAnnotations;
using DataGridView.Models.Constants;

namespace DataGridView.Models.Models;

public class Product
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Введите название товара")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "Название должно быть от 3 до 100 символов")]
    public string ProductName { get; set; }

    public ProductSize ProductSize { get; set; }

    public Material Material { get; set; }

    [Range(0.01, 999999, ErrorMessage = "Цена должна быть от 0.01 до 999999")]
    public decimal Price { get; set; }

    [Range(0, 1000, ErrorMessage = "Мин. запас должен быть от 0 до 1000")]
    public int MinQuantity { get; set; }

    [Range(0, 100, ErrorMessage = "Количество должно быть от 0 до 100")]
    public int Quantity
    {
        get;
        set => field = Math.Clamp(value, AppConstants.QuantityMin, AppConstants.QuantityMax);
    }

    public decimal TotalAmount => Quantity * Price;

    public Product(string productName, ProductSize productSize, Material material, int quantity, int minQuantity, decimal price)
    {
        ProductName = productName;
        ProductSize = productSize;
        Material = material;
        Quantity = quantity;
        MinQuantity = minQuantity;
        Price = price;
    }

    public Product() : this("", ProductSize.M6, Material.Steel, 0, 0, 0m) { }

    public Product Clone()
    {
        return new Product
        {
            Id = Id,
            ProductName = ProductName,
            ProductSize = ProductSize,
            Material = Material,
            Quantity = Quantity,
            MinQuantity = MinQuantity,
            Price = Price
        };
    }
}
