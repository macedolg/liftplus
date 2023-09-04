using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace liftplus_apiproject.Models
{
    public class Treino
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string GrupoMuscular { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataRegistro { get; set; }
    }
 }
