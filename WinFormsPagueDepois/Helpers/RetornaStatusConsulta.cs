using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsPagueDepois.Helpers
{
    public class RetornaStatusConsulta
    {
        

        public static string retornaStatusConsulta(char status)
        {
            if (status == '1')
            {
                return "ATIVO";
            }
            else if (status == '2')
            {
                return "INATIVO";
            }
            else
            {
                return "DESCONHECIDO";
            }
        }

        public static char retornaStatusInclusao(string status)
        {
            if (status == "ATIVO")
            {
                return '1';
            }
            else if (status == "INATIVO")
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
