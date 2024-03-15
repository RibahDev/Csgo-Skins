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
        List<Arma> armas = GetArmas();
        List<Caracteristica> caracteristicas = GetCaracteristicas();
        ViewData["Caracteristicas"] = caracteristicas;
        return View(armas);
    }

    public IActionResult Details(int id)
    {
        List<Arma> armas = GetArmas();
        List<Caracteristica> caracteristicas = GetCaracteristicas();
        DetailsVM details = new() {
            Caracteristicas = caracteristicas,
            Atual = armas.FirstOrDefault(p => p.Numero == id),
            Anterior = armas.OrderByDescending(p => p.Numero).FirstOrDefault(p => p.Numero < id),
            Proximo = armas.OrderBy(p => p.Numero).FirstOrDefault(p => p.Numero > id),
        };
        return View(details);
    }

    private List<Arma> GetArmas()
    {
        using (StreamReader leitor = new("Data\\armas.json"))
        {
            string dados = leitor.ReadToEnd();
            return JsonSerializer.Deserialize<List<Arma>>(dados);
        }
    }

   private List<Caracteristica> GetCaracteristicas()
    {
        using (StreamReader leitor = new("Data\\caracteristicas.json"))
        {
            string dados = leitor.ReadToEnd();
            return JsonSerializer.Deserialize<List<Caracteristica>>(dados);
        }
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
