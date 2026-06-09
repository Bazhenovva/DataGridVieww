using System.Diagnostics;
using DataGridView.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using DataGridView.Web.Models;
using DataGridView.Models;

namespace DataGridView.Web.Controllers;

public class HomeController : Controller
{
    private readonly IProductService productService;

    public HomeController(IProductService productService)
    {
        this.productService = productService;
    }

    public async Task<IActionResult> Index()
    {
        var products = await productService.GetAllAsync();
        return View(products);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Product product)
    {
        SetMaterialAndSize(product);
        await productService.AddAsync(product);
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Product product)
    {
        SetMaterialAndSize(product);
        await productService.UpdateAsync(product);
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public async Task<IActionResult> Delete(Product product)
    {
        await productService.DeleteAsync(product);
        return RedirectToAction(nameof(Index));
    }

    private void SetMaterialAndSize(Product product)
    {
        if (Request.Form.TryGetValue("Material", out var materialValue))
        {
            switch (materialValue.ToString())
            {
                case "Steel":
                    product.Material = Material.Steel;
                    break;
                case "Copper":
                    product.Material = Material.Copper;
                    break;
                case "Iron":
                    product.Material = Material.Iron;
                    break;
                case "Chrome":
                    product.Material = Material.Chrome;
                    break;
            }
        }

        if (Request.Form.TryGetValue("ProductSize", out var sizeValue))
        {
            switch (sizeValue.ToString())
            {
                case "M6":
                    product.ProductSize = ProductSize.M6;
                    break;
                case "M8":
                    product.ProductSize = ProductSize.M8;
                    break;
                case "M10":
                    product.ProductSize = ProductSize.M10;
                    break;
                case "M12":
                    product.ProductSize = ProductSize.M12;
                    break;
                case "Size10Mm":
                    product.ProductSize = ProductSize.Size10Mm;
                    break;
                case "Size20Mm":
                    product.ProductSize = ProductSize.Size20Mm;
                    break;
            }
        }
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
