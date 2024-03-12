namespace SkinGO.Models;
    public class Skins
    {
        public int Numero { get; set; }

        public string Nome {get; set; }

        public string Descricao { get; set; }

        public string Tipo { get; set; }

        public List<string> Caracteristica { get; set; }

        public double Dano { get; set; }

        public string Alcance { get; set; }

        public string Imagem { get; set; }
    }