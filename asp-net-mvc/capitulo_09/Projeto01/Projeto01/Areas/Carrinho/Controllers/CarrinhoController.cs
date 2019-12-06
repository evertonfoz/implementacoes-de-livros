using Persistencia.Contexts;
using Projeto01.Areas.Carrinho.ViewModels;
using Servicos.Cadastros;
using Servicos.Carrinho;
using System;
using System.Web;
using System.Web.Mvc;

namespace Projeto01.Areas.Carrinho.Controllers
{
    public class CarrinhoController : Controller
    {
        private CarrinhoServico carrinhoServico = new CarrinhoServico();
        private ProdutoServico produtoServico = new ProdutoServico();
        private ClienteServico clienteServico = new ClienteServico();

        // GET: Carrinho/Carrinho
        public ActionResult Index()
        {
            //var carrinho = new CarrinhoIndexViewModel()
            //{
            //    Carrinhos = carrinhoServico.ObterCarrinhosClassificadosPorDataDecrescente(),
            //    Produtos = produtoServico.ObterProdutosClassificadosPorNome()
            //};
            return View(carrinhoServico.ObterCarrinhosClassificadosPorDataDecrescente());
        }

        public ActionResult Create()
        {
            return PartialView("_CreateCarrinho", new Modelo.Carrinho.Carrinho());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult CreateCarrinho(Modelo.Carrinho.Carrinho carrinho, FormCollection collection)
        {
            carrinho.ClienteId = Convert.ToInt32(collection.Get("idcliente"));
            carrinho.Cliente = clienteServico.ObterClientePorId((long)carrinho.ClienteId);
            carrinhoServico.CreateCarrinho(carrinho);
            HttpContext.Session["carrinho"] = carrinho;
            return View("CarrinhoAddProdutos", carrinho);
//            return Content("Ok");
//            return PartialView("_CreateCarrinho", carrinho);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult GetCarrinho()
        {
            return PartialView("_CreateCarrinho", HttpContext.Session["carrinho"] as Modelo.Carrinho.Carrinho);
        }
    }
}