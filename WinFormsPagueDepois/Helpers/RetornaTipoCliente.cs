using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsPagueDepois.Helpers
{
    public class RetornaTipoCliente
    {
        public static string retornaTipoClienteConsulta(char tipo)
        {
            if (tipo == '1')
            {
                return "FÍSICA";
            }
            else if (tipo == '2')
            {
                return "JURÍDICA";
            }
            else
            {
                return "DESCONHECIDO";
            }
        }

        public static char retornaTipoClienteInclusao(string tipo)
        {
            if (tipo == "FÍSICA")
            {
                return '1';
            }
            else if (tipo == "JURÍDICA")
            {
                return '2';
            }
            else
            {
                return '0';
            }
        }
    }
}
