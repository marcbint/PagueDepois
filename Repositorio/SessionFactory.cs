using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;

namespace Repositorio
{
    public class SessionFactory
    {
        private static string ConnectionString = "Server=127.0.0.1; Port=5432; User Id=postgres; Password=casa2010; Database=paguedepois";
        private static ISessionFactory session;

        public static ISessionFactory CriarSession()
        {
            if (session != null)
                return session;

            IPersistenceConfigurer configDB = PostgreSQLConfiguration.PostgreSQL82.ConnectionString(ConnectionString);

            var configMap = Fluently.Configure()
                .Database(configDB)
                .Mappings(c => 
                        c.FluentMappings
                        .AddFromAssemblyOf<Mapeamento.UsuarioMap>()
                        .AddFromAssemblyOf<Mapeamento.ProdutoMap>()
                        .AddFromAssemblyOf<Mapeamento.FormaPagamentoMap>()
                        .AddFromAssemblyOf<Mapeamento.ClienteMap>()
                        .AddFromAssemblyOf<Mapeamento.PedidoMap>()
                        .AddFromAssemblyOf<Mapeamento.PedidoMap>()
                        );

            session = configMap.BuildSessionFactory();

            return session; 
        }

        public static ISession AbrirSession()
        {
            return CriarSession().OpenSession();
        }
    }
}
