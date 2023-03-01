using MODELS;
using System.Data.SqlClient;

namespace DAL
{
    public class UsuarioDAL
    {
        public void Inserir(Usuario _Usuario)
        {
            SqlConnection cn = new SqlConnection();

            try
            {
                cn.ConnectionString = Conexao.StringDeConexao;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = @"INSERT INTO Usuario(Nome, NomeUsuario, CPF, Email, Senha, Ativo) 
                                    VALUES(@Nome, @NomeUsuario, @CPF, @Email, @Senha, @Ativo)";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@Nome", _Usuario.Nome);
                cmd.Parameters.AddWithValue("@NomeUsuario", _Usuario.Username);
                cmd.Parameters.AddWithValue("@CPF", _Usuario.CPF);
                cmd.Parameters.AddWithValue("@Email", _Usuario.Email);
                cmd.Parameters.AddWithValue("@Senha", _Usuario.Senha);
                cmd.Parameters.AddWithValue("@Ativo", _Usuario.Ativo);

                cn.Open();
                cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao tentar inserir um usuário no banco: " + ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }
        public List<Usuario> BuscarTodos()
        {
            SqlConnection cn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            Usuario usuario;
            List<Usuario> usuarios = new List<Usuario>();
            try
            {
                cn.ConnectionString = Conexao.StringDeConexao;
                cmd.Connection = cn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = @"SELECT Id, Nome, CPF, Email, Ativo FROM Usuario ";
                cmd.CommandType = System.Data.CommandType.Text;
                cn.Open();

                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        usuario = new Usuario();
                        usuario.Id = Convert.ToInt32(rd["Id"]);
                        usuario.Nome = rd["Nome"].ToString();
                        usuario.Username = rd["Username"].ToString();
                        usuario.CPF = rd["CPF"].ToString();
                        usuario.Email = rd["Email"].ToString();
                        usuario.Ativo = Convert.ToBoolean(rd["Ativo"]);

                        usuarios.Add(usuario);
                    }
                }
                return usuarios;
            }
            catch(Exception ex)
            {
                throw new Exception("Ocorreu um erro ao tentar buscar todos os usuários: ");
            }
            finally 
            {
                cn.Close(); 
            }
        }
        public void Alterar(Usuario _usuario)
        {

        }
        public void Excluir(int _id)
        {

        }

    }
}