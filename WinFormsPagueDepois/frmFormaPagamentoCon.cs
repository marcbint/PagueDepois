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
            //ExibirProdutos();
            criaDataGrid();
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

        private void criaDataGrid()
        {
            FormaPagamentoRepositorio<FormaPagamento> repositorio = new FormaPagamentoRepositorio<FormaPagamento>();
            IList<FormaPagamento> objeto = repositorio.Consultar();

            var lista = objeto.Select(s => new {
                Id          = s.Id,
                Descricao   = s.Descricao,
                Tipo        = s.Tipo,
                Status      = s.Status
            }
                                        ).OrderBy(x => x.Descricao)
                                                     //.Sum(item => item.valor)
                                                     //.GroupBy(x => x.Id)
                                                     .ToList();

            dgvFormasPagamento.DataSource = lista;

            //Cria as colunas
            //DataGridViewCheckBoxColumn colChk = new DataGridViewCheckBoxColumn(); Deve ser criado pela tela
            DataGridViewTextBoxColumn colId         = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn colDescricao  = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn colTipo       = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn colSituacao   = new DataGridViewTextBoxColumn();

            //Nomeia os cabeçalhos
            dgvFormasPagamento.Columns[0].HeaderText = "Id";
            dgvFormasPagamento.Columns[1].HeaderText = "Descrição";
            dgvFormasPagamento.Columns[2].HeaderText = "Tipo";
            dgvFormasPagamento.Columns[3].HeaderText = "Situação";

            //Cores
            dgvFormasPagamento.GridColor = Color.Black;
            dgvFormasPagamento.ForeColor = Color.Black;


            this.dgvFormasPagamento.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvFormasPagamento.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFormasPagamento.MultiSelect = false;
            this.dgvFormasPagamento.Dock = DockStyle.Fill;

            //Já Existentes
            dgvFormasPagamento.ColumnHeadersDefaultCellStyle.BackColor = Color.LightSkyBlue;
            dgvFormasPagamento.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvFormasPagamento.ColumnHeadersDefaultCellStyle.Font = new Font(dgvFormasPagamento.Font, FontStyle.Bold);
            dgvFormasPagamento.ForeColor = Color.Black;


            dgvFormasPagamento.Name = "dgvFormasPagamento";
            dgvFormasPagamento.Location = new Point(8, 8);
            dgvFormasPagamento.Size = new Size(500, 250);
            dgvFormasPagamento.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            dgvFormasPagamento.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvFormasPagamento.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgvFormasPagamento.RowHeadersVisible = false;


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
            //ExibirProdutos();
            criaDataGrid();



        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            frmFormaPagamento frmFormaPagamento = new frmFormaPagamento();
            frmFormaPagamento.ShowDialog();
            //ExibirProdutos();
            criaDataGrid();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
