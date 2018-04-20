using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Repositorio.Entidades;
using Repositorio.Enum;
using FluentNHibernate.Mapping;

namespace Repositorio.Mapeamento
{
    public class ClienteMap:ClassMap<Cliente>
    {
        public ClienteMap()
        {
            Id(c => c.Id);
            Map(c => c.Documento);
            //Map(c => c.Tipo);
            Map(c => c.Tipo).CustomType<TipoPessoa>();
            Map(c => c.NomeRazao);
            Map(c => c.Endereco);
            Map(c => c.Numero);
            Map(c => c.Complemento);
            Map(c => c.Cep);
            Map(c => c.Uf);
            Map(c => c.Cidade);
            Map(c => c.Ddd);
            Map(c => c.Telefone);
            Map(c => c.Email);
            Map(c => c.Contato);
            //Map(c => c.Status);
            Map(c => c.Status).CustomType<Situacao>();
            Table("clientes");
        }
    }
}
