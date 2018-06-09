using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NHibernate;
using NHibernate.Linq;
using Repositorio.Entidades;
using Repositorio.Enum;

namespace Repositorio
{
    public class ProdutoRepositorio<T> : IProduto<T> where T : class
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
                        transacao.Commit();
                    }
                    catch (Exception ex)
                    {
                        if (!transacao.WasCommitted)
                        {
                            transacao.Rollback();
                        }
                        throw new Exception("Erro ao inserir Produto : " + ex.Message);
                    }
                }
            }
        }

        public void Alterar(T entidade)
        {
            using (ISession session = SessionFactory.AbrirSession())
            {
                using (ITransaction transacao = session.BeginTransaction())
                {
                    try
                    {
                        session.Update(entidade);
                        transacao.Commit();
                    }
                    catch (Exception ex)
                    {
                        if (!transacao.WasCommitted)
                        {
                            transacao.Rollback();
                        }
                        throw new Exception("Erro ao Alterar Produto : " + ex.Message);
                    }
                }
            }
        }

        public void Excluir(T entidade)
        {
            using (ISession session = SessionFactory.AbrirSession())
            {
                using (ITransaction transacao = session.BeginTransaction())
                {
                    try
                    {
                        session.Delete(entidade);
                        transacao.Commit();
                    }
                    catch (Exception ex)
                    {
                        if (!transacao.WasCommitted)
                        {
                            transacao.Rollback();
                        }
                        throw new Exception("Erro ao Excluir Produto : " + ex.Message);
                    }
                }
            }
        }

        public T RetornarPorId(int Id)
        {
            using (ISession session = SessionFactory.AbrirSession())
            {
                return session.Get<T>(Id);
            }
        }

        public IList<T> Consultar()
        {
            using (ISession session = SessionFactory.AbrirSession())
            {
                return (from c in session.Query<T>() select c).ToList();
            }
        }

        public IList<Produto> Pesquisar(string paramProduto, Situacao situacao)
        {
            using (ISession session = SessionFactory.AbrirSession())
            {

                IList<Produto> objetoRetorno = new List<Produto>();

                var objetoProduto = (from produto in session.Query<Produto>()
                                     where produto.Descricao.Contains(paramProduto)
                                     && Convert.ToInt32(produto.Status) == Convert.ToInt32(situacao)
                                     select produto).ToList();
                objetoRetorno = objetoProduto;


                return objetoRetorno;
            }
        }
    }
}
