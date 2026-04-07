namespace DataGridView.Models.Constants
{
    /// <summary>
    /// Константы для валидации данных
    /// </summary>
    public static class ValidationConstants
    {
        /// <summary>
        /// Минимальная длина названия товара
        /// </summary>
        public const int ProductNameMinLength = 3;

        /// <summary>
        /// Максимальная длина названия товара
        /// </summary>
        public const int ProductNameMaxLength = 100;

        /// <summary>
        /// Минимальное количество товара на складе
        /// </summary>
        public const int QuantityMin = 0;

        /// <summary>
        /// Максимальное количество товара на складе
        /// </summary>
        public const int QuantityMax = 100;

        /// <summary>
        /// Минимальное значение минимального запаса
        /// </summary>
        public const int MinQuantityMin = 0;

        /// <summary>
        /// Максимальное значение минимального запаса
        /// </summary>
        public const int MinQuantityMax = 100;

        /// <summary>
        /// Минимальная цена товара
        /// </summary>
        public const decimal PriceMin = 0.01m;

        /// <summary>
        /// Максимальная цена товара
        /// </summary>
        public const decimal PriceMax = 999999m;

        /// <summary>
        /// Количество знаков после запятой для цены
        /// </summary>
        public const int PriceDecimalPlaces = 2;
    }
}
