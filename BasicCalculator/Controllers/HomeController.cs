using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BasicCalculator.Models;
using System.Data;

namespace BasicCalculator.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }
    
    [HttpPost]
    public string Calculation([FromBody] string content)
    {
        NumberStringModel model = new NumberStringModel();
        model.NumString = new DataTable().Compute(content, null).ToString();
        return model.NumString;
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
    }
}