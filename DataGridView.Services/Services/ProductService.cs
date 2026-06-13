using System.Collections.ObjectModel;
using DataGridView.Models;
using DataGridView.Services.Contracts;
using DataGridView.Storage.Contracts;

namespace DataGridView.Services.Services
{
    /// <summary>
    /// Сервис для управления товарами в реестре
    /// </summary>
    public class ProductService : IProductService
    {
        private readonly IProductStorage storage;
        private List<Product> products;

        /// <summary>
        /// Инициализирует новый экземпляр сервиса
        /// </summary>
        public ProductService(IProductStorage storage)
        {
            this.storage = storage;
            products = new List<Product>();
        }

        /// <summary>
        /// Асинхронно возвращает список всех товаров
        /// </summary>
        public async Task<IReadOnlyCollection<Product>> GetAllAsync()
        {
            var list = await storage.GetAllAsync();
            products = new List<Product>(list);
            return products.AsReadOnly();
        }

        /// <summary>
        /// Асинхронно добавляет новый товар в реестр
        /// </summary>
        public async Task AddAsync(Product product)
        {
            product.Id = await storage.GetNextIdAsync();
            await storage.AddAsync(product);
            products.Add(product);
        }

        /// <summary>
        /// Асинхронно обновляет существующий товар
        /// </summary>
        public async Task UpdateAsync(Product product)
        {
            await storage.UpdateAsync(product);
            var existing = products.FirstOrDefault(p => p.Id == product.Id);
            if (existing != null)
            {
                existing.ProductName = product.ProductName;
                existing.ProductSize = product.ProductSize;
                existing.Material = product.Material;
                existing.Price = product.Price;
                existing.MinQuantity = product.MinQuantity;
                existing.Quantity = product.Quantity;
            }
        }

        /// <summary>
        /// Асинхронно удаляет товар из реестра
        /// </summary>
        public async Task DeleteAsync(Product product)
        {
            await storage.DeleteAsync(product);
            products.Remove(product);
        }
    }
}
