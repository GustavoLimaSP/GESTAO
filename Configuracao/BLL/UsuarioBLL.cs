using DAL;
using MODELS;
using System;
using System.Collections.Generic;
using System.Security.Permissions;

namespace BLL
{
    public class UsuarioBLL
    {

        public void inserir(Usuario _usuario, string _confirmarDeSenha)
        {
            Usuario usuario = new Usuario();
            usuario = BuscaPorNomeUsuario(_usuario.NomeUsuario);
            throw new Exception("Usuário já existente");
            UsuarioDAL usuarioDAL = new UsuarioDAL();
            usuarioDAL.Inserir(_usuario);
        }

        public Usuario BuscaPorNomeUsuario(string _nomeUsuario)
        {
            if (String.IsNullOrEmpty(_nomeUsuario))
                throw new Exception("Informe o nome do usuário.");

            UsuarioDAL _usuarioDAL = new UsuarioDAL();
            return _usuarioDAL.BuscarPorNomeUsuario(_nomeUsuario);
        }
        public void Alterar(Usuario _usuario, string _confirmacaoDeSenha)
        {
                
                
        }
        private static void ValidarDados(Usuario _usuario)
        {
            if (_usuario.NomeUsuario.Length <= 3 || _usuario.NomeUsuario.Length >= 50)
                throw new Exception("O nome de usuário deve ter mais de três caracteres.");

            if (_usuario.NomeUsuario.Contains(" "))
                throw new Exception("O nome de usuário não pode conter espaço");

            if (_usuario.Senha == "1234567")
                throw new Exception("Não é permitido um número sequencial.");

            if (_usuario.Senha.Length < 7 || _usuario.Senha.Length > 11)
                throw new Exception("A senha deve ter entre 7 e 11 caracteres.");

            //TODO: Validar se já existe um usuário com este nome.

            UsuarioDAL usuarioDAL = new UsuarioDAL();
            usuarioDAL.Inserir(_usuario);

        }
        public Usuario BuscarPorNomeUsuario(string _nomeUsuario)
        {
            if (String.IsNullOrEmpty(_nomeUsuario))
                throw new Exception("Informe o nome do usúario.");

            UsuarioDAL usuarioDAL = new UsuarioDAL();
            return usuarioDAL.BuscarPorNomeUsuario(_nomeUsuario);
        }

        public List<Usuario> BuscarTodos()
        {
            UsuarioDAL usuarioDAL = new UsuarioDAL();
            return usuarioDAL.BuscarTodos();
        }

        public void Excluir(int id)
        {
            UsuarioDAL usuarioDAL = new UsuarioDAL();
            usuarioDAL.Excluir(_id);
        }

        public void AdicionarGrupo(int _idUsuario, int _idGrupoUsuario)    
        {
        if (new UsuarioDAL().ExisteRelacionamento(_idUsuario, _idGrupoUsuario))
             return;
           
            UsuarioDAL UsuarioDAL = new UsuarioDAL();
            UsuarioDAL.AdicionarGrupo(_idUsuario, _idGrupoUsuario);
        }
    }
}

