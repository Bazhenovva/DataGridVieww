using System.ComponentModel.DataAnnotations;
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
        /// Название товара с валидацией по длине
        /// </summary>
        [Required(ErrorMessage = "Введите название товара")]
        [StringLength(AppConstants.ProductNameMaxLength, MinimumLength = AppConstants.ProductNameMinLength, ErrorMessage = "Название должно быть от 3 до 100 символов")]
        public string ProductName { get; set; }

        /// <summary>
        /// Размер товара
        /// </summary>
        public ProductSize ProductSize { get; set; }

        /// <summary>
        /// Материал товара
        /// </summary>
        public Material Material { get; set; }

        /// <summary>
        /// Цена товара
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Минимальный запас товара с валидацией по диапазону
        /// </summary>
        [Range(0, 1000, ErrorMessage = "Мин. запас должен быть от 0 до 1000")]
        public int MinQuantity { get; set; }

        /// <summary>
        /// Количество товара на складе с валидацией по диапазону
        /// </summary>
        [Range(0, 100, ErrorMessage = "Количество должно быть от 0 до 100")]
        public int Quantity { get; set; }  // ← Убрал Math.Clamp

        /// <summary>
        /// Общая сумма товара (вычисляемое свойство)
        /// </summary>
        public decimal TotalAmount => Quantity * Price;

        /// <summary>
        /// Конструктор с параметрами для создания товара
        /// </summary>
        public Product(string productName, ProductSize productSize, Material material, int quantity, int minQuantity, decimal price)
        {
            ProductName = productName;
            ProductSize = productSize;
            Material = material;
            Quantity = quantity;
            MinQuantity = minQuantity;
            Price = price;
        }

        /// <summary>
        /// Конструктор по умолчанию с начальными значениями
        /// </summary>
        public Product() : this("", ProductSize.M6, Material.Steel, 0, 0, 0m) { }

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
