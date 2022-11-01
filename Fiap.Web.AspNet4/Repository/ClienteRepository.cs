using Fiap.Web.AspNet4.Data;
using Fiap.Web.AspNet4.Models;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Web.AspNet4.Repository
{
    public class ClienteRepository
    {

        private readonly DataContext dataContext;
        public ClienteRepository(DataContext context)
        {
            dataContext = context;
        }


        public List<ClienteModel> FindAll()
        {
            return dataContext
                    .Clientes // SELECT * FROM Clientes
                        .Include( r => r.Representante )  // inner join
                            .OrderBy( c => c.Nome )
                                .ToList<ClienteModel>();
        }

        public ClienteModel FindById(int id)
        {
            //return dataContext.Clientes.Find(id);

            var clienteModel =
                dataContext.Clientes // SELECT * FROM Clienter
                    .Include(r => r.Representante) // Inner JOIN
                    .SingleOrDefault(c => c.ClienteId == id ); // Where

            return clienteModel;
        }

        public void Insert(ClienteModel clienteModel)
        {
            dataContext.Clientes.Add(clienteModel);
            dataContext.SaveChanges();
        }

        public void Update(ClienteModel clienteModel)
        {
            dataContext.Clientes.Update(clienteModel);
            dataContext.SaveChanges();
        }

        public void Delete(int id)
        {
            ClienteModel clienteModel = new ClienteModel();
            clienteModel.ClienteId = id;
            Delete(clienteModel);
        }

        public void Delete(ClienteModel clienteModel)
        {
            dataContext.Clientes.Remove(clienteModel);
            dataContext.SaveChanges();
        }


    }
}
