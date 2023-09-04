using System.ComponentModel.DataAnnotations;

namespace liftplus_apiproject.Models
{
    public class Exercicio 
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Musculo { get; set; }

        public int? TreinoID { get; set; }

        public Treino Treino { get; set; }

    }
}
