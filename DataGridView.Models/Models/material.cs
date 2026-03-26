namespace DataGridView.Models.Models
{
    /// <summary>
    /// Класс для представления материалов товара
    /// </summary>
    public class Material
    {
        /// <summary>
        /// Медь
        /// </summary>
        public static readonly Material Copper = new("Медь");

        /// <summary>
        /// Сталь
        /// </summary>
        public static readonly Material Steel = new("Сталь");

        /// <summary>
        /// Железо
        /// </summary>
        public static readonly Material Iron = new("Железо");

        /// <summary>
        /// Хром
        /// </summary>
        public static readonly Material Chrome = new("Хром");

        private readonly string name;

        /// <summary>
        /// Приватный конструктор для создания экземпляра материала
        /// </summary>
        private Material(string name)
        {
            this.name = name;
        }

        /// <summary>
        /// Возвращает название материала в виде строки
        /// </summary>
        public override string ToString()
        {
            return name;
        }
    }
}
