using System.ComponentModel.DataAnnotations;
using DataGridView.Models.Constants;

namespace DataGridView.Models
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
        [Required(ErrorMessage = "Название товара обязательно")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Название должно быть от 2 до 100 символов")]
        public string ProductName { get; set; }

        /// <summary>
        /// Размер товара
        /// </summary>
        [Required(ErrorMessage = "Размер товара обязателен")]
        public ProductSize? ProductSize { get; set; }

        /// <summary>
        /// Материал товара
        /// </summary>
        [Required(ErrorMessage = "Материал товара обязателен")]
        public Material? Material { get; set; }

        /// <summary>
        /// Цена товара
        /// </summary>
        // ИСПРАВЛЕНО: используем double литералы вместо строк, чтобы избежать ошибки парсинга культуры
        [Range(0.01, 1000000.0, ErrorMessage = "Цена должна быть больше 0 и не превышать 1 000 000")]
        public decimal Price { get; set; }

        /// <summary>
        /// Минимальный запас товара
        /// </summary>
        [Range(0, int.MaxValue, ErrorMessage = "Мин. запас не может быть отрицательным")]
        public int MinQuantity { get; set; }

        /// <summary>
        /// Количество товара на складе
        /// </summary>
        [Range(0, int.MaxValue, ErrorMessage = "Количество не может быть отрицательным")]
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

            if (productName.Length < 2 || productName.Length > 100)
            {
                throw new ArgumentException("Название должно быть от 2 до 100 символов");
            }

            if (price < 0.01m || price > 1000000m)
            {
                throw new ArgumentException("Цена должна быть от 0.01 до 1 000 000");
            }

            if (quantity < 0 || quantity > int.MaxValue)
            {
                throw new ArgumentException("Количество должно быть неотрицательным");
            }

            if (minQuantity < 0 || minQuantity > int.MaxValue)
            {
                throw new ArgumentException("Мин. запас должен быть неотрицательным");
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
