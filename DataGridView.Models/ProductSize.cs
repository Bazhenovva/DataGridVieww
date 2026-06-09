namespace DataGridView.Models
{
    /// <summary>
    /// Класс для представления размеров товара
    /// </summary>
    public class ProductSize
    {
        /// <summary>
        /// Размер M6
        /// </summary>
        public static readonly ProductSize M6 = new("M6");

        /// <summary>
        /// Размер M8
        /// </summary>
        public static readonly ProductSize M8 = new("M8");

        /// <summary>
        /// Размер M10
        /// </summary>
        public static readonly ProductSize M10 = new("M10");

        /// <summary>
        /// Размер M12
        /// </summary>
        public static readonly ProductSize M12 = new("M12");

        /// <summary>
        /// Размер 10 мм
        /// </summary>
        public static readonly ProductSize Size10Mm = new("10 мм");

        /// <summary>
        /// Размер 20 мм
        /// </summary>
        public static readonly ProductSize Size20Mm = new("20 мм");

        private readonly string name;

        /// <summary>
        /// Приватный конструктор для создания экземпляра размера
        /// </summary>
        private ProductSize(string name)
        {
            this.name = name;
        }

        /// <summary>
        /// Возвращает название размера в виде строки
        /// </summary>
        public override string ToString()
        {
            return name;
        }

        /// <summary>
        /// Преобразует строку из формы в объект ProductSize
        /// </summary>

        public static ProductSize Parse(string value)
        {
            return value switch
            {
                "M6" => M6,
                "M8" => M8,
                "M10" => M10,
                "M12" => M12,
                "Size10Mm" => Size10Mm,
                "Size20Mm" => Size20Mm,
                _ => M6
            };
        }
    }
}
