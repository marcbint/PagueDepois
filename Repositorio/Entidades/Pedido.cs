using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositorio.Enum;

namespace Repositorio.Entidades
{
    public class Pedido
    {
        //O nome das propriedades devem ser iguais as informações da base de dados da classe.
        public virtual int Id { get; set; }
        //public virtual int Id_Usuario_Inclusao { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual DateTime Data_Inclusao { get; set; }
        public virtual DateTime Data_Previsao_Pagamento { get; set; }

        //public virtual int Id_Usuario_Pagamento { get; set; }
        //public virtual UsuarioPagamento UsuarioPagamento { get; set; }
        public virtual DateTime? Data_Pagamento { get; set; } // ? Pode ser nulo
        public virtual DateTime? Data_Cancelamento { get; set; } // ? Pode ser nulo
        public virtual DateTime? Data_Registro_Pagamento { get; set; } // ? Pode ser nulo
        //public virtual string Status { get; set; }
        public virtual SituacaoPedido Status { get; set; }
        public virtual Cliente Cliente { get; set; }
        //public virtual int Id_Cliente { get; set; }
        //public virtual int Id_Forma_Pagamento { get; set; }
        public virtual FormaPagamento FormaPagamento { get; set; }

        public virtual IList<PedidoItem> PedidoItem { get; set; }

        public virtual decimal Valor_Total { get; set; }

        public virtual string Motivo_Cancelamento { get; set; }

        //Cria a instância das classes relacionadas.
        public Pedido()
        {
            Cliente = new Cliente();
            FormaPagamento = new FormaPagamento();
            PedidoItem = new List<PedidoItem>();
            Usuario = new Usuario();
            //UsuarioPagamento = new UsuarioPagamento();
        }
    }
}
