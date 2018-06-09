namespace WinFormsPagueDepois
{
    partial class frmPedido
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPedido));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnSair = new System.Windows.Forms.Button();
            this.btnIncluirPedidoItem = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblQuantidade = new System.Windows.Forms.Label();
            this.txtQuantidade = new System.Windows.Forms.TextBox();
            this.cboProduto = new System.Windows.Forms.ComboBox();
            this.txtValorTotal = new System.Windows.Forms.TextBox();
            this.lblValor = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.dgvPedidoItem = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblDadosCliente = new System.Windows.Forms.Label();
            this.btnIncluirCliente = new System.Windows.Forms.Button();
            this.txtMotivo = new System.Windows.Forms.TextBox();
            this.lblMotivo = new System.Windows.Forms.Label();
            this.txtValorPedido = new System.Windows.Forms.TextBox();
            this.lblValorPedido = new System.Windows.Forms.Label();
            this.lblDataPagamento = new System.Windows.Forms.Label();
            this.dtpDataPagamento = new System.Windows.Forms.DateTimePicker();
            this.cboSituacao = new System.Windows.Forms.ComboBox();
            this.lblSituacao = new System.Windows.Forms.Label();
            this.lblPrevisaoPagamento = new System.Windows.Forms.Label();
            this.dtpPrevisaoPagamento = new System.Windows.Forms.DateTimePicker();
            this.cboFormaPagamento = new System.Windows.Forms.ComboBox();
            this.lblFormaPagamento = new System.Windows.Forms.Label();
            this.cboCliente = new System.Windows.Forms.ComboBox();
            this.lblCliente = new System.Windows.Forms.Label();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.dgvPedidoItemBtnRemover = new System.Windows.Forms.DataGridViewButtonColumn();
            this.rtbInformacoesCliente = new System.Windows.Forms.RichTextBox();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidoItem)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSair
            // 
            this.btnSair.BackColor = System.Drawing.Color.White;
            this.btnSair.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSair.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSair.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSair.Image = ((System.Drawing.Image)(resources.GetObject("btnSair.Image")));
            this.btnSair.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSair.Location = new System.Drawing.Point(672, 609);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(100, 40);
            this.btnSair.TabIndex = 30;
            this.btnSair.Text = "    Sair";
            this.btnSair.UseVisualStyleBackColor = false;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // btnIncluirPedidoItem
            // 
            this.btnIncluirPedidoItem.BackColor = System.Drawing.Color.White;
            this.btnIncluirPedidoItem.Enabled = false;
            this.btnIncluirPedidoItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIncluirPedidoItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIncluirPedidoItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnIncluirPedidoItem.Image = ((System.Drawing.Image)(resources.GetObject("btnIncluirPedidoItem.Image")));
            this.btnIncluirPedidoItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIncluirPedidoItem.Location = new System.Drawing.Point(654, 23);
            this.btnIncluirPedidoItem.Name = "btnIncluirPedidoItem";
            this.btnIncluirPedidoItem.Size = new System.Drawing.Size(100, 31);
            this.btnIncluirPedidoItem.TabIndex = 9;
            this.btnIncluirPedidoItem.Text = "         Incluir";
            this.btnIncluirPedidoItem.UseVisualStyleBackColor = false;
            this.btnIncluirPedidoItem.Click += new System.EventHandler(this.btnIncluirPedidoItem_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblQuantidade);
            this.groupBox2.Controls.Add(this.txtQuantidade);
            this.groupBox2.Controls.Add(this.cboProduto);
            this.groupBox2.Controls.Add(this.txtValorTotal);
            this.groupBox2.Controls.Add(this.lblValor);
            this.groupBox2.Controls.Add(this.lblStatus);
            this.groupBox2.Controls.Add(this.dgvPedidoItem);
            this.groupBox2.Controls.Add(this.btnIncluirPedidoItem);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(12, 251);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(760, 347);
            this.groupBox2.TabIndex = 34;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Itens";
            // 
            // lblQuantidade
            // 
            this.lblQuantidade.AutoSize = true;
            this.lblQuantidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuantidade.ForeColor = System.Drawing.Color.White;
            this.lblQuantidade.Location = new System.Drawing.Point(325, 31);
            this.lblQuantidade.Name = "lblQuantidade";
            this.lblQuantidade.Size = new System.Drawing.Size(92, 20);
            this.lblQuantidade.TabIndex = 38;
            this.lblQuantidade.Text = "Quantidade";
            // 
            // txtQuantidade
            // 
            this.txtQuantidade.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtQuantidade.Enabled = false;
            this.txtQuantidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuantidade.Location = new System.Drawing.Point(416, 28);
            this.txtQuantidade.MaxLength = 6;
            this.txtQuantidade.Name = "txtQuantidade";
            this.txtQuantidade.Size = new System.Drawing.Size(74, 22);
            this.txtQuantidade.TabIndex = 7;
            this.txtQuantidade.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtQuantidade.TextChanged += new System.EventHandler(this.txtQuantidade_TextChanged);
            this.txtQuantidade.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQuantidade_KeyPress);
            // 
            // cboProduto
            // 
            this.cboProduto.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboProduto.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboProduto.FormattingEnabled = true;
            this.cboProduto.Location = new System.Drawing.Point(71, 28);
            this.cboProduto.Name = "cboProduto";
            this.cboProduto.Size = new System.Drawing.Size(234, 24);
            this.cboProduto.Sorted = true;
            this.cboProduto.TabIndex = 6;
            this.cboProduto.SelectedIndexChanged += new System.EventHandler(this.cboProduto_SelectedIndexChanged);
            this.cboProduto.SelectedValueChanged += new System.EventHandler(this.cboSituacao_SelectedValueChanged);
            // 
            // txtValorTotal
            // 
            this.txtValorTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtValorTotal.Enabled = false;
            this.txtValorTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValorTotal.Location = new System.Drawing.Point(556, 28);
            this.txtValorTotal.Name = "txtValorTotal";
            this.txtValorTotal.Size = new System.Drawing.Size(74, 22);
            this.txtValorTotal.TabIndex = 8;
            this.txtValorTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblValor
            // 
            this.lblValor.AutoSize = true;
            this.lblValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValor.ForeColor = System.Drawing.Color.White;
            this.lblValor.Location = new System.Drawing.Point(511, 31);
            this.lblValor.Name = "lblValor";
            this.lblValor.Size = new System.Drawing.Size(46, 20);
            this.lblValor.TabIndex = 34;
            this.lblValor.Text = "Valor";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.White;
            this.lblStatus.Location = new System.Drawing.Point(6, 31);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(65, 20);
            this.lblStatus.TabIndex = 35;
            this.lblStatus.Text = "Produto";
            // 
            // dgvPedidoItem
            // 
            this.dgvPedidoItem.AllowUserToAddRows = false;
            this.dgvPedidoItem.AllowUserToDeleteRows = false;
            this.dgvPedidoItem.AllowUserToResizeColumns = false;
            this.dgvPedidoItem.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSkyBlue;
            this.dgvPedidoItem.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPedidoItem.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvPedidoItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPedidoItem.Location = new System.Drawing.Point(3, 74);
            this.dgvPedidoItem.Name = "dgvPedidoItem";
            this.dgvPedidoItem.ReadOnly = true;
            this.dgvPedidoItem.RowTemplate.ReadOnly = true;
            this.dgvPedidoItem.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPedidoItem.Size = new System.Drawing.Size(754, 267);
            this.dgvPedidoItem.TabIndex = 32;
            this.dgvPedidoItem.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPedidoItem_CellContentClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rtbInformacoesCliente);
            this.groupBox1.Controls.Add(this.lblDadosCliente);
            this.groupBox1.Controls.Add(this.btnIncluirCliente);
            this.groupBox1.Controls.Add(this.txtMotivo);
            this.groupBox1.Controls.Add(this.lblMotivo);
            this.groupBox1.Controls.Add(this.txtValorPedido);
            this.groupBox1.Controls.Add(this.lblValorPedido);
            this.groupBox1.Controls.Add(this.lblDataPagamento);
            this.groupBox1.Controls.Add(this.dtpDataPagamento);
            this.groupBox1.Controls.Add(this.cboSituacao);
            this.groupBox1.Controls.Add(this.lblSituacao);
            this.groupBox1.Controls.Add(this.lblPrevisaoPagamento);
            this.groupBox1.Controls.Add(this.dtpPrevisaoPagamento);
            this.groupBox1.Controls.Add(this.cboFormaPagamento);
            this.groupBox1.Controls.Add(this.lblFormaPagamento);
            this.groupBox1.Controls.Add(this.cboCliente);
            this.groupBox1.Controls.Add(this.lblCliente);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(760, 233);
            this.groupBox1.TabIndex = 35;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dados";
            // 
            // lblDadosCliente
            // 
            this.lblDadosCliente.AutoSize = true;
            this.lblDadosCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDadosCliente.ForeColor = System.Drawing.Color.White;
            this.lblDadosCliente.Location = new System.Drawing.Point(29, 48);
            this.lblDadosCliente.Name = "lblDadosCliente";
            this.lblDadosCliente.Size = new System.Drawing.Size(131, 20);
            this.lblDadosCliente.TabIndex = 49;
            this.lblDadosCliente.Text = "Dados do Cliente";
            // 
            // btnIncluirCliente
            // 
            this.btnIncluirCliente.BackColor = System.Drawing.Color.White;
            this.btnIncluirCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIncluirCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIncluirCliente.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnIncluirCliente.Image = ((System.Drawing.Image)(resources.GetObject("btnIncluirCliente.Image")));
            this.btnIncluirCliente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIncluirCliente.Location = new System.Drawing.Point(654, 15);
            this.btnIncluirCliente.Name = "btnIncluirCliente";
            this.btnIncluirCliente.Size = new System.Drawing.Size(100, 33);
            this.btnIncluirCliente.TabIndex = 47;
            this.btnIncluirCliente.Text = "         Incluir";
            this.btnIncluirCliente.UseVisualStyleBackColor = false;
            this.btnIncluirCliente.Click += new System.EventHandler(this.btnIncluirCliente_Click);
            // 
            // txtMotivo
            // 
            this.txtMotivo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMotivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMotivo.Location = new System.Drawing.Point(290, 197);
            this.txtMotivo.MaxLength = 100;
            this.txtMotivo.Name = "txtMotivo";
            this.txtMotivo.Size = new System.Drawing.Size(464, 22);
            this.txtMotivo.TabIndex = 46;
            this.txtMotivo.Visible = false;
            // 
            // lblMotivo
            // 
            this.lblMotivo.AutoSize = true;
            this.lblMotivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMotivo.ForeColor = System.Drawing.Color.White;
            this.lblMotivo.Location = new System.Drawing.Point(105, 197);
            this.lblMotivo.Name = "lblMotivo";
            this.lblMotivo.Size = new System.Drawing.Size(55, 20);
            this.lblMotivo.TabIndex = 45;
            this.lblMotivo.Text = "Motivo";
            this.lblMotivo.Visible = false;
            // 
            // txtValorPedido
            // 
            this.txtValorPedido.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtValorPedido.Enabled = false;
            this.txtValorPedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValorPedido.Location = new System.Drawing.Point(510, 164);
            this.txtValorPedido.Name = "txtValorPedido";
            this.txtValorPedido.ReadOnly = true;
            this.txtValorPedido.Size = new System.Drawing.Size(120, 26);
            this.txtValorPedido.TabIndex = 39;
            this.txtValorPedido.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblValorPedido
            // 
            this.lblValorPedido.AutoSize = true;
            this.lblValorPedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorPedido.ForeColor = System.Drawing.Color.White;
            this.lblValorPedido.Location = new System.Drawing.Point(383, 167);
            this.lblValorPedido.Name = "lblValorPedido";
            this.lblValorPedido.Size = new System.Drawing.Size(121, 20);
            this.lblValorPedido.TabIndex = 44;
            this.lblValorPedido.Text = "Valor do Pedido";
            // 
            // lblDataPagamento
            // 
            this.lblDataPagamento.AutoSize = true;
            this.lblDataPagamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataPagamento.ForeColor = System.Drawing.Color.White;
            this.lblDataPagamento.Location = new System.Drawing.Point(30, 197);
            this.lblDataPagamento.Name = "lblDataPagamento";
            this.lblDataPagamento.Size = new System.Drawing.Size(130, 20);
            this.lblDataPagamento.TabIndex = 43;
            this.lblDataPagamento.Text = "Data Pagamento";
            this.lblDataPagamento.Visible = false;
            // 
            // dtpDataPagamento
            // 
            this.dtpDataPagamento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataPagamento.Location = new System.Drawing.Point(166, 197);
            this.dtpDataPagamento.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtpDataPagamento.Name = "dtpDataPagamento";
            this.dtpDataPagamento.Size = new System.Drawing.Size(121, 22);
            this.dtpDataPagamento.TabIndex = 5;
            // 
            // cboSituacao
            // 
            this.cboSituacao.AutoCompleteCustomSource.AddRange(new string[] {
            "PENDENTE",
            "PAGO"});
            this.cboSituacao.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboSituacao.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboSituacao.FormattingEnabled = true;
            this.cboSituacao.Location = new System.Drawing.Point(166, 164);
            this.cboSituacao.Name = "cboSituacao";
            this.cboSituacao.Size = new System.Drawing.Size(200, 24);
            this.cboSituacao.TabIndex = 4;
            this.cboSituacao.SelectedValueChanged += new System.EventHandler(this.cboSituacao_SelectedValueChanged);
            // 
            // lblSituacao
            // 
            this.lblSituacao.AutoSize = true;
            this.lblSituacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSituacao.ForeColor = System.Drawing.Color.White;
            this.lblSituacao.Location = new System.Drawing.Point(88, 167);
            this.lblSituacao.Name = "lblSituacao";
            this.lblSituacao.Size = new System.Drawing.Size(72, 20);
            this.lblSituacao.TabIndex = 41;
            this.lblSituacao.Text = "Situação";
            // 
            // lblPrevisaoPagamento
            // 
            this.lblPrevisaoPagamento.AutoSize = true;
            this.lblPrevisaoPagamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrevisaoPagamento.ForeColor = System.Drawing.Color.White;
            this.lblPrevisaoPagamento.Location = new System.Drawing.Point(5, 137);
            this.lblPrevisaoPagamento.Name = "lblPrevisaoPagamento";
            this.lblPrevisaoPagamento.Size = new System.Drawing.Size(155, 20);
            this.lblPrevisaoPagamento.TabIndex = 39;
            this.lblPrevisaoPagamento.Text = "Previsão Pagamento";
            // 
            // dtpPrevisaoPagamento
            // 
            this.dtpPrevisaoPagamento.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpPrevisaoPagamento.Location = new System.Drawing.Point(166, 136);
            this.dtpPrevisaoPagamento.Name = "dtpPrevisaoPagamento";
            this.dtpPrevisaoPagamento.Size = new System.Drawing.Size(273, 22);
            this.dtpPrevisaoPagamento.TabIndex = 3;
            // 
            // cboFormaPagamento
            // 
            this.cboFormaPagamento.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboFormaPagamento.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboFormaPagamento.FormattingEnabled = true;
            this.cboFormaPagamento.Location = new System.Drawing.Point(166, 102);
            this.cboFormaPagamento.Name = "cboFormaPagamento";
            this.cboFormaPagamento.Size = new System.Drawing.Size(464, 24);
            this.cboFormaPagamento.TabIndex = 2;
            // 
            // lblFormaPagamento
            // 
            this.lblFormaPagamento.AutoSize = true;
            this.lblFormaPagamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormaPagamento.ForeColor = System.Drawing.Color.White;
            this.lblFormaPagamento.Location = new System.Drawing.Point(19, 97);
            this.lblFormaPagamento.Name = "lblFormaPagamento";
            this.lblFormaPagamento.Size = new System.Drawing.Size(141, 20);
            this.lblFormaPagamento.TabIndex = 37;
            this.lblFormaPagamento.Text = "Forma Pagamento";
            // 
            // cboCliente
            // 
            this.cboCliente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboCliente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboCliente.FormattingEnabled = true;
            this.cboCliente.Location = new System.Drawing.Point(166, 21);
            this.cboCliente.Name = "cboCliente";
            this.cboCliente.Size = new System.Drawing.Size(464, 24);
            this.cboCliente.TabIndex = 1;
            this.cboCliente.SelectedValueChanged += new System.EventHandler(this.cboCliente_SelectedValueChanged);
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCliente.ForeColor = System.Drawing.Color.White;
            this.lblCliente.Location = new System.Drawing.Point(102, 24);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(58, 20);
            this.lblCliente.TabIndex = 35;
            this.lblCliente.Text = "Cliente";
            // 
            // btnSalvar
            // 
            this.btnSalvar.BackColor = System.Drawing.Color.White;
            this.btnSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalvar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalvar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSalvar.Image = global::WinFormsPagueDepois.Properties.Resources.salvar_32;
            this.btnSalvar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalvar.Location = new System.Drawing.Point(12, 609);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(100, 40);
            this.btnSalvar.TabIndex = 10;
            this.btnSalvar.Text = "         Salvar";
            this.btnSalvar.UseVisualStyleBackColor = false;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // dgvPedidoItemBtnRemover
            // 
            this.dgvPedidoItemBtnRemover.Name = "dgvPedidoItemBtnRemover";
            // 
            // rtbInformacoesCliente
            // 
            this.rtbInformacoesCliente.Enabled = false;
            this.rtbInformacoesCliente.Location = new System.Drawing.Point(166, 55);
            this.rtbInformacoesCliente.Name = "rtbInformacoesCliente";
            this.rtbInformacoesCliente.Size = new System.Drawing.Size(464, 37);
            this.rtbInformacoesCliente.TabIndex = 50;
            this.rtbInformacoesCliente.Text = "";
            // 
            // frmPedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DodgerBlue;
            this.ClientSize = new System.Drawing.Size(784, 661);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "frmPedido";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pedido";
            this.Load += new System.EventHandler(this.frmPedido_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidoItem)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Button btnIncluirPedidoItem;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvPedidoItem;
        private System.Windows.Forms.Label lblValor;
        private System.Windows.Forms.TextBox txtValorTotal;
        private System.Windows.Forms.Label lblQuantidade;
        private System.Windows.Forms.TextBox txtQuantidade;
        internal System.Windows.Forms.ComboBox cboProduto;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.ComboBox cboCliente;
        private System.Windows.Forms.Label lblCliente;
        internal System.Windows.Forms.ComboBox cboFormaPagamento;
        private System.Windows.Forms.Label lblFormaPagamento;
        private System.Windows.Forms.Label lblPrevisaoPagamento;
        private System.Windows.Forms.DateTimePicker dtpPrevisaoPagamento;
        private System.Windows.Forms.Label lblDataPagamento;
        private System.Windows.Forms.DateTimePicker dtpDataPagamento;
        internal System.Windows.Forms.ComboBox cboSituacao;
        private System.Windows.Forms.Label lblSituacao;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.DataGridViewButtonColumn dgvPedidoItemBtnRemover;
        private System.Windows.Forms.TextBox txtValorPedido;
        private System.Windows.Forms.Label lblValorPedido;
        private System.Windows.Forms.TextBox txtMotivo;
        private System.Windows.Forms.Label lblMotivo;
        private System.Windows.Forms.Button btnIncluirCliente;
        private System.Windows.Forms.Label lblDadosCliente;
        private System.Windows.Forms.RichTextBox rtbInformacoesCliente;
        //private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}