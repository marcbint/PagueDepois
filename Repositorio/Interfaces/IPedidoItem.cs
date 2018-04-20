using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio
{
    public interface IPedidoItem<T>
    {
        void Inserir(T entidade);

        void InserirItens(IList<T> entidade);
    }
}
