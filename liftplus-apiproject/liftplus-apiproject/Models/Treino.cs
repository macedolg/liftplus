namespace liftplus_apiproject.Models
{
    public class Treino
    {
        public int treinoId { get; set; }

        public string treinoNome { get; set; }

        public string grupoMusucular { get; set; }

        public DateOnly dataRegistro { get; set; }

    }
}
