namespace DataGridView
{
    public class ProductSize
    {
        public static readonly ProductSize M6 = new("M6");
        public static readonly ProductSize M8 = new("M8");
        public static readonly ProductSize M10 = new("M10");
        public static readonly ProductSize M12 = new("M12");
        public static readonly ProductSize Size10Mm = new("10 мм");
        public static readonly ProductSize Size20Mm = new("20 мм");

        private readonly string name;

        private ProductSize(string name)
        {
            this.name = name;
        }

        public override string ToString()
        {
            return name;
        }
    }
}
