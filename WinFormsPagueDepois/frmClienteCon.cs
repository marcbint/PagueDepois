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
using Repositorio.Enum;

namespace WinFormsPagueDepois
{
    public partial class frmClienteCon : Form
    {
        Situacao situacao;

        public frmClienteCon()
        {
            InitializeComponent();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            frmCliente cliente = new frmCliente();
            cliente.ShowDialog();
            //dgvClientes.Refresh();
            criaDataGrid();
        }

        private void criaDataGrid()
        {

            ClienteRepositorio<Cliente> clienteRepo = new ClienteRepositorio<Cliente>();
            IList<Cliente> objeto = clienteRepo.Consultar2();

            var lista = objeto.Select(s => new
            {
                Id = s.Id
                                                ,
                Tipo = s.Tipo
                                                ,
                NomeRazao = s.NomeRazao
                                                ,
                Cidade = s.Cidade
                                                ,
                Contato = s.Contato
                                                ,
                Status = s.Status
            }
                                        )
                                                     .OrderBy(x => x.NomeRazao)
                                                     //.Sum(item => item.valor)
                                                     //.GroupBy(x => x.Id)
                                                     .ToList();


            dgvClientes.DataSource = lista;

            //Cria as colunas
            //DataGridViewCheckBoxColumn colChk = new DataGridViewCheckBoxColumn(); Deve ser criado pela tela
            DataGridViewTextBoxColumn colClienteId = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn colClienteTipo = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn colClienteNomeRazao = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn colClienteCidade = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn colClienteContato = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn colClienteSituacao = new DataGridViewTextBoxColumn();


            //Nomeia os cabeçalhos
            dgvClientes.Columns[0].HeaderText = "Id";
            dgvClientes.Columns[1].HeaderText = "Tipo";
            dgvClientes.Columns[2].HeaderText = "Nome/Razão";
            dgvClientes.Columns[3].HeaderText = "Cidade";
            dgvClientes.Columns[4].HeaderText = "Contato";
            dgvClientes.Columns[5].HeaderText = "Situação";

            //Cores
            dgvClientes.GridColor = Color.Black;
            dgvClientes.ForeColor = Color.Black;


            this.dgvClientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvClientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvClientes.MultiSelect = false;
            this.dgvClientes.Dock = DockStyle.Fill;

            //Já Existentes
            dgvClientes.ColumnHeadersDefaultCellStyle.BackColor = Color.LightSkyBlue;
            dgvClientes.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvClientes.ColumnHeadersDefaultCellStyle.Font = new Font(dgvClientes.Font, FontStyle.Bold);
            dgvClientes.ForeColor = Color.Black;

            dgvClientes.Name = "dgvClientes";
            dgvClientes.Location = new Point(8, 8);
            dgvClientes.Size = new Size(500, 250);
            dgvClientes.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            dgvClientes.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvClientes.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgvClientes.RowHeadersVisible = false;


            /*
            dgvClientes.Columns["Tipo"].Visible = false;

            if (dgvClientes.Columns.Contains("TipoCliente") == false)
            {
                dgvClientes.Columns.Add("TipoCliente", "TipoCliente");
            }
            

            foreach (DataGridViewRow row in dgvClientes.Rows)
            {
                char valor = Convert.ToChar(row.Cells["Tipo"].Value);
                if(valor == '1')
                {
                    //dgvClientes.Columns.Add("TipoCliente","TipoCliente");
                    row.Cells["TipoCliente"].Value = "FÍSICA";
                    //dgvClientes.Rows.Add(row);
                }else if(valor == '2')
                {
                    //dgvClientes.Columns.Add("TipoCliente", "TipoCliente");
                    row.Cells["TipoCliente"].Value = "JURÍDICA";
                }
            }
            */

        }

        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            int index = e.RowIndex;

            //Se for diferente do cabeçalho
            if (index != -1)
            {
                DataGridViewRow selectedRow = dgvClientes.Rows[index];

                string id = selectedRow.Cells[0].Value.ToString();

                //Abre a tela em processo de edição
                frmCliente frmcliente = new frmCliente();
                frmcliente.idCliente = Convert.ToInt32(id);
                frmcliente.ShowDialog();

                //Remonta o grid apos o process de edição ou exclusao.
                criaDataGrid();
            }



        }

        private void frmClienteCon_Load(object sender, EventArgs e)
        {
            LoadSituacaoCombo<Situacao>(cboSituacao);
            //criaDataGrid();
            txtCliente.Focus();
        }

        private void Pesquisar()
        {

            ClienteRepositorio<Cliente> clienteRepo = new ClienteRepositorio<Cliente>();

            Enum.TryParse<Situacao>(cboSituacao.SelectedValue.ToString(), out situacao);
            int value = (int)situacao;

            IList<Cliente> objeto = clienteRepo.Pesquisar(txtCliente.Text, situacao);

            var lista = objeto.Select(s => new
            {
                Id = s.Id,
                Tipo = s.Tipo,
                NomeRazao = s.NomeRazao,
                Cidade = s.Cidade,
                Contato = s.Contato,
                Status = s.Status
            }
                                     ).OrderBy(x => x.NomeRazao)
                                      .ToList();


            dgvClientes.DataSource = lista;

            //Cria as colunas
            //DataGridViewCheckBoxColumn colChk = new DataGridViewCheckBoxColumn(); Deve ser criado pela tela
            DataGridViewTextBoxColumn colClienteId = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn colClienteTipo = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn colClienteNomeRazao = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn colClienteCidade = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn colClienteContato = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn colClienteSituacao = new DataGridViewTextBoxColumn();


            //Nomeia os cabeçalhos
            dgvClientes.Columns[0].HeaderText = "Id";
            dgvClientes.Columns[1].HeaderText = "Tipo";
            dgvClientes.Columns[2].HeaderText = "Nome/Razão";
            dgvClientes.Columns[3].HeaderText = "Cidade";
            dgvClientes.Columns[4].HeaderText = "Contato";
            dgvClientes.Columns[5].HeaderText = "Situação";

            //Cores
            dgvClientes.GridColor = Color.Black;
            dgvClientes.ForeColor = Color.Black;


            this.dgvClientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvClientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvClientes.MultiSelect = false;
            this.dgvClientes.Dock = DockStyle.Fill;

            //Já Existentes
            dgvClientes.ColumnHeadersDefaultCellStyle.BackColor = Color.LightSkyBlue;
            dgvClientes.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvClientes.ColumnHeadersDefaultCellStyle.Font = new Font(dgvClientes.Font, FontStyle.Bold);
            dgvClientes.ForeColor = Color.Black;

            dgvClientes.Name = "dgvClientes";
            dgvClientes.Location = new Point(8, 8);
            dgvClientes.Size = new Size(500, 250);
            dgvClientes.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            dgvClientes.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvClientes.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgvClientes.RowHeadersVisible = false;

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

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            Pesquisar();
        }



    }
}
