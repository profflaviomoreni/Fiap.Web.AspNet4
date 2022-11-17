using AutoMapper;
using Fiap.Web.AspNet4.Controllers.Filters;
using Fiap.Web.AspNet4.Models;
using Fiap.Web.AspNet4.Repository.Interface;
using Fiap.Web.AspNet4.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.ObjectModel;

namespace Fiap.Web.AspNet4.Controllers
{

    public class ProdutoController : Controller
    {
        // Declarando a propriedade do repositorio
        private readonly IProdutoRepository produtoRepository;
        private readonly ILojaRepository lojaRepository;
        private readonly IMapper mapper;

        // declarando o construtor da classe
        public ProdutoController(IProdutoRepository _produtoRepository, ILojaRepository _lojaRepository, IMapper _mapper)
        {
            produtoRepository = _produtoRepository;
            lojaRepository = _lojaRepository;
            mapper = _mapper;
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


        [HttpGet]
        public IActionResult Novo()
        {
            var produtoNovoViewModel = new ProdutoNovoViewModel();
            produtoNovoViewModel.Lojas = LoadLojas();

            return View(produtoNovoViewModel);
        }


        [HttpPost]
        public IActionResult Novo(ProdutoNovoViewModel produtoNovoViewModel)
        {
            try { 

                var produtoModel = new ProdutoModel();
                produtoModel.ProdutoNome = produtoNovoViewModel.ProdutoNome;
                produtoModel.ProdutosLojas = new List<ProdutoLojaModel>();

                if (produtoNovoViewModel.LojaId != null || produtoNovoViewModel.LojaId.Count() > 0 )
                {
                    foreach (var item in produtoNovoViewModel.LojaId)
                    {
                        var produtoLojaModel = new ProdutoLojaModel();
                        produtoLojaModel.LojaId = item;
                        produtoLojaModel.Produto = produtoModel;

                        produtoModel.ProdutosLojas.Add(produtoLojaModel);
                    }
                } 
                else
                {
                    throw new Exception("Nenhum loja selecionada para o cadastro");
                }
            
                produtoRepository.Insert(produtoModel);

                TempData["mensagem"] = "Produto cadastrado com sucesso";
                return RedirectToAction("Index");

            } 
            catch
            {
                TempData["mensagem"] = "Não foi possível cadastrar o produto, verifique se existe alguma loja selecionada";
                produtoNovoViewModel.Lojas = LoadLojas();
                return View(produtoNovoViewModel);
            }

        }


        private SelectList LoadLojas()
        {
            var listaLojas = lojaRepository.FindAll();

            var listaLojasVM = mapper.Map<List<LojaViewModel>>(listaLojas);

            var listaLojasSelectList = new SelectList(listaLojasVM, "LojaId", "LojaNome");

            return listaLojasSelectList;
        }


    }
}
