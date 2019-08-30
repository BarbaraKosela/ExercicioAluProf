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
    public class AlunoDAO
    {
        public List<AlunoModel> ObterTodos()
        {
            List<AlunoModel> alunos = new List<AlunoModel>();
            SqlCommand comando = new BancoDadosConexao().ObterConexao();
            comando.CommandText = "SELECT IDAluno,NomeAluno,DataNascimento,IDProfessorResponsavel FROM dbo.Aluno";
            DataTable tabela = new DataTable();
            tabela.Load(comando.ExecuteReader());
            foreach (DataRow linha in tabela.Rows)
            {
                AlunoModel aluno = new AlunoModel()

                {
                    ID = Convert.ToInt32(linha[0].ToString()),
                    NomeAluno = linha[1].ToString(),
                    DataNascimento = Convert.ToDateTime(linha[2].ToString()),
                };
                alunos.Add(aluno);
            }
            return alunos;
        }
        public int Cadastrar(AlunoModel aluno)
        {
            SqlCommand comando = new BancoDadosConexao().ObterConexao();
            comando.CommandText = @"INSERT INTO dbo.Aluno (NomeAluno,DataNascimento) OUTPUT
            INSERTED.ID VALUES (@NOMEALUNO, @DATANASCIMENTO)";
            comando.Parameters.AddWithValue("@NOMEALUNO", aluno.NomeAluno);
            comando.Parameters.AddWithValue("@DATANASCIMENTO", aluno.DataNascimento);
            int id = Convert.ToInt32(comando.ExecuteScalar().ToString());
            return id;
        }

        public bool Alterar(AlunoModel aluno)
        {
            SqlCommand comando = new BancoDadosConexao().ObterConexao();
            comando.CommandText = "UPDATE dbo.Aluno SET NomeAluno = @NOMEALUNO, DataNascimento = @DATANASCIMENTO WHERE IDAluno = @IDALUNO";
            comando.Parameters.AddWithValue("@NOME", aluno.NomeAluno);
            comando.Parameters.AddWithValue("@CODIGO_MATRICULA", aluno.DataNascimento);
            return comando.ExecuteNonQuery() == 1;
        }


        public bool Excluir(int id)
        {
            SqlCommand comando = new BancoDadosConexao().ObterConexao();
            comando.CommandText = "DELETE FROM dbo.Aluno WHERE IDAluno = @IDALUNO";
            comando.Parameters.AddWithValue("@IDALUNO", id);
            return comando.ExecuteNonQuery() == 1;

        }

        public AlunoModel ObterPeloID(int id)
        {
            AlunoModel aluno = null;
            SqlCommand comando = new BancoDadosConexao().ObterConexao();
            comando.CommandText = "SELECT IDAluno,NomeAluno,DataNascimento,IDProfessorResponsavel FROM dbo.Aluno WHERE IDAluno = @IDALUNO";
            comando.Parameters.AddWithValue("@IDALUNO", id);
            DataTable tabela = new DataTable();
            tabela.Load(comando.ExecuteReader());
            if (tabela.Rows.Count == 1)
            {
                aluno = new AlunoModel();
                aluno.ID = id;
                aluno.NomeAluno = tabela.Rows[0][0].ToString();
                aluno.DataNascimento = Convert.ToDateTime(tabela.Rows[0][1].ToString());
                aluno.IDProfessorResposavel = Convert.ToInt32(tabela.Rows[0][2].ToString());
            }
            return aluno;
        }
    }
}