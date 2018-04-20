using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;


namespace Repositorio.Enum
{
    public enum SituacaoPedido
    {
        [Description("PENDENTE")] PENDENTE = 1,
        [Description("PAGO")] PAGO = 2,
        [Description("CANCELADO")] CANCELADO = 3

    }
}
