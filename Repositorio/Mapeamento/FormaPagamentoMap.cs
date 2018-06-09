using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using FluentNHibernate.Mapping;
using Repositorio.Entidades;
using Repositorio.Enum;

namespace Repositorio.Mapeamento
{
    public class FormaPagamentoMap : ClassMap<FormaPagamento>
    {
        public FormaPagamentoMap()
        {
            Id(c => c.Id);
            Map(c => c.Descricao);
            //Map(c => c.Tipo);
            Map(c => c.Tipo).CustomType<TipoPagamento>();
            //Map(c => c.Status);
            Map(c => c.Status).CustomType<Situacao>();
            Table("formas_pagamento");   
        }
    }
}
