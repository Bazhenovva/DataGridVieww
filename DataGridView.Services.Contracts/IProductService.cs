using System.ComponentModel;
using DataGridView.Models.Models;

namespace DataGridView.Services.Contracts
{
    public interface IProductService
    {
        BindingList<Product> GetAll();
        void Add(Product product);
        void Update(Product product);
        void Delete(Product product);
        Product GetById(int id);
    }
}
