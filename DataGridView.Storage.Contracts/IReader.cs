namespace DataGridView.Storage.Contracts
{
    /// <summary>
    ///Интерфейс для чтения данных из хранилища
    /// </summary>
    public interface IReader
    {
        IQueryable<TEntity> Read<TEntity>() where TEntity : class;
    }
}
