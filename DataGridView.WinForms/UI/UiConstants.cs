namespace DataGridView.WinForms.UI
{
    /// <summary>
    /// Константы для настройки пользовательского интерфейса
    /// </summary>
    public static class UiConstants
    {
        /// <summary>
        /// Заголовок главной формы приложения
        /// </summary>
        public const string FormTitle = "Реестр товаров";

        /// <summary>
        /// Заголовок формы редактирования товара
        /// </summary>
        public const string FormEditTitle = "Редактирование товара";

        /// <summary>
        /// Заголовок формы добавления нового товара
        /// </summary>
        public const string FormAddTitle = "Добавление товара";

        /// <summary>
        /// Имя столбца для отображения количества товара
        /// </summary>
        public const string QuantityColumnName = "QuantityColumn";

        /// <summary>
        /// Отступ в пикселях для кастомной отрисовки ячеек
        /// </summary>
        public const int CellOffset = 2;

        /// <summary>
        /// Цвет рамки индикатора заполнения количества товара
        /// </summary>
        public readonly static Color QuantityProgressBarBorderColor = Color.SteelBlue;

        /// <summary>
        /// Цвет заполнения индикатора количества товара
        /// </summary>
        public readonly static Color QuantityProgressBarFillColor = Color.SkyBlue;

        /// <summary>
        /// Цвет текста индикатора количества товара
        /// </summary>
        public readonly static Color QuantityProgressTextColor = Color.Black;

        /// <summary>
        /// Заголовок предупреждающих сообщений
        /// </summary>
        public const string MessageBoxWarningTitle = "Внимание";

        /// <summary>
        /// Заголовок диалога подтверждения удаления товара
        /// </summary>
        public const string MessageBoxDeleteTitle = "Удаление товара";
    }
}
