using System.ComponentModel;
using DataGridView.Models.Models;
using DataGridView.Storage.Contracts;

namespace DataGridView.Storage.InMemory
{
    public class InMemoryProductStorage : IProductStorage
    {
        private readonly BindingList<Product> products;
        private int nextId;

        public InMemoryProductStorage()
        {
            products = new BindingList<Product>();
            nextId = 1;

            products.Add(new Product("Гвоздь", ProductSize.Size10Mm, Material.Steel, 100, 20, 3.5m) { Id = nextId++ });
            products.Add(new Product("Гайка", ProductSize.M8, Material.Copper, 50, 10, 7.2m) { Id = nextId++ });
            products.Add(new Product("Болт", ProductSize.M10, Material.Iron, 15, 15, 9.0m) { Id = nextId++ });
            products.Add(new Product("Шайба", ProductSize.M6, Material.Chrome, 3, 30, 2.1m) { Id = nextId++ });
        }

        public BindingList<Product> GetAll() => products;

        public void Add(Product product)
        {
            products.Add(product);
        }

        public void Update(Product product)
        {
            var existing = products.FirstOrDefault(p => p.Id == product.Id);
            if (existing != null)
            {
                var index = products.IndexOf(existing);
                products[index] = product;
            }
        }

        public void Delete(Product product)
        {
            products.Remove(product);
        }

        public Product GetById(int id)
        {
            return products.FirstOrDefault(p => p.Id == id);
        }

        public int GetNextId() => nextId++;
    }
}
