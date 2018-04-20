using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FluentNHibernate.Mapping;
using Repositorio.Entidades;

namespace Repositorio.Mapeamento
{
    public class ProdutoMap : ClassMap<Produto>
    {
        public ProdutoMap()
        {
            Id(c => c.Id);
            Map(c => c.Codigo);
            Map(c => c.Descricao);
            Map(c => c.Valor);
            Map(c => c.Status);
            Table("produtos");
        }
    }
}
