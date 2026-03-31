namespace DataGridView.Models
{
    /// <summary>
    /// Класс для представления материалов товара
    /// </summary>
    public class Material
    {
        /// <summary>
        /// Медь
        /// </summary>
        public readonly static Material Copper = new("Медь");

        /// <summary>
        /// Сталь
        /// </summary>
        public readonly static Material Steel = new("Сталь");

        /// <summary>
        /// Железо
        /// </summary>
        public readonly static Material Iron = new("Железо");

        /// <summary>
        /// Хром
        /// </summary>
        public readonly static Material Chrome = new("Хром");

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
