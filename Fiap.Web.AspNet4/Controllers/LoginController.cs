using AutoMapper;
using Fiap.Web.AspNet4.Models;
using Fiap.Web.AspNet4.Repository;
using Fiap.Web.AspNet4.Repository.Interface;
using Fiap.Web.AspNet4.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Web.AspNet4.Controllers
{
    public class LoginController : Controller
    {

        private readonly IUsuarioRepository usuarioRepository;
        private readonly IMapper mapper;

        public LoginController(IUsuarioRepository _usuarioRepository, IMapper _mapper)
        {
            usuarioRepository = _usuarioRepository;
            mapper = _mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login( LoginViewModel loginViewModel )
        {

            UsuarioModel usuarioModel = mapper.Map<UsuarioModel>(loginViewModel);
            var usuarioRetorno = usuarioRepository.Login(usuarioModel);

            if ( usuarioRetorno != null && usuarioRetorno.UsuarioId != 0 )
            {
                return RedirectToAction("Index", "Home");
            } else
            {
                return View("Index");
            }

            
        }

    }
}
