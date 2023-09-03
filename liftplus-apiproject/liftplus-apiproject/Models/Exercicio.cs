using System.ComponentModel.DataAnnotations;

namespace liftplus_apiproject.Models
{
    public class Exercicio : Treino
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Musculo { get; set; }

        // Propriedade de chave estrangeira para o relacionamento com Treino
        public int TreinoID { get; set; }

        // Propriedade de navegação para o relacionamento com Treino
        public Treino Treino { get; set; }

    }
}
