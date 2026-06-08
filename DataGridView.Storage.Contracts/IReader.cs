namespace DataGridView.Storage.Contracts
{
    /// <summary>
    ///
    /// </summary>
    public interface IReader
    {
        IQueryable<TEntity> Read<TEntity>() where TEntity : class;
    }
}
