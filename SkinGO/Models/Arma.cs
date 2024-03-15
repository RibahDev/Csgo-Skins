using System.Security.Cryptography.X509Certificates;


namespace SkinGO.Models;
    public class Arma
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