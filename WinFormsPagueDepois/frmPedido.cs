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
using Repositorio.Enum;
using Repositorio.Entidades;
using WinFormsPagueDepois.Helpers;

namespace WinFormsPagueDepois
{
    public partial class frmPedido : Form
    {
        public int linha;
        public int atualiza;
        public int codigoReg;
        Produto produto = new Produto();

        public int idPedido;
        frmMenu frmMenu;

        SituacaoPedido situacaoPedido;
        string produtoCodigo;
        string produtoDescricao;
        string produtoId;
        string produtoQuantidade;
        string produtoValor;
        decimal produtoValorTotal;

        PedidoRepositorio<Pedido> pedidoRepoUpdate = new PedidoRepositorio<Pedido>();
        Pedido pedidoUpdate = new Pedido();
        


        public frmPedido()
        {
            InitializeComponent();
        }

        
        private void frmPedido_Load(object sender, EventArgs e)
        {
            
            carregaClientes();
            carregaFormasPagamento();
            LoadSituacaoCombo<SituacaoPedido>(cboSituacao);
            carregaProdutos();
            

            if (idPedido >= 1)
            {

                PedidoRepositorio<Pedido> pedidoRepo = new PedidoRepositorio<Pedido>();
                var pedido = pedidoRepo.RetornarPorId(idPedido);
                pedidoUpdate = pedidoRepo.RetornarPorId(idPedido);

                carregaClientesPorId(pedido.Cliente.Id);
                carregaFormasPagamentoPorId(pedido.FormaPagamento.Id);
                dtpPrevisaoPagamento.Text = pedido.Data_Previsao_Pagamento.ToString();
                txtValorPedido.Text = pedido.Valor_Total.ToString();
                cboSituacao.Text = pedido.Status.ToString();
                txtMotivo.Text = pedido.Motivo_Cancelamento;


                //Cria o datagrid view de itens
                //Incluir botão Remover no Datagridview
                this.dgvPedidoItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.dgvPedidoItemBtnRemover
                });

                this.dgvPedidoItemBtnRemover.HeaderText = "";
                this.dgvPedidoItemBtnRemover.Name = "dgvPedidoItemBtnRemover";
                this.dgvPedidoItemBtnRemover.ReadOnly = true;
                this.dgvPedidoItemBtnRemover.Text = "Excluir";
                this.dgvPedidoItemBtnRemover.UseColumnTextForButtonValue = true;

                
                //Cores
                dgvPedidoItem.GridColor = Color.Black;
                dgvPedidoItem.ForeColor = Color.Black;


                this.dgvPedidoItem.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
                this.dgvPedidoItem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;


                IList<PedidoItem> objetoPedido = pedido.PedidoItem;
                var lista = objetoPedido.Select(s => new {
                    Id = s.Id
                    ,Descriçao = s.Produto.Descricao
                    ,Quantidade = s.Quantidade
                    ,ValorUnitario = s.Valor_Unitario
                    ,ValorTotal = s.Valor_Total
                                                                                                               
                }).OrderBy(x => x.Descriçao)
                    //.Sum(item => item.valor)
                    //.GroupBy(x => x.Id)
                    .ToList();

