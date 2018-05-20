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
    public class UsuarioMap : ClassMap<Usuario>
    {
        public UsuarioMap()
        {
            Id(c => c.Id);
            Map(c => c.Nome);
            Map(c => c.Login);
            Map(c => c.Senha);
            //Map(c => c.Status);
            Map(c => c.Status).CustomType<Situacao>();
            Table("usuarios");
        }
    }
}
