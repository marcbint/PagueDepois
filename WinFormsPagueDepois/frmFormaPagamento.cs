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

namespace WinFormsPagueDepois
{
    public partial class frmFormaPagamento : Form
    {
        Situacao situacao;
        TipoPagamento tipoPagamento;

        public int idFormaPagamento;

        public frmFormaPagamento()
        {
            InitializeComponent();
        }

        private void frmFormaPagamento_Load(object sender, EventArgs e)
        {
            LoadSituacaoCombo<Situacao>(cboStatus);
            LoadSituacaoCombo<TipoPagamento>(cboTipo);

            if (idFormaPagamento >= 1)
            {

                FormaPagamentoRepositorio<FormaPagamento> formaPagamentoRepo = new FormaPagamentoRepositorio<FormaPagamento>();
                var formaPagamento = formaPagamentoRepo.RetornarPorId(idFormaPagamento);
                txtDescricao.Text = formaPagamento.Descricao;
                //cboTipo.Text = RetornaTipoFormaPagamento.retornaTipoFormaPagamentoConsulta(formaPagamento.Tipo);
                cboTipo.Text = formaPagamento.Tipo.ToString();
                //cboStatus.Text = RetornaStatusConsulta.retornaStatusConsulta(formaPagamento.Status);
                cboStatus.Text = formaPagamento.Status.ToString();

                btnExcluir.Visible = true;
            }
            else
            {
                btnExcluir.Visible = false;
            }
            txtDescricao.Select();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Enum.TryParse<Situacao>(cboStatus.SelectedValue.ToString(), out situacao);
            int valueSituacao = (int)situacao;

            Enum.TryParse<TipoPagamento>(cboTipo.SelectedValue.ToString(), out tipoPagamento);
            int valueTipoPagamento = (int)tipoPagamento;

            errorProvider1.Clear();
            if (txtDescricao.Text == string.Empty)
            {
                errorProvider1.SetError(txtDescricao, "Informe a descrição do produto.");
                return;
            }
            if (cboTipo.Text == string.Empty)
            {
                errorProvider1.SetError(cboTipo, "Informe o tipo da forma de pagamento.");
                return;
            }
            if (cboStatus.Text == string.Empty)
            {
                errorProvider1.SetError(cboStatus, "Informe o status da forma de pagamento.");
                return;
            }

            FormaPagamentoRepositorio<FormaPagamento> formaPagamentoRepo = new FormaPagamentoRepositorio<FormaPagamento>();

            try
            {
                FormaPagamento formaPagamento = new FormaPagamento();

                formaPagamento.Id = idFormaPagamento;
                formaPagamento.Descricao = txtDescricao.Text;
                //formaPagamento.Tipo = RetornaTipoFormaPagamento.retornaTipoFormaPagamentoInclusao(cboTipo.Text);
                formaPagamento.Tipo = tipoPagamento;
                //formaPagamento.Status = RetornaStatusConsulta.retornaStatusInclusao(cboStatus.Text);
                formaPagamento.Status = situacao;

                if (formaPagamento.Id == 0)
                {
                    formaPagamentoRepo.Inserir(formaPagamento);
                    MessageBox.Show("Cadastro realizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close();
                }
                else
                {
                    formaPagamentoRepo.Alterar(formaPagamento);
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
                , "Confirmação"
                , MessageBoxButtons.YesNoCancel
                , MessageBoxIcon.Question
                , MessageBoxDefaultButton.Button2);

            if (result3 == DialogResult.Yes)
            {
                Enum.TryParse<Situacao>(cboStatus.SelectedValue.ToString(), out situacao);
                int valueSituacao = (int)situacao;

                Enum.TryParse<TipoPagamento>(cboStatus.SelectedValue.ToString(), out tipoPagamento);
                int valueTipoPagamento = (int)tipoPagamento;


                FormaPagamentoRepositorio<FormaPagamento> formaPagamentoRepo = new FormaPagamentoRepositorio<FormaPagamento>();

                try
                {
                    FormaPagamento formaPagamento = new FormaPagamento();

                    formaPagamento.Id = idFormaPagamento;
                    formaPagamento.Descricao = txtDescricao.Text;
                    
                    //formaPagamento.Tipo = RetornaTipoFormaPagamento.retornaTipoFormaPagamentoInclusao(cboTipo.Text);
                    formaPagamento.Tipo = tipoPagamento;
                    
                    //formaPagamento.Status = RetornaStatusConsulta.retornaStatusInclusao(cboStatus.Text);
                    formaPagamento.Status = situacao;

                    formaPagamentoRepo.Excluir(formaPagamento);
                    MessageBox.Show("Exclusão realizada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close();


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro na operação " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
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
    }
}
