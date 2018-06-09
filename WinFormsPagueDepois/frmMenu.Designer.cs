namespace WinFormsPagueDepois
{
    partial class frmMenu
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
            this.Label1 = new System.Windows.Forms.Label();
            this.btnPedido = new System.Windows.Forms.Button();
            this.btnClientes = new System.Windows.Forms.Button();
            this.Button4 = new System.Windows.Forms.Button();
            this.btnFormaPagamento = new System.Windows.Forms.Button();
            this.btnRelatorioPedidos = new System.Windows.Forms.Button();
            this.Button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Label1
            // 
            this.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Label1.AutoSize = true;
            this.Label1.BackColor = System.Drawing.Color.DodgerBlue;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.White;
            this.Label1.Location = new System.Drawing.Point(202, 47);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(398, 42);
            this.Label1.TabIndex = 11;
            this.Label1.Text = "Sistema Pague Depois";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnPedido
            // 
            this.btnPedido.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnPedido.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnPedido.Image = global::WinFormsPagueDepois.Properties.Resources.pedidos_102;
            this.btnPedido.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnPedido.Location = new System.Drawing.Point(132, 92);
            this.btnPedido.Name = "btnPedido";
            this.btnPedido.Size = new System.Drawing.Size(158, 128);
            this.btnPedido.TabIndex = 1;
            this.btnPedido.Text = "Pedidos";
            this.btnPedido.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPedido.UseVisualStyleBackColor = false;
            this.btnPedido.Click += new System.EventHandler(this.btnPedido_Click);
            // 
            // btnClientes
            // 
            this.btnClientes.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnClientes.BackColor = System.Drawing.Color.White;
            this.btnClientes.Image = global::WinFormsPagueDepois.Properties.Resources.clientes_102;
            this.btnClientes.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnClientes.Location = new System.Drawing.Point(512, 92);
            this.btnClientes.Name = "btnClientes";
            this.btnClientes.Size = new System.Drawing.Size(158, 128);
            this.btnClientes.TabIndex = 3;
            this.btnClientes.Text = "Clientes";
            this.btnClientes.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnClientes.UseVisualStyleBackColor = false;
            this.btnClientes.Click += new System.EventHandler(this.btnClientes_Click);
            // 
            // Button4
            // 
            this.Button4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Button4.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Button4.Image = global::WinFormsPagueDepois.Properties.Resources.usuarios_102;
            this.Button4.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Button4.Location = new System.Drawing.Point(322, 233);
            this.Button4.Name = "Button4";
            this.Button4.Size = new System.Drawing.Size(158, 131);
            this.Button4.TabIndex = 5;
            this.Button4.Text = "Usuários";
            this.Button4.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Button4.UseVisualStyleBackColor = false;
            this.Button4.Click += new System.EventHandler(this.btnUsuarios_Click);
            // 
            // btnFormaPagamento
            // 
            this.btnFormaPagamento.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnFormaPagamento.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnFormaPagamento.Image = global::WinFormsPagueDepois.Properties.Resources.forma_pagamento;
            this.btnFormaPagamento.Location = new System.Drawing.Point(512, 236);
            this.btnFormaPagamento.Name = "btnFormaPagamento";
            this.btnFormaPagamento.Size = new System.Drawing.Size(158, 131);
            this.btnFormaPagamento.TabIndex = 6;
            this.btnFormaPagamento.Text = "Formas de Pagamento";
            this.btnFormaPagamento.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnFormaPagamento.UseVisualStyleBackColor = false;
            this.btnFormaPagamento.Click += new System.EventHandler(this.btnFormaPagamento_Click);
            // 
            // btnRelatorioPedidos
            // 
            this.btnRelatorioPedidos.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnRelatorioPedidos.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnRelatorioPedidos.Image = global::WinFormsPagueDepois.Properties.Resources.relatorio_102;
            this.btnRelatorioPedidos.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnRelatorioPedidos.Location = new System.Drawing.Point(322, 92);
            this.btnRelatorioPedidos.Name = "btnRelatorioPedidos";
            this.btnRelatorioPedidos.Size = new System.Drawing.Size(158, 128);
            this.btnRelatorioPedidos.TabIndex = 2;
            this.btnRelatorioPedidos.Text = "Relatório de Pedidos";
            this.btnRelatorioPedidos.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRelatorioPedidos.UseVisualStyleBackColor = false;
            this.btnRelatorioPedidos.Click += new System.EventHandler(this.btnRelatorioPedidos_Click);
            // 
            // Button1
            // 
            this.Button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Button1.BackColor = System.Drawing.Color.White;
            this.Button1.Image = global::WinFormsPagueDepois.Properties.Resources.produtos_102;
            this.Button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Button1.Location = new System.Drawing.Point(132, 236);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(158, 128);
            this.Button1.TabIndex = 4;
            this.Button1.Text = "Produtos";
            this.Button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Button1.UseVisualStyleBackColor = false;
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ClientSize = new System.Drawing.Size(784, 394);
            this.Controls.Add(this.btnPedido);
            this.Controls.Add(this.btnClientes);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.Button4);
            this.Controls.Add(this.btnFormaPagamento);
            this.Controls.Add(this.btnRelatorioPedidos);
            this.Controls.Add(this.Button1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.IsMdiContainer = true;
            this.Name = "frmMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema Pague Depois";
            this.TransparencyKey = System.Drawing.Color.Transparent;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMenu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Button Button4;
        internal System.Windows.Forms.Button btnFormaPagamento;
        internal System.Windows.Forms.Button btnRelatorioPedidos;
        internal System.Windows.Forms.Button Button1;
        internal System.Windows.Forms.Button btnClientes;
        internal System.Windows.Forms.Button btnPedido;
    }
}