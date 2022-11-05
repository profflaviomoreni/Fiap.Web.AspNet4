using Fiap.Web.AspNet4.Models;

namespace Fiap.Web.AspNet4.Repository.Interface
{
    public interface IUsuarioRepository
    {

        public UsuarioModel Login(string username, string password);

    }
}
