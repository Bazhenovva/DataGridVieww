using System.ComponentModel;
using DataGridView.Models.Models;

namespace DataGridView.Storage.Contracts
{
    public interface IProductStorage
    {
        BindingList<Product> GetAll();
        void Add(Product product);
        void Update(Product product);
        void Delete(Product product);
        Product GetById(int id);
        int GetNextId();
    }
}
