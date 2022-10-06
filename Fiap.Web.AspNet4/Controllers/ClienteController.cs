using Fiap.Web.AspNet4.Models;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Web.AspNet4.Controllers
{
    public class ClienteController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
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

            return View("Sucesso");
        }

    }
}
