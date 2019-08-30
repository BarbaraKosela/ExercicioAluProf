using ExercicioAluProf.DAO;
using ExercicioAluProf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExercicioAluProf.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Consulta de alunos, com professor responsável.";
            //ViewBag.Aluno = new AlunoModel();
            List<AlunoModel> alunos = new AlunoDAO().ObterTodos();
            //AlunoModel aluno = new AlunoDAO().ObterPeloID(id);
            //bool apagado = new AlunoDAO().Excluir(id);
            ViewBag.Alunos = alunos;
            return View();
        }

        public ActionResult Cadastro()
        {
            ViewBag.AlunoCadastro = new AlunoModel();
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Listagem de professor no qual é responsável por determinado aluno.";
            List<ProfessorModel> professor = new ProfessorDao().ObterTodos();
            ViewBag.Professor = professor;
            return View();
        }

        public ActionResult Store(AlunoModel aluno)
        {
            ViewBag.Cadastro = new AlunoModel();
            int identificador = new AlunoDAO().Cadastrar(aluno);
            return RedirectToAction("About", new { id = identificador });

        }
    }
}