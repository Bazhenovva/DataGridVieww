using DataGridView.Services.Services;
using DataGridView.Storage.InMemory;
using UI.Forms;

namespace UI
{
    static internal class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            var storage = new InMemoryProductStorage();
            var productService = new ProductService(storage);

            Application.Run(new ProductsForm(productService));
        }
    }
}
