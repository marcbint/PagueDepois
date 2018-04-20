using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Repositorio.Enum
{
    public enum TipoPessoa
    {
        [Description("FÍSICA")]
        FÍSICA = 1,
        [Description("JURÍDICA")]
        JURÍDICA = 2,
        [Description("DESCONHECIDO")]
        DESCONHECIDO = 3
    }
}
