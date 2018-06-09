using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsPagueDepois
{
    public partial class frmMenu : Form
    {
        public int idUsuario;
        public frmMenu()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            frmProdutoCon produto = new frmProdutoCon();
            produto.ShowDialog();
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {
            Controls.OfType<MdiClient>().FirstOrDefault().BackColor = Color.DodgerBlue;
        }

        private void btnFormaPagamento_Click(object sender, EventArgs e)
        {
            frmFormaPagamentoCon frmCondPagamentoCon = new frmFormaPagamentoCon();
            frmCondPagamentoCon.ShowDialog();
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            frmRegistroCon frmRegistroCon = new frmRegistroCon();
            frmRegistroCon.ShowDialog();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            frmClienteCon frmClienteCon = new frmClienteCon();
            frmClienteCon.ShowDialog();
        }

        private void btnPedido_Click(object sender, EventArgs e)
        {
            frmPedido frmPedido = new frmPedido();
            frmPedido.ShowDialog();
        }

        private void btnRelatorioPedidos_Click(object sender, EventArgs e)
        {
            frmPedidoCon frmPedidoCon = new frmPedidoCon();
            frmPedidoCon.ShowDialog();
        }
    }
}
