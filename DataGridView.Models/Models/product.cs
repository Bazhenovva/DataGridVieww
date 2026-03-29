using DataGridView.Models.Constants;

namespace DataGridView.Models.Models
{
    /// <summary>
    /// Модель товара для реестра
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Уникальный идентификатор товара
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название товара
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// Размер товара
        /// </summary>
        public ProductSize? ProductSize { get; set; }

        /// <summary>
        /// Материал товара
        /// </summary>
        public Material? Material { get; set; }

        /// <summary>
        /// Цена товара
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Минимальный запас товара
        /// </summary>
        public int MinQuantity { get; set; }

        /// <summary>
        /// Количество товара на складе
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Общая сумма товара (вычисляемое свойство)
        /// </summary>
        public decimal TotalAmount => Quantity * Price;

        /// <summary>
        /// Конструктор с параметрами и валидацией
        /// </summary>
        public Product(string productName, ProductSize? productSize, Material? material, int quantity, int minQuantity, decimal price)
        {
            if (string.IsNullOrWhiteSpace(productName))
            {
                throw new ArgumentException("Введите название товара");
            }

            if (productName.Length < ValidationConstants.ProductNameMinLength ||
                productName.Length > ValidationConstants.ProductNameMaxLength)
            {
                throw new ArgumentException(
                    $"Название должно быть от {ValidationConstants.ProductNameMinLength} до {ValidationConstants.ProductNameMaxLength} символов");
            }

            if (price < ValidationConstants.PriceMin || price > ValidationConstants.PriceMax)
            {
                throw new ArgumentException(
                    $"Цена должна быть от {ValidationConstants.PriceMin} до {ValidationConstants.PriceMax}");
            }

            if (quantity < ValidationConstants.QuantityMin || quantity > ValidationConstants.QuantityMax)
            {
                throw new ArgumentException(
                    $"Количество должно быть от {ValidationConstants.QuantityMin} до {ValidationConstants.QuantityMax}");
            }

            if (minQuantity < ValidationConstants.MinQuantityMin || minQuantity > ValidationConstants.MinQuantityMax)
            {
                throw new ArgumentException(
                    $"Мин. запас должен быть от {ValidationConstants.MinQuantityMin} до {ValidationConstants.MinQuantityMax}");
            }

            ProductName = productName;
            ProductSize = productSize;
            Material = material;
            Quantity = quantity;
            MinQuantity = minQuantity;
            Price = price;
        }

        /// <summary>
        /// Конструктор по умолчанию (для создания нового товара)
        /// </summary>
        public Product()
        {
            ProductName = "";
            ProductSize = ProductSize.M6;
            Material = Material.Steel;
            Quantity = 0;
            MinQuantity = 0;
            Price = 0m;
        }

        /// <summary>
        /// Создание копии товара
        /// </summary>
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
}
