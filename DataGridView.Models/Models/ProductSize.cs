namespace DataGridView.Models.Models
{
    /// <summary>
    /// Класс для представления размеров товара
    /// </summary>
    public class ProductSize
    {
        /// <summary>
        /// Размер M6
        /// </summary>
        public readonly static ProductSize M6 = new("M6");

        /// <summary>
        /// Размер M8
        /// </summary>
        public readonly static ProductSize M8 = new("M8");

        /// <summary>
        /// Размер M10
        /// </summary>
        public readonly static ProductSize M10 = new("M10");

        /// <summary>
        /// Размер M12
        /// </summary>
        public readonly static ProductSize M12 = new("M12");

        /// <summary>
        /// Размер 10 мм
        /// </summary>
        public readonly static ProductSize Size10Mm = new("10 мм");

        /// <summary>
        /// Размер 20 мм
        /// </summary>
        public readonly static ProductSize Size20Mm = new("20 мм");

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
    }
}
