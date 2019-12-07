using Capitulo02.Data;
using Capitulo02.Data.DAL.Cadastros;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Modelo.Cadastros;
using Capitulo02.Data.DAL.Docente;
using System.Collections.Generic;
using Modelo.Docente;
using Microsoft.AspNetCore.Mvc.Rendering;
using Capitulo02.Areas.Docente.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Capitulo02.Areas.Docente.Controllers
{
    [Area("Docente")]
    public class ProfessorController : Controller
    {
        private readonly IESContext _context;
        private readonly InstituicaoDAL instituicaoDAL;
        private readonly DepartamentoDAL departamentoDAL;
        private readonly CursoDAL cursoDAL;
        private readonly ProfessorDAL professorDAL;

        public ProfessorController(IESContext context)
        {
            _context = context;
            instituicaoDAL = new InstituicaoDAL(context);
            departamentoDAL = new DepartamentoDAL(context);
            cursoDAL = new CursoDAL(context);
            professorDAL = new ProfessorDAL(context);
        }

        public IActionResult AdicionarProfessor()
        {
            PrepararViewBags(instituicaoDAL.ObterInstituicoesClassificadasPorNome().ToList(),
                new List<Departamento>().ToList(), new List<Curso>().ToList(), new List<Professor>().ToList());
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AdicionarProfessor([Bind("InstituicaoID, DepartamentoID, CursoID, ProfessorID")] AdicionarProfessorViewModel model)
        {
            if (model.InstituicaoID == 0 || model.DepartamentoID == 0 || model.CursoID == 0 || model.ProfessorID == 0)
            {
                ModelState.AddModelError("", "É preciso selecionar todos os dados");
            } else
            {
                cursoDAL.RegistrarProfessor((long)model.CursoID, (long)model.ProfessorID);

                RegistrarProfessorNaSessao((long)model.CursoID, (long)model.ProfessorID);

                PrepararViewBags(instituicaoDAL.ObterInstituicoesClassificadasPorNome().ToList(),
                    departamentoDAL.ObterDepartamentoPorInstituicao((long)model.InstituicaoID).ToList(),
                    cursoDAL.ObterCursosPorDepartamento((long)model.DepartamentoID).ToList(),
                    cursoDAL.ObterProfessoresForaDoCurso((long)model.CursoID).ToList());
            }
            return View(model);
        }

        public void RegistrarProfessorNaSessao(long cursoID, long professorID)
        {
            var cursoProfessor = new CursoProfessor() { ProfessorID = professorID, CursoID = cursoID };
            List<CursoProfessor> cursosProfessor = new List<CursoProfessor>();
            string cursosProfessoresSession = HttpContext.Session.GetString("cursosProfessores");
            if (cursosProfessoresSession != null)
            {
                cursosProfessor = JsonConvert.DeserializeObject<List<CursoProfessor>>(cursosProfessoresSession);
            }
            cursosProfessor.Add(cursoProfessor);
            HttpContext.Session.SetString("cursosProfessores", JsonConvert.SerializeObject(cursosProfessor));
        }

        public IActionResult VerificarUltimosRegistros()
        {
            List<CursoProfessor> cursosProfessor = new List<CursoProfessor>();
            string cursosProfessoresSession = HttpContext.Session.GetString("cursosProfessores");
            if (cursosProfessoresSession != null)
            {
                cursosProfessor = JsonConvert.DeserializeObject<List<CursoProfessor>>(cursosProfessoresSession);
            }
            return View(cursosProfessor);
        }

        public void PrepararViewBags(List<Instituicao> instituicoes, List<Departamento> departamentos, List<Curso> cursos, List<Professor> professores)
        {
            instituicoes.Insert(0, new Instituicao() { InstituicaoID = 0, Nome = "Selecione a instituição" });
            ViewBag.Instituicoes = instituicoes;

            departamentos.Insert(0, new Departamento() { DepartamentoID = 0, Nome = "Selecione o departamento" });
            ViewBag.Departamentos = departamentos;

            cursos.Insert(0, new Curso() { CursoID = 0, Nome = "Selecione o curso" });
            ViewBag.Cursos = cursos;

            professores.Insert(0, new Professor() { ProfessorID = 0, Nome = "Selecione o professor" });
            ViewBag.Professores = professores;
        }

        public JsonResult ObterDepartamentosPorInstituicao(long actionID)
        {
            var departamentos = departamentoDAL.ObterDepartamentoPorInstituicao(actionID).ToList();
            return Json(new SelectList(departamentos, "DepartamentoID", "Nome"));
        }

        public JsonResult ObterCursosPorDepartamento(long actionID)
        {
            var cursos = cursoDAL.ObterCursosPorDepartamento(actionID).ToList();
            return Json(new SelectList(cursos, "CursoID", "Nome"));
        }

        public JsonResult ObterProfessoresForaDoCurso(long actionID)
        {
            var professores = cursoDAL.ObterProfessoresForaDoCurso(actionID).ToList();
            return Json(new SelectList(professores, "ProfessorID", "Nome"));
        }
    }
}