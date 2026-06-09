using System.Diagnostics;
using DataGridView.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using DataGridView.Web.Models;
using DataGridView.Models;

namespace DataGridView.Web.Controllers;

/// <summary>
/// Контроллер для управления реестром товаров
/// </summary>
public class HomeController : Controller
{
    private readonly IProductService productService;

    /// <summary>
    /// Инициализирует контроллер с сервисом товаров
    /// </summary>
    public HomeController(IProductService productService)
    {
        this.productService = productService;
    }

    /// <summary>
    /// Отображает список всех товаров
    /// </summary>
    public async Task<IActionResult> Index()
    {
        var products = await productService.GetAllAsync();
        return View(products);
    }

    /// <summary>
    /// Создаёт новый товар
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> Create(Product product)
    {
        product.Material = Material.Parse(Request.Form["Material"].ToString());
        product.ProductSize = ProductSize.Parse(Request.Form["ProductSize"].ToString());

        await productService.AddAsync(product);
        return RedirectToAction(nameof(Index));
    }

    /// <summary>
    /// Обновляет существующий товар
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> Edit(Product product)
    {
        product.Material = Material.Parse(Request.Form["Material"].ToString());
        product.ProductSize = ProductSize.Parse(Request.Form["ProductSize"].ToString());

        await productService.UpdateAsync(product);
        return RedirectToAction(nameof(Index));
    }

    /// <summary>
    /// Удаляет товар по Id
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> Delete(Product product)
    {
        await productService.DeleteAsync(product);
        return RedirectToAction(nameof(Index));
    }

    /// <summary>
    /// Обработчик ошибок приложения
    /// </summary>
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
