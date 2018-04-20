using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsPagueDepois.Helpers
{
    public class RetornaTipoFormaPagamento
    {
        public static string retornaTipoFormaPagamentoConsulta(char tipo)
        {
            if(tipo == '1')
            {
                return "DINHEIRO";
            }
            else if(tipo == '2')
            {
                return "CARTÃO";
            }
            else if(tipo == '3')
            {
                return "CHEQUE";
            }
            else
            {
                return "DESCONHECIDO";
            }
        }

        public static char retornaTipoFormaPagamentoInclusao(string tipo)
        {
            if(tipo == "DINHEIRO")
            {
                return '1';
            }
            else if(tipo == "CARTÃO")
            {
                return '2';
            }
            else if(tipo == "CHEQUE")
            {
                return '3';
            }
            else
            {
                return '0';
            }
        }
    }
}
