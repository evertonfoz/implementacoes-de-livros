using Projeto01.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Projeto01.Controllers
{
    public class CategoriasController : Controller
    {
        private static IList<Categoria> categorias = new List<Categoria>()
            {
                new Categoria() { CategoriaId = 1, Nome = "Notebooks" },
                new Categoria() { CategoriaId = 2, Nome = "Monitores" },
                new Categoria() { CategoriaId = 3, Nome = "Impressoras" },
                new Categoria() { CategoriaId = 4, Nome = "Mouses" },
                new Categoria() { CategoriaId = 5, Nome = "Desktops" }
            };

        // GET: Categorias
        public ActionResult Index()
        {
            return View(categorias.OrderBy(c => c.Nome));
        }

        // GET: Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Categoria categoria)
        {
            categoria.CategoriaId = 
                categorias.Select(m => m.CategoriaId).Max() + 1;
            categorias.Add(categoria);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(long id)
        {
            return View(categorias.
                Where(m => m.CategoriaId == id).First());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Categoria categoria)
        {
            categorias[categorias.IndexOf(
                categorias.Where(
                    c => c.CategoriaId == categoria.CategoriaId).
                    First())] = categoria;
//            categorias.Remove(categorias.Where(c => c.CategoriaId == categoria.CategoriaId).First());
//            categorias.Add(categoria);
            return RedirectToAction("Index");
        }

        public ActionResult Details(long id)
        {
            return View(categorias.Where(m => m.CategoriaId == id)
                .First());
        }

        public ActionResult Delete(long id)
        {
            return View(categorias.Where(
                m => m.CategoriaId == id).First());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Categoria categoria)
        {
            categorias.Remove(categorias.Where(
                c => c.CategoriaId == categoria.CategoriaId).
                First());
            return RedirectToAction("Index");
        }
    }
}