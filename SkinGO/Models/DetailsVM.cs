namespace SkinGO.Models;

public class DetailsVM
{
    public Arma Anterior {get; set; }

    public Arma Atual { get; set; }

    public Arma Proximo { get; set;}

    public List<Caracteristica> Caracteristicas { get; set; }
}