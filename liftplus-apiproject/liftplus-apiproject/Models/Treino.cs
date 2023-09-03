using System.ComponentModel.DataAnnotations.Schema;

namespace liftplus_apiproject.Models
{
    public class Treino
    {
        public int treinoId { get; set; }

        public string treinoNome { get; set; }

        public string grupoMusucular { get; set; }

        public DateOnly dataRegistro { get; set; }

        public string Status { get; set; }

        [ForeignKey("exeId")]
        public virtual Exercicio exercicioId { get; set; }

    }
}
