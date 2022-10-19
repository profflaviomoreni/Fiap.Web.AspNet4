using Fiap.Web.AspNet4.Data;
using Fiap.Web.AspNet4.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Fiap.Web.AspNet4.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly DataContext dataContext;

        public HomeController(ILogger<HomeController> logger, DataContext ctx)
        {
            _logger = logger;
            dataContext = ctx;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {

            /*
            RepresentanteModel model = new RepresentanteModel();
            model.RepresentanteId = 3;
            model.NomeRepresentante = "Flavio Updated";

            dataContext.Representantes.Update(model);
            dataContext.SaveChanges();
            */

            /*
            RepresentanteModel model = new RepresentanteModel();
            model.RepresentanteId = 2;

            dataContext.Representantes.Remove(model);
            dataContext.SaveChanges();
            */



            /*
            var representantes = dataContext.Representantes.ToList();
            Console.WriteLine(representantes.Count());
            */

            /*
            var representante = dataContext.Representantes.Find(2);
            Console.WriteLine(representante.NomeRepresentante);
            */

            /*
            RepresentanteModel model = new RepresentanteModel();
            model.NomeRepresentante = "Fabricio";
            model.Token = "Fabricio";

            dataContext.Representantes.Add(model);
            dataContext.SaveChanges();
            */

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}