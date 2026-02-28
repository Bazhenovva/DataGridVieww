namespace DataGridView;
/// <summary>
/// класс, содержщащий информацию о материале товара
/// Используется как тип для свойства <see cref="Product.Material"/>.
/// </summary>
    public class Material
    {
        /// <summary>
        /// материал - медь
        /// </summary>
        public static readonly Material Copper = new("Медь");

        /// <summary>
        ///  материал - сталь
        /// </summary>
        public static readonly Material Steel = new("Сталь");

        /// <summary>
        /// материал - железо
        /// </summary>
        public static readonly Material Iron = new("Железо");

        /// <summary>
        /// материал - хром
        /// </summary>
        public static readonly Material Chrome = new("Хром");

        private readonly string name;
        private Material(string name)
        {
            this.name = name;
        }
        public override string ToString()
        {
            return name;
        }
    }
