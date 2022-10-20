using Fiap.Web.AspNet4.Models;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Web.AspNet4.Data
{
    public class DataContext : DbContext
    {

        public DbSet<RepresentanteModel> Representantes { get; set; }

        public DbSet<FornecedorModel> Fornecedores { get; set; }


        public DataContext(DbContextOptions options) : base(options)
        {
        }

        protected DataContext()
        {
        }
    }
}
