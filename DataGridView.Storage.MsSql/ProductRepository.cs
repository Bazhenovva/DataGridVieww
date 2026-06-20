using System.ComponentModel;
using DataGridView.Models;
using DataGridView.Storage.Contracts;

namespace DataGridView.Storage.MsSql;

/// <summary>
/// Репозиторий для работы с товарами через MS SQL Server
/// </summary>
public class ProductRepository : IProductStorage
{
    private readonly IReader reader;
    private readonly IWriter writer;

    /// <summary>
    /// Инициализирует новый экземпляр репозитория
    /// </summary>
    public ProductRepository(IReader reader, IWriter writer)
    {
        this.reader = reader;
        this.writer = writer;
    }

    /// <summary>
    /// Асинхронно получает все товары из хранилища
    /// </summary>
    public async Task<IReadOnlyCollection<Product>> GetAllAsync()
    {
        var products = reader.Read<Product>()
            .OrderBy(p => p.ProductName)
            .ToList();

        return await Task.FromResult(new BindingList<Product>(products));
    }

    /// <summary>
    /// Асинхронно добавляет новый товар в хранилище
    /// </summary>
    public async Task AddAsync(Product product)
    {
        product.Id = 0;
        writer.Add(product);
        await writer.SaveChangesAsync();
    }

    /// <summary>
    /// Асинхронно обновляет существующий товар
    /// </summary>
    public async Task UpdateAsync(Product product)
    {
        var existing = reader.Read<Product>()
            .FirstOrDefault(p => p.Id == product.Id);

        if (existing == null)
        {
            return;
        }

        existing.ProductName = product.ProductName;
        existing.ProductSize = product.ProductSize;
        existing.Material = product.Material;
        existing.Price = product.Price;
        existing.Quantity = product.Quantity;
        existing.MinQuantity = product.MinQuantity;

        writer.Update(existing);
        await writer.SaveChangesAsync();
    }

    /// <summary>
    /// Асинхронно удаляет товар из хранилища
    /// </summary>
    public async Task DeleteAsync(Product product)
    {
        var existing = reader.Read<Product>()
            .FirstOrDefault(p => p.Id == product.Id);

        if (existing == null)
        {
            return;
        }

        writer.Delete(existing);
        await writer.SaveChangesAsync();
    }

    /// <summary>
    /// Асинхронно получает следующий доступный ID
    /// </summary>
    public async Task<int> GetNextIdAsync()
    {
        var products = reader.Read<Product>().ToList();

        if (products.Count == 0)
        {
            return await Task.FromResult(1);
        }

        return await Task.FromResult(products.Max(p => p.Id) + 1);
    }
}
