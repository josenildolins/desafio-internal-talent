using Microsoft.EntityFrameworkCore;

namespace Desafio.Internal.Talent.Api.Data
{
    public class ClientAPIDbContext : DbContext
    {
        public ClientAPIDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Cliente> Cliente { get; set; }
    }
}
