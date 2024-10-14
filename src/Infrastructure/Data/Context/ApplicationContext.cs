using ProjetoOdontoPrev.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ProjetoOdontoPrev.src.Infrastructure.Data.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        public DbSet<CadastroClienteEntity> Cliente { get; set; }
    
    }
}
