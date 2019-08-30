using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExercicioAluProf.Models
{
    public class AlunoModel
    {
        public int ID { get; set; }
        public string NomeAluno { get; set; }
        public DateTime DataNascimento { get; set; }
        public int IDProfessorResposavel { get; set; }
    }
}