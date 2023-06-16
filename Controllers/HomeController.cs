using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using lab11.Models;
using Microsoft.AspNetCore.Authorization;
using lab11.Data;

namespace lab11.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    
    private readonly StockExchangeContext _context;


    public HomeController(ILogger<HomeController> logger, StockExchangeContext context)
    {
        _context = context;
        _logger = logger;
    }

    public IActionResult Index()
    {
        DbInitializer.Initialize(_context);
        return View();
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
