namespace DataGridView.Models.Constants
{
    /// <summary>
    /// Константы приложения для валидации и UI
    /// </summary>
    public static class AppConstants
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
        public const int MinQuantityMax = 1000;

        /// <summary>
        /// Минимальная цена товара
        /// </summary>
        public const decimal PriceMin = 0.01m;

        /// <summary>
        /// Максимальная цена товара
        /// </summary>
        public const decimal PriceMax = 999999m;

        /// <summary>
        /// Заголовок главной формы
        /// </summary>
        public const string FormTitle = "Реестр товаров";

        /// <summary>
        /// Заголовок формы редактирования
        /// </summary>
        public const string FormEditTitle = "Редактирование товара";

        /// <summary>
        /// Заголовок формы добавления
        /// </summary>
        public const string FormAddTitle = "Добавление товара";

        /// <summary>
        /// Начальный ID для новых товаров
        /// </summary>
        public const int InitialId = 1;
    }
}
