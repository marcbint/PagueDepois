using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using WinFormsPagueDepois.Helpers;
using Repositorio;
using Repositorio.Entidades;
using Repositorio.Enum;

namespace WinFormsPagueDepois
{
    public partial class frmCliente : Form
    {
        public int idCliente;
        TipoPessoa tipoPessoa;
        Situacao situacao;


        public frmCliente()
        {
            InitializeComponent();
        }
        string mensagem = "";

        private void frmCliente_Load(object sender, EventArgs e)
        {
            cboTipo.Enabled = false;
            cboTipo.Text = "DESCONHECIDO";
            LoadSituacaoCombo<Situacao>(cboStatus);
            LoadCombo<TipoPessoa>(cboTipo);


            if (idCliente >= 1)
            {

                ClienteRepositorio<Cliente> clienteRepo = new ClienteRepositorio<Cliente>();
                var cliente = clienteRepo.RetornarPorId(idCliente);
                maskDocumento.Text = cliente.Documento;
                //cboTipo.Text = RetornaTipoCliente.retornaTipoClienteConsulta(cliente.Tipo);
                cboTipo.Text = cliente.Tipo.ToString();
                txtNomeRazao.Text = cliente.NomeRazao;
                txtEndereco.Text = cliente.Endereco;
                txtNumero.Text = cliente.Numero;
                txtComplemento.Text = cliente.Complemento;
                txtCep.Text = cliente.Cep;
                txtBairro.Text = cliente.Bairro;
                txtUf.Text = cliente.Uf;
                txtCidade.Text = cliente.Cidade;
                txtDdd.Text = cliente.Ddd;
                txtTelefone.Text = cliente.Telefone;
                txtEmail.Text = cliente.Email;
                txtContato.Text = cliente.Contato;
                //cboStatus.Text = RetornaStatusConsulta.retornaStatusConsulta(cliente.Status);
                cboStatus.Text = cliente.Status.ToString();

                btnExcluir.Visible = true;
            }
            else
            {
                cboTipo.Text = "DESCONHECIDO";
                btnExcluir.Visible = false;
            }
            maskDocumento.Focus();

        }

        private void maskDocumento_Leave(object sender, EventArgs e)
        {
            string valor = maskDocumento.Text;

            if (maskDocumento.Text.Trim().Length >= 1)
            {
                //Verifica o tipo do cliente digitado
                if(maskDocumento.Text.Trim().Length == 14)
                {
                    //Seta o tipo do cliente
                    cboTipo.Text = "JURÍDICA";

                    //Valida o cnpj
                    if (!ValidaTexto.IsCnpj(valor))
                    {
                        mensagem = "O número é um CNPJ inválido !";
                        MessageBox.Show(mensagem, "Validação");
                    }

                    //inclui a máscara
                    //maskDocumento.Mask = "00,000,000/0000-00";

                }
                else if(maskDocumento.Text.Trim().Length == 11)
                {
                    //Seta o tipo do cliente
                    cboTipo.Text = "FÍSICA";

                    //Valida o CPF
                    if (!ValidaTexto.IsCpf(valor))
                    {
                        mensagem = "O número é um CPF inválido !";
                        MessageBox.Show(mensagem, "Validação");
                    }
                    //inclui a máscara
                    //maskDocumento.Mask = "000,000,000-00";

                }
                else
                {
                    cboTipo.Text = "DESCONHECIDO";
                }
            }
            else
            {
                cboTipo.Text = "DESCONHECIDO";
            }
            

        }

        private void maskDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidaTexto.SomenteNumeros(sender, e);
            /*
            //Se a tecla digitada não for número e nem backspace
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08)
            {
                //Atribui True no Handled para cancelar o evento
                e.Handled = true;
            }*/
        }

