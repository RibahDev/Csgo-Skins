namespace Pokedex.Models;

public class DetailsVM
{
    public Skins Anterior {get; set; }

    public Skins Atual { get; set; }

    public Skins Proximo { get; set;}

    public List<Caracteristica> Caracteristicas { get; set; }
}