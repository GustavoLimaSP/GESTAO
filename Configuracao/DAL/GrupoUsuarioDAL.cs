using MODELS;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class GrupoUsuarioDAL
    {
        public List<GrupoUsuario> BuscarPorIdUsuario(int _idUsuario)
        {
            SqlConnection cn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            GrupoUsuario grupoUsuario;
            List<GrupoUsuario> usuarios = new List<GrupoUsuario>();
            try
            {
                cn.ConnectionString = Conexao.StringDeConexao;
                cmd.Connection = cn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = @"SELECT GrupoUsuario.ID, GrupoUsuario.GrupoUsuario FROM GrupoUsuario
inner join USUARIOGRUPOUSUARIO on GrupoUsuario.ID = USUARIOGRUPOUSUARIO.ID_GRUPOUSUARIO
where ID_USUARIO= @Id_Usuario";
                cmd.CommandType = System.Data.CommandType.Text;
                cn.Open();

                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        grupoUsuario = new GrupoUsuario();
                        grupoUsuario.Id = Convert.ToInt32(rd["Id"]);
                        grupoUsuario.Descricao = rd["GrupoUsuario"].ToString();

                        usuarios.Add(grupoUsuario);
                    }
                }
                return usuarios;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao tentar buscar todos os usuários: ");
            }
            finally
            {
                cn.Close();
            }
        }
    }
}
    


