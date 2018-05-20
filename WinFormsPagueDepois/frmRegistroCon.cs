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
    public partial class frmRegistroCon : Form
    {
        public frmRegistroCon()
        {
            InitializeComponent();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmRegistroCon_Load(object sender, EventArgs e)
        {
            criaDataGrid();
        }

        private void criaDataGrid()
        {
            UsuarioRepositorio<Usuario> repositorio = new UsuarioRepositorio<Usuario>();
            IList<Usuario> objeto = repositorio.Consultar();

            var lista = objeto.Select(s => new {
                Id      = s.Id,
                Nome    = s.Nome,
                Login   = s.Login,
                Senha   = s.Senha,
                Status  = s.Status
            }
                                        ).OrderBy(x => x.Nome)
                                                     //.Sum(item => item.valor)
                                                     //.GroupBy(x => x.Id)
                                                     .ToList();

            dgvRegistros.DataSource = lista;

            //Cria as colunas
            //DataGridViewCheckBoxColumn colChk = new DataGridViewCheckBoxColumn(); Deve ser criado pela tela
            DataGridViewTextBoxColumn colId = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn colNome = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn colLogin = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn colSenha = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn colSituacao = new DataGridViewTextBoxColumn();

            //Nomeia os cabeçalhos
            dgvRegistros.Columns[0].HeaderText = "Id";
            dgvRegistros.Columns[1].HeaderText = "Nome";
            dgvRegistros.Columns[2].HeaderText = "Login";
            dgvRegistros.Columns[3].HeaderText = "Senha";
            dgvRegistros.Columns[4].HeaderText = "Situação";

            //Cores
            dgvRegistros.GridColor = Color.Black;
            dgvRegistros.ForeColor = Color.Black;


            this.dgvRegistros.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRegistros.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRegistros.MultiSelect = false;
            this.dgvRegistros.Dock = DockStyle.Fill;

            //Já Existentes
            dgvRegistros.ColumnHeadersDefaultCellStyle.BackColor = Color.LightSkyBlue;
            dgvRegistros.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvRegistros.ColumnHeadersDefaultCellStyle.Font = new Font(dgvRegistros.Font, FontStyle.Bold);
            dgvRegistros.ForeColor = Color.Black;


            dgvRegistros.Name = "dgvRegistros";
            dgvRegistros.Location = new Point(8, 8);
            dgvRegistros.Size = new Size(500, 250);
            dgvRegistros.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            dgvRegistros.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvRegistros.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgvRegistros.RowHeadersVisible = false;



        }

        private void dgvRegistros_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            int index = e.RowIndex;
            DataGridViewRow selectedRow = dgvRegistros.Rows[index];

            string id = selectedRow.Cells[0].Value.ToString();

            //Abre a tela em processo de edição
            frmRegistro frmRegistro = new frmRegistro();
            frmRegistro.idRegistro  = Convert.ToInt32(id);
            frmRegistro.ShowDialog();

            //Remonta o grid apos o process de edição ou exclusao.
            criaDataGrid();



        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            frmRegistro frmRegistro = new frmRegistro();
            frmRegistro.ShowDialog();
            criaDataGrid();
        }
    }
}
