using Microsoft.EntityFrameworkCore;
using GestaoResiduo.Models;

namespace GestaoResiduo.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Residuo> Residuos { get; set; }
        // public DbSet<Notificacao> Notificacoes { get; set; }
        // public DbSet<Coleta> Coletas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Residuo>(entity =>
            {
                entity.ToTable("RESIDUO");

                entity.HasKey(r => r.IdResiduo);
                entity.Property(r => r.IdResiduo).HasColumnName("ID_RESIDUO");
                entity.Property(r => r.Tipo).HasColumnName("TIPO");
                entity.Property(r => r.Descricao).HasColumnName("DESCRICAO");
            });

            // modelBuilder.Entity<Notificacao>().ToTable("NOTIFICACAO");
            // modelBuilder.Entity<Coleta>().ToTable("COLETA");
        }
    }
}
