namespace DataGridView
{
    public class Material
    {
        public static readonly Material Copper = new("Медь");
        public static readonly Material Steel = new("Сталь");
        public static readonly Material Iron = new("Железо");
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
}
