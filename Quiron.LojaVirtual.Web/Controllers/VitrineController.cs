using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Quiron.LojaVirtual.Dominio.Repositorio;
using Quiron.LojaVirtual.Web.Models;

namespace Quiron.LojaVirtual.Web.Controllers
{
    public class VitrineController : Controller
    {
        private ProdutosRepositorio _produtosRepositorio;
        public int ProdutosPorPagina = 3;

        // GET: Vitrine
        public ActionResult ListaProdutos(int pagina =1)
        {

            _produtosRepositorio = new ProdutosRepositorio();

            ProdutosViewModel model = new ProdutosViewModel
            {
                Produtos = _produtosRepositorio.Produtos
                    .OrderBy(p => p.Descricao)
                    .Skip((pagina - 1) * ProdutosPorPagina)
                    .Take(ProdutosPorPagina),

                Paginacao = new Paginacao
                {
                    PaginaAtual = pagina,
                    ItensPorPagina = ProdutosPorPagina,
                    ItensTotal = _produtosRepositorio.Produtos.Count()
                }

            };


            return View(model);
            //return View(produtos);
        }
    }
}