using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Entidades
{
    public class UsuarioPagamento
    {
        public virtual int? Id { get; set; }
        public virtual string Nome { get; set; }
        /*public virtual IList<Pedido> Pedido { get; set; }

        public UsuarioPagamento()
        {
            Pedido = new List<Pedido>();
        }*/
    }
}
