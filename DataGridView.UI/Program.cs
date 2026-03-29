using DataGridView.Services.Services;
using DataGridView.Storage.InMemory;
using DataGridView.UI.Forms;

namespace DataGridView.UI
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            var storage = new InMemoryProductStorage();
            var productService = new ProductService(storage);

            Application.Run(new Form1(productService));
        }
    }
}
