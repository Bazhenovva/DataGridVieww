namespace DataGridView
{
    /// <summary>
    /// Класс, который представляет товар на складе
    /// Используется для ведения реестра товаров
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Название товара
        /// </summary>
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
        /// Цена без НДС за единицу товара
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Минимальный предел количества
        /// </summary>
        public int MinQuantity { get; set; }

        /// <summary>
        /// Приватное поле для хранения количества товара
        /// </summary>
        private int quantity;

        /// <summary>
        /// Количество товара на складе
        /// Ограничено диапазоном от 0 до 100
        /// </summary>
        public int Quantity
        {
            get => quantity;
            set => quantity = Math.Clamp(value, 0, 100);
        }

        /// <summary>
        /// Общая сумма товара,вычисляется автоматически
        /// </summary>
        public decimal TotalAmount => Quantity * Price;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Product"/>.
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
    }
}
