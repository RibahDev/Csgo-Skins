using System.Diagnostics;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using SkinGO.Models;

namespace SkinGO.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        List<Arma> armas = [];
        using (StramReader leitor = new("Data\\armas.json"))
        {
            string dados = leitor.ReadToEnd(); 
            skins = JsonSerializer.Deserialize<List<Armas>>(dados);
        }
        List<Caracteristica> caracteristicas = [];
        using(StreamReader leitor = new("Data\\caracteristicas.json"))
        {
            string dados = leitor.ReadToEnd();
            caracteristicas = JsonSerializer.Deserialize<List<Caracteristica>>(dados);
        }
        ViewData["Caracteristicas"] = caracteristicas;
        return View(armas);
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
