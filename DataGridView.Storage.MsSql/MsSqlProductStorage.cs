using System.ComponentModel;
using DataGridView.Models;
using DataGridView.Storage.Contracts;
using Microsoft.EntityFrameworkCore;

namespace DataGridView.Storage.MsSql;

/// <summary>
/// Репозиторий для работы с товарами через MS SQL Server
/// </summary>
public class MsSqlProductStorage : IProductStorage
{
    /// <summary>
    /// Получает все товары
    /// </summary>
    public BindingList<Product> GetAll()
    {
        using var db = new MsSqlProductContext();
        var items = db.Products
            .AsNoTracking()
            .OrderBy(p => p.ProductName)
            .ToList();

        return new BindingList<Product>(items);
    }

    /// <summary>
    /// Добавляет новый товар
    /// </summary>
    public void Add(Product product)
    {
        using var db = new MsSqlProductContext();
        product.Id = 0;
        db.Products.Add(product);
        db.SaveChanges();
    }

    /// <summary>
    /// Обновляет существующий товар
    /// </summary>
    public void Update(Product product)
    {
        using var db = new MsSqlProductContext();
        var existing = db.Products.Find(product.Id);
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

        db.Products.Update(existing);
        db.SaveChanges();
    }

    /// <summary>
    /// Удаляет товар
    /// </summary>
    public void Delete(Product product)
    {
        using var db = new MsSqlProductContext();
        var item = db.Products.Find(product.Id);
        if (item == null)
        {
            return;
        }

        db.Products.Remove(item);
        db.SaveChanges();
    }

    /// <summary>
    /// Получает следующий доступный ID
    /// </summary>
    public int GetNextId()
    {
        using var db = new MsSqlProductContext();
        return db.Products.Any()
            ? db.Products.Max(p => p.Id) + 1
            : 1;
    }
}
