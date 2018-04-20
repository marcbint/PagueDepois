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
    public partial class frmProdutoCon : Form
    {
        public frmProdutoCon()
        {
            InitializeComponent();
        }

        
        //ProdutoRepositorio<Produto> produtoRepo = new ProdutoRepositorio<Produto>();

        private void ExibirProdutos()
        {
            ProdutoRepositorio<Produto> produtoRepo = new ProdutoRepositorio<Produto>();
            dgvProdutos.DataSource = produtoRepo.Consultar();

            //Add a CheckBox Column to the DataGridView at the first position.
            /*DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
            checkBoxColumn.HeaderText = "";
            checkBoxColumn.Width = 30;
            checkBoxColumn.Name = "checkBoxColumn";
            dgvProdutos.Columns.Insert(0, checkBoxColumn);*/
        }

        private void frmProducoCon_Load(object sender, EventArgs e)
        {
            criaDataGrid();
            //ExibirProdutos();
        }

        private void dgvProdutos_DoubleCellClick(object sender, DataGridViewCellEventArgs e)
        {

            int index = e.RowIndex;
            DataGridViewRow selectedRow = dgvProdutos.Rows[index];

            string id = selectedRow.Cells[0].Value.ToString();

            //Abre a tela em processo de edição
            frmProduto frmProduto = new frmProduto();
            frmProduto.idProduto = Convert.ToInt32(id);
            frmProduto.ShowDialog();
            
            //Remonta o grid apos o process de edição ou exclusao.
            ExibirProdutos();

            

        }

        private void criaDataGrid() {

            ProdutoRepositorio<Produto> produtoRepo = new ProdutoRepositorio<Produto>();
            dgvProdutos.DataSource = produtoRepo.Consultar();
            //dgvProdutos.ColumnCount = 5;

            dgvProdutos.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            dgvProdutos.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvProdutos.ColumnHeadersDefaultCellStyle.Font =
                new Font(dgvProdutos.Font, FontStyle.Bold);
            dgvProdutos.GridColor = Color.Black;
            dgvProdutos.ForeColor = Color.Black;


            dgvProdutos.Name = "dgvProdutos";
            dgvProdutos.Location = new Point(8, 8);
            dgvProdutos.Size = new Size(500, 250);
            dgvProdutos.AutoSizeRowsMode =
                DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            dgvProdutos.ColumnHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.Single;
            dgvProdutos.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            
            dgvProdutos.RowHeadersVisible = false;
            

            // NOMES DA COLUNA
            dgvProdutos.Columns[0].HeaderText = "ID";
            dgvProdutos.Columns[1].HeaderText = "CÓDIGO";
            dgvProdutos.Columns[2].HeaderText = "DESCRIÇÃO";
            dgvProdutos.Columns[3].HeaderText = "VALOR";
            dgvProdutos.Columns[4].HeaderText = "STATUS";

            


            dgvProdutos.Columns[0].Name = "Column1";
            dgvProdutos.Columns[1].Name = "teste2";
            dgvProdutos.Columns[2].Name = "Title";
            dgvProdutos.Columns[3].Name = "Artist";
            dgvProdutos.Columns[4].Name = "Album";
            dgvProdutos.Columns[4].DefaultCellStyle.Font =
                new Font(dgvProdutos.DefaultCellStyle.Font, FontStyle.Italic);
            dgvProdutos.Columns[4].HeaderText = "teste";

            dgvProdutos.SelectionMode =
        DataGridViewSelectionMode.FullRowSelect;
            dgvProdutos.MultiSelect = false;
            dgvProdutos.Dock = DockStyle.Fill;

            /*dgvProdutos.CellFormatting += new
                DataGridViewCellFormattingEventHandler(
                dgvProdutos_CellFormatting);*/


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
            ExibirProdutos();

        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