        private void txtCep_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidaTexto.SomenteNumeros(sender, e);
        }

        private void txtDdd_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidaTexto.SomenteNumeros(sender, e);
        }

        private void txtTelefone_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidaTexto.SomenteNumeros(sender, e);
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Enum.TryParse<TipoPessoa>(cboTipo.SelectedValue.ToString(), out tipoPessoa);
            int valueTipoPessoa = (int)tipoPessoa;

            Enum.TryParse<Situacao>(cboStatus.SelectedValue.ToString(), out situacao);
            int valueSituacao = (int)situacao;

            errorProvider1.Clear();
            if (cboTipo.Text == string.Empty)
            {
                errorProvider1.SetError(cboTipo, "Informe o tipo do cliente.");
                return;
            }
            if (txtNomeRazao.Text == string.Empty)
            {
                errorProvider1.SetError(txtNomeRazao, "Informe o Nome/Razão do cliente.");
                return;
            }
            if (txtEndereco.Text == string.Empty)
            {
                errorProvider1.SetError(txtEndereco, "Informe o endereço do cliente.");
                return;
            }
            if (txtNumero.Text == string.Empty)
            {
                errorProvider1.SetError(txtNumero, "Informe o número do cliente.");
                return;
            }
            if (txtCep.Text == string.Empty)
            {
                errorProvider1.SetError(txtCep, "Informe o cep do cliente.");
                return;
            }
            if (txtBairro.Text == string.Empty)
            {
                errorProvider1.SetError(txtBairro, "Informe o bairro do cliente.");
                return;
            }
            if (txtUf.Text == string.Empty)
            {
                errorProvider1.SetError(txtUf, "Informe a UF do cliente.");
                return;
            }
            if (txtCidade.Text == string.Empty)
            {
                errorProvider1.SetError(txtCidade, "Informe a cidade do cliente.");
                return;
            }
            if (cboStatus.Text == string.Empty)
            {
                errorProvider1.SetError(cboStatus, "Informe o status do cliente.");
                return;
            }

            ClienteRepositorio<Cliente> clienteRepo = new ClienteRepositorio<Cliente>();

            try
            {
                Cliente cliente = new Cliente();

                cliente.Id = idCliente;
                cliente.Documento = maskDocumento.Text.Trim();
                //cliente.Tipo = RetornaTipoCliente.retornaTipoClienteInclusao(cboTipo.Text.Trim());
                cliente.Tipo = tipoPessoa;
                cliente.NomeRazao = txtNomeRazao.Text.Trim();
                cliente.Endereco = txtEndereco.Text.Trim();
                cliente.Numero = txtNumero.Text.Trim();
                cliente.Complemento = txtComplemento.Text.Trim();
                cliente.Cep = txtCep.Text.Trim();
                cliente.Bairro = txtBairro.Text.Trim();
                cliente.Uf = txtUf.Text.Trim();
                cliente.Cidade = txtCidade.Text.Trim();
                cliente.Ddd = txtDdd.Text.Trim();
                cliente.Telefone = txtTelefone.Text.Trim();
                cliente.Email = txtEmail.Text.Trim();
                cliente.Contato = txtContato.Text.Trim();
                //cliente.Status = RetornaStatusConsulta.retornaStatusInclusao(cboStatus.Text.Trim());
                cliente.Status = situacao;

                if (cliente.Id == 0)
                {
                    clienteRepo.Inserir(cliente);
                    MessageBox.Show("Cadastro realizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close();
                }
                else
                {
                    clienteRepo.Alterar(cliente);
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

                Enum.TryParse<TipoPessoa>(cboTipo.SelectedValue.ToString(), out tipoPessoa);
                int valueTipoPessoa = (int)tipoPessoa;

                Enum.TryParse<Situacao>(cboStatus.SelectedValue.ToString(), out situacao);
                int valueSituacao = (int)situacao;

                ClienteRepositorio<Cliente> clienteRepo = new ClienteRepositorio<Cliente>();

                try
                {
                    Cliente cliente = new Cliente();

                    cliente.Id = idCliente;
                    cliente.Documento = maskDocumento.Text.Trim();
                    //cliente.Tipo = RetornaTipoCliente.retornaTipoClienteInclusao(cboTipo.Text.Trim());
                    cliente.Tipo = tipoPessoa;
                    cliente.NomeRazao = txtNomeRazao.Text.Trim();
                    cliente.Endereco = txtEndereco.Text.Trim();
                    cliente.Numero = txtNumero.Text.Trim();
                    cliente.Complemento = txtComplemento.Text.Trim();
                    cliente.Cep = txtCep.Text.Trim();
                    cliente.Bairro = txtBairro.Text.Trim();
                    cliente.Uf = txtUf.Text.Trim();
                    cliente.Cidade = txtCidade.Text.Trim();
                    cliente.Ddd = txtDdd.Text.Trim();
                    cliente.Telefone = txtTelefone.Text.Trim();
                    cliente.Email = txtEmail.Text.Trim();
                    cliente.Contato = txtContato.Text.Trim();
                    //cliente.Status = RetornaStatusConsulta.retornaStatusInclusao(cboStatus.Text.Trim());
                    cliente.Status = situacao;


                    clienteRepo.Excluir(cliente);
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

        public static void LoadCombo<T>(ComboBox cbo)
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

        private void txtUf_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidaTexto.SomenteLetras(sender, e);
        }
    }
}
