using DAL;
using MODELS;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class UsuarioBLL
    {

        public void inserir(Usuario _usuario)
        {
            Usuario usuario = new Usuario();

            usuario = BuscarUsuarioPorNome(_usuario.Username);
            throw new Exception("Usuário já existente");

            UsuarioDAL usuarioDAL = new UsuarioDAL();
            usuarioDAL.Inserir(_usuario);
        }
        public Usuario BuscaPorNomeUsuario(string _nomeUsuario)
        {
            if (String.IsNullOrEmpty(_nomeUsuario))
                throw new Exception("Informe o nome do usuário.");

            UsuarioDAL _usuarioDAL = new UsuarioDAL();
            return _usuarioDAL.BuscarUsuarioPorNome(_nomeUsuario);
        }
        private void ValidarDados(Usuario _usuario)
        {
            if (_usuario.Username.Length <= 3 || _usuario.Username.Length >= 50)
                throw new Exception("O nome de usuário deve ter mais de três caracteres.");

            if (_usuario.Username.Contains(" "))
                throw new Exception("O nome de usuário não pode conter espaço");

            if (_usuario.Senha == "1234567")
                throw new Exception("Não é permitido um número sequencial.");

            if (_usuario.Senha.Length < 7 || _usuario.Senha.Length > 11)
                throw new Exception("A senha deve ter entre 7 e 11 caracteres.");

            //TODO: Validar se já existe um usuário com este nome.

            UsuarioDAL usuarioDAL = new UsuarioDAL();
            usuarioDAL.Inserir(_usuario);

        }

        public List<Usuario> BuscarTodos()
        {
            UsuarioDAL usuarioDAL = new UsuarioDAL();
            if (textBox1.Text == "")
                usuarioBindingSource.DataSource = usuarioBLL.BuscarTodos();
            else
                usuarioBindingSource.DataSource
            return usuarioDAL.BuscarTodos();
        }

        public Usuario BuscarUsuarioPorNome(string _nomeUsuario)
        {
            if(String.IsNullOrEmpty(_nomeUsuario))
                throw new Exception("Informe o nome do usuário.");

            UsuarioDAL usuarioDAL = new UsuarioDAL();
            return usuarioDAL.BuscarUsuarioPorNome(_nomeUsuario);
        }
    }
}