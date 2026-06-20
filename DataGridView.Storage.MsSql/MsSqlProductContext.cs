using Microsoft.EntityFrameworkCore;
using DataGridView.Models;
using DataGridView.Storage.Contracts;

namespace DataGridView.Storage.MsSql;

/// <summary>
/// Контекст БД для работы с товарами через MS SQL Server
/// Реализует интерфейсы чтения и записи
/// </summary>
public class MsSqlProductContext : DbContext, IReader, IWriter
{
    /// <summary>
    /// Набор данных товаров (<see cref="Product"/>).
    /// </summary>
    public DbSet<Product> Products { get; set; }

    /// <summary>
    /// Создаёт контекст и гарантирует создание БД
    /// </summary>
    public MsSqlProductContext()
    {
        Database.EnsureCreated();
    }

    /// <summary>
    /// Создаёт контекст с заданными опциями и гарантирует создание БД
    /// </summary>
    public MsSqlProductContext(DbContextOptions<MsSqlProductContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    /// <summary>
    /// Настраивает маппинг сущностей, включая конвертацию
    /// <see cref="Material"/> и <see cref="ProductSize"/> в строку
    /// </summary>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entity =>
        {
            entity.Property(p => p.Id).ValueGeneratedOnAdd();

            entity.Property(p => p.Material)
                  .HasConversion<string>();

            entity.Property(p => p.ProductSize)
                  .HasConversion<string>();
        });
    }

    /// <summary>
    /// Возвращает IQueryable для чтения сущностей без отслеживания изменений
    /// </summary>
    public IQueryable<TEntity> Read<TEntity>() where TEntity : class
    {
        return base.Set<TEntity>()
            .AsNoTracking()
            .AsQueryable();
    }

    /// <summary>
    /// Добавляет сущность в контекст для последующего сохранения
    /// </summary>
    void IWriter.Add<TEntity>(TEntity entity)
    {
        base.Add(entity);
    }

    /// <summary>
    /// Помечает сущность как изменённую для последующего сохранения
    /// </summary>
    void IWriter.Update<TEntity>(TEntity entity)
    {
        base.Update(entity);
    }

    /// <summary>
    /// Помечает сущность как удалённую для последующего сохранения
    /// </summary>
    void IWriter.Delete<TEntity>(TEntity entity)
    {
        base.Remove(entity);
    }

    /// <summary>
    /// Асинхронно сохраняет все изменения в БД
    /// </summary>
    async Task<int> IWriter.SaveChangesAsync(CancellationToken cancellationToken)
    {
        return await base.SaveChangesAsync(cancellationToken);
    }
}
