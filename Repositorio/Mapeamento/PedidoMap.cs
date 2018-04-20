using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Repositorio.Entidades;
using FluentNHibernate.Mapping;
using Repositorio.Enum;

namespace Repositorio.Mapeamento
{
    public class PedidoMap:ClassMap<Pedido>
    {
        public PedidoMap()
        {
            // Mesmas informações da base de dados e da classe do mapeamento.
            Id(c => c.Id);
            //Map(c => c.Id_Usuario_Inclusao);
            Map(c => c.Data_Inclusao);
            Map(c => c.Data_Previsao_Pagamento);
            //Map(c => c.Id_Usuario_Pagamento);
            Map(c => c.Data_Pagamento);
            Map(c => c.Data_Registro_Pagamento);
            //Map(c => c.Status);
            Map(c => c.Status).CustomType<SituacaoPedido>();
            Map(c => c.Valor_Total);
            Map(c => c.Motivo_Cancelamento);
            //Map(c => c.Id_Cliente);
            //Map(c => c.Id_Forma_Pagamento);
            References(c => c.Cliente).Column("id_cliente").Not.LazyLoad(); //atributo tabela pedido
            References(c => c.FormaPagamento).Column("id_forma_pagamento").Not.LazyLoad(); //atributo tabela pedido
            References(c => c.Usuario).Column("id_usuario_atualizacao").Not.LazyLoad(); //atributo tabela pedido.
            //References(c => c.UsuarioPagamento).Column("id_usuario_pagamento").Not.LazyLoad(); //atributo tabela pedido.
            //References(c => c.UsuarioPagamento).Class<Usuario>().Nullable().NotFound.Ignore().PropertyRef("id_usuario_inclusao");
            HasMany(c => c.PedidoItem).KeyColumn("id_pedido").Not.LazyLoad();
            Table("pedidos");

        }
    }
}
