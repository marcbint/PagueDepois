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
using System.Globalization;
using Repositorio.Enum;

namespace WinFormsPagueDepois
{
    public partial class frmProdutoCon : Form
    {
        Situacao situacao;



        public frmProdutoCon()
        {
            InitializeComponent();
        }
 

        private void frmProducoCon_Load(object sender, EventArgs e)
        {
            LoadSituacaoCombo<Situacao>(cboSituacao);

            //criaDataGrid();
            
        }

        private void dgvProdutos_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            int index = e.RowIndex;

            //Se diferente do cabeçalho
            if (index != -1)
            {
                DataGridViewRow selectedRow = dgvProdutos.Rows[index];

                string id = selectedRow.Cells[0].Value.ToString();

                //Abre a tela em processo de edição
                frmProduto frmProduto = new frmProduto();
                frmProduto.idProduto = Convert.ToInt32(id);
                frmProduto.ShowDialog();

                //Remonta o grid apos o process de edição ou exclusao.
                //ExibirProdutos();
                criaDataGrid();
            }

            

        }

        private void criaDataGrid() {

            ProdutoRepositorio<Produto> repositorio = new ProdutoRepositorio<Produto>();
            IList<Produto> objeto = repositorio.Consultar();

            var lista = objeto.Select(s => new {
                Id          = s.Id,
                Codigo      = s.Codigo,
                Descricao   = s.Descricao,
                Valor       = s.Valor,
                Status      = s.Status
            }
                                        ).OrderBy(x => x.Descricao)
                                                     //.Sum(item => item.valor)
                                                     //.GroupBy(x => x.Id)
                                                     .ToList();

            dgvProdutos.DataSource = repositorio.Consultar();


            //Cria as colunas
            //DataGridViewCheckBoxColumn colChk = new DataGridViewCheckBoxColumn(); Deve ser criado pela tela
            DataGridViewTextBoxColumn colId = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn colCodigo = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn colDescricao = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn colValor = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn colSituacao = new DataGridViewTextBoxColumn();

            //Nomeia os cabeçalhos
            dgvProdutos.Columns[0].HeaderText = "Id";
            dgvProdutos.Columns[1].HeaderText = "Código";
            dgvProdutos.Columns[2].HeaderText = "Descrição";
            dgvProdutos.Columns[3].HeaderText = "Valor";
            dgvProdutos.Columns[4].HeaderText = "Situação";

            //Formata exibição do dado na coluna
            dgvProdutos.Columns[3].DefaultCellStyle.Format = "N2";

            //Cores
            dgvProdutos.GridColor = Color.Black;
            dgvProdutos.ForeColor = Color.Black;

            
            //Já Existentes
            dgvProdutos.ColumnHeadersDefaultCellStyle.BackColor = Color.LightSkyBlue;
            dgvProdutos.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvProdutos.ColumnHeadersDefaultCellStyle.Font = new Font(dgvProdutos.Font, FontStyle.Bold);
            dgvProdutos.ForeColor = Color.Black;

            //Propriedades
            dgvProdutos.Name = "dgvProdutos";
            dgvProdutos.Location = new Point(8, 8);
            dgvProdutos.Size = new Size(500, 250);
            dgvProdutos.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            dgvProdutos.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvProdutos.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgvProdutos.RowHeadersVisible = false;

            this.dgvProdutos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProdutos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProdutos.MultiSelect = false;
            this.dgvProdutos.Dock = DockStyle.Fill;

            
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            string message = string.Empty;
            foreach (DataGridViewRow row in dgvProdutos.Rows)
            {
                bool isSelected = Convert.ToBoolean(row.Cells["checkBoxColumn"].Value);
                if (isSelected)
                {
                    message += Environment.NewLine;
                    message += row.Cells["Name"].Value.ToString();
                }
            }

            MessageBox.Show("Selected Values" + message);
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            frmProduto frmProduto = new frmProduto();
            frmProduto.ShowDialog();
            //ExibirProdutos();
            criaDataGrid();

        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            Pesquisar();
        }

        private void Pesquisar()
        {

            ProdutoRepositorio<Produto> produtoRepo = new ProdutoRepositorio<Produto>();

            Enum.TryParse<Situacao>(cboSituacao.SelectedValue.ToString(), out situacao);
            int value = (int)situacao;

            IList<Produto> objeto = produtoRepo.Pesquisar(txtProduto.Text, situacao);

            var lista = objeto.Select(s => new {
                Id = s.Id,
                Codigo = s.Codigo,
                Descricao = s.Descricao,
                Valor = s.Valor,
                Status = s.Status
            }
                                        ).OrderBy(x => x.Descricao)
                                                     //.Sum(item => item.valor)
                                                     //.GroupBy(x => x.Id)
                                                     .ToList();

            dgvProdutos.DataSource = lista;


            //Cria as colunas
            //DataGridViewCheckBoxColumn colChk = new DataGridViewCheckBoxColumn(); Deve ser criado pela tela
            DataGridViewTextBoxColumn colId = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn colCodigo = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn colDescricao = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn colValor = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn colSituacao = new DataGridViewTextBoxColumn();

            //Nomeia os cabeçalhos
            dgvProdutos.Columns[0].HeaderText = "Id";
            dgvProdutos.Columns[1].HeaderText = "Código";
            dgvProdutos.Columns[2].HeaderText = "Descrição";
            dgvProdutos.Columns[3].HeaderText = "Valor";
            dgvProdutos.Columns[4].HeaderText = "Situação";

            //Formata exibição do dado na coluna
            dgvProdutos.Columns[3].DefaultCellStyle.Format = "N2";

            //Cores
            dgvProdutos.GridColor = Color.Black;
            dgvProdutos.ForeColor = Color.Black;


            //Já Existentes
            dgvProdutos.ColumnHeadersDefaultCellStyle.BackColor = Color.LightSkyBlue;
            dgvProdutos.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvProdutos.ColumnHeadersDefaultCellStyle.Font = new Font(dgvProdutos.Font, FontStyle.Bold);
            dgvProdutos.ForeColor = Color.Black;

            //Propriedades
            dgvProdutos.Name = "dgvProdutos";
            dgvProdutos.Location = new Point(8, 8);
            dgvProdutos.Size = new Size(500, 250);
            dgvProdutos.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            dgvProdutos.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvProdutos.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgvProdutos.RowHeadersVisible = false;

            this.dgvProdutos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProdutos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProdutos.MultiSelect = false;
            this.dgvProdutos.Dock = DockStyle.Fill;

        }

        public static void LoadSituacaoCombo<T>(ComboBox cbo)
        {
            cbo.DataSource = Enum.GetValues(typeof(T))
                .Cast<Enum>()
                .Select(value => new
                {
                    (Attribute.GetCustomAttribute(value.GetType().GetField(value.ToString()), typeof(DescriptionAttribute)) as DescriptionAttribute).Description,
                    value
                })
                .OrderBy(item => item.value)
                .ToList();
            cbo.DisplayMember = "Description";
            cbo.ValueMember = "value";
        }
    }
}
