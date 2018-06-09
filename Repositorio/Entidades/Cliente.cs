using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositorio.Enum;

namespace Repositorio.Entidades
{
    public class Cliente
    {
        public virtual int Id { get; set; }
        public virtual string Documento { get; set; }
        //public virtual char Tipo { get; set; }
        public virtual TipoPessoa Tipo { get; set; }
        public virtual string NomeRazao { get; set; }
        public virtual string Endereco { get; set; }
        public virtual string Numero { get; set; }
        public virtual string Complemento { get; set; }
        public virtual string Cep { get; set; }
        public virtual string Bairro { get; set; }
        public virtual string Uf { get; set; }
        public virtual string Cidade { get; set; }
        public virtual string Ddd { get; set; }
        public virtual string Telefone { get; set; }
        public virtual string Email { get; set; }
        public virtual string Contato { get; set; }
        //public virtual char Status { get; set; }

        public virtual Situacao Status { get; set; }

    }
}
