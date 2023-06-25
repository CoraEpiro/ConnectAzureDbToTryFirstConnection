using Bogus;
using ConnectAzureDbToTryFirstConnection.Models;
using ConnectToAzureDbToTryFirstConnection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Diagnostics;

namespace ConnectAzureDbToTryFirstConnection.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ProductsDbContext _context;

    public HomeController(ILogger<HomeController> logger, ProductsDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpPost]
    public IActionResult Index(string optionValue)
    {
        var categoryID = _context.ProductCategory.FirstOrDefault(x => x.Name == optionValue).ProductCategoryID;
        var products = _context.Product.Where(x => x.ProductCategoryID == categoryID).ToList();
        var categories = _context.ProductCategory.Select(x => x.Name).ToList();
        ViewBag.Categories = categories;

        foreach (var product in products)
        {
            product.ProductCategoryName = 
                _context.ProductCategory.
                        FirstOrDefault(x => x.ProductCategoryID == product.ProductCategoryID)!
                        .Name!;
        }
        return View(products);
    }
    public IActionResult Index()
    {
        var categories = _context.ProductCategory.Select(x => x.Name).ToList();
        ViewBag.Categories = categories;
        return View(null);
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