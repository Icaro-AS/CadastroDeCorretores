using Microsoft.EntityFrameworkCore;


namespace CadastroCorretores.Models
{
    public class CorretorDbContext : DbContext
    {
        public DbSet<CorretorModel> corretorModels { get; set; }

        public CorretorDbContext(DbContextOptions<CorretorDbContext> options) : base(options) 
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<CorretorModel>().ToTable("CadastroCorretores");
        }
    }
}
