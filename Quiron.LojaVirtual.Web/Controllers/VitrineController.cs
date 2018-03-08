using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Quiron.LojaVirtual.Dominio.Repositorio;

namespace Quiron.LojaVirtual.Web.Controllers
{
    public class VitrineController : Controller
    {
        private ProdutosRepositorio _produtosRepositorio;

        // GET: Vitrine
        public ActionResult Index()
        {

            _produtosRepositorio = new ProdutosRepositorio();
            var produtos = _produtosRepositorio.Produtos;
            return View();
        }
    }
}