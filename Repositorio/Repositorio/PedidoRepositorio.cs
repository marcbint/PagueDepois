using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NHibernate;
using NHibernate.Linq;
using Repositorio.Entidades;
using Repositorio.Enum;

namespace Repositorio
{
    public class PedidoRepositorio<T>:IPedido<T> where T:class
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
                        throw new Exception("Erro ao Alterar Pedido : " + ex.Message);
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

        public void InserirPedidoItem(Pedido pedido, IList<PedidoItem> pedidoItem)
        {
            using (ISession session = SessionFactory.AbrirSession())
            {
                using (ITransaction transacao = session.BeginTransaction())
                {
                    try
                    {
                        PedidoItemRepositorio<PedidoItem> repoPedidoItem = new PedidoItemRepositorio<PedidoItem>();
                        IList<PedidoItem> lstItens = new List<PedidoItem>();

                        session.SaveOrUpdate(pedido);

                        //session.FlushMode = NHibernate.FlushMode.Auto;

                        int novoId = pedido.Id;

                        //var query = (from t in session.Query<Pedido>() select t).ToList();

                        foreach(var pedidoItem2 in pedidoItem)
                        {
                            //Associa o id do pedido inserido na lista de itens
                            pedidoItem2.Pedido.Id = novoId;
                            lstItens.Add(pedidoItem2);

                        }

                        // Realiza o processo de inclusão de Itens do Pedido.
                        repoPedidoItem.InserirItens(lstItens);

                        //session.Save(lstItens);

                        transacao.Commit();
                        
                    }
                    catch (Exception ex)
                    {
                        if (!transacao.WasCommitted)
                        {
                            transacao.Rollback();
                        }
                        throw new Exception("Erro ao inserir Pedido : " + ex.Message);
                    }
                }
            }

        }

        public IList<Pedido> Consultar()
        {
            using (ISession session = SessionFactory.AbrirSession())
            {
                string sQuery = @"
                    SELECT
                        new Pedido(
                        pedido.Id,
                        pedido.Status
                        )
                    from Pedido pedido
                ";

                string sQuery2 = @"
                    SELECT
                        pedido.Id,
                        pedido.Status
                    from Pedido pedido
                ";

                string h_stmt = "FROM Pedido";

                string sQuery3 = @"
Select 
pedido
from Pedido pedido,
Cliente cliente,
FormaPagamento formaPagamento,
Usuario usuario,
PedidoItem pedidoItem
Where pedido.Cliente = cliente
AND pedido.FormaPagamento = formaPagamento
AND pedido.Usuario = usuario
AND pedidoItem.Pedido = pedido
";

                IQuery query = session.CreateQuery(sQuery3);

                var objeto = (from pedido in session.Query<Pedido>()
                              join cliente in session.Query<Cliente>() on pedido.Cliente.Id equals cliente.Id
                              join formaPagamento in session.Query<FormaPagamento>() on pedido.FormaPagamento.Id equals formaPagamento.Id
                              join usuario in session.Query<Usuario>() on pedido.Usuario.Id equals usuario.Id
                              //join pedidoItem in session.Query<PedidoItem>() on pedido.PedidoItem.
                              //where pedido.Cliente.NomeRazao == "Init" && pedido.FormaPagamento.Descricao.Contains("Purpose Sample")
                              select pedido).ToList();

                IList<Pedido> pedidos = new List<Pedido>();

                          

                pedidos = query.List<Pedido>();

                string[] grid = new string[2];

                grid[0] = "Param1";
                grid[1] = "Param2";

                //return pedidos;
                return objeto;
            }
        }

