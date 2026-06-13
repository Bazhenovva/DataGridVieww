using System.Collections.ObjectModel;
using DataGridView.Models;

namespace DataGridView.Services.Contracts
{
    /// <summary>
    /// Интерфейс сервиса для управления товарами в реестре
    /// </summary>
    public interface IProductService
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
    }
}
