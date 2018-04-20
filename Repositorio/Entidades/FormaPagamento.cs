using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Entidades
{
    public class FormaPagamento
    {
        public virtual int Id { get; set; }
        public virtual string Descricao { get; set; }
        public virtual char Tipo { get; set; }
        public virtual char Status { get; set; }
    }
}
