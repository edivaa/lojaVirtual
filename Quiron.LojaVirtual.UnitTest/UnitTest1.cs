using System;
using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quiron.LojaVirtual.Web.HtmlHelpers;
using Quiron.LojaVirtual.Web.Models;

namespace Quiron.LojaVirtual.UnitTest
{
    [TestClass]
    public class UnitTestQuiron
    {
        [TestMethod]
        public void Take()
        {//O operador Take é usado para selecionar os primeiros n objetos de uma coleção

            int[] numeros = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var resultado = from num in numeros.Take(5) select num;
            int[] teste = { 5, 4, 1, 3, 9 };

            CollectionAssert.AreEqual(resultado.ToArray(),teste);

        }

        [TestMethod]
        public void Skip()
        {//O operador Skip é usado para ignorar os primeiros n objetos de uma coleção

            int[] numeros = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var resultado = from num in numeros.Take(5).Skip(2) select num;
            int[] teste = { 1, 3, 9 };

            CollectionAssert.AreEqual(resultado.ToArray(), teste);

        }


        [TestMethod]
        public void TestarSePaginacaoEstaSendoGeradaCorretamente()
        {
            HtmlHelper html = null;
            Paginacao paginacao = new Paginacao
            {
                PaginaAtual = 1,
                ItensPorPagina = 10,
                ItensTotal = 7

            };

            Func<int, string> paginaUrl = i => "Pagina" + i;

            MvcHtmlString resultado = html.PageLinks(paginacao, paginaUrl);



            //Assert  
            //Assert.AreEqual(/*Teste para 3 pagianas*/
            //       @"<a class=""btn btn-default"" href=""Pagina1"">1</a>"
            //      +@"<a class=""btn btn-default btn-primary selected"" href=""Pagina2"">2</a>"
            //      +@"<a class=""btn btn-default"" href=""Pagina3"">3</a>.", resultado.ToString()
            //   );

            //<a class="btn btn-default" href="Pagina1">1</a>
            //<a class="btn btn-default btn-primary Selected" href="Pagina2">2</a>
            //<a class="btn btn-default" href="Pagina3">3</a>.

            Assert.AreEqual(/*Teste para 1 pagianas*/
                   @"<a class=""btn btn-default"" href=""Pagina1"">1</a>"
                   , resultado.ToString()
               );


        }

    }
}
