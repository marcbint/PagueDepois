using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Repositorio.Enum
{
    public enum Situacao
    {
        [Description("ATIVO")]
        ATIVO = 1,
        [Description("INATIVO")]
        INATIVO = 2

    }
}
