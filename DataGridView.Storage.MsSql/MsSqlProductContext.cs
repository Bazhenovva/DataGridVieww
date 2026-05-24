using Microsoft.EntityFrameworkCore;
using DataGridView.Models;

namespace DataGridView.Storage.MsSql;

/// <summary>
/// Контекст БД для работы с товарами через MS SQL Server.
/// </summary>
public class MsSqlProductContext : DbContext
{
    /// <summary>
    /// Набор данных товаров
    /// <see cref="Product"/>).
    /// </summary>
    public DbSet<Product> Products { get; set; }

    /// <summary>
    /// Инициализирует контекст и создаёт БД при первом запуске.
    /// </summary>
    public MsSqlProductContext() => Database.EnsureCreated();

    /// <summary>
    /// Настраивает подключение к LocalDB.
    /// </summary>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\mssqllocaldb;Database=DataGridViewDb_v5;Trusted_Connection=True;");
        }
    }
    /// <summary>
    /// Преобразует <see cref="Material"/> и <see cref="ProductSize"/> в строку БД,
    /// так как эти модели имеют приватные поля и не могут быть сохранены напрямую
    /// </summary>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entity =>
        {
            entity.Property(p => p.Id).ValueGeneratedOnAdd();

            entity.Property(p => p.Material)
                  .HasConversion(
                      m => m.ToString(),
                      s => ParseMaterial(s)
                  );

            entity.Property(p => p.ProductSize)
                  .HasConversion(
                      ps => ps.ToString(),
                      s => ParseProductSize(s)
                  );
        });
    }

    /// <summary>
    /// Восстанавливает экземпляр <see cref="Material"/> из строки БД.
    /// </summary>
    private static Material ParseMaterial(string value)
    {
        return value switch
        {
            "Медь" => Material.Copper,
            "Сталь" => Material.Steel,
            "Железо" => Material.Iron,
            "Хром" => Material.Chrome,
            _ => Material.Steel
        };
    }
    /// <summary>
    /// Восстанавливает экземпляр <see cref="ProductSize"/> из строки БД.
    /// </summary>
    private static ProductSize ParseProductSize(string value)
    {
        return value switch
        {
            "M6" => ProductSize.M6,
            "M8" => ProductSize.M8,
            "M10" => ProductSize.M10,
            "M12" => ProductSize.M12,
            "10 мм" => ProductSize.Size10Mm,
            "20 мм" => ProductSize.Size20Mm,
            _ => ProductSize.M6
        };
    }
}
