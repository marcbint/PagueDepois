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


using Microsoft.Office.Interop.Excel;
using System.Reflection;
using OfficeOpenXml;
using System.IO;
using OfficeOpenXml.Style;

namespace WinFormsPagueDepois
{
    public partial class frmPedidoCon : Form
    {
        SituacaoPedido situacaoPedido;

        IList<Pedido> PedidoRelatorio;


        public frmPedidoCon()
        {
            InitializeComponent();
        }

        private void frmPedidoCon_Load(object sender, EventArgs e)
        {
            LoadSituacaoCombo<SituacaoPedido>(cboSituacao);
            txtCliente.Focus();
            //criaDataGrid();
        }

        private void criaDataGrid()
        {
            PedidoRepositorio<Pedido> pedidoRepo = new PedidoRepositorio<Pedido>();
            IList<Pedido> objetoPedido = pedidoRepo.Consultar();

            //IList<Pedido> objetoPedido = pedidoRepo.Pesquisar(txtCliente.Text, situacaoPedido);

            var lista = objetoPedido.Select(s => new
            {
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
            dgvPedidos.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font(dgvPedidos.Font, FontStyle.Bold);
            dgvPedidos.ForeColor = Color.Black;


            //Propriedades
            dgvPedidos.Name = "dgvPedidos";
            dgvPedidos.Location = new System.Drawing.Point(8, 8);
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

                //Remonta o grid apos o processo de edição ou exclusao.
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

            PedidoRelatorio = pesquisar();
        }


        private IList<Pedido> pesquisar()
        {
            PedidoRepositorio<Pedido> pedidoRepo = new PedidoRepositorio<Pedido>();

            Enum.TryParse<SituacaoPedido>(cboSituacao.SelectedValue.ToString(), out situacaoPedido);
            int value = (int)situacaoPedido;

            IList<Pedido> objetoPedido = pedidoRepo.Pesquisar(txtCliente.Text, situacaoPedido, Convert.ToDateTime(dtpPrevisaoPagamento.Text), Convert.ToDateTime(dtpDataPagamento.Text), Convert.ToDateTime(dtpDataCancelamento.Text), txtAno.Text, txtMes.Text);

            var lista = objetoPedido.Select(s => new
            {
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
            dgvPedidos.Columns[0].HeaderText = "Pedido";
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
                        
            return objetoPedido;
            
        }

        private void pesquisarOld()
        {
            PedidoRepositorio<Pedido> pedidoRepo = new PedidoRepositorio<Pedido>();

            Enum.TryParse<SituacaoPedido>(cboSituacao.SelectedValue.ToString(), out situacaoPedido);
            int value = (int)situacaoPedido;

            IList<Pedido> objetoPedido = pedidoRepo.Pesquisar(txtCliente.Text, situacaoPedido, Convert.ToDateTime(dtpPrevisaoPagamento.Text), Convert.ToDateTime(dtpDataPagamento.Text), Convert.ToDateTime(dtpDataCancelamento.Text), txtAno.Text, txtMes.Text);

            var lista = objetoPedido.Select(s => new
            {
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


        private void rdbAnoMes_Click(object sender, EventArgs e)
        {

            if (rdbAnoMes.Checked == true)//Pendete
            {
                txtAno.Enabled = true;
                txtAno.Visible = true;
                txtMes.Enabled = true;
                txtMes.Visible = true;
                lblAno.Visible = true;
                lblMes.Visible = true;
                lblDataPagamento.Visible = false;
                dtpDataPagamento.Enabled = false;
                dtpDataPagamento.Visible = false;
                lblPrevisaoPagamento.Visible = false;
                dtpPrevisaoPagamento.Enabled = false;
                dtpPrevisaoPagamento.Visible = false;
                lblDataCancelamento.Visible = false;
                dtpDataCancelamento.Enabled = false;
                dtpDataCancelamento.Visible = false;
            }



        }

        private void rdbDia_Click(object sender, EventArgs e)
        {
            Enum.TryParse<SituacaoPedido>(cboSituacao.SelectedValue.ToString(), out situacaoPedido);
            int value = (int)situacaoPedido;
            if (rdbDia.Checked == true && value == 1)//Pendente
            {
                dtpPrevisaoPagamento.Enabled = true;
                dtpPrevisaoPagamento.Visible = true;
                lblPrevisaoPagamento.Visible = true;
                dtpDataPagamento.Enabled = false;
                dtpDataPagamento.Visible = false;
                lblDataPagamento.Visible = false;
                dtpDataCancelamento.Enabled = false;
                dtpDataCancelamento.Visible = false;
                lblDataCancelamento.Visible = false;
                lblAno.Visible = false;
                lblMes.Visible = false;
                txtAno.Visible = false;
                txtMes.Visible = false;
            }
            else if (rdbDia.Checked == true && value == 2)//Pago
            {
                dtpPrevisaoPagamento.Enabled = false;
                dtpPrevisaoPagamento.Visible = false;
                lblPrevisaoPagamento.Visible = false;
                dtpDataPagamento.Enabled = true;
                dtpDataPagamento.Visible = true;
                lblDataPagamento.Visible = true;
                dtpDataCancelamento.Enabled = false;
                dtpDataCancelamento.Visible = false;
                lblDataCancelamento.Visible = false;
                lblAno.Visible = false;
                lblMes.Visible = false;
                txtAno.Visible = false;
                txtMes.Visible = false;
            }
            else if (rdbDia.Checked == true && value == 3)//Cancelado
            {
                dtpPrevisaoPagamento.Enabled = false;
                dtpPrevisaoPagamento.Visible = false;
                lblPrevisaoPagamento.Visible = false;
                dtpDataPagamento.Enabled = false;
                dtpDataPagamento.Visible = false;
                lblDataPagamento.Visible = false;
                dtpDataCancelamento.Enabled = true;
                dtpDataCancelamento.Visible = true;
                lblDataCancelamento.Visible = true;
                lblAno.Visible = false;
                lblMes.Visible = false;
                txtAno.Visible = false;
                txtMes.Visible = false;
            }


        }

        private void cboSituacao_SelectedValueChanged(object sender, EventArgs e)
        {
            Enum.TryParse<SituacaoPedido>(cboSituacao.SelectedValue.ToString(), out situacaoPedido);
            int value = (int)situacaoPedido;

            if (value == 1 && rdbDia.Checked == true)// Pendente
            {
                dtpPrevisaoPagamento.Enabled = true;
                dtpPrevisaoPagamento.Visible = true;
                lblPrevisaoPagamento.Visible = true;
                dtpDataPagamento.Enabled = false;
                dtpDataPagamento.Visible = false;
                lblDataPagamento.Visible = false;
                dtpDataCancelamento.Enabled = false;
                dtpDataCancelamento.Visible = false;
                lblDataCancelamento.Visible = false;
                lblAno.Visible = false;
                lblMes.Visible = false;
                txtAno.Visible = false;
                txtMes.Visible = false;
            }
            else if (value == 2 && rdbDia.Checked == true) //Pago
            {
                dtpPrevisaoPagamento.Enabled = false;
                dtpPrevisaoPagamento.Visible = false;
                lblPrevisaoPagamento.Visible = false;
                dtpDataPagamento.Enabled = true;
                dtpDataPagamento.Visible = true;
                lblDataPagamento.Visible = true;
                dtpDataCancelamento.Enabled = false;
                dtpDataCancelamento.Visible = false;
                lblDataCancelamento.Visible = false;
                lblAno.Visible = false;
                lblMes.Visible = false;
                txtAno.Visible = false;
                txtMes.Visible = false;
            }
            else if (value == 3 && rdbDia.Checked == true) // Cancelado
            {
                dtpPrevisaoPagamento.Enabled = false;
                dtpPrevisaoPagamento.Visible = false;
                lblPrevisaoPagamento.Visible = false;
                dtpDataPagamento.Enabled = false;
                dtpDataPagamento.Visible = false;
                lblDataPagamento.Visible = false;
                dtpDataCancelamento.Enabled = true;
                dtpDataCancelamento.Visible = true;
                lblDataCancelamento.Visible = true;
                lblAno.Visible = false;
                lblMes.Visible = false;
                txtAno.Visible = false;
                txtMes.Visible = false;
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

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (dgvPedidos.Rows.Count > 0)
            {
                //Mesmo objeto retornado no processo de pesquisa
                GenerateExcel(PedidoRelatorio);
            }
            else
            {
                MessageBox.Show("Realize o processo de pesquisa!");
            }
        }

        public void GenerateExcel(IList<Pedido> objPedido)
        {
            try{ 

            string p_strPath = @"C:\Excel\Pedidos_" + DateTime.Now.ToString("yyyy-MM-dd--HH-mm-ss") + ".xlsx";


                using (ExcelPackage objExcelPackage = new ExcelPackage())
                {

                    var workSheet = objExcelPackage.Workbook.Worksheets.Add("Pedidos");
                    workSheet.TabColor = System.Drawing.Color.Black;
                    workSheet.DefaultRowHeight = 12;


                    objExcelPackage.Workbook.Properties.Author = "PagueDepois";
                    objExcelPackage.Workbook.Properties.Title = "Meus Pedidos";



                    //Cria o cabeçalho das colunas
                    workSheet.Row(1).Height = 20;
                    Color colFromHex = System.Drawing.ColorTranslator.FromHtml("#4682B4");

                    using (ExcelRange objRange = workSheet.Cells["A1:S1"])
                    {
                        
                        objRange.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        objRange.Style.Font.Bold = true;
                        objRange.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        objRange.Style.Font.Color.SetColor(Color.White);

                        objRange.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        objRange.Style.Fill.BackgroundColor.SetColor(colFromHex);
                       
                    }
                                        
                    workSheet.Cells[1, 1].Value = "Pedido";
                    workSheet.Cells[1, 2].Value = "Nome/Razão Fantasia";
                    workSheet.Cells[1, 3].Value = "Endereço";
                    workSheet.Cells[1, 4].Value = "Número";
                    workSheet.Cells[1, 5].Value = "Complemento";
                    workSheet.Cells[1, 6].Value = "Bairro";
                    workSheet.Cells[1, 7].Value = "Cidade";
                    workSheet.Cells[1, 8].Value = "UF";
                    workSheet.Cells[1, 9].Value = "Contato";
                    workSheet.Cells[1, 10].Value = "Telefone";
                    workSheet.Cells[1, 11].Value = "Email";
                    workSheet.Cells[1, 12].Value = "Data Pedido";
                    workSheet.Cells[1, 13].Value = "Previsão Pagamento";
                    workSheet.Cells[1, 14].Value = "Data Pagamento";
                    workSheet.Cells[1, 15].Value = "Valor";
                    workSheet.Cells[1, 16].Value = "Forma Pagamento";
                    workSheet.Cells[1, 17].Value = "Situação";
                    workSheet.Cells[1, 18].Value = "Data Cancelamento";
                    workSheet.Cells[1, 19].Value = "Usuário Atualização";



                    //Mesmo processo de pesquisa da tela de relatórios
                    //PedidoRepositorio<Pedido> pedidoRepo = new PedidoRepositorio<Pedido>();
                    //IList<Pedido> objetoPedido = pedidoRepo.Pesquisar(txtCliente.Text, situacaoPedido, Convert.ToDateTime(dtpPrevisaoPagamento.Text), Convert.ToDateTime(dtpDataPagamento.Text), Convert.ToDateTime(dtpDataCancelamento.Text), txtAno.Text, txtMes.Text);

                    //Mesmo objeto retornado no processo de pesquisa
                    var lista = objPedido.Select(s => new
                    {
                        Id                  = s.Id,
                        ClienteNome         = s.Cliente.NomeRazao,
                        ClienteEndereco     = s.Cliente.Endereco,
                        ClienteNumero       = s.Cliente.Numero,
                        ClienteComplemento  = s.Cliente.Complemento,
                        ClienteBairro       = s.Cliente.Bairro,
                        ClienteCidade       = s.Cliente.Cidade,
                        ClienteUf           = s.Cliente.Uf,
                        ClienteContato      = s.Cliente.Contato,
                        ClienteTelefone     = s.Cliente.Ddd + "-" + s.Cliente.Telefone,
                        ClienteEmail        = s.Cliente.Email,
                        DataPedido          = s.Data_Inclusao,
                        PrevisaoPagamento   = s.Data_Previsao_Pagamento,
                        DataPagamento       = s.Data_Registro_Pagamento,
                        Valor               = s.Valor_Total,
                        FormaPagamento      = s.FormaPagamento.Tipo + " - " + s.FormaPagamento.Descricao,
                        Situacao            = s.Status,
                        DataCancelamento    = s.Data_Cancelamento,
                        UsuarioAtualizacao  = s.Usuario.Nome                                                    
                    })
                       .OrderBy(x => x.ClienteNome)
                       //.Sum(item => item.valor)
                       //.GroupBy(x => x.Id)
                       .ToList();



                    int recordIndex = 2;
                    foreach (var objLista in lista)
                    {
                        //workSheet.Cells[recordIndex, 1].Value = (recordIndex - 1).ToString();
                        workSheet.Cells[recordIndex, 1].Value = objLista.Id;
                        workSheet.Cells[recordIndex, 2].Value = objLista.ClienteNome;
                        workSheet.Cells[recordIndex, 3].Value = objLista.ClienteEndereco;
                        workSheet.Cells[recordIndex, 4].Value = objLista.ClienteNumero;
                        workSheet.Cells[recordIndex, 5].Value = objLista.ClienteComplemento;
                        workSheet.Cells[recordIndex, 6].Value = objLista.ClienteBairro;
                        workSheet.Cells[recordIndex, 7].Value = objLista.ClienteCidade;
                        workSheet.Cells[recordIndex, 8].Value = objLista.ClienteUf;
                        workSheet.Cells[recordIndex, 9].Value = objLista.ClienteContato;
                        workSheet.Cells[recordIndex, 10].Value = objLista.ClienteTelefone;
                        workSheet.Cells[recordIndex, 11].Value = objLista.ClienteEmail;
                        workSheet.Cells[recordIndex, 12].Value = objLista.DataPedido.ToString("dd/MM/yyyy HH:mm:ss");
                        workSheet.Cells[recordIndex, 13].Value = objLista.PrevisaoPagamento.ToString("dd/MM/yyyy");
                        workSheet.Cells[recordIndex, 14].Value = objLista.DataPagamento; //.ToString("dd/MM/yyyy");
                        workSheet.Cells[recordIndex, 15].Value = objLista.Valor.ToString("N2");
                        workSheet.Cells[recordIndex, 16].Value = objLista.FormaPagamento;
                        workSheet.Cells[recordIndex, 17].Value = objLista.Situacao;
                        workSheet.Cells[recordIndex, 18].Value = objLista.DataCancelamento; //.ToString("dd/MM/yyyy");
                        workSheet.Cells[recordIndex, 19].Value = objLista.UsuarioAtualizacao;


                        recordIndex++;
                    }

                    //Auto preenchimento
                    workSheet.Column(1).AutoFit();
                    workSheet.Column(2).AutoFit();
                    workSheet.Column(3).AutoFit();
                    workSheet.Column(4).AutoFit();
                    workSheet.Column(5).AutoFit();
                    workSheet.Column(6).AutoFit();
                    workSheet.Column(7).AutoFit();
                    workSheet.Column(8).AutoFit();
                    workSheet.Column(9).AutoFit();
                    workSheet.Column(10).AutoFit();
                    workSheet.Column(11).AutoFit();
                    workSheet.Column(12).AutoFit();
                    workSheet.Column(13).AutoFit();
                    workSheet.Column(14).AutoFit();
                    workSheet.Column(15).AutoFit();
                    workSheet.Column(16).AutoFit();
                    workSheet.Column(17).AutoFit();
                    workSheet.Column(18).AutoFit();
                    workSheet.Column(19).AutoFit();
                    

                    //Write it back to the client    
                    if (File.Exists(p_strPath))
                        File.Delete(p_strPath);

                    //Create excel file on physical disk    
                    FileStream objFileStrm = File.Create(p_strPath);
                    objFileStrm.Close();

                    //Write content to excel file    
                    File.WriteAllBytes(p_strPath, objExcelPackage.GetAsByteArray());
                }

                MessageBox.Show("Arquivo gerado com sucesso!");
                
                //Abrir o arquivo
                System.Diagnostics.Process.Start(p_strPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.ToString());
            }
        }
    }
}
