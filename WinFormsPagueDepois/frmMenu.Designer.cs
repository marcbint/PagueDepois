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
            this.btnClientes = new System.Windows.Forms.Button();
            this.Button4 = new System.Windows.Forms.Button();
            this.btnFormaPagamento = new System.Windows.Forms.Button();
            this.Button2 = new System.Windows.Forms.Button();
            this.Button1 = new System.Windows.Forms.Button();
            this.btnPedido = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Label1
            // 
            this.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Label1.AutoSize = true;
            this.Label1.BackColor = System.Drawing.Color.DodgerBlue;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.White;
            this.Label1.Location = new System.Drawing.Point(272, 35);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(398, 42);
            this.Label1.TabIndex = 11;
            this.Label1.Text = "Sistema Pague Depois";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnClientes
            // 
            this.btnClientes.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnClientes.BackColor = System.Drawing.Color.White;
            this.btnClientes.Image = global::WinFormsPagueDepois.Properties.Resources.clientes_102;
            this.btnClientes.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnClientes.Location = new System.Drawing.Point(37, 239);
            this.btnClientes.Name = "btnClientes";
            this.btnClientes.Size = new System.Drawing.Size(158, 128);
            this.btnClientes.TabIndex = 13;
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
            this.Button4.Location = new System.Drawing.Point(227, 95);
            this.Button4.Name = "Button4";
            this.Button4.Size = new System.Drawing.Size(158, 131);
            this.Button4.TabIndex = 7;
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
            this.btnFormaPagamento.Location = new System.Drawing.Point(417, 95);
            this.btnFormaPagamento.Name = "btnFormaPagamento";
            this.btnFormaPagamento.Size = new System.Drawing.Size(158, 131);
            this.btnFormaPagamento.TabIndex = 8;
            this.btnFormaPagamento.Text = "Formas de Pagamento";
            this.btnFormaPagamento.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnFormaPagamento.UseVisualStyleBackColor = false;
            this.btnFormaPagamento.Click += new System.EventHandler(this.btnFormaPagamento_Click);
            // 
            // Button2
            // 
            this.Button2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Button2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Button2.Image = global::WinFormsPagueDepois.Properties.Resources.book_open;
            this.Button2.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Button2.Location = new System.Drawing.Point(597, 95);
            this.Button2.Name = "Button2";
            this.Button2.Size = new System.Drawing.Size(158, 128);
            this.Button2.TabIndex = 9;
            this.Button2.Text = "Consultas";
            this.Button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Button2.UseVisualStyleBackColor = false;
            // 
            // Button1
            // 
            this.Button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Button1.BackColor = System.Drawing.Color.White;
            this.Button1.Image = global::WinFormsPagueDepois.Properties.Resources.produtos_102;
            this.Button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Button1.Location = new System.Drawing.Point(37, 95);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(158, 128);
            this.Button1.TabIndex = 1;
            this.Button1.Text = "Produtos";
            this.Button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Button1.UseVisualStyleBackColor = false;
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // btnPedido
            // 
            this.btnPedido.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnPedido.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnPedido.Image = global::WinFormsPagueDepois.Properties.Resources.pedidos_102;
            this.btnPedido.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnPedido.Location = new System.Drawing.Point(227, 239);
            this.btnPedido.Name = "btnPedido";
            this.btnPedido.Size = new System.Drawing.Size(158, 128);
            this.btnPedido.TabIndex = 15;
            this.btnPedido.Text = "Pedidos";
            this.btnPedido.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPedido.UseVisualStyleBackColor = false;
            this.btnPedido.Click += new System.EventHandler(this.btnPedido_Click);
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
            this.Controls.Add(this.Button2);
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
        internal System.Windows.Forms.Button Button2;
        internal System.Windows.Forms.Button Button1;
        internal System.Windows.Forms.Button btnClientes;
        internal System.Windows.Forms.Button btnPedido;
    }
}