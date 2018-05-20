using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositorio.Enum;

namespace Repositorio.Entidades
{
    public class Produto
    {
        public virtual int Id { get; set; }

        public virtual string Codigo { get; set; }

        public virtual string Descricao { get; set; }

        public virtual decimal Valor { get; set; }

        //public virtual char Status { get; set; }
        public virtual Situacao Status { get; set; }
    }
}
