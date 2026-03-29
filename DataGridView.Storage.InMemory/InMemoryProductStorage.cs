using System.ComponentModel;
using DataGridView.Models.Constants;
using DataGridView.Models.Models;
using DataGridView.Storage.Contracts;

namespace DataGridView.Storage.InMemory
{
    /// <summary>
    /// хранилище товаров в памяти
    /// </summary>
    public class InMemoryProductStorage : IProductStorage
    {
        private readonly BindingList<Product> products;
        private int nextId;

        /// <summary>
        /// конструктор с тестовыми данными
        /// </summary>
        public InMemoryProductStorage()
        {
            products = [];
            nextId =  BusinessConstants.InitialId;

            products.Add(new Product("Гвоздь", ProductSize.Size10Mm, Material.Steel, 100, 20, 3.5m) { Id = nextId++ });
            products.Add(new Product("Гайка", ProductSize.M8, Material.Copper, 50, 10, 7.2m) { Id = nextId++ });
            products.Add(new Product("Болт", ProductSize.M10, Material.Iron, 15, 15, 9.0m) { Id = nextId++ });
            products.Add(new Product("Шайба", ProductSize.M6, Material.Chrome, 3, 30, 2.1m) { Id = nextId++ });
        }

        /// <summary>
        /// получить все товары
        /// </summary>
        public BindingList<Product> GetAll() => products;

        /// <summary>
        /// добавить новый товар
        /// </summary>
        public void Add(Product product)
        {
            products.Add(product);
        }

        /// <summary>
        /// обновить существующий товар
        /// </summary>
        public void Update(Product product)
        {
            var existing = products.FirstOrDefault(p => p.Id == product.Id);
            if (existing != null)
            {
                var index = products.IndexOf(existing);
                products[index] = product;
            }
        }

        /// <summary>
        /// удалить товар
        /// </summary>
        public void Delete(Product product)
        {
            products.Remove(product);
        }

        /// <summary>
        /// получить следующий доступный ID
        /// </summary>
        public int GetNextId() => nextId++;
    }
}
