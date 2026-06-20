using System.ComponentModel;
using DataGridView.Models;

namespace DataGridView.Storage.Contracts
{
    /// <summary>
    /// Интерфейс хранилища данных для товаров
    /// </summary>
    public interface IProductStorage
    {
        /// <summary>
        /// Получить все товары
        /// </summary>
        Task<IReadOnlyCollection<Product>> GetAllAsync();

        /// <summary>
        /// Добавить новый товар
        /// </summary>
        Task AddAsync(Product product);

        /// <summary>
        /// Обновить существующий товар
        /// </summary>
        Task UpdateAsync(Product product);

        /// <summary>
        /// Удалить товар
        /// </summary>
        Task DeleteAsync(Product product);

        /// <summary>
        /// Получить следующий доступный ID
        /// </summary>
        Task<int> GetNextIdAsync();
    }
}