        public IList<Pedido> Pesquisar(string nomeRazao, SituacaoPedido situacao, DateTime previsaoPagamento, DateTime pagamento, DateTime cancelamento, string ano, string mes )
        {
            using (ISession session = SessionFactory.AbrirSession())
            {
                string sQuery = @"
                    SELECT
                        new Pedido(
                        pedido.Id,
                        pedido.Status
                        )
                    from Pedido pedido
                ";

                string sQuery2 = @"
                    SELECT
                        pedido.Id,
                        pedido.Status
                    from Pedido pedido
                ";

                string h_stmt = "FROM Pedido";

                string sQuery3 = @"
                                    Select 
                                        pedido
                                    from Pedido pedido,
                                        Cliente cliente,
                                        FormaPagamento formaPagamento,
                                        Usuario usuario,
                                        PedidoItem pedidoItem
                                    Where pedido.Cliente = cliente
                                    AND pedido.FormaPagamento = formaPagamento
                                    AND pedido.Usuario = usuario
                                    AND pedidoItem.Pedido = pedido";
                                    //AND pedido.Id = " + idPedido;

                IQuery query = session.CreateQuery(sQuery3);

                IList<Pedido> objetoRetorno = new List<Pedido>();

                if (Convert.ToInt32(situacao) == 1)
                {

                    if (Convert.ToInt32(situacao) == 1 && ano != string.Empty && mes != string.Empty) // Pendente
                    {
                        var objetoPendenteAnoMes = (from pedido in session.Query<Pedido>()
                                                    join cliente in session.Query<Cliente>() on pedido.Cliente.Id equals cliente.Id
                                                    join formaPagamento in session.Query<FormaPagamento>() on pedido.FormaPagamento.Id equals formaPagamento.Id
                                                    join usuario in session.Query<Usuario>() on pedido.Usuario.Id equals usuario.Id
                                                    //join pedidoItem in session.Query<PedidoItem>() on pedido.PedidoItem.
                                                    //where pedido.Cliente.NomeRazao == "Init" && pedido.FormaPagamento.Descricao.Contains("Purpose Sample")
                                                    where pedido.Cliente.NomeRazao.Contains(nomeRazao)
                                                    //&& ((pedido.Status & SituacaoPedido.PAGO) == SituacaoPedido.PAGO)
                                                    && Convert.ToInt32(pedido.Status) == Convert.ToInt32(situacao)
                                                    && pedido.Data_Previsao_Pagamento.Year == Convert.ToInt32(ano)
                                                    && pedido.Data_Previsao_Pagamento.Month == Convert.ToInt32(mes)
                                                    select pedido).ToList();
                        objetoRetorno = objetoPendenteAnoMes;


                    }
                    else
                    {
                        var objetoPendenteDia = (from pedido in session.Query<Pedido>()
                                                 join cliente in session.Query<Cliente>() on pedido.Cliente.Id equals cliente.Id
                                                 join formaPagamento in session.Query<FormaPagamento>() on pedido.FormaPagamento.Id equals formaPagamento.Id
                                                 join usuario in session.Query<Usuario>() on pedido.Usuario.Id equals usuario.Id
                                                 //join pedidoItem in session.Query<PedidoItem>() on pedido.PedidoItem.
                                                 //where pedido.Cliente.NomeRazao == "Init" && pedido.FormaPagamento.Descricao.Contains("Purpose Sample")
                                                 where pedido.Cliente.NomeRazao.Contains(nomeRazao)
                                                 //&& ((pedido.Status & SituacaoPedido.PAGO) == SituacaoPedido.PAGO)
                                                 && Convert.ToInt32(pedido.Status) == Convert.ToInt32(situacao)
                                                 //&& pedido.Data_Previsao_Pagamento.Year == 2018
                                                 //&& pedido.Data_Previsao_Pagamento.Month == 03
                                                 //&& pedido.Data_Previsao_Pagamento.Year + pedido.Data_Previsao_Pagamento.Month == 201803
                                                 && pedido.Data_Previsao_Pagamento.Date == previsaoPagamento.Date
                                                 select pedido).ToList();
                        objetoRetorno = objetoPendenteDia;
                    }
                }
                else if (Convert.ToInt32(situacao) == 2)
                {
                    if (Convert.ToInt32(situacao) == 2 && ano != string.Empty && mes != string.Empty) // Pago
                    {
                        var objetoPagoAnoMes = (from pedido in session.Query<Pedido>()
                                                join cliente in session.Query<Cliente>() on pedido.Cliente.Id equals cliente.Id
                                                join formaPagamento in session.Query<FormaPagamento>() on pedido.FormaPagamento.Id equals formaPagamento.Id
                                                join usuario in session.Query<Usuario>() on pedido.Usuario.Id equals usuario.Id
                                                //join pedidoItem in session.Query<PedidoItem>() on pedido.PedidoItem.
                                                //where pedido.Cliente.NomeRazao == "Init" && pedido.FormaPagamento.Descricao.Contains("Purpose Sample")
                                                where pedido.Cliente.NomeRazao.Contains(nomeRazao)
                                                && Convert.ToInt32(pedido.Status) == Convert.ToInt32(situacao)
                                                && pedido.Data_Pagamento.Value.Year == Convert.ToInt32(ano)
                                                && pedido.Data_Pagamento.Value.Month == Convert.ToInt32(mes)
                                                select pedido).ToList();
                        objetoRetorno = objetoPagoAnoMes;
                    }
                    else
                    {
                        var objetoPago = (from pedido in session.Query<Pedido>()
                                          join cliente in session.Query<Cliente>() on pedido.Cliente.Id equals cliente.Id
                                          join formaPagamento in session.Query<FormaPagamento>() on pedido.FormaPagamento.Id equals formaPagamento.Id
                                          join usuario in session.Query<Usuario>() on pedido.Usuario.Id equals usuario.Id
                                          //join pedidoItem in session.Query<PedidoItem>() on pedido.PedidoItem.
                                          //where pedido.Cliente.NomeRazao == "Init" && pedido.FormaPagamento.Descricao.Contains("Purpose Sample")
                                          where pedido.Cliente.NomeRazao.Contains(nomeRazao)
                                          && Convert.ToInt32(pedido.Status) == Convert.ToInt32(situacao)
                                          && pedido.Data_Pagamento.Value.Date == pagamento.Date
                                          select pedido).ToList();
                        objetoRetorno = objetoPago;
                    }
                }
                else if (Convert.ToInt32(situacao) == 3)
                {
                    // Cancelados
                    if (Convert.ToInt32(situacao) == 3 && ano != string.Empty && mes != string.Empty)
                    {
                        var objetoPendenteAnoMes = (from pedido in session.Query<Pedido>()
                                                    join cliente in session.Query<Cliente>() on pedido.Cliente.Id equals cliente.Id
                                                    join formaPagamento in session.Query<FormaPagamento>() on pedido.FormaPagamento.Id equals formaPagamento.Id
                                                    join usuario in session.Query<Usuario>() on pedido.Usuario.Id equals usuario.Id
                                                    //join pedidoItem in session.Query<PedidoItem>() on pedido.PedidoItem.
                                                    //where pedido.Cliente.NomeRazao == "Init" && pedido.FormaPagamento.Descricao.Contains("Purpose Sample")
                                                    where pedido.Cliente.NomeRazao.Contains(nomeRazao)
                                                    //&& ((pedido.Status & SituacaoPedido.PAGO) == SituacaoPedido.PAGO)
                                                    && Convert.ToInt32(pedido.Status) == Convert.ToInt32(situacao)
                                                    && pedido.Data_Cancelamento.Value.Year == Convert.ToInt32(ano)
                                                    && pedido.Data_Cancelamento.Value.Month == Convert.ToInt32(mes)
                                                    //&& pedido.Data_Previsao_Pagamento.Year + pedido.Data_Previsao_Pagamento.Month == 201803
                                                    //&& pedido.Data_Previsao_Pagamento.Date == previsaoPagamento.Date
                                                    select pedido).ToList();
                        objetoRetorno = objetoPendenteAnoMes;


                    }
                    else
                    {
                        var objetoPendenteDia = (from pedido in session.Query<Pedido>()
                                                 join cliente in session.Query<Cliente>() on pedido.Cliente.Id equals cliente.Id
                                                 join formaPagamento in session.Query<FormaPagamento>() on pedido.FormaPagamento.Id equals formaPagamento.Id
                                                 join usuario in session.Query<Usuario>() on pedido.Usuario.Id equals usuario.Id
                                                 //join pedidoItem in session.Query<PedidoItem>() on pedido.PedidoItem.
                                                 //where pedido.Cliente.NomeRazao == "Init" && pedido.FormaPagamento.Descricao.Contains("Purpose Sample")
                                                 where pedido.Cliente.NomeRazao.Contains(nomeRazao)
                                                 //&& ((pedido.Status & SituacaoPedido.PAGO) == SituacaoPedido.PAGO)
                                                 && Convert.ToInt32(pedido.Status) == Convert.ToInt32(situacao)
                                                 //&& pedido.Data_Previsao_Pagamento.Year == 2018
                                                 //&& pedido.Data_Previsao_Pagamento.Month == 03
                                                 //&& pedido.Data_Previsao_Pagamento.Year + pedido.Data_Previsao_Pagamento.Month == 201803
                                                 && pedido.Data_Cancelamento.Value.Date == cancelamento.Date
                                                 select pedido).ToList();
                        objetoRetorno = objetoPendenteDia;
                    }
                }


                IList<Pedido> pedidos = new List<Pedido>();



                pedidos = query.List<Pedido>();

                string[] grid = new string[2];

                grid[0] = "Param1";
                grid[1] = "Param2";

                //return pedidos;
                return objetoRetorno;
            }
        }

    }
}
