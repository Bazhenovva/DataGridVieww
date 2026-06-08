using Microsoft.EntityFrameworkCore;
using DataGridView.Models;
using DataGridView.Storage.Contracts;

namespace DataGridView.Storage.MsSql;

/// <summary>
/// Контекст БД для работы с товарами через MS SQL Server.
/// </summary>
public class MsSqlProductContext : DbContext, IReader, IWriter
{
    /// <summary>
    /// Набор данных товаров (<see cref="Product"/>).
    /// </summary>
    public DbSet<Product> Products { get; set; }

    /// <summary>
    /// Конструктор без параметров (для миграций)
    /// </summary>
    public MsSqlProductContext() => Database.EnsureCreated();

    /// <summary>
    /// Конструктор с опциями (для DI через AddDbContext)
    /// </summary>
    public MsSqlProductContext(DbContextOptions<MsSqlProductContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }

    /// <summary>
    /// Преобразует <see cref="Material"/> и <see cref="ProductSize"/> в строку БД
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

    public IQueryable<TEntity> Read<TEntity>() where TEntity : class
    {
        return base.Set<TEntity>()
            .AsNoTracking()
            .AsQueryable();
    }

    void IWriter.Add<TEntity>(TEntity entity)
    {
        base.Add(entity);
    }

    void IWriter.Update<TEntity>(TEntity entity)
    {
        base.Update(entity);
    }

    void IWriter.Delete<TEntity>(TEntity entity)
    {
        base.Remove(entity);
    }

    async Task<int> IWriter.SaveChangesAsync(CancellationToken cancellationToken)
    {
        return await base.SaveChangesAsync(cancellationToken);
    }
}
