using Fiap.Web.AspNet4.Controllers.Filters;
using Fiap.Web.AspNet4.Models;
using Fiap.Web.AspNet4.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Web.AspNet4.Controllers
{
    [FiapAuthFilter]
    public class ProdutoController : Controller
    {
        // Declarando a propriedade do repositorio
        private readonly IProdutoRepository produtoRepository;

        // declarando o construtor da classe
        public ProdutoController(IProdutoRepository _produtoRepository)
        {
            produtoRepository = _produtoRepository;
        }


        public IActionResult Index()
        {
            IList<ProdutoModel> produtos = produtoRepository.FindAll();

            return View(produtos);
        }

        public IActionResult Details(int id)
        {
            ProdutoModel produtoModel = produtoRepository.FindById(id);

            return View(produtoModel);
        }


    }
}
