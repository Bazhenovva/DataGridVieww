using System.ComponentModel;
using DataGridView.Models.Models;
using DataGridView.Services.Contracts;
using DataGridView.Storage.Contracts;

namespace DataGridView.Services.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductStorage storage;
        private readonly BindingList<Product> products;

        public ProductService(IProductStorage storage)
        {
            this.storage = storage;
            products = storage.GetAll();
        }

        public BindingList<Product> GetAll() => products;

        public void Add(Product product)
        {
            product.Id = storage.GetNextId();
            storage.Add(product);
        }

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

        public void Delete(Product product)
        {
            storage.Delete(product);
            products.Remove(product);
        }

        public Product GetById(int id)
        {
            return products.FirstOrDefault(p => p.Id == id);
        }
    }
}
