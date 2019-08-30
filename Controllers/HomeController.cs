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

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Listagem de professor no qual é responsável por determinado aluno.";

            return View();
        }
    }
}