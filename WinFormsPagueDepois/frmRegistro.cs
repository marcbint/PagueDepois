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
using Repositorio.Helpers;

namespace WinFormsPagueDepois
{
    public partial class frmRegistro : Form
    {
        public int idRegistro;
        public string loginInicial;
        Situacao situacao;


        public frmRegistro()
        {
            InitializeComponent();
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            Enum.TryParse<Situacao>(cboStatus.SelectedValue.ToString(), out situacao);
            int valueSituacao = (int)situacao;

            errorProvider1.Clear();
            if (txtNome.Text == string.Empty)
            {
                errorProvider1.SetError(txtNome, "Informe o nome do usuário");
                return;
            }
            if (txtLogin.Text == string.Empty)
            {
                errorProvider1.SetError(txtLogin, "Informe o login do usuário");
                return;
            }
            if (txtSenha.Text == string.Empty)
            {
                errorProvider1.SetError(txtSenha, "Informe a senha do usuário");
                return;
            }
            UsuarioRepositorio<Usuario> usuarioRepo = new UsuarioRepositorio<Usuario>();
            if ((usuarioRepo.ValidarLogin(txtLogin.Text)))
            {
                MessageBox.Show("Login já esta Cadastrado", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    Usuario user = new Usuario();
                    user.Login = txtLogin.Text;
                    user.Nome = txtNome.Text;
                    user.Senha = txtSenha.Text;
                    //user.Status = retornaStatus();
                    user.Status = situacao;
                    usuarioRepo.Inserir(user);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao cadastrar " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                MessageBox.Show("Login Cadastrado com sucesso", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private char retornaStatus()
        {
            if (cboStatus.Text == "Ativo")
            {
                return 'A';
            }
            else if (cboStatus.Text == "Inativo")
            {
                return 'I';
            }
            else
            {
                return 'A';
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Enum.TryParse<Situacao>(cboStatus.SelectedValue.ToString(), out situacao);
            int valueSituacao = (int)situacao;

            if (txtNome.Text == string.Empty)
            {
                errorProvider1.SetError(txtNome, "Informe o nome do usuário");
                return;
            }
            if (txtLogin.Text == string.Empty)
            {
                errorProvider1.SetError(txtLogin, "Informe o login do usuário");
                return;
            }
            if (txtSenha.Text == string.Empty)
            {
                errorProvider1.SetError(txtSenha, "Informe a senha do usuário");
                return;
            }

            if (txtSenha.Text != txtConfirmarSenha.Text)
            {
                MessageBox.Show("As senhas digitadas não coincidem. Digite novamente!");
                txtSenha.Clear();
                txtConfirmarSenha.Clear();
                txtSenha.Focus();
                //errorProvider1.SetError(txtSenha, "Informe a senha do usuário");
                return;
            }


            UsuarioRepositorio<Usuario> usuarioRepo = new UsuarioRepositorio<Usuario>();


            try
            {
                var keyNew = Helper.GeneratePassword(10);
                var password = Helper.EncodePassword(txtSenha.Text, keyNew);


                Usuario user = new Usuario();
                user.Id = idRegistro;
                user.Login = txtLogin.Text;
                user.Nome = txtNome.Text;
                //user.Senha = txtSenha.Text;
                user.Senha = password;
                user.Salt = keyNew;
                //user.Status = RetornaStatusConsulta.retornaStatusInclusao(cboStatus.Text);
                user.Status = situacao;
                //usuarioRepo.Inserir(user);


                
                if (user.Id == 0)
                {

                    if ((usuarioRepo.ValidarLogin(txtLogin.Text)))
                    {
                        MessageBox.Show("Login já esta Cadastrado", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        usuarioRepo.Inserir(user);
                        MessageBox.Show("Cadastro realizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.Close();
                    }


                }
                else
                {
                    if (user.Login != loginInicial)
                    {
                        if ((usuarioRepo.ValidarLogin(txtLogin.Text)))
                        {
                            MessageBox.Show("Login já esta cadastrado! Informe outro login.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            usuarioRepo.Alterar(user);
                            MessageBox.Show("Alteração realizada com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            this.Close();
                        }
                    }
                    else
                    {
                        usuarioRepo.Alterar(user);
                        MessageBox.Show("Alteração realizada com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.Close();
                    }

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

                UsuarioRepositorio<Usuario> usuarioRepo = new UsuarioRepositorio<Usuario>();

                try
                {
                    Usuario usuario = new Usuario();

                    usuario.Id = idRegistro;
                    usuario.Nome = txtNome.Text;
                    usuario.Login = txtLogin.Text;
                    usuario.Senha = txtSenha.Text;
                    //usuario.Status = RetornaStatusConsulta.retornaStatusInclusao(cboStatus.Text);
                    usuario.Status = situacao;

                    usuarioRepo.Excluir(usuario);
                    MessageBox.Show("Exclusão realizada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close();


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro na operação " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
        }

        private void frmRegistro_Load(object sender, EventArgs e)
        {
            LoadSituacaoCombo<Situacao>(cboStatus);

            if (idRegistro >= 1)
            {

                UsuarioRepositorio<Usuario> usuarioRepo = new UsuarioRepositorio<Usuario>();
                var usuario = usuarioRepo.RetornarPorId(idRegistro);
                txtNome.Text = usuario.Nome;
                txtLogin.Text = usuario.Login;
                txtSenha.Text = usuario.Senha;
                txtConfirmarSenha.Enabled = false;
                //cboStatus.Text = RetornaStatusConsulta.retornaStatusConsulta(usuario.Status);
                cboStatus.Text = usuario.Status.ToString();

                loginInicial = usuario.Login;

                btnExcluir.Visible = true;
                btnSalvar.Visible = true;
            }
            else
            {
                btnExcluir.Visible = false;
                btnSalvar.Visible = true;
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

        private void txtSenha_Validating(object sender, CancelEventArgs e)
        {
            if (txtSenha.Text.Count() <= 5)
            {
                //MessageBox.Show("A senha deve possuir pelo menos 6 caracteres/números!");
                errorProvider1.SetError(txtSenha, "A senha deve possuir pelo menos 6 caracteres/números!");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.Clear();
                e.Cancel = false;
            }
        }
    }
}
