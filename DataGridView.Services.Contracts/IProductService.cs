using System.ComponentModel;
using DataGridView.Models;

namespace DataGridView.Services.Contracts
{
    /// <summary>
    /// Интерфейс сервиса для управления товарами в реестре
    /// </summary>
    public interface IProductService
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
    }
}
