using Lemondo.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
namespace Lemondo.Web.Controllers;

public class HomeController : Controller
{
    private readonly HttpClient _client;
    private readonly ILogger<HomeController> _logger;

    public HomeController(HttpClient httpClient)
    {
        _client = httpClient;
        _client.BaseAddress = new Uri("http://localhost:5119");
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
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