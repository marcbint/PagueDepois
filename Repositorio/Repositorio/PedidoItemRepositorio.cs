using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Repositorio;
using NHibernate;

namespace Repositorio
{
    public class PedidoItemRepositorio<T>:IPedidoItem<T>where T:class
    {
        public void Inserir(T entidade)
        {
            using (ISession session = SessionFactory.AbrirSession())
            {
                using (ITransaction transacao = session.BeginTransaction())
                {
                    try
                    {
                        session.Save(entidade);
                        //Inserir os itens do pedido

                        transacao.Commit();
                    }
                    catch (Exception ex)
                    {
                        if (!transacao.WasCommitted)
                        {
                            transacao.Rollback();
                        }
                        throw new Exception("Erro ao inserir itens do pedido : " + ex.Message);
                    }
                }
            }
        }

        public void InserirItens(IList<T> entidade)
        {
            using (ISession session = SessionFactory.AbrirSession())
            {
                using (ITransaction transacao = session.BeginTransaction())
                {
                    try
                    {
                        //session.FlushMode = NHibernate.FlushMode.Auto;
                        foreach (var obj in entidade)
                        {
                            //session.Flush();
                            session.SaveOrUpdate(obj);
                            
                            
                        }

                        //session.Save(entidade);
                        //Inserir os itens do pedido
                        
                        transacao.Commit();
                    }
                    catch (Exception ex)
                    {
                        if (!transacao.WasCommitted)
                        {
                            transacao.Rollback();
                        }
                        throw new Exception("Erro ao inserir itens do pedido : " + ex.Message);
                    }
                }
            }
        }



    }
}
