using Microsoft.EntityFrameworkCore;

namespace MonitoramentoAgua.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) 
            : base(options)
        {
        }
        public DbSet<Models.MedicaoAgua> MedicoesAgua { get; set; }
    }
}
