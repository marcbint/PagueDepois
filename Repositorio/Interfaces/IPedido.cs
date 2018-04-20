using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio
{
    public interface IPedido<T>
    {

        void Inserir(T entidade);

        void Alterar(T entidade);

        //void InserirPedidoItem(T pedido, IList<T> pedidoItem);


    }
}
