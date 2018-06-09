using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Repositorio.Enum
{
    public enum TipoPagamento
    {
        
            [Description("DINHEIRO")] DINHEIRO = 1,
            [Description("CARTÃO")] CARTAO = 2,
            [Description("CHEQUE")] CHEQUE = 3

        
    }
}
