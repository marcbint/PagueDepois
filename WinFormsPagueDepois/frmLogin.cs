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
using Repositorio.Helpers;

namespace WinFormsPagueDepois
{
    public partial class frmLogin : Form
    {
        public int idUsuario;
        public frmLogin()
        {
            InitializeComponent();
        }


        UsuarioRepositorio<Usuario> usuarioRepo;

        private void btnLogin_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (txtUsuario.Text == string.Empty)
            {
                errorProvider1.SetError(txtUsuario, "Informe o login do usuário");
                return;
            }
            if (txtSenha.Text == string.Empty)
            {
                errorProvider1.SetError(txtSenha, "Informe a senha do usuário");
                return;
            }
            try
            {
                usuarioRepo = new UsuarioRepositorio<Usuario>();

                //var hashCode = "s5X9HZQ1Cz"; // getUser.VCode;
                //Password Hasing Process Call Helper Class Method
                //var encodingPasswordString = Helper.EncodePassword(txtSenha.Text, hashCode);

                //Consulta o usuário informado para localizar o código SALT
                var usuario1 = usuarioRepo.ConsultaUsuario(txtUsuario.Text);
                var hashCode =  usuario1[0].Salt; 

                //Realiza do decript de acordo com a senha informada e codigo SALT do usuário localizado.
                var encodingPasswordString = Helper.EncodePassword(txtSenha.Text, hashCode);

                
                //if ((usuarioRepo.ValidarAcesso(txtUsuario.Text, txtSenha.Text)))
                if ((usuarioRepo.ValidarAcesso(txtUsuario.Text, encodingPasswordString)))
                {
                    
                    var usuario = usuarioRepo.ConsultaPorAcesso(txtUsuario.Text, encodingPasswordString);
                                    
                    this.Hide();

                    Global.idUsuario = usuario[0].Id;

                    frmMenu frmmnu = new frmMenu();
                    //frmmnu.idUsuario = usuario[0].Id;
                    frmmnu.Show();
                }
                else
                {
                    MessageBox.Show("Login e/ou Senha inválidos", "Login Inválido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao acessar o sistema" + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

        private void exibirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void registrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        

        private void frmLogin_Load(object sender, EventArgs e)
        {
            txtUsuario.Focus();
        }
    }
}
