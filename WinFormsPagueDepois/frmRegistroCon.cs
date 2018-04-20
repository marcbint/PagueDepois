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

            UsuarioRepositorio<Usuario> usuarioRepo = new UsuarioRepositorio<Usuario>();
            dgvRegistros.DataSource = usuarioRepo.Consultar();
            //dgvRegistros.ColumnCount = 5;

            dgvRegistros.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            dgvRegistros.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvRegistros.ColumnHeadersDefaultCellStyle.Font =
                new Font(dgvRegistros.Font, FontStyle.Bold);

            dgvRegistros.Name = "dgvRegistros";
            dgvRegistros.Location = new Point(8, 8);
            dgvRegistros.Size = new Size(500, 250);
            dgvRegistros.AutoSizeRowsMode =
                DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            dgvRegistros.ColumnHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.Single;
            dgvRegistros.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgvRegistros.GridColor = Color.Black;
            dgvRegistros.RowHeadersVisible = false;

            // NOMES DA COLUNA
            /*dgvRegistros.Columns[0].HeaderText = "ID";
            dgvRegistros.Columns[1].HeaderText = "CÓDIGO";
            dgvRegistros.Columns[2].HeaderText = "DESCRIÇÃO";
            dgvRegistros.Columns[3].HeaderText = "VALOR";
            dgvRegistros.Columns[4].HeaderText = "STATUS";*/



            /*
            dgvRegistros.Columns[0].Name = "Column1";
            dgvRegistros.Columns[1].Name = "teste2";
            dgvRegistros.Columns[2].Name = "Title";
            dgvRegistros.Columns[3].Name = "Artist";
            dgvRegistros.Columns[4].Name = "Album";

            dgvRegistros.Columns[4].DefaultCellStyle.Font =
                new Font(dgvRegistros.DefaultCellStyle.Font, FontStyle.Italic);
            dgvRegistros.Columns[4].HeaderText = "teste";
            */

            dgvRegistros.SelectionMode =
        DataGridViewSelectionMode.FullRowSelect;
            dgvRegistros.MultiSelect = false;
            dgvRegistros.Dock = DockStyle.Fill;

            /*dgvRegistros.CellFormatting += new
                DataGridViewCellFormattingEventHandler(
                dgvRegistros_CellFormatting);*/


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
