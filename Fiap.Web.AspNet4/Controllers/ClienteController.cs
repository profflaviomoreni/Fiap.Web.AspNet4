using Fiap.Web.AspNet4.Data;
using Fiap.Web.AspNet4.Models;
using Fiap.Web.AspNet4.Repository;
using Fiap.Web.AspNet4.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Fiap.Web.AspNet4.Controllers
{
    public class ClienteController : Controller
    {

        private readonly IClienteRepository clienteRepository;
        private readonly IRepresentanteRepository representanteRepository;

        public ClienteController(IClienteRepository _clienteRepository, IRepresentanteRepository _representanteRepository )
        {
            clienteRepository = _clienteRepository;
            representanteRepository = _representanteRepository;
        }


        [HttpGet]
        public IActionResult Index()
        {
            //var listaClientes = clienteRepository.FindAllOrderByNomeDesc();
            //var listaClientes = clienteRepository.FindByNome("io");
            //var listaClientes = clienteRepository.FindByNomeAndEmail("io","@gmail");
            //var listaClientes = clienteRepository.FindByNomeAndEmailAndRepresentante("io","@gmail",0);
            //var listaClientes = clienteRepository.FindByNomeAndEmailAndRepresentante("", "", 0);

            ComboRepresentantes();

            return View(new List<ClienteModel>());
        }

        [HttpPost]
        public IActionResult Pesquisar(string NomePesquisa, string EmailPesquisa, int RepresentanteId)
        {
            ComboRepresentantes();

            var listaClientes = 
                clienteRepository.FindByNomeAndEmailAndRepresentante(NomePesquisa, EmailPesquisa, RepresentanteId); 

            return View("Index", listaClientes );
        }



        [HttpGet]
        public IActionResult Novo()
        {
            ComboRepresentantes();

            return View(new ClienteModel());
        }

        [HttpPost]
        public IActionResult Novo(ClienteModel clienteModel)
        {
            if (ModelState.IsValid)
            {
                clienteRepository.Insert(clienteModel);

                TempData["Mensagem"] = "Cliente cadastrado com sucesso";
                return RedirectToAction("Index");
            }
            else
            {
                ComboRepresentantes();

                return View(clienteModel);
            }
        }


        [HttpGet]
        public IActionResult Editar(int id)
        {
            ComboRepresentantes();

            var clienteModel = clienteRepository.FindById(id);

            return View(clienteModel);
        }


        [HttpPost]
        public IActionResult Editar(ClienteModel clienteModel)
        {
            if ( ModelState.IsValid  ) {
                clienteRepository.Update(clienteModel);

                TempData["Mensagem"] = "Cliente editado com sucesso";
                return RedirectToAction("Index");
            }
            else
            {
                ComboRepresentantes();
                return View(clienteModel);
            }

        }

        

        [HttpGet]
        public IActionResult Remover(int id)
        {
            TempData["Mensagem"] = "Cliente removido com sucesso";

            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Detalhe(int id)
        {
            var clienteModel = clienteRepository.FindById(id);
            return View(clienteModel);
        }



        private void ComboRepresentantes()
        {
            var listaRepresentantes = representanteRepository.FindAll();
            var selectListRepresentantes = new SelectList(listaRepresentantes, "RepresentanteId", "NomeRepresentante");
            ViewBag.representantes = selectListRepresentantes;
        }

    }
}
