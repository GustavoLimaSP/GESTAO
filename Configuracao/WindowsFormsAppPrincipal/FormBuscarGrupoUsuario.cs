using BLL;
using MODELS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppPrincipal
{
    public partial class FormBuscarGrupoUsuario : Form
    {
        public FormBuscarGrupoUsuario()
        {
            InitializeComponent();
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            UsuarioBLL usuarioBLL = new UsuarioBLL();
            grupoUsuarioBindingSource.DataSource = usuarioBLL.BuscarTodos();
        }

        private void buttonAlterar_Click(object sender, EventArgs e)
        {

        }

        private void buttonAdicionar_Click(object sender, EventArgs e)
        {
            using(FormCadastroUsuario frm = new FormCadastroUsuario())
            {
                frm.ShowDialog();
            }
            buttonBuscar_Click(sender, e);
        }

        private void buttonExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                int id = ((Usuario)grupoUsuarioBindingSource.Current).Id;
                UsuarioBLL usuarioBLL = new UsuarioBLL();
                usuarioBLL.Excluir(id);
                MessageBox.Show("Usuário excluído com sucesso!");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Erro ao excluir usuário: " + ex.Message);
            }
        }

        private void buttonAdicionarPermissao_Click(object sender, EventArgs e)
        {

        }

        private void buttonExcluirPermissao_Click(object sender, EventArgs e)
        {

        }
    }
}
