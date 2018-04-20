using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Entidades
{
    public class PedidoItem
    {
        public virtual int Id { get; set; }
        public virtual int Quantidade { get; set; }
        public virtual decimal Valor_Unitario { get; set; }
        public virtual decimal Valor_Total { get; set; }

        public virtual Pedido Pedido { get; set; }
        public virtual Produto Produto { get; set; }

        public PedidoItem()
        {
            Pedido = new Pedido();
            Produto = new Produto();
        }
    }
}
