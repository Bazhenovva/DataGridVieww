using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using DataGridView.Models;
using DataGridView.Models.Constants;
using DataGridView.Storage.Contracts;

namespace DataGridView.Storage.InMemory
{
    /// <summary>
    /// Хранилище товаров в памяти
    /// </summary>
    public class InMemoryProductStorage : IProductStorage
    {
        private readonly BindingList<Product> products;
        private int nextId;

        /// <summary>
        /// Конструктор с тестовыми данными
        /// </summary>
        public InMemoryProductStorage()
        {
            products = [];
            nextId = BusinessConstants.InitialId;

            products.Add(new Product("Гвоздь", ProductSize.Size10Mm, Material.Steel, 100, 20, 3.5m) { Id = nextId++ });
            products.Add(new Product("Гайка", ProductSize.M8, Material.Copper, 50, 10, 7.2m) { Id = nextId++ });
            products.Add(new Product("Болт", ProductSize.M10, Material.Iron, 15, 15, 9.0m) { Id = nextId++ });
            products.Add(new Product("Шайба", ProductSize.M6, Material.Chrome, 3, 30, 2.1m) { Id = nextId++ });
        }

        /// <summary>
        /// Асинхронно получает все товары
        /// </summary>
        public async Task<BindingList<Product>> GetAllAsync()
        {
            return products;
        }

        /// <summary>
        /// Асинхронно добавляет новый товар
        /// </summary>
        public async Task AddAsync(Product product)
        {
            product.Id = nextId;
            nextId++;
            products.Add(product);
        }

        /// <summary>
        /// Асинхронно обновляет существующий товар
        /// </summary>
        public async Task UpdateAsync(Product product)
        {
            var existing = products.FirstOrDefault(p => p.Id == product.Id);
            if (existing != null)
            {
                var index = products.IndexOf(existing);
                products[index] = product;
            }
        }

        /// <summary>
        /// Асинхронно удаляет товар
        /// </summary>
        public async Task DeleteAsync(Product product)
        {
            products.Remove(product);
        }

        /// <summary>
        /// Асинхронно получает следующий доступный ID
        /// </summary>
        public async Task<int> GetNextIdAsync()
        {
            return nextId++;
        }
    }
}
