using System.ComponentModel;

namespace DataGridView
{
    public class ProductService
    {
        private readonly BindingList<Product> products;
        private int nextId;

        public ProductService()
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
            product.Id = nextId;
            nextId++;
            products.Add(product);
        }

        public void Update(Product product)
        {
            var existing = products.FirstOrDefault(p => p.Id == product.Id);
            if (existing != null)
            {
                // Обновляем свойства существующего объекта (не заменяем!)
                existing.ProductName = product.ProductName;
                existing.ProductSize = product.ProductSize;
                existing.Material = product.Material;
                existing.Price = product.Price;
                existing.MinQuantity = product.MinQuantity;
                existing.Quantity = product.Quantity;

                // Уведомляем BindingList об изменении
                products.ResetItem(products.IndexOf(existing));
            }
        }

        public void Delete(Product product)
        {
            products.Remove(product);
        }
    }
}
