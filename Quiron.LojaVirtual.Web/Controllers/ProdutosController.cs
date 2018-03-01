using System.Web.Mvc;
using Quiron.LojaVirtual.Dominio.Repositorio;

namespace Quiron.LojaVirtual.Web.Controllers
{
    public class ProdutosController : Controller
    {
        private ProdutosRepositorio _produtosRepositorio;

        // GET: Produtos
        public ActionResult Index()
        {
            _produtosRepositorio = new ProdutosRepositorio();
            var produtos = _produtosRepositorio.Produtos;
            return View(produtos);
        }
    }
}