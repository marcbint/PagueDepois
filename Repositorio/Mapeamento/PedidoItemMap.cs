using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FluentNHibernate.Mapping;
using Repositorio.Entidades;

namespace Repositorio.Mapeamento
{
    public class PedidoItemMap:ClassMap<PedidoItem>
    {
        public PedidoItemMap()
        {
            Id(c => c.Id);
            Map(c => c.Quantidade);
            Map(c => c.Valor_Unitario);
            Map(c => c.Valor_Total);
            References(c => c.Pedido).Column("id_pedido").Not.LazyLoad(); //Id da tabela Pedido
            References(c => c.Produto).Column("id_produto").Not.LazyLoad();
            Table("pedido_itens");
        }
    }
}
