using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class VirticketDbContext : DbContext
    {
        public VirticketDbContext(DbContextOptions<VirticketDbContext> options)
            : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Evento> Eventos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurar valores por defecto, índices, relaciones, etc.
            modelBuilder.Entity<Usuario>()
                .Property(u => u.Rol)
                .HasDefaultValue("User");
        }
    }
}