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
        if (!ModelState.IsValid)
        {
            var products = await productService.GetAllAsync();
            return View("Index", products);
        }

        await productService.AddAsync(product);
        return RedirectToAction(nameof(Index));
    }

    /// <summary>
    /// Обновляет существующий товар 
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> Edit(Product product)
    {
        if (!ModelState.IsValid)
        {
            var products = await productService.GetAllAsync();
            return View("Index", products);
        }

        await productService.UpdateAsync(product);
        return RedirectToAction(nameof(Index));
    }

    /// <summary>
    /// Удаляет товар по Id
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        var products = await productService.GetAllAsync();
        var product = products.FirstOrDefault(p => p.Id == id);

        if (product != null)
        {
            await productService.DeleteAsync(product);
        }

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
