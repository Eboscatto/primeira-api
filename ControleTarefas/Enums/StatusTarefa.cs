using System.ComponentModel;

namespace ControleTarefas.Enums
{
    public enum StatusTarefa
    {
        [Description("A fazer")]
        AFazer = 1,

        [Description("Em andamento")]
        EmAdamento = 2,

        [Description("Concluído")]
        Concluido = 3
    }
}
