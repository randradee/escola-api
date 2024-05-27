using System.ComponentModel;

namespace EscolaApi.Domain.Enums
{
    public enum ECargo
    {
        [Description("Administrador")]
        ADMIN,

        [Description("Gestor Escolar")]
        GE,

        [Description("Professor")]
        PROFESSOR,

        [Description("Aluno")]
        ALUNO,
    }
}
