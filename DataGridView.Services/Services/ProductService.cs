using System.ComponentModel;
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
        private readonly BindingList<Product> products;

        /// <summary>
        /// Инициализирует новый экземпляр сервиса
        /// </summary>
        public ProductService(IProductStorage storage)
        {
            this.storage = storage;
            products = storage.GetAll();
        }

        /// <summary>
        /// Возвращает список всех товаров
        /// </summary>
        public BindingList<Product> GetAll() => products;

        /// <summary>
        /// Добавляет новый товар в реестр
        /// </summary>
        public void Add(Product product)
        {
            product.Id = storage.GetNextId();
            storage.Add(product);
        }

        /// <summary>
        /// Обновляет существующий товар
        /// </summary>
        public void Update(Product product)
        {
            storage.Update(product);
            var existing = products.FirstOrDefault(p => p.Id == product.Id);
            if (existing != null)
            {
                existing.ProductName = product.ProductName;
                existing.ProductSize = product.ProductSize;
                existing.Material = product.Material;
                existing.Price = product.Price;
                existing.MinQuantity = product.MinQuantity;
                existing.Quantity = product.Quantity;
                products.ResetItem(products.IndexOf(existing));
            }
        }

        /// <summary>
        /// Удаляет товар из реестра
        /// </summary>
        public void Delete(Product product)
        {
            storage.Delete(product);
        }

    }
}
