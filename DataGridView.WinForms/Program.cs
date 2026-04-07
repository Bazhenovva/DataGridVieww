using DataGridView.Services.Services;
using DataGridView.Storage.InMemory;
using DataGridView.WinForms.Forms;

namespace DataGridView.WinForms
{
    static internal class Program
    {
        [STAThread]
        private static void Main()
        {
            ApplicationConfiguration.Initialize();

            var storage = new InMemoryProductStorage();
            var productService = new ProductService(storage);

            Application.Run(new ProductsForm(productService));
        }
    }
}
