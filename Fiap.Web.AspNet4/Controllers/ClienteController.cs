using Fiap.Web.AspNet4.Models;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Web.AspNet4.Controllers
{
    public class ClienteController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            // var resultado = SELECT * FROM tabelaCliente;

            var listaClientes = new List<ClienteModel>();
            listaClientes.Add(new ClienteModel
            {
                ClienteId = 1,
                Nome = "Flávio",
                Email = "fmoreni@gmail.com",
                DataNascimento = DateTime.Now,
                Observacao = "OBS1"
            });
            listaClientes.Add(new ClienteModel
            {
                ClienteId = 2,
                Nome = "Eduardo",
                Email = "eduardo@gmail.com",
                DataNascimento = DateTime.Now,
                Observacao = "OBS3"
            });
            listaClientes.Add(new ClienteModel
            {
                ClienteId = 3,
                Nome = "Moreni",
                Email = "moreni@gmail.com",
                DataNascimento = DateTime.Now,
                Observacao = "OBS3"
            });
            listaClientes.Add(new ClienteModel
            {
                ClienteId = 4,
                Nome = "Luan",
                Email = "luan@gmail.com",
                DataNascimento = DateTime.Now,
                Observacao = "OBS4"
            });


            //ViewBag.Clientes = listaClientes;
            //ViewData["Clientes"] = listaClientes;
            //TempData["Clientes"] = listaClientes;

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
            Console.WriteLine(clienteModel.Nome);
            Console.WriteLine(clienteModel.Sobrenome);

            // ClasseBancoDados.Insert( clienteModel );

            TempData["Mensagem"] = "Cliente inserido com sucesso";

            return RedirectToAction("Index");
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


    }
}
