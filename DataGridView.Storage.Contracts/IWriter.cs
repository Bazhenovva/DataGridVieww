using System.Diagnostics.CodeAnalysis;

namespace DataGridView.Storage.Contracts
{
    /// <summary>
    /// Интерфейс для записи данных в хранилище
    /// </summary>
    public interface IWriter
    {
        /// <summary>
        /// Добавить сущность
        /// </summary>
        void Add<TEntity>([NotNull] TEntity entity) where TEntity : class;

        /// <summary>
        /// Обновить сущность
        /// </summary>
        void Update<TEntity>([NotNull] TEntity entity) where TEntity : class;

        /// <summary>
        /// Удалить сущность
        /// </summary>
        void Delete<TEntity>([NotNull] TEntity entity) where TEntity : class;

        /// <summary>
        /// Асинхронно сохранить изменения в хранилище
        /// </summary>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
