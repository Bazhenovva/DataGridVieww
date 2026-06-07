using System.ComponentModel;
using DataGridView.Models;
using DataGridView.Storage.Contracts;
using Microsoft.EntityFrameworkCore;

namespace DataGridView.Storage.MsSql;

/// <summary>
/// Репозиторий для работы с товарами через MS SQL Server
/// </summary>
public class MsSqlProductStorage(MsSqlProductContext context) : IProductStorage
{
    private readonly MsSqlProductContext context = context;

    /// <summary>
    /// Асинхронно получает все товары
    /// </summary>
    public async Task<BindingList<Product>> GetAllAsync()
    {
        var result = await context.Products
            .AsNoTracking()
            .OrderBy(p => p.ProductName)
            .ToListAsync();

        return new BindingList<Product>(result);
    }

    /// <summary>
    /// Асинхронно добавляет новый товар
    /// </summary>
    public async Task AddAsync(Product product)
    {
        product.Id = 0;
        await context.Products.AddAsync(product);
        await context.SaveChangesAsync();
    }

    /// <summary>
    /// Асинхронно обновляет существующий товар
    /// </summary>
    public async Task UpdateAsync(Product product)
    {
        var existing = await context.Products.FindAsync(product.Id);
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

        await context.SaveChangesAsync();
    }

    /// <summary>
    /// Асинхронно удаляет товар
    /// </summary>
    public async Task DeleteAsync(Product product)
    {
        var item = await context.Products.FindAsync(product.Id);
        if (item == null)
        {
            return;
        }

        context.Products.Remove(item);
        await context.SaveChangesAsync();
    }

    /// <summary>
    /// Асинхронно получает следующий доступный ID
    /// </summary>
    public async Task<int> GetNextIdAsync()
    {
        if (await context.Products.AnyAsync())
        {
            return await context.Products.MaxAsync(p => p.Id) + 1;
        }
        else
        {
            return 1;
        }
    }
}
