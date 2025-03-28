using Eventos.Domain.Entities;
using Eventos.Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;

namespace Eventos.Infra.Data.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<Category> Categorys { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Encontra todas as entidades que herdam BaseEntity
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var entity = entityType.ClrType;
                // Verifica se a entidade herda de BaseEntity
                if (typeof(BaseEntity).IsAssignableFrom(entity))
                {
                    var entityBuilder = modelBuilder.Entity(entity);
                    // Configura created_at para usar GETDATE() como valor padrão
                    entityBuilder.Property(nameof(BaseEntity.CreatedAt))
                        .HasDefaultValueSql("GETDATE()");
                    // Configura is_deleted para ter false como valor padrão
                    entityBuilder.Property(nameof(BaseEntity.IsDeleted))
                        .HasDefaultValue(false);
                    // 'Description' deve ser único
                    modelBuilder.Entity<Category>()
                        .HasIndex(c => c.Description)
                        .IsUnique();
                }
            }
        }
    }
}
