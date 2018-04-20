using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NHibernate;
using NHibernate.Linq;

namespace Repositorio
{
    public class FormaPagamentoRepositorio<T>:IFormaPagamento<T> where T : class
    {
        public void Inserir(T entidade)
        {
            using (NHibernate.ISession session = SessionFactory.AbrirSession())
            {
                using (NHibernate.ITransaction transacao = session.BeginTransaction())
                {
                    try
                    {
                        session.Save(entidade);
                        transacao.Commit();
                    }
                    catch(Exception ex)
                    {
                        if (!transacao.WasCommitted)
                        {
                            transacao.Rollback();
                        }
                        throw new Exception("Erro ao inserir Forma Pagamento : " + ex.Message);
                    }
                }
            }
        }

        public void Alterar(T entidade)
        {
            using(NHibernate.ISession session = SessionFactory.AbrirSession())
            {
                using(ITransaction transacao = session.BeginTransaction())
                {
                    try
                    {
                        session.Update(entidade);
                        transacao.Commit();
                    }
                    catch(Exception ex)
                    {
                        if (!transacao.WasCommitted)
                        {
                            transacao.Rollback();
                        }
                        throw new Exception("Erro ao Alterar Forma de Pagamento : " + ex.Message);
                    }
                }
            }
        }

        public void Excluir(T entidade)
        {
            using(NHibernate.ISession session = SessionFactory.AbrirSession())
            {
                using(NHibernate.ITransaction transacao = session.BeginTransaction())
                {
                    try
                    {
                        session.Delete(entidade);
                        transacao.Commit();
                    }
                    catch(Exception ex)
                    {
                        if (!transacao.WasCommitted)
                        {
                            transacao.Rollback();
                        }
                        throw new Exception("Erro ao excluir Forma de Pagamento : " + ex.Message);
                    }
                }
            }
        }

        public T RetornarPorId(int Id)
        {
            using(NHibernate.ISession session = SessionFactory.AbrirSession())
            {
                return session.Get<T>(Id);
            }
        }

        public IList<T> Consultar()
        {
            using (NHibernate.ISession session = SessionFactory.AbrirSession())
            {
                return (from c in session.Query<T>() select c).ToList();
            }
        }
    }
}
