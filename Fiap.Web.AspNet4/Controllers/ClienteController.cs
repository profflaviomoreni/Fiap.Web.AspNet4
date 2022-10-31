using Fiap.Web.AspNet4.Data;
using Fiap.Web.AspNet4.Models;
using Fiap.Web.AspNet4.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Web.AspNet4.Controllers
{
    public class ClienteController : Controller
    {

        private readonly ClienteRepository clienteRepository;

        public ClienteController(DataContext dataContext)
        {
            clienteRepository = new ClienteRepository(dataContext);
        }


        [HttpGet]
        public IActionResult Index()
        {
            var listaClientes = clienteRepository.FindAll();
            return View(listaClientes);
        }

        [HttpGet]
        public IActionResult Novo()
        {
            return View();
            //return Content("Fiap Asp.NET Core");
            //return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Novo(ClienteModel clienteModel)
        {
            if (ModelState.IsValid)
            {
                // UPDATE tabela VALUES ...
                TempData["Mensagem"] = "Cliente cadastrado com sucesso";
                return RedirectToAction("Index");
            }
            else
            {
                return View(clienteModel);
            }
        }


        [HttpGet]
        public IActionResult Editar(int id)
        {
            // var cliente = "SELECT ... FROM cliente WHERE Id = {id}";
            var clienteModel = new ClienteModel();

            if (id == 1)
            {
                clienteModel = new ClienteModel
                {
                    ClienteId = 1,
                    Nome = "Flavio",
                    Email = "fmoreni@gmail.com",
                    DataNascimento = DateTime.Now,
                    Observacao = "OBS1"
                };
            }
            else if (id == 2)
            {
                clienteModel = new ClienteModel
                {
                    ClienteId = 2,
                    Nome = "Eduardo",
                    Email = "eduardo@gmail.com",
                    DataNascimento = DateTime.Now,
                    Observacao = "OBS3"
                };
            }
            else
            {
                clienteModel = new ClienteModel
                {
                    ClienteId = 3,
                    Nome = "Moreni",
                    Email = "moreni@gmail.com",
                    DataNascimento = DateTime.Now,
                    Observacao = "OBS3"
                };
            }

            return View(clienteModel);
        }


        [HttpPost]
        public IActionResult Editar(ClienteModel clienteModel)
        {
            if ( ModelState.IsValid  ) {
                // UPDATE tabela VALUES ...
                TempData["Mensagem"] = "Cliente editado com sucesso";
                return RedirectToAction("Index");
            }
            else
            {
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


    }
}
