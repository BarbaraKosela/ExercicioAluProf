using ExercicioAluProf.BancoDados;
using ExercicioAluProf.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ExercicioAluProf.DAO
{
    public class ProfessorDao
    {
        public List<ProfessorModel> ObterTodos()
        {
            List<ProfessorModel> professor = new List<ProfessorModel>();
            SqlCommand comando = new BancoDadosConexao().ObterConexao();
            comando.CommandText = "SELECT IDProfessorResponsavel,NomeProfessor FROM dbo.ProfessorResponsavel";
            DataTable tabela = new DataTable();
            tabela.Load(comando.ExecuteReader());
            foreach (DataRow linha in tabela.Rows)
            {
                ProfessorModel prof = new ProfessorModel()

                {
                    IDProfessorResponsavel = Convert.ToInt32(linha[0].ToString()),
                    NomeProfessor = linha[1].ToString(),
                };
                professor.Add(prof);
            }
            return professor;
        }
    }
}