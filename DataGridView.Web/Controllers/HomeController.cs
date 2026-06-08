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
        await productService.AddAsync(product);
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Product product)
    {
        await productService.UpdateAsync(product);
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public async Task<IActionResult> Delete(Product product)
    {
        await productService.DeleteAsync(product);
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
