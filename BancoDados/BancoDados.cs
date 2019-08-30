using System.Configuration;
using System.Data.SqlClient;

namespace ExercicioAluProf.BancoDados
{
    public class BancoDadosConexao
    {
        private static string connectionString;
        static BancoDadosConexao() { connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString; }
        public SqlCommand ObterConexao()
        {
            SqlConnection conexao = new SqlConnection(connectionString);
            conexao.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = conexao;
            return command;
        }
    }
}