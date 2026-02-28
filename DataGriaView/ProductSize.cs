namespace DataGridView;
/// <summary>
/// класс, содержащий информацию о размере товара
/// Используется как тип для свойства <see cref="Product.ProductSize"/>.
/// </summary>
public class ProductSize
{
    /// <summary>
    /// Размер M6.
    /// </summary>
    public static readonly ProductSize M6 = new("M6");

    /// <summary>
    /// Размер M8.
    /// </summary>
    public static readonly ProductSize M8 = new("M8");

    /// <summary>
    /// Размер M10.
    /// </summary>
    public static readonly ProductSize M10 = new("M10");

    /// <summary>
    /// Размер M12.
    /// </summary>
    public static readonly ProductSize M12 = new("M12");

    /// <summary>
    /// Размер 10 мм.
    /// </summary>
    public static readonly ProductSize Size10Mm = new("10 мм");

    /// <summary>
    /// Размер 20 мм.
    /// </summary>
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
