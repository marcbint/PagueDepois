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
    public partial class frmPedidoCon : Form
    {
        SituacaoPedido situacaoPedido;

        public frmPedidoCon()
        {
            InitializeComponent();
        }

        private void frmPedidoCon_Load(object sender, EventArgs e)
        {
            LoadSituacaoCombo<SituacaoPedido>(cboSituacao);
            criaDataGrid();
        }

        private void criaDataGrid()
        {
            PedidoRepositorio<Pedido> pedidoRepo = new PedidoRepositorio<Pedido>();
            IList<Pedido> objetoPedido = pedidoRepo.Consultar();

            //IList<Pedido> objetoPedido = pedidoRepo.Pesquisar(txtCliente.Text, situacaoPedido);

            var lista = objetoPedido.Select(s => new {  Id = s.Id
                                                        ,Cliente = s.Cliente.NomeRazao
                                                        ,DataPedido = s.Data_Inclusao
                                                        ,PrevisaoPagamento = s.Data_Previsao_Pagamento
                                                        ,Valor = s.Valor_Total 
                                                        ,Status = s.Status
                                                        //,FormaPagamento = s.FormaPagamento.Descricao
                                                        //,DataPagamento = s.Data_Registro_Pagamento
                                                        //,UsuarioAlteracao = s.Usuario.Nome                                                       
                                                     })
                                                     .OrderBy(x => x.Cliente)
                                                     //.Sum(item => item.valor)
                                                     //.GroupBy(x => x.Id)
                                                     .ToList();

            dgvPedidos.DataSource = lista;

            
            /*this.dgvPedidoItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clnChk,
            this.dgvPedidoItemBtnRemover});

            this.clnChk.HeaderText = "Selecione";
            this.clnChk.Name = "clnChk";
            this.clnChk.ReadOnly = true;
            
            this.dgvPedidoItemBtnRemover.HeaderText = "Remover";
            this.dgvPedidoItemBtnRemover.Name = "dgvPedidoItemBtnRemover";
            this.dgvPedidoItemBtnRemover.ReadOnly = true;
            this.dgvPedidoItemBtnRemover.Text = "Remover";
            this.dgvPedidoItemBtnRemover.UseColumnTextForButtonValue = true;
             */

            /*//Incluir botão Remover no Datagridview
            this.dgvPedidoItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvPedidoItemBtnRemover});

            this.dgvPedidoItemBtnRemover.HeaderText = "";
            this.dgvPedidoItemBtnRemover.Name = "dgvPedidoItemBtnRemover";
            this.dgvPedidoItemBtnRemover.ReadOnly = true;
            this.dgvPedidoItemBtnRemover.Text = "Excluir";
            this.dgvPedidoItemBtnRemover.UseColumnTextForButtonValue = true;
            //this.dgvPedidoItemBtnRemover.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            */

            //Cria as colunas
            //DataGridViewCheckBoxColumn colChk = new DataGridViewCheckBoxColumn(); Deve ser criado pela tela
            DataGridViewTextBoxColumn colPedidoId = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn colPedidoCliente = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn colPedidoDataInclusao = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn colPedidoDataPrevisao = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn colPedidoValor = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn colPedidoSituacao = new DataGridViewTextBoxColumn();


            //Adiciona as colunas
            //dgvPedidoItem.Columns.Add(colChk);
            /*dgvPedidos.Columns.Add(colPedidoId);
            dgvPedidos.Columns.Add(colPedidoCliente);
            dgvPedidos.Columns.Add(colPedidoDataInclusao);
            dgvPedidos.Columns.Add(colPedidoDataPrevisao);
            dgvPedidos.Columns.Add(colPedidoValor);
            dgvPedidos.Columns.Add(colPedidoSituacao);*/

            //Nomeia as colunas
            //dgvPedidoItem.Columns[0].Name = "clnChk";
            //dgvPedidos.Columns[1].Name = "clnPedidoId";
            //dgvPedidos.Columns[2].Name = "clnPedidoSituacao";
            //dgvPedidoItem.Columns[3].Name = "clnProdutoQuantidade";
            //dgvPedidoItem.Columns[4].Name = "clnProdutoValor";
            //dgvPedidoItem.Columns[5].Name = "clnProdutoValorTotal";

            //Nomeia os cabeçalhos
            dgvPedidos.Columns[0].HeaderText = "Id";
            dgvPedidos.Columns[1].HeaderText = "Cliente";
            dgvPedidos.Columns[2].HeaderText = "Data Pedido";
            dgvPedidos.Columns[3].HeaderText = "Previsão Pagamento";
            dgvPedidos.Columns[4].HeaderText = "Valor";
            dgvPedidos.Columns[5].HeaderText = "Situação";

            //Formata exibição do dado na coluna
            dgvPedidos.Columns[4].DefaultCellStyle.Format = "N2";

            //Cores
            dgvPedidos.GridColor = Color.Black;
            dgvPedidos.ForeColor = Color.Black;
            

            //Já Existentes
            dgvPedidos.ColumnHeadersDefaultCellStyle.BackColor = Color.LightSkyBlue;
            dgvPedidos.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvPedidos.ColumnHeadersDefaultCellStyle.Font = new Font(dgvPedidos.Font, FontStyle.Bold);
            dgvPedidos.ForeColor = Color.Black;


            //Propriedades
            dgvPedidos.Name = "dgvPedidos";
            dgvPedidos.Location = new Point(8, 8);
            dgvPedidos.Size = new Size(500, 250);
            dgvPedidos.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            dgvPedidos.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvPedidos.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgvPedidos.RowHeadersVisible = false;

            this.dgvPedidos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPedidos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPedidos.MultiSelect = false;
            this.dgvPedidos.Dock = DockStyle.Fill;

        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            frmPedido frmPedido = new frmPedido();
            frmPedido.ShowDialog();
            //dgvPedidos.Refresh();
            criaDataGrid();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvPedidos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;

            // Se diferente do cabeçalho
            if (index != -1)
            {
                DataGridViewRow selectedRow = dgvPedidos.Rows[index];

                string id = selectedRow.Cells[0].Value.ToString();

                //Abre a tela em processo de edição
                frmPedido frmPedido = new frmPedido();
                frmPedido.idPedido = Convert.ToInt32(id);
                frmPedido.ShowDialog();

                //Remonta o grid apos o process de edição ou exclusao.
                criaDataGrid();
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (txtAno.Text.Trim() == string.Empty && rdbAnoMes.Checked == true)
            {
                errorProvider1.SetError(txtAno, "Informe o ano.");
                txtAno.Focus();
                return;
            }
            if (txtMes.Text.Trim() == string.Empty && rdbAnoMes.Checked == true)
            {
                errorProvider1.SetError(txtMes, "Informe o mês.");
                txtMes.Focus();
                return;
            }

            pesquisar();
        }

        private void pesquisar()
        {
            PedidoRepositorio<Pedido> pedidoRepo = new PedidoRepositorio<Pedido>();

            Enum.TryParse<SituacaoPedido>(cboSituacao.SelectedValue.ToString(), out situacaoPedido);
            int value = (int)situacaoPedido;

            IList<Pedido> objetoPedido = pedidoRepo.Pesquisar(txtCliente.Text, situacaoPedido, Convert.ToDateTime(dtpPrevisaoPagamento.Text), Convert.ToDateTime(dtpDataPagamento.Text), txtAno.Text, txtMes.Text);

            var lista = objetoPedido.Select(s => new {
                Id = s.Id
                                                        ,
                Cliente = s.Cliente.NomeRazao
                                                        ,
                DataPedido = s.Data_Inclusao
                                                        ,
                PrevisaoPagamento = s.Data_Previsao_Pagamento
                                                        ,
                Valor = s.Valor_Total
                                                        ,
                Status = s.Status
                //,FormaPagamento = s.FormaPagamento.Descricao
                //,DataPagamento = s.Data_Registro_Pagamento
                //,UsuarioAlteracao = s.Usuario.Nome                                                       
            })
                                                     .OrderBy(x => x.Cliente)
                                                     //.Sum(item => item.valor)
                                                     //.GroupBy(x => x.Id)
                                                     .ToList();

            dgvPedidos.DataSource = lista;


            //Cria as colunas
            //DataGridViewCheckBoxColumn colChk = new DataGridViewCheckBoxColumn(); Deve ser criado pela tela
            DataGridViewTextBoxColumn colPedidoId = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn colPedidoCliente = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn colPedidoDataInclusao = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn colPedidoDataPrevisao = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn colPedidoValor = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn colPedidoSituacao = new DataGridViewTextBoxColumn();

            //Nomeia os cabeçalhos
            dgvPedidos.Columns[0].HeaderText = "Id";
            dgvPedidos.Columns[1].HeaderText = "Cliente";
            dgvPedidos.Columns[2].HeaderText = "Data Pedido";
            dgvPedidos.Columns[3].HeaderText = "Previsão Pagamento";
            dgvPedidos.Columns[4].HeaderText = "Valor";
            dgvPedidos.Columns[5].HeaderText = "Situação";

            //Cores
            dgvPedidos.GridColor = Color.Black;
            dgvPedidos.ForeColor = Color.Black;

            this.dgvPedidos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPedidos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

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



        private void montaGrid()
        {
            
        }

        private void rdbAnoMes_Click(object sender, EventArgs e)
        {
            Enum.TryParse<SituacaoPedido>(cboSituacao.SelectedValue.ToString(), out situacaoPedido);
            int value = (int)situacaoPedido;
            if (rdbAnoMes.Checked == true)//Pendete
            {
                txtAno.Enabled = true;
                txtMes.Enabled = true;
                dtpDataPagamento.Enabled = false;
                dtpPrevisaoPagamento.Enabled = false;
            }
            else
            {
                txtAno.Enabled = false;
                txtMes.Enabled = false;
                txtAno.Text = string.Empty;
                txtMes.Text = string.Empty;
            }

            /*if (rdbDia.Checked == true && value == 2)//Pago
            {
                dtpDataPagamento.Enabled = true;
                dtpPrevisaoPagamento.Enabled = false;
                txtAno.Enabled = false;
                txtMes.Enabled = false;
            }
            else
            {
                dtpDataPagamento.Enabled = false;
                dtpPrevisaoPagamento.Enabled = false;
                txtAno.Enabled = true;
                txtMes.Enabled = true;
            }


            if (rdbDia.Checked == true && value == 3)//Cancelado
            {
                dtpDataPagamento.Enabled = false;
                dtpPrevisaoPagamento.Enabled = true;
                txtAno.Enabled = false;
                txtMes.Enabled = false;
            }
            else
            {
                dtpDataPagamento.Enabled = false;
                dtpPrevisaoPagamento.Enabled = false;
                txtAno.Enabled = true;
                txtMes.Enabled = true;
            }*/
        }

        private void rdbDia_Click(object sender, EventArgs e)
        {
            Enum.TryParse<SituacaoPedido>(cboSituacao.SelectedValue.ToString(), out situacaoPedido);
            int value = (int)situacaoPedido;
            if (rdbDia.Checked == true && value == 1)//Pendente
            {
                dtpDataPagamento.Enabled = false;
                dtpPrevisaoPagamento.Enabled = true;
                txtAno.Enabled = false;
                txtMes.Enabled = false;
                txtAno.Text = string.Empty;
                txtMes.Text = string.Empty;
            }
            else if (rdbDia.Checked == true && value == 2)//Pago
            {
                dtpDataPagamento.Enabled = true;
                dtpPrevisaoPagamento.Enabled = false;
                txtAno.Enabled = false;
                txtMes.Enabled = false;
                txtAno.Text = string.Empty;
                txtMes.Text = string.Empty;
            }
            else if (rdbDia.Checked == true && value == 3)//Cancelado
            {
                dtpDataPagamento.Enabled = false;
                dtpPrevisaoPagamento.Enabled = true;
                txtAno.Enabled = false;
                txtMes.Enabled = false;
                txtAno.Text = string.Empty;
                txtMes.Text = string.Empty;
            }
            else
            {
                dtpDataPagamento.Enabled = false;
                dtpPrevisaoPagamento.Enabled = false;
                txtAno.Enabled = true;
                txtMes.Enabled = true;
            }

            
        }

        private void cboSituacao_SelectedValueChanged(object sender, EventArgs e)
        {
            Enum.TryParse<SituacaoPedido>(cboSituacao.SelectedValue.ToString(), out situacaoPedido);
            int value = (int)situacaoPedido;

            if (value == 1 && rdbDia.Checked == true)// Pendente
            {
                dtpPrevisaoPagamento.Enabled = true;
                dtpDataPagamento.Enabled = false;
            }
            else if (value == 2 && rdbDia.Checked == true) //Pago
            {
                dtpDataPagamento.Enabled = true;
                dtpPrevisaoPagamento.Enabled = false;
            }
            else if (value == 3 && rdbDia.Checked == true) // Cancelado
            {
                dtpPrevisaoPagamento.Enabled = true;
                dtpDataPagamento.Enabled = false;
            }
            else {
                dtpDataPagamento.Enabled = false;
                dtpPrevisaoPagamento.Enabled = false;
            }


            
        }

        private void txtAno_KeyPress(object sender, KeyPressEventArgs e)
        {
            Helpers.ValidaTexto.SomenteNumeros(sender, e);
        }

        private void txtMes_KeyPress(object sender, KeyPressEventArgs e)
        {
            Helpers.ValidaTexto.SomenteNumeros(sender, e);
        }
    }
}
