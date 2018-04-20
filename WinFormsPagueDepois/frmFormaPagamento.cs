﻿using System;
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

namespace WinFormsPagueDepois
{
    public partial class frmFormaPagamento : Form
    {
        public int idFormaPagamento;

        public frmFormaPagamento()
        {
            InitializeComponent();
        }

        private void frmFormaPagamento_Load(object sender, EventArgs e)
        {
            if (idFormaPagamento >= 1)
            {

                FormaPagamentoRepositorio<FormaPagamento> formaPagamentoRepo = new FormaPagamentoRepositorio<FormaPagamento>();
                var formaPagamento = formaPagamentoRepo.RetornarPorId(idFormaPagamento);
                txtDescricao.Text = formaPagamento.Descricao;
                cboTipo.Text = RetornaTipoFormaPagamento.retornaTipoFormaPagamentoConsulta(formaPagamento.Tipo);
                cboStatus.Text = RetornaStatusConsulta.retornaStatusConsulta(formaPagamento.Status);
                
                btnExcluir.Visible = true;
            }
            else
            {
                btnExcluir.Visible = false;
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
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
                formaPagamento.Tipo = RetornaTipoFormaPagamento.retornaTipoFormaPagamentoInclusao(cboTipo.Text);
                formaPagamento.Status = RetornaStatusConsulta.retornaStatusInclusao(cboStatus.Text);

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

                FormaPagamentoRepositorio<FormaPagamento> formaPagamentoRepo = new FormaPagamentoRepositorio<FormaPagamento>();

                try
                {
                    FormaPagamento formaPagamento = new FormaPagamento();

                    formaPagamento.Id = idFormaPagamento;
                    formaPagamento.Descricao = txtDescricao.Text;
                    formaPagamento.Tipo = RetornaTipoFormaPagamento.retornaTipoFormaPagamentoInclusao(cboTipo.Text);
                    formaPagamento.Status = RetornaStatusConsulta.retornaStatusInclusao(cboStatus.Text);


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
    }
}