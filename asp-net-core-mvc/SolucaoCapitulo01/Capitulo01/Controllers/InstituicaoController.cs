using Capitulo01.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Capitulo01.Controllers
{
    public class InstituicaoController : Controller
    {
        private static IList<Instituicao> instituicoes =
            new List<Instituicao>()
                {
                    new Instituicao() {
                        InstituicaoID = 1,
                        Nome = "UniParaná",
                        Endereco = "Paraná"
                    },
                    new Instituicao() {
                        InstituicaoID = 2,
                        Nome = "UniSanta",
                        Endereco = "Santa Catarina"
                    },
                    new Instituicao() {
                        InstituicaoID = 3,
                        Nome = "UniSãoPaulo",
                        Endereco = "São Paulo"
                    },
                    new Instituicao() {
                        InstituicaoID = 4,
                        Nome = "UniSulgrandense",
                        Endereco = "Rio Grande do Sul"
                    },
                    new Instituicao() {
                        InstituicaoID = 5,
                        Nome = "UniCarioca",
                        Endereco = "Rio de Janeiro"
                    }
            };

        public IActionResult Index()
        {
            return View(instituicoes);
        }

        // GET: Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Instituicao instituicao)
        {
            instituicoes.Add(instituicao);
            instituicao.InstituicaoID =
                instituicoes.Select(m => m.InstituicaoID).Max() + 1;
            return RedirectToAction("Index");
        }

        public ActionResult Edit(long id)
        {
            return View(instituicoes.Where(
                m => m.InstituicaoID == id).First());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Instituicao instituicao)
        {
            instituicoes.Remove(instituicoes.Where(
                c => c.InstituicaoID == instituicao.InstituicaoID)
                .First());
            instituicoes.Add(instituicao);
            return RedirectToAction("Index");
        }

        public ActionResult Details(long id)
        {
            return View(instituicoes.Where(
                m => m.InstituicaoID == id).First());
        }

        public ActionResult Delete(long id)
        {
            return View(instituicoes.Where(
                m => m.InstituicaoID == id).First());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Instituicao instituicao)
        {
            instituicoes.Remove(instituicoes.Where(
                c => c.InstituicaoID == instituicao.InstituicaoID)
                .First());
            return RedirectToAction("Index");
        }
    }
}