                dgvPedidoItem.DataSource = lista;
                groupBox2.Enabled = false;
                //dgvPedidoItem.Enabled = false;

                
                if(cboSituacao.SelectedValue.ToString() == "CANCELADO")
                {
                    btnSalvar.Visible = false;
                    groupBox1.Enabled = false;
                    groupBox1.ForeColor = Color.White;
                }else if (cboSituacao.SelectedValue.ToString() == "PAGO")
                {
                    groupBox1.Enabled = false;
                }
                


            }
            else
            {
                criaDataGrid();
                //btnExcluir.Visible = false;
            }
            //maskDocumento.Focus();

        }

        private void criaDataGrid()
        {
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

            //Incluir botão Remover no Datagridview
            this.dgvPedidoItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvPedidoItemBtnRemover
            });

            this.dgvPedidoItemBtnRemover.HeaderText = "";
            this.dgvPedidoItemBtnRemover.Name = "dgvPedidoItemBtnRemover";
            this.dgvPedidoItemBtnRemover.ReadOnly = true;
            this.dgvPedidoItemBtnRemover.Text = "Excluir";
            this.dgvPedidoItemBtnRemover.UseColumnTextForButtonValue = true;
            //this.dgvPedidoItemBtnRemover.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            //Cria as colunas
            //DataGridViewCheckBoxColumn colChk = new DataGridViewCheckBoxColumn(); Deve ser criado pela tela
            DataGridViewTextBoxColumn colProdutoId = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn colProdutoDescricao = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn colProdutoQuantidade = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn colProdutoValor = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn colProdutoValorTotal = new DataGridViewTextBoxColumn();


            //Adiciona as colunas
            //dgvPedidoItem.Columns.Add(colChk);
            dgvPedidoItem.Columns.Add(colProdutoId);
            dgvPedidoItem.Columns.Add(colProdutoDescricao);
            dgvPedidoItem.Columns.Add(colProdutoQuantidade);
            dgvPedidoItem.Columns.Add(colProdutoValor);
            dgvPedidoItem.Columns.Add(colProdutoValorTotal);

            //Nomeia as colunas
            //dgvPedidoItem.Columns[0].Name = "clnChk";
            dgvPedidoItem.Columns[1].Name = "clnProdutoId";
            dgvPedidoItem.Columns[2].Name = "clnProdutoDescricao";
            dgvPedidoItem.Columns[3].Name = "clnProdutoQuantidade";
            dgvPedidoItem.Columns[4].Name = "clnProdutoValor";
            dgvPedidoItem.Columns[5].Name = "clnProdutoValorTotal";

            //Nomeia os cabeçalhos
            //dgvPedidoItem.Columns[0].HeaderText = "Selecione";
            dgvPedidoItem.Columns[1].HeaderText = "Id";
            dgvPedidoItem.Columns[2].HeaderText = "Descrição";
            dgvPedidoItem.Columns[3].HeaderText = "Quantidade";
            dgvPedidoItem.Columns[4].HeaderText = "Valor Unitário";
            dgvPedidoItem.Columns[5].HeaderText = "Valor Total";

            //Cores
            dgvPedidoItem.GridColor = Color.Black;
            dgvPedidoItem.ForeColor = Color.Black;

            this.dgvPedidoItem.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPedidoItem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;



        }

        private void carregaProdutos()
        {
            ProdutoRepositorio<Produto> produtoRepo = new ProdutoRepositorio<Produto>();
            cboProduto.DataSource = produtoRepo.Consultar();
            this.cboProduto.DisplayMember = "Descricao";
            this.cboProduto.ValueMember = "Id";

            //this.cboProduto.SelectedItem = this.cboProduto.Items.OfType<Produto>().Where(i => i.Status == '1').First();
            

        }

        private void carregaClientes()
        {
            ClienteRepositorio<Cliente> clienteRepo = new ClienteRepositorio<Cliente>();
            cboCliente.DataSource = clienteRepo.Consultar();
            this.cboCliente.DisplayMember = "Nomerazao";
            this.cboCliente.ValueMember = "Id";

            //this.cboCliente.SelectedItem = null;
        }

        private void carregaClientesPorId(int id)
        {
            ClienteRepositorio<Cliente> clienteRepo = new ClienteRepositorio<Cliente>();      
            var cliente =   clienteRepo.RetornarPorId(id);
            cboCliente.Text = cliente.NomeRazao.ToString();
            cboCliente.SelectedValue = cliente.Id;
        }

        private void populaCboSituacao()
        {
            //cboSituacao.DataSource = Enum.GetValues(typeof(SituacaoPedido));
            

            //cboSituacao.DataSource = typeof(SituacaoPedido).ToList<int>(); 
            //cboSituacao.DisplayMember = "Value";
            //cboSituacao.ValueMember = "Key";

            /*
            cboSituacao.DataSource = typeof(SituacaoPedido).ToList<int>();
            cboSituacao.DisplayMember = "Value";
            cboSituacao.ValueMember = "Key"; */

        }

        private void carregaFormasPagamento()
        {
            FormaPagamentoRepositorio<FormaPagamento> formaPagamentoRepo = new FormaPagamentoRepositorio<FormaPagamento>();
            cboFormaPagamento.DataSource = formaPagamentoRepo.Consultar();
            this.cboFormaPagamento.DisplayMember = "Descricao";
            this.cboFormaPagamento.ValueMember = "Id";

            //this.cboFormaPagamento.SelectedItem = null;
        }

        private void carregaFormasPagamentoPorId(int id)
        {
            FormaPagamentoRepositorio<FormaPagamento> formaPagamentoRepo = new FormaPagamentoRepositorio<FormaPagamento>();
            var formaPagamento = formaPagamentoRepo.RetornarPorId(id);
            this.cboFormaPagamento.Text = formaPagamento.Descricao;
            this.cboFormaPagamento.SelectedValue = formaPagamento.Id;

        }


        private void RecalculaValorPedido()
        {
            txtValorPedido.Text = CalculaValorTotalPedido().ToString();
        }

        private void txtQuantidade_TextChanged(object sender, EventArgs e)
        {
            if (txtQuantidade.Text.Trim() != string.Empty)
            {
                calculaValorTotal(txtQuantidade.Text);
            }
        }

        private void txtQuantidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            Helpers.ValidaTexto.SomenteNumeros(sender, e);
        }

        private decimal CalculaValorTotalPedido()
        {
            decimal total = 0;
            int i = 0;
            for (i = 0; i < dgvPedidoItem.Rows.Count; i++)
            {
                total = total + Convert.ToDecimal(dgvPedidoItem.Rows[i].Cells["clnProdutoValorTotal"].Value);
            }
            return total;

        }

        private void calculaValorTotal(string quantidade)
        {
            btnIncluirPedidoItem.Enabled = false;

            produtoQuantidade = quantidade;
            produtoValorTotal = Convert.ToInt32(produtoQuantidade) * Convert.ToDecimal(produtoValor);
            txtValorTotal.Text = Convert.ToString(produtoValorTotal);

            btnIncluirPedidoItem.Enabled = true;
        }

        private void limpaVariaveisCampos()
        {
            produtoId = null;
            produtoCodigo = null;
            produtoDescricao = null;
            produtoValor = null;
            produtoValorTotal = 0;
            

            txtQuantidade.Text = string.Empty;
            txtValorTotal.Text = string.Empty;
            txtQuantidade.Enabled = false;
            btnIncluirPedidoItem.Enabled = false;
        }

        private void limpaCampos()
        {
            txtQuantidade.Text = string.Empty;
            txtValorTotal.Text = string.Empty;
            txtQuantidade.Enabled = true;
            btnIncluirPedidoItem.Enabled = false;
        }

        private void consultaProdutoSelecionado(int id)
        {
            
            limpaVariaveisCampos();

            ProdutoRepositorio<Produto> produtoRepo = new ProdutoRepositorio<Produto>();
            var produto = produtoRepo.RetornarPorId(id);
            //produtoRepo.RetornarPorId(Convert.ToInt32(this.cboProduto.SelectedValue.ToString()));

            produtoId = this.cboProduto.SelectedValue.ToString();
            produtoCodigo = produto.Codigo;
            produtoDescricao = produto.Descricao;
            produtoValor = Convert.ToString(produto.Valor);

            txtQuantidade.Enabled = true;
        }

        private static Cliente consultaClienteSelecionado(int id)
        {
            
            ClienteRepositorio<Cliente> clienteRepo = new ClienteRepositorio<Cliente>();
            var cliente = clienteRepo.RetornarPorId(id);
            //produtoRepo.RetornarPorId(Convert.ToInt32(this.cboProduto.SelectedValue.ToString()));

            return cliente;
        }

        private static FormaPagamento consultaFormaPagamentoSelecionada(int id)
        {

            FormaPagamentoRepositorio<FormaPagamento> formaPagamentoRepo = new FormaPagamentoRepositorio<FormaPagamento>();
            var formaPagamento = formaPagamentoRepo.RetornarPorId(id);

            return formaPagamento;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Enum.TryParse<SituacaoPedido>(cboSituacao.SelectedValue.ToString(), out situacaoPedido);
            int valueSituacaoPedido = (int)situacaoPedido;

            errorProvider1.Clear();
            if (cboCliente.Text == string.Empty)
            {
                errorProvider1.SetError(cboCliente, "Selecione o cliente do pedido.");
                cboCliente.Focus();
                return;
            }
            if (cboFormaPagamento.Text == string.Empty)
            {
                errorProvider1.SetError(cboFormaPagamento, "Selecione a forma de pagamento do pedido.");
                cboFormaPagamento.Focus();
                return;
            }
            if (dtpPrevisaoPagamento.Text == string.Empty)
            {
                errorProvider1.SetError(dtpPrevisaoPagamento, "Informe a data de previsão de pagamento.");
                dtpPrevisaoPagamento.Focus();
                return;
            }
            if (cboSituacao.Text == string.Empty)
            {
                errorProvider1.SetError(cboSituacao, "Informe a situação do pedido.");
                cboSituacao.Focus();
                return;
            }
            if (cboSituacao.Text == "PAGO" && dtpDataPagamento.Text == string.Empty)
            {
                errorProvider1.SetError(dtpDataPagamento, "Informe a data de pagamento do pedido.");
                dtpDataPagamento.Focus();
                return;
            }
            if (dgvPedidoItem.Rows.Count  == 0)
            {
                errorProvider1.SetError(cboProduto, "Inclua pelo menos um produto ao pedido.");
                cboProduto.Focus();
                return;
            }
            if (valueSituacaoPedido == 3 && txtMotivo.Text == string.Empty)
            {
                errorProvider1.SetError(txtMotivo, "Informe o motivo do cancelamento do pedido.");
                txtMotivo.Focus();
                return;
            }


            PedidoRepositorio<Pedido> pedidoRepo = new PedidoRepositorio<Pedido>();

            try
            {
                Pedido pedido = new Pedido();
                IList<PedidoItem> pedidoItem = new List<PedidoItem>();
                Cliente cliente = new Cliente();

                //Recupera as informações do cliente selecionado no combo Clientes.
                //Atualiza a classe cliente instanciada na classe pedido
                pedido.Cliente = consultaClienteSelecionado(Convert.ToInt32(this.cboCliente.SelectedValue.ToString()));

                //Recupera as informações do cliente selecionado no combo Clientes.
                //Atualiza a classe cliente instanciada na classe pedido
                pedido.FormaPagamento = consultaFormaPagamentoSelecionada(Convert.ToInt32(this.cboFormaPagamento.SelectedValue.ToString()));


                pedido.Id = idPedido;
                pedido.Usuario.Id = Global.idUsuario;
                pedido.Data_Inclusao = DateTime.Now;
                pedido.Data_Previsao_Pagamento =Convert.ToDateTime( dtpPrevisaoPagamento.Text);
                pedido.Valor_Total = Convert.ToDecimal(txtValorPedido.Text);
                pedido.Status = situacaoPedido;
                
                //pedido.Data_Pagamento = Convert.ToDateTime(dtpDataPagamento.Text);
                //pedido.Data_Registro_Pagamento = DateTime.Now;

                
                //Enum.TryParse<SituacaoPedido>(cboSituacao.SelectedValue.ToString(), out situacaoPedido);
                //int value = (int)situacaoPedido;
                //pedido.Status =Convert.ToString(value);
                //pedido.Status = situacaoPedido;

                //Preencher somente quando a situação do pedido for Pago
                if (valueSituacaoPedido == 2)
                {
                    //pedido.UsuarioPagamento.Id = Global.idUsuario;
                    pedido.Status = situacaoPedido;
                    pedido.Data_Pagamento = Convert.ToDateTime(dtpDataPagamento.Text);
                    pedido.Data_Registro_Pagamento = DateTime.Now;
                }
                else if(valueSituacaoPedido == 3)
                {
                    pedido.Status = situacaoPedido;
                    pedido.Motivo_Cancelamento = txtMotivo.Text.Trim();
                }
                

                

                // Processo de inclusão
                if (pedido.Id == 0)
                {
                    //Percorre o datagridview se o processo for de inclusão
                    foreach (DataGridViewRow dr in dgvPedidoItem.Rows)
                    {
                        var lstPedidoItem = new PedidoItem();
                        //lstPedidoItem.Id = Convert.ToInt32(dr.Cells[0].Value.ToString());
                        lstPedidoItem.Produto.Id = Convert.ToInt32(dr.Cells[1].Value.ToString());
                        lstPedidoItem.Quantidade = Convert.ToInt32(dr.Cells[3].Value.ToString());
                        lstPedidoItem.Valor_Unitario = Convert.ToDecimal(dr.Cells[4].Value.ToString());
                        lstPedidoItem.Valor_Total = Convert.ToDecimal(dr.Cells[5].Value.ToString());

                        pedidoItem.Add(lstPedidoItem);

                        //MessageBox.Show("Produto " + lstPedidoItem.Produto.Id + " valor unitário" + lstPedidoItem.Valor_Unitario);

                    }


                    pedidoRepo.InserirPedidoItem(pedido, pedidoItem);
                    MessageBox.Show("Cadastro realizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close();
                }
                else
                {
                    //Cenário que ocorre no processo de edição

                    // Valida a opção selecionada no combo situação do pedido
                    if (valueSituacaoPedido == 2)
                    {
                        pedidoUpdate.Data_Pagamento = Convert.ToDateTime(dtpDataPagamento.Text);
                        pedidoUpdate.Data_Registro_Pagamento = DateTime.Now;
                        pedidoUpdate.Status = situacaoPedido;
                    }
                    else if (valueSituacaoPedido == 3)
                    {
                        pedidoUpdate.Status = situacaoPedido;
                        pedidoUpdate.Motivo_Cancelamento = txtMotivo.Text.Trim();
                    }

                    pedidoRepo.Alterar(pedidoUpdate);
                    MessageBox.Show("Alteração realizada com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro na operação " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnIncluirPedidoItem_Click(object sender, EventArgs e)
        {
            if (produtoId != string.Empty && txtQuantidade.Text.Trim() != string.Empty)
            {
                btnIncluirPedidoItem.Enabled = false;

                dgvPedidoItem.Rows.Insert(0, null, produtoId, produtoDescricao, produtoQuantidade, produtoValor, produtoValorTotal);
                dgvPedidoItem.Refresh();

                limpaVariaveisCampos();
                RecalculaValorPedido();
            }
            else
            {
                MessageBox.Show("Selecione um produto e informe a quantidade", "Notificação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvPedidoItem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            /// Este evento é disparado quando o usuário clica no conteúdo de uma célula
            /// Vamos exibir uma mensagem contendo os valores true ou valse refletindo os 
            /// o valores da coluna checkbox
            /// 
            //Verificamos se e somente se a celula checkbox (Estado) foi clicada
            /*if (e.ColumnIndex == dgvPedidoItem.Columns["clnChk"].Index)
            {
                if(dgvPedidoItem.Rows[e.RowIndex].Cells[0].Value == null)
                {
                    dgvPedidoItem.Rows[e.RowIndex].Cells[0].Value = true;
                }
                else if((bool)dgvPedidoItem.Rows[e.RowIndex].Cells[0].Value == true)
                {
                    dgvPedidoItem.Rows[e.RowIndex].Cells[0].Value = false;
                }
                else
                {
                    dgvPedidoItem.Rows[e.RowIndex].Cells[0].Value = true;
                }

                //interrompe a edição
                dgvPedidoItem.EndEdit();
                //exibe os valores da célula quando clicada: verdadeiro (true) ou falso (false)
                //MessageBox.Show("=> " + dgvPedidoItem.Rows[e.RowIndex].Cells[0].Value);
            }*/

            if (e.ColumnIndex == dgvPedidoItem.Columns["dgvPedidoItemBtnRemover"].Index)
            {
                //MessageBox.Show((e.RowIndex + 1) + "  Row  " + (e.ColumnIndex + 1) + "  Column button clicked ");

                if (this.dgvPedidoItem.SelectedRows.Count > 0)
                {
                    dgvPedidoItem.Rows.RemoveAt(this.dgvPedidoItem.SelectedRows[0].Index);
                }

                RecalculaValorPedido();
            }
        }

        /*//Remove os itens marcados com checkbox no datagridview
        private void button1_Click(object sender, EventArgs e)
        {
            //percorre as linhas do controle DataGridView  
            foreach (DataGridViewRow dr in dgvPedidoItem.Rows)
            {
                
                //valos exibir a linha da [0](Cells[0]) pois ela representa a coluna checkbox 
                //que foi selecionada
                if ((bool)dr.Cells[0].Value == true)
                {
                    MessageBox.Show("Linha " + dr.Index + " foi selecionada");
                }
            }
        }*/

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

        private void cboSituacao_SelectedValueChanged(object sender, EventArgs e)
        {
            Enum.TryParse<SituacaoPedido>(cboSituacao.SelectedValue.ToString(), out situacaoPedido);
            int value = (int)situacaoPedido;
            if(value == 2)
            {
                lblDataPagamento.Visible = true;
                dtpDataPagamento.Visible = true;

                lblMotivo.Visible = false;
                txtMotivo.Visible = false;
            }
            else if(value ==3)
            {
                lblMotivo.Visible = true;
                txtMotivo.Visible = true;

                lblDataPagamento.Visible = false;
                dtpDataPagamento.Visible = false;
            }
            else
            {
                lblDataPagamento.Visible = false;
                dtpDataPagamento.Visible = false;

                lblMotivo.Visible = false;
                txtMotivo.Visible = false;
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboProduto_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*string teste = cboProduto.SelectedIndex.ToString();
            string teste1 = cboProduto.SelectedItem.ToString();
            string teste2 = cboProduto.SelectedText.ToString();
            string teste3 = cboProduto.SelectedValue.ToString();*/

            if (this.cboProduto.SelectedValue.ToString() != "Repositorio.Entidades.Produto")
            {
                consultaProdutoSelecionado(Convert.ToInt32(this.cboProduto.SelectedValue.ToString()));
            }
        }

        
    }
}
