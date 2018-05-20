using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositorio.Enum;

namespace Repositorio.Entidades
{
    public class Usuario
    {
        public virtual int Id { get; set; }
        public virtual string Nome { get; set; }
        public virtual string Login { get; set; }
        public virtual string Senha { get; set; }
        //public virtual char Status { get; set; }
        public virtual Situacao Status { get; set; }
        //public virtual IList<Pedido> Pedido { get; set; }

        public Usuario()
        {
            //Pedido = new List<Pedido>();
        }
    }
}
