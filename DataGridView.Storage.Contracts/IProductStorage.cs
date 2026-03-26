using System.ComponentModel;
using DataGridView.Models.Models;

namespace DataGridView.Storage.Contracts
{
    /// <summary>
    /// Интерфейс хранилища данных для товаров
    /// </summary>
    public interface IProductStorage
    {
        /// <summary>
        /// получить все товары
        /// </summary>
        BindingList<Product> GetAll();

        /// <summary>
        /// добавить новый товар
        /// </summary>
        void Add(Product product);

        /// <summary>
        /// обновить существующий товар
        /// </summary>
        void Update(Product product);

        /// <summary>
        /// удалить товар
        /// </summary>
        void Delete(Product product);

        /// <summary>
        /// найти товар по ID
        /// </summary>
        Product GetById(int id);

        /// <summary>
        /// получить следующий доступный ID
        /// </summary>
        int GetNextId();
    }
}
