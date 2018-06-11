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
using WinFormsPagueDepois.Helpers;
using Repositorio.Enum;
using WinFormsPagueDepois.Helpers;
using System.Globalization;

namespace WinFormsPagueDepois
{
    public partial class frmProduto : Form
    {
        public int idProduto;
        Situacao situacao;


        public frmProduto()
        {
            InitializeComponent();
            
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            Enum.TryParse<Situacao>(cboStatus.SelectedValue.ToString(), out situacao);
            int valueSituacao = (int)situacao;

            errorProvider1.Clear();
            if (txtDescricao.Text == string.Empty)
            {
                errorProvider1.SetError(txtDescricao, "Informe a descrição do produto.");
                return;
            }
            if (txtValor.Text == string.Empty)
            {
                errorProvider1.SetError(txtValor, "Informe o valor do produto.");
                return;
            }
            if(cboStatus.Text == string.Empty)
            {
                errorProvider1.SetError(cboStatus, "Informe o status do produto.");
            }
            
            ProdutoRepositorio<Produto> produtoRepo = new ProdutoRepositorio<Produto>();
        
                try
                {
                    Produto produto = new Produto();

                produto.Codigo = txtCodigo.Text.Trim();
                produto.Descricao = txtDescricao.Text;
                produto.Valor = Convert.ToDecimal(txtValor.Text);
                //produto.Status = RetornaStatusConsulta.retornaStatusInclusao(cboStatus.Text);
                produto.Status = situacao;
                produtoRepo.Inserir(produto);
                   
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao cadastrar " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                MessageBox.Show("Cadastrado realizado com sucesso", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            
        }
     
        private void frmProduto_Load(object sender, EventArgs e)
        {
            LoadSituacaoCombo<Situacao>(cboStatus);

            if (idProduto >= 1){

                ProdutoRepositorio<Produto> produtoRepo = new ProdutoRepositorio<Produto>();
                var produto = produtoRepo.RetornarPorId(idProduto);
                txtCodigo.Text = produto.Codigo;
                txtDescricao.Text = produto.Descricao;
                //txtValor.Text = Convert.ToString(produto.Valor);
                txtValor.Text = produto.Valor.ToString("N2", CultureInfo.CurrentCulture);
                //cboStatus.Text = RetornaStatusConsulta.retornaStatusConsulta(produto.Status);
                cboStatus.Text = produto.Status.ToString();

                btnIncluir.Visible = false;
                btnExcluir.Visible = true;
                      

            }
            else
            {
                btnExcluir.Visible = false;
                btnIncluir.Visible = false;
            }
            txtCodigo.Focus();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Enum.TryParse<Situacao>(cboStatus.SelectedValue.ToString(), out situacao);
            int valueSituacao = (int)situacao;

            errorProvider1.Clear();
            if (txtDescricao.Text == string.Empty)
            {
                errorProvider1.SetError(txtDescricao, "Informe a descrição do produto.");
                return;
            }
            if (txtValor.Text == string.Empty)
            {
                errorProvider1.SetError(txtValor, "Informe o valor do produto.");
                return;
            }
            if(cboStatus.Text == string.Empty)
            {
                errorProvider1.SetError(cboStatus, "Informe o status do produto.");
                return;
            }

            ProdutoRepositorio<Produto> produtoRepo = new ProdutoRepositorio<Produto>();

            try
            {
                Produto produto = new Produto();

                produto.Id = idProduto;
                produto.Codigo = txtCodigo.Text.Trim();
                produto.Descricao = txtDescricao.Text;
                produto.Valor = Convert.ToDecimal(txtValor.Text);
                //produto.Status = RetornaStatusConsulta.retornaStatusInclusao(cboStatus.Text);
                produto.Status = situacao;

                if (produto.Id == 0)
                {
                    produtoRepo.Inserir(produto);
                    MessageBox.Show("Cadastro realizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close();
                }
                else
                {
                    produtoRepo.Alterar(produto);
                    MessageBox.Show("Alteração realizada com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro na operação " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {

            DialogResult result3 = MessageBox.Show("Realmente deseja excluir o registro?"
                ,"Confirmação"
                ,MessageBoxButtons.YesNoCancel
                ,MessageBoxIcon.Question
                ,MessageBoxDefaultButton.Button2);

            if(result3 == DialogResult.Yes)
            {
                Enum.TryParse<Situacao>(cboStatus.SelectedValue.ToString(), out situacao);
                int valueSituacao = (int)situacao;

                ProdutoRepositorio<Produto> produtoRepo = new ProdutoRepositorio<Produto>();

                try
                {
                    Produto produto = new Produto();

                    produto.Id = idProduto;
                    produto.Codigo = txtCodigo.Text;
                    produto.Descricao = txtDescricao.Text;
                    produto.Valor = Convert.ToDecimal(txtValor.Text);
                    //produto.Status = RetornaStatusConsulta.retornaStatusInclusao(cboStatus.Text);
                    produto.Status = situacao;

                    produtoRepo.Excluir(produto);
                    MessageBox.Show("Exclusão realizada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close();
                

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro na operação " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }

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

        private void txtValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidaTexto.SomenteNumeros(sender, e);
        }

        private void txtValor_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            ValidaTexto.Moeda(ref txt);
        }
    }
}
