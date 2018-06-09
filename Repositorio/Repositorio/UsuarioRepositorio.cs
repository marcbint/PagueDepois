using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Repositorio.Entidades;
using NHibernate;
using NHibernate.Linq;

namespace Repositorio
{
    public class UsuarioRepositorio<T> : IUsuario<T> where T : class
    {
        public bool ValidarLogin(string login)
        {
            using (ISession session = SessionFactory.AbrirSession())
            {
                return (from e in session.Query<Usuario>() where e.Login.Equals(login) select e).Count() > 0;
            }
        }

        public bool ValidarAcesso(string login, string senha)
        {
            using (ISession session = SessionFactory.AbrirSession())
            {
                return (from e in session.Query<Usuario>() where e.Login.Equals(login) && e.Senha.Equals(senha) select e).Count() > 0;
            }
        }


        public IList<Usuario> ConsultaPorAcesso(string login, string senha)
        {
            using (ISession session = SessionFactory.AbrirSession())
            {


                var usuarios = session.Query<Usuario>()
                                         .Where(p => p.Login == login && p.Senha == senha )
                                         .ToList();

                return usuarios;
            }
        }


        public IList<Usuario> ConsultaUsuario(string login)
        {
            using (ISession session = SessionFactory.AbrirSession())
            {


                var usuarios = session.Query<Usuario>()
                                         .Where(p => p.Login == login)
                                         .ToList();

                return usuarios;
            }
        }

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
                        throw new Exception("Erro ao inserir Cliente : " + ex.Message);
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
                        throw new Exception("Erro ao Alterar Cliente : " + ex.Message);
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
                        throw new Exception("Erro ao Excluir Cliente : " + ex.Message);
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
    }
}
