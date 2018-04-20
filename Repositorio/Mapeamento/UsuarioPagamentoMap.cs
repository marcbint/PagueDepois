using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FluentNHibernate.Mapping;
using Repositorio.Entidades;

namespace Repositorio.Mapeamento
{
    public class UsuarioPagamentoMap : ClassMap<UsuarioPagamento>
    {
        public UsuarioPagamentoMap()
        {
            Id(c => c.Id);
            Map(c => c.Nome);
            Table("usuarios");
        }
    }
}
