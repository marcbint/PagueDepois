using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Repositorio;
using Repositorio.Entidades;

namespace WinFormsPagueDepois
{
    public partial class frmFormaPagamentoCon : Form
    {
        public frmFormaPagamentoCon()
        {
            InitializeComponent();
        }

        private void frmFormaPagamentoCon_Load(object sender, EventArgs e)
        {
            ExibirProdutos();
        }

        private void ExibirProdutos()
        {
            FormaPagamentoRepositorio<FormaPagamento> formaPagamentoRepo = new FormaPagamentoRepositorio<FormaPagamento>();
            dgvFormasPagamento.DataSource = formaPagamentoRepo.Consultar();

            //Add a CheckBox Column to the DataGridView at the first position.
            /*DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
            checkBoxColumn.HeaderText = "";
            checkBoxColumn.Width = 30;
            checkBoxColumn.Name = "checkBoxColumn";
            dgvProdutos.Columns.Insert(0, checkBoxColumn);*/
        }

        private void dgvFormasPagamento_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            int index = e.RowIndex;
            DataGridViewRow selectedRow = dgvFormasPagamento.Rows[index];

            string id = selectedRow.Cells[0].Value.ToString();

            //Abre a tela em processo de edição
            frmFormaPagamento frmFormaPagamento = new frmFormaPagamento();
            frmFormaPagamento.idFormaPagamento = Convert.ToInt32(id);
            frmFormaPagamento.ShowDialog();

            //Remonta o grid apos o process de edição ou exclusao.
            ExibirProdutos();



        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            frmFormaPagamento frmFormaPagamento = new frmFormaPagamento();
            frmFormaPagamento.ShowDialog();
            ExibirProdutos();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
