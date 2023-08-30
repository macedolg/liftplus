using System.ComponentModel;

namespace liftplus_apiproject.Enum
{
    public enum StatusExercicio
    {
        [Description("A fazer")]
        Afazer = 1,
        [Description("Em andamento")]
        Andamento = 2,
        [Description("Concluído")]
        Concluido = 3
    }
}
