using System.ComponentModel.DataAnnotations;
using DataGridView.Models.Constants;

namespace DataGridView.Models
{
    /// <summary>
    /// Модель товара для реестра с валидацией через DataAnnotations
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Уникальный идентификатор товара
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название товара (от 3 до 100 символов)
        /// </summary>
        [Required(ErrorMessage = "Название товара обязательно")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Название должно быть от 3 до 100 символов")]
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
        /// Цена за единицу товара
        /// </summary>
        [Range(0.01, 999999, ErrorMessage = "Цена должна быть больше 0 и не превышать 999 999")]
        public decimal Price { get; set; }

        /// <summary>
        /// Количество товара на складе
        /// </summary>
        [Range(0, 100, ErrorMessage = "Количество должно быть от 0 до 100")]
        public int Quantity { get; set; }

        /// <summary>
        /// Минимальный запас товара. Без range, ошибка не высветиться любое число больше 100 обрежеться до установленного максимума
        /// </summary>
        public int MinQuantity { get; set; }

        /// <summary>
        /// Общая стоимость товара
        /// </summary>
        public decimal TotalAmount => Quantity * Price;

        /// <summary>
        /// Создает товар с проверкой данных
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
                throw new ArgumentException($"Название должно быть от {ValidationConstants.ProductNameMinLength} до {ValidationConstants.ProductNameMaxLength} символов");
            }

            if (price < ValidationConstants.PriceMin || price > ValidationConstants.PriceMax)
            {
                throw new ArgumentException($"Цена должна быть от {ValidationConstants.PriceMin} до {ValidationConstants.PriceMax}");
            }

            if (quantity < ValidationConstants.QuantityMin || quantity > ValidationConstants.QuantityMax)
            {
                throw new ArgumentException($"Количество должно быть от {ValidationConstants.QuantityMin} до {ValidationConstants.QuantityMax}");
            }

            if (minQuantity < ValidationConstants.MinQuantityMin || minQuantity > ValidationConstants.MinQuantityMax)
            {
                throw new ArgumentException($"Мин. запас должен быть от {ValidationConstants.MinQuantityMin} до {ValidationConstants.MinQuantityMax}");
            }

            ProductName = productName;
            ProductSize = productSize;
            Material = material;
            Quantity = quantity;
            MinQuantity = minQuantity;
            Price = price;
        }

        /// <summary>
        /// Конструктор по умолчанию
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
        /// Создает копию товара
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
